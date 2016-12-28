
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Xml;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class _Default : BasePage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //Profile.FirstName = "Ashish";
        //string p = Profile.FirstName;
        //SendEmail(sender, e);
        //DateTime dt = DateTime.UtcNow;
        //clsUtility.GetTagStringInHtmlString("<a href='http://clk.omgt5.com/?AID=764019&PID=10722&UID=cos&WID=57715' target='_blank'>Recharge Here</a>","");
        //string i = Profile.CurrentUser["CurrentUser"].ToString();

         //DownloadData("http://api.omgpm.com/network/OMGNetworkApi.svc/v1.1/ProductFeeds/GetProducts?AgencyID=95&AID=764019&MID=&Keyword=motorola&MinPrice=0&MaxPrice=9000&Currency=INR&DiscountedOnly=False&ProductSKU=&Key=0e1a4b99-8aa0-43e7-81d7-22dd4e0f6786&Sig=e7oQHLK3ENkaAySmswVV8qp8gUG5eC9UOXr7XHRQUwo%3d&SigData=2015-05-12 07:07:50.483");
        //getXMLDocumentFromXMLTemplate("http://api.omgpm.com/network/OMGNetworkApi.svc/v1.1/ProductFeeds/GetProducts?AgencyID=95&AID=764019&MID=&Keyword=Shirt&MinPrice=0&MaxPrice=500&Currency=INR&DiscountedOnly=False&ProductSKU=&Key=0e1a4b99-8aa0-43e7-81d7-22dd4e0f6786&Sig=FXymxniaDFdTj0Wn7PJyFSXk%2feZ1YaRhmi7WSWBrv7k%3d&SigData=2015-05-13 05:17:20.571");
        //ExportToDataTable();
        
        //https://admin.omgpm.com/v2/VoucherCodes/Affiliate/ExportVoucherCodes.ashx?Auth=95:764019:31600E6D4717172FC8C62F9C1D35CE11&Format=Xml&Agency=95");//https://affiliate-api.flipkart.net/affiliate/api/aashishsh.json");
    }


    

   
    //public void DownloadData(string url)
    //{
    //    WebClient client = new WebClient();
    //    //client.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
    //    //client.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);

    //    string str = client.DownloadString(url);
    //}


    public void DownloadData(string url)
    {
        WebClient client = new WebClient();

        var dotd = client.DownloadString(url);
        DataContractJsonSerializer sdotd = new DataContractJsonSerializer(typeof(ProductsFeedData));

        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(dotd)))
        {
            // deserialize the JSON object using the WeatherData type.//Repeater1.DataSource = weatherData.dotdList;//Repeater1.DataBind();
            var itemDotd = (ProductsFeedData)sdotd.ReadObject(ms);
            int itemNo = 0;
            foreach (clsOMGProductFeed item in itemDotd.GetProductsResult)
            {

                //this.Title = item.title;
                //this.Description = item.description;
                //this.NavigationURL = item.url;
                //this.Availability = item.availability;
                //this.Ad_Type = Constants.APITypeURL.FlipKart_DOTD_OffersAPI;
                ////this.Ad_For =Convert.ToInt16(MID);
                //this.MID = Convert.ToInt16(MID);
                //this.ImageUrl = item.imageUrls[0].url;
                //itemNo = itemNo + 1;
                //this.SerialNo = itemNo;
                //CreateProduct(sender, e);

            }
        }

    }
   

    public static XmlDocument getXMLDocumentFromXMLTemplate(string inURL)
    {
        HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
        HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
        XmlDocument myXMLDocument = null;           //Declare XMLResponse document
        XmlTextReader myXMLReader = null;           //Declare XMLReader

        try
        {
            //Create Request
            myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(inURL);
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

            //Get Response
            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            //Now load the XML Document
            myXMLDocument = new XmlDocument();

            //Load response stream into XMLReader
            myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());
            myXMLDocument.Load(myXMLReader);

            XmlReader xmlReader = new XmlNodeReader(myXMLDocument);
            DataSet ds = new DataSet();
            ds.ReadXml(xmlReader);
        }
        catch (Exception myException)
        {
            throw new Exception("Error Occurred in AuditAdapter.getXMLDocumentFromXMLTemplate()", myException);
        }
        finally
        {
            myHttpWebRequest = null;
            myHttpWebResponse = null;
            myXMLReader = null;
        }
        return myXMLDocument;
    }
}