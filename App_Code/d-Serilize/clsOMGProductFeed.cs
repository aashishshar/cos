using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clsOMGProductFeed
/// </summary>

 [DataContract]
 [Serializable]
public class clsOMGProductFeed
{
    public clsOMGProductFeed()
    {
        //
        // TODO: Add constructor logic here
        //
    }

     [DataMember]
    public string Brand { get; set; }
     [DataMember]
     public string CategoryName { get; set; }
     [DataMember]
     public string CategoryPathAsString { get; set; }
     [DataMember]
     public object Colour { get; set; }
     [DataMember]
     public string Custom1 { get; set; }
     [DataMember]
     public string Custom2 { get; set; }
     [DataMember]
     public string Custom3 { get; set; }
     [DataMember]
     public string Custom4 { get; set; }
     [DataMember]
     public string Custom5 { get; set; }
     [DataMember]
     public double? DiscountedPrice { get; set; }
     [DataMember]
     public object Location { get; set; }
     [DataMember]
     public int MID { get; set; }
     [DataMember]
     public object MPN { get; set; }
     [DataMember]
     public string MerchantDomain { get; set; }
     [DataMember]
     public string MerchantLogoURL { get; set; }
     [DataMember]
     public int PID { get; set; }
     [DataMember]
     public string ProductDescription { get; set; }
     [DataMember]
     public int ProductID { get; set; }
     [DataMember]
     public string ProductLargeImageURL { get; set; }
     [DataMember]
     public string ProductMediumImageURL { get; set; }
     [DataMember]
     public string ProductName { get; set; }
     [DataMember]
     public double ProductPrice { get; set; }
     [DataMember]
     public string ProductPriceCurrency { get; set; }
     [DataMember]
     public string ProductSKU { get; set; }
     [DataMember]
     public string ProductSmallImageURL { get; set; }
     [DataMember]
     public string ProductURL { get; set; }
     [DataMember]
     public string StockAvailability { get; set; }
     [DataMember]
    public double? WasPrice { get; set; }




}

[DataContract]
[Serializable]
public class ProductsFeedData
{
     
  //  public IList<clsOMGProductFeed> GetProductsResult { get; set; }
[DataMember]
     public List<clsOMGProductFeed> GetProductsResult { get; set; }
}
