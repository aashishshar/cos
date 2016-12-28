using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class UC_UCUI_Master_SubCategory_UC_SubCategoryEntry : System.Web.UI.UserControl, ISubCategoryView
{
    private MastersListPresenter _presenter;

    public event EventHandler InsertCommand;
    public event EventHandler UpdateCommand;
    public event EventHandler DeleteCommand;
    public UC_UCUI_Master_SubCategory_UC_SubCategoryEntry()
    {
        this._presenter = new MastersListPresenter(this, Constants.Master.SubCategory);       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindSubCategories();
        }
    }

    private void BindSubCategories()
    {
        gvSubCategories.DataSource = SubCategories;
        gvSubCategories.DataBind();
    }

   
    protected void btnSubmitSubcategory_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            lblMessage.Text = string.Empty;
            Insert(this, e);
            BindSubCategories();
            lblMessage.Text = strMessage;
        }
    }

    #region ISubCategoryView Members

    public List<Sub_Category> SubCategories { get; set; }

    public int SubCategoryID_N { get; set; }
    public int CategoryID_N
    {
        get
        {
            return Convert.ToInt32(UC_Category_List.SelectedValue);
        }
        set
        {
            UC_Category_List.SelectedValue = value.ToString();
        }
        //{
        //    ;//UC_Category_List.SelectedValue = value;
        //}
    }

    public string SubCategoryName_V
    {
        get
        {
            return txtSubCategory.Text.Trim();
        }
        set
        {
            txtSubCategory.Text = value;
        }
    }

    public string strMessage { get; set; }

 

    #endregion

    #region IView Members


    public bool IsValid
    {
        get { return true; }
    }

    #endregion
    protected void gvSubCategories_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delSubCat")
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                lblMessage.Text = string.Empty;

                this.SubCategoryID_N = Convert.ToInt32(e.CommandArgument.ToString());
                delete(this, e);
                BindSubCategories();
                lblMessage.Text = strMessage;
            }
        }
    }


 
}