using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.IO;

/// <summary>
/// Summary description for clsFileToTable
/// </summary>
public static class  clsFileToTable
{

    public static DataTable XElementToDataTable1(XElement x)
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
            //else
            //{
            //    if (!dtable.Columns.Contains(xe.Name.ToString()))
            //    {
            //        dtable.Columns.Add(new DataColumn("Sub_" + xe.Name.ToString(), typeof(string))); // add columns to your dt
            //    }
            //    else
            //    {
            //        dtable.Columns.Add(new DataColumn("Sub2_" + xe.Name.ToString(), typeof(string))); // add columns to your dt
            //    }
            //}
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
    public static DataTable XElementToDataTable(XElement element)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(new StringReader(element.ToString()));
        return ds.Tables[0];
    }

    public static DataSet XElementToDataset(XElement element)
    {

        DataSet ds = new DataSet();
        ds.ReadXml(new StringReader(element.ToString()));
        return ds;
    }
}