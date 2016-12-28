using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public abstract class Common
{
    public string CreatedBy { get; set; }
    public Nullable<DateTime> CreatedDate { get; set; }
    public Nullable<DateTime> ModifiedDate { get; set; }
   
}

public interface CommonItem
{
     Int64 UserID { get; set; }
}


public class Category : Common
{

    public int CategoryID_N { get; set; }

    public string CategoryName_V { get; set; }

    public List<Sub_Category> SubCategory { get; set; }

    public Constants.Status Status_N { get; set; }
    public string MCategoryName_V { get; set; }
    public int? ParentCategoryID_N { get; set; }


}


public class Sub_Category : Common
{    
    public int SubCategoryID_N { get; set; }    
    public string SubCategoryName_V { get; set; }    
    public Constants.Status Status_N { get; set; }
    public List<Product_Common> Products_Common { get; set; }    
    public int? CategoryID_N { get; set; }
    public string CategoryName_V { get; set; }
}

public class UserProfile 
{   
    public Int64 UserID { get; set; }   
    public string LoginUserName { get; set; }   
    public Guid UserProfileID { get; set; }
    public string FullName { get; set; }
    public string EmailID { get; set; }   
    public string ProfilePicture { get; set; }   
    public DateTime? DOB { get; set; }   
    public string PhoneNo { get; set; }
    public bool? IsEmailVerified { get; set; }
    public bool? IsOfferReceiveWeekly { get; set; }
    public bool? IsOtherInfo { get; set; }
    public string BankAcHolderName { get; set; }
    public string BankName { get; set; }
    public string BankBranchName { get; set; }
    public string BankAccountNo { get; set; }
    public string IFSCCode { get; set; }
    public string FullNameOnAdd { get; set; }
    public string FullAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PinCode { get; set; }   
}

public class Product_Common : Common
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }

    public Nullable<int> CategoryID_N { get; set; }
    public string ProductCategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Availability { get; set; }
    public Int64 ProductID { get; set; }
    public int? PID { get; set; }
    public string Custom1 { get; set; }
    public string Custom2 { get; set; }
    public string Custom3 { get; set; }
    public float ProductPrice { get; set; }
    public string ProductPriceCurrency { get; set; }
    public float DiscountedPrice { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Location { get; set; }
    public string MerchantProductID { get; set; }
    public string SKUID { get; set; }

    public string ImageUrl { get; set; }
    public string NavigationURL { get; set; }
    public int SerialNo { get; set; }
    public int MID { get; set; }
    public Constants.APITypeURL Ad_Type { get; set; }
    public Constants.NameOfMerchants Ad_For { get; set; }
}


public class Merchant
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }
    public Int64 MID { get; set; }
    public int MerchantID { get; set; }
    public string MerchantName { get; set; }
    public string MerchantNameDetail { get; set; }
    public string MerchantImage { get; set; }
    public string MerchantDetails { get; set; }
    public string MerchantLogoUrl { get; set; }
    public string MerchantNameDescription { get; set; }
    public Int16? MerchantLinkType { get; set; }

    public int? AffiliateID { get; set; }
    public int? OMGMID { get; set; }
    public string CountryCode { get; set; }
    public int Status { get; set; }


    public string Seo_Title { get; set; }
    public string Seo_Description { get; set; }
    public string Seo_Keyword { get; set; }

    public string TrackingURL { get; set; }
    public Constants.CategoryType? CategoryType { get; set; }
    public int TotalOffer { get; set; }
    public string UserCommission { get; set; }
    public Constants.Status Status_N { get; set; }
    public List<Merchant_Offer> Merchant_Offers { get; set; }
    public List<Merchant_Coupon> Merchant_Coupons { get; set; }
    public List<Merchant_Deal> Merchant_Deals { get; set; }
    public List<Merchant_Banner> Merchant_Banners { get; set; }
    public List<vw_Product> Merchant_ProductDeals { get; set; }
    public List<Merchant_BreakDown> Merchant_BreakDowns { get; set; }
}

[Serializable]
public class Merchant_BreakDown
{
    
    public int BreakDownID { get; set; }
    public Int64? MID { get; set; }
    public string MerchantName { get; set; }
    public string BreakDownText { get; set; }
    public decimal? BreakDownStartAmount { get; set; }
    public decimal? BreakDownEndAmount { get; set; }
    public decimal? BreakDownMaxCommission { get; set; }
    public decimal? UserBreakDownMaxCommission { get; set; }
    public Constants.PriceType? CommissionType { get; set; }
    
    public DateTime? ToValidDate { get; set; }
    public DateTime? CreatedDate { get; set; }

}


[Serializable]
public class Merchant_Offer
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }

    public int? VoucherCodeID { get; set; }
    public Int64 MID { get; set; }    
    public string MerchantName { get; set; }
    public string UserCommision { get; set; }
    public string MerchantImage { get; set; }
    public Int64 OfferID { get; set; }
    public Constants.Device? CouponForDevice { get; set; }
    public int? OfferType { get; set; }
    public string Title { get; set; }

    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public string CouponCode { get; set; }
    public DateTime? ValidTill { get; set; }
    public DateTime? ActivationDate { get; set; }
    //public Constants.Adv_Type? OfferType { get; set; }
    public string TrackingURL { get; set; }
    public int? MoreOffer { get; set; }
    public string NavigationURL { get; set; }
    public DateTime CreatedDate { get; set; }
   
}

[Serializable]
public class Merchant_Coupon
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }

    public Int64 MID { get; set; }
    public string MerchantName { get; set; }
    public string MerchantImage { get; set; }
    public Int64 CID { get; set; }
    public Constants.Device CouponForDevice { get; set; }
   
    public string Coupon { get; set; }
    public string Offer { get; set; }
    public DateTime ValidTill { get; set; }
    public string NavigationURL { get; set; }
    public DateTime CreatedDate { get; set; }
    
}

public class Merchant_Deal
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }

    public Int64 MID { get; set; }
    public string MerchantName { get; set; }
    public string ProductID { get; set; }
    public string ProductSKU { get; set; }
    public Int64 DealID { get; set; }
    //public Constants.Device CouponForDevice { get; set; }
    public string ProductCategoryName { get; set; }
 
    public string Title { get; set; }
    public string Description { get; set; }
    public string Availability { get; set; }
    public string DiscountPercentage { get; set; }
    public double? ProductPrice { get; set; }
    public string ProductPriceCurrency { get; set; }
    public double? WasPrice { get; set; }
    public double? DiscountedPrice { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Location { get; set; }

    public string CouponCode { get; set; }
    public string ImageUrl { get; set; }
    public int SerialNo { get; set; }
    //public DateTime ValidTill { get; set; }
    public string NavigationURL { get; set; }
    public DateTime CreatedDate { get; set; }
    public Nullable<DateTime> ModifiedDate { get; set; }
    public string CreatedBy { get; set; }


}

public class Merchant_ApiURL
{
    public Int64 APIID { get; set; }
    public int APIType { get; set; }
    public string APITypeName { get; set; }
    public string ApiName { get; set; }
    public string ApiURL { get; set; }
    public DateTime? ExpireOn { get; set; }
    public int ApiScheduleType { get; set; }
    public string ApiScheduleTypeName { get; set; }
    public string RunOnTimeName { get; set; }
    public TimeSpan? RunOnTime { get; set; }

}

public class Merchant_Commision
{
    public int CommisionID { get; set; }
    public string MerchantName { get; set; }
    public Int64? MerchantID { get; set; }
    public string ProgramName { get; set; }
    public string Commision { get; set; }
    public string UserCommision { get; set; }
    public int? Currency { get; set; }
     public string CurrencyName { get; set; }
     public int? MaximumCommision { get; set; }
    
     public int? PID { get; set; }
     public string MerchantLogoUrl { get; set; }
   
     public string ProductDescription { get; set; }
     public string Sector { get; set; }
  
    
     public string PayoutType { get; set; }
     public string CookieDuration { get; set; }
     public Constants.YesNo? DeepLinkEnabled { get; set; }
     public Constants.YesNo? ProductfeedAvailable { get; set; }
     public Constants.YesNo? UIDTracking { get; set; }
     public string WebsiteUrl { get; set; }
     public string TrackingURL { get; set; }
     public Constants.PriceType? PriceType { get; set; }
     public Constants.Status? Status { get; set; }
}

public class Merchant_Banner
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }
    public Int64? MID { get; set; }
    public string MerchantName { get; set; }
    public string LogoURL { get; set; }
    public Int64 BannerID { get; set; }
    public string BannerText { get; set; }
    public string BannerTypeName { get; set; }
    public int? BannerType { get; set; }
    public string BannerURL { get; set; }
    public int? BannerLocation { get; set; }
    public string BannerLocationName { get; set; }
    public Merchant MerchantDetail { get; set; }
    public int? Price { get; set; }
    public int? DiscountedPrice { get; set; }
    public string Description { get; set; }
    public string DiscountPercentageText { get; set; }

    
}

public class vw_Product
{
    public string USERID { get; set; }
    public bool ISLOGIN { get; set; }

    public Int64 ID { get; set; }
    public Nullable<int> CategoryID_N { get; set; }
    public int? MerchantName { get; set; }
    public string MerchantLogourl { get; set; }
    public string MerchantNameDetail { get; set; }   
    public int? AdType { get; set; }
    public int? PID { get; set; }
    public string MName { get; set; }
    public string Custom1 { get; set; }
    public string Custom2 { get; set; }
    public string Custom3 { get; set; }
    public string MerchantLogoUrl { get; set; }
    public string AdTypeName { get; set; }
    public string CategoryName { get; set; }
    public string ProductTitle { get; set; }
    public string Description { get; set; }
    public string Availability { get; set; }
    public string ImageUrl { get; set; }
    public string NavigationURL { get; set; }

    public float? ProductPrice { get; set; }
    public string ProductPriceCurrency { get; set; }
    public float? DiscountedPrice { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string DiscountPercentage { get; set; }
    public string Location { get; set; }
    public string UserCommision { get; set; }
    public int? PriceType { get; set; }

    public int SerialNo { get; set; }
    public DateTime CreatedDate { get; set; }
    public Nullable<DateTime> ModifiedDate { get; set; }
    public string CreatedBy { get; set; }

}

public class Transaction_Feed
{
    public Int64 TransactionID { get; set; }

    public string ClickTime { get; set; }
    public DateTime TransactionTime { get; set; }
    public string OmgTransactionID { get; set; }
    public string OmgMerchantRef { get; set; }
    public string UID { get; set; }
    public string UID2 { get; set; }
    public string MID { get; set; }
    public string MerchantImage { get; set; }
    public string MerchantName { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string PID { get; set; }
    public string Product { get; set; }
    public string Referrer { get; set; }
    public string SR { get; set; }
    public string VR { get; set; }
    public string NVR { get; set; }
    public string Status { get; set; }
    public string Paid { get; set; }
    public string Completed { get; set; }
    public string UKey { get; set; }
    public string TransactionValue { get; set; }
    public string VoucherCode { get; set; }
    public decimal? FinalCommision { get; set; }
    public decimal? UserPercentage { get; set; }
    public bool SendToUser { get; set; }
    public Constants.AmountStatus? AmountStatus { get; set; }
}

public class MissingCashBack
{
    public int TicketNo { get; set; }

    public DateTime? TransactionDate { get; set; }
    public Int64? MID { get; set; }
    public Guid? UserID { get; set; }
    public string OrderID { get; set; }
    public string UserName { get; set; }
    public string AmountPaid { get; set; }
    public string CouponCode { get; set; }
    public string Details    { get; set; }
    public string FileUrl { get; set; }
    public string ContactNo { get; set; }
    public bool? MailSend { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Constants.Status? Status { get; set; }
    public string MerchantLogoUrl { get; set; }
    public string MerchantName { get; set; }
}

public class Wallet_History
{
    public string PendingAmount { get; set; }

    public string ValidatedAmount { get; set; }
    public string TransferableAmount { get; set; }

    public string RejectedAmount { get; set; }
    public string RechargeAmount { get; set; }
}

public class Notification 
{
    public int NotificationID { get; set; }
    public string NotificationText { get; set; }
    public Constants.Status Status { get; set; }
    public Constants.NotificationType NotificationType { get; set; }
    public DateTime? CreatedDate { get; set; }
    
}