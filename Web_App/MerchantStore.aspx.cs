using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MerchantStore :BasePage,IMerchantListView
{
    private MerchantListViewPrensenter _presenter;

    public MerchantStore()
    {
        this._presenter = new MerchantListViewPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                BindMerchants();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    private void BindMerchants()
    {
        dlMerchants.DataSource = this.Merchants;
        dlMerchants.DataBind();
        //ddlMercharList.DataSource = Merchants;
        //ddlMercharList.DataValueField = "MID";
        //ddlMercharList.DataTextField = "MerchantName";
        //ddlMercharList.DataBind();
        ////ddlMercharList.Attributes.Add("MID", "MID");
        //ddlMercharList.Items.Insert(0, "[ Select Merchant ]");
    }

    public List<Merchant> Merchants { get; set; }

    public string MID { get; set; }

    public string MerchantName { get; set; }


    public event EventHandler ViewCommand;
}