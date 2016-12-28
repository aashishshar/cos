using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MainMaster : System.Web.UI.MasterPage
{
    public MainMaster()
    {
       // uc_NotificationView1.NotificationType = Constants.NotificationType.Home;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        uc_NotificationView1.NotificationType = Constants.NotificationType.Home;
    }
}
