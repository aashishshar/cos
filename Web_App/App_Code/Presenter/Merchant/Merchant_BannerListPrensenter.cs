using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_BannerListPrensenter
{

    IMerchant_BannerListView _view;
    MerchantModel _model;
    public Merchant_BannerListPrensenter(IMerchant_BannerListView view)
	{
        _view = view;
        _model = new MerchantModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;      
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
        _view.Merchant_Banners = _model.GetAllBanner(_view.BannerType,_view.CategoryType);
    }  
}