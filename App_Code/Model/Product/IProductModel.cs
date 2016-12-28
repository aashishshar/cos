using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IProductModel
/// </summary>

/// <summary>
/// Summary description for IUserGroup
/// </summary>
public interface IProductModel
{
    List<vw_Product> GetAllProducts();
    Product_Common GetOneCommonProduct();
    List<vw_Product> GetAll_Proc_Product(int pageIndex, int pageSize, out int totalRecord);
    
    void DBOperation(Constants.Action command, Product_Common group = null,List<Int64> ids = null);
}

