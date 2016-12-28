using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Collections.Specialized;
using EntityData;
using System.Web.UI.HtmlControls;

public partial class frmSearch : BasePage
{
    SqlConnection con = new SqlConnection();
    clsSearchMethod objSearch = new clsSearchMethod();
    #region Private Properties
    public int pageSize { get; set; }
    private int pagingFrom { get; set; }
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

   
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
        this.pageSize = 48;
        if (!IsPostBack)
        {

            string categoryname = Page.RouteData.Values["pageTitle"] as string;//"mobile phones";
            Load_tree(categoryname);
            BindRecord(categoryname, "", "");
            CheckBoxList chk = new CheckBoxList();
            chk.ID = "10";
            BindLeftSearch(categoryname, chk);
        }
    }
    public void BindLeftSearch(string categoryname, CheckBoxList ckhCurrentCheckBox)
    {
        HtmlControl[] htmlctrl = { div1, div2, div3, div4, div5, div6, div7, div8 };
        CheckBoxList[] chkl = new CheckBoxList[] { CheckBoxList1, CheckBoxList2, CheckBoxList3, CheckBoxList4, CheckBoxList5, CheckBoxList6, CheckBoxList7, CheckBoxList8, ckhCurrentCheckBox };
        Label[] lblctrl = new Label[] { Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8 };
        TextBox[] txtctrl = new TextBox[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8 };
        objSearch.BindSearchMethodsForCategory(categoryname, chkl, htmlctrl, lblctrl, txtctrl, (DataTable)ViewState["DatasetResult"]);
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string val = TreeView1.SelectedNode.Text;
        ChangeURL(val);
    }
    public void ChangeURL(string categoryName)
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string[] separateURL = url.Split('/');
        //NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[0]);
        //queryString["categoryname"] = categoryName;
        url = url.Replace(separateURL[separateURL.Length-1], categoryName);
        Response.Redirect(url);
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
    #region Bind Category Tree
    public void Load_tree(string category)
    {
        SqlCommand cmd = new SqlCommand("adv_FindAllParentForCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", category);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);
        ViewState["checkvalue"] = null;
        TreeView1.Nodes.Clear();
        SetSEOTags(dtp, category);
        foreach (DataRow dr in dtp.Rows)
        {
            if (Convert.ToString(dr["ParentCategoryID_N"]) == string.Empty)
            {
                TreeNode tnParent = new TreeNode();
                tnParent.Text = dr["CategoryName_V"].ToString();
                tnParent.Value = dr["CategoryID_N"].ToString();
                string value = dr["CategoryID_N"].ToString();
                tnParent.Expand();
                TreeView1.Nodes.Add(tnParent);
                FillParentChild(tnParent, value, category);
            }
        }
    }
    public void FillParentChild(TreeNode parent, string ID, string category)
    {
        SqlCommand cmd = new SqlCommand("adv_FindAllParentForCategoryNew", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", category);
        cmd.Parameters.AddWithValue("@parentcategoryId", ID);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode child = new TreeNode();
            child.Text = dr["CategoryName_V"].ToString().Trim();
            child.Value = dr["CategoryID_N"].ToString().Trim();
            string temp = dr["CategoryID_N"].ToString();
            child.Expand();
            parent.ChildNodes.Add(child);
            FillParentChild(child, temp, category);
        }

        if (dt.Rows.Count == 0 && Convert.ToString(ViewState["checkvalue"]) != "assign")
            FillChild(parent, ID);
    }
    public int FillChild(TreeNode parent, string ID)
    {
        string Childquery = " SELECT CategoryName_V,CategoryID_N from vw_FindAllChildForCategory where ParentCategoryID_N='" + ID + "'";
        SqlDataAdapter da = new SqlDataAdapter(Childquery, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode child = new TreeNode();
                child.Text = dr["CategoryName_V"].ToString().Trim();
                child.Value = dr["CategoryID_N"].ToString().Trim();
                string temp = dr["CategoryID_N"].ToString();
                child.Expand();
                parent.ChildNodes.Add(child);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }
    #endregion
    public DataTable BindAllCategory(string categoryName)
    {
        SqlCommand cmd = new SqlCommand("adv_FindAllChildForCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", categoryName);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);
        return dtp;
    }

    public void BindRecord(string categoryName, string sortby, string checkValue)
    {
        try
        {
            DataTable dtp = new DataTable();
            dtp = BindAllCategory(categoryName);
            SqlCommand cmd = new SqlCommand("GetOfferItemPageWiseSearchDynamic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageIndex", CurrentPage + 1);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);
            cmd.Parameters.AddWithValue("@RecordCount", "");
            cmd.Parameters.AddWithValue("@categoryName_V", dtp);

            SqlDataAdapter daP = new SqlDataAdapter(cmd);
            DataSet dtProduct = new DataSet();
            daP.Fill(dtProduct);
            this.pagingFrom = 0;
            
                ViewState["product"] = dtProduct.Tables[1];
                ViewState["DatasetResult"] = dtProduct.Tables[1];
            
            BindDatasetRecordSet();
        }
        catch (Exception ex)
        { }
    }

    #region DoPaging
    public void PagingInRepeater()
    {
        //Paging 
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
        doPaging();
        //EndPaging
    }
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
        BindDatasetRecordSet();
    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        BindDatasetRecordSet();
    }
    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        BindDatasetRecordSet();
    }
    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        BindDatasetRecordSet();
    }
    protected void dlPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            BindDatasetRecordSet();
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

    protected void CheckBoxList1_DataBound(object sender, EventArgs e)
    {
        CheckBoxList chkl = (CheckBoxList)sender;
        HtmlControl divNew = (HtmlControl)chkl.Parent;
        int n = 0;
        for (int i = 0; i < chkl.Items.Count; i++)
        {
            int p = objSearch.BindSearchMethods(chkl.Items[i].Value, (DataTable)ViewState["DatasetResult"]);
            if (p == 0)
                chkl.Items[i].Attributes.Add("style", "display:none;");
            else
            {
                chkl.Items[i].Text = chkl.Items[i].Text + " (" + p.ToString() + ")";
                n = n + 1;
            }
        }
        if (n > 0)
            divNew.Visible = true;
        else
            divNew.Visible = false;
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList chkCurrenCheckbox = (CheckBoxList)sender;
        HtmlControl[] htmlctrl = { div1, div2, div3, div4, div5, div6, div7, div8 };
        CheckBoxList[] chkl = new CheckBoxList[] { CheckBoxList1, CheckBoxList2, CheckBoxList3, CheckBoxList4, CheckBoxList5, CheckBoxList6, CheckBoxList7, CheckBoxList8 };
        ViewState["DatasetResult"] = objSearch.BindSearchResult(chkl, htmlctrl, (DataTable)ViewState["product"]);
        BindDatasetRecordSet();
        BindLeftSearch(Convert.ToString(Page.RouteData.Values["pageTitle"]), chkCurrenCheckbox);
    }

    public void BindDatasetRecordSet()
    {
        DataTable dtDatasetResult = (DataTable)ViewState["DatasetResult"];
        ViewState["TotalPages"] = (Convert.ToInt32(dtDatasetResult.Rows.Count) / pageSize) + 1;
        clsAssignDataCollection getVW_Item = new clsAssignDataCollection();
        DataTable dt = objSearch.FunctionForPaging(dtDatasetResult, CurrentPage, pageSize);
        uc_VwProduct1.ProductItemBind(getVW_Item.GetViewProductCommon(dt.ToList<vw_OfferItem>()));
        PagingInRepeater();

    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        DataTable dtDatasetResult = (DataTable)ViewState["DatasetResult"];
        if (txtpriceFrom.Text != string.Empty && txtPriceTo.Text != string.Empty)
        {
            var priceN = from price in dtDatasetResult.AsEnumerable()
                         where price.Field<double>("ProductPrice") >= Convert.ToInt64(txtpriceFrom.Text) && price.Field<double>("ProductPrice") <= Convert.ToInt64(txtPriceTo.Text)
                         select price;

            ViewState["DatasetResult"] = priceN.CopyToDataTable();
        }
        else
            ViewState["DatasetResult"] = ViewState["product"];

        BindDatasetRecordSet();
        CheckBoxList chk = new CheckBoxList();
        chk.ID = "10";
        BindLeftSearch(Convert.ToString(Page.RouteData.Values["pageTitle"]), chk);
    }
}