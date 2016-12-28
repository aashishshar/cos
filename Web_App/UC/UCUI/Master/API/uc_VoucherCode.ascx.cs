using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UC_UCUI_Master_API_uc_VoucherCode : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public DataTable DataTableXML
    {
        set
        {
            XMLDataTable = value;
            if (XMLDataTable.Rows.Count > 0)
            {
                BindXMLData("");
            }
        }
    }

    private DataTable XMLDataTable
    {
        get
        {
            Object s = ViewState["XMLDataTable"];

            return ((s == null) ? null : (DataTable)s);
        }

        set
        {
            ViewState["XMLDataTable"] = value;
        }
    }

    public void BindHeader(DataTable dt, string filter)
    {
        DropDownList ddlHeader =
         (DropDownList)gvXMLDate.HeaderRow.FindControl("ddlHeader");
        string[] TobeDistinct = { "Merchant" };
        DataTable dtDistinct = GetDistinctRecords(dt, TobeDistinct);
        ddlHeader.DataSource = dtDistinct;
        ddlHeader.DataTextField = "Merchant";
        ddlHeader.DataValueField = "Merchant";
        ddlHeader.DataBind();
        ddlHeader.Items.Insert(0, new ListItem("All", "All"));
        if (filter != string.Empty)
            ddlHeader.SelectedValue = filter;
    }
    public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
    {
        DataTable dtUniqRecords = new DataTable();
        dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
        return dtUniqRecords;
    }

    protected void ddlHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlHeader = (DropDownList)sender;
        BindXMLData(ddlHeader.SelectedItem.Value);
    }

    private void BindXMLData(string filter)
    {


        if (filter != string.Empty && filter != "All")
        {
            EnumerableRowCollection<DataRow> query = from order in XMLDataTable.AsEnumerable()
                                                     where order.Field<string>("Merchant") == filter
                                                     select order;

            DataView view = query.AsDataView();
            gvXMLDate.DataSource = view;
            gvXMLDate.DataBind();
            BindHeader(XMLDataTable, filter);
        }
        else
        {
            gvXMLDate.DataSource = XMLDataTable;
            gvXMLDate.DataBind();
            BindHeader(XMLDataTable, string.Empty);
        }

    }
}