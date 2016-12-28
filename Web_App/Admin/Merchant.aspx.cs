using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;

public partial class Admin_Merchant : AdminBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

    DataTable dt = new DataTable();
    protected void btnRunAPI_Click(object sender, EventArgs e)
    {
        XElement xele = XElement.Load(uc_ApiURLName.GetAPIUrl);
        //dt = clsFileToTable.XElementToDataset(xele);
       //uc_VoucherCode1.DataTableXML = dt;
       
    }


}