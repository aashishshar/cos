using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Banners_uc_RightSideTop : System.Web.UI.UserControl,IMerchant_BannerListView
{
     private Merchant_BannerListPrensenter _presenter;



     public UC_UCUI_Master_Banners_uc_RightSideTop()
    {
        //this.CategoryType = null;
        BannerType = Convert.ToInt32(Constants.BannerLocation.RightTop);
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

    public List<Merchant_Banner> Merchant_Banners { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }

    public int? BannerType { get; set; }


    public int? CategoryType { get; set; }


    public int? Price { get; set; }

    public int? DiscountedPrice { get; set; }

    public string Description { get; set; }
}