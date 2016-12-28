using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_MasterHeader_uc_TopOnHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

               // divDefaultPanel.Visible = false;
               // divUserPanel.Visible = true;
               // //hfIsLogin.Value = "true";
               //// hfUserName.Value = clsCommonMethods.GetGlobalUserID();
            }
            else
            {
                //divDefaultPanel.Visible = true;
                //divUserPanel.Visible = false;
            }
        }
    }
}