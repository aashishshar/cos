using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_OfferPrensenter
{

    IMerchant_OfferEntryView _view;
    MerchantModel _model;
    public Merchant_OfferPrensenter(IMerchant_OfferEntryView view)
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
        _view.BulkInsert += _view_BulkInsert;
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
        _view.Merchant_Offers = _model.GetAllOffers();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            if (_view.Merchant_Offers==null)
            {
                Merchant_Offer c = new Merchant_Offer();

                c.MID = _view.MID;
                c.CouponForDevice = (Constants.Device)_view.CouponForDevice;
                c.Title = _view.Title;
                c.Description = _view.Description;
                c.ValidTill = _view.ValidTill;
                c.NavigationURL = _view.NavigationURL;
                c.CouponCode = _view.CouponCode;
                c.VoucherCodeID = _view.VoucherCodeID;
                c.ActivationDate = _view.StartDate;
                c.OfferType = _view.OfferType;
                _model.DBOperation(Constants.Action.Insert, c);
                _view.strMessage = "Successfully Inserted!!!";
                LoadViewFromModel();

                c.Title = string.Empty;
                c.Description = string.Empty;
                c.NavigationURL = string.Empty;
                c.CouponCode = string.Empty;
            }
            else
            {
                foreach (Merchant_Offer _item in _view.Merchant_Offers)
                {
                    _model.DBOperation(Constants.Action.Insert, _item);
                }
                _view.strMessage = "Successfully insert!!!";
            }
            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.InnerException.Message ;
        }
    }

    void _view_BulkInsert(object sender, EventArgs e)
    {
        try
        {
            foreach (Merchant_Offer _item in _view.Merchant_Offers)
            {

                Merchant_Offer c = new Merchant_Offer();

                c.MID = _item.MID;
                c.CouponForDevice = _item.CouponForDevice;
                c.Title = _item.Title;
                c.Description = _item.Description;
                c.ValidTill = _item.ValidTill;
                c.NavigationURL = _item.NavigationURL;
                c.CouponCode = _item.CouponCode;
                _model.DBOperation(Constants.Action.Insert, c);
            }
            _view.strMessage = "Successfully bulk insert added!!!";
            LoadViewFromModel();         

            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.InnerException.Message;
        }
    }

    void _view_UpateCommand(object sender, EventArgs e)
    {
        try
        {
            //UserGroup c = new UserGroup();

            //c.GroupName = _view.GroupName;

            //c.UserID = (Guid)Membership.GetUser().ProviderUserKey;

            //c.Status_N = Constants.CurrentStatus.Active;
            //c.CreatedBy = Membership.GetUser().ProviderUserKey.ToString();
            //_model.DBOperation(Constants.Action.Insert, c);
            //_view.message = "Successfully Inserted!!!";
            //_view.GroupName = string.Empty;
            //LoadViewFromModel();
            //_view.DataBind();
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
            Merchant_Offer c = new Merchant_Offer();
            _model.DBOperation(Constants.Action.Delete, c, _view.OfferIds);
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