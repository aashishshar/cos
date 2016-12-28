using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using EntityData;

public partial class UC_UCUI_Master_Merchant_uc_LiveXmlProductFeed : System.Web.UI.UserControl, IProductEntryView
{
    ProductPrensenter _prensenter;
    public event EventHandler InsertCommand;
    public event EventHandler DeleteCommand;

    public UC_UCUI_Master_Merchant_uc_LiveXmlProductFeed()
    {
        _prensenter = new ProductPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

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
        set { throw new NotImplementedException(); }
    }

    public int MID { get; set; }

    public List<Product_Common> ProductVW { get; set; }

   


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        foreach (Adv_DynamicProductFeed feed in clsAddItems.GetDynamicXMLProductFeedApiURL())
        {

            EventHandler Insert = this.InsertCommand;
            if (Insert != null)
            {
                ProductVW = XmlResult(feed.CategoryID_N,feed.PFXmlPath,feed.SearchInCategory);
                Insert(this, e);
            }
        }       
    }

    private List<Product_Common> XmlResult(int? categoryID, string path, string keyWord)
    {
        DataSet ds = GetXMLDATA(path);
        if (ds == null)
            return null;

        var item = from sItem in ds.Tables[0].AsEnumerable()
                   select new Product_Common()
                   {
                       CategoryID_N = categoryID,
                       CreatedDate = DateTime.Now,
                       Description = sItem.Field<string>("ProductDescription"),
                       ImageUrl = clsImageUrl.GetProductImageURL((ds.Tables["Product"].Columns.Contains("ProductImageSmallURL") ? sItem.Field<string>("ProductImageSmallURL") + ";" : ";") + (ds.Tables["Product"].Columns.Contains("ProductImageMediumURL") ? sItem.Field<string>("ProductImageMediumURL") + ";" : ";") + (ds.Tables["Product"].Columns.Contains("ProductImageLargeURL") ? sItem.Field<string>("ProductImageLargeURL") : "")),
                       NavigationURL = sItem.Field<string>("producturl"),
                       ProductCategoryName = sItem.Field<string>("CategoryName"),
                       Availability = ds.Tables["Product"].Columns.Contains("StockAvailability") ? sItem.Field<string>("StockAvailability") : "",
                       ProductPrice = Convert.ToSingle(sItem.Field<string>("ProductPrice")),
                       //if (sItem.Field<string>("DiscountedPrice")!="")
                       DiscountedPrice = Convert.ToSingle(sItem.Field<string>("DiscountedPrice")),
                       Brand = ds.Tables["Product"].Columns.Contains("Brand") ? sItem.Field<string>("Brand") : "",
                       //if (sItem.Field<string>("Colour") != "")
                       Color = ds.Tables["Product"].Columns.Contains("Colour") ? sItem.Field<string>("Colour") : "",

                       ProductPriceCurrency = ds.Tables["Product"].Columns.Contains("ProductPriceCurrency") ? sItem.Field<string>("ProductPriceCurrency") : "",
                       //if (sItem.Location != null)
                       Location = sItem.Field<string>("CategoryPathAsString").Replace("Root|", ""),//.Replace(sItem.CategoryName + "|", "").Replace("||", "");

                       SKUID = ds.Tables["Product"].Columns.Contains("ProductSKU") ? sItem.Field<string>("ProductSKU") : "",
                       MerchantProductID = sItem.Field<string>("ProductID"),
                       Title = sItem.Field<string>("ProductName"),
                       PID =Convert.ToInt32(sItem.Field<string>("PID")),
                       Ad_Type = Constants.APITypeURL.ProductFeed,
                       MID = clsGetAppIDs.GetMIDByOMGMID(sItem.Field<string>("MID"))
                   };


        List<Product_Common> ProductList = new List<Product_Common>();
        if (!string.IsNullOrEmpty(keyWord))
        {
            string[] keyWords = keyWord.Split(',');
            var result = from s in item
                         where keyWords.Contains(s.Title + " " + s.Description + " " + s.Location)
                         select s;
            ProductList = result.ToList();
        }
        else
        {
            ProductList = item.ToList();
        }


        return ProductList;
        // }

    }


    private DataSet GetXMLDATA( string url)
    {
        XElement xele = XElement.Load(url);
        DataSet ds = clsFileToTable.XElementToDataset(xele);
        return ds;
    }

}