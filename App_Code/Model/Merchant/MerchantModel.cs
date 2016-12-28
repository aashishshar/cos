using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class MerchantModel : IMerchantModel, ICouponModel, IDealModel, IOfferModel, IApiURLModel, ICommisionModel, IBannerModel, IMissingCashBackModel
{
    clsCommonMethods client;
    public MerchantModel()
	{
        client = new clsCommonMethods();
	}

    public List<Merchant> GetAllMerchants()
    {
        List<Merchant> items = client.GetAllMerchants().ToList();
        return items;
    }


    public Merchant FindMerchant(string MerchantName)
    {
        Merchant item = client.FindMerchant(MerchantName);
        return item;
    }



    public Merchant GetMerchantMID(int OMGMID)
    {
        Merchant item = client.FindMerchantMID(OMGMID);
        return item;
    }

    public Merchant GetMerchantMID(int OMGMID, string MerchantNameDescription)
    {
        Merchant item = client.FindMerchantMID(OMGMID);
        return item;
    }

    public Merchant GetMerchant(Int64 merchantID)
    {
        Merchant item = client.GetAllMerchants().Where(p => p.MID == merchantID).FirstOrDefault();
        return item;
    }

    public void DBOperation(Constants.Action command, Merchant item = null, List<Int64> Ids = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertMerchant(item);
                break;
            case Constants.Action.Delete:
                client.DeleteMerchants(Ids);
                break;
            case Constants.Action.Update:
                client.UpdateMerchant(item);
                break;
            default:
                break;
        }
    }

    public void DBOperation(Constants.Action command, Merchant_Coupon item = null, List<Int64> Ids = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertCoupon(item);
                break;
            case Constants.Action.Delete:
                client.DeleteCoupons(Ids);
                break;
            default:
                break;
        }
    }

    public void DBOperation(Constants.Action command, Merchant_Deal item = null, List<Int64> Ids = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertDeal(item);
                break;
            case Constants.Action.Delete:
                client.DeleteDeals(Ids);
                break;
            default:
                break;
        }
    }

    public void DBOperation(Constants.Action command, Merchant_Offer item = null, List<Int64> Ids = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertOffer(item);
                break;
            case Constants.Action.Delete:
                client.DeleteOffers(Ids);
                break;
            default:
                break;
        }
    }

    public List<Merchant_Coupon> GetAllCoupons()
    {
        List<Merchant_Coupon> items = client.GetAllCoupons().ToList();
        return items;
    }

    public List<Merchant_Coupon> GetLatestCoupons(int takeCoupon)
    {
        List<Merchant_Coupon> items = client.GetLatestCoupons(takeCoupon).ToList();
        return items;
    }

    public List<Merchant_Deal> GetAllDeals()
    {
        List<Merchant_Deal> items = client.GetAllDeals().ToList();
        return items;
    }

    public List<Merchant_Offer> GetAllOffers()
    {
        List<Merchant_Offer> items = client.GetAllOffers().ToList();
        return items;
    }

    public List<Merchant_Offer> GetLatestOffers(int takeOffer)
    {
        List<Merchant_Offer> items = client.GetLatestOffers(takeOffer).ToList();
        return items;
    }

    public List<Merchant_ApiURL> GetAllApiURLs()
    {
        List<Merchant_ApiURL> items = client.GetAllApiURLs().ToList();
        return items;
    }

    public void DBOperation(Constants.Action command, Merchant_ApiURL item = null, List<long> apiUrlIds = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertApiURL(item);
                break;
            case Constants.Action.Delete:
                client.DeleteApiURLs(apiUrlIds);
                break;
            default:
                break;
        }
    }

  

    public void DBOperation(Constants.Action command, Merchant_Commision item = null, List<int> Ids = null,List<Merchant_Commision> commisions=null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertCommision(item);
                break;
            case Constants.Action.Delete:
                client.DeleteCommisions(Ids);
                break;
                 case Constants.Action.Update:
                client.UpdateCommisions(commisions);
                break;
            default:
                break;
        }
    }

   

    public void DBOperation(Constants.Action command, Merchant_Banner item = null, List<long> Ids = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertBanner(item);
                break;
            case Constants.Action.Delete:
                client.DeleteBanners(Ids);
                break;
            default:
                break;
        }
    }



    public List<Merchant_Commision> GetAllCommision()
    {
        List<Merchant_Commision> items = client.GetAllCommisions().ToList();
        return items;
    }

    public List<Merchant_Banner> GetAllBanner(int? bannerLocation,int? categoryType=null)
    {
        List<Merchant_Banner> items = client.GetAllBanners(bannerLocation,categoryType).ToList();
        return items;
    }




    public List<Merchant_Coupon> GetAllCouponsSearchText(string searchText)
    {
        List<Merchant_Coupon> items = client.GetAllCouponsSearchText(searchText).ToList();
        return items;
    }


    public List<Merchant_Deal> GetAllDealsSearchText(string searchText)
    {
        List<Merchant_Deal> items = client.GetAllDealsSearchText(searchText).ToList();
        return items;
    }


    public List<Merchant_Offer> GetAllOffersSearchText(string searchText)
    {
        List<Merchant_Offer> items = client.GetAllOffersSearchText(searchText).ToList();
        return items;
    }

    public List<Merchant_Offer> GetAll_Proc_Offer(int pageIndex, int pageSize, out int totalRecord,string offerType)
    {       
        return client.GetAll_Proc_Offer(pageIndex,pageSize,out totalRecord,offerType);
    }
    
    public List<Merchant_Commision> GetCommisionByMerchant(string MerchantName)
    {
        List<Merchant_Commision> items = client.GetCommisionsByMID(MerchantName).ToList();
        return items;
    }

    public List<MissingCashBack> GetAllMissingCashBacks()
    {
        List<MissingCashBack> items = client.GetAllMissingCashBacks().ToList();
        return items;
    }

    public void DBOperation(Constants.Action command, MissingCashBack item = null, List<int> Ids = null, List<MissingCashBack> items = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertCashIssue(item);
                break;
            case Constants.Action.Delete:
                client.DeleteCashIssue(Ids);
                break;
                 case Constants.Action.Update:
                client.UpdateCashIssue(item);
                break;
            default:
                break;
        }
    }


    public List<Merchant> GetAllMerchantsList()
    {
        List<Merchant> items = client.GetAllMerchantsList().ToList();
        return items;
    }
}