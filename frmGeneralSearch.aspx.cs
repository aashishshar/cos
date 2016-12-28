using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Collections.Specialized;
using EntityData;

public partial class frmGeneralSearch : BasePage
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            BindRecord(Convert.ToString(Session["S"]), 100);
        }
    }

    public void BindRecord(string searchby, int pageS)
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
            SqlCommand cmd = new SqlCommand("GetSearchFromMasterPage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageIndex", 1);
            cmd.Parameters.AddWithValue("@PageSize", pageS);
            cmd.Parameters.AddWithValue("@RecordCount", "");
            cmd.Parameters.AddWithValue("@Searchby", searchby);

            SqlDataAdapter daP = new SqlDataAdapter(cmd);
            DataTable dtProduct = new DataTable();
            daP.Fill(dtProduct);
            clsAssignDataCollection getVW_Item = new clsAssignDataCollection();

            uc_VwProduct1.ProductItemBind(getVW_Item.GetViewProductCommon(dtProduct.ToList<vw_OfferItem>()));
            //if (dtProduct.Rows.Count > 0)
            //    lnkLoadmoreRecords.Visible = true;
            //else
            //    lnkLoadmoreRecords.Visible = false;
            //ViewState["NoofProduct"] = dtProduct;
        }
        catch (Exception ex)
        { }
    }
}