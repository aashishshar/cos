using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml.Linq;

public partial class UC_UCUI_Master_Merchant_uc_OMG_Excel_Product_Feed : System.Web.UI.UserControl, IProductEntryView
{
   ProductPrensenter _prensenter;
     public event EventHandler InsertCommand;
     public event EventHandler DeleteCommand;



     public UC_UCUI_Master_Merchant_uc_OMG_Excel_Product_Feed()
    {
        _prensenter = new ProductPrensenter(this);
    }

    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (fuUpload.HasFile)
        {

            string filename = Path.GetFileName(fuUpload.FileName);
            fuUpload.SaveAs(Server.MapPath("~/XML/") + filename);

            string path1 = Path.GetFullPath(fuUpload.PostedFile.FileName);
            XElement xele = XElement.Load(Server.MapPath("~/XML/") + filename);
            ds = clsFileToTable.XElementToDataset(xele);
            //XMLDataTable = dt;
            //BindXMLData("");
            //AssingDBDate(ds.Tables["Product"]);
            File.Delete(Server.MapPath("~/XML/") + filename);
            //EventHandler Insert = this.InsertCommand;
            //if (Insert != null)
            //{
            //    this.Merchant_Deals = AssingDBDate(ds.Tables["Product"]);
            //    //lblMessage.Text = string.Empty;
            //    Insert(this, e);
            //    BindItems();
            //}



            if (ds.Tables["Product"].Rows.Count > 0)
            {
                string imageURL = string.Empty;
                //if (ds.Tables["Product"].Columns.Contains("ProductImageSmallURL"))
                //{
                //    imageURL=
                //}
                //if (ds.Tables["Product"].Columns.Contains("ProductImageMediumURL"))
                //{

                //}
                //if (ds.Tables["Product"].Columns.Contains("ProductImageLargeURL"))
                //{

                //}
               


                var xmlData = from sItem in ds.Tables["Product"].AsEnumerable()
                              select new Product_Common()
                              {
                                  CreatedDate = DateTime.Now,
                                  Description = sItem.Field<string>("ProductDescription"),                                                  
                                  ImageUrl = clsImageUrl.GetProductImageURL((ds.Tables["Product"].Columns.Contains("ProductImageSmallURL")?sItem.Field<string>("ProductImageSmallURL") + ";" :";")+(ds.Tables["Product"].Columns.Contains("ProductImageMediumURL")?sItem.Field<string>("ProductImageMediumURL") + ";":";") + (ds.Tables["Product"].Columns.Contains("ProductImageLargeURL")?sItem.Field<string>("ProductImageLargeURL"):"")),
                                  NavigationURL = sItem.Field<string>("producturl"),
                                  ProductCategoryName = sItem.Field<string>("CategoryName"),
                                  Availability = ds.Tables["Product"].Columns.Contains("StockAvailability") ? sItem.Field<string>("StockAvailability"):"",
                                  ProductPrice = Convert.ToSingle(sItem.Field<string>("ProductPrice")),                                                             
                                  //if (sItem.Field<string>("DiscountedPrice")!="")
                                  DiscountedPrice = Convert.ToSingle(sItem.Field<string>("DiscountedPrice")),
                                  Brand = ds.Tables["Product"].Columns.Contains("Brand") ? sItem.Field<string>("Brand") : "",
                                  //if (sItem.Field<string>("Colour") != "")
                                  Color =ds.Tables["Product"].Columns.Contains("Colour") ? sItem.Field<string>("Colour"):"",

                                  ProductPriceCurrency = ds.Tables["Product"].Columns.Contains("ProductPriceCurrency") ? sItem.Field<string>("ProductPriceCurrency") : "",
                                  //if (sItem.Location != null)
                                  Location = sItem.Field<string>("CategoryPathAsString").Replace("Root|", ""),//.Replace(sItem.CategoryName + "|", "").Replace("||", "");

                                  SKUID =ds.Tables["Product"].Columns.Contains("ProductSKU") ? sItem.Field<string>("ProductSKU"):"",
                                  MerchantProductID = sItem.Field<string>("ProductID"),
                                  Title = sItem.Field<string>("ProductName"),
                                  Ad_Type = Constants.APITypeURL.ProductFeed,
                                  MID = clsGetAppIDs.GetMIDByOMGMID(sItem.Field<string>("MID"))
                              };

                List<Product_Common> ProductList = xmlData.ToList();
                //gvItems.DataSource = ProductList;
                //gvItems.DataBind();

                EventHandler Insert = this.InsertCommand;
                if (Insert != null)
                {
                    ProductVW = ProductList;
                    Insert(this, e);
                }
            }
            //ProductList.Add(item);

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
}