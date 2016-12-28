using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Product_uc_VwProductList : System.Web.UI.UserControl, IVW_Product
{
    private VW_ProductPrensenter _presenter;
    public event EventHandler RefreshCommand;
    public UC_UCUI_Product_uc_VwProductList()
    {
        this._presenter = new VW_ProductPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EventHandler refresh = this.RefreshCommand;
            refresh(sender, e);
            BindVWProduct();
            UserCtrl();
        }
    }


    private void BindVWProduct()
    {
        //gvItems.DataSource = ProductVW;
        //gvItems.DataBind();
        //if (gvItems.Rows.Count > 0)
        //{
        //    gvItems.UseAccessibleHeader = true;
        //    gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
        //}

    }
    public string ReduceString(string obj)
    {
        return obj.Truncate(50, "...");
    }

    public List<vw_Product> ProductVW
    {
        get;
        set;
    }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }


    public event EventHandler DeleteCommand;


    public List<long> Ids { get; set; }
    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> offerIds = new List<Int64>();
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
                this.Ids = offerIds;
                //lblMessage.Text = string.Empty;
                delete(this, e);
                BindVWProduct();
            }
        }
    }


    public int pageIndex
    {
        get;
        set;
    }

    public int pageSize
    {
        get;
        set;
    }

    public int totalRecord
    {
        get;
        set;
    }

    public event EventHandler PagingCommand;



    protected void rblProductFeed_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserCtrl();            
    }


    private void UserCtrl()
    {
        if (rblProductFeed.SelectedValue == "0")
        {
            uc_ProductCommonList.Visible = true;
            uc_LiveProductFeedDataList.Visible = false;
            uc_OMG_Excel_Product_FeedItems.Visible = false;
            uc_LiveXmlProductFeed1.Visible = false;
        }
        else if (rblProductFeed.SelectedValue == "1")
        {
            uc_ProductCommonList.Visible = false;
            uc_LiveProductFeedDataList.Visible = true;
            uc_OMG_Excel_Product_FeedItems.Visible = false;
            uc_LiveXmlProductFeed1.Visible = false;
        }
        else if (rblProductFeed.SelectedValue == "3")
        {
            uc_LiveXmlProductFeed1.Visible = true;
            uc_ProductCommonList.Visible = false;
            uc_LiveProductFeedDataList.Visible = false;
            uc_OMG_Excel_Product_FeedItems.Visible = false;
        }
        else
        {
            uc_ProductCommonList.Visible = false;
            uc_LiveProductFeedDataList.Visible = false;
            uc_LiveXmlProductFeed1.Visible = false;
            uc_OMG_Excel_Product_FeedItems.Visible = true;
        }
    }
}