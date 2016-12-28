using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class UC_UCUI_Master_Merchant_uc_ApiURL : System.Web.UI.UserControl, IMerchant_ApiURLView
{

    public event EventHandler InsertCommand;
    public event EventHandler UpdateCommand;
    public event EventHandler DeleteCommand;

    private Merchant_ApiURLPrensenter _presenter;


    public UC_UCUI_Master_Merchant_uc_ApiURL()
    {
        this._presenter = new Merchant_ApiURLPrensenter(this);
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
        gvItems.DataSource = Merchant_ApiURLs;
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
        EnumControl.GetEnumDescriptions<Constants.API_URL_Type>(ddlAPIType);
        EnumControl.GetEnumDescriptions<Constants.ApiScheduleType>(ddlApiScheduleType);
        ddlRunTime.DataSource = DateTimeAgo.GetTimeIntervals();
        ddlRunTime.DataBind();
    }
    protected void btnMerchantNameAdd_Click(object sender, EventArgs e)
    {
        EventHandler Insert = this.InsertCommand;
        if (Insert != null)
        {
            //lblMessage.Text = string.Empty;
            Insert(this, e);
            BindItems();            
        }
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> uidIds = new List<long>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 uid = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                uidIds.Add(uid);
            }
        }

        if (uidIds.Count > 0)
        {
            EventHandler delete = this.DeleteCommand;
            if (delete != null)
            {
                this.Ids = uidIds;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindItems();
            }
        }
    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(50, "...");
    }

    public int APIType
    {
        get
        {
            //if (ddlAPIType.SelectedIndex == 0)
            //{
            //    return Convert.ToInt32(Constants.API_URL_Type.Desktop);
            //}
            //else
            //{
            return Convert.ToInt32(Convert.ToInt32((Constants.API_URL_Type)Enum.Parse(typeof(Constants.API_URL_Type), ddlAPIType.SelectedValue.ToString())));
            //}

        }
        set
        {
            ddlAPIType.SelectedValue = Convert.ToInt32((Constants.API_URL_Type)Enum.Parse(typeof(Constants.API_URL_Type), value.ToString())).ToString();
        }
    }

    public string ApiName
    {
        get
        {
            return txtApiName.Text.Trim();
        }
        set
        {
            txtApiName.Text = value;
        }
    }

    public string ApiURL
    {
        get
        {
            return txtApiURL.Text.Trim();
        }
        set
        {
            txtApiURL.Text = value;
        }
    }

    public DateTime? ExpireOn
    {
        get
        {
            if (!string.IsNullOrEmpty(txtExpireOn.Text.Trim()))
                return Convert.ToDateTime(txtExpireOn.Text.Trim());
            else
                return null;
        }
        set
        {
            txtExpireOn.Text = value.ToString();
        }
    }

    public int ApiScheduleType
    {
        get
        {
            if (ddlAPIType.SelectedIndex == 0)
            {
                return Convert.ToInt32(Constants.ApiScheduleType.Month);
            }
            else
            {
                return Convert.ToInt32(Convert.ToInt32((Constants.ApiScheduleType)Enum.Parse(typeof(Constants.ApiScheduleType), ddlApiScheduleType.SelectedValue.ToString())));
            }

        }
        set
        {
            ddlApiScheduleType.SelectedValue = Convert.ToInt32((Constants.ApiScheduleType)Enum.Parse(typeof(Constants.ApiScheduleType), value.ToString())).ToString();
        }
    }

    public TimeSpan? RunOnTime
    {
        get
        {
            if (ddlRunTime.SelectedIndex > 0)
            {
                DateTime dateTime = DateTime.ParseExact(ddlRunTime.SelectedValue.ToString(), "hh:mm tt", CultureInfo.InvariantCulture);
                TimeSpan span = dateTime.TimeOfDay;
                return span;
            }
            else
                return null;
        }
        set
        {
            ddlApiScheduleType.SelectedValue = value.ToString();
        }
    }

    public string strMessage
    {
        set { lblMessage.Text = value; }
    }

    public List<long> Ids { get; set; }

   

    public List<Merchant_ApiURL> Merchant_ApiURLs { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }
   
}