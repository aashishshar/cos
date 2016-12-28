using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;

public partial class UC_UCUI_Master_Merchant_uc_MissingCashback : System.Web.UI.UserControl, IIMissingCashBack_ListView
{
     private MissingCashback_ListPresenter _presenter;


     public UC_UCUI_Master_Merchant_uc_MissingCashback()
    {
        this._presenter = new MissingCashback_ListPresenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindItem();
        }
    }
    private void BindItem()
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
    public List<MissingCashBack> MissingCashBack_List { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
    protected void Delete_Click(object sender, EventArgs e)
    {

    }
    protected void lkbSendmail_Click(object sender, EventArgs e)
    {

        List<int> tIds = new List<int>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int tid = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                tIds.Add(tid);
            }
        }
        MerchantModel _m=new MerchantModel();
        var missing = from n in _m.GetAllMissingCashBacks()
                      where tIds.Contains(n.TicketNo)
                      select n;
        clsCommonMethods client = new clsCommonMethods();
        foreach (MissingCashBack m in missing)
        {
            SendEmail(m.OrderID, m.TransactionDate.ToString(), m.AmountPaid.ToString(), m.CouponCode, m.MerchantName + "/" + m.MID, txtNote.Text);
            m.MailSend=true;
            client.UpdateCashIssue(m);
        }


        //if (offerIds.Count > 0)
        //{
        //    EventHandler delete = this.DeleteCommand;
        //    if (delete != null)
        //    {
        //        this.OfferIds = offerIds;
        //        //lblMessage.Text = string.Empty;
        //        delete(this, e);
        //        BindItems();
        //    }
        //}
    }

    private void SendEmail(string OrderID, string TransactionDate, string Amount, string Coupon, string MerchantName,string note)
    {
        string body = clsEmailMailer.PopulateMissingCashBackBody( OrderID,  TransactionDate,  Amount,  Coupon,  MerchantName,note);
        clsEmailMailer.SendHtmlFormattedEmail(txtToEmail.Text.Trim(), "Transaction not getting track on www.cashonshop.com", body);
    }
    protected void lkbResolve_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int tid = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                using (Ad_ConnectionString model = new Ad_ConnectionString())
                {

                    var original = model.Adv_MissingCashbacks.Where(c => c.TicketNo == tid).SingleOrDefault();
                    if (original != null)
                    {

                        original.Status = (int)Constants.Status.Resolve;
                        model.SaveChanges();
                    }
                }

            }
        }
       
    }
}