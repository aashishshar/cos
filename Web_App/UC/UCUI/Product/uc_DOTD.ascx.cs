using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Product_uc_DOTD : System.Web.UI.UserControl, IMerchant_OfferListView
{
    private Merchant_OfferListPrensenter _presenter;

    public event EventHandler SearchRefresh;
    public event EventHandler PagingCommand;
    public UC_UCUI_Product_uc_DOTD()
    {
        
        this._presenter = new Merchant_OfferListPrensenter(this);      
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.PageSize = 100;
        if (!IsPostBack)
        {
            EventHandler paging = this.PagingCommand;
            this.PageIndex = 1;
            this.SearchText = Convert.ToInt16(Constants.Adv_Type.DOTD).ToString();
            if (paging != null)
                paging(this, e);

            BindVWOffer(this.PageIndex);
        }
    }

    private void BindVWOffer(int pageIndex)
    {
        rpItems.DataSource = this.Merchant_Offers;
        rpItems.DataBind();
        //dlItems.Offers = Merchant_Offers;
        //int recordCount = this.TotalRecord;
        //this.PopulatePager(recordCount, pageIndex);

    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(30, "...");
    }

    public string SearchText { get; set; }

    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalRecord { get; set; }

    public int TakeLatestCoupon { get; set; }

    public List<Merchant_Offer> Merchant_Offers { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
}