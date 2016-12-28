using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_NotificationView : System.Web.UI.UserControl,INotificationListView
{
    public event EventHandler ViewCommand;
    private NotificationListPrensenter _presenter;

    public UC_UCUI_Master_Merchant_uc_NotificationView()
    {
        this._presenter = new NotificationListPrensenter(this);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindItems();
        }
    }

    private void BindItems()
    {
        rptNotification.DataSource = Notifications;
        rptNotification.DataBind();
    }
    public Constants.NotificationType NotificationType { get; set; }
    public List<Notification> Notifications { get; set; }

    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
}