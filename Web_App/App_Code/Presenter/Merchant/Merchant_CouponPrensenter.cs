using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_CouponPrensenter
{

    IMerchant_CouponEntryView _view;
    MerchantModel _model;
    public Merchant_CouponPrensenter(IMerchant_CouponEntryView view)
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
        _view.Merchant_Coupons = _model.GetAllCoupons();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            Merchant_Coupon var = new Merchant_Coupon();

            var.MID = _view.MID;
            var.Coupon = _view.Coupon;
            var.CouponForDevice =(Constants.Device)_view.CouponForDevice;
            var.Offer = _view.Offer;
            var.ValidTill = _view.ValidTill;
            var.NavigationURL = _view.NavigationURL;

            _model.DBOperation(Constants.Action.Insert, var);
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

    void _view_BulkInsert(object sender, EventArgs e)
    {
        try
        {
            foreach (Merchant_Coupon _item in _view.Merchant_Coupons)
            {

                Merchant_Coupon c = new Merchant_Coupon();

                c.MID = _item.MID;
                c.CouponForDevice = _item.CouponForDevice;
                c.Coupon = _item.Coupon;
                c.Offer = _item.Offer;
                c.ValidTill = _item.ValidTill;
                c.NavigationURL = _item.NavigationURL;
              
                _model.DBOperation(Constants.Action.Insert, c);
            }
            _view.strMessage = "Successfully bulk insert added!!!";
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
            Merchant_Coupon c = new Merchant_Coupon();
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