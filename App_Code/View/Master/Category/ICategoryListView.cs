using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for ICategoryListView
/// </summary>
public interface ICategoryListView : IView
{
    void populateCategories(List<KeyValuePair<int, string>> items);
    bool postback { get; set; }
    string SelectedValueDDL { get; set; }
    Category ShowCategory { get; set; }
    List<Sub_Category> SubCategories { get; set; }
   
    event EventHandler SelectionChangedCategory;
    event EventHandler refreshCategories;
}