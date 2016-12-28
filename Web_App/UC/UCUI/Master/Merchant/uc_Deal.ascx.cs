using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml.Linq;

public partial class UC_UCUI_Master_Merchant_uc_Deal : System.Web.UI.UserControl, IMerchant_DealEntryView
{
    private Merchant_DealPrensenter _presenter;


    public UC_UCUI_Master_Merchant_uc_Deal()
    {
        this._presenter = new Merchant_DealPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindItems();
        }
    }



    public long MID
    {
        get
        {
            return Convert.ToInt64(uc_MerchantDDlList.SelectedMerchant);
        }
        set
        {
            uc_MerchantDDlList.SelectedMerchant = value.ToString();
        }
    }

    public string ProductCategoryName
    {
        get
        {
            return txtProductCategoryName.Text.Trim();
        }
        set
        {
            txtProductCategoryName.Text = value;
        }
    }

    public string Title
    {
        get
        {
            return txtDeal.Text.Trim();
        }
        set
        {
            txtDeal.Text = value;
        }
    }

    public string Description
    {
        get
        {
            return txtDealDescription.Text.Trim();
        }
        set
        {
            txtDealDescription.Text = value;
        }
    }

    public string Availability
    {
        get
        {
            return Constants.Availability.InStock.ToString();
        }

    }

    public string CouponCode
    {
        get
        {
            return txtCouponCode.Text.Trim();
        }
        set
        {
            txtCouponCode.Text = value;
        }
    }

    public string ImageUrl
    {
        get
        {
            return txtImageUrl.Text.Trim();
        }
        set
        {
            txtImageUrl.Text = value;
        }
    }

    public int SerialNo { get; set; }

    public string NavigationURL
    {
        get
        {
            return txtNavigationUrl.Text.Trim();
        }
        set
        {
            txtNavigationUrl.Text = value;
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public event EventHandler InsertCommand;

    public event EventHandler UpdateCommand;

    public event EventHandler DeleteCommand;

    public List<Merchant_Deal> Merchant_Deals { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(22, "...");
    }
    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            List<Merchant_Deal> deals = new List<Merchant_Deal>();
            Merchant_Deal deal = new Merchant_Deal();

            //deal.Brand = this.
            //deal.Color = row["Color"].ToString();
            //deal.CouponCode = row["CouponCode"].ToString();
            //deal.Description = row["ProductDescription"].ToString();
            //deal.DiscountedPrice = Convert.ToInt64(row["DiscountedPrice"].ToString());
            //deal.ImageUrl = row["ProductURL"].ToString();
            //deal.Location = row["Location"].ToString();
            //deal.NavigationURL = row["NavigationURL"].ToString();
            //deal.ProductCategoryName = row["CategoryName"].ToString();
            //deal.ProductPrice = Convert.ToInt64(row["ProductPrice"].ToString());
            //deal.ProductPriceCurrency = row["ProductPriceCurrency"].ToString();
            //deal.Title = row["ProductName"].ToString();
            //deal.Availability = row["Availability"].ToString();
            //deal.ProductID = row["ProductID"].ToString();
            //deal.ProductSKU = row["ProductSKU"].ToString();
            //deal.WasPrice = Convert.ToInt64(row["WasPrice"].ToString());

            deal.MID = this.MID;
            deal.ProductCategoryName = this.ProductCategoryName;
            deal.Title = this.Title;
            deal.Description = this.Description;
            deal.Availability = this.Availability;
            deal.CouponCode = this.NavigationURL;
            deal.ImageUrl = this.NavigationURL;
            deals.Add(deal);
            Merchant_Deals = deals;
            //deal.SerialNo = _view.SerialNo;
            deal.NavigationURL = this.NavigationURL;

            Insert(this, e);
            BindItems();
        }
    }

    private void BindItems()
    {
        gvItems.DataSource = Merchant_Deals;
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }


    public List<long> Ids { get; set; }

    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> iIDS = new List<long>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 id = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                iIDS.Add(id);
            }
        }

        if (iIDS.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.Ids = iIDS;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindItems();
            }
        }

    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (fuUpload.HasFile)
        {

            string filename = Path.GetFileName(fuUpload.FileName);
            fuUpload.SaveAs(Server.MapPath("~/XML/") + filename);

            string path1 = Path.GetFullPath(fuUpload.PostedFile.FileName);
            XElement xele = XElement.Load(Server.MapPath("~/XML/") + filename);
            ds = clsFileToTable.XElementToDataset(xele);
            //XMLDataTable = dt;
            //BindXMLData("");
            AssingDBDate(ds.Tables["Product"]);
            File.Delete(Server.MapPath("~/XML/") + filename);
            EventHandler Insert = this.InsertCommand;
            if (Insert != null)
            {
                this.Merchant_Deals = AssingDBDate(ds.Tables["Product"]);
                //lblMessage.Text = string.Empty;
                Insert(this, e);
                BindItems();
            }
        }
        //if (rbListUrl.Checked)
        //{
        //    XElement xele = XElement.Load(Constants.OmgVoucherCode);
        //    dt = clsFileToTable.XElementToDataTable(xele);
        //    XMLDataTable = dt;
        //    BindXMLData("");
        //}
    }

    private List<Merchant_Deal> AssingDBDate(DataTable dt)
    {
        List<Merchant_Deal> deals = new List<Merchant_Deal>();
        foreach (DataRow row in dt.Rows)
        {
            Merchant_Deal deal = new Merchant_Deal();
            deal.MID = this.MID;
            if (dt.Columns.Contains("Brand"))
                deal.Brand = row["Brand"].ToString();
            if (dt.Columns.Contains("Color"))
                deal.Color = row["Color"].ToString();
            if (dt.Columns.Contains("CouponCode"))
                deal.CouponCode = row["CouponCode"].ToString();
            if (dt.Columns.Contains("ProductDescription"))
                deal.Description = row["ProductDescription"].ToString();
            if (dt.Columns.Contains("DiscountedPrice"))
                deal.DiscountedPrice = Convert.ToDouble(row["DiscountedPrice"].ToString());

            if (dt.Columns.Contains("ProductImageLargeURL"))
                deal.ImageUrl = row["ProductImageLargeURL"].ToString();
            
            if(dt.Columns.Contains("ProductImageMediumURL"))
                deal.ImageUrl = row["ProductImageMediumURL"].ToString();

            if (dt.Columns.Contains("ProductImageSmallURL"))
                deal.ImageUrl = row["ProductImageSmallURL"].ToString();


            if (dt.Columns.Contains("Location"))
                deal.Location = row["Location"].ToString();
            if (dt.Columns.Contains("ProductURL"))
                deal.NavigationURL = row["ProductURL"].ToString();
            deal.ProductCategoryName = row["CategoryName"].ToString();
            if (dt.Columns.Contains("ProductPrice"))
                deal.ProductPrice = Convert.ToDouble(row["ProductPrice"].ToString());
            if (dt.Columns.Contains("ProductPriceCurrency"))
                deal.ProductPriceCurrency = row["ProductPriceCurrency"].ToString();
            if (dt.Columns.Contains("ProductName"))
                deal.Title = row["ProductName"].ToString();
            if (dt.Columns.Contains("Availability"))
                deal.Availability = row["Availability"].ToString();
            if (dt.Columns.Contains("ProductID"))
                deal.ProductID = row["ProductID"].ToString();
            deal.ProductSKU = row["ProductSKU"].ToString();
            if (dt.Columns.Contains("WasPrice"))
                deal.WasPrice = Convert.ToDouble(row["WasPrice"].ToString());

            deals.Add(deal);
        }

        return deals;
    }

    public string SearchText { get; set; }

    public event EventHandler SearchRefresh;


    public int TakeLatestCoupon { get; set; }
}
//<ProductID>50416044</ProductID>
//<ProductSKU>61</ProductSKU>
//<ProductName>Pocket Detail Striped Shirt</ProductName>
//<ProductDescription
//<ProductPrice>1799.00</ProductPrice>

//<ProductPriceCurrency>INR</ProductPriceCurrency>

//<WasPrice>0.00</WasPrice>

//<DiscountedPrice>0.00</DiscountedPrice>

//<ProductURL>http://clk.omgt5.com/?AID=764019&PID=11325&Type=12&r=http://www.trendin.com/pocket-detail-striped-shirt-61.html</ProductURL>

//<PID>11325</PID>

//<MID>523985</MID>

//<ProductImageSmallURL/>

//<ProductImageMediumURL/>

//<ProductImageLargeURL>http://cdn1.cdntrendin.com/img/p/61-141-productlist.jpg</ProductImageLargeURL>

//<MPN/>

//<StockAvailability/>

//<Brand>Allen Solly</Brand>

//<Location/>

//<Colour/>

//<custom1/>

//<custom2/>

//<custom3/>

//<custom4/>

//<custom5/>

//<CategoryName>Root|Shirts</CategoryName>

//<CategoryPathAsString>Root|Shirts|</CategoryPathAsString>