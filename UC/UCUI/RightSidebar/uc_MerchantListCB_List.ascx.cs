using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_RightSidebar_uc_MerchantListCB_List : System.Web.UI.UserControl, IMerchantListView
{
     private MerchantListPrensenter _presenter;

     public UC_UCUI_RightSidebar_uc_MerchantListCB_List()
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
        Int16 currentStatus = Convert.ToInt16(Constants.Status.Active);
        ckbAllMerchant.DataSource = Merchants.Where(p => p.Status == currentStatus).ToList();
        ckbAllMerchant.DataTextField = "MerchantNameDetail";
        ckbAllMerchant.DataValueField = "MID";
        ckbAllMerchant.DataBind();

    }

    public List<string> GetSelectedItemValue()
    {
        List<string> selectedItem = new List<string>();

        foreach (ListItem li in ckbAllMerchant.Items)
        {
            if (li.Selected)
            {
                selectedItem.Add(li.Value);
            }
        }

        return selectedItem;
    }

    public void GetSelectedClearItem()
    {
        foreach (ListItem li in ckbAllMerchant.Items)
        {
            li.Selected = false;
        }

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