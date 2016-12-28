using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

public partial class UC_UserMain : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // uc_NotificationView1.NotificationType = Constants.NotificationType.UserHome;
       
    }


    public void btnSubmitPost_Click(object sender, EventArgs e)
    {
        //string searchText = txtSearch.Text.Trim();
       // searchresult();
        //searchCommand(sender,e);
        //Server.Transfer("~/UC/Ques/Search.aspx");
    }
   
}
