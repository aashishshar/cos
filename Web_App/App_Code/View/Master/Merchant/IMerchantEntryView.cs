using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IProductEntryView
/// </summary>
public interface IMerchantEntryView : IMerchantListView
{
    //string MerchantName { get; set; }    
    string MerchantDetails { get; set; }
    int MerchantID { get; set; }
    int? AffiliateID { get; set; }
    int? OMGMID { get; set; }
    string CountryCode { get; set; }
    string LogoUrl { get; set; }
    string MerchantNameDetail { get; set; }
    string TrackingURL { get; set; }
    Constants.CategoryType CategoryType { get; set; }
    string MerchantNameDescription { get; set; }
    Int16? MerchantLinkType { get; set; }

    string strMessage { set; }
    List<Int64> Ids { get; set; }

    event EventHandler InsertCommand;
    event EventHandler UpdateCommand;
    event EventHandler DeleteCommand;

    
}


 public interface IMerchantListView : IView
 {
     string MID { get; set; }
     string MerchantName { get; set; }
     List<Merchant> Merchants { get; set; }

     event EventHandler ViewCommand;
 }

 public interface IMerchant_CouponEntryView : IMerchant_CouponListView
 {
     Int64 MID { get; set; }
     int CouponForDevice { get; set; }
     string Coupon { get; set; }
     string Offer { get; set; }
     DateTime ValidTill { get; set; }
     string NavigationURL { get; set; }
     string strMessage { set; }
     List<Int64> Ids { get; set; }


     event EventHandler BulkInsert;
     event EventHandler InsertCommand;
     event EventHandler UpdateCommand;
     event EventHandler DeleteCommand;
 }

 public interface IMerchant_CouponListView : IView
 {
     string SearchText { get; set; }
     int TakeLatestCoupon { get; set; }
     event EventHandler SearchRefresh;
     List<Merchant_Coupon> Merchant_Coupons { get; set; }
 }


 public interface IMerchant_OfferEntryView : IMerchant_OfferListView
 {
     Int64 MID { get; set; }
     int CouponForDevice { get; set; }
     string Title { get; set; }
     string Description { get; set; }
     string CouponCode { get; set; }
      DateTime? StartDate { get; set; }
     DateTime? ValidTill { get; set; }
     string NavigationURL { get; set; }
     string strMessage { set; }
     List<Int64> OfferIds { get; set; }
     int? VoucherCodeID { get; set; }
     int? OfferType { get; set; }

     event EventHandler InsertCommand;
     event EventHandler UpdateCommand;
     event EventHandler DeleteCommand;
     event EventHandler BulkInsert;
 }
 public interface IMerchant_OfferListView : IView
 {
     string SearchText { get; set; }
     event EventHandler SearchRefresh;
     event EventHandler PagingCommand;
     
     int PageIndex { get; set; }
     int PageSize { get; set; }
     int TotalRecord { get; set; }
     int TakeLatestCoupon { get; set; }
     List<Merchant_Offer> Merchant_Offers { get; set; }
 }


 public interface IMerchant_DealEntryView : IMerchant_DealListView
 {
     Int64 MID { get; set; }
     string ProductCategoryName { get; set; }
     string Title { get; set; }
     string Description { get; set; }
     string Availability { get; }
     string CouponCode { get; set; }
     string ImageUrl { get; set; }
     int SerialNo { get; set; }
     string NavigationURL { get; set; }
     string strMessage { set; }
     List<Int64> Ids { get; set; }

     event EventHandler InsertCommand;
     event EventHandler UpdateCommand;
     event EventHandler DeleteCommand;
 }
 public interface IMerchant_DealListView : IView
 {
     string SearchText { get; set; }
     event EventHandler SearchRefresh;
     int TakeLatestCoupon { get; set; }
     List<Merchant_Deal> Merchant_Deals { get; set; }
 }


 public interface IMerchant_ApiURLView : IMerchant_ApiURLListView
 {
     int APIType { get; set; }

     string ApiName { get; set; }
     string ApiURL { get; set; }
     DateTime? ExpireOn { get; set; }
     int ApiScheduleType { get; set; }

     TimeSpan? RunOnTime { get; set; }
     string strMessage { set; }
     List<Int64> Ids { get; set; }

     event EventHandler InsertCommand;
     event EventHandler UpdateCommand;
     event EventHandler DeleteCommand;
 }

 public interface IMerchant_ApiURLListView : IView
 {
     List<Merchant_ApiURL> Merchant_ApiURLs { get; set; }
 }



 public interface IMerchant_CommisionView : IMerchant_CommisionListView
 {
     Int64? MerchantID { get; set; }
     string ProgramName { get; set; }
     string Commision { get; set; }
     string UserCommision { get; set; }
     int? Currency { get; set; }
     int? MaximumCommision { get; set; }
     
     int? PID { get; set; }
     //string MerchantLogoUrl { get; set; }
     string ProductDescription { get; set; }
     string Sector { get; set; }
     string PayoutType { get; set; }
     string CookieDuration { get; set; }
     Constants.YesNo? DeepLinkEnabled { get; set; }
     Constants.YesNo? ProductfeedAvailable { get; set; }
     Constants.YesNo? UIDTracking { get; set; }
     string WebsiteUrl { get; set; }
     string TrackingURL { get; set; }
     Constants.PriceType? PriceType { get; set; }
     Constants.Status? Status { get; set; }

     string strMessage { set; }
     List<int> Ids { get; set; }

     event EventHandler UpdateCommand;
     event EventHandler InsertCommand;
     event EventHandler DeleteCommand;
 }
 public interface IMerchant_CommisionListView : IView
 {
     string MerchantName { get; set; }
     List<Merchant_Commision> Merchant_Commisions { get; set; }
 }

 public interface IMerchant_BannerView : IMerchant_BannerListView
 {
     string BannerText { get; set; }
     int? BannerType { get; set; }
     string BannerURL { get; set; }
     int? BannerLocation { get; set; }
     Int64 MID { get; set; }
     string strMessage { set; }
     List<Int64> Ids { get; set; }

     event EventHandler InsertCommand;
     event EventHandler DeleteCommand;
 }
 public interface IMerchant_BannerListView : IView
 {
     int? BannerType { get; set; }
     int? Price { get; set; }
     int? DiscountedPrice { get; set; }
     string Description { get; set; }
     int? CategoryType { get; set; }
     List<Merchant_Banner> Merchant_Banners { get; set; }
 }

 public interface IMissingCashBack_View : IIMissingCashBack_ListView
 {
      DateTime? TransactionDate { get; set; }
      Int64? MID { get; set; }
     //public Guid? UserID { get; set; }
      string OrderID { get; set; }
      string AmountPaid { get; set; }
      string CouponCode { get; set; }
      string Details { get; set; }
      string FileUrl { get; set; }
      string ContactNo { get; set; }
     //public DateTime? CreatedDate { get; set; }
      Constants.Status? Status { get; set; }
     //public string MerchantLogoUrl { get; set; }
     //Int64 MID { get; set; }
     string strMessage { set; }
     List<int> Ids { get; set; }

     event EventHandler InsertCommand;
     event EventHandler DeleteCommand;
     event EventHandler UpdateCommand;
 }
 public interface IIMissingCashBack_ListView : IView
 {

     List<MissingCashBack> MissingCashBack_List { get; set; }
 }
