using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EntityData;
using System.IO;

public partial class Admin_Default : AdminBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindApi();
    }

    private void BindApi()
    {
        EnumControl.GetEnumDescriptions<Constants.MailFormatContentType>(ddlTemplateType);
    }

    protected void btnRunTemplateDesign_Click(object sender, EventArgs e)
    {
        StringBuilder templateItems = new StringBuilder();
        if (ddlTemplateType.SelectedValue.ToString() == Constants.MailFormatContentType.ImageContent.ToString())
        {
            using (Ad_ConnectionString model = new Ad_ConnectionString())
            {
                int bannerLocation = Convert.ToInt32(Constants.BannerLocation.EmailImageMarketing);
                var varlist = (from var in model.Adv_Trn_Banners
                               where var.BannerLocation == bannerLocation
                               select var).ToList();

                foreach (Adv_Trn_Banner item in varlist)
                {
                    string mNamed;
                    if (item.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf(".") >= 0)
                    {
                        mNamed = item.Adv_Mst_Merchant.MerchantNameDetail.Substring(0, item.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf("."));
                    }
                    else
                    {
                        mNamed = item.Adv_Mst_Merchant.MerchantNameDetail;
                    }

                    templateItems.Append(ImagetemplateBuilder(item.BannerURL, mNamed, item.BannerText, item.Description));
                }

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/MailFormat/ImageTemplateMarketing.htm")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{AddImages}", templateItems.ToString());

                txtCodeGenerate.Text = body;

                //Update Contaent in DB --------------------------------------------------------------
                Int16 mailFormatType=Convert.ToInt16(Constants.MailFormatContentType.ImageContent);
                var contentMail = (from pro in model.Adv_MailContents
                                   where pro.MailType == mailFormatType
                                   select pro).SingleOrDefault();

                if (contentMail != null)
                 {
                     contentMail.MailContent = body;                   
                     model.SaveChanges();
                 }
                 else
                 {
                     Adv_MailContent mailContent = new Adv_MailContent();
                     mailContent.MailContent = body;
                     mailContent.MailType = Convert.ToInt16(Constants.MailFormatContentType.ImageContent);
                     model.AddToAdv_MailContents(mailContent);
                     model.SaveChanges();
                 }
            }
        }
        else if (ddlTemplateType.SelectedValue.ToString() == Constants.MailFormatContentType.OfferContent.ToString())
        {
            using (Ad_ConnectionString model = new Ad_ConnectionString())
            {
                Int64 offTYpe = Convert.ToInt64(Constants.FeatureTypeOffer.FeatureOffer);
                var varlist = (from var in model.Adv_Offers
                               where model.Adv_FeatureOffer1.Where(w=>w.OfferType==offTYpe).Select(s=>s.OfferID).Contains(var.OfferID)
                               select var).ToList();
                int offerCount = 1;
                foreach (Adv_Offer item in varlist)
                {
                    string mNamed;
                    if (item.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf(".") >= 0)
                    {
                        mNamed = item.Adv_Mst_Merchant.MerchantNameDetail.Substring(0, item.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf("."));
                    }
                    else
                    {
                        mNamed = item.Adv_Mst_Merchant.MerchantNameDetail;
                    }

                    string comision = string.Empty;
                    //Constants.PriceType.INR
                    //int? priceType = 1;
                    var com=(from c in model.Adv_Commisions
                            where c.MerchantID==item.Adv_Mst_Merchant.MID
                             select c).OrderByDescending(x => x.UserCommision).FirstOrDefault();


                    if (offerCount == 1)
                    {
                        templateItems.Append(OffertemplateBuilder("<tr>","divLeft", item.Adv_Mst_Merchant.LogoUrl, mNamed, item.Title, com.UserCommision+getPiceType(com.PriceType),""));
                    }
                    else if (offerCount == 2)
                    {
                        templateItems.Append(OffertemplateBuilder("", "divLeft", item.Adv_Mst_Merchant.LogoUrl, mNamed, item.Title, com.UserCommision + getPiceType(com.PriceType), ""));                       
                    }
                    else
                    {
                        templateItems.Append(OffertemplateBuilder("", "divLeft", item.Adv_Mst_Merchant.LogoUrl, mNamed, item.Title, com.UserCommision + getPiceType(com.PriceType), "</tr>"));
                        if (offerCount == 3)
                        {
                            offerCount = 0;
                        }
                    }
                    offerCount = offerCount + 1;
                }

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/MailFormat/OfferTemplateMarketing.htm")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{Addoffer}", templateItems.ToString());

                txtCodeGenerate.Text = body;

                //Update Contaent in DB --------------------------------------------------------------
                Int16 mailFormatType = Convert.ToInt16(Constants.MailFormatContentType.OfferContent);
                var contentMail = (from pro in model.Adv_MailContents
                                   where pro.MailType == mailFormatType
                                   select pro).SingleOrDefault();

                if (contentMail != null)
                {
                    contentMail.MailContent = body;
                    model.SaveChanges();
                }
                else
                {
                    Adv_MailContent mailContent = new Adv_MailContent();
                    mailContent.MailContent = body;
                    mailContent.MailType = Convert.ToInt16(Constants.MailFormatContentType.OfferContent);
                    model.AddToAdv_MailContents(mailContent);
                    model.SaveChanges();
                }

            }


        }
    }

    private string getPiceType(int? i)
    {
        if (i == 1)
            return " INR";
        else
            return "%";
    }


    private string ImagetemplateBuilder(string ImageURL,string mName,string Title,string description)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<tr><td class='img'><a href=http://www.cashonshop.com/Merchant/" + mName + "><img src='" + ImageURL + "' alt=" + mName + " width='650' border='0'    style='display: inline-block;'></a></td></tr><tr><td align='center' valign='middle'><span class='txt_pdng' style='font-family: Arial; font-size: 12px; color: #343434;                                        line-height: 22px; font-weight: bold;'>" + Title + " " + description + " Extra Cashback from CASHONSHOP </span>                                </td>                            </tr>");

        return sb.ToString();
    }

    private string OffertemplateBuilder(string startTr,string divClass,string mImageURL, string mName, string OfferTitle, string extraCashback,string endtr)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat(startTr + "<td style='height: 225px;width: 208px;border: 1px solid #cccccc;'> <table border='0' cellspacing='5'>                                                   <tr>                                                        <td style='height: 30px; text-align: center; margin-top: 2px; margin-bottom: 10px;'><a href=http://www.cashonshop.com/Merchant/" + mName + "><img src=" + mImageURL + " height='28' border='0' style='display: inline-block;'></a></td>                                                   </tr><tr>                                                        <td style='height: 110px; text-align: center; margin-bottom: 10px; font-weight: bold;                                                            font-family: Verdana; font-size: 12px; text-decoration: none; line-height: 22px;                                                            color: #2a2a2a; padding: 0px 2px;'> " + OfferTitle + "  </td>                                                    </tr> <tr>                                                        <td style='height: 30px; text-align: center; margin-bottom: 5px; margin-top: 5px;                                                            font-weight: bold; font-family: Verdana; font-size: 12px; line-height: 15px;                                                            color: #149da8; text-transform: uppercase;'>+ Upto " + extraCashback + " Extra Cashback cashback  </td>                                                    </tr> <tr >                                                        <td style='height: 10px; text-align: center; margin-top: 10px!important; margin-bottom: 5px;'>                                                        <a href=http://www.cashonshop.com/Merchant/" + mName + " style='border: 1px solid #000000; font-size: 11px; background-color: #CE3000;font-family: Verdana; color: #FFFFFF; font-weight: bold; text-transform: uppercase;padding: 5px; margin-bottom: 5px;'>Grab now </a></td>                                                    </tr>                                                </table></td>" + endtr);      

        return sb.ToString();
    }
}