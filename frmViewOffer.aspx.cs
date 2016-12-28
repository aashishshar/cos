using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;
using System.Text;

public partial class frmViewOffer : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.RouteData.Values.ContainsKey("OfferID"))
        {
            string OfferID = Page.RouteData.Values["OfferID"] as string;

            Int64 offID = Convert.ToInt64(OfferID);
            using (Ad_ConnectionString model = new Ad_ConnectionString())
            {
                var url = (from u in model.Adv_Offers
                           where u.OfferID == offID
                           select u).ToList();
                rpItems.DataSource = url;
                rpItems.DataBind();
                var p = url.Select(o => o).SingleOrDefault();
                Page.Title = p.Adv_Mst_Merchant.MerchantNameDetail + " | " + p.Title;
                Page.MetaDescription = p.Description;
                Page.MetaKeywords = p.Adv_Mst_Merchant.MerchantNameDetail;
                uc_ExtraCashBackList.MerchantName = p.Adv_Mst_Merchant.MerchantNameDetail;
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    public bool IsUserLogin()
    {
        if (Page.User.Identity.IsAuthenticated)
            return true;
        else
            return false;
    }
}