using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Data;

public partial class XMLToLinq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            XElement xele = XElement.Load("D://VoucherCodes-2015-03-10.xml");
            dt = XElementToDataTable(xele);
        }
    }
    #region
    public void XMLToLinqC()
    {
       // var xmlDoc = new XmlDocument();
       // xmlDoc.Load("D://Shared/SnapDeal Affiliate/topFashion.xml");
       // var itemNodes = xmlDoc.SelectNodes("entry");
       // foreach (XmlNode node in itemNodes)
       // {
       //     var location = node.SelectNodes("entry");
       //     foreach (XmlNode loc in location)
       //     {
       //         var server = loc.SelectSingleNode("id").InnerText;
       //         //var drive = loc.SelectSingleNode("drive").InnerText;
       //         //var folder = loc.SelectSingleNode("folder").InnerText;
       //         //var filename = loc.SelectSingleNode("filename").InnerText;
       //     }
       // }
       //// XDocument cpo = XDocument.Load("D://Shared/SnapDeal Affiliate/topElectronics.xml");
       //// XNamespace aw = "http://www.adventure-works.com";
       // XElement newTree = new XElement("entry",
       //     from el in cpo.Root.Elements()
           
       //     select el
        // );.Elements(ns + "Parent").Elements().Where(w => w.Value == "John")
        string name = string.Empty;
        XElement po = XElement.Load("D://Shared/VoucherCodes-2015-03-10.xml");
        //XElement po = XElement.Load("https://affiliate-api.flipkart.net/affiliate/api/aashishsh.xml");
        //var ns = doc..GetDefaultNamespace();
        //IEnumerable<XElement> elements = doc.Elements("feed").Elements("entry");
        //foreach (XElement element in elements)
        //{
        //    name = name + element.Value;// "Wayne";
        //}
        //IEnumerable<XElement> childElements1 = po.Elements("feed").Elements("entry");
        IEnumerable<XElement> childElements =
            from el in po.Elements().Elements()
            select el;
        DataTable dt = new DataTable();

        foreach (XElement el in childElements)
        {
            //el.FirstNode.Parent.Name;
            //dt.Columns.Add(el.Name.ToString());
            //name = name + el.Name + ": " + el.Value;
        }
        XElement xele = XElement.Load("D://Shared/VoucherCodes-2015-03-10.xml");//get your file
        // declare a new DataTable and pass your XElement to it
       
    }
    #endregion
    public DataTable XElementToDataTable(XElement x)
    {
        DataTable dtable = new DataTable();

        XElement setup = (from p in x.Descendants() select p).First();
        // build your DataTable
        foreach (XElement xe in setup.Descendants())
            dtable.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string))); // add columns to your dt

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
}