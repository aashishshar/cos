using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UC_UCUI_Master_SubCategory_UC_SubCategory : System.Web.UI.UserControl,IMasterSubCategoryListView
{
    private SubCategoryListPresenter _presenter;        

    public UC_UCUI_Master_SubCategory_UC_SubCategory()
    {
        this._presenter = new SubCategoryListPresenter(this);       
    }

    protected void Page_Load(object sender, EventArgs e)
    {       
    }
    #region  Members

    public void populateSubCategories(List<KeyValuePair<int, string>> items)
    {
        ddlSubCategory.DataSource = items.ToArray();
        ddlSubCategory.DataBind();
        ddlSubCategory.Items.Insert(0, new ListItem("[ Sub Category ]","0"));
    }    

    public string SelectedValue
    {
        get
        {
            return ddlSubCategory.SelectedValue.ToString();
        }     

    }

    public bool postback { get; set; }

    public int CategoryID { get; set; }

    public bool IsValid
    {
        get { return true; }
    }
    public List<Sub_Category> SubCategories { get; set; }

   

    #endregion

   

    
}