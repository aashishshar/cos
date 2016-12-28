using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_User_Default : BasePage
{
    string name;
    void Page_Init(Object sender, EventArgs e)
    {
        //name = uc_UserSideMenuNavigation.CurrentClicked;
    }
    //string name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(name))
        {
            //if (!IsPostBack)
            //{
            //    LoadQuestionEntryUI((Constants.Master)Enum.Parse(typeof(Constants.Master), name));
            //    ControlLoaded = true;
            //    return;
            //}
            //if (ControlLoaded)
            //{

            //    LoadQuestionEntryUI((Constants.Master)Enum.Parse(typeof(Constants.Master), name));
            //    // ControlLoaded = true;
            //}

        }
        else
        {
           
           // ControlLoaded = true;
           // Response.Redirect("~/Admin/Master/Default.aspx");
        }

    }

    //protected void lkbClicked_Click(object sender, EventArgs e)
    //{
    //    LinkButton lkbClicked = (LinkButton)sender;
    //    name = lkbClicked.CommandName;
    //    LoadQuestionEntryUI((Constants.Master)Enum.Parse(typeof(Constants.Master), NameClicked));
    //    ControlLoaded = true;
    //}

    public string NameClicked
    {
        get
        {
            Object s = ViewState["NameClicked"];
            return ((s == null) ? string.Empty : (string)s);
        }

        set
        {
            ViewState["NameClicked"] = value;
        }
    }
    public bool ControlLoaded
    {
        get
        {
            Object s = ViewState["ControlLoaded"];
            return ((s == null) ? false : (bool)s);
        }

        set
        {
            ViewState["ControlLoaded"] = value;
        }
    }
    private void LoadQuestionEntryUI(Constants.Master masterFormat)
    {

        //string mg = questionText.message;    
        switch (masterFormat)
        {
            case Constants.Master.DashBoard:
                Control _UserDashBoard = (Control)LoadControl("~/UC/UCUI/User/uc_UserDashBoard.ascx");
                _UserDashBoard.ID = "uc_CouponUserDashBoard_ID";
                //phDynamicControls.Controls.Add(_UserDashBoard);
                break;
            case Constants.Master.Wallet:
                Control _Coupon = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Coupon.ascx");
                _Coupon.ID = "uc_Coupon_ID";
               // phDynamicControls.Controls.Add(_Coupon);
                break;
            case Constants.Master.Payment:
                Control _Offer = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Offer.ascx");
                _Offer.ID = "uc_Offer_ID";
                //phDynamicControls.Controls.Add(_Offer);
                break;
            case Constants.Master.Cashback:
                Control _Deal = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Deal.ascx");
                _Deal.ID = "uc_Deal_ID";
                //phDynamicControls.Controls.Add(_Deal);
                break;
            case Constants.Master.Profile:
                Control _profoile = (Control)LoadControl("~/UC/UCUI/Account/EditProfile.ascx");
                _profoile.ID = "uc_profoile_ID";
                //phDynamicControls.Controls.Add(_profoile);
                break;           
            case Constants.Master.Commision:
                Control _Commisions = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Commisions.ascx");
                _Commisions.ID = "uc_Commisions_ID";
                //phDynamicControls.Controls.Add(_Commisions);
                break;
            case Constants.Master.Password:
                Control _Password = (Control)LoadControl("~/UC/UCUI/Account/uc_ChangePassword.ascx");
                _Password.ID = "uc_Password_ID";
                //phDynamicControls.Controls.Add(_Password);
                break;      
            default:
                break;

        }

    }
}