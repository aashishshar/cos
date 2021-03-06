﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// For add image
using System.IO;
using System.Configuration;

public partial class UC_UCUI_Master_Merchant_uc_Banner : System.Web.UI.UserControl,IMerchant_BannerView
{
   private Merchant_BannerPrensenter _presenter;

    public event EventHandler InsertCommand;
    public event EventHandler DeleteCommand;

    public UC_UCUI_Master_Merchant_uc_Banner()
    {
        this._presenter = new Merchant_BannerPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string i = clsUtility.AppendUIDinHrefURl("<a href=\"http://clk.omgt5.com/?AID=764019&MID=526801&PID=11365&CID=4468489&CRID=85709&WID=57715\" rel=\"nofollow\" target=\"_blank\"><img src=\"http://track.in.omgpm.com/bs/?CRID=85709&AID=764019&PID=11365&CID=4468489&WID=57715\" border=\"0\" width=\"300\" height=\"250\"></a>");
        if (!Page.IsPostBack)
        {
            BindEnum();
            BindItems();
        }
    }

    private void BindItems()
    {
        gvItems.DataSource = Merchant_Banners;
        gvItems.DataBind();
    }

    private void BindEnum()
    {

        EnumControl.GetEnumDescriptions<Constants.BannerType>(ddlBanner);
        ddlBanner.Items.Insert(0, "[ Banner Type ]");
        ddlBanner.Items.RemoveAt(1);

        EnumControl.GetEnumDescriptions<Constants.BannerLocation>(ddlBannerLocation);
        ddlBannerLocation.Items.Insert(0, "[ Banner Placing ]");
        ddlBannerLocation.Items.RemoveAt(1);

    }

    

   

    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            //lblMessage.Text = string.Empty;
            Insert(this, e);
            BindItems();
        }
    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> offerIds = new List<Int64>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                offerIds.Add(offerID);
            }
        }

        if (offerIds.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.Ids = offerIds;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindItems();
            }
        }
    }

    public string BannerText
    {
        get
        {
            return txtBannerText.Text.Trim();
        }
        set
        {
            txtBannerText.Text = value;
        }
    }

    public int? BannerType
    {
        get
        {
            return Convert.ToInt32(Convert.ToInt32((Constants.BannerType)Enum.Parse(typeof(Constants.BannerType), ddlBanner.SelectedValue.ToString())));

        }
        set
        {
            ddlBanner.SelectedValue = Convert.ToInt32((Constants.BannerType)Enum.Parse(typeof(Constants.BannerType), value.ToString())).ToString();
        }
    }

    public string BannerURL
    {
        get
        {
            return txtBannerURL.Text.Trim();
        }
        set
        {
            txtBannerURL.Text = value;
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public List<long> Ids { get; set; }

   

    public List<Merchant_Banner> Merchant_Banners { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    public int? BannerLocation
    {
        get
        {
            return Convert.ToInt32(Convert.ToInt32((Constants.BannerLocation)Enum.Parse(typeof(Constants.BannerLocation), ddlBannerLocation.SelectedValue.ToString())));

        }
        set
        {
            ddlBannerLocation.SelectedValue = Convert.ToInt32((Constants.BannerLocation)Enum.Parse(typeof(Constants.BannerLocation), value.ToString())).ToString();
        }
    }


    public long MID
    {
        get
        {
            return Convert.ToInt64(uc_MerchantDDlList.SelectedMerchant);
        }
        set
        {
            uc_MerchantDDlList.SelectedMerchant = value.ToString();
        }
    }


    public int? CategoryType { get; set; }


    public int? Price
    {
        get
        {
            if (!string.IsNullOrEmpty(txtPrice.Text))
                return Convert.ToInt32(txtPrice.Text);
            else
                return null;
        }
        set
        {
            txtPrice.Text = value.ToString();
        }
    }
    public int? DiscountedPrice
    {
        get
        {
            if (!string.IsNullOrEmpty(txtDiscountedPrice.Text))
                return Convert.ToInt32(txtDiscountedPrice.Text);
            else
                return null;
        }
        set
        {
            txtDiscountedPrice.Text = value.ToString();
        }
    }

    public string Description
    {
        get
        {
            return txtDescription.Text.Trim();
        }
        set
        {
            txtDescription.Text = value.ToString();
        }
    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        if (imgUpload.HasFile)
        {
            string filename = imgUpload.FileName;
            string imgPath = "~/Images/BannerImage/" + filename;
            string getext = Path.GetExtension(imgUpload.PostedFile.FileName);
            string pathName = Server.MapPath(imgUpload.FileName);
            if (getext != ".JPEG" && getext != ".jpeg" && getext != ".JPG" && getext != ".jpg" && getext != ".png")
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "successfull", "alert('Please upload only jpeg, jpg,png');", true);
            }
            else
            {
               
                imgUpload.SaveAs(Server.MapPath(imgPath));
                // string imgPathUrl = "http://localhost:6881/COS/Images/BannerImage/" + filename;
                string imgPathUrl = ConfigurationManager.AppSettings["ImageUrl"].ToString() + filename;
                txtBannerURL.Text = imgPathUrl;
                Label1.Text = "Image Saved..";
            }
            
           
        }
    }
}