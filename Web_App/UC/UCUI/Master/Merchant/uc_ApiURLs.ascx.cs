using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_ApiURLs : System.Web.UI.UserControl,IMerchant_ApiURLListView
{

    private Merchant_ApiURLListPrensenter _presenter;

     public UC_UCUI_Master_Merchant_uc_ApiURLs()
    {
        this._presenter = new Merchant_ApiURLListPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDL();
        }
    }


    public string GetAPIUrl
    {
        get 
        {
            return ddlApiURL.SelectedValue.ToString();
        }
    }

    private void BindDDL()
    {
        ddlApiURL.DataSource = Merchant_ApiURLs;
        ddlApiURL.DataValueField = "ApiURL";
        ddlApiURL.DataTextField = "ApiName";
        ddlApiURL.DataBind();
        ddlApiURL.Items.Insert(0, "[ Select API ]");
    }

    public List<Merchant_ApiURL> Merchant_ApiURLs { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
}