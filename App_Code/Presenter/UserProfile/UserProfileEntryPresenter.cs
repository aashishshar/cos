using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for UserProfileEntryPresenter
/// </summary>
public class UserProfileEntryPresenter
{
    private IUserProfileEntryView _view;
    private ModelUserProfile _model;
    public UserProfileEntryPresenter(IUserProfileEntryView view)
	{
        _view = view;
        _model = new ModelUserProfile();
        SubscribeViewToEvents();
	}

    void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.InsertUpdateCommand += _view_InsertCommand;
        //_view.UpdateCommand += _view_UpdateCommand;
        //_view.TagRemoved += OnTagRemoved;
    }

    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            //LoadViewFromModel();
            _view.DataBind();
        }
    }

    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            string strStatusMessage=string.Empty;string errorMessage=string.Empty;
            string createUserID = clsuser.CreateUser(_view.UserNameEmailID, _view.UserNameEmailID, _view.Password, Constants.RoleNamePreDefine.User.ToString(), out strStatusMessage,out errorMessage);
            if (string.IsNullOrEmpty(strStatusMessage))
            {
                UserProfile c = new UserProfile();
                c.UserProfileID =new Guid(createUserID);// _view.UserProfileID;
                c.FullName =  _view.FullName;
                c.IsEmailVerified = false;// _view.IsEmailVerified;
                c.LoginUserName = _view.UserNameEmailID;               
                c.IsEmailVerified = false;
                c.PhoneNo = _view.PhoneNo;
                _model.DBOperation("Insert", c);
                
               

                if (!string.IsNullOrEmpty(_view.UserNameEmailID.Trim()))
                {

                    try
                    {
                        string url = "";//= "http://www.cashonshop.com/resetpassword.aspx?uid=" + mu.ProviderUserKey + "&Dt=" + DateTime.Now;
                        SendEmail(_view.UserNameEmailID, _view.FullName, "", _view.Password);
                        //lblMessage.Text = "Password has been sent on your email ID. Kindly check you mail. Thank you.";
                        //txtEmail.Text = "";
                    }
                    catch (Exception ex)
                    {
                        _view.message = ex.Message;
                    }

                }
                
                _view.message = "<span style='color:green;'>Registration completed. Now you can login!!!</span>";
                
                _view.DataBind();

                if (Membership.ValidateUser(_view.UserNameEmailID, _view.Password))
                {
                    FormsAuthentication.SetAuthCookie(_view.UserNameEmailID, true);
                    HttpContext.Current.Response.Redirect("~/Security.ashx", false);
                }
                
               //HttpContext.Current.Response.Redirect("~/uc/user/default.aspx", true);
            }
            else
            {
                _view.message = strStatusMessage == string.Empty ? errorMessage : strStatusMessage;
            }
        }
        catch (Exception ex) 
        {
            _view.message = ex.Message;
        }
        //ClearControls(); 
    }

    private void SendEmail(string EmailD,string fullName, string url, string pwd)
    {
        string body = clsEmailMailer.PopulateRegisteredBody(EmailD, fullName.Trim(), "", pwd);
        clsEmailMailer.SendHtmlFormattedEmail(EmailD, "Registration on www.cashonshop.com", body);
    }

}