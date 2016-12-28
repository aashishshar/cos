using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_DealPrensenter
{

    IMerchant_DealEntryView _view;
    MerchantModel _model;
    public Merchant_DealPrensenter(IMerchant_DealEntryView view)
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
        _view.Merchant_Deals = _model.GetAllDeals();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            foreach(Merchant_Deal deal in _view.Merchant_Deals)
            {
                //Merchant_Deal var = new Merchant_Deal();

                //var.MID = _view.MID;
                //var.ProductCategoryName = _view.ProductCategoryName;
                //var.Title = _view.Title;
                //var.Description = _view.Description;
                //var.Availability = _view.Availability;
                //var.CouponCode = _view.NavigationURL;
                //var.ImageUrl = _view.NavigationURL;

                //var.SerialNo = _view.SerialNo;
                //var.NavigationURL = _view.NavigationURL;
                deal.CreatedDate = DateTime.Now;

                _model.DBOperation(Constants.Action.Insert, deal);
            }
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

    void _view_DeleteCommand(object sender, EventArgs e)
    {
        try
        {
            Merchant_Deal c = new Merchant_Deal();
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