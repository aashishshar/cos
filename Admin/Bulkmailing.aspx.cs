using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

public partial class Admin_Bulkmailing : AdminBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEnum();
        }
    }

    private void BindEnum()
    {

        EnumControl.GetEnumDescriptions<Constants.MailFormatContentType>(ddlTemplateType);
        ddlTemplateType.Items.Insert(0, "Mail Content");
        ddlTemplateType.Items.RemoveAt(1);

    }

    private DataTable GetEamilsList(int from, int to)
    {
        clsFramework objFramework = new clsFramework();
        DataTable dt = new DataTable();
        SqlParameter[] parameters =
        {    
            new SqlParameter("@MailStartFrom", SqlDbType.Int) { Value =Convert.ToInt32(from) },
             new SqlParameter("@MailCount", SqlDbType.Int) { Value = Convert.ToInt32(to) }
        };
        dt = objFramework.GetRecordSet("Adv_Proc_SendMail", CommandType.StoredProcedure, parameters);
        return dt;
    }
    protected void btnRunTemplateDesign_Click(object sender, EventArgs e)
    {

        string SendMail = string.Empty;
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            if (ddlTemplateType.SelectedValue == Constants.MailFormatContentType.ImageContent.ToString())
            {
                Int16 mailFormatType = Convert.ToInt16(Constants.MailFormatContentType.ImageContent);
                var contentMail = (from pro in model.Adv_MailContents
                                   where pro.MailType == mailFormatType
                                   select pro).SingleOrDefault();

                DataTable dtEmails = GetEamilsList(Convert.ToInt32(txtSendMail.Text.Trim()), Convert.ToInt32(txtMailCount.Text.ToString()));
                if (dtEmails.Rows.Count > 0)
                {
                    string emailIDS = string.Empty;
                    for (int i = 0; i < dtEmails.Rows.Count; i++)
                    {
                        emailIDS = emailIDS + "," + dtEmails.Rows[i]["SubscribeEmail"].ToString();
                    }
                    string staus = MailSender.SendMailAPI(txtSubject.Text.Trim(), txtEmailTo.Text.Trim() + emailIDS, contentMail.MailContent.ToString());

                    lblmsg.Text = staus;
                }
                
            }
            if (ddlTemplateType.SelectedValue == Constants.MailFormatContentType.OfferContent.ToString())
            {
                Int16 mailFormatType = Convert.ToInt16(Constants.MailFormatContentType.OfferContent);
                var contentMail = (from pro in model.Adv_MailContents
                                   where pro.MailType == mailFormatType
                                   select pro).SingleOrDefault();
                int from = 0;
                int to = 500;
                //for (int m = 0; m < 10; m++)
                //{

                DataTable dtEmails = GetEamilsList(Convert.ToInt32(txtSendMail.Text.Trim()), Convert.ToInt32(txtMailCount.Text.ToString()));
                    if (dtEmails.Rows.Count > 0)
                    {
                        string emailIDS = string.Empty;
                        for (int i = 0; i < dtEmails.Rows.Count; i++)
                        {
                            emailIDS = emailIDS + "," + dtEmails.Rows[i]["SubscribeEmail"].ToString();
                        }
                        string staus = MailSender.SendMailAPI(txtSubject.Text.Trim(), txtEmailTo.Text.Trim() + emailIDS, contentMail.MailContent.ToString());

                        lblmsg.Text = staus;
                    }
                    //from = to + 1;
                    //to = to + 500;
                //}

            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clsFramework objFramework = new clsFramework();
        DataTable dt = new DataTable();
        SqlParameter[] parameters =
        {    
            new SqlParameter("@MailStartFrom", SqlDbType.Int) { Value =Convert.ToInt32(txtSendMail.Text.Trim()) },
             new SqlParameter("@MailCount", SqlDbType.Int) { Value = Convert.ToInt32(txtMailCount.Text.Trim()) }
        };
        dt = objFramework.GetRecordSet("Adv_Proc_SendMail", CommandType.StoredProcedure, parameters);
        string SendMail = string.Empty;
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            if (ddlTemplateType.SelectedValue == Constants.MailFormatContentType.ImageContent.ToString())
            {
                Int16 mailFormatType = Convert.ToInt16(Constants.MailFormatContentType.ImageContent);
                var contentMail = (from pro in model.Adv_MailContents
                                   where pro.MailType == mailFormatType
                                   select pro).SingleOrDefault();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            MailSender.SendHtmlFormattedEmail(txtSubject.Text.Trim(), dt.Rows[i]["SubscribeEmail"].ToString(), contentMail.MailContent.ToString(), Constants.FromAddress.Info);
                            Thread.Sleep(3000);
                            //SendMail = SendMail + dt.Rows[i]["SubscribeEmail"].ToString() + ",";
                        }
                        SendMail = SendMail.TrimEnd(',');
                    }
                }
                lblmsg.Text = "Send";
            }
            else if (ddlTemplateType.SelectedValue == Constants.MailFormatContentType.OfferContent.ToString())
            {
                Int16 mailFormatType = Convert.ToInt16(Constants.MailFormatContentType.OfferContent);
                var contentMail = (from pro in model.Adv_MailContents
                                   where pro.MailType == mailFormatType
                                   select pro).SingleOrDefault();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            MailSender.SendHtmlFormattedEmail(txtSubject.Text.Trim(), dt.Rows[i]["SubscribeEmail"].ToString(), contentMail.MailContent.ToString(), Constants.FromAddress.Info);
                            Thread.Sleep(3000);
                            //SendMail = SendMail + dt.Rows[i]["SubscribeEmail"].ToString() + ",";
                        }
                        SendMail = SendMail.TrimEnd(',');
                    }
                }



                lblmsg.Text = "Send";

            }



        }
    }
}