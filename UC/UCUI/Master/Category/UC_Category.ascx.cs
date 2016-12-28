using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UC_UCUI_Master_Category_UC_Category : System.Web.UI.UserControl,ICategoryListView
{
    private CategoryPresenter _presenter;    
    //private List<KeyValuePair<int, string>> items;
    private string _selctedCategory = string.Empty;
    public UC_UCUI_Master_Category_UC_Category()
    {
        this._presenter = new CategoryPresenter(this);       
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void populateCategories(List<KeyValuePair<int, string>> items)
    {
        ddlCategory.DataSource = items.ToArray();
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("[ Category ]", "0"));
        if (ddlWidth > 0)
            ddlCategory.Width = ddlWidth;
    }

    public string SelectedValue
    {
        get
        { 
           return  ddlCategory.SelectedValue.ToString(); 
        }
        set 
        {
            ddlCategory.SelectedValue = value;
        }
    }

    //public string SelectedText
    //{
    //    get
    //    {
    //        return ddlCategory.SelectedItem.Text.ToString();
    //    }
    //    set
    //    {
    //        ddlCategory.SelectedItem.Text = value;
    //    }
    //}

    public int SelectedIndex
    {
        get
        {
            return ddlCategory.SelectedIndex;
        }
        set
        {
            ddlCategory.SelectedIndex = value;
        }
    }

   


    public int ddlWidth { get; set; }

    public bool postback { get; set; }

    public List<Category> Categories { get; set; }

    public List<Sub_Category> SubCategories { get; set; }

    public event EventHandler SelectionChangedCategory;

    public event EventHandler refreshCategories;


    public bool IsValid 
    {
        get
        {
            return true;
        }
    }

    #region ICategoryListView Members


    public string SelectedValueDDL { get; set; }

    public Category ShowCategory { get; set; }

    #endregion
}