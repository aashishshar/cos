using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for clsImageUrl
/// </summary>
public class clsImageUrl
{
    public clsImageUrl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetProductImageURL(object bigImage)
    {
        string[] str = bigImage.ToString().Split(';'); 
        if (!string.IsNullOrEmpty(str[0].ToString()))
        {
            return str[0].ToString();
        }
        else if (!string.IsNullOrEmpty(str[1].ToString()))
        {
            return str[1].ToString();
        }
        else
        {
            return str[2].ToString();
        }
    }



    public static string GetMerchantImage(Constants.NameOfMerchants merchantName)
    {
        string url = string.Empty;
        //switch (merchantName)
        //{
        //    case Constants.NameOfMerchants.FlipKart:
        //        url = "~/merchantImage/flipkart.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Amazon:
        //        url = "~/merchantImage/amazon.jpg";
        //        break;
        //    case Constants.NameOfMerchants.ShopClues:
        //        url = "~/merchantImage/shopclues.jpg";
        //        break;
        //    case Constants.NameOfMerchants.SnapDeal:
        //        url = "~/merchantImage/snapdeal.jpg";
        //        break;
        //    case Constants.NameOfMerchants.AmericanSwan:
        //        url = "~/merchantImage/AmericanSwan.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Askmebazaar:
        //        url = "~/merchantImage/Askmebazaar.jpg";
        //        break;
        //    case Constants.NameOfMerchants.BabyHugz:
        //        url = "~/merchantImage/BabyHugz.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Basicslife:
        //        url = "~/merchantImage/Basicslife.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Bata:
        //        url = "~/merchantImage/bata.jpg";
        //        break;
        //    case Constants.NameOfMerchants.BodyShop:
        //        url = "~/merchantImage/BodyShop.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Goibibo:
        //        url = "~/merchantImage/Goibibo.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Bluestone:
        //        url = "~/merchantImage/Bluestone.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Foodpanda:
        //        url = "~/merchantImage/Foodpanda.jpg";
        //        break;
        //    case Constants.NameOfMerchants.GMCampaigns:
        //        url = "~/merchantImage/dominos.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Groupon:
        //        url = "~/merchantImage/Groupon.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Jabong:
        //        url = "~/merchantImage/Jabong.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Justeat:
        //        url = "~/merchantImage/Justeat.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Koovs:
        //        url = "~/merchantImage/Koovs.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Myntra:
        //        url = "~/merchantImage/Myntra.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Paytm:
        //        url = "~/merchantImage/Paytm.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Stalkbuylove:
        //        url = "~/merchantImage/Stalkbuylove.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Ticketgoose:
        //        url = "~/merchantImage/Ticketgoose.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Travelguru:
        //        url = "~/merchantImage/Travelguru.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Trendin:
        //        url = "~/merchantImage/Trendin.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Voylla:
        //        url = "~/merchantImage/Voylla.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Zovi:
        //        url = "~/merchantImage/Zovi.jpg";
        //        break;
        //    case Constants.NameOfMerchants.PizzaHut:
        //        url = "~/merchantImage/PizzaHut.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Uninor:
        //        url = "~/merchantImage/Uninor.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Zivame:
        //        url = "~/merchantImage/Zivame.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Yepme:
        //        url = "~/merchantImage/Yepme.jpg";
        //        break;
        //    case Constants.NameOfMerchants.ITCFoods:
        //        url = "~/merchantImage/ITCFood.jpg";
        //        break;
        //    case Constants.NameOfMerchants.TimesInternet:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.TravelKhana:
        //        url = "~/merchantImage/TravelKhana.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Babyoyecom:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Chumbakcom:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Coke2home:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Ebay:
        //        url = "~/merchantImage/ebay.jpg";
        //        break;
        //    case Constants.NameOfMerchants.ELITIFY:
        //        url = "~/merchantImage/firstcry.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Expedia:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Faballeycom:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Fabfurnishcom:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Firstcrycom:
        //        url = "~/merchantImage/firstcry.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Greendustcom:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Homeshop18com:
        //        url = "~/merchantImage/homeshop18.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Hotelscom:
        //        url = "~/merchantImage/TimesInternet.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Pepperfrycom:
        //        url = "~/merchantImage/pepperfry.jpg";
        //        break;
        //    case Constants.NameOfMerchants.Printvenuecom:
        //        url = "~/merchantImage/printvenue.jpg";
        //        break;

            //                case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //                case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //                case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.TravelKhana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Edukart:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Ebay:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Easypolicycom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dxcom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Droomin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dogspotin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dishtv:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.DiagnoseCoupon:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Designemporia:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dell_co_in:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Deal4loans:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.DealPly:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dell_co_in:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Designemporia:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.DiagnoseCoupon:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dishtv:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dogspotin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Droomin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dxcom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Easypolicycom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Ebay:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Edukart:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.ELITIFY:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.EtihadAirways:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.EurekaForbes:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Evokin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Expedia:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.ezeego1coin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Expedia:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Evokin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.EurekaForbes:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.EtihadAirways:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.ELITIFY:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Edukart:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Ebay:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Droomin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dogspotin:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dishtv:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.DiagnoseCoupon:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Designemporia:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dell_co_in:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.DealPly:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Deal4loans:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.DBS:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Darveyscom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Dailyobjectscom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Daburaromacom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.CordLife:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Collegedunia:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Coke2home:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.ClubMahindra:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.CleartripPrivateLimited:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.CitiBank:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Chumbakcom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.CarTrade:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Candere:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.CampusSutra:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Caironme:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.BVP:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.BuyHatke:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Buongiorno:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Bookmyflowerscom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.BookingKhazana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.BirlaMutualFund:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Bing:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.BigfLix:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Bharatmatrimony:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Bankbazarcom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Babyoyecom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AxisBank:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AsianPaints:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Ashiana:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AngelBroking:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AmericanExpress:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AmarChitrakatha:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.aliinacom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AirtelOnlineRecharge:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Airtel:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Airstream:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Aircel:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AirAsiaAEGIS:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AdlabsEntertainment:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Adda52:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Acropolis:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.ace2three:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Aashaonlinecom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.bestbuycom:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.AirAsiaAEGIS:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;
            //case Constants.NameOfMerchants.Agoda:
            //               url = "~/merchantImage/TravelKhana.jpg";
            //               break;




        //    default:
        //        break;
        //}
        return url;

    }


    public static string GetImagesInHTMLString(string htmlString, string width, string height)
    {
        string images = string.Empty;//= new List<string>();
        String HTML = htmlString;
        Regex reImg = new Regex(@"<img\s[^>]*>", RegexOptions.IgnoreCase);
        Regex reHeight = new Regex(@"height=(?:(['""])(?<height>(?:(?!\1).)*)\1|(?<height>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        Regex reWidth = new Regex(@"width=(?:(['""])(?<width>(?:(?!\1).)*)\1|(?<width>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        MatchCollection mc = reImg.Matches(HTML);
        foreach (Match mImg in mc)
        {
            string imageUrl = string.Empty;
            //Console.WriteLine("    img tag: {0}", mImg.Groups[0].Value);
            if (reHeight.IsMatch(mImg.Groups[0].Value))
            {
                Match mHeight = reHeight.Match(mImg.Groups[0].Value);
                //Console.WriteLine("  height is: {0}", mHeight.Groups["height"].Value);
            }
            if (reWidth.IsMatch(mImg.Groups[0].Value))
            {
                Match mWidth = reWidth.Match(mImg.Groups[0].Value);
                //Console.WriteLine("   width is: {0}", mWidth.Groups["width"].Value);
            }
            if (reHeight.IsMatch(mImg.Groups[0].Value))
            {
                Match mSrc = reSrc.Match(mImg.Groups[0].Value);
                imageUrl = "Handler/ImageResizeHandler.ashx?width=" + width + "&height=" + height + "&imgPath=" + mSrc.Groups["src"].Value;
                //images.Add(mSrc.Groups["src"].Value);
                //Console.WriteLine("     src is: {0}", mSrc.Groups["src"].Value);
            }

            if (reImg.IsMatch(mImg.Groups[0].Value))
            {
                Match mSrc = reSrc.Match(mImg.Groups[0].Value);
                imageUrl = "Handler/ImageResizeHandler.ashx?width=" + width + "&height=" + height + "&imgPath=" + mSrc.Groups["src"].Value;
                //images.Add(mSrc.Groups["src"].Value);
                //Console.WriteLine("     src is: {0}", mSrc.Groups["src"].Value);
            }


            string newImageSRC = "<img src='" + imageUrl + "'/>";

            images = htmlString.Replace(mImg.Groups[0].Value, newImageSRC);
        }

        return images;
    }
   
}