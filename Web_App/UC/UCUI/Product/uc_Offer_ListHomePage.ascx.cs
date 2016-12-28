using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Product_uc_Offer_ListHomePage : System.Web.UI.UserControl, IMerchant_OfferListView
{
    private Merchant_OfferListPrensenter _presenter;

    public event EventHandler SearchRefresh;
    public event EventHandler PagingCommand;
    public UC_UCUI_Product_uc_Offer_ListHomePage()
    {
        
        this._presenter = new Merchant_OfferListPrensenter(this);      
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.PageSize = 12;
        if (!IsPostBack)
        {
            EventHandler paging = this.PagingCommand;
            this.PageIndex = 2;
            this.SearchText = Convert.ToInt16(Constants.Adv_Type.Offer).ToString();
            if (paging != null)
                paging(this, e);

            BindVWOffer(2);


            EventHandler paging1 = this.PagingCommand;
            this.PageIndex = 1;
            this.SearchText = Convert.ToInt16(Constants.Adv_Type.Offer).ToString();
            if (paging1 != null)
                paging1(this, e);

            BindVWOffer1(1);

            EventHandler paging2 = this.PagingCommand;
            this.PageIndex = 3;
            this.SearchText = Convert.ToInt16(Constants.Adv_Type.Offer).ToString();
            if (paging2 != null)
                paging2(this, e);

            BindVWOffer2(3);
        }
        
    }

    private void BindVWOffer(int pageIndex)
    {
        dlItems.Offers = Merchant_Offers;
       // int recordCount = this.TotalRecord;
       // this.PopulatePager(recordCount, pageIndex);

    }
    private void BindVWOffer1(int pageIndex)
    {
        dlItems.Offers1 = Merchant_Offers;
        //int recordCount = this.TotalRecord;
        //this.PopulatePager(recordCount, pageIndex);

    }
    private void BindVWOffer2(int pageIndex)
    {
        dlItems.Offers2 = Merchant_Offers;
        //int recordCount = this.TotalRecord;
        //this.PopulatePager(recordCount, pageIndex);

    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(this.PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        EventHandler paging = this.PagingCommand;
        if (paging != null)
        {
            this.PageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.PageSize = 16;
            this.SearchText = Convert.ToInt16(Constants.Adv_Type.Offer).ToString();
            paging(this, e);
            int totalRecord = this.TotalRecord;
            BindVWOffer(this.PageIndex);
        }

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