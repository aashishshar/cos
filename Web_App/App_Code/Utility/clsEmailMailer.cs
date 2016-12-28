using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.IO;

/// <summary>
/// Summary description for clsEmailMailer
/// </summary>
public static class clsEmailMailer
{


    public static string PopulateAddCashBackBody(string Rs, string orderID, string merchantname)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/MailFormat/MoneyAdded.htm")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Rs}", Rs);
        body = body.Replace("{OrderID}", orderID);
        body = body.Replace("{Merchant}", merchantname);        
        return body;
    }


    public static string PopulateForgotPasswordBody(string userName, string title, string url,string pwd)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/MailFormat/ForgotPassword.htm")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{UserName}", userName);
        body = body.Replace("{Title}", title);
        body = body.Replace("{Url}", url);
        body = body.Replace("{Password}", pwd); 
        return body;
    }

    public static string PopulateRegisteredBody(string userName, string Name, string url, string pwd)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/MailFormat/UserRegister.htm")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{UserName}", userName);
        body = body.Replace("{Name}", Name);
        body = body.Replace("{Url}", url);
        body = body.Replace("{Password}", pwd);
        return body;
    }

    public static string PopulateMissingCashBackBody(string OrderID, string TransactionDate, string Amount, string Coupon, string MerchantName, string note)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/MailFormat/MissingCashback.htm")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{OrderID}", OrderID);
        body = body.Replace("{TransactionDate}", TransactionDate);
        body = body.Replace("{Amount}", Amount);
        body = body.Replace("{Coupon}", Coupon); 
        body = body.Replace("{MerchantName}", MerchantName);
        body = body.Replace("{Note}", note);
        return body;
    }

    public static string PopulateContactUsBody(string Name, string Email, string subject, string Message)
    {
        string body = string.Empty;
        body += body + "Name :" + Name + "<br/>Email :" + Email + "<br/>Subject :" + subject + "<br/>Message :" + Message;

        return body;
    }

    public static void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
    {
        using (MailMessage mailMessage = new MailMessage())
        {
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(recepientEmail));
            mailMessage.Bcc.Add(new MailAddress("aashishshar@gmail.com"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["Host"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
            NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            smtp.Send(mailMessage);
        }
    }
}