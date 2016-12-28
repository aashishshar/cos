using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Master_NestedMasters : System.Web.UI.MasterPage
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

    public void lkbOnclick(object sender, EventArgs e)
    {
        LinkButton lkb = (LinkButton)sender;
        lkb.EnableViewState = false;
        CurrentClicked = lkb.CommandName;

        Response.Redirect("~/Admin/Master/Masters.aspx", false);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        
    }

   
}
