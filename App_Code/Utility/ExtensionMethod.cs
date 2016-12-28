using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;
using System.Data.Objects.DataClasses;

/// <summary>
/// Summary description for ExtensionMethod
/// </summary>
public static class ExtensionMethod
{
    //public static EntityCollection<T> ToEntityCollection<T>(this List<T> list) where T : class
    //{
    //    EntityCollection<T> entityCollection = new EntityCollection<T>();
    //    list.ForEach(entityCollection.Add);
    //    return entityCollection;
    //}
    public static DataTable AsDataTable<T>(this IEnumerable<T> list)
    where T : class
    {
        DataTable dtOutput = new DataTable("tblOutput");

        //if the list is empty, return empty data table
        if (list.Count() == 0)
            return dtOutput;

        //get the list of  public properties and add them as columns to the
        //output table           
        PropertyInfo[] properties = list.FirstOrDefault().GetType().
            GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo propertyInfo in properties)
            dtOutput.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);

        //populate rows
        DataRow dr;
        //iterate through all the objects in the list and add them
        //as rows to the table
        foreach (T t in list)
        {
            dr = dtOutput.NewRow();
            //iterate through all the properties of the current object
            //and set their values to data row
            foreach (PropertyInfo propertyInfo in properties)
            {
                dr[propertyInfo.Name] = propertyInfo.GetValue(t, null);
            }
            dtOutput.Rows.Add(dr);
        }
        return dtOutput;
    }

	
}

//public static T ToEnum<T>(this string value, T defaultValue) 
//{
//    if (string.IsNullOrEmpty(value))
//    {
//        return defaultValue;
//    }

//    T result;
//    return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
//}

public static class StringExtensions
{
    /// <summary>
    /// Returns the given string truncated to the specified length, suffixed with an elipses (...)
    /// </summary>
    /// <param name="input"></param>
    /// <param name="length">Maximum length of return string</param>
    /// <returns></returns>
    public static string Truncate(this string input, int length)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return input.Length <= length ? input : input.Substring(0, length);
        //return Truncate(input, length, "...");
    }

    /// <summary>
    /// Returns the given string truncated to the specified length, suffixed with the given value
    /// </summary>
    /// <param name="input"></param>
    /// <param name="length">Maximum length of return string</param>
    /// <param name="suffix">The value to suffix the return value with (if truncation is performed)</param>
    /// <returns></returns>
    public static string Truncate(this string input, int length, string suffix)
    {
        if (input == null) return "";
        if (input.Length <= length) return input;

        if (suffix == null) suffix = "...";

        return input.Substring(0, length - suffix.Length) + suffix;
    }
    /// <summary>
    /// Returns the given string truncated to the specified length, suffixed with an elipses (...)
    /// </summary>
    /// <param name="input"></param>
    /// <param name="length">Maximum length of return string</param>
    /// <returns></returns>
    //public static string Truncate(this string input, int length)
    //{
    //    return Truncate(input, length);
    //}

    /// <summary>
    /// Returns the given string truncated to the specified length, suffixed with an elipses (...)
    /// </summary>
    /// <param name="input"></param>
    /// <param name="length">Maximum length of return string</param>
    /// <returns></returns>
    //public static string Truncate(string input, Int16 maxLength)
    //{
    //    return TruncateString(input, maxLength);
    //}

    /// <summary>
    /// Returns the given string truncated to the specified length, suffixed with the given value
    /// </summary>
    /// <param name="input"></param>
    /// <param name="length">Maximum length of return string</param>
    /// <param name="suffix">The value to suffix the return value with (if truncation is performed)</param>
    /// <returns></returns>
    //public static string TruncateSuffix(this string input, int length, string suffix)
    //{
    //    if (input == null) return "";
    //    if (input.Length <= length) return input;

    //    if (suffix == null) suffix = "...";

    //    return input.Substring(0, length - suffix.Length) + suffix;
    //}


    /// <summary>
    /// Returns the given string truncated to the specified length, suffixed with the given value
    /// </summary>
    /// <param name="input"></param>
    /// <param name="length">Maximum length of return string</param>    
    /// <returns></returns>  
    //public static string Truncate(this string value, Int16 maxLength)
    //{
    //    if (string.IsNullOrEmpty(value)) return value;
    //    return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    //}

    /// <summary>
    /// Splits a given string into an array based on character line breaks
    /// </summary>
    /// <param name="input"></param>
    /// <returns>String array, each containing one line</returns>
    public static string[] ToLineArray(this string input)
    {
        if (input == null) return new string[] { };
        return System.Text.RegularExpressions.Regex.Split(input, "\r\n");
    }

    /// <summary>
    /// Splits a given string into a strongly-typed list based on character line breaks
    /// </summary>
    /// <param name="input"></param>
    /// <returns>Strongly-typed string list, each containing one line</returns>
    public static List<string> ToLineList(this string input)
    {
        List<string> output = new List<string>();
        output.AddRange(input.ToLineArray());
        return output;
    }

    /// <summary>
    /// Replaces line breaks with self-closing HTML 'br' tags
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ReplaceBreaksWithBR(this string input)
    {
        return string.Join("<br/>", input.ToLineArray());
    }

    /// <summary>
    /// Replaces any single apostrophes with two of the same
    /// </summary>
    /// <param name="input"></param>
    /// <returns>String</returns>
    public static string DoubleApostrophes(this string input)
    {
        return Regex.Replace(input, "'", "''");
    }

    /// <summary>
    /// Encodes the input string as HTML (converts special characters to entities)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>HTML-encoded string</returns>
    public static string ToHTMLEncoded(this string input)
    {
        return HttpContext.Current.Server.HtmlEncode(input);
    }

    /// <summary>
    /// Encodes the input string as a URL (converts special characters to % codes)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>URL-encoded string</returns>
    public static string ToURLEncoded(this string input)
    {
        return HttpContext.Current.Server.UrlEncode(input);
    }

    /// <summary>
    /// Decodes any HTML entities in the input string
    /// </summary>
    /// <param name="input"></param>
    /// <returns>String</returns>
    public static string FromHTMLEncoded(this string input)
    {
        return HttpContext.Current.Server.HtmlDecode(input);
    }

    /// <summary>
    /// Decodes any URL codes (% codes) in the input string
    /// </summary>
    /// <param name="input"></param>
    /// <returns>String</returns>
    public static string FromURLEncoded(this string input)
    {
        return HttpContext.Current.Server.UrlDecode(input);
    }

    /// <summary>
    /// Removes any HTML tags from the input string
    /// </summary>
    /// <param name="input"></param>
    /// <returns>String</returns>
    public static string StripHTML(this string input)
    {
        return Regex.Replace(input, @"<(style|script)[^<>]*>.*?</\1>|</?[a-z][a-z0-9]*[^<>]*>|<!--.*?-->", "");
    }
}

public static class DateTimeExtensions { }