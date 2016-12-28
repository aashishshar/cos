using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Newtonsoft.Json;

/// <summary>
/// Summary description for clsOMGProductFeedList
/// </summary>
public class clsOMGProductFeedList
{
	public clsOMGProductFeedList()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static IList<clsOMGProductFeed> ProductListData(string url)
    {
        WebClient client = new WebClient();
        //client.Headers.Add("key", "0e1a4b99-8aa0-43e7-81d7-22dd4e0f6786");
        //client.Headers.Add("Sig", "e7oQHLK3ENkaAySmswVV8qp8gUG5eC9UOXr7XHRQUwo%3d");
        
        client.Headers.Add("Content-Type","application/json");

        var dotd = client.DownloadString(url);
        DataContractJsonSerializer sdotd = new DataContractJsonSerializer(typeof(ProductsFeedData));

        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(dotd)))
        {
            try
            {
                var itemDotd = (ProductsFeedData)sdotd.ReadObject(ms);
                return itemDotd.GetProductsResult;

            }
            catch (Exception ex)
            {
                string str= ex.Message;
            }           

            return null;
        }
    }

    public static IList<clsOMGProductFeed> ProductJsonList(string url)
    {
        List<clsOMGProductFeed> items = new List<clsOMGProductFeed>();
        try
        {
            //WebRequest request = WebRequest.Create(url);
            //WebResponse ws = request.GetResponse();
            //DataContractJsonSerializer jsonSerializer =
            //        new DataContractJsonSerializer(typeof(ProductsFeedData));
            //var photos = (ProductsFeedData)jsonSerializer.ReadObject(ws.GetResponseStream());

            //items= photos.GetProductsResult;

            HttpWebRequest webRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = WebRequestMethods.Http.Get;

            webRequest.ContentType = "application/json";
            using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    DataContractJsonSerializer jsonSerializer =
                            new DataContractJsonSerializer(typeof(ProductsFeedData));
                    var photos = (ProductsFeedData)jsonSerializer.ReadObject(response.GetResponseStream());
                    items = photos.GetProductsResult;
                }
            }
        }
        catch (WebException we)
        {

        }
        catch (Exception ex)
        {

        }
        return items;
    }
}