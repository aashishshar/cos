using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class TransactionFeedPrensenter
{

    ITransactionFeedEntryView _view;
    TransactionModel _model;
    public TransactionFeedPrensenter(ITransactionFeedEntryView view)
	{
        _view = view;
        _model = new TransactionModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.InsertCommand += _view_InsertCommand;        
        _view.DeleteCommand += _view_DeleteCommand;
        _view.UpdateCommand += _view_UpdateCommand;
        _view.SearchCommand += _view_SearchCommand;
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
        _view.Transaction_Feeds = _model.GetAllTransactions();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            //Transaction_Feed item = new Transaction_Feed();

            foreach (Transaction_Feed _item in _view.Transaction_FeedInsert)
            {
                Transaction_Feed item = new Transaction_Feed();
                item.ClickTime = _item.ClickTime;
                item.TransactionTime = _item.TransactionTime;
                item.OmgTransactionID = _item.OmgTransactionID;
                item.OmgMerchantRef = _item.OmgMerchantRef;
                item.UID = _item.UID;
                item.UID2 = _item.UID2;
                item.MID = _item.MID;
                item.MerchantName = _item.MerchantName;
                item.PID = _item.PID;
                item.Product = _item.Product;
                item.Referrer = _item.Referrer;
                item.SR = _item.SR;
                item.VR = _item.VR;
                item.NVR = _item.NVR;
                item.Status = _item.Status;
                item.Paid = _item.Paid;
                item.Completed = _item.Completed;
                item.UKey = _item.UKey;
                item.TransactionValue = _item.TransactionValue;
                item.VoucherCode = _item.VoucherCode;
                item.FinalCommision = _item.FinalCommision;
                _model.DBOperation(Constants.Action.Insert, item);
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


    void _view_SearchCommand(object sender, EventArgs e)
    {
        try
        {
            _view.Transaction_Feeds = _model.GetSearchTransactions(_view.FromDate,_view.ToDate,_view.AmountStatus );
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.Message;
        }
    }

    void _view_UpdateCommand(object sender, EventArgs e)
    {
        try
        {
            Transaction_Feed c = new Transaction_Feed();
            _model.DBOperation(Constants.Action.Update, c, _view.Ids);
            _view.strMessage = "Successfully Send to user History!!!";
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
            Transaction_Feed c = new Transaction_Feed();
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