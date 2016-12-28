using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IProductEntryView
/// </summary>
public interface IProductEntryView:IView
{     
    string ProductCategoryName { get; set; }
    Constants.APITypeURL Ad_Type { get; set; }
    Constants.NameOfMerchants Ad_For { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    string Availability { get; set; }
    string ImageUrl { get; set; }
    string NavigationURL { get; set; }
    int SerialNo { get; set; }
    int CategoryID_N { get; set; }
    string strMessage {  set; }
    int MID { get; set; }

    List<Product_Common> ProductVW { get; set; }

    event EventHandler InsertCommand;
    event EventHandler DeleteCommand;
}


public interface IVW_Product : IView
{
    List<vw_Product> ProductVW { get; set; }

    List<Int64> Ids { get; set; }
    int pageIndex { get; set; }
    int pageSize { get; set; }
    int totalRecord { get; set; }

    event EventHandler RefreshCommand;
    event EventHandler PagingCommand;
    event EventHandler DeleteCommand;
}