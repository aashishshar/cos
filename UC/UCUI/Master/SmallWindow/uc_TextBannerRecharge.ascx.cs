using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_SmallWindow_uc_TextBanner : System.Web.UI.UserControl, IMerchant_BannerListView
{
     private Merchant_BannerListPrensenter _presenter;



     public UC_UCUI_Master_SmallWindow_uc_TextBanner()
    {
        this.BannerType = Convert.ToInt32(Constants.BannerLocation.RightBottom);
        this.CategoryType = Convert.ToInt32(Constants.CategoryType.Recharge);
        this._presenter = new Merchant_BannerListPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {          
            BindItems();
        }
    }

    private void BindItems()
    {
        rptItem.DataSource = Merchant_Banners;
        rptItem.DataBind();
    }

    public int? BannerType { get; set; }

    public List<Merchant_Banner> Merchant_Banners { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    public int? CategoryType { get; set; }


    public int? Price { get; set; }

    public int? DiscountedPrice { get; set; }

    public string Description { get; set; }
}