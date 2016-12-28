using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using System.IO;
using System.Net;
using EntityData;

public partial class UC_UCUI_Master_Merchant_uc_Commision : System.Web.UI.UserControl, IMerchant_CommisionView
{
    private Merchant_CommisionPrensenter _presenter;

    public event EventHandler InsertCommand;
    public event EventHandler DeleteCommand;
    public event EventHandler UpdateCommand;

    public UC_UCUI_Master_Merchant_uc_Commision()
    {
        this._presenter = new Merchant_CommisionPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEnum();
            BindItems();
        }
    }

    private void BindItems()
    {
        gvItemsCOM.DataSource = Merchant_Commisions.OrderBy(o=>o.MerchantName);
        gvItemsCOM.DataBind();
        if (gvItemsCOM.Rows.Count > 0)
        {
            gvItemsCOM.UseAccessibleHeader = true;
            gvItemsCOM.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItemsCOM.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    private void BindEnum()
    {

        EnumControl.GetEnumDescriptions<Constants.CurrencyType>(ddlCurrency);
        ddlCurrency.Items.Insert(0, "[ Select Currency ]");
        ddlCurrency.Items.RemoveAt(1);

        EnumControl.GetEnumDescriptions<Constants.YesNo>(ddlUIDTracking);
        ddlUIDTracking.Items.Insert(0, "[ UID ]");
        ddlUIDTracking.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.YesNo>(ddlProductfeedAvailable);
        ddlProductfeedAvailable.Items.Insert(0, "[ Feed Product ]");
        ddlProductfeedAvailable.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.YesNo>(ddlDeepLinkEnabled);
        ddlDeepLinkEnabled.Items.Insert(0, "[ Deeplinking ]");
        ddlDeepLinkEnabled.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.PayoutType>(ddlPayoutType);
        ddlPayoutType.Items.Insert(0, "[ Payout Type ]");
        ddlPayoutType.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.PriceType>(ddlPriceType);
        ddlPriceType.Items.Insert(0, "[ Price Type ]");
        ddlPriceType.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.Status>(ddlStatus);
         ddlStatus.Items.Insert(0, "[ Status ]");
        ddlStatus.Items.RemoveAt(1);
        
    }


    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        List<Merchant_Commision> itemS = new List<Merchant_Commision>();

        if (Insert != null)
        {
            Merchant_Commision item = new Merchant_Commision();
            //lblMessage.Text = string.Empty;
            item.MerchantID = Convert.ToInt32(uc_MerchantDDlList.SelectedMerchant);
            item.PID = Convert.ToInt32(txtPID.Text.Trim());
            item.ProgramName = txtProgramName.Text;
            //MerchantLogoUrl=txtMerchantLogoUrl.Text.Trim();
            item.ProductDescription = txtProductDescription.Text.Trim();
            //Sector = txtMerchantLogoUrl.Text.Trim();
            item.PayoutType = ddlPayoutType.SelectedIndex > 0 ? ddlPayoutType.SelectedValue.ToString() : "";
            item.CookieDuration = txtCookieDuration.Text.Trim();
            item.DeepLinkEnabled = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), ddlDeepLinkEnabled.SelectedValue.ToString());
            item.ProductfeedAvailable = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), ddlProductfeedAvailable.SelectedValue.ToString());
            item.UIDTracking = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), ddlUIDTracking.SelectedValue.ToString());
            item.WebsiteUrl = txtWebsiteUrl.Text.Trim();
            item.TrackingURL = txtTrackingURL.Text.Trim();
            item.PriceType = (Constants.PriceType)Enum.Parse(typeof(Constants.PriceType), ddlPriceType.SelectedValue.ToString());
            item.Status = (Constants.Status)Enum.Parse(typeof(Constants.Status), ddlStatus.SelectedValue.ToString());
            item.UserCommision = txtUserCommision.Text;
            item.Commision = txtCommision.Text; 


            itemS.Add(item);
            this.Merchant_Commisions = itemS;
            Insert(this, e);
            BindItems();
        }

    }

    public DataTable MerchantDataTable
    {
        get
        {
            Object s = ViewState["CommisionData"];

            return ((s == null) ? null : (DataTable)s);
        }

        set
        {
            ViewState["CommisionData"] = value;
        }
    }
    DataTable dt = new DataTable();
    protected void btnPushToDB_Click(object sender, EventArgs e)
    {
        //AssignDataToDbParameter();
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            lblMessage.Text = string.Empty;
            AssignDataToDbParameter();
            Insert(this, e);
            BindItems();
        }

    }

    private void AssignDataToDbParameter()
    {

        //Transaction_Feeds
        ExportToDataTable();
        List<Merchant_Commision> feeds = new List<Merchant_Commision>();
        foreach (DataRow row in MerchantDataTable.Select("ProgrammeStatus='Live'"))
        {
            if (MerchantDataTable.Columns.Contains("MerchantName"))
            {
                Merchant_Commision item = new Merchant_Commision();
                Int64 merID = uc_MerchantDDlList.GetValueFindByText(row["MerchantName"].ToString());
                if (merID != 0)
                {
                    item.MerchantID = merID;
                    item.PID = Convert.ToInt32(row["PID"].ToString());
                    //MerchantLogoUrl=txtMerchantLogoUrl.Text.Trim();
                    item.ProgramName = row["ProductName"].ToString();
                    item.ProductDescription = row["ProductDescription"].ToString();
                    //Sector = txtMerchantLogoUrl.Text.Trim();
                    item.PayoutType = row["PayoutType"].ToString();
                    item.CookieDuration = row["CookieDuration"].ToString();
                    item.DeepLinkEnabled = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), row["DeepLinkEnabled"].ToString());
                    item.ProductfeedAvailable = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), row["ProductFeedAvailable"].ToString());
                    item.UIDTracking = (Constants.YesNo)Enum.Parse(typeof(Constants.YesNo), row["UidTracking"].ToString().Replace(" ", "").ToString());
                    item.WebsiteUrl = row["WebsiteURL"].ToString();
                    item.TrackingURL = row["TrackingURL"].ToString();
                    item.Commision = row["Commission"].ToString().Replace("£", "").ToString();
                    item.PriceType = row["Commission"].ToString().Contains("%") ? Constants.PriceType.Percentage : Constants.PriceType.INR;
                    item.Status = Constants.Status.Active;
                    item.MaximumCommision = null;
                    //item.PriceType = (Constants.PriceType)Enum.Parse(typeof(Constants.PriceType), row["MerchantLogoURL"].ToString());
                    //item.Status = (Constants.Status)Enum.Parse(typeof(Constants.Status), row["MerchantLogoURL"].ToString());


                    //item.MerchantName = row["MerchantName"].ToString();
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
                    //item.Status = Convert.ToInt32((Constants.Status)Enum.Parse(typeof(Constants.Status), row["ProgrammeStatus"].ToString().Replace(" ", "").ToString()));
                    //item.WebsiteUrl = row["WebsiteURL"].ToString();
                    //item.Commision = row["Commission"].ToString();
                    //item.TrackingURL = row["TrackingURL"].ToString();

                    feeds.Add(item);
                }
            }
        }
       
        Merchant_Commisions = feeds;

    }

    private void ExportToDataTable()
    {
        string url = "http://admin.optimisemedia.com/v2/Reports/Affiliate/ProgrammesExport.aspx?Agency=95&Country=0&Affiliate=764019&Search=&Sector=0&UidTracking=False&PayoutTypes=&ProductFeedAvailable=False&Format=XML&AuthHash=31600E6D4717172FC8C62F9C1D35CE11&AuthAgency=95&AuthContact=764019";
        //string newurl = "http://admin.optimisemedia.com/v2/Reports/Affiliate/ProgrammesExport.aspx?Agency=95&Country=0&Affiliate=764019&Search=&Sector=0&UidTracking=False&PayoutTypes=S&ProductFeedAvailable=False&Format=XML&AuthHash=31600E6D4717172FC8C62F9C1D35CE11&AuthAgency=95&AuthContact=764019&ProductType=";

        Uri ur = new Uri(url, UriKind.Absolute);
        //GetPageAsString(ur);
        XElement xele = XElement.Parse(GetPageAsString(ur));// XElement.Load(url);
        dt = clsFileToTable.XElementToDataset(xele).Tables["Detail"];


        if (dt.Rows.Count > 0)
        {
            MerchantDataTable = dt;
            //GridView1.DataSource = dt;
            // GridView1.DataBind();
        }
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

    protected void Delete_Click(object sender, EventArgs e)
    {
        List<int> offerIds = new List<int>();
        foreach (GridViewRow row in gvItemsCOM.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int offerID = Convert.ToInt32(gvItemsCOM.DataKeys[row.RowIndex].Value);
                offerIds.Add(offerID);
            }
        }

        if (offerIds.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.Ids = offerIds;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindItems();
            }
        }
    }

    public Int64? MerchantID
    {
        get
        {
            return Convert.ToInt32(uc_MerchantDDlList.SelectedMerchant);
        }
        set
        {
            uc_MerchantDDlList.SelectedMerchant = value.ToString();
        }
    }
    public string ProgramName
    {
        get
        {
            return txtProgramName.Text.Trim();
        }
        set
        {
            txtProgramName.Text = value;
        }
    }
    public string Commision
    {
        get
        {
            return txtCommision.Text.Trim();
        }
        set
        {
            txtCommision.Text = value;
        }
    }
    public string UserCommision
    {
        get
        {
            return txtUserCommision.Text.Trim();
        }
        set
        {
            txtUserCommision.Text = value;
        }
    }
    public int? Currency
    {
         get
        {
            return Convert.ToInt32(Convert.ToInt32((Constants.CurrencyType)Enum.Parse(typeof(Constants.CurrencyType), ddlCurrency.SelectedValue.ToString())));         

        }
        set
        {
            ddlCurrency.SelectedValue = Convert.ToInt32((Constants.CurrencyType)Enum.Parse(typeof(Constants.CurrencyType), value.ToString())).ToString();
        }       
    }

    public int? PID { get; set; }
   // public string MerchantLogoUrl { get; set; }
    public string ProductDescription { get; set; }
    public string Sector { get; set; }
    public string PayoutType { get; set; }
    public string CookieDuration { get; set; }
    public Constants.YesNo? DeepLinkEnabled { get; set; }
    public Constants.YesNo? ProductfeedAvailable { get; set; }
    public Constants.YesNo? UIDTracking { get; set; }
    public string WebsiteUrl { get; set; }
    public string TrackingURL { get; set; }
    public Constants.PriceType? PriceType { get; set; }
public Constants.Status? Status { get; set; }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public List<int> Ids { get; set; }



    public List<Merchant_Commision> Merchant_Commisions { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
    

    public int? MaximumCommision { get; set; }

    protected void lkbDeactive_Click(object sender, EventArgs e)
    {
        List<Merchant_Commision> coms = new List<Merchant_Commision>();
        foreach (GridViewRow row in gvItemsCOM.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {
                using (Ad_ConnectionString model = new Ad_ConnectionString())
                {
                    int comID = Convert.ToInt32(gvItemsCOM.DataKeys[row.RowIndex].Value);
                    var varlist = (from var in model.Adv_Commisions
                                   where var.CommisionID == comID
                                   select var).FirstOrDefault();
                    if (ddlStatus.SelectedValue.ToString() == Constants.Status.Active.ToString())
                    {
                        varlist.Status = Convert.ToInt32(Constants.Status.Active);
                    }
                    else if (ddlStatus.SelectedValue.ToString() == Constants.Status.DeActive.ToString())
                    {
                        varlist.Status = Convert.ToInt32(Constants.Status.DeActive);
                    }
                    model.SaveChanges();
                }
            }
        }
    }

    protected void lkbUpdate_Click(object sender, EventArgs e)
    {
        List<Merchant_Commision> coms = new List<Merchant_Commision>();
        foreach (GridViewRow row in gvItemsCOM.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {
                Merchant_Commision com = new Merchant_Commision();

                com.CommisionID = Convert.ToInt32(gvItemsCOM.DataKeys[row.RowIndex].Value);
                //com.PID = Convert.ToInt32(gvItemsCOM.DataKeys[row.RowIndex].Value);
                TextBox uCom = (TextBox)row.FindControl("txtUserCommision");
                TextBox maxCom = (TextBox)row.FindControl("txtMaxCommision");
                TextBox Commis = (TextBox)row.FindControl("txtCommision");
                TextBox pTitle = (TextBox)row.FindControl("txtTitle");
                com.ProgramName = pTitle.Text;
                com.UserCommision = uCom.Text;
                com.Commision = Commis.Text;
                if (!string.IsNullOrEmpty(maxCom.Text.Trim()))
                    com.MaximumCommision = Convert.ToInt32(maxCom.Text.Trim());// !string.IsNullOrEmpty(maxCom.Text.Trim()) ? Convert.ToInt32(maxCom.Text.Trim()) : null;

                coms.Add(com);
            }
        }

        if (coms.Count > 0)
        {
            EventHandler update = this.UpdateCommand;
            if (update != null)
            {
                this.Merchant_Commisions = coms;
                //lblMessage.Text = string.Empty;
                update(this, e);
                BindItems();
            }
        }

    }

    public string MerchantName { get; set; }
    
}