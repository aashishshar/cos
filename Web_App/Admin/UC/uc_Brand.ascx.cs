using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;

public partial class Admin_UC_uc_Brand : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // BindBrand();
        }
    }

    private void BindBrand()
    {
        gvItems.DataSource = clsAddItems.GetAllBrandByCategoryID(Convert.ToInt32(UC_CategoryList.SelectedValue));
        gvItems.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Tbl_Brand item = new Tbl_Brand();
        item.BrandName = txtBrandName.Text.Trim();
        item.CategoryID = Convert.ToInt32(UC_CategoryList.SelectedValue.ToString());
        item.ISRun = false;
        clsAddItems.AddBrandName(item);
        BindBrand();
        //txtBrandName.Text
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {        
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                clsAddItems.AddBrandName(true,offerID);
            }
           
        }

        BindBrand();
    }
    protected void btnDeactive_Click(object sender, EventArgs e)
    {
       foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                clsAddItems.AddBrandName(false,offerID);
            }
           
        }
       BindBrand();
    }
    protected void imgDelete_Click(object sender, ImageClickEventArgs e)
    {
        List<int> offerIds = new List<int>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                offerIds.Add(offerID);
            }
        }

        if (offerIds.Count > 0)
        {
            clsAddItems.AddBrandName(offerIds);
            BindBrand();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        List<Tbl_Brand> brands = new List<Tbl_Brand>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            Tbl_Brand brand = new Tbl_Brand();
            TextBox txtMinPrice = (TextBox)row.FindControl("txtMinPrice");
            TextBox txtMaxPrice = (TextBox)row.FindControl("txtMaxPrice");
            TextBox txtRangePrice = (TextBox)row.FindControl("txtRangePrice");
            if (!string.IsNullOrEmpty(txtMinPrice.Text))
                brand.MinPrice = Convert.ToInt32(txtMinPrice.Text);

            if (!string.IsNullOrEmpty(txtMaxPrice.Text))
                brand.MaxPrice = Convert.ToInt32(txtMaxPrice.Text);

            if (!string.IsNullOrEmpty(txtRangePrice.Text))
                brand.RangePrice = Convert.ToInt32(txtRangePrice.Text);

            int brandID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
            brand.BrandID = brandID;
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {
               // brand.ISRun = true;
            }
            else
            {
              //  brand.ISRun = false;
            }
            brands.Add(brand);

        }

        if (brands.Count > 0)
        {
            clsAddItems.AddBrandName(brands);
            BindBrand();
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindBrand();
    }
}