using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;


/// <summary>
/// Summary description for BindingControl
/// </summary>
public class BindingControl
{
    
	public BindingControl()
	{

		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Get All SubCategory Based On selection
    /// </summary>
    /// <param name="catID"></param>
    /// <returns></returns>
    public static List<KeyValuePair<int, string>> BindSubCategory(int categoryID)
    {
        ModelSubCategory _subCategory = new ModelSubCategory();
        return _subCategory.GetSubCategoriesList(categoryID);
    }

    public static List<KeyValuePair<int, string>> BindCategories()
    {
        ModelCategory _category = new ModelCategory();
        return _category.GetCategoriesList();
        
    }


    /// <summary>
    /// Dynamic Enum Bind in control
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ddl"></param>
    public static void BindEnumDropDown<T>(DropDownList ddl)
    {        
        string[] enumNames = Enum.GetNames(typeof(T));
        foreach (string item in enumNames)
        {
            //get the enum item value
            int value = (int)Enum.Parse(typeof(T), item);
            ListItem listItem = new ListItem(item, value.ToString());
            ddl.Items.Add(listItem);
        }        
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("[ Select ]", "0"));
    }

    //public static Dictionary<int, string> GetDictionaryFromEnum<T>()
    //{

    //    string[] names = Enum.GetNames(typeof(T));

    //    Array keysTemp = Enum.GetValues(typeof(T));
    //    dynamic keys = keysTemp.Cast<int>();

    //    dynamic dictionary = keys.Zip(names, (k, v) => new
    //    {
    //        Key = k,
    //        Value = v
    //    }).ToDictionary(x => x.Key, x => x.Value);

    //    return dictionary;
    //}
}