using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;
using System.Net;
using System.IO;

public partial class UC_UCUI_Master_Merchant_uc_Merchant : System.Web.UI.UserControl, IMerchantEntryView
{
    public event EventHandler InsertCommand;
    public event EventHandler UpdateCommand;
    public event EventHandler DeleteCommand;

    private MerchantPrensenter _presenter;


    public UC_UCUI_Master_Merchant_uc_Merchant()
    {
        this._presenter = new MerchantPrensenter(this);
    }
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindMerchant();
            BindMerchants();
            BindEnum();
        }

    }

    private void BindMerchants()
    {
        gvItems.DataSource = Merchants;
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }


    private void BindMerchant()
    {
        EnumControl.GetEnumDescriptions<Constants.NameOfMerchants>(ddlMerchantName);
    }
    private void BindEnum()
    {

        EnumControl.GetEnumDescriptions<Constants.CategoryType>(ddlCategoryType);
        ddlCategoryType.Items.Insert(0, "[ Category Type ]");
        ddlCategoryType.Items.RemoveAt(1);

        EnumControl.GetEnumDescriptions<Constants.MerchantLinkType>(ddlMerchantLinkType);
        ddlMerchantLinkType.Items.Insert(0, "[ Merchant Link ]");
        ddlMerchantLinkType.Items.RemoveAt(1);

        
    }

    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            this.LogoUrl = txtLogoUrl.Text.Trim();
            this.MerchantNameDetail = txtMerchantNameDetail.Text.Trim();
            this.TrackingURL = txtTrackingURL.Text.Trim();
            if (ddlMerchantLinkType.SelectedIndex > 0)
            {
                this.MerchantLinkType = Convert.ToInt16(Enum.Parse(typeof(Constants.MerchantLinkType), ddlMerchantLinkType.SelectedValue.ToString()));
                lblMessage.Text = string.Empty;
                Insert(this, e);
                BindMerchants();
            }
            else
            {
                lblMessage.Text = "Select Merchant Link Type.";
            }
        }
    }

    public string MerchantNameDescription
    {
        get
        {
            return txtMerchantNameDescription.Text.Trim();
        }
        set
        {
            txtMerchantNameDescription.Text = value;
        }
    }

    public short? MerchantLinkType { get; set; }

    public string MerchantDetails
    {
        get
        {
            return txtMerchantDetails.Text.Trim();
        }
        set
        {
            txtMerchantDetails.Text = value;
        }
    }

    public int MerchantID
    {
        get
        {
            return 0;// Convert.ToInt32((Constants.NameOfMerchants)Enum.Parse(typeof(Constants.NameOfMerchants), ddlMerchantName.SelectedValue.ToString()));
        }
        set
        {

            //ddlMerchantName.SelectedValue = value.ToString();
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public List<Merchant> Merchants { get; set; }







    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    public List<long> Ids { get; set; }


    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> iIDS = new List<long>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 id = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                iIDS.Add(id);
            }
        }

        if (iIDS.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.Ids = iIDS;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindMerchants();
            }
        }

    }

    protected void lkbDeactive_Click(object sender, EventArgs e)
    {
        List<Merchant> iIDS = new List<Merchant>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 id = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                Merchant item = new Merchant();
                item.MID = id;
                item.Status = Convert.ToInt32(Constants.Status.DeActive);
                iIDS.Add(item);
            }
        }

        if (iIDS.Count > 0)
        {
            EventHandler update = this.UpdateCommand;
            if (update != null)
            {
                this.Merchants = iIDS;
                //lblMessage.Text = string.Empty;
                update(this, e);
                BindMerchants();
            }
        }
    }

    protected void lkbActive_Click(object sender, EventArgs e)
    {
        List<Merchant> iIDS = new List<Merchant>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 id = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                Merchant item = new Merchant();
                item.MID = id;
                item.Status = Convert.ToInt32(Constants.Status.Active);
                iIDS.Add(item);
            }
        }

        if (iIDS.Count > 0)
        {
            EventHandler update = this.UpdateCommand;
            if (update != null)
            {
                this.Merchants = iIDS;
                //lblMessage.Text = string.Empty;
                update(this, e);
                BindMerchants();
            }
        }
    }

    public int? AffiliateID 
    {
        get
        {
            return Convert.ToInt32(txtAffiliateID.Text.Trim());
        }
        set
        {
            txtAffiliateID.Text = value.ToString();
        }
    }

    public int? OMGMID
    {
        get
        {
            return Convert.ToInt32(txtLiveMechantID.Text.Trim());
        }
        set
        {
            txtLiveMechantID.Text = value.ToString();
        }
    }

    protected void btnPushToDB_Click(object sender, EventArgs e)
    {

        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            lblMessage.Text = string.Empty;
            //AssignDataToDbParameter();
            Insert(this, e);
            BindMerchants();
        }

    }

    private void AssignDataToDbParameter()
    {

        //Transaction_Feeds
        ExportToDataTable();
        List<Merchant> feeds = new List<Merchant>();
        foreach (DataRow row in MerchantDataTable.Rows)
        {
            Merchant item = new Merchant();
            item.MerchantName = row["MerchantName"].ToString();
            //item.MerchantLogoUrl = row["MerchantLogoURL"].ToString();
            //item.ProgramName = row["ProductName"].ToString();
            //item.ProductDescription = row["ProductDescription"].ToString();
            //item.PID = Convert.ToInt32(row["PID"].ToString());
            //item.Sector = row["Sector"].ToString();
            //item.CountryCode = row["CountryCode"].ToString();
            //item.PayoutType = row["PayoutType"].ToString();
            //item.CookieDuration = row["CookieDuration"].ToString();
            //item.ProductfeedAvailable = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), row["ProductFeedAvailable"].ToString().Replace(" ", "").ToString());
            //item.DeepLinkEnabled = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), row["DeepLinkEnabled"].ToString().Replace(" ", "").ToString());
            //item.UIDTracking = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), row["UidTracking"].ToString().Replace(" ", "").ToString());
            item.Status = Convert.ToInt32((Constants.Status)Enum.Parse(typeof(Constants.Status), row["ProgrammeStatus"].ToString().Replace(" ", "").ToString()));
            //item.WebsiteUrl = row["WebsiteURL"].ToString();
            //item.Commision = row["Commission"].ToString();
            //item.TrackingURL = row["TrackingURL"].ToString();

            feeds.Add(item);
        }

        Merchants = feeds;

    }

    public DataTable MerchantDataTable
    {
        get
        {
            Object s = ViewState["MerchantData"];

            return ((s == null) ? null : (DataTable)s);
        }

        set
        {
            ViewState["MerchantData"] = value;
        }
    }
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        //if (MerchantDataTable.Rows.Count == 0 || MerchantDataTable!=null)
        //{
        string url = "http://admin.optimisemedia.com/v2/Reports/Affiliate/ProgrammesExport.aspx?Agency=95&Country=26&Affiliate=764019&Search=&Sector=0&UidTracking=False&PayoutTypes=&ProductFeedAvailable=False&Format=XML&AuthHash=31600E6D4717172FC8C62F9C1D35CE11&AuthAgency=95&AuthContact=764019&ProductType="; //"http://admin.omgpm.com/v2/Reports/Affiliate/ProgrammesExport.aspx?Agency=95&Country=0&Affiliate=764019&Search=&Sector=0&UidTracking=False&PayoutTypes=S&ProductFeedAvailable=False&Format=XML&AuthHash=31600E6D4717172FC8C62F9C1D35CE11&AuthAgency=95&AuthContact=764019&ProductType=";

            Uri ur = new Uri(url, UriKind.Absolute);
            XElement xele = XElement.Parse(GetPageAsString(ur));
            dt = clsFileToTable.XElementToDataset(xele).Tables["Detail"];


            if (dt.Rows.Count > 0)
            {
                //MerchantDataTable = dt;
                gvLiveData.DataSource = dt;
                gvLiveData.DataBind();
                UpdateTrackingUrlToMerchant(dt, sender, e);
            }
        //}
    }

    public static string GetPageAsString(Uri address)
    {
        string result = "";

        // Create the web request  
        HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

        // Get response  
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            // Get the response stream  
            StreamReader reader = new StreamReader(response.GetResponseStream());

            // Read the whole contents and return as a string  
            result = reader.ReadToEnd();
        }

        return result;
    }  

    private void UpdateTrackingUrlToMerchant(DataTable dt, object sender, EventArgs e)
    {
        List<Merchant> iIDS = new List<Merchant>();
        foreach (DataRow row in dt.Rows)
        {
            if (row["TrackingUrl"].ToString()!="")
            {
                Uri myUri = new Uri(row["TrackingUrl"].ToString());
                string OMGMID = HttpUtility.ParseQueryString(myUri.Query).Get("MID");
                //Request.QueryString[
                Int32 id = Convert.ToInt32(OMGMID);
                Merchant item = new Merchant();
                item.OMGMID = id;
                if (row["MerchantLogoUrl"].ToString() != "")
                    item.MerchantLogoUrl = row["MerchantLogoUrl"].ToString();
                //item.MerchantLogoUrl
                //item.Status = Convert.ToInt32(Constants.Status.Active);
                item.MerchantNameDetail = row["MerchantName"].ToString();
                item.TrackingURL = row["TrackingUrl"].ToString();
                iIDS.Add(item);
            }
        }

        if (iIDS.Count > 0)
        {
            EventHandler update = this.UpdateCommand;
            if (update != null)
            {
                this.Merchants = iIDS;

                //lblMessage.Text = string.Empty;
                update(this, e);
                BindMerchants();
            }
        }
    }


    private void ExportToDataTable()
    {
        string url = "https://admin.omgpm.com/v2/Reports/Affiliate/ProgrammesExport.aspx?Agency=95&Country=0&Affiliate=764019&Search=&Sector=0&UidTracking=False&PayoutTypes=&ProductFeedAvailable=False&Format=XML&AuthHash=31600E6D4717172FC8C62F9C1D35CE11&AuthAgency=95&AuthContact=764019&ProductType=";

        XElement xele = XElement.Load(url);
        dt = clsFileToTable.XElementToDataset(xele).Tables["Detail"];


        if (dt.Rows.Count > 0)
        {
            MerchantDataTable = dt;
            //gvLiveData.DataSource = dt;
            //gvLiveData.DataBind();
        }
    }


    public string CountryCode { get; set; }


    public string LogoUrl { get; set; }

    public string MerchantNameDetail { get; set; }





    public string TrackingURL { get; set; }

    public Constants.CategoryType CategoryType { get; set; }
    protected void lkbUpdateCategory_Click(object sender, EventArgs e)
    {
        List<Merchant> iIDS = new List<Merchant>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 id = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                Merchant item = new Merchant();
                item.MID = id;
                item.Status = Convert.ToInt32(Constants.Status.Active);
                item.CategoryType = (Constants.CategoryType)Enum.Parse(typeof(Constants.CategoryType), ddlCategoryType.SelectedValue.ToString());
                iIDS.Add(item);
            }
        }

        if (iIDS.Count > 0)
        {
            EventHandler update = this.UpdateCommand;
            if (update != null)
            {
                this.Merchants = iIDS;
               
                //lblMessage.Text = string.Empty;
                update(this, e);
                BindMerchants();
            }
        }
    }

    public string MID { get; set; }

    public string MerchantName { get; set; }


    public event EventHandler ViewCommand;


  
}