using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Product_uc_ProductCommonItems : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public void ProductItemBind(List<vw_Product> ProductVW)
    {
        try
        {
            dlItems.DataSource = ProductVW;
            dlItems.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public string ReduceString(string obj)
    {
        if (obj != null)
        {
            return obj.Truncate(45, "...");
        }
        else
        {
            return "";
        }
    }

    public string ReduceString(string obj,int size)
    {
        if (obj != null)
        {
            return obj.Truncate(size, "...");
        }
        else
        {
            return "";
        }
    }
}