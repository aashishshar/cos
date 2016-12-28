using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MissingCashback_ListPresenter
/// </summary>
public class MissingCashback_ListPresenter
{
    IIMissingCashBack_ListView _view;
    MerchantModel _model;
    public MissingCashback_ListPresenter(IIMissingCashBack_ListView view)
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
        _view.MissingCashBack_List = _model.GetAllMissingCashBacks();
    }  
}