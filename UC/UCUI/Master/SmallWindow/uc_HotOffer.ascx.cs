using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_SmallWindow_uc_HotOffer : System.Web.UI.UserControl, IMerchant_OfferListView
{
     private Merchant_OfferListPrensenter _presenter;


    public event EventHandler SearchRefresh;
    public UC_UCUI_Master_SmallWindow_uc_HotOffer()
    {
        this.TakeLatestCoupon = 10;
        this._presenter = new Merchant_OfferListPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOffers();
        }
    }

    private void BindOffers()
    {
        rptItem.DataSource = Merchant_Offers;
        rptItem.DataBind();
    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(40, "...");
    }

    public string SearchText { get; set; }

    public int TakeLatestCoupon { get; set; }

    public List<Merchant_Offer> Merchant_Offers { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalRecord { get; set; }


    public event EventHandler PagingCommand;
}