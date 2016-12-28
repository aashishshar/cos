using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityData;

public partial class Admin_FeatureOffers : AdminBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindApi();
            getFeatureslist();
        }
    }

    private void BindApi()
    {
        EnumControl.GetEnumDescriptions<Constants.FeatureTypeOffer>(ddlOfferType);
    }
    protected void btnGetOffers_Click(object sender, EventArgs e)
    {
        BindOffersList();
    }

    private void getFeatureslist()
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Offers
                           where model.Adv_FeatureOffer1.Select(s => s.OfferID).Contains(var.OfferID)
                           select var).ToList();
            gvItems.DataSource = varlist;
            gvItems.DataBind();
            gvItems.Caption = "Feature Offers";
        }
    }

    private void BindOffersList()
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            Int64 mid = Convert.ToInt64(uc_MerchantListItem.SelectedMerchant);
            var varlist = (from var in model.Adv_Offers
                           where var.MID == mid && var.ValidTill>=DateTime.Now
                           select var).ToList();
            
            gvItems.DataSource = varlist;
            gvItems.DataBind();
            gvItems.Caption = "Live Offers";
        }
    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        List<Int64> offerIds = new List<Int64>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                using (Ad_ConnectionString model = new Ad_ConnectionString())
                {
                    model.Adv_FeatureOffer1.Where(x => x.OfferID == offerID).ToList().ForEach(model.Adv_FeatureOffer1.DeleteObject);
                    model.SaveChanges();           
                }
            }
        }

        getFeatureslist();
    
    }
    protected void lkbFeatureOffer_Click(object sender, EventArgs e)
    {
        List<Int64> offerIds = new List<Int64>();
        foreach (GridViewRow row in gvItems.Rows)
        {
            if (((CheckBox)row.FindControl("chkRow")).Checked)
            {

                Int64 offerID = Convert.ToInt32(gvItems.DataKeys[row.RowIndex].Value);
                using (Ad_ConnectionString model = new Ad_ConnectionString())
                {
                    Adv_FeatureOffer1 offer = new Adv_FeatureOffer1();
                    offer.OfferID = offerID;
                    offer.OfferType = Convert.ToInt16(Convert.ToInt32((Constants.FeatureTypeOffer)Enum.Parse(typeof(Constants.FeatureTypeOffer), ddlOfferType.SelectedValue.ToString())));
                    model.AddToAdv_FeatureOffer1(offer);
                    model.SaveChanges();
                }
            }
        }

        BindOffersList();
    }
}