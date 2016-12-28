using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_Deals : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(25, "...");
    }

    public List<vw_Product> Deals
    {
        set
        {
            dlItems.DataSource = value;
            dlItems.DataBind();
        }
    }
}