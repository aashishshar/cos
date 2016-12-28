using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;

public partial class UC_UCUI_Master_Merchant_uc_Offer : System.Web.UI.UserControl, IMerchant_OfferEntryView
{


    private Merchant_OfferPrensenter _presenter;

    public event EventHandler BulkInsert;


    public UC_UCUI_Master_Merchant_uc_Offer()
    {
        this._presenter = new Merchant_OfferPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEnum();
            BindItems();
        }
     
      
    }



    private void BindEnum()
    {

        EnumControl.GetEnumDescriptions<Constants.Device>(ddlDevice);
        ddlDevice.Items.Insert(0, "[ Select Device ]");
        ddlDevice.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.MerchantDeepLinkType>(ddlLinkFor);
        //ddlDevice.Items.Insert(0, "[ Select Device ]");
        //ddlDevice.Items.RemoveAt(1);
        EnumControl.GetEnumDescriptions<Constants.Adv_Type>(ddlOfferType);
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
            if (ddlDevice.SelectedIndex == 0)
            {
                return Convert.ToInt32(Constants.Device.Desktop);
            }
            else
            {
                return Convert.ToInt32(Convert.ToInt32((Constants.Device)Enum.Parse(typeof(Constants.Device), ddlDevice.SelectedValue.ToString())));
            }

        }
        set
        {
            ddlDevice.SelectedValue = Convert.ToInt32((Constants.Device)Enum.Parse(typeof(Constants.Device), value.ToString())).ToString();
        }
    }

    public string Title
    {
        get
        {
            return txtOffer.Text.Trim();
        }
        set
        {
            txtOffer.Text = value;
        }
    }

    public string Description
    {
        get
        {
            return txtOfferDescription.Text.Trim();
        }
        set
        {
            txtOfferDescription.Text = value;
        }
    }

    public DateTime? ValidTill
    {
        get
        {
            if (txtValiDate.Text.Trim() != string.Empty)
                return Convert.ToDateTime(txtValiDate.Text.Trim());
            else
                return null;
        }
        set
        {
            txtValiDate.Text = value.ToString();
        }
    }

    public string NavigationURL
    {
        get
        {
            //if (uc_DeepLinkUrlDDL.SelectedIndex() > 0)
            //{
                if (ddlLinkFor.SelectedValue == Constants.MerchantDeepLinkType.Payoom.ToString())
                {
                    string url = uc_DeepLinkUrlDDL.SelectedValue() + "&url=" + txtNavigationUrl.Text.Trim();
                    return url;
                }
                else if (ddlLinkFor.SelectedValue == Constants.MerchantDeepLinkType.OMGPM.ToString())
                {
                    string url = Constants.OMG_TrackinfURL_AID+"PID=" + uc_CommisionProgramDDLList.GetProgramID() + "&r=" + txtNavigationUrl.Text.Trim();
                    return url;
                }
                else
                {
                    return txtNavigationUrl.Text.Trim();
                }
            //}
            //else
            //{
            //    return txtNavigationUrl.Text.Trim();
            //}
            // Server.UrlEncode
        }
        set
        {
            txtNavigationUrl.Text = value.ToString();
        }
    }

    public string CouponCode
    {
        get
        {
            if (!string.IsNullOrEmpty(txtCouponCode.Text.Trim()))
                return txtCouponCode.Text.Trim();
            else
                return "No Coupon Required.";
        }
        set
        {
            txtCouponCode.Text = value.ToString();
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public event EventHandler InsertCommand;

    public event EventHandler UpdateCommand;

    public event EventHandler DeleteCommand;

    public List<Merchant_Offer> Merchant_Offers { get; set; }

    public string ReduceString(string obj)
    {
        return obj.Truncate(22, "...");
    }
    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            //lblMessage.Text = string.Empty;
            Insert(this, e);
            BindItems();
            ddlLinkFor.SelectedIndex = 0;
            txtOffer.Text = "";
            txtNavigationUrl.Text = "";
            txtCouponCode.Text = "";
        }
    }

    private void BindItems()
    {
        gvItems.DataSource = Merchant_Offers.OrderByDescending(o=>o.CreatedDate);
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (fuUpload.HasFile)
        {

            string filename = Path.GetFileName(fuUpload.FileName);
            fuUpload.SaveAs(Server.MapPath("~/XML/") + filename);

            string path1 = Path.GetFullPath(fuUpload.PostedFile.FileName);
            XElement xele = XElement.Load(Server.MapPath("~/XML/") + filename);
            dt = clsFileToTable.XElementToDataTable(xele);
            XMLDataTable = dt;
            BindXMLData("");
            File.Delete(Server.MapPath("~/XML/") + filename);
        }
        if (rbListUrl.Checked)
        {
            XElement xele = XElement.Load(Constants.OmgVoucherCode);
            dt = clsFileToTable.XElementToDataTable(xele);
            XMLDataTable = dt;
            BindXMLData("");
        }

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

    public DataTable XMLDataTable
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
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindXMLData("");
    }

    protected void ddlHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlHeader = (DropDownList)sender;
        BindXMLData(ddlHeader.SelectedItem.Value);
    }


    protected void btnSubmitOffer_Click(object sender, EventArgs e)
    {
        List<Merchant_Offer> offers = new List<Merchant_Offer>();

        DataTable dt = new DataTable("Item");
        EventHandler Insert = this.InsertCommand;
        if (rbListUrl.Checked)
        {
            XElement xele = XElement.Load(Constants.OmgVoucherCode);
            dt = clsFileToTable.XElementToDataTable(xele);
            dt.Columns["ExpiryDate"].GetType();
            //var offer = (from o in dt.AsEnumerable()
            //            select new Merchant_Offer()
            //            {

            //                Title = o.Field<string>("Title"),
            //                VoucherCodeID =Convert.ToInt32(o.Field<string>("VoucherCodeID")),
            //                MID =uc_MerchantDDlList.GetValueFindByText(o.Field<string>("Merchant").ToString()),// o.Field<string>("Title"),
            //                Description = o.Field<string>("Description"),
            //                CouponCode = o.Field<string>("Code"),
            //                ValidTill = Convert.ToDateTime(string.IsNullOrEmpty(o.Field<string>("ExpiryDate")) ? DateTime.Now.AddYears(1).ToString() : o.Field<string>("ExpiryDate")).Date,
            //                ActivationDate = Convert.ToDateTime(string.IsNullOrEmpty(o.Field<string>("ActivationDate")) ? DateTime.Now.AddYears(1).ToString() : o.Field<string>("ActivationDate")).Date,
                            
            //                NavigationURL = o.Field<string>("TrackingURL"),
            //                OfferType = Convert.ToInt16(Constants.Adv_Type.Offer)

            //            });
            //foreach (Merchant_Offer ooo in offer)
            //{
            //    if (ooo.MID > 0)
            //        offers.Add(ooo);
            //}
            foreach (DataRow row in dt.Rows)
            {
                Merchant_Offer itemOffer = new Merchant_Offer();
                Int64 merID = uc_MerchantDDlList.GetValueFindByText(row["Merchant"].ToString());
                if (merID != 0)
                {
                    itemOffer.Title = row["Title"].ToString();
                    if (row["VoucherCodeID"].ToString() != "")
                        itemOffer.VoucherCodeID = Convert.ToInt32(row["VoucherCodeID"].ToString());
                    //this.co Code = row.Cells[3].Text;
                    itemOffer.MID = merID;
                    itemOffer.Description = row["Description"].ToString();
                    itemOffer.CouponCode = row["Code"].ToString();
                    string[] vDate = null;
                    if (row["ExpiryDate"].ToString() != "")
                        vDate = row["ExpiryDate"].ToString().Split('/');

                    if (vDate != null && vDate.Length > 1)
                        itemOffer.ValidTill = Convert.ToDateTime(vDate[1] + "/" + vDate[0] + "/" + vDate[2]);

                    if (row["ActivationDate"].ToString() != "")
                        vDate = row["ActivationDate"].ToString().Split('/');

                    if (vDate != null && vDate.Length > 1)
                        itemOffer.ActivationDate = Convert.ToDateTime(vDate[1] + "/" + vDate[0] + "/" + vDate[2]);

                    itemOffer.NavigationURL = row["TrackingURL"].ToString();
                    itemOffer.OfferType = Convert.ToInt16(Constants.Adv_Type.Offer);

                    offers.Add(itemOffer);
                }
            }

            if (Insert != null)
            {
                //lblMessage.Text = string.Empty;
                this.Merchant_Offers = offers;//.ToList();// offers;
                Insert(this, e);

                clsProcCallingService.Proc_UpdateDeleteDupilcateOffers();
                BindItems();
            }
        }


        //foreach (GridViewRow row in gvXMLDate.Rows)
        //{
        //    CheckBox chkXMLData = row.Cells[0].Controls[0].FindControl("chkRow") as CheckBox;
        //    if (chkXMLData.Checked)
        //    {
        //        //Title
        //        //string vcodeID=row.Cells[1].Text;
        //        this.Title = row.Cells[4].Text;
        //        //this.co Code = row.Cells[3].Text;
        //       // this.MID=
        //        this.Description = row.Cells[5].Text;
        //        this.CouponCode = row.Cells[3].Text;
        //        string[] vDate = null;
        //        if (row.Cells[7].Text != "")
        //            vDate = row.Cells[7].Text.Split('/');

        //        if (vDate.Length > 1)
        //            this.ValidTill = Convert.ToDateTime(vDate[1] + "/" + vDate[0] + "/" + vDate[2]);

        //        this.NavigationURL = row.Cells[8].Text;

        //        if (Insert != null)
        //        {
        //            //lblMessage.Text = string.Empty;
        //            Insert(this, e);
        //            BindItems();
        //        }
        //        //this.Title=chkXMLData.XMLDataTable.se

        //    }
        //}
    }



    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> offerIds = new List<long>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                offerIds.Add(offerID);
            }
        }

        if (offerIds.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.OfferIds = offerIds;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindItems();
            }
        }

    }


    public List<long> OfferIds { get; set; }


    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (fuUpload.HasFile)
        {
            string FileName = Path.GetFileName(fuUpload.PostedFile.FileName);
            string Extension = Path.GetExtension(fuUpload.PostedFile.FileName);


            string FilePath = Server.MapPath("~/XML/") + FileName;
            fuUpload.SaveAs(FilePath);
            if (Extension == ".csv")
            {
             this.Merchant_Offers= SetDTinValuesOfPayoomCSV( ConvertCSVtoDataTable(FilePath));
            }
            else
            {
                Import_To_Grid(FilePath, Extension, "Yes");
            }
            EventHandler bulk = this.BulkInsert;
            if (bulk != null)
            {
                //lblMessage.Text = string.Empty;
                bulk(this, e);
                BindItems();
            }
        }
    }
    public static DataTable ConvertCSVtoDataTable(string strFilePath)
    {
        DataTable dt = new DataTable();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            string[] headers = sr.ReadLine().Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header.Replace(" ",""));
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }

        }


        return dt;
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
        this.Merchant_Offers = SetDTinValues(dt);

        //Bind Data to GridView
        GridView1.Caption = Path.GetFileName(FilePath);
        GridView1.DataSource = this.Merchant_Offers;
        GridView1.DataBind();
    }

    private List<Merchant_Offer> SetDTinValuesOfPayoomCSV(DataTable dt)
    {
        List<Merchant_Offer> offers = new List<Merchant_Offer>();

        foreach (DataRow row in dt.Rows)
        {
            if (!string.IsNullOrEmpty(row["Campaign"].ToString()))
            {
                Merchant_Offer offer = new Merchant_Offer();
                Uri myUri = new Uri(row["LandingPage"].ToString());
                string omgmid = HttpUtility.ParseQueryString(myUri.Query).Get("Offer_ID");

                offer.MID = uc_MerchantDDlList.GetMIDByAMID(Convert.ToInt32(omgmid), row["Campaign"].ToString());
                if (offer.MID > 0)
                {
                    //offer.MID = row["Program"].ToString();
                    //offer.MID = row["AffWebsite"].ToString();
                    offer.Title = row["CouponTitle"].ToString();
                    offer.CouponCode = row["CouponCode"].ToString();
                    //offer.Description = row["Description"].ToString();

                    if (!string.IsNullOrEmpty(row["EndDate"].ToString()))
                    {
                        // offer.ValidTill = Convert.ToDateTime(row["EndDate"].ToString());
                        string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        if (row["EndDate"].ToString().Contains("-"))
                        {

                            if (dtFormat == "dd/MM/yyyy")
                                offer.ValidTill = DateTime.ParseExact(row["EndDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            else
                                offer.ValidTill = DateTime.ParseExact(row["EndDate"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);


                        }
                        else
                        {
                            try
                            {
                                if (dtFormat == "dd/MM/yyyy")
                                    offer.ValidTill = DateTime.ParseExact(row["EndDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                else
                                    offer.ValidTill = DateTime.ParseExact(row["EndDate"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            }
                            catch (Exception ex)
                            {
                                offer.ValidTill = Convert.ToDateTime(row["EndDate"].ToString());
                            }


                        }
                    }
                    else
                        offer.ValidTill = null;

                    if (!string.IsNullOrEmpty(row["StartDate"].ToString()))
                        offer.ActivationDate = Convert.ToDateTime(row["StartDate"].ToString());
                    else
                        offer.ActivationDate = null;

                    //if (string.IsNullOrEmpty(row["Device"].ToString()))
                    //    offer.CouponForDevice = Constants.Device.Desktop;
                    //else
                    //    offer.CouponForDevice = (Constants.Device)Enum.Parse(typeof(Constants.Device), row["Device"].ToString());



                    offer.NavigationURL = row["LandingPage"].ToString();

                    offers.Add(offer);
                }
            }
        }
        return offers;
    }
    private List<Merchant_Offer> SetDTinValues(DataTable dt)
    {
        List<Merchant_Offer> offers = new List<Merchant_Offer>();

        foreach (DataRow row in dt.Rows)
        {
            if (!string.IsNullOrEmpty(row["Merchant"].ToString()))
            {
                Merchant_Offer offer = new Merchant_Offer();

                offer.MID = uc_MerchantDDlList.GetValueFindByText(row["Merchant"].ToString());
                //offer.MID = row["Program"].ToString();
                //offer.MID = row["AffWebsite"].ToString();
                offer.Title = row["OfferTitle"].ToString();
                offer.CouponCode = row["CouponCode"].ToString();
                offer.Description = row["Description"].ToString();

                if (!string.IsNullOrEmpty(row["ValidTill"].ToString()))
                    offer.ValidTill = Convert.ToDateTime(row["ValidTill"].ToString());
                else
                    offer.ValidTill = null;

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
            if (!string.IsNullOrEmpty(date.Text) && date.Text != "UNTILL")
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


    public int? VoucherCodeID { get; set; }


    public int PageIndex{get;set;}

    public int PageSize { get; set; }

    public int TotalRecord { get; set; }


    public event EventHandler PagingCommand;
    protected void ddlLinkFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLinkFor.SelectedValue == "OMGPM")
        {
            uc_CommisionProgramDDLList.CommisionByMerchantName(uc_MerchantDDlList.SelectedMerchantText);
        }
    }


    public DateTime? StartDate
    {
        get
        {
            if (txtStartDate.Text.Trim() != string.Empty)
                return Convert.ToDateTime(txtStartDate.Text.Trim());
            else
                return null;
        }
        set
        {
            txtStartDate.Text = value.ToString();
        }
    }

    public int? OfferType 
    {
        get
        {
            return Convert.ToInt32((Constants.Adv_Type)Enum.Parse(typeof(Constants.Adv_Type), ddlOfferType.SelectedValue)); 
        }
        set
        {
            ddlOfferType.SelectedIndex=0;
        }
    }
}