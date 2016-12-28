using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for ISubCategoryView
/// </summary>
public interface ISubCategoryView : IView
{
    List<Sub_Category> SubCategories { get; set; }
    int SubCategoryID_N { get; set; }
    int CategoryID_N { get; set; }
    string SubCategoryName_V { get; set; }
    string strMessage { get; set; }

    event EventHandler InsertCommand;
    event EventHandler UpdateCommand;
    event EventHandler DeleteCommand;
}