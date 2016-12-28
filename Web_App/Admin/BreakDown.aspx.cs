using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BreakDown : AdminBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            //gvItems.DataSourceID = "EntityDataSource1";
            //gvItems.DataBind();
            if (gvItems.Rows.Count > 0)
            {
                gvItems.UseAccessibleHeader = true;
                gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
            }
       
    }
}