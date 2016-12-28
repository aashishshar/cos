using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for ISubCategoryList
/// </summary>
public interface IMasterSubCategoryListView:IView
{
   
    void populateSubCategories(List<KeyValuePair<int, string>> items);
    //void List<>
    bool postback { get; set; }
    int CategoryID { get; set; }
   

    List<Sub_Category> SubCategories { get; set; }


  
}