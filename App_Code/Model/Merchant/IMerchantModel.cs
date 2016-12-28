using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IProductModel
/// </summary>

/// <summary>
/// Summary description for IUserGroup
/// </summary>
public interface IMerchantModel
{
    Merchant FindMerchant(string MerchantName);
    List<Merchant> GetAllMerchants();
    List<Merchant> GetAllMerchantsList();
    Merchant GetMerchant(Int64 merchantID);
    Merchant GetMerchantMID(int OMGMID);
    Merchant GetMerchantMID(int OMGMID, string MerchantNameDescription);

    void DBOperation(Constants.Action command, Merchant item = null, List<Int64> MerchantIds = null);
}

public interface ICouponModel
{
    List<Merchant_Coupon> GetAllCoupons();
    List<Merchant_Coupon> GetLatestCoupons(int takeCoupon);
    List<Merchant_Coupon> GetAllCouponsSearchText(string searchText);
    void DBOperation(Constants.Action command, Merchant_Coupon item = null, List<Int64> CouponIds = null);
}

public interface IDealModel
{
    List<Merchant_Deal> GetAllDeals();
    List<Merchant_Deal> GetAllDealsSearchText(string searchText);
    void DBOperation(Constants.Action command, Merchant_Deal item = null, List<Int64> DealIds = null);
}

public interface IOfferModel
{
    List<Merchant_Offer> GetAllOffers();
    List<Merchant_Offer> GetLatestOffers(int takeCoupon);
    List<Merchant_Offer> GetAllOffersSearchText(string searchText);
    List<Merchant_Offer> GetAll_Proc_Offer(int pageIndex, int pageSize, out int totalRecord, string searchTextOrOfferType);
    void DBOperation(Constants.Action command, Merchant_Offer item = null, List<Int64> offerIds=null);
}

public interface IApiURLModel
{
    List<Merchant_ApiURL> GetAllApiURLs();
    void DBOperation(Constants.Action command, Merchant_ApiURL item = null, List<Int64> apiUrlIds = null);
}

public interface ICommisionModel
{
    List<Merchant_Commision> GetAllCommision();
    List<Merchant_Commision> GetCommisionByMerchant(string MerchantName);
    void DBOperation(Constants.Action command, Merchant_Commision item = null, List<int> Ids = null, List<Merchant_Commision> commisions = null);
}

public interface IBannerModel
{
    List<Merchant_Banner> GetAllBanner(int? bannerLocation,int? categoryType=null);
    void DBOperation(Constants.Action command, Merchant_Banner item = null, List<Int64> Ids = null);
}
public interface IMissingCashBackModel
{

    List<MissingCashBack> GetAllMissingCashBacks();
    void DBOperation(Constants.Action command, MissingCashBack item = null, List<int> Ids = null, List<MissingCashBack> items = null);
}



