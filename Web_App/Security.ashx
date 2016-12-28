<%@ WebHandler Language="C#" Class="Security" %>

using System;
using System.Web;
using System.Web.Security;

public class Security : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        if (context.User.Identity.IsAuthenticated)
        {
            if (context.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
            {
                context.Response.Redirect("~/UC/User/Default.aspx");
            }
            else if (context.User.IsInRole(Constants.RoleNamePreDefine.Administrator.ToString()))
            {
                context.Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else
            {
                context.Response.Redirect("Default.aspx");
            }
        } 
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}