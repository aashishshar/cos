using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EntityData;
using System.Collections.Specialized;

public partial class frmDealByBrand : BasePage
{
    SqlConnection con = new SqlConnection();
    DataTable dtCategory;
    DataTable dtMerchant;
    #region Private Properties
    public int pageSize { get; set; }
    public string BName { get; set; }
    public string BID { get; set; }
    private int CurrentPage
    {
        get
        {
            object objPage = ViewState["_CurrentPage"];
            int _CurrentPage = 0;
            if (objPage == null)
            {
                _CurrentPage = 0;
            }
            else
            {
                _CurrentPage = (int)objPage;
            }
            return _CurrentPage;
        }
        set { ViewState["_CurrentPage"] = value; }
    }
    private int fistIndex
    {
        get
        {

            int _FirstIndex = 0;
            if (ViewState["_FirstIndex"] == null)
            {
                _FirstIndex = 0;
            }
            else
            {
                _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
            }
            return _FirstIndex;
        }
        set { ViewState["_FirstIndex"] = value; }
    }
    private int lastIndex
    {
        get
        {

            int _LastIndex = 0;
            if (ViewState["_LastIndex"] == null)
            {
                _LastIndex = 0;
            }
            else
            {
                _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
            }
            return _LastIndex;
        }
        set { ViewState["_LastIndex"] = value; }
    }
    #endregion

    #region PagedDataSource
    PagedDataSource _PageDataSource = new PagedDataSource();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        pageSize = 100;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
        this.BName = Convert.ToString(Page.RouteData.Values["BrandName"]);
        this.BID = Convert.ToString(Page.RouteData.Values["BrandID"]);
        if (!IsPostBack)
        {
            Load_tree(BName, BID);
            TreeView1.TabIndex = 3;
            BindRecord("");
        }
    }
   
    #region "SEO"
    private void SetSEOTags(DataTable dataTable, string categoryName)
    {
        clsSeoDetail detail = clsSeoClass.GetSEODetails(dataTable, categoryName);
        this.Title = detail.SeoTitle;
        this.MetaDescription = detail.SeoDescription;
        this.MetaKeywords = detail.SeoKeyword;
    }
    #endregion
    public void Load_tree(string category,string categoryID)
    {
        //if (category.ToLower() == "mobile and tablets" || category.ToLower() =="electronics and appliances")
        //    category = "All";
        SqlCommand cmd = new SqlCommand("adv_FindAllBrand", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", category);
        cmd.Parameters.AddWithValue("@categoryID", categoryID);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);
        ViewState["checkvalue"] = null;
        TreeView1.Nodes.Clear();
        SetSEOTags(dtp, category);
        TreeNode tnParent = new TreeNode();
        string AllBrand = string.Empty;
        string AllBrandWithNoColun = string.Empty;
        foreach (DataRow dr in dtp.Rows)
        {
            if (dtp.Rows.IndexOf(dr) == 0)
            {
                tnParent.Text = dr["BrandName"].ToString();
                tnParent.Value = dr["CategoryID"].ToString();
                string value1 = dr["CategoryID"].ToString();
                tnParent.Expand();
                TreeView1.Nodes.Add(tnParent);
            }
            else
            {
                TreeNode child = new TreeNode();
                //child.Text = dr["BrandName"].ToString().Trim();
                //child.Value = dr["CategoryID"].ToString().Trim();
                AllBrand = AllBrand + "'" + dr["BrandName"].ToString().Trim()+ "'," ;
                //child.Expand();
                //child.Selected = false;
                //tnParent.ChildNodes.Add(child);
                child.Text= dr["BrandName"].ToString();// dtp.Rows[dtp.Rows.IndexOf(dr)]["BrandName"].ToString();// "name" + dtp.Rows.IndexOf(dr);
                child.Value = Convert.ToString(dtp.Rows.IndexOf(dr)); 
                //child.Value = Convert.ToString(dtp.Rows.IndexOf(dr));// Convert.ToString(dtp.Rows.IndexOf(dr));
                tnParent.ChildNodes.Add(child);
            }
        }

        AllBrand = AllBrand.TrimEnd(',');
        BindCategory(AllBrand);
        BindMerchant(AllBrand);
       
    }
    public void BindMerchant(string BrandName)
    {
        string strAllcategory = string.Empty;
        string sql = "select distinct MID,MerchantNameDetail + ' ('+ cast(COUNT(*) as varchar(50))+')' as MerchantNameDetail from Mst_Category A  inner join Adv_Product_Common C on A.CategoryID_N=C.CategoryID_N inner join Adv_Mst_Merchant D on D.MID=C.Ad_For where isnull(Brand,'')!='' and C.Brand in(" + BrandName + ") group by MID,MerchantNameDetail";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        #region Record Count For Paging
        string sqlCount = "select (count(*)/" + pageSize + ")+1 from Mst_Category A  inner join Adv_Product_Common C on A.CategoryID_N=C.CategoryID_N inner join Adv_Mst_Merchant D on D.MID=C.Ad_For where isnull(Brand,'')!='' and C.Brand in(" + BrandName + ")";
        SqlDataAdapter daCount = new SqlDataAdapter(sqlCount, con);
        DataTable dtCount = new DataTable();
        daCount.Fill(dtCount);
        ViewState["TotalPages"] = dtCount.Rows[0][0].ToString();
        #endregion
        DataTable dt = new DataTable();
        da.Fill(dt);
        chkMerchant.DataSource = dt;
        chkMerchant.DataTextField = "MerchantNameDetail";
        chkMerchant.DataValueField = "MID";
        chkMerchant.DataBind();
        if (chkMerchant.Items.Count > 0)
            divmerchant.Visible = true;
        else
            divmerchant.Visible = false;
    }
    public void BindCategory(string BrandName)
    {
        string strAllcategory = string.Empty;
        string sql = "select A.CategoryID_N,CategoryName_V + ' ('+ cast(COUNT(*) as varchar(50))+')' as Categorydetail from Mst_Category A inner join Adv_Product_Common C on A.CategoryID_N=C.CategoryID_N  where  C.Brand in(" + BrandName + ") and isnull(Brand,'')!='' group by  A.CategoryID_N,CategoryName_V order by CategoryName_V";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        chkCategory.DataSource = dt;
        chkCategory.DataTextField = "Categorydetail";
        chkCategory.DataValueField = "CategoryID_N";
        chkCategory.DataBind();
        if (chkCategory.Items.Count > 0)
            divCategory.Visible = true;
        else
            divCategory.Visible = false;

    }
    public DataTable BindAllBrand()
    {
       // string BrandName = Convert.ToString(Request.QueryString["Brandname"]);
        //string BrandID = Convert.ToString(Request.QueryString["BrandID"]);
        SqlCommand cmd = new SqlCommand("adv_FindAllBrand", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", BName);
        cmd.Parameters.AddWithValue("@categoryID", BID);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);

        DataTable dtBrand = new DataTable();
        dtBrand.Columns.Add("BrandName");

        for (int i = 1; i < dtp.Rows.Count; i++)
        {
            DataRow drBrand = dtBrand.NewRow();
            drBrand["BrandName"] = dtp.Rows[i]["BrandName"].ToString();
            dtBrand.Rows.Add(drBrand);
        }
        return dtBrand;
    }
    public void BindRecord(string sortby)
    {
        try
        {
            DataTable dtprice = new DataTable();
            dtprice.Columns.Add("HighPrice");
            dtprice.Columns.Add("LowPrice");
            if (txtPriceTo.Text != string.Empty && txtpriceFrom.Text != string.Empty)
            {
                DataRow drPrice = dtprice.NewRow();
                drPrice["HighPrice"] = txtPriceTo.Text;
                drPrice["LowPrice"] = txtpriceFrom.Text;
                dtprice.Rows.Add(drPrice);
            }


            DataTable dtp = new DataTable();
            dtp = BindAllBrand();
            dtMerchant = new DataTable();
            dtMerchant.Columns.Add("merchantID");
            dtMerchant.Columns.Add("merchantName");
            foreach (ListItem lstMerchat in chkMerchant.Items)
            {
                if (lstMerchat.Selected)
                {
                    DataRow dr = dtMerchant.NewRow();
                    dr["merchantID"] = lstMerchat.Value;
                    string input = string.Empty;
                    int index = lstMerchat.Text.LastIndexOf("(");
                    if (index > 0)
                        input = lstMerchat.Text.Substring(0, index - 1);
                    dr["merchantName"] = input;
                    dtMerchant.Rows.Add(dr);
                }
            }

            dtCategory = new DataTable();
            dtCategory.Columns.Add("CategoryID_N");
            dtCategory.Columns.Add("CategoryName_V");

            foreach (ListItem lstCategory in chkCategory.Items)
            {
                if (lstCategory.Selected)
                {
                    DataRow dr = dtCategory.NewRow();
                    dr["CategoryID_N"] = lstCategory.Value;
                    string input = string.Empty;
                    int index = lstCategory.Text.LastIndexOf("(");
                    if (index > 0)
                        input = lstCategory.Text.Substring(0, index - 1);
                    dr["CategoryName_V"] = input;
                    dtCategory.Rows.Add(dr);
                }
            }

            SqlCommand cmd = new SqlCommand("GetOfferItemPageWiseSearchForBrand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageIndex", 1);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);
            cmd.Parameters.AddWithValue("@RecordCount", "");
            cmd.Parameters.AddWithValue("@categoryName_V", dtCategory);
            cmd.Parameters.AddWithValue("@Brandname", dtp);
            cmd.Parameters.AddWithValue("@MerchantName", dtMerchant);
            cmd.Parameters.AddWithValue("@searchType", "");
            cmd.Parameters.AddWithValue("@sortby", sortby);
            cmd.Parameters.AddWithValue("@price", dtprice);

            SqlDataAdapter daP = new SqlDataAdapter(cmd);
            DataTable dtProduct = new DataTable();
            daP.Fill(dtProduct);
            this.lblPageInfo.Text = "Page " + (CurrentPage + 1) + " of " + ViewState["TotalPages"].ToString();
            if (CurrentPage == 0 && Convert.ToInt32(ViewState["TotalPages"]) * pageSize > pageSize)
            {
                lbtnPrevious.Enabled = false;
                lbtnNext.Enabled = true;
                lbtnFirst.Enabled = false;
                lbtnLast.Enabled = true;
            }
            else if (CurrentPage == 0 && Convert.ToInt32(ViewState["TotalPages"]) * pageSize <= pageSize)
            {
                lbtnPrevious.Enabled = false;
                lbtnNext.Enabled = false;
                lbtnFirst.Enabled = false;
                lbtnLast.Enabled = false;
            }
            else if (Convert.ToInt32(ViewState["TotalPages"]) == CurrentPage + 1)
            {
                lbtnPrevious.Enabled = true;
                lbtnNext.Enabled = false;
                lbtnFirst.Enabled = true;
                lbtnLast.Enabled = false;
            }
            else
            {
                lbtnPrevious.Enabled = true;
                lbtnNext.Enabled = true;
                lbtnFirst.Enabled = true;
                lbtnLast.Enabled = true;
            }
            clsAssignDataCollection getVW_Item = new clsAssignDataCollection();

            uc_VwProduct1.ProductItemBind(getVW_Item.GetViewProductCommon(dtProduct.ToList<vw_OfferItem>()));
            doPaging();
        }
        catch (Exception ex)
        { }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {   
        TreeView1.SelectedNode.SelectAction = TreeNodeSelectAction.Select;
        string val = TreeView1.SelectedNode.Text;
        if (TreeView1.SelectedNode.Text.ToLower() == "mobile and tablets" || TreeView1.SelectedNode.Text.ToLower() == "electronics and appliances")
            val = "All";
        else
             val = TreeView1.SelectedNode.Text;
        string val1 = BID;
        ChangeURL(val,val1);
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        BindRecord("");
    }
    protected void chkCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRecord( "");
        txtCategory.Text = string.Empty;
    }
    protected void chkMerchant_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRecord("");
        txtmerchant.Text = string.Empty;
    }
    protected void lnkLowPrice_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        BindRecord(lnk.Text);
    }
   
    public void ChangeURL(string categoryName,string categoryID)
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string[] separateURL = url.Split('?');
        //NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]);
        //queryString["Brandname"] = categoryName;
        //url = separateURL[0] + "?" + queryString.ToString();
        url = separateURL[0].Replace(Convert.ToString(Page.RouteData.Values["BrandName"]), categoryName).Replace(Convert.ToString(Page.RouteData.Values["BrandID"]), categoryID);
        Response.Redirect(url);
    }


    #region DoPaging
    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");

        fistIndex = CurrentPage - 5;


        if (CurrentPage > 5)
        {
            lastIndex = CurrentPage + 5;
        }
        else
        {
            lastIndex = 10;
        }
        if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            fistIndex = lastIndex - 10;
        }

        if (fistIndex < 0)
        {
            fistIndex = 0;
        }

        for (int i = fistIndex; i < lastIndex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        this.dlPaging.DataSource = dt;
        this.dlPaging.DataBind();
    }
    protected void lbtnPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        BindRecord("");

    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {

        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        BindRecord("");

    }
    protected void lbtnFirst_Click(object sender, EventArgs e)
    {

        CurrentPage = 0;
        BindRecord("");


    }
    protected void lbtnNext_Click(object sender, EventArgs e)
    {

        CurrentPage += 1;
        BindRecord("");

    }
    protected void dlPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            BindRecord("");
        }
    }
    protected void dlPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
        if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Style.Add("fone-size", "14px");
            lnkbtnPage.Font.Bold = true;

        }
    }
    #endregion
}