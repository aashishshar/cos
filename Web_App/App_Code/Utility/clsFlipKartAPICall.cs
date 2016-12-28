using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Data;

/// <summary>
/// Summary description for clsFlipKartAPICall
/// </summary>
public class clsFlipKartAPICall
{
    private const string FlipKart_AffiliateId = "aashishsh";
    private const string FlipKart_AffiliateToken = "7fbe41311d1241a2afd9e164028f7cf6";
    private const string FlipKart_DOTD_Offers_API = "https://affiliate-api.flipkart.net/affiliate/offers/v1/dotd/json";
    private const string FlipKart_TOP_Offers_API = "https://affiliate-api.flipkart.net/affiliate/offers/v1/top/json";

	public clsFlipKartAPICall()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static List<TopOffersList> FlipKartTopOfferList()
    {
        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", FlipKart_AffiliateToken);
        var topOffer = client.DownloadString(FlipKart_TOP_Offers_API);
        DataContractJsonSerializer serializertopOff = new DataContractJsonSerializer(typeof(TopOffer));
        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(topOffer)))
        {
            var topOff = (TopOffer)serializertopOff.ReadObject(ms);
            return topOff.topOffersList;
        }
    }


    public static List<DotdList> FlipKartDOTDList()
    {
        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", FlipKart_AffiliateToken);
        var dotd = client.DownloadString(FlipKart_DOTD_Offers_API);
        DataContractJsonSerializer sdotd = new DataContractJsonSerializer(typeof(DOTD));
        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(dotd)))
        {
            // deserialize the JSON object using the WeatherData type.//Repeater1.DataSource = weatherData.dotdList;//Repeater1.DataBind();
            var itemDotd = (DOTD)sdotd.ReadObject(ms);
            return itemDotd.dotdList;            
        }
    }


    public static string FlipkartDownLoadString(string URL)
    {
        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", FlipKart_AffiliateToken);
        string topOffer = client.DownloadString(URL);
        client.Dispose();
        return topOffer;
    }


    public static DataTable FLipkartCategoryList()
    {
        WebClient client = new WebClient();
        client.Headers.Add("Fk-Affiliate-Id", FlipKart_AffiliateId);
        client.Headers.Add("Fk-Affiliate-Token", FlipKart_AffiliateToken);

        var topOffer = client.DownloadString("https://affiliate-api.flipkart.net/affiliate/api/aashishshar.xml");
        var response = XDocument.Parse(topOffer);
        DataTable distinctValues = new DataTable();
        foreach (XElement ele in response.Root.Elements("apiGroups"))
        {
            DataTable dt = xmlParser.XElementToDataTableForCategory(ele);
            DataView view = new DataView(dt);
            distinctValues = view.ToTable(true, "ResourceName", "Get");
        }
        return distinctValues;
    }

}