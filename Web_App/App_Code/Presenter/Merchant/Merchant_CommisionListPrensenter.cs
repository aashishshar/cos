using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_CommisionListPrensenter
{

    IMerchant_CommisionListView _view;
    MerchantModel _model;
    public Merchant_CommisionListPrensenter(IMerchant_CommisionListView view)
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
        if (string.IsNullOrEmpty(_view.MerchantName))
            _view.Merchant_Commisions = _model.GetAllCommision();
        else
            _view.Merchant_Commisions = _model.GetCommisionByMerchant(_view.MerchantName);
    }  
}