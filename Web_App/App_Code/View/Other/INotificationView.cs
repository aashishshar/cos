using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




public interface INotificationView : INotificationListView
{
    //string MerchantName { get; set; }    
    string NotificationText { get; set; }       
    Constants.NotificationType NotificationType { get; set; }
    Constants.NotificationType Status { get; set; }

    string strMessage { set; }
    List<int> Ids { get; set; }

    event EventHandler InsertCommand;
    event EventHandler UpdateCommand;
    event EventHandler DeleteCommand;
}

public interface INotificationListView : IView
{   
    Constants.NotificationType NotificationType { get; set; }    
    List<Notification> Notifications { get; set; }

    event EventHandler ViewCommand;
}
