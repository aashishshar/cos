using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;

public partial class UC_UCUI_User_uc_MissingCashback : System.Web.UI.UserControl, IMissingCashBack_View
{
     private MissingCashBack_EntryPresenter _presenter;


     public UC_UCUI_User_uc_MissingCashback()
    {
        this._presenter = new MissingCashBack_EntryPresenter(this);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindIssues();
        }

    }
    

    private void BindIssues()
    {
        gvItems.DataSource = MissingCashBack_List;
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    public DateTime? TransactionDate
    {
        get
        {
            return Convert.ToDateTime(txtTransactionDate.Text);
        }
        set
        {
            txtTransactionDate.Text = value.ToString();
        }
    }

    public long? MID
    {
        get
        {
            return Convert.ToInt64(uc_MerchantNameList.SelectedMerchant);
        }
        set
        {
            uc_MerchantNameList.SelectedMerchantText = "Select Merchant";
        }
    }

    public string OrderID
    {
        get
        {
            return txtOrderID.Text.Trim();
        }
        set
        {
            txtOrderID.Text = value;
        }
    }

    public string AmountPaid
    {
        get
        {
            return txtAmount.Text.Trim();
        }
        set
        {
            txtAmount.Text = value;
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

    public string Details
    {
        get
        {
            return txtOrderDetail.Text.Trim();
        }
        set
        {
            txtOrderDetail.Text = value;
        }
    }

    public string FileUrl
    {
        get
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/CashBackDoc/");
            string filePath = "";
            if (fuFileUpload.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(fuFileUpload.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        string extension = Path.GetExtension(fuFileUpload.PostedFile.FileName);
                        string fName = Path.GetFileNameWithoutExtension(fuFileUpload.PostedFile.FileName); 
                        string userId = Membership.GetUser().ProviderUserKey.ToString();
                        string fileName = OrderID + "_" + fName + "_" + extension;
                        fuFileUpload.PostedFile.SaveAs(path + fileName);
                        filePath = "~/CashBackDoc/" + fileName;
                        //Label1.Text = "File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "File could not be uploaded.";
                    }
                }
                else
                {
                    lblMessage.Text = "Cannot accept files of this type.";
                }
            }

            

            return filePath;
        }
        set
        {
            string ii = "";
        }
    }

    public string ContactNo
    {
        get
        {
            return txtContactNo.Text.Trim();
        }
        set
        {
             txtContactNo.Text = value;
        }
    }

    public Constants.Status? Status
    {
        get
        {
            return Constants.Status.Pending;
        }
        set
        {
            string st = value.ToString();
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public List<int> Ids { get; set; }

    public event EventHandler InsertCommand;

    public event EventHandler DeleteCommand;

    public event EventHandler UpdateCommand;

    public List<MissingCashBack> MissingCashBack_List { get; set; }

    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
    protected void btnTicket_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            Insert(sender, e);
            txtContactNo.Text = "";
            txtTransactionDate.Text = "";
            txtAmount.Text = "";
            txtOrderID.Text = "";
            txtCouponCode.Text = "";
            txtContactNo.Text = "";
            txtOrderDetail.Text = "";
            BindIssues();
        }
    }
}