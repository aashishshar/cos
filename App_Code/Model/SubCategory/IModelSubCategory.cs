using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IModelSubCategory
/// </summary>
public interface IModelSubCategory
{
    List<KeyValuePair<int, string>> GetSubCategoriesList(int categoryID);
    Sub_Category GetSubCategory(int Id);
    void DBOperation(string command, Sub_Category subCat = null, int id = 0);
}