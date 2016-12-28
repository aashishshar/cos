using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
//using QuestionServiceWebReference;

public class ModelNotification:IModelNotification
{
    #region IModelNotification Members

    clsCommonMethods client;
    public ModelNotification()
    {
        client = new clsCommonMethods();
    }
    public List<Notification> GetNotificationText(short notificationType)
    {
        return client.GetNotificationTextByType(notificationType);
    }
    public List<Notification> GetAllNotification()
    {
        return client.GetAllNotification();
    }
    public void DBOperation(Constants.Action command, Notification notification = null, List<int> nid = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertNotification(notification);
                break;
            case Constants.Action.Delete:
                client.DeleteNotification(nid);
                break;
            case Constants.Action.Update:
                client.UpdateNotification(notification);
                break;
            default:
                break;
        }
    }

    

    
    

    #endregion



    
}