using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

public partial class UC_MasterHeader_uc_HeaderCommon : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Profile
        //Profile.FirstName
        //if(MembershipUser MulticastDelegate=new 
        if (!IsPostBack)
        {
            txtSearchHome.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)){ __doPostBack('" + searchButton.UniqueID + "','');return false;}else{return true;}}");
            txtSearchHome.Attributes.Add("type", "search");
        }

        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            HeadLoginStatus.Attributes.Add("data-toggle", "modal");
            HeadLoginStatus.Attributes.Add("data-target", "#loginModal");
            liAccount.Visible = false;
            liLogout.Visible = true;
        }
        else
        {
            LoginName1.FormatString = HttpContext.Current.User.Identity.Name.Split('@')[0].ToString();
            liLogout.Visible = false;
            liAccount.Visible = true;
        }
    }
        
   
    public void btnSubmitPost_Click(object sender, EventArgs e)
    {
           // Session["S"] = txtSearch.Text.Trim();
           // Response.Redirect("frmGeneralSearch.aspx");//?s=" + txtSearch.Text.Trim());
        if (txtSearchHome.Text.Trim() != "")
        {
            Session["S"] = txtSearchHome.Text.Trim();
            string query = string.Format("select merchantnamedetail from adv_mst_merchant where merchantnamedetail like '%{0}%' ", txtSearchHome.Text.Trim());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Response.Redirect("~/Merchant/" + txtSearchHome.Text, true);
                    //return
                }

            }
            Response.Redirect("~/frmGeneralSearch.aspx");//?s=" + txtSearch.Text.Trim());
        }
        

    }


    
}