using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class TransactionFeedLListPrensenter
{

    ITransactionFeedListView _view;
    TransactionModel _model;
    public TransactionFeedLListPrensenter(ITransactionFeedListView view)
	{
        _view = view;
        _model = new TransactionModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;      
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
}