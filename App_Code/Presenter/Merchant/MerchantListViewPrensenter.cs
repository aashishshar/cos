using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class MerchantListViewPrensenter
{

    IMerchantListView _view;
    MerchantModel _model;
    public MerchantListViewPrensenter(IMerchantListView view)
	{
        _view = view;
        _model = new MerchantModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.ViewCommand += OnViewCommand; 
    }
    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            _view.Merchants = _model.GetAllMerchantsList();
            _view.DataBind();
        }
    }

    void OnViewCommand(object sender, EventArgs e)
    {
       
    }

    private void LoadViewFromModel()
    {
        if (string.IsNullOrEmpty(_view.MerchantName))
        {
            _view.Merchants = _model.GetAllMerchants();
        }
        else
        {
            List<Merchant> items = new List<Merchant>();
            items.Add(_model.FindMerchant(_view.MerchantName));
            _view.Merchants=items;
        }
    }  
}