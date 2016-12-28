using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityData;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Configuration;
using System.Data.Entity;
using System.Web.Security;
using System.Data;

/// <summary>
/// Summary description for clsAddItems
/// </summary>
public class clsAddItems
{
	public clsAddItems()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static List<Adv_DynamicProductFeed> GetDynamicXMLProductFeedApiURL()
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_DynamicProductFeeds
                           where var.ISRUN=="N" && var.Status=="A"
                           select var);
            return varlist.ToList();
        }
    }

    public static void AddMasterItem(Tbl_Item items)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {

            Tbl_Item item = new Tbl_Item();
           
            var original = model.Tbl_Items.Where(c => c.ItenName == items.ItenName).SingleOrDefault();

            if (original == null)
            {
                item.ItenName = items.ItenName;
                item.ItemBrand = items.ItemBrand;
                item.CategoryID_N = items.CategoryID_N;
                item.CategoryName_V = items.CategoryName_V;
                item.merchantname = items.merchantname;
                model.AddToTbl_Items(item);
                model.SaveChanges();
            }       
        }
    }

    public static void AddMasterItem(List<int> itemID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            model.Tbl_Items.Where(x => itemID.Contains(x.ItemID)).ToList().ForEach(model.Tbl_Items.DeleteObject);

            model.SaveChanges();
        }
    }

    public static List<Tbl_Item> GetAllItems()   
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_Items                         
                           select var).OrderBy(p => p.ItenName).ToList();
            return varlist;   
        }        
    }

    public static List<Tbl_Item> GetAllItems(int catID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_Items
                           where var.CategoryID_N == catID
                           select var).OrderBy(p => p.ItenName).ToList();
            return varlist;
        }
    }

    public static List<Tbl_Brand> GetAllBrand()
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_Brands
                          // where var.CategoryID == catID && var.ISRun == false
                           select var).OrderBy(p => p.BrandName).ToList();
            return varlist;
        }
    }

    public static List<Tbl_Brand> GetAllBrandByCategoryID(int catID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_Brands
                           where var.CategoryID == catID 
                           select var).OrderBy(p => p.BrandName).ToList();
            return varlist;
        }
    }

    public static List<Tbl_Brand> GetAllBrand(int catID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_Brands
                           where var.CategoryID==catID && var.ISRun==false
                           select var).OrderBy(p => p.BrandName).ToList();
            return varlist;
        }
    }

    public static void AddBrandName(bool isRun,int BrandID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {

            Tbl_Brand item = new Tbl_Brand();

            var original = model.Tbl_Brands.Where(c => c.BrandID.Equals(BrandID)).SingleOrDefault();

            if (original != null)
            {
                original.ISRun = isRun;
                model.SaveChanges();
                model.Dispose();
            }            
        }
    }
    public static void AddBrandName(List<Tbl_Brand> brand)
    {
        try
        {

            using (var model = new cos_OtherEntities())
            {
                brand.ForEach(com =>
                {
                    var original = model.Tbl_Brands.SingleOrDefault(E => E.BrandID == com.BrandID);
                    original.MinPrice = com.MinPrice;
                    original.MaxPrice = com.MaxPrice;
                    original.RangePrice = com.RangePrice;
                    //original.ISRun = com.ISRun;                    
                });
                model.SaveChanges();
                model.Dispose();
            }
        }
        catch (Exception ex)
        {

        }
    }
    public static void AddBrandName(Tbl_Brand brand)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {

            //Tbl_Brand item = new Tbl_Brand();

            var original = model.Tbl_Brands.Where(c => c.BrandID.Equals(brand.BrandID)).SingleOrDefault();

            if (original != null)
            {
                //original.ISRun = isRun;
                original.ISRun = brand.ISRun;
                original.MinPrice = brand.MinPrice;
                original.MaxPrice = brand.MaxPrice;
                original.RangePrice = brand.RangePrice;
                model.SaveChanges();
                model.Dispose();
            }
            else
            {
                //item.BrandName = brand.BrandName;
                //item.CategoryID = brand.CategoryID;
                //item.ISRun = false;
                model.AddToTbl_Brands(brand);
                model.SaveChanges();
            }
        }
    }

    public static void AddBrandName(List<int> itemID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            model.Tbl_Brands.Where(x => itemID.Contains(x.BrandID)).ToList().ForEach(model.Tbl_Brands.DeleteObject);

            model.SaveChanges();
        }
    }

    public static void AddMasterItemDetails(Tbl_ItemsDetail items)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {

            Tbl_ItemsDetail item = new Tbl_ItemsDetail();

            var original = model.Tbl_ItemsDetails.Where(c => c.Title == items.Title).SingleOrDefault();

            if (original == null)
            {  
                item.Title = items.Title;
                if (items.SnapDeal > 0)
                {
                    item.SnapDeal = items.SnapDeal;
                }
                else if (items.Amazon > 0)
                {
                    item.Amazon = items.Amazon;
                }
                else if (items.Flipkart > 0)
                {
                    item.Flipkart = items.Flipkart;
                }
                else if (items.Paytm > 0)
                {
                    item.Paytm = items.Paytm;
                }

                model.AddToTbl_ItemsDetails(item);
                model.SaveChanges();
            }
            else
            {
                if (items.SnapDeal > 0)
                {
                    original.SnapDeal = items.SnapDeal;
                }
                else if (items.Amazon > 0)
                {
                    original.Amazon = items.Amazon;
                }
                else if (items.Flipkart > 0)
                {
                    original.Flipkart = items.Flipkart;
                }
                else if (items.Paytm > 0)
                {
                    original.Paytm = items.Paytm;
                }
                
                model.SaveChanges();
                    model.Dispose();
            }
        }
    }


    public static void AddMasterItemDetails_MOre(Tbl_ItemsDetails_More items)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {

            Tbl_ItemsDetails_More item = new Tbl_ItemsDetails_More();

            var original = model.Tbl_ItemsDetails_Mores.Where(c => c.MerchantID == items.MerchantID && c.MerchantProductID == items.MerchantProductID).SingleOrDefault();

            if (original == null)
            {
                item.Availability = items.Availability;
                item.Brand = items.Brand;
                item.Color = items.Color;
                item.Custom1 = items.Custom1;
                item.Custom2 = items.Custom2;
                item.Custom3 = items.Custom3;
                item.Description = items.Description;
                item.DiscountedPrice = items.DiscountedPrice;
                item.ImageUrl = items.ImageUrl;
                item.Location = items.Location;
                item.MerchantID = items.MerchantID;
                item.MerchantName = items.MerchantName;
                item.MerchantProductID = items.MerchantProductID;
                item.NavigationURL = items.NavigationURL;
                item.ProductID = items.ProductID;
                item.ProductPrice = items.ProductPrice;
                item.ProductPriceCurrency = items.ProductPriceCurrency;
                item.SKUID = items.SKUID;
                item.Title = items.Title;

                model.AddToTbl_ItemsDetails_Mores(item);
                model.SaveChanges();
            }
            else
            {
                if (original.ProductPrice < item.ProductPrice || original.DiscountedPrice < item.DiscountedPrice)
                {
                    original.ProductPrice = items.ProductPrice;
                    original.DiscountedPrice = items.DiscountedPrice;
                    model.SaveChanges();
                    model.Dispose();
                }
            }

        }
    }

    public static List<Tbl_ItemsDetails_More> GetAllItemsDetails_more()
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_ItemsDetails_Mores
                           select var).OrderBy(p => p.Title).ToList();
            return varlist;
        }
    }

    public static List<Tbl_ItemsDetails_More> GetAllItemsDetails_more(double MID)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_ItemsDetails_Mores
                           where var.MerchantID==MID
                           select var).Distinct().ToList();
            return varlist;
        }
    }

    public static Tbl_ItemsDetails_More GetAllItemsDetails_moreByProductTitle(double MID,string productTitle)
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_ItemsDetails_Mores
                           where var.MerchantID == MID && var.Title.Contains(productTitle)
                           select var).FirstOrDefault();
            return varlist;
        }
    }

    //public static IEnumerable<TSource> DistinctBy<TSource, TKey>
    //(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    //{
    //    HashSet<TKey> seenKeys = new HashSet<TKey>();
    //    foreach (TSource element in source)
    //    {
    //        if (seenKeys.Add(keySelector(element)))
    //        {
    //            yield return element;
    //        }
    //    }
    //}
    public static List<Tbl_ItemsDetail> GetAllItemsDetails()
    {
        using (cos_OtherEntities model = new cos_OtherEntities())
        {
            var varlist = (from var in model.Tbl_ItemsDetails
                           select var).OrderBy(p => p.Title).ToList();
            return varlist;
        }
    }
}