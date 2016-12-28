using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_Offers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public List<Merchant_Offer> Offers
    {
        set
        {
            rpItems.DataSource = value;
            rpItems.DataBind();
        }
    }

   
}