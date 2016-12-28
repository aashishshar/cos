using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MissingCashBack_EntryPresenter
/// </summary>
public class MissingCashBack_EntryPresenter
{
	
     IMissingCashBack_View _view;
     MerchantModel _model;
    public MissingCashBack_EntryPresenter(IMissingCashBack_View view)
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
        _view.MissingCashBack_List = _model.GetAllMissingCashBacks();
    }
     void _view_InsertCommand(object sender, EventArgs e)
     {
         try
         {
             MissingCashBack item = new MissingCashBack();


             item.TransactionDate = _view.TransactionDate;
             item.MID = _view.MID;
             //item.UserID = (Guid)Membership.GetUser().ProviderUserKey;
             item.OrderID = _view.OrderID;
             item.AmountPaid = _view.AmountPaid;
             item.CouponCode = _view.CouponCode;
             item.Details = _view.Details;
             item.FileUrl = _view.FileUrl;
             item.ContactNo = _view.ContactNo;

             item.Status = _view.Status;
             _model.DBOperation(Constants.Action.Insert,item);
             _view.strMessage = "Successfully Submitted!!";
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
             MissingCashBack c = new MissingCashBack();
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