using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MerchantOffers : BasePage, IMerchantListView
{
    string viewMerchant = string.Empty;



     private MerchantListPrensenter _presenter;

     public MerchantOffers()
    {
        //Page.RouteData.Values as string;
         
        //if (HttpContext.Current.Request.QueryString.HasKeys())
        //{
        //    this.MerchantName = HttpContext.Current.Request.QueryString["m"];
           
        //}
        if (Page.RouteData.Values.ContainsKey("pageTitle"))
        {
            string[] pageTitle = (Page.RouteData.Values["pageTitle"] as string).Split('.');
            this.MerchantName = pageTitle[0];
        }
        else
        { Response.Redirect("~/Default.aspx",true); }

        this._presenter = new MerchantListPrensenter(this);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
       // string profi = Profile.FirstName;
        //if (Request.QueryString.HasKeys())
        //{
        //    viewMerchant = Request.QueryString["m"].ToString();

        //}
        //else
        //{
        //    Response.Redirect("~/Default.aspx");
        //}

        if (!IsPostBack)
        {
            //if (viewMerchant == string.Empty)
            //    viewMerchant = Constants.NameOfMerchants.Amazon.ToString();
            BindItems();
            uc_ExtraCashBackList.MerchantName = this.MerchantName;
        }
    }


    private void BindItems()
    {
        //Constants.NameOfMerchants e = (Constants.NameOfMerchants)Enum.Parse(typeof(Constants.NameOfMerchants), viewMerchant);
        fmViewMerchantsHeader.DataSource = Merchants;
        fmViewMerchantsHeader.DataBind(); 
        fmViewMerchants.DataSource = Merchants;//.Where(m => m.MerchantNameDetail==viewMerchant).ToList();//== Convert.ToInt32((Constants.NameOfMerchants)Enum.Parse(typeof(Constants.NameOfMerchants), viewMerchant))).ToList();
        fmViewMerchants.DataBind();
        //var br=Merchants.Select(b => b.Merchant_BreakDowns).ToList();
        uc_BreakDownCommsionDescription.BindBreakDown = (from parent in Merchants
                                                        //where parent.Children.Any(c => c.CategoryNumber == 1)
                                                        select parent into p
                                                        from child in p.Merchant_BreakDowns
                                                        //where child.CategoryNumber == 2
                                                        select child).ToList();// Merchants.Select(p => from c in p.Merchant_BreakDowns
                                                         //                     select c);

        var add_Seo = (from m in Merchants
                      where m.MerchantNameDetail.Contains(this.MerchantName)
                      select m).SingleOrDefault();
        if (add_Seo != null)
        {
            if (!string.IsNullOrEmpty(add_Seo.Seo_Title))
                Page.Title = add_Seo.Seo_Title;
            if (!string.IsNullOrEmpty(add_Seo.Seo_Keyword))
                Page.MetaDescription = add_Seo.Seo_Description;
            if (!string.IsNullOrEmpty(add_Seo.Seo_Keyword))
                Page.MetaKeywords = add_Seo.Seo_Keyword;
        }
    }


    public List<Merchant> Merchants { get; set; }

    public string MID { get; set; }

    public string MerchantName { get; set; }


    public event EventHandler ViewCommand;
}