using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityData;
using System.Data.Objects.DataClasses;

/// <summary>
/// Summary description for clsAssignDataCollection
/// </summary>
public class clsAssignDataCollection
{
    clsCommonMethods obj;
    public clsAssignDataCollection()
    {
        obj = new clsCommonMethods();
    }

    public List<vw_Product> GetViewProductCommon(List<vw_OfferItem> _items)
    {
        EntityCollection<vw_OfferItem> entityCollection = _items.ToEntityCollection();       
        return obj.DTO_ProductsVW(entityCollection);
    }
}