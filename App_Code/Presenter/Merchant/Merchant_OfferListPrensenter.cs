using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_OfferListPrensenter
{

    IMerchant_OfferListView _view;
    MerchantModel _model;
    public Merchant_OfferListPrensenter(IMerchant_OfferListView view)
	{
        _view = view;
        _model = new MerchantModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.SearchRefresh += _view_SearchRefresh;
        _view.PagingCommand += _view_PagingCommand;
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
        if (string.IsNullOrEmpty(_view.SearchText) && _view.TakeLatestCoupon <= 0)
        {
            _view.Merchant_Offers = _model.GetAllOffers();
        }       
        else if (_view.TakeLatestCoupon > 0)
        {
            _view.Merchant_Offers = _model.GetLatestOffers(_view.TakeLatestCoupon);
        }
        else
        {
            _view.Merchant_Offers = _model.GetAllOffersSearchText(_view.SearchText);
        }
    }

    void _view_SearchRefresh(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_view.SearchText))
        {
            LoadViewFromModel();
        }
        else
        {
            _view.Merchant_Offers = _model.GetAllOffersSearchText(_view.SearchText);
        }
    }

    void _view_PagingCommand(object sender, EventArgs e)
    {
        try
        {
            int totalRecord;
            _view.Merchant_Offers = _model.GetAll_Proc_Offer(_view.PageIndex, _view.PageSize, out totalRecord,_view.SearchText);
            _view.TotalRecord = totalRecord;
        }
        catch (Exception ex)
        {
            // _view.strMessage = ex.Message;
        }
    }
   
}