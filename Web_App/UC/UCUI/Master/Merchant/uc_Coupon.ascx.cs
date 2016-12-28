using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;

public partial class UC_UCUI_Master_Merchant_uc_Coupon : System.Web.UI.UserControl, IMerchant_CouponEntryView
{


    private Merchant_CouponPrensenter _presenter;
    public event EventHandler BulkInsert;

    public UC_UCUI_Master_Merchant_uc_Coupon()
    {
        this._presenter = new Merchant_CouponPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEnum();
            BindCoupons();
        }
    }


    private void BindEnum()
    {

        EnumControl.GetEnumDescriptions<Constants.Device>(ddlDevice);
        ddlDevice.Items.Insert(0, "[ Select Device ]");
        ddlDevice.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.MerchantDeepLinkType>(ddlLinkFor);
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

    public int CouponForDevice
    {
        get
        {

            return Convert.ToInt32(Convert.ToInt32((Constants.Device)Enum.Parse(typeof(Constants.Device), ddlDevice.SelectedValue.ToString())));
        }
        set
        {
            ddlDevice.SelectedValue = Convert.ToInt32((Constants.Device)Enum.Parse(typeof(Constants.Device), value.ToString())).ToString();
        }
    }

    public string Coupon
    {
        get
        {
            return txtCoupon.Text.Trim();
        }
        set
        {
            txtCoupon.Text = value.Trim();
        }
    }

    public string Offer
    {
        get
        {
            return txtCouponDescription.Text.Trim();
        }
        set
        {
            txtCouponDescription.Text = value;
        }
    }

    public DateTime ValidTill
    {
        get
        {
            return Convert.ToDateTime(txtValidTill.Text.Trim());
        }
        set
        {
            txtValidTill.Text = value.ToString();
        }
    }

    public string NavigationURL
    {
        get
        {
            if (uc_DeepLinkUrlDDL.SelectedIndex() > 0)
            {
                if (ddlLinkFor.SelectedValue == Constants.MerchantDeepLinkType.Payoom.ToString())
                {
                    string url = uc_DeepLinkUrlDDL.SelectedValue() + "&url=" + txtNavigationURL.Text.Trim();
                    return url;
                }
                else if (ddlLinkFor.SelectedValue == Constants.MerchantDeepLinkType.OMGPM.ToString())
                {
                    string url = uc_DeepLinkUrlDDL.SelectedValue() + "&r=" + txtNavigationURL.Text.Trim();
                    return url;
                }
                else
                    return txtNavigationURL.Text.Trim();
            }
            else
                return txtNavigationURL.Text.Trim();
        }
        set
        {
            txtNavigationURL.Text = value.ToString();
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public event EventHandler InsertCommand;

    public event EventHandler UpdateCommand;

    public event EventHandler DeleteCommand;

    public List<Merchant_Coupon> Merchant_Coupons { get; set; }


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
            //lblMessage.Text = string.Empty;
            Insert(this, e);
            BindCoupons();
        }
    }


    private void BindCoupons()
    {
        gvItems.DataSource = Merchant_Coupons;
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
                BindCoupons();
            }
        }

    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (fuUpload.HasFile)
        {
            string FileName = Path.GetFileName(fuUpload.PostedFile.FileName);
            string Extension = Path.GetExtension(fuUpload.PostedFile.FileName);


            string FilePath = Server.MapPath("~/XML/") + FileName;
            fuUpload.SaveAs(FilePath);
            Import_To_Grid(FilePath, Extension, "Yes");

          
            EventHandler bulk = this.BulkInsert;
            if (bulk != null)
            {
                //lblMessage.Text = string.Empty;
                bulk(this, e);
                BindCoupons();
            }
        }
    }

    private void Import_To_Grid(string FilePath, string Extension, string isHDR)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;
        }
        conStr = String.Format(conStr, FilePath, isHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;

        //Get the name of First Sheet
        connExcel.Open();
        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        //Read Data from First Sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();
        
        //Bind Data to GridView
        //GridView1.Caption = Path.GetFileName(FilePath);
        //GridView1.DataSource = this.Merchant_Coupons;
        //GridView1.DataBind();
    }

    private List<Merchant_Coupon> SetDTinValues(DataTable dt)
    {
        List<Merchant_Coupon> offers = new List<Merchant_Coupon>();

        foreach (DataRow row in dt.Rows)
        {
            if (!string.IsNullOrEmpty(row["Merchant"].ToString()))
            {
                Merchant_Coupon offer = new Merchant_Coupon();

                offer.MID = uc_MerchantDDlList.GetValueFindByText(row["Merchant"].ToString());
                //offer.MID = row["Program"].ToString();
                //offer.MID = row["AffWebsite"].ToString();
                offer.Coupon = row["CouponCode"].ToString();               
                offer.Offer = row["Description"].ToString();

                if (!string.IsNullOrEmpty(row["ValidTill"].ToString()))
                    offer.ValidTill = Convert.ToDateTime(row["ValidTill"].ToString());
               

                if (string.IsNullOrEmpty(row["Device"].ToString()))
                    offer.CouponForDevice = Constants.Device.Desktop;
                else
                    offer.CouponForDevice = (Constants.Device)Enum.Parse(typeof(Constants.Device), row["Device"].ToString());


                if (!string.IsNullOrEmpty(row["Program"].ToString()) && !string.IsNullOrEmpty(row["AffWebsite"].ToString()))
                {
                    if (row["AffWebsite"].ToString() == Constants.MerchantDeepLinkType.Payoom.ToString())
                    {
                        string programURL = uc_DeepLinkUrlDDL.GetValueFindByText(row["Program"].ToString());
                        string url = programURL + "&url=" + row["NavigationURL"].ToString();
                        offer.NavigationURL = url;
                    }
                    else if (row["AffWebsite"].ToString() == Constants.MerchantDeepLinkType.OMGPM.ToString())
                    {
                        string programURL = uc_DeepLinkUrlDDL.GetValueFindByText(row["Program"].ToString());
                        string url = programURL + "&r=" + row["NavigationURL"].ToString();
                        offer.NavigationURL = url;
                    }
                    else
                    {
                        offer.NavigationURL = null;
                    }
                }
                offers.Add(offer);
            }
        }
        return offers;
    }




    public string SearchText { get; set; }

    public event EventHandler SearchRefresh;


    public int TakeLatestCoupon { get; set; }
    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label date = (Label)e.Row.FindControl("lblValiDate");
            if (!string.IsNullOrEmpty(date.Text) && date.Text!="UNTILL")
            {
                DateTime validTill = Convert.ToDateTime(date.Text);

                foreach (TableCell cell in e.Row.Cells)
                {
                    if (validTill < DateTime.Now)
                    {
                        cell.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}