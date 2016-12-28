using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class NotificationPrensenter
{

    INotificationView _view;
    ModelNotification _model;
    public NotificationPrensenter(INotificationView view)
	{
        _view = view;
        _model = new ModelNotification();
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
        _view.Notifications = _model.GetAllNotification();
    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            Notification item = new Notification();
            item.NotificationText = _view.NotificationText;
            item.Status = Constants.Status.Active;
            item.NotificationType = _view.NotificationType;
            _model.DBOperation(Constants.Action.Insert, item);
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
                
                foreach (Notification c in _view.Notifications)
                {
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
            Notification c = new Notification();
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