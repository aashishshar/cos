using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

public partial class UC_UCUI_Menu_uc_UserMenuList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CalculateWalletAmount();
        }

        if (Page.User.Identity.Name == "84.mukesh@gmail.com")
        {
            hlRecharge.Enabled = true;
        }
        else
        {
            hlRecharge.Enabled = false;
        }
    }

    public void CalculateWalletAmount()
    {
        clsFramework objFramework = new clsFramework();
        MembershipUser mu = Membership.GetUser();

        SqlParameter[] parameters =
        {    
            new SqlParameter("@userid", SqlDbType.VarChar) { Value = mu.ProviderUserKey.ToString() }
        };
        DataTable dt = objFramework.GetRecordSet("Adv_WalletHistory_New", CommandType.StoredProcedure, parameters);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
                lblWalletAmount.Text =" Rs. "+ Convert.ToString(dt.Rows[0]["ConfirmAmount"]);
        }
    }
}