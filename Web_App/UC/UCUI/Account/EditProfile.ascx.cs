using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class UC_UCUI_Account_EditProfile : System.Web.UI.UserControl, IUserProfileUpdateView
{
    public event EventHandler InsertUpdateCommand;
    private UserProfileUpdatePresenter _presenter;

    public UC_UCUI_Account_EditProfile()
    {

        _presenter = new UserProfileUpdatePresenter(this);
        UserProfileID = (Guid)Membership.GetUser().ProviderUserKey;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //MasterPage mstr = this.Parent.Page.Master as MasterPage;
       // Label1.Text = (mstr.FindControl("lblVal") as Label).Text;
            //LoginName login = (mstr.FindControl("LoginName1") as LoginName);
            //login.FormatString = "ashish";

           // txtEmailUserName.Text = this.Page.User.Identity.Name;
            //litUserName.Text = this.Page.User.Identity.Name;
            //if (ProfilePicture!=null && ProfilePicture.Length > 10)
            //{
            //    imgProfilePic.ImageUrl = "~/ImageHandler.ashx?id=" + ProfilePicture; //Helper.ConvertToImage(ProfilePicture).ToString(); //"data:image/jpg;base64," + Convert.ToBase64String(ProfilePicture, 0, ProfilePicture.Length);
            //}
        }
        

    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
       
        //Image.FromStream

        //postedFile.InputStream.Read(myData, 0, dataLength);
        //postedFile.SaveAs(Server.MapPath("/Uploads/image01.jpg"));
    }



    #region IUserProfileUpdateView Members

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

    public string ProfilePicture
    {
        get
        {
            if (string.IsNullOrEmpty(ViewState["PiMage"].ToString()))
                return "";
            else
                return ViewState["PiMage"].ToString();
        }
        set
        {
            //
            string val = string.IsNullOrEmpty(value) ? "~/ProfilePic/Default/user-image.png" : "~/ProfilePic/UserProfile/" + value;
            imgProfilePic.ImageUrl = val;
            ViewState["PiMage"] = val;
        }

    }

  

  

    public string PinCode
    {
        get
        {
            return txtPincode.Text.Trim();
        }
        set
        {
            txtPincode.Text = value;
        }
    }

   
    public event EventHandler UpdateCommand;
    #endregion
    protected void bnRegistration_Click(object sender, EventArgs e)
    {
        //Image.FromStream

        //postedFile.InputStream.Read(myData, 0, dataLength);
        //postedFile.SaveAs(Server.MapPath("/Uploads/image01.jpg"));
        int dataLength = 0;
        byte[] myData = null;

        var postedFile = ctrl_Upload.PostedFile;
        if (postedFile != null)
        {

            string imageExtension = Path.GetExtension(postedFile.FileName);
            string fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
            string userID = Membership.GetUser().ProviderUserKey.ToString() ;
            string path = userID.Truncate(8) + "_" + fileName.Replace(" ", "") + imageExtension;
            //Helper.DeleteFile(Server.MapPath("~/ProfilePic/UserProfile/" + ProfilePicture));

           
            //ImageResizer1 resizer = new ImageResizer1();
            //resizer.MaxHeight = int.Parse("150");
            //resizer.MaxWidth = int.Parse("150");
            //resizer.ImgQuality = 100;
            //resizer.OutputFormat = ImageFormat.Png;
            //byte[] bytes = resizer.Resize(ctrl_Upload.PostedFile);
            //File.WriteAllBytes(Server.MapPath("~/ProfilePic/UserProfile/" + path), bytes);







          

           
            //postedFile.SaveAs(Server.MapPath("~/ProfilePic/UserProfile/" + path));
            ProfilePicture = path;
        }
        else
        {
            // No file was sent

        }
        EventHandler Update = this.UpdateCommand;
        if (Update != null)
        {
            
            Update(this, e);
        }
         
    }




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

    public DateTime? DOB
    {
        get
        {
            if (txtDOB.Text.Trim() != string.Empty)
                return Convert.ToDateTime(txtDOB.Text.Trim());
            else
                return null;
        }
        set
        {
            txtDOB.Text = Convert.ToDateTime(value).Date.ToShortDateString();
        }
    }

    public bool? IsEmailVerified
    {
        get
        {
            return ckbIsEmailVerified.Checked;
        }
        set
        {
            if (value.HasValue)
                ckbIsEmailVerified.Checked = value.Value;
            else
                ckbIsEmailVerified.Checked = false;
        }
    }

    public bool? IsOfferReceiveWeekly
    {
        get
        {
            return ckIsOfferReceiveWeekly.Checked;
        }
        set
        {
            if (value.HasValue)
                ckIsOfferReceiveWeekly.Checked = value.Value;
            else
                ckIsOfferReceiveWeekly.Checked = false;
            
        }
    }

    public bool? IsOtherInfo
    {
        get
        {
            return ckOtherInfo.Checked;
        }
        set
        {
            if (value.HasValue)
                ckOtherInfo.Checked = value.Value;
            else
                ckOtherInfo.Checked = false;
           
        }
    }

    public string BankAcHolderName
    {
        get
        {
            return txtBankAcHolderName.Text.Trim();
        }
        set
        {
            txtBankAcHolderName.Text = value;
        }
    }

    public string BankName
    {
        get
        {
            return txtBankName.Text.Trim();
        }
        set
        {
            txtBankName.Text = value;
        }
    }

    public string BankBranchName
    {
        get
        {
            return txtBankBranchName.Text.Trim();
        }
        set
        {
            txtBankBranchName.Text = value;
        }
    }

    public string BankAccountNo
    {
        get
        {
            return txtBankAccountNo.Text.Trim();
        }
        set
        {
            txtBankAccountNo.Text = value;
        }
    }

    public string IFSCCode
    {
        get
        {
            return txtIFSCCode.Text.Trim();
        }
        set
        {
            txtIFSCCode.Text = value;
        }
    }

    public string FullNameOnAdd
    {
        get
        {
            return txtFullNameOnAdd.Text.Trim();
        }
        set
        {
            txtFullNameOnAdd.Text = value;
        }
    }

    public string FullAddress
    {
        get
        {
            return txtAddress.Text.Trim();
        }
        set
        {
            txtAddress.Text = value;
        }
    }

    public string City
    {
        get
        {
            return txtCity.Text.Trim();
        }
        set
        {
            txtCity.Text = value;
        }
    }

    public string IsTruePOstBack { get; set; }
    public string State { get; set; }


    public string PhoneNo { get; set; }


    public bool IsValid
    {
        get { return true; }
    }
}