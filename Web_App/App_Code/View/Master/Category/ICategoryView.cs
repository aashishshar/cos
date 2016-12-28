using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for ICategoryView
/// </summary>
public interface ICategoryView:IView
{
    List<Category> Categories { get; set; }
    int CategoryID_N { get; set; }
    string CategoryName_V { get; set; }
    int? ParentCategoryID_N { get; set; }
   // string MCategoryName_V { get; set; }
      

    string strMessage { get; set; }

    event EventHandler InsertCommand;
    event EventHandler UpdateCommand;
    event EventHandler DeleteCommand;
	
}