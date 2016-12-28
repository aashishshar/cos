using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//

public interface IModelNotification
{
    List<Notification> GetAllNotification();
    List<Notification> GetNotificationText(Int16 notificationType);
    void DBOperation(Constants.Action command, Notification notification = null, List<int> nid = null);	
}