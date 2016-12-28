using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;


public partial class UC_UCUI_Master_Category_UC_CategoryEntry : System.Web.UI.UserControl, ICategoryView
{
    private MastersListPresenter _presenter;

    public event EventHandler InsertCommand;
    public event EventHandler UpdateCommand;
    public event EventHandler DeleteCommand;
    public UC_UCUI_Master_Category_UC_CategoryEntry()
    {
        this._presenter = new MastersListPresenter(this, Constants.Master.Category);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCategories();
            //GetChildren(0, 10);
            GetNewDataBaseCategory();
        }       
    }
    public IEnumerable<KeyValuePair<int, int>> GetChildren(int id, int childLevel)
    {
        foreach (var row in Categories.Where(row => row.ParentCategoryID_N == id && row.CategoryID_N != id))
        {
            yield return new KeyValuePair<int, int>(row.CategoryID_N, childLevel);
            foreach (var x in GetChildren(row.CategoryID_N, childLevel + 1))
            {
                yield return x;
            }
        }
    }

    //public IQueryable GetCategories(Category parent)
    //{
    //    var cats = Categories;
    //    List<
    //    foreach (Category c in Categories)
    //    {
    //        cats = cats.Concat(GetCategories(c));
    //    }
    //    return a;
    //}

    private void BindCategories()
    {
        gvItems.DataSource = Categories;
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    
    #region ICategoryView Members

    public List<Category> Categories { get; set; }

    public int CategoryID_N { get; set; }


    

    public string CategoryName_V
    {
        get
        {
            return txtCategoryName.Text.Trim();
        }
        set
        {
            txtCategoryName.Text = value;
        }
    }

    #endregion

    #region IView Members


    public bool IsValid
    {
        get
        {
            return true;
        }
    }
    public string strMessage { get; set; }
    #endregion
    protected void btnCategoryAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            lblMessage.Text = string.Empty;

            if (UC_CategoryList.SelectedIndex > 0)
            {
                ParentCategoryID_N = Convert.ToInt32(UC_CategoryList.SelectedValue);
            }
            //if(!string.IsNullOrEmpty(txtMasterCategoryName.Text.Trim()))
            //{
            //    MCategoryName_V=txtMasterCategoryName.Text.Trim();
            //}
            Insert(this, e);
            BindCategories();
            lblMessage.Text = strMessage;        
        }
    }

    public int? ParentCategoryID_N { get; set; }

   

    private void GetNewDataBaseCategory()
    {
        clsCommonMethods obj = new clsCommonMethods();
        var cate =from newcat in obj.GetAll_VW_Products()
                   where !Categories.Select(cat => cat.CategoryName_V).ToList().Contains(newcat.CategoryName) && newcat.CategoryName!=null
                   select new
                   {
                       NewCategory = newcat.CategoryName,
                       CategoryPath = newcat.Location
                   };

        gvLiveItems.DataSource = cate.Distinct().ToList();
        gvLiveItems.DataBind();
        //if (gvLiveItems.Rows.Count > 0)
        //{
        //    gvLiveItems.UseAccessibleHeader = true;
        //    gvLiveItems.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    gvLiveItems.FooterRow.TableSection = TableRowSection.TableFooter;
        //}
    }


    private void UpdateCategoryID()
    {
        try
        {
            using (var model = new Ad_ConnectionString())
            {
                clsCommonMethods _modelCat = new clsCommonMethods();
                var catList = _modelCat.GetAllCategories();
                var catIDs = (from ct in catList
                              select ct.CategoryName_V).ToList();
                foreach (Category cat in catList)
                {

                    if (cat.SubCategory.Count > 0)
                    {

                        var orginalCat = model.Adv_Product_Commons.Where(nc => nc.CategoryID_N == null && nc.ProductCategoryName != null && nc.Ad_For > 0).Where(p => p.ProductCategoryName.Equals(cat.CategoryName_V)).ToList();// p.cat.CategoryName.Contains(cat.CategoryName_V)).ToList();
                        orginalCat.ForEach(aa => aa.CategoryID_N = cat.CategoryID_N);//a=>a..c.CategoryID_N=cat.CategoryID_N);
                        model.SaveChanges();


                        var orginal = model.Adv_Product_Commons.Where(nc => nc.CategoryID_N == null && nc.ProductCategoryName != null && nc.Ad_For > 0).Where(p => cat.SubCategory.Select(s => s.SubCategoryName_V).ToList().Equals(p.ProductCategoryName)).ToList();// p.cat.CategoryName.Contains(cat.CategoryName_V)).ToList();
                        orginal.ForEach(aa => aa.CategoryID_N = cat.CategoryID_N);//a=>a..c.CategoryID_N=cat.CategoryID_N);
                        model.SaveChanges();
                    }
                    else
                    {
                        var orginal = model.Adv_Product_Commons.Where(nc => nc.CategoryID_N == null && nc.ProductCategoryName != null && nc.Ad_For > 0).Where(p => p.ProductCategoryName.Equals(cat.CategoryName_V)).ToList();// p.cat.CategoryName.Contains(cat.CategoryName_V)).ToList();
                        orginal.ForEach(aa => aa.CategoryID_N = cat.CategoryID_N);//a=>a..c.CategoryID_N=cat.CategoryID_N);
                        model.SaveChanges();

                        if (cat.CategoryName_V == "Mobile Phones")
                        {
                            var cateNewMap = model.Adv_Product_Commons.Where(nc => nc.CategoryID_N == null && nc.ProductCategoryName != null && nc.Ad_For > 0).Where(p => p.ProductCategoryName.Equals("Mobiles & Accessories>Mobiles")).ToList();// p.cat.CategoryName.Contains(cat.CategoryName_V)).ToList();
                            cateNewMap.ForEach(aa => aa.CategoryID_N = cat.CategoryID_N);//a=>a..c.CategoryID_N=cat.CategoryID_N);
                            model.SaveChanges();
                        }
                    }

                }

                model.Dispose();

            }
        }
        catch (Exception ex)
        {
        }
    }

    private string MapCategoryText(string cateMapText,string toMapCategory)
    {
        string cateName = string.Empty;
        if (cateMapText == "Mobiles & Accessories>Mobiles")
        {
            cateName = "Mobile Phones";
        }
        else
        {
            cateName = toMapCategory;
        }

        return cateName;
    }
    protected void btnUpdatecategoryItems_Click(object sender, EventArgs e)
    {
        UpdateCategoryID();
    }
    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delCal")
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                lblMessage.Text = string.Empty;

                this.CategoryID_N = Convert.ToInt32(e.CommandArgument.ToString());
                delete(this, e);
                BindCategories();
                lblMessage.Text = strMessage;
            }
        }
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int id = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                EventHandler delete = this.DeleteCommand;
                if (delete != null)
                {
                    this.CategoryID_N = id;
                    delete(this, e);
                    BindCategories();
                    lblMessage.Text = strMessage;
                }
               
            }
        }

        

    }


    
}