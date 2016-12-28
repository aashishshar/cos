using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_ProductCommon : System.Web.UI.UserControl, IProductEntryView
{
    ProductPrensenter _prensenter;

    public UC_UCUI_Master_Merchant_uc_ProductCommon()
    {
        _prensenter = new ProductPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindApi();
        }

    }

    private void BindApi()
    { 
        EnumControl.GetEnumDescriptions<Constants.APITypeURL>(ddlAdv_Type);
    }

    public string ProductCategoryName { get; set; }

    public Constants.APITypeURL Ad_Type { get; set; }

    public Constants.NameOfMerchants Ad_For { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Availability { get; set; }

    public string ImageUrl { get; set; }

    public string NavigationURL { get; set; }

    public int SerialNo { get; set; }

    public int CategoryID_N { get; set; }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public int MID { get; set; }

    public event EventHandler InsertCommand;

    public event EventHandler DeleteCommand;


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<Product_Common> ProductList = new List<Product_Common>();
        Product_Common prduct = new Product_Common();
        prduct.Title = txtTitle.Text;
        prduct.Description = txtDescription.Text;
        prduct.NavigationURL = txtNavigateURL.Text;
        prduct.Availability = "In-stock";
        if (!string.IsNullOrEmpty(txtMRP.Text.Trim()))
            prduct.ProductPrice = Convert.ToInt32(txtMRP.Text);
        if (!string.IsNullOrEmpty(txtDiscountPrice.Text.Trim()))
            prduct.DiscountedPrice = Convert.ToInt32(txtDiscountPrice.Text.Trim());
        prduct.Brand = txtBrand.Text.Trim();
        prduct.Color = txtColor.Text.Trim();
        prduct.Ad_Type = Constants.APITypeURL.FlipKart_DOTD_OffersAPI;
        //this.Ad_For =Convert.ToInt16(MID);
        prduct.MID = Convert.ToInt16(uc_MerchantDDlList.SelectedMerchant);
        prduct.ImageUrl = txtImageURL.Text;
        //itemNo = itemNo + 1;
        //this.SerialNo = itemNo;




        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            ProductList.Add(prduct);
            ProductVW = ProductList;
            Insert(this, e);
        }
    }


    public List<Product_Common> ProductVW { get; set; }
}