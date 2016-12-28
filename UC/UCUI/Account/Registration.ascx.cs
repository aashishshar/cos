using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UC_UCUI_Account_Registration : System.Web.UI.UserControl, IUserProfileEntryView
{
    public event EventHandler InsertUpdateCommand;
    private UserProfileEntryPresenter _presenter;

    public UC_UCUI_Account_Registration()
    {
        _presenter = new UserProfileEntryPresenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlGenderTitle.DataSource = Enumeration.ToList(typeof(Constants.GenderTitle));
            //ddlGenderTitle.DataBind();
            //ddlGenderTitle.Items.Insert(0, new ListItem("Title", "0"));
        }
    }
    protected void bnRegistration_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertUpdateCommand;
        if (Insert != null)
        {

            Insert(this, e);
            
        }
    }
   
    #region IUserProfileEntryView Members

    public string message 
    {
        get
        {
            return "";
        }
        set
        {
            lblMessage.Text = value;
        }
    }

    public long UserID { get; set; }

    public Guid UserProfileID { get; set; }

    public string FullName
    {
        get
        {
            return txtFullName.Text.Trim();
        }
        set
        {
            txtFullName.Text = value;
        }
    }

  

    public string UserNameEmailID
    {
        get
        {
            return txtEmailUserName.Text.Trim();
        }
        set
        {
            txtEmailUserName.Text = value;
        }
    }

    public string Password
    {
        get
        {
            return txtConfirmPassword.Text.Trim();
        }
        set
        {
            txtConfirmPassword.Text = value;
        }
    }



    public string PhoneNo
    {
        get
        {
            return txtMobile.Text.Trim();
        }
        set
        {
            txtMobile.Text = value;
        }
    }

    public bool IsEmailVerified { get; set; }

  

    #endregion

    #region IView Members


    public bool IsValid
    {
        get { return true; }
    }

    #endregion



   
}