using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel:IProductModel
{
    clsCommonMethods client;
    public ProductModel()
	{
        client = new clsCommonMethods();
	}

    public List<vw_Product> GetAllProducts()
    {
        List<vw_Product> items = client.GetAll_VW_Products().ToList();
        return items;
    }

    public Product_Common GetOneCommonProduct()
    {
        throw new NotImplementedException();
    }

    public void DBOperation(Constants.Action command, Product_Common item = null, List<long> ids=null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertCommonProduct(item);
                break;
            case Constants.Action.Delete:
                client.DeleteCommonProduct(ids);
                break;
            default:
                break;
        }
    }


    public List<vw_Product> GetAll_Proc_Product(int pageIndex, int pageSize, out int totalRecord)
    {
        List<vw_Product> items = client.GetAll_Proc_Product(pageIndex, pageSize,out totalRecord).ToList();
        return items;
    }
}