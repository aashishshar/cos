using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Menu_uc_MerchantMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindApi();
        }
    }

    private void BindApi()
    {

        EnumControl.GetEnumDescriptions<Constants.NameOfMerchants>(blMenu);



    }
}