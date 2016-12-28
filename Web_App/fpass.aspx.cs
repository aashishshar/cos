using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_fpass : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Submit(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
        {
            MembershipUser mu = Membership.GetUser(txtEmail.Text.Trim());
            if (mu != null)
            {
                try
                {
                    string url="" ;//= "http://www.cashonshop.com/resetpassword.aspx?uid=" + mu.ProviderUserKey + "&Dt=" + DateTime.Now;
                    SendEmail(url,mu.GetPassword());
                    lblMessage.Text = "Password has been sent on your email ID. Kindly check you mail. Thank you.";
                    txtEmail.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "This user not registered with us.";
            }
        }
       
    }


    private void SendEmail(string url,string pwd)
    {
        string body = clsEmailMailer.PopulateForgotPasswordBody(txtEmail.Text.Trim(), "", url, pwd);
        clsEmailMailer.SendHtmlFormattedEmail(txtEmail.Text, "Password Request!!", body);
    }
   
}