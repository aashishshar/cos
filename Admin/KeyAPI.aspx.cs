using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;

public partial class Admin_KeyAPI : AdminBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlCategory.DataSource = clsFlipKartAPICall.FLipkartCategoryList();
            //ddlCategory.DataBind();
            GetAllItems();
        }
    }
    string nextUrl = string.Empty;
    private void GetAllItems()
    {
        gvItems.DataSource = clsAddItems.GetAllItems();
        gvItems.DataBind();
    }

    protected void btnItems_Click(object sender, EventArgs e)
    {
        //WORKING GIVEN CODE
        //List<Tbl_Item> items = xmlParser.FlipkartMasterXElementToDataTable(clsFlipKartAPICall.FlipkartDownLoadString(ddlCategory.SelectedValue.ToString()), out nextUrl);
        // GetNext();
        //foreach (Tbl_Item item in items)
        //{
        //    clsAddItems.AddMasterItem(item);
        //}

        GetProductItemTillNextURL(ddlCategory.SelectedValue.ToString());
    }
    private void GetProductItemTillNextURL(string nextUrlLoop)
    {
        List<Tbl_Item> items = xmlParser.FlipkartMasterXElementToDataTable(clsFlipKartAPICall.FlipkartDownLoadString(nextUrlLoop), out nextUrl);

        foreach (Tbl_Item item in items)
        {
            clsAddItems.AddMasterItem(item);
        }

        if (nextUrl != "")
        {
            GetProductItemTillNextURL(nextUrl);
        }

    }
    private void GetProductTillNextURL(string nextUrlLoop)
    {
        List<Tbl_ItemsDetail> itemsnew = xmlParser.FlipkartProductDetailsXElementToDataTable(clsFlipKartAPICall.FlipkartDownLoadString(nextUrlLoop), out nextUrl);

        foreach (Tbl_ItemsDetail item in itemsnew)
        {

            clsAddItems.AddMasterItemDetails(item);
        }

        if (nextUrl != "")
        {
            GetProductTillNextURL(nextUrl);
        }

    }
    protected void btnUpdateItemInDatabase_Click(object sender, EventArgs e)
    {
        foreach (Tbl_Item item in clsAddItems.GetAllItems())
        {
            if (!item.ItenName.Contains("&"))
            {

                GetOmgLiveResult(Server.UrlEncode(item.ItenName), "", "", "");

            }
            //}
        }
    }

    private void GetOmgLiveResult(string searchString, string MID, string minPrice, string MaxPrice)
    {
        string dateSignData = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
        string encryptedSignature = clsUtility.EncryptString(dateSignData, "98e2106077d34d2c900cdd7c7121906e");


        string url = "http://api.omgpm.com/network/OMGNetworkApi.svc/v1.1/ProductFeeds/GetProducts?AgencyID=95&AID=764019&MID=" + MID + "&Keyword=" + searchString + "&MinPrice=" + minPrice + "&MaxPrice=" + MaxPrice + "&Currency=INR&DiscountedOnly=false&ProductSKU=&Key=0e1a4b99-8aa0-43e7-81d7-22dd4e0f6786&Sig=" + Server.UrlEncode(encryptedSignature) + "&SigData=" + dateSignData;

        //if (SearchLiveData == null)
        //SearchLiveData = clsOMGProductFeedList.ProductJsonList(url).ToList();
        var p = (from i in clsOMGProductFeedList.ProductJsonList(url)
                 // where i.CategoryName.Contains("Mobile Phones") || i.CategoryName.Contains("Mobiles")
                 select i).ToList();
        foreach (clsOMGProductFeed pFeed in p)
        {
            Tbl_ItemsDetails_More item = new Tbl_ItemsDetails_More();
            item.DiscountedPrice = pFeed.DiscountedPrice;
            item.MerchantID = pFeed.MID;
            item.MerchantName = pFeed.MerchantDomain;
            item.MerchantProductID = pFeed.ProductSKU;
            item.NavigationURL = pFeed.ProductURL;
            item.ProductPrice = pFeed.ProductPrice;
            item.Title = pFeed.ProductName;
            clsAddItems.AddMasterItemDetails_MOre(item);
        }

        //AddMasterItemDetails_MOre


    }
   
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        List<int> offerIds = new List<int>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                offerIds.Add(offerID);
            }
        }

        if (offerIds.Count > 0)
        {
            clsAddItems.AddMasterItem(offerIds);
            GetAllItems();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Tbl_Item item = new Tbl_Item();
        item.CategoryID_N =Convert.ToInt32(UC_CategoryList.SelectedValue.ToString());
        item.CategoryName_V = txtCategory.Text.Trim();
        item.merchantname = txtMerchant.Text.Trim();
        clsAddItems.AddMasterItem(item);
         GetAllItems();
    }
}