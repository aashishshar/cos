using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class MerchantPrensenter
{

    IMerchantEntryView _view;
    MerchantModel _model;
    public MerchantPrensenter(IMerchantEntryView view)
	{
        _view = view;
        _model = new MerchantModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.InsertCommand += _view_InsertCommand;
        _view.UpdateCommand += _view_UpateCommand;
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
        _view.Merchants = _model.GetAllMerchants();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
           // Merchant c = new Merchant();

            //foreach (Merchant c in _view.Merchants)
            //{
                Merchant item = new Merchant();
                //item.MerchantID = _view.MerchantID;
                item.MerchantDetails = _view.MerchantDetails;
                item.Status_N = Constants.Status.Active;
                item.CountryCode = "IN";
                item.AffiliateID = _view.AffiliateID;
                item.OMGMID = _view.OMGMID;
                item.MerchantLogoUrl = _view.LogoUrl;
                item.MerchantNameDetail = _view.MerchantNameDetail;
                item.MerchantNameDescription = _view.MerchantNameDescription;
                item.MerchantLinkType = _view.MerchantLinkType;
                //item.PID = c.PID;
                //item.MerchantLogoUrl = c.MerchantLogoUrl;
                //item.ProgramName = c.ProgramName;
                //item.ProductDescription = c.ProductDescription;
                //item.Sector = c.Sector;
                //item.Commision = c.Commision;
                //item.CountryCode = c.CountryCode;
                //item.PayoutType = c.PayoutType;
                //item.CookieDuration = c.CookieDuration;

                //item.DeepLinkEnabled = (Constants.YesNo)c.DeepLinkEnabled;
                //item.ProductfeedAvailable = (Constants.YesNo)c.ProductfeedAvailable;
                //item.UIDTracking = (Constants.YesNo)c.UIDTracking;
                //item.WebsiteUrl = c.WebsiteUrl;
                item.TrackingURL = _view.TrackingURL;



                _model.DBOperation(Constants.Action.Insert, item);
            //}
            _view.strMessage = "Successfully Inserted!!!";            
            LoadViewFromModel();
            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.Message;
        }
    }

    void _view_UpateCommand(object sender, EventArgs e)
    {
        try
        {
            try
            {
                //Merchant c = new Merchant();
                foreach (Merchant c in _view.Merchants)
                {
                   // Merchant item = new Merchant();
                   // item.MID = c.MID;
                   // item.Status = c.Status;
                    //item.AffiliateID = c.AffiliateID;
                    //item.OMGMID = c.OMGMID;


                    _model.DBOperation(Constants.Action.Update, c);
                }
                _view.strMessage = "Successfully updated!!!";
                LoadViewFromModel();

                _view.DataBind();
            }
            catch (Exception ex)
            {
                _view.strMessage = ex.Message;
            }
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
            Merchant c = new Merchant();
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