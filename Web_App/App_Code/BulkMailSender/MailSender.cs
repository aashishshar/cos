using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for MailSender
/// </summary>
public static class MailSender
{
	static MailSender()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void SendHtmlFormattedEmail(string subject, string recepientEmail, string body)
    {
        using (MailMessage mailMessage = new MailMessage())
        {
            mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(recepientEmail));
            //mailMessage.Bcc.Add(new MailAddress("aashishshar@gmail.com"));
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
    public static void SendHtmlFormattedEmail(string subject, string recepientEmail, string body,Constants.FromAddress fromAddress)
    {
        using (MailMessage mailMessageAdd = new MailMessage())
        {
            
            mailMessageAdd.From = new MailAddress(GetFromAddress(fromAddress),"CashonShop.com :)");
            mailMessageAdd.Subject = subject;
            mailMessageAdd.Body = body;
            mailMessageAdd.IsBodyHtml = true;
            mailMessageAdd.To.Add(new MailAddress(recepientEmail));
            //mailMessage.Bcc.Add(new MailAddress("aashishshar@gmail.com"));
            SmtpClient smtpAdd = new SmtpClient();
            smtpAdd.Host = ConfigurationManager.AppSettings["Host"];
            smtpAdd.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = GetFromAddress(fromAddress);
            NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
            smtpAdd.UseDefaultCredentials = true;
            smtpAdd.Credentials = NetworkCred;
            smtpAdd.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            smtpAdd.Send(mailMessageAdd);
        }
    }

    public static string SendMailAPI(string subject,string toEmailAddress,string content)
    {
        WebRequest request = WebRequest.Create("http://api.pepipost.com/api/web.send.rest");
        request.Method = "POST";
        var postData = "api_key=5e75ce943974f724a665f544ef4633b0";
        postData += "&subject="+subject;
        postData += "&fromname=Cashonshop.com";
        postData += "&from=info@cashonshop.com";
        postData += "&recipients=" + toEmailAddress;
        postData += "&content=1";
        postData += "&footer=1&template=2299";
        
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);        

        //Label1.Text = postData;

        request.ContentType = "application/x-www-form-urlencoded";       

        request.ContentLength = byteArray.Length;
        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();        

        WebResponse response = request.GetResponse();
        //Label1.Text= ((HttpWebResponse)response).StatusDescription;

        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();

        dataStream.Close();

        response.Close();

        return responseFromServer;
    }


    public static string GetFromAddress(Constants.FromAddress fromAddress)
    {
        string Address = string.Empty;
        switch (fromAddress)
        {
            case Constants.FromAddress.Care:
                Address = ConfigurationManager.AppSettings["UserNameCare"];
                break;
            case Constants.FromAddress.Info:
                Address = ConfigurationManager.AppSettings["UserNameInfo"];
                break;
            case Constants.FromAddress.Support:
                Address = ConfigurationManager.AppSettings["UserName"];
                break;
            case Constants.FromAddress.Newsletter:
                Address = ConfigurationManager.AppSettings["UserNameNewsLetter"];
                break;

        }

        return Address;

    }
}