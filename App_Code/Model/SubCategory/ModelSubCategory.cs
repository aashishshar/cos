using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using QuestionServiceWebReference;
//

/// <summary>
/// Summary description for ModelSubCategory
/// </summary>
public class ModelSubCategory : IModelSubCategory
{
     clsCommonMethods client;
     public ModelSubCategory()
    {
        client = new clsCommonMethods();
    }


     #region IModelSubCategory Members

     public List<KeyValuePair<int, string>> GetSubCategoriesList(int categoryID)
     {
         List<KeyValuePair<int, string>> LstKeyValues = new List<KeyValuePair<int, string>>();
        
         List<Sub_Category> lstcust = client.GetAllSubCategoriesByID(categoryID).ToList();
         foreach (Sub_Category q in lstcust)
         {
             KeyValuePair<int, string> kvp = new KeyValuePair<int, string>(q.SubCategoryID_N, q.SubCategoryName_V);
             LstKeyValues.Add(kvp);
         }
         return LstKeyValues;
     }

     public List<Sub_Category> GetAllSubCategories()
     {
         List<Sub_Category> subCats = new List<Sub_Category>();
        
         subCats = client.GetAllSubCategories().ToList();
         return subCats;
     }
     public List<Sub_Category> GetActiveSubCategories()
     {
         List<Sub_Category> subCats = new List<Sub_Category>();
     
         subCats = client.GetAllSubCategories().Where(p => p.Status_N.Equals(Constants.Status.Active)).ToList();
         return subCats;
     }

     public Sub_Category GetSubCategory(int Id)
     {
         throw new NotImplementedException();
     }

     public void DBOperation(string command, Sub_Category subCat = null, int id = 0)
     {
        
         switch (command)
         {
             case "Insert":
                 client.InsertSubCategory(subCat);
                 break;
             case "Delete":
                 client.DeleteSubCategory(id);
                 break;
             case "Update":
                // client.UpdateSubCategory(subCat);
                 break;
             default:
                 break;
         }
     }

     #endregion
}