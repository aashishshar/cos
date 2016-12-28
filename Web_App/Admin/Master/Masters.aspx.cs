using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_Master_Masters : AdminBasePage
{
    string name;
    void Page_Init(Object sender, EventArgs e)
    {
         name = ((Admin_Master_NestedMasters)this.Master).CurrentClicked;
       
    }
    protected void Page_Load(object sender, EventArgs e)
    { 

      
            if (!string.IsNullOrEmpty(name))
            {
                if (!IsPostBack)
                {
                    LoadQuestionEntryUI((Constants.Master)Enum.Parse(typeof(Constants.Master), name));
                    ControlLoaded = true;
                    return;
                }
                if (ControlLoaded)
                {
                    
                    LoadQuestionEntryUI((Constants.Master)Enum.Parse(typeof(Constants.Master), name));
                   // ControlLoaded = true;
                }
               
            }
            else
            {
                Response.Redirect("~/Admin/Master/Default.aspx");
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
            case Constants.Master.Category:
                phDynamicControls.Controls.Clear();
                Control _categoryEntry = (Control)LoadControl("~/UC/UCUI/Master/Category/UC_CategoryEntry.ascx");
                _categoryEntry.ID = "ucCategoryEntry_ID";
                //questionText.SubCategoryID_N = Convert.ToInt16(UC_SubCategoryList.SelectedValue);
                phDynamicControls.Controls.Add(_categoryEntry);
                //questionText.QuestionType = (Constants.QuestionFormat)Enum.Parse(typeof(Constants.QuestionFormat), ddlQuestionFormat.SelectedValue);
                //questionText.DocID = new Guid("447b9207-5f79-4f58-9ed4-18fcac6a6623");
                //questionText.InsertCommand += new EventHandler(questionText_InsertCommand);
                //ControlLoaded = false;
                break;
            case Constants.Master.SubCategory:
                phDynamicControls.Controls.Clear();
                Control _subCategoryEntry = (Control)LoadControl("~/UC/UCUI/Master/SubCategory/UC_SubCategoryEntry.ascx");
                _subCategoryEntry.ID = "ucSubCategoryEntry_ID";
                //questionText.SubCategoryID_N = Convert.ToInt16(UC_SubCategoryList.SelectedValue);
                phDynamicControls.Controls.Add(_subCategoryEntry);
                //ControlLoaded = false;
                break;

            case Constants.Master.Merchant:
                Control _merchant = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Merchant.ascx");
                 _merchant.ID = "uc_merchant_ID";
                 phDynamicControls.Controls.Add(_merchant);
                break;
            case Constants.Master.Coupon:
                Control _Coupon = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Coupon.ascx");
                _Coupon.ID = "uc_Coupon_ID";
                phDynamicControls.Controls.Add(_Coupon);
                break;
            case Constants.Master.Offer:
                Control _Offer = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Offer.ascx");
                _Offer.ID = "uc_Offer_ID";
                phDynamicControls.Controls.Add(_Offer);
                break;
            case Constants.Master.Deal:
                Control _Deal = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Deal.ascx");
                _Deal.ID = "uc_Deal_ID";
                phDynamicControls.Controls.Add(_Deal);
                break;
            case Constants.Master.Campaigns:
                Control _Campaigns = (Control)LoadControl("~/UC/UCUI/Product/uc_VwProductList.ascx");
                _Campaigns.ID = "uc_VwProductList_ID";
                phDynamicControls.Controls.Add(_Campaigns);
                break;
            case Constants.Master.ApiURL:
                Control _ApiURL = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_ApiURL.ascx");
                _ApiURL.ID = "uc_ApiURL_ID";
                phDynamicControls.Controls.Add(_ApiURL);
                break;
            case Constants.Master.Commision:
                Control _Commision = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Commision.ascx");
                _Commision.ID = "uc_Commision_ID";
                phDynamicControls.Controls.Add(_Commision);
                break;
            case Constants.Master.Banner:
                Control _Banner = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Banner.ascx");
                _Banner.ID = "uc_Banner_ID";
                phDynamicControls.Controls.Add(_Banner);
                break;
            case Constants.Master.Notification:
                Control _Notification = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_Notification.ascx");
                _Notification.ID = "uc_Notification";
                phDynamicControls.Controls.Add(_Notification);
                break; 
            case Constants.Master.MissingCashback:
                Control _MissingCashback = (Control)LoadControl("~/UC/UCUI/Master/Merchant/uc_MissingCashback.ascx");
                _MissingCashback.ID = "uc_MissingCashback";
                phDynamicControls.Controls.Add(_MissingCashback);
                break; 
            default:
                break;

        }

    }

}