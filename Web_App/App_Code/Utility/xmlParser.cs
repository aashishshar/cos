using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.IO;

using EntityData;

/// <summary>
/// Summary description for xmlParser
/// </summary>
public class xmlParser
{
    public xmlParser()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static DataTable XElementToDataTableForCategory(XElement x)
    {
        DataTable dtable = new DataTable();

        XElement setup = (from p in x.Descendants() select p).First();
        // build your DataTable
        foreach (XElement xe in setup.Descendants())
        {
            if (!dtable.Columns.Contains(xe.Name.ToString()))
            {
                dtable.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string))); // add columns to your dt
            }
        }

        var all = from p in x.Descendants(setup.Name.ToString()) select p;
        foreach (XElement xe in all)
        {
            DataRow dr = dtable.NewRow();
            foreach (XElement xe2 in xe.Descendants())
                dr[xe2.Name.ToString()] = xe2.Value; //add in the values
            dtable.Rows.Add(dr);
        }
        return dtable;
    }


    public static List<Tbl_Item> FlipkartMasterXElementToDataTable(string element, out string nextURL)
    {
        string urlNext=string.Empty;
        DataSet ds1 = new DataSet();
        ds1.ReadXml(new StringReader(element.ToString()));
        if (ds1.Tables["ProductFeed"].Columns.Contains("NextURL"))
        {

            var NextURL = (from t1 in ds1.Tables["ProductFeed"].AsEnumerable()
                           select new
                           {
                               NxtURL = t1.Field<string>("NextURL")
                           }).FirstOrDefault();

            if (NextURL != null)
            {
                urlNext = NextURL.NxtURL.ToString();
            }
            else
            {
                urlNext = "";
            }
        }

        var row = from t1 in ds1.Tables["ImageURLs"].AsEnumerable()
                  let id = t1.Field<Int32>("ImageURLs_ID")
                  join t2 in ds1.Tables["Entry"].AsEnumerable()
                                     on id equals t2.Field<Int32>("ImageURLs_ID")
                  where t2.Field<string>("key") == "75x75"
                  select new
                  {
                      ProductAttributes_ID = t1.Field<Int32>("ProductAttributes_ID"),
                      ImgageURL = t2.Field<string>("Value")
                  };
        //var i=from dr in row.AsEnumerable()
        //      select dr.
        string str = ds1.Tables["MaximumRetailPrice"].Columns["Amount"].DataType.ToString();
        string str1 = ds1.Tables["SellingPrice"].Columns["Amount"].DataType.ToString();

        var product = from p in ds1.Tables["ProductAttributes"].AsEnumerable()
                      let AID = p.Field<Int32>("ProductAttributes_ID")
                      join mrp in ds1.Tables["MaximumRetailPrice"].AsEnumerable()
                      on AID equals mrp.Field<Int32>("ProductAttributes_ID")
                      join sp in ds1.Tables["SellingPrice"].AsEnumerable()
                      on AID equals sp.Field<Int32>("ProductAttributes_ID")
                      join dr in row.AsEnumerable()
                      on AID equals dr.ProductAttributes_ID
                      select new Tbl_Item
                      {
                          ////id = AID,
                          //CodAvailable = p.Field<string>("CodAvailable"),
                          //color = p.Field<string>("color"),
                          //discountPercentage = p.Field<string>("discountPercentage"),
                          ////EmiAvailable = p.Field<string>("EmiAvailable"),
                          ////ProductAttributes_ID = p.Field<Int32>("ProductAttributes_ID"), 
                          ////instock = p.Field<string>("instock"),
                          //// ProductBrand = p.Field<string>("ProductBrand"),
                          //ProductDescription = p.Field<string>("ProductDescription"),
                          //producturl = p.Field<string>("producturl"),
                          ////sizevariants =  p.Field<string>("sizevariants"), 
                          //title = p.Field<string>("title"),
                          ////productbaseinfo_id =  p.Field<string>("productbaseinfo_id"), 
                          //ImageURL = dr.ImgageURL,//, 
                          //Price = mrp.Field<string>("Amount"),
                          //SelleingPrice = sp.Field<string>("Amount")

                          ItenName = p.Field<string>("title"),
                          ItemBrand = p.Field<string>("ProductBrand") != null ? p.Field<string>("ProductBrand") : ""
                      };

        //GridView2.DataSource = product.ToList();
        //GridView2.DataBind();
        nextURL=urlNext;
        return product.ToList();
    }


    public static List<Tbl_ItemsDetail> FlipkartProductDetailsXElementToDataTable(string element, out string nextURL)
    {
        string urlNext = string.Empty;
        DataSet ds1 = new DataSet();
        ds1.ReadXml(new StringReader(element.ToString()));
        if (ds1.Tables["ProductFeed"].Columns.Contains("NextURL"))
        {

            var NextURL = (from t1 in ds1.Tables["ProductFeed"].AsEnumerable()
                           select new
                           {
                               NxtURL = t1.Field<string>("NextURL")
                           }).FirstOrDefault();

            if (NextURL != null)
            {
                urlNext = NextURL.NxtURL.ToString();
            }
            else
            {
                urlNext = "";
            }
        }

        var row = from t1 in ds1.Tables["ImageURLs"].AsEnumerable()
                  let id = t1.Field<Int32>("ImageURLs_ID")
                  join t2 in ds1.Tables["Entry"].AsEnumerable()
                                     on id equals t2.Field<Int32>("ImageURLs_ID")
                  where t2.Field<string>("key") == "75x75"
                  select new
                  {
                      ProductAttributes_ID = t1.Field<Int32>("ProductAttributes_ID"),
                      ImgageURL = t2.Field<string>("Value")
                  };
        //var i=from dr in row.AsEnumerable()
        //      select dr.
        string str = ds1.Tables["MaximumRetailPrice"].Columns["Amount"].DataType.ToString();
        string str1 = ds1.Tables["SellingPrice"].Columns["Amount"].DataType.ToString();

        var product = from p in ds1.Tables["ProductAttributes"].AsEnumerable()
                      let AID = p.Field<Int32>("ProductAttributes_ID")
                      join mrp in ds1.Tables["MaximumRetailPrice"].AsEnumerable()
                      on AID equals mrp.Field<Int32>("ProductAttributes_ID")
                      join sp in ds1.Tables["SellingPrice"].AsEnumerable()
                      on AID equals sp.Field<Int32>("ProductAttributes_ID")
                      //join dr in row.AsEnumerable()
                     // on AID equals dr.ProductAttributes_ID
                      select new Tbl_ItemsDetail
                      {                          
                          Flipkart = Convert.ToSingle(mrp.Field<string>("Amount")),                         
                          Title = p.Field<string>("title")
                      };

        //GridView2.DataSource = product.ToList();
        //GridView2.DataBind();
        nextURL = urlNext;
        return product.ToList();
    }


}