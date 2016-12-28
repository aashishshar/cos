using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        try
        {
            SendEmail(txtName.Text.Trim(), txtEmail.Text.Trim(), txtSubject.Text.Trim(), txtMessage.Text.Trim());
            success.InnerText = "Thank you for contact us. Our representative will contact you soon.";
        }
        catch (Exception ex)
        {
            success.InnerText = ex.InnerException.Message;
        }
    }

    private void SendEmail(string Name, string Email, string subject, string Message)
    {
        string body = clsEmailMailer.PopulateContactUsBody(Name,Email,subject,Message);
        clsEmailMailer.SendHtmlFormattedEmail("aashishshar@gmail.com", "Contact To Mr.: "+Name, body);

       
    }
}