using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_CommisionPrensenter
{

    IMerchant_CommisionView _view;
    MerchantModel _model;
    public Merchant_CommisionPrensenter(IMerchant_CommisionView view)
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
        _view.UpdateCommand += _view_UpdateCommand;
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
        _view.Merchant_Commisions = _model.GetAllCommision();
    }
    void _view_InsertCommand(object sender, EventArgs e)
   {
        try
        {
            foreach (Merchant_Commision view in _view.Merchant_Commisions)
            {
                //Merchant_Commision item = new Merchant_Commision();

                //item.MerchantID = view.MerchantID;
                //item.Commision = view.Commision;
                //item.UserCommision = view.UserCommision;
                //item.ProgramName = view.ProgramName;
                //item.Currency = view.Currency;

                //item.PID = view.PID;
                ////item.MerchantLogoUrl = _view.MerchantLogoUrl;
                //item.ProgramName = view.ProgramName;
                //item.ProductDescription = view.ProductDescription;
                //item.Sector = view.Sector;
                //item.PayoutType = view.PayoutType;
                //item.CookieDuration = view.CookieDuration;
                
                //item.DeepLinkEnabled = (Constants.YesNo)view.DeepLinkEnabled;
                //item.ProductfeedAvailable = (Constants.YesNo)view.ProductfeedAvailable;
                //item.UIDTracking = (Constants.YesNo)view.UIDTracking;
                //item.WebsiteUrl = view.WebsiteUrl;
                //item.TrackingURL = view.TrackingURL;
                //item.Status = _view.Status;

                _model.DBOperation(Constants.Action.Insert, view);
            }
            _view.strMessage = "Successfully Inserted!!!";
            LoadViewFromModel();

            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.InnerException.Message;
        }
    }



    void _view_UpdateCommand(object sender, EventArgs e)
    {
        try
        {
            //foreach (Merchant_Commision view in _view.Merchant_Commisions)
            //{
            _model.DBOperation(Constants.Action.Update, null, null, _view.Merchant_Commisions);
            //}

            _view.strMessage = "Successfully Updated!!!";
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
            Merchant_Commision c = new Merchant_Commision();
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