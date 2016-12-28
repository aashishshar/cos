using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>

public class Merchant_BannerPrensenter
{

    IMerchant_BannerView _view;
    MerchantModel _model;
    public Merchant_BannerPrensenter(IMerchant_BannerView view)
	{
        _view = view;
        _model = new MerchantModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.InsertCommand += _view_InsertCommand;       
        _view.DeleteCommand += _view_DeleteCommand;
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
        _view.Merchant_Banners = _model.GetAllBanner(null);
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            Merchant_Banner c = new Merchant_Banner();

            c.BannerText = _view.BannerText;
            c.BannerType = _view.BannerType;
            c.BannerURL = _view.BannerURL;
            c.Price = _view.Price;
            c.DiscountedPrice = _view.DiscountedPrice;
            c.Description = _view.Description;
            
            c.BannerLocation = _view.BannerLocation;
            c.MID = _view.MID;

            _model.DBOperation(Constants.Action.Insert, c);
            _view.strMessage = "Successfully Inserted!!!";                       

                  
         
            LoadViewFromModel();

            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.Message;
        }
    }

   
    void _view_DeleteCommand(object sender, EventArgs e)
    {
        try
        {
            Merchant_Banner c = new Merchant_Banner();
            _model.DBOperation(Constants.Action.Delete, c, _view.Ids);
            _view.strMessage = "Successfully Deleted!!!";
            LoadViewFromModel();         

            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.Message;
        }
    }
}