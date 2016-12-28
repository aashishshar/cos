using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_Notification : System.Web.UI.UserControl,INotificationView
{
     public event EventHandler InsertCommand;
    public event EventHandler UpdateCommand;
    public event EventHandler DeleteCommand;

    private NotificationPrensenter _presenter;


    public UC_UCUI_Master_Merchant_uc_Notification()
    {
        this._presenter = new NotificationPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDL();
            BindItems();
        }
    }
    private void BindItems()
    {
        gvItems.DataSource = Notifications;
        gvItems.DataBind();
        if (gvItems.Rows.Count > 0)
        {
            gvItems.UseAccessibleHeader = true;
            gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    private void BindDDL()
    {
        EnumControl.GetEnumDescriptions<Constants.NotificationType>(ddlNotificationType);
    }
    

    public string NotificationText { get; set; }

    public Constants.NotificationType NotificationType { get; set; }

    public Constants.NotificationType Status { get; set; }    

    public string strMessage
    {
        set { lblMessage.Text=value; }
    }

    public List<int> Ids { get; set; }


    public List<Notification> Notifications { get; set; }    
    public event EventHandler ViewCommand;


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            this.NotificationText = txtNotificationText.Text.Trim();
            this.NotificationType = (Constants.NotificationType)Enum.Parse(typeof(Constants.NotificationType), ddlNotificationType.SelectedValue.ToString());
            //lblMessage.Text = string.Empty;
            Insert(this, e);
            BindItems();
        }
    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        List<int> Ids = new List<int>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                int offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                Ids.Add(offerID);
            }
        }

        if (Ids.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.Ids = Ids;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindItems();
            }
        }
    }
}