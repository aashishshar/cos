using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_SmallWindow_uc_BreakDownCommsion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public List<Merchant_BreakDown> BindBreakDown
    {
        set
        {
            rptItem.DataSource = value;//( from p in value
                                // select p.Merchant_BreakDowns).ToList();
            rptItem.DataBind();
            //if(rptItem
        }
    }
}