using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_User_uc_UserSideMenu : System.Web.UI.UserControl
{
    public string CurrentClicked
    {
        get
        {
            Object s = Session["CurrentClicked"];
            return ((s == null) ? null : (string)s);
        }

        set
        {
            Session["CurrentClicked"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void lkbClicked_Click(object sender, EventArgs e)
    {
        LinkButton lkb = (LinkButton)sender;

        CurrentClicked = lkb.CommandName;
        Response.Redirect("~/Uc/User/Default.aspx", false);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.ApplicationInstance.CompleteRequest();

    }
}