using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class Merchant_ApiURLPrensenter
{

    IMerchant_ApiURLView _view;
    MerchantModel _model;
    public Merchant_ApiURLPrensenter(IMerchant_ApiURLView view)
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
        _view.Merchant_ApiURLs = _model.GetAllApiURLs();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            Merchant_ApiURL c = new Merchant_ApiURL();

            c.APIType = _view.APIType;          
            c.ApiName = _view.ApiName;
            c.ApiURL = _view.ApiURL;
            c.ExpireOn = _view.ExpireOn;
            c.ApiScheduleType = _view.ApiScheduleType;
            c.RunOnTime = _view.RunOnTime;
            _model.DBOperation(Constants.Action.Insert, c);
            _view.strMessage = "Successfully Inserted!!!";                       

            c.ApiName = string.Empty;
            c.ApiURL = string.Empty;            
         
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
            Merchant_ApiURL c = new Merchant_ApiURL();
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