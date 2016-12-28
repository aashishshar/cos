using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Product_uc_VwProduct : System.Web.UI.UserControl,IVW_Product
{

    private VW_ProductPrensenter _presenter;    
    public UC_UCUI_Product_uc_VwProduct()
    {
        this._presenter = new VW_ProductPrensenter(this);       
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pageSize = 28;
        if(!IsPostBack)
        {
            EventHandler paging = this.PagingCommand;
            this.pageIndex = 1;
            paging(this, e);
            BindVWProduct(pageIndex);
        }
    }
   
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(this.pageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        EventHandler paging = this.PagingCommand;
        if (paging != null)
        {
            this.pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.pageSize = 28;
            paging(this, e);
            int totalRecord = this.totalRecord;
            BindVWProduct(pageIndex);
        }

    }



    private void BindVWProduct(int pageIndex)
    {
        dlItems.ProductItemBind(ProductVW);        
        int recordCount = this.totalRecord;
        this.PopulatePager(recordCount, pageIndex);

    }
    public string ReduceString(string obj)
    {
        if (obj != null)
        {
            return obj.Truncate(45, "...");
        }
        else
        {
            return "";
        }
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


    public List<long> Ids { get; set; }

    public event EventHandler DeleteCommand;


    public int pageIndex { get; set; }

    public int pageSize { get; set ; }

    public int totalRecord { get; set; }

    public event EventHandler PagingCommand;


    public event EventHandler RefreshCommand;
}