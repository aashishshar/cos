using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_CouponListPrensenter
{

    IMerchant_CouponListView _view;
    MerchantModel _model;
    public Merchant_CouponListPrensenter(IMerchant_CouponListView view)
	{
        _view = view;
        _model = new MerchantModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.SearchRefresh += _view_SearchRefresh;
       
    }
    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
           LoadViewFromModel();
            _view.DataBind();
        }
    }

    private void LoadViewFromModel()
    {
        if (_view.TakeLatestCoupon <= 0)
            _view.Merchant_Coupons = _model.GetAllCoupons();
        else
            _view.Merchant_Coupons = _model.GetLatestCoupons(_view.TakeLatestCoupon);
    }

    void _view_SearchRefresh(object sender, EventArgs e)
    {
        _view.Merchant_Coupons = _model.GetAllCouponsSearchText(_view.SearchText);
    }
    
}