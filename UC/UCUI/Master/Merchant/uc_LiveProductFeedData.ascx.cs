using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;
using EntityData;


public partial class UC_UCUI_Master_Merchant_uc_LiveProductFeedData : System.Web.UI.UserControl, IProductEntryView
{
     ProductPrensenter _prensenter;
     public event EventHandler InsertCommand;
     public event EventHandler DeleteCommand;



     public UC_UCUI_Master_Merchant_uc_LiveProductFeedData()
    {
        _prensenter = new ProductPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSignData.Text= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
            //AutoInsertByCategries();
        }

    }
    public IList<clsOMGProductFeed> SearchLiveData
    {
        get
        {
            if (ViewState["LiveData"] != null)
            {
                //IList<clsOMGProductFeed> feeds = (IList<clsOMGProductFeed>)ViewState["LiveData"];
                return (IList<clsOMGProductFeed>)ViewState["LiveData"];
            }
            else
                return null;
        }
        set
        {
            ViewState.Add("LiveData", value);
            //ViewState["LiveData"] = value; // IList<clsOMGProductFeed>
        }
    }
    protected void btnGetProduct_Click(object sender, EventArgs e)
    {
        string mid = uc_MerchantDDlList.LiveMID(uc_MerchantDDlList.SelectedMerchantText);

        string encryptedSignature = clsUtility.EncryptString(txtSignData.Text.Trim(), "98e2106077d34d2c900cdd7c7121906e");

        string url = "http://api.omgpm.com/network/OMGNetworkApi.svc/v1.1/ProductFeeds/GetProducts?AgencyID=95&AID=764019&MID=" + mid + "&Keyword=" + txtKeyword.Text.Trim() + "&MinPrice=" + txtMinPrice.Text.Trim() + "&MaxPrice=" + txtMaxPrice.Text.Trim() + "&Currency=INR&DiscountedOnly=" + rblDiscount.SelectedValue.ToString() + "&ProductSKU=" + txtProductSKU.Text.Trim() + "&Key=7a332fc2-0cd5-4ad8-9baa-cb172c6145c6&Sig=" + Server.UrlEncode(encryptedSignature) + "&SigData=" + txtSignData.Text.Trim();// +"&NumberOfRecords=" + txtNoOfRecord.Text.Trim();

        //if (SearchLiveData == null)
        //SearchLiveData = clsOMGProductFeedList.ProductJsonList(url).ToList();
        var p = (from i in clsOMGProductFeedList.ProductJsonList(url)                 
                 select i).ToList();
        
        //SearchLiveData = p;
        if (UC_CategoryList.SelectedIndex > 0)
        {
            gvItems.DataSource = p.Where(i=>GetCategoryName().Contains(i.CategoryName));// clsOMGProductFeedList.ProductJsonList(url); ;
            gvItems.DataBind();
        }
        else
        {
            gvItems.DataSource = p;// clsOMGProductFeedList.ProductJsonList(url); ;
            gvItems.DataBind();
        }
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        List<clsOMGProductFeed> newProductList = new List<clsOMGProductFeed>();
        foreach (clsOMGProductFeed feed in GetCategoryFilterData(p))
        {
            newProductList.Add(feed);
        }

        SearchLiveData = newProductList;

    }

    private void GetSearchResult(string keyword,string minPrice,string maxPrice)
    {
        //Response.Write(keyword);
        string mid = uc_MerchantDDlList.LiveMID(uc_MerchantDDlList.SelectedMerchantText);
        string dateSignData = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
        string encryptedSignature = clsUtility.EncryptString(dateSignData, "98e2106077d34d2c900cdd7c7121906e");

        string url = "http://api.omgpm.com/network/OMGNetworkApi.svc/v1.1/ProductFeeds/GetProducts?AgencyID=95&AID=764019&MID=" + mid + "&Keyword=" + keyword + "&MinPrice=" + minPrice + "&MaxPrice=" + maxPrice + "&Currency=INR&DiscountedOnly=false&ProductSKU=&Key=7a332fc2-0cd5-4ad8-9baa-cb172c6145c6&Sig=" + Server.UrlEncode(encryptedSignature) + "&SigData=" + dateSignData + "&Brand=Nokia";
        var p = (from i in clsOMGProductFeedList.ProductJsonList(url)                
                 select i).ToList();

        List<clsOMGProductFeed> newProductList = new List<clsOMGProductFeed>();

        foreach (clsOMGProductFeed feed in GetCategoryFilterData(p))
        {
            newProductList.Add(feed);
        }

        SearchLiveData = newProductList;

    }


    private List<clsOMGProductFeed> GetCategoryFilterData(List<clsOMGProductFeed> getResultOMG)
    {
        List<clsOMGProductFeed> newProductList = new List<clsOMGProductFeed>();
        if (UC_CategoryList.SelectedIndex > 0 && getResultOMG != null)
        {
            var filterData = (from i in getResultOMG
                              where GetCategoryName().Contains(i.CategoryName)
                              select i).ToList();
            newProductList = filterData;
        }
        else
        {
            newProductList = getResultOMG;
        }

        return newProductList;
    }

    private List<string> GetCategoryName()
    {
        List<string> subCat = new List<string>();
        if (UC_CategoryList.SelectedIndex > 0 )
        {
            //clsCommonMethods _modelCat = new clsCommonMethods();
            //var SUBcatList = _modelCat.GetCategoryByID(Convert.ToInt32(UC_CategoryList.SelectedValue));
            //subCat.Add(SUBcatList.CategoryName_V);
            //if (SUBcatList.SubCategory.Count > 0)
            //{
            //    foreach (Sub_Category catText in SUBcatList.SubCategory)
            //    {
            //        subCat.Add(catText.SubCategoryName_V);
            //    }                
            //}

           subCat= clsAddItems.GetAllItems(Convert.ToInt32(UC_CategoryList.SelectedValue.ToString())).Select(c => c.CategoryName_V).ToList();   
        }
        return subCat;
    }

    private void AutoInsertByCategries(object sender, EventArgs e)
    {                
        //foreach (string cat in GetCategoryName())
        //{            
        //    string searchKeyword = cat;        

        //    int minPrice = 0;
        //    int maxPrice = 1000;
        //    for (int i = 0; i <= (100000/1000); i++)
        //    {
        //        GetSearchResult(searchKeyword.Replace(',', ' ').Replace('&', ' '), (minPrice + 1).ToString(), maxPrice.ToString());
                
        //        if (SearchLiveData.Count() > 0)
        //        {
        //            EventHandler Insert = this.InsertCommand;
        //            if (Insert != null)
        //            {
        //                ProductVW = SearchResultBulk();
        //                Insert(this, e);
        //            }
        //        }
        //        minPrice = minPrice + 1000;
        //        maxPrice = maxPrice + 1000;
        //    }          
             
        //}


        //foreach (Tbl_Item item in clsAddItems.GetAllItems())
        //{
        //    if (!item.ItenName.Contains("&"))
        //    {
        //        GetSearchResult(item.ItenName.Replace(',', ' ').Replace('&', ' '), "", "");

        //        if (SearchLiveData.Count() > 0)
        //        {
        //            EventHandler Insert = this.InsertCommand;
        //            if (Insert != null)
        //            {
        //                ProductVW = SearchResultBulk();
        //                Insert(this, e);
        //            }
        //        }
        //    }
        //}

        foreach (Tbl_Brand item in clsAddItems.GetAllBrand(Convert.ToInt32(UC_CategoryList.SelectedValue.ToString())))
        {
            if (!item.BrandName.Contains("&") && item.MinPrice!=null && item.MaxPrice!=null && item.RangePrice!=null)
            {
                int minPrice = item.MinPrice.Value;
               // int maxPrice = item.RangePrice.Value;
                int maxPrice = item.MinPrice.Value + item.RangePrice.Value;
                for (int i = 0; i <= (item.MaxPrice.Value / item.RangePrice.Value); i++)
                {
                    GetSearchResult(item.BrandName.Trim().TrimEnd(), (minPrice + 1).ToString(), maxPrice.ToString());

                    if (SearchLiveData.Count() > 0)
                    {
                        EventHandler Insert = this.InsertCommand;
                        if (Insert != null)
                        {
                            ProductVW = SearchResultBulk();
                            Insert(this, e);
                        }
                    }
                    //Response.Write("MIN:" + minPrice.ToString() + " Max:" + maxPrice + "<br/>");
                    minPrice = minPrice + item.RangePrice.Value; ;
                    maxPrice = maxPrice + item.RangePrice.Value; ;
                }  
            }

            clsAddItems.AddBrandName(true, item.BrandID);
        }
    }



    public string ProductCategoryName { get; set; }
    public Constants.APITypeURL Ad_Type { get; set; }
    public Constants.NameOfMerchants Ad_For { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Availability { get; set; }
    public string ImageUrl { get; set; }
    public string NavigationURL { get; set; }
    public int SerialNo { get; set; }
    public int CategoryID_N { get; set; }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public int MID { get; set; }
    public List<Product_Common> ProductVW { get; set; }   

    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }



    protected void btnDoLive_Click(object sender, EventArgs e)
    {
        

        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            ProductVW = SearchResult();
            Insert(this, e);
        }
    }

    private List<Product_Common> SearchResult()
    {
        List<Product_Common> ProductList = new List<Product_Common>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            CheckBox ckb = (CheckBox)row.FindControl("chkRow");

            if (ckb.Checked)
            {
                var sItem = (from p in SearchLiveData
                             where p.ProductSKU == gvItems.DataKeys[row.RowIndex].Values["ProductSKU"].ToString()
                             select p).FirstOrDefault();

                Product_Common item = new Product_Common();
                item.CreatedDate = DateTime.Now;
                item.Description = sItem.ProductDescription;//gvLiveProduct.DataKeys[row.RowIndex].Values["ProductDescription"].ToString();            
                item.ImageUrl = clsImageUrl.GetProductImageURL(sItem.ProductSmallImageURL + ";" + sItem.ProductMediumImageURL + ";" + sItem.ProductLargeImageURL);
                item.NavigationURL = sItem.ProductURL;
                item.ProductCategoryName = sItem.CategoryName;// +":" + sItem.CategoryPathAsString; //(string)DataBinder.Eval(row.DataItem, "CategoryName");
                item.Availability = sItem.StockAvailability;
                item.ProductPrice = Convert.ToSingle(sItem.ProductPrice);
                if (sItem.DiscountedPrice.HasValue)
                    item.DiscountedPrice = Convert.ToSingle(sItem.DiscountedPrice);
                item.Brand = sItem.Brand;
                if (sItem.Colour != null)
                    item.Color = sItem.Colour.ToString();

                item.PID = sItem.PID;
                item.ProductPriceCurrency = sItem.ProductPriceCurrency;
                //if (sItem.Location != null)
                item.Location = sItem.CategoryPathAsString.Replace("Root|", "");//.Replace(sItem.CategoryName + "|", "").Replace("||", "");

                item.SKUID = sItem.ProductSKU;
                item.MerchantProductID = sItem.ProductID.ToString();
                item.Title = sItem.ProductName;
                item.Ad_Type = Constants.APITypeURL.ProductFeed;
                item.MID = clsGetAppIDs.GetMIDByOMGMID(sItem.MID.ToString());
                item.Custom1 = sItem.Custom1;
                item.Custom2 = sItem.Custom2;
                item.Custom3 = sItem.Custom3;
                ProductList.Add(item);
            }
        }
        return ProductList;
    }

    private List<Product_Common> SearchResultBulk()
    {
        List<Product_Common> ProductList = new List<Product_Common>();
        foreach (clsOMGProductFeed sItem in SearchLiveData)
        {
            Product_Common item = new Product_Common();
            item.MID = clsGetAppIDs.GetMIDByOMGMID(sItem.MID.ToString());
            if (item.MID != 0)
            {
                item.CreatedDate = DateTime.Now;
                item.Description = sItem.ProductDescription;//gvLiveProduct.DataKeys[row.RowIndex].Values["ProductDescription"].ToString();            
                item.ImageUrl = clsImageUrl.GetProductImageURL(sItem.ProductSmallImageURL + ";" + sItem.ProductMediumImageURL + ";" + sItem.ProductLargeImageURL);
                item.NavigationURL = sItem.ProductURL;// clsUtility.GetDeeplinkInHTMLString(sItem.ProductURL);
                item.ProductCategoryName = sItem.CategoryName;// +":" + sItem.CategoryPathAsString; //(string)DataBinder.Eval(row.DataItem, "CategoryName");
                item.Availability = sItem.StockAvailability;
                item.ProductPrice = Convert.ToSingle(sItem.ProductPrice);
                if (sItem.DiscountedPrice.HasValue)
                    item.DiscountedPrice = Convert.ToSingle(sItem.DiscountedPrice);
                item.Brand = sItem.Brand;
                if (sItem.Colour != null)
                    item.Color = sItem.Colour.ToString();

                if (UC_CategoryList.SelectedIndex > 0)
                    item.CategoryID_N = Convert.ToInt32(UC_CategoryList.SelectedValue.ToString());

                item.PID = sItem.PID;
                item.ProductPriceCurrency = sItem.ProductPriceCurrency;
                //if (sItem.Location != null)
                item.Location = sItem.CategoryPathAsString.Replace("Root|","").Replace(sItem.CategoryName+"|","").Replace("||","");//Location.ToString();
                item.SKUID = sItem.ProductSKU;
                item.MerchantProductID = sItem.ProductID.ToString();
                item.Title = sItem.ProductName;
                item.Ad_Type = Constants.APITypeURL.ProductFeed;
                item.Custom1 = sItem.Custom1;
                item.Custom2 = sItem.Custom2;
                item.Custom3 = sItem.Custom3;
                ProductList.Add(item);
            }
        }
        return ProductList;
    }


    protected void btnPushCollectionData_Click(object sender, EventArgs e)
    {
        if (UC_CategoryList.SelectedIndex > 0)
        {
            AutoInsertByCategries(this, e);
        }
        else
        {
            lblMessage.Text = "Select Category";
        }
        
    }
}