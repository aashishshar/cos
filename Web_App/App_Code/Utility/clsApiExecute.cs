using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;
using System.Data;

/// <summary>
/// Summary description for clsApiExecute
/// </summary>
public static class clsApiExecute
{
	


    public static DataTable DownloadXMLData(Constants.APITypeURL type)//, object sender, EventArgs e)
    {
        //WebClient client = new WebClient();
        //client.Headers.Add("Fk-Affiliate-Id", Constants.FlipKart_AffiliateId);
        //client.Headers.Add("Fk-Affiliate-Token", Constants.FlipKart_AffiliateToken);
      
        XElement xele;
        DataTable dt = new DataTable();
        //switch (type)
        //{
        //    case Constants.APITypeURL.AmericanSwanCPA:
        //        xele = XElement.Load(Constants.AmericanSwanCPA);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    case Constants.APITypeURL.JabongcomSales:
        //        xele = XElement.Load(Constants.JabongcomSales);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    case Constants.APITypeURL.KoovscomCostPerSale:
        //        xele = XElement.Load(Constants.KoovscomCostPerSale);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    case Constants.APITypeURL.MyntracomSaleExistingUser:
        //        xele = XElement.Load(Constants.MyntracomSaleExistingUser);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    case Constants.APITypeURL.PaytmPaytmnonrecharge:
        //        xele = XElement.Load(Constants.PaytmPaytmnonrecharge);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    case Constants.APITypeURL.TrendincomCostPerSale:
        //        xele = XElement.Load(Constants.TrendincomCostPerSale);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    case Constants.APITypeURL.ZoviComSale:
        //        xele = XElement.Load(Constants.ZoviComSale);
        //        dt = clsFileToTable.XElementToDataTable(xele);
        //        break;
        //    default:
        //        break;
        //}

        return dt;
    }
}