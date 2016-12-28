
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Xml;

public partial class Admin_API : AdminBasePage,IProductEntryView
{

    ProductPrensenter _prensenter;

    public Admin_API()
    {
        _prensenter = new ProductPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindApi();
        }
       
    }


    private void BindApi()
    {

        //EnumControl.GetEnumDescriptions<Constants.NameOfMerchants>(ddlApiList);

        EnumControl.GetEnumDescriptions<Constants.APITypeURL>(rdbApiTypeURL);

    }
   // Constants.NameOfMerchants api;
    protected void btnRunAPI_Click(object sender, EventArgs e)
    {
        if (uc_MerchantListItem.SelectedMerchant!=string.Empty)
        {
            string strFlipKart = uc_MerchantListItem.SelectedMerchantText;
            //Response.Write(strFlipKart);
            //api = (Constants.NameOfMerchants)Enum.Parse(typeof(Constants.NameOfMerchants), strFlipKart.Contains(Constants.NameOfMerchants.FlipKart.ToString()) ? "FlipKart" : "");
            Constants.APITypeURL type = (Constants.APITypeURL)Enum.Parse(typeof(Constants.APITypeURL), rdbApiTypeURL.SelectedValue.ToString());
            DownloadData(type, sender, e, uc_MerchantListItem.SelectedMerchant);   
            //switch (api)
            //{
            //    case Constants.NameOfMerchants.FlipKart:
            //        Constants.APITypeURL type = (Constants.APITypeURL)Enum.Parse(typeof(Constants.APITypeURL), rdbApiTypeURL.SelectedValue.ToString());
            //        DownloadData(type, sender, e, uc_MerchantListItem.SelectedMerchant);                   
            //        break;              
            //    default:

            //        break;
            //}
        }

    }

    #region "Common Method"
   

    #endregion

    #region "Method FlipKart"
    public void DownloadData(Constants.APITypeURL type, object sender, EventArgs e, string MID)
    {
        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);



        switch (type)
        {
            case Constants.APITypeURL.FlipKart_DOTD_OffersAPI:

                //var test = client.DownloadString(" https://affiliate-api.flipkart.net/affiliate/feeds/aashishsh/category/v1:reh.xml?expiresAt=1425146502079&sig=6259329061d2b8a0b81b7982eaf07d70");
                var dotd = client.DownloadString(Constants.FlipKart_DOTD_Offers_API);
                DataContractJsonSerializer sdotd = new DataContractJsonSerializer(typeof(DOTD));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(dotd)))
                {
                    // deserialize the JSON object using the WeatherData type.//Repeater1.DataSource = weatherData.dotdList;//Repeater1.DataBind();
                    var itemDotd = (DOTD)sdotd.ReadObject(ms);
                    int itemNo = 0;
                    foreach (DotdList item in itemDotd.dotdList)
                    {
                        this.CategoryID_N = clsGetAppIDs.GetCategoryIDByText("DOTD");
                        if (this.CategoryID_N > 0)
                        {
                            this.Title = item.title;
                            this.Description = item.description;
                            this.NavigationURL = item.url;
                            this.Availability = item.availability;
                            this.Ad_Type = Constants.APITypeURL.FlipKart_DOTD_OffersAPI;
                            //this.Ad_For =Convert.ToInt16(MID);
                            this.MID = Convert.ToInt16(MID);
                            this.ImageUrl = item.imageUrls[0].url;
                            itemNo = itemNo + 1;
                            this.SerialNo = itemNo;
                            CreateProduct(sender, e);
                        }

                    }
                }
                break;
            case Constants.APITypeURL.FlipKart_TOP_Offers_API:
                var topOffer = client.DownloadString(Constants.FlipKart_TOP_Offers_API);
                DataContractJsonSerializer serializertopOff = new DataContractJsonSerializer(typeof(TopOffer));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(topOffer)))
                {
                    var topOff = (TopOffer)serializertopOff.ReadObject(ms);
                    int itemNo = 0;
                    foreach (TopOffersList item in topOff.topOffersList)
                    { 
                         this.CategoryID_N = clsGetAppIDs.GetCategoryIDByText("Top Offer");
                         if (this.CategoryID_N > 0)
                         {
                             this.Title = item.title;
                             this.Description = item.description;
                             this.NavigationURL = item.url;
                             this.Availability = item.availability;
                             this.Ad_Type = Constants.APITypeURL.FlipKart_TOP_Offers_API;
                             //this.Ad_For = api;
                             this.MID = Convert.ToInt16(MID);
                             this.ImageUrl = item.imageUrls[0].url;
                             itemNo = itemNo + 1;
                             this.SerialNo = itemNo;
                             CreateProduct(sender, e);
                         }
                    }
                }
                break;
            case Constants.APITypeURL.FlipKart_Product_Feeds_API:

                HttpWebRequest webRequest = HttpWebRequest.Create(ddlCategory.SelectedValue.ToString()) as HttpWebRequest;
                webRequest.Method = WebRequestMethods.Http.Get;
                webRequest.ContentType = "text/xml; charset=utf-8";
                webRequest.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
                webRequest.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);
                //webRequest.ContentType = "application/x";
                using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Encoding encoding;
                        try
                        {
                            encoding = Encoding.GetEncoding(response.CharacterSet);
                        }
                        catch
                        {
                            encoding = Encoding.UTF8;
                        }


                        StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
                        var categoryItems = reader.ReadLine();
                        XmlDocument doc = new XmlDocument();
                        doc.Load(reader);
                        //XElementToDataTable(categoryItems, sender, e);                       
                    }
                }

               // var categoryItems = client.DownloadString();

                //XElementToDataTable(categoryItems, sender, e);
                break;
            default:
                break;
        }

    }
    
    private void BindFlipKartCategory()
    {
        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);

        var category = client.DownloadString("https://affiliate-api.flipkart.net/affiliate/api/aashishshar.xml");
        var response = XDocument.Parse(category);

        foreach (XElement ele in response.Root.Elements("apiGroups"))
        {
            DataTable dt =clsFileToTable.XElementToDataTable1(ele);

            DataView view = new DataView(dt);
            DataTable distinctValues = view.ToTable(true, "ResourceName", "Get");

            if (distinctValues.Rows.Count > 0)
            {
                ddlCategory.DataSource = distinctValues;
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select Category");
            }
            else
            {
                ddlCategory.Items.Insert(0, "No Category");
            }
        }

        client.Dispose();
    }

    public void XElementToDataTable(string element, object sender, EventArgs e)
    {

        DataSet ds1 = new DataSet();
        ds1.ReadXml(new StringReader(element.ToString()));

       

        var row = from t1 in ds1.Tables["ImageURLs"].AsEnumerable()
                  let id = t1.Field<Int32>("ImageURLs_ID")
                  join t2 in ds1.Tables["Entry"].AsEnumerable()
                                     on id equals t2.Field<Int32>("ImageURLs_ID")
                  where t2.Field<string>("key") == "100x100"
                  select new
                  {
                      ProductAttributes_ID = t1.Field<Int32>("ProductAttributes_ID"),
                      ImgageURL = t2.Field<string>("Value")
                  };

        var productIdCategory = from pa in ds1.Tables["ProductAttributes"].AsEnumerable()
                                let PAID = pa.Field<Int32>("productbaseinfo_id")
                                join pi in ds1.Tables["ProductIdentifier"].AsEnumerable()
                                on PAID equals pi.Field<Int32>("productbaseinfo_id")
                                //join cp in ds1.Tables["categorypaths"].AsEnumerable()
                                //on pi.Field<Int32>("ProductIdentifier_ID") equals cp.Field<Int32>("categorypaths_id")
                                //join cap in ds1.Tables["CategoryPath"].AsEnumerable()
                                //on cp.Field<Int32>("categorypaths_id") equals cap.Field<Int32>("categorypaths_id")
                                //join pItem in ds1.Tables["Item"].AsEnumerable()
                                //on cap.Field<Int32>("CategoryPath_id") equals pItem.Field<Int32>("CategoryPath_ID")
                                select new
                                {
                                    //Category = pItem.Field<string>("Title"),
                                    SKUID = pi.Field<string>("productid"),
                                    Productbaseinfo_id = PAID
                                };
      
        string str = ds1.Tables["MaximumRetailPrice"].Columns["Amount"].DataType.ToString();
        string str1 = ds1.Tables["SellingPrice"].Columns["Amount"].DataType.ToString();
        //Product_Common item = new Product_Common();
        var product = from p in ds1.Tables["ProductAttributes"].AsEnumerable()
                      let AID = p.Field<Int32>("ProductAttributes_ID")
                      join mrp in ds1.Tables["MaximumRetailPrice"].AsEnumerable()
                      on AID equals mrp.Field<Int32>("ProductAttributes_ID")
                      join sp in ds1.Tables["SellingPrice"].AsEnumerable()
                      on AID equals sp.Field<Int32>("ProductAttributes_ID")
                      join dr in row.AsEnumerable()
                      on AID equals dr.ProductAttributes_ID
                      join cat in productIdCategory.AsEnumerable()
                      on p.Field<Int32>("productbaseinfo_id") equals cat.Productbaseinfo_id
                      select new Product_Common()
                      {
                          CreatedDate = DateTime.Now,
                          MID = Convert.ToInt32(uc_MerchantListItem.GetValueFindByText("Flipkart")),
                          CategoryID_N=Convert.ToInt32(UC_CategoryList.SelectedValue.ToString()),
                          //SubCategoryID=
                          //id = AID,
                          //CodAvailable = p.Field<string>("CodAvailable"),
                          Color = p.Field<string>("color"),
                          // discountPercentage = p.Field<string>("discountPercentage"),
                          // EmiAvailable = p.Field<string>("EmiAvailable"),
                          //ProductAttributes_ID = p.Field<Int32>("ProductAttributes_ID"), 
                          
                          //Availability = p.Field<string>("instock"),
                          Brand = p.Field<string>("ProductBrand"),
                          Description = p.Field<string>("ProductDescription"),
                          NavigationURL = p.Field<string>("producturl"),
                          //sizevariants =  p.Field<string>("sizevariants"), 
                          Title = p.Field<string>("title"),
                          //productbaseinfo_id =  p.Field<string>("productbaseinfo_id"), 
                          ImageUrl = dr.ImgageURL,//,//, 
                          ProductPrice = Convert.ToSingle(mrp.Field<string>("Amount")),
                          DiscountedPrice = Convert.ToSingle(sp.Field<string>("Amount")),
                          // ProductCategoryName=cat.Category,
                          SKUID = cat.SKUID,
                          Ad_Type = Constants.APITypeURL.ProductFeed

                      };

        List<Product_Common> ProductList = product.ToList();
       

        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            ProductVW = ProductList;
            Insert(this, e);
        } 
        
        gvProductList.DataSource = ProductList;
        gvProductList.DataBind();

        if (ds1.Tables["ProductFeed"].Columns.Contains("NextURL"))
        {
            var NextURL = (from t1 in ds1.Tables["ProductFeed"].AsEnumerable()
                           select new
                           {
                               NxtURL = t1.Field<string>("NextURL")
                           }).FirstOrDefault();

            if (NextURL != null)
            {
                //WebClient client = new WebClient();
                //client.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
                //client.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);

                HttpWebRequest webRequest = HttpWebRequest.Create(NextURL.NxtURL.ToString()) as HttpWebRequest;
                webRequest.Method = WebRequestMethods.Http.Get;
                webRequest.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
                webRequest.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);
                //webRequest.ContentType = "application/x";
                using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        var categoryItems = reader.ReadLine();
                        XElementToDataTable(categoryItems, sender, e);                       
                    }
                }


              
            }           
        }
    }

   
    public static void SaveMemoryStream(MemoryStream ms, string FileName)
    {

        FileStream outStream = File.OpenWrite(FileName);
        ms.WriteTo(outStream);
        outStream.Flush();
        outStream.Close();
    }

    #endregion

    public string ProductCategoryName { get; set; }

  

    public string Description { get; set; }

    public string Availability { get; set; }

    public string ImageUrl { get; set; }
    public string NavigationURL { get; set; }
    public int SerialNo { get; set; }
    public string  Title { get; set; }
    public int CategoryID_N { get; set; }

    public string strMessage
    {      
        set
        {
            lblmsg.Text = value;
        }
    }

    public event EventHandler InsertCommand;

    public event EventHandler DeleteCommand;

    protected void CreateProduct(object sender, EventArgs e)
    {
        lblmsg.Text = string.Empty;
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {

            
            
            Insert(this, e);        
        }
    }


    public Constants.APITypeURL Ad_Type { get; set; }

    public Constants.NameOfMerchants Ad_For { get; set; }


    public int MID { get; set; }


    public List<Product_Common> ProductVW { get; set; }
    protected void rdbApiTypeURL_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbApiTypeURL.SelectedItem.Text == "FlipKart Product Feeds")
        {
            BindFlipKartCategory();
        }
    }
    protected void btnNextProduct_Click(object sender, EventArgs e)
    {
        string str = btnNextProduct.CommandName.ToString();


        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);

        var topOffer = client.DownloadString(str);
        XElementToDataTable(topOffer,sender,e);
    }
}