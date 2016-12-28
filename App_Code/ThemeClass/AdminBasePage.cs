using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminBasePage
/// </summary>
public class AdminBasePage : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        Page.Theme = "Admin";
       

    }
}

public class BasePage : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        //Page.Theme = "Main";
    }
}

public class UserPage : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        Page.Theme = "UserTheme";


    }
}
public class CommonPage : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
        {
            Page.Theme = "UserTheme";
            this.MasterPageFile = "~/UC/MainMaster.master";
        }
        else if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.Author.ToString()))
        {
            Page.Theme = "UserTheme";
            this.MasterPageFile = "~/UC/MainMaster.master";
        }
        else if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.Administrator.ToString()))
        {
            Page.Theme = "Admin";
            this.MasterPageFile = "~/Admin/Admin.master";
        }
        else
        {
            Page.Theme = "Main";
        }
    }
}

