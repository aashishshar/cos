using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class NotificationListPrensenter
{

    INotificationListView _view;
    ModelNotification _model;
    public NotificationListPrensenter(INotificationListView view)
	{
        _view = view;
        _model = new ModelNotification();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.ViewCommand += OnViewCommand; 
    }
    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
           LoadViewFromModel();
            _view.DataBind();
        }
    }

    void OnViewCommand(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            //_view.Merchants = _model.GetAllMerchantsList();   
            //_view.DataBind();
        }
    }

    private void LoadViewFromModel()
    {
        if (_view.NotificationType == null)
        {
            _view.Notifications = _model.GetAllNotification();
        }
        else
        {
            _view.Notifications = _model.GetNotificationText(Convert.ToInt16(_view.NotificationType));
        }
        
    }  
}