using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_RightSidebar_UC_MerchantList : System.Web.UI.UserControl, IMerchantListView
{
     private MerchantListPrensenter _presenter;

     public UC_UCUI_RightSidebar_UC_MerchantList()
    {
        this._presenter = new MerchantListPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindApi();
        }
    }

    private void BindApi()
    {

        //EnumControl.GetEnumDescriptions<Constants.NameOfMerchants>(rptMerchants);

        rptMerchants.DataSource = Merchants;
        rptMerchants.DataBind();

    }

    public List<Merchant> Merchants { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }

    public string MID { get; set; }

    public string MerchantName { get; set; }


    public event EventHandler ViewCommand;
}