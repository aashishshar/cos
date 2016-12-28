using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_Coupons : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(100, "...");
    }

    public List<Merchant_Coupon> Coupons
    {
        set
        {
            dlItems.DataSource = value;
            dlItems.DataBind();
        }
    }
}