using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UC_UCUI_User_uc_UserDashBoard : System.Web.UI.UserControl, ITransactionFeedEntryView
{
    private TransactionFeedPrensenter _presenter;
    public UC_UCUI_User_uc_UserDashBoard()
    {
        this._presenter = new TransactionFeedPrensenter(this);
    }

    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TransFromDB();
            clsCommonMethods history = new clsCommonMethods();
           fvUserPaymentPanel.DataSource= history.GetWallet_Histroy();
           fvUserPaymentPanel.DataBind();
        }
    }

    private void TransFromDB()
    {
        //DataTable dummy = new DataTable();
        //dummy.Columns.Add("Status");
        ////dummy.Columns.Add("ContactName");
        ////dummy.Columns.Add("City");
        //dummy.Rows.Add();
        //gvItems.DataSource = dummy;
        //gvItems.DataBind();


        gvItems.DataSource = Transaction_Feeds;
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }

    }
    public string ClickTime { get; set; }

    public string TransactionTime { get; set; }

    public string OmgTransactionID { get; set; }

    public string OmgMerchantRef { get; set; }

    public string UID { get; set; }

    public string UID2 { get; set; }

    public string MID { get; set; }

    public string MerchantName { get; set; }

    public string PID { get; set; }

    public string Product { get; set; }

    public string Referrer { get; set; }

    public string SR { get; set; }

    public string VR { get; set; }

    public string NVR { get; set; }

    public string Status { get; set; }

    public string Paid { get; set; }

    public string Completed { get; set; }

    public string UKey { get; set; }

    public string TransactionValue { get; set; }

    public string VoucherCode { get; set; }

    public List<Transaction_Feed> Transaction_FeedInsert { get; set; }

    public string strMessage
    {
        set { throw new NotImplementedException(); }
    }

    public List<long> Ids { get; set; }

    public event EventHandler InsertCommand;

    public event EventHandler DeleteCommand;

    public event EventHandler UpdateCommand;

    public List<Transaction_Feed> Transaction_Feeds
    { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    public string FromDate { get; set; }

    public string ToDate { get; set; }

    public string AmountStatus { get; set; }

    public event EventHandler SearchCommand;
    protected void btnRedeem_Click(object sender, EventArgs e)
    {
        bool IsSuccess=true;
        divMessage.InnerText = "";
        if (IsSuccess)
        {
            divMessage.InnerText = "Sucess get Request";
            divMessage.Attributes.Add("class", "text-success");
        }
        else
        {
            divMessage.InnerText = "Fail get Request";
            divMessage.Attributes.Add("class", "text-danger");
        }
    }
}