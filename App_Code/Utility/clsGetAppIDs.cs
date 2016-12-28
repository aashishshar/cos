using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsGetAppIDs
/// </summary>
public class clsGetAppIDs
{
	public clsGetAppIDs()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int GetCategoryIDByText(string category)
    {
        ModelCategory model = new ModelCategory();

        var cat = (from c in model.GetAllCategories()
                   where c.CategoryName_V.Contains(category)
                   select c.CategoryID_N).FirstOrDefault();
        if (cat != null)
        {
            return cat;
        }
        else
        {
            return 0;
        }
    }

    public static int GetMIDByOMGMID(string omgMID)
    {
        MerchantModel _model = new MerchantModel();
        Merchant p = _model.GetMerchantMID(Convert.ToInt32(omgMID));
        
        if (p.MID != 0)
            return Convert.ToInt32(p.MID);//ddlMercharList.Items.FindByText(searchText).Value);
        else
            return 0;        
    }
}