using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
//using QuestionServiceWebReference;

public class ModelCategory:IModelCategory
{
    #region IModelCategory Members

    clsCommonMethods client;
    public ModelCategory()
    {
        client = new clsCommonMethods();
    }


    public List<KeyValuePair<int, string>> GetCategoriesList()
    {
        List<KeyValuePair<int, string>> LstKeyValues = new List<KeyValuePair<int, string>>();        
        List<Category> lstcust = client.GetAllCategories().ToList();
        foreach (Category q in lstcust)
        {
            KeyValuePair<int, string> kvp = new KeyValuePair<int, string>(q.CategoryID_N, q.CategoryName_V);
            LstKeyValues.Add(kvp);
        }
        return LstKeyValues;

    }

    public List<Category> GetAllCategories()
    {        
        List<Category> lstcust = client.GetAllCategories().ToList();
        return lstcust;
    }

    public List<Category> GetAllActiveCategories()
    {
        List<Category> lstcust = GetAllCategories().Where(p => p.Status_N.Equals(Constants.Status.Active)).ToList();
        return lstcust;
    }

    public Category GetCategory(int Id)
    {
        Category q = new Category();        
        q = client.GetCategoryByID(Id);
        return q;
    }

    public void DBOperation(string command, Category cat = null, int id = 0)
    {        
        switch (command)
        {
            case "Insert":
                client.InsertCategory(cat);
                break;
            case "Delete":
                client.DeleteCategory(id);
                break;
            case "Update":
                //client.UpdateCategory(cat);
                break;
            default:
                break;
        }
    }

    #endregion
}