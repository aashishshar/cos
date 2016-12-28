using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using HtmlAgilityPack;
using EntityData;
using System.Data;
using System.Reflection;
using System.Data.Objects.DataClasses;

/// <summary>
/// Summary description for clsUtility
/// </summary>


public static class ExtensionMethods
{
    public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
    {
        var dataList = new List<TSource>();

        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
        var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                             select new
                             {
                                 Name = aProp.Name,
                                 Type = Nullable.GetUnderlyingType(aProp.PropertyType) ??
                         aProp.PropertyType
                             }).ToList();
        var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                 select new
                                 {
                                     Name = aHeader.ColumnName,
                                     Type = aHeader.DataType
                                 }).ToList();
        var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

        foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
        {
            var aTSource = new TSource();
            foreach (var aField in commonFields)
            {
                PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                var value = (dataRow[aField.Name] == DBNull.Value) ?
                null : dataRow[aField.Name]; //if database field is nullable
                propertyInfos.SetValue(aTSource, value, null);
            }
            dataList.Add(aTSource);
        }
        return dataList;
    }

    public static EntityCollection<T> ToEntityCollection<T>(this List<T> list) where T : class
    {
        EntityCollection<T> entityCollection = new EntityCollection<T>();
        list.ForEach(entityCollection.Add);
        return entityCollection;
    }
}

public class clsUtility
{
    public clsUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    

    public static String EncryptString(String plainText, String key)
    {
        try
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(key)));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
    {
        try
        {
            return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static RijndaelManaged GetRijndaelManaged(String secretKey)
    {
        try
        {
            var keyBytes = new byte[32];
            var ivBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 256,
                BlockSize = 128,
                Key = keyBytes,
                IV = ivBytes
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }


    public static string GetDeeplinkInHTMLString(string htmlString, string UID)
    {
        string newNavigateURL = string.Empty;
        if (!string.IsNullOrEmpty(UID))
        {
            string[] splitString = htmlString.Split('&');
            if (splitString.Count() > 1)
            {
                for (int i = 0; i < splitString.Count(); i++)
                {
                    if (i == splitString.Count() - 1)
                    {
                        newNavigateURL = newNavigateURL + "&UID=" + UID + "&" + splitString[i].ToString();
                    }
                    else if (i == 0)
                    {
                        newNavigateURL = splitString[i].ToString();
                    }
                    else
                    {
                        newNavigateURL = newNavigateURL + "&" + splitString[i].ToString();
                    }

                }

            }
        }
        else
        {
            return htmlString;
        }
        return newNavigateURL;
    }


    public static string GetDeeplinkInHTMLString(string htmlString)
    {
        string newNavigateURL = string.Empty;//affExtParam2=cos
        if (htmlString.Contains("clk.omgt") || htmlString.Contains("tracking.payoom.com") || htmlString.Contains("omgpm"))
        {

            string param = string.Empty;
            if (htmlString.Contains("clk.omgt5") || htmlString.Contains("track.in.omgpm"))
            {
                param = "&UID=cos";
            }
            else if (htmlString.Contains("tracking.payoom.com"))
            {
                param = "&aff_sub=cos";
            }

            string[] splitString = htmlString.Split('&');
            if (splitString.Count() > 1)
            {
                for (int i = 0; i < splitString.Count(); i++)
                {
                    if (i == splitString.Count() - 1)
                    {
                        newNavigateURL = newNavigateURL + param + "&" + splitString[i].ToString();
                    }
                    else if (i == 0)
                    {
                        newNavigateURL = splitString[i].ToString();
                    }
                    else
                    {
                        newNavigateURL = newNavigateURL + "&" + splitString[i].ToString();
                    }

                }

            }
        }
        else if (htmlString.Contains("dl.flipkart.com"))
        {
            newNavigateURL = htmlString + "&affExtParam1=" + "cos";
        }
        else if (htmlString.Contains("snapdeal"))
        {
            newNavigateURL = htmlString + "&aff_sub=" + "cos";
        }
        else
        {
            newNavigateURL = htmlString;
        }


        return newNavigateURL;
    }


    public static string AppendUIDinHrefURl(string strTagHTML)
    {
        string linkURL = string.Empty;
        var doc = new HtmlAgilityPack.HtmlDocument();
        string tableTag = strTagHTML;// "<th><a href=\"Boot_53.html\">135 Boot</a></th>";
        doc.LoadHtml(tableTag);

        var anchor = doc.DocumentNode.SelectSingleNode("//a");
        if (anchor != null)
        {
            string link = anchor.Attributes["href"].Value;
            linkURL = strTagHTML.Replace(link, GetDeeplinkInHTMLString(link.ToString()));
        }
        else
        {
            linkURL = strTagHTML;
        }
      
        return linkURL;
    }

    public static string GetTagStringInHtmlString(string strTagHTML,string tagFind)
    {
        string linkURL = string.Empty;
        var doc = new HtmlAgilityPack.HtmlDocument();
        string tableTag = strTagHTML;// "<th><a href=\"Boot_53.html\">135 Boot</a></th>";
        doc.LoadHtml(tableTag);

        var anchor = doc.DocumentNode.SelectSingleNode("//a");
        if (anchor != null)
        {
            linkURL = anchor.Attributes[tagFind].Value;
           // linkURL = strTagHTML.Replace(link, GetDeeplinkInHTMLString(link.ToString()));
        }      

        return linkURL;
    }

    public static string RemoveSpecialCharForURL(string strText)
    {
        string[] charList = { "&", ":", "?", "/", "'\'", "%", "." };

        foreach (string item in charList)
        {
            strText = strText.Replace(item, "");
        }
        return strText;
    }
}