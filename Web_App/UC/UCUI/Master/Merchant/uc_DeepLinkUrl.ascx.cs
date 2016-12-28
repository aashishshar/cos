using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_DeepLinkUrl : System.Web.UI.UserControl, IMerchant_ApiURLListView
{

    private Merchant_ApiURLListPrensenter _presenter;

    public UC_UCUI_Master_Merchant_uc_DeepLinkUrl()
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

    private void BindDDL()
    {

        ddlDeepLinking.DataSource = Merchant_ApiURLs.Where(p => p.APIType == Convert.ToInt32(Constants.API_URL_Type.DeeplinkingURL)).ToList();
        ddlDeepLinking.DataBind();
        ddlDeepLinking.Items.Insert(0, "[ Select Program ]");
    }

    public string SelectedValue()
    {
        return ddlDeepLinking.SelectedValue.ToString();    
    }
    public int SelectedIndex()
    {
        return ddlDeepLinking.SelectedIndex;
    }

    public string GetValueFindByText(string searchText)
    {
        return ddlDeepLinking.Items.FindByText(searchText).Value;
    }
    public List<Merchant_ApiURL> Merchant_ApiURLs { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
}