using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_SmallWindow_uc_HotCoupon : System.Web.UI.UserControl, IMerchant_CouponListView
{
    private Merchant_CouponListPrensenter _presenter;


    public UC_UCUI_Master_SmallWindow_uc_HotCoupon()
    {
        this.TakeLatestCoupon = 10;
        this._presenter = new Merchant_CouponListPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCoupon();
        }

    }

    private void BindCoupon()
    {
        rptItem.DataSource = Merchant_Coupons;
        rptItem.DataBind();
    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(50, "...");
    }
    public string SearchText { get; set; }

    public int TakeLatestCoupon { get; set; }

    public event EventHandler SearchRefresh;

    public List<Merchant_Coupon> Merchant_Coupons { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
}