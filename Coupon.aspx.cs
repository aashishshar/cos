using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Coupon : BasePage, IMerchant_CouponListView
{
    private Merchant_CouponListPrensenter _presenter;


    public Coupon()
    {
        this.TakeLatestCoupon = 0;
        this._presenter = new Merchant_CouponListPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string searchText = string.Empty;
            if (Session["S"]!=null)
            {
                this.SearchText = Session["S"].ToString();

                EventHandler search = this.SearchRefresh;
                if (search != null)
                {
                    search(sender, e);
                    ckbAll.Checked = false;
                    uc_AllCouponsList.Coupons = Merchant_Coupons;
                    Merchant_CouponsList = Merchant_Coupons;
                }
            }

            BindApi(); 
            //ckbAllMerchant.SelectedItem.Selected = false;
            ckbAll.Checked = true;
            uc_AllCouponsList.Coupons = Merchant_Coupons;
            Merchant_CouponsList = Merchant_Coupons;
        }
    }


    public List<Merchant_Coupon> Merchant_CouponsList
    {
        get
        {
            object s = ViewState["Merchant_CouponsList"];
            return ((s == null) ? null : (List<Merchant_Coupon>)s);
        }

        set
        {
            ViewState["Merchant_CouponsList"] = value;
        }
    }

    private void BindApi()
    {
        //EnumControl.GetEnumDescriptions<Constants.NameOfMerchants>(ckbAllMerchant);
    }

    protected void ckbAllMerchant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ckbAll.Checked)
        {
            uc_MerchantListCB_ListItem.GetSelectedClearItem();

            if (Merchant_CouponsList.Count > 0)
            {
                uc_AllCouponsList.Coupons = Merchant_CouponsList;
            }
            else
            {
                EventHandler searchRefresh = this.SearchRefresh;
                if (searchRefresh != null)
                {
                    uc_AllCouponsList.Coupons = Merchant_CouponsList;
                }
            }
        }

    }
    protected void ckbAll_CheckedChanged(object sender, EventArgs e)
    {
        if (ckbAll.Checked)
        {
            uc_MerchantListCB_ListItem.GetSelectedClearItem();

            uc_AllCouponsList.Coupons = Merchant_CouponsList;
        }
    }

    public List<Merchant_Coupon> Merchant_Coupons { get; set; }

    protected void lkbFilterSearch_Click(object sender, EventArgs e)
    {
        ckbAll.Checked = false;

        List<Merchant_Coupon> i = (from p in Merchant_CouponsList
                                   where uc_MerchantListCB_ListItem.GetSelectedItemValue().Contains(p.MID.ToString())
                                   select p).ToList();
        uc_AllCouponsList.Coupons = i;
        //if (ckbAll.Checked)
        //{
        //var i=from p in Merchant_CouponsList
        //      where p.
        //}
    }

    public string SearchText { get; set; }

    public event EventHandler SearchRefresh;


    public int TakeLatestCoupon { get; set; }
}