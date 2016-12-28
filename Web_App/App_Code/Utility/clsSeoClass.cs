using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for clsSeoClass
/// </summary>
public class clsSeoClass
{
	public clsSeoClass()
	{
		//
		// TODO: Add constructor logic here
		//et
	}

    public static clsSeoDetail GetSEODetails(DataTable dataTable, string categoryName)
    {
        string columnName;
        if (dataTable.Columns.Contains("CategoryName_V"))
        {
            columnName = "CategoryName_V";
        }
        else if (dataTable.Columns.Contains("BrandName"))
        {
            columnName = "BrandName";
        }
        else
        {
            return null;
        }
        var seo = (from s in dataTable.AsEnumerable()
                   where s.Field<string>(columnName).ToLower() == categoryName.ToLower()
                  select new clsSeoDetail
                  {
                      SeoTitle = s.Field<string>("Seo_Title"),
                      SeoDescription = s.Field<string>("Seo_Description"),
                      SeoKeyword = s.Field<string>("Seo_Keyword")
                  }).FirstOrDefault();

        if (seo == null)
        {
            clsSeoDetail obj = new clsSeoDetail();

            obj.SeoTitle = Constants.SEO_Title;
            obj.SeoDescription = Constants.SEO_Description;
            obj.SeoKeyword = Constants.SEO_Keyword;
            return obj;
        }
        else
        {
            return seo;
        }
    }


}

public class clsSeoDetail
{
    public string SeoTitle { get; set; }
    public string SeoDescription { get; set; }
    public string SeoKeyword { get; set; }
        
}