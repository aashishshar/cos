using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;




[DataContract]
public class DOTD
{

    [DataMember]
    public List<DotdList> dotdList { get; set; }
}

[DataContract]
public class TopOffer
{
    [DataMember]
    public List<TopOffersList> topOffersList { get; set; }
}

[DataContract]
public class Product_Feeds_API
{
    [DataMember]
    public ProductBaseInfo productBaseInfo { get; set; }
    [DataMember]
    public ProductShippingBaseInfo productShippingBaseInfo { get; set; }
    [DataMember]
    public string offset { get; set; }
}


public class CategoryPaths
{
    public List<CategoryPaths> categoryPath { get; set; }
}

public class ProductIdentifier
{
    public string productId { get; set; }
    public CategoryPaths categoryPaths { get; set; }
}

public class ImageUrls
{
    public string _Size_400x400 { get; set; }
    public string _Size_275x275 { get; set; }
    public string _Size_75x75 { get; set; }
    public string _Size_125x125 { get; set; }
    public string _Size_40x40 { get; set; }
    public string _Size_100x100 { get; set; }
    public string _Size_200x200 { get; set; }
    public string _Size { get; set; }
}

public class MaximumRetailPrice
{
    public int amount { get; set; }
    public string currency { get; set; }
}

public class SellingPrice
{
    public int amount { get; set; }
    public string currency { get; set; }
}

public class Offer
{
    public string title { get; set; }
}

public class ProductAttributes
{
    public string title { get; set; }
    public object productDescription { get; set; }
    public ImageUrls imageUrls { get; set; }
    public MaximumRetailPrice maximumRetailPrice { get; set; }
    public SellingPrice sellingPrice { get; set; }
    public string productUrl { get; set; }
    public string productBrand { get; set; }
    public bool inStock { get; set; }
    public bool codAvailable { get; set; }
    public bool emiAvailable { get; set; }
    public int discountPercentage { get; set; }
    public object cashBack { get; set; }
    public List<Offer> offers { get; set; }
    public string size { get; set; }
    public object color { get; set; }
    public string sizeUnit { get; set; }
    public string sizeVariants { get; set; }
    public object colorVariants { get; set; }
    public object styleCode { get; set; }
}

public class ProductBaseInfo
{
    public ProductIdentifier productIdentifier { get; set; }
    public ProductAttributes productAttributes { get; set; }
}

public class ProductShippingBaseInfo
{
    public object shippingOptions { get; set; }
}

public class TopOffersList
{
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public List<ImageUrl> imageUrls { get; set; }
    public string availability { get; set; }
}

public class DotdList
{
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public List<ImageUrl> imageUrls { get; set; }
    public string availability { get; set; }
}

public class ImageUrl
{
    public string url { get; set; }
}









