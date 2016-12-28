using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_ApiURLListPrensenter
{

    IMerchant_ApiURLListView _view;
    MerchantModel _model;
    public Merchant_ApiURLListPrensenter(IMerchant_ApiURLListView view)
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
        _view.Merchant_ApiURLs = _model.GetAllApiURLs();
    }  
}