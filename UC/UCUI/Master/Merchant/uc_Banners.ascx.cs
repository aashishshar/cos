using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class UC_UCUI_Master_Merchant_uc_Banners : System.Web.UI.UserControl,IMerchant_BannerListView
{
   private Merchant_BannerListPrensenter _presenter;



   public UC_UCUI_Master_Merchant_uc_Banners()
    {
        BannerType = Convert.ToInt32(Constants.BannerLocation.LeftTop);
        this._presenter = new Merchant_BannerListPrensenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {          
            BindItems();
        }
    }

    public string ReduceString(string obj)
    {
        return obj.Truncate(40, "...");
    }


    private void BindItems()
    {
        rptItem.DataSource = Merchant_Banners;
        rptItem.DataBind();
    }

    //public string GetImagesInHTMLString(string htmlString, string width, string height)
    //{
    //    string images=string.Empty;//= new List<string>();
    //    String HTML = htmlString;
    //    Regex reImg = new Regex(@"<img\s[^>]*>", RegexOptions.IgnoreCase);
    //    Regex reHeight = new Regex(@"height=(?:(['""])(?<height>(?:(?!\1).)*)\1|(?<height>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //    Regex reWidth = new Regex(@"width=(?:(['""])(?<width>(?:(?!\1).)*)\1|(?<width>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //    Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    //    MatchCollection mc = reImg.Matches(HTML);
    //    foreach (Match mImg in mc)
    //    {
    //         string imageUrl=string.Empty;
    //        //Console.WriteLine("    img tag: {0}", mImg.Groups[0].Value);
    //        if (reHeight.IsMatch(mImg.Groups[0].Value))
    //        {
    //            Match mHeight = reHeight.Match(mImg.Groups[0].Value);
    //            //Console.WriteLine("  height is: {0}", mHeight.Groups["height"].Value);
    //        }
    //        if (reWidth.IsMatch(mImg.Groups[0].Value))
    //        {
    //            Match mWidth = reWidth.Match(mImg.Groups[0].Value);
    //            //Console.WriteLine("   width is: {0}", mWidth.Groups["width"].Value);
    //        }
    //        if (reHeight.IsMatch(mImg.Groups[0].Value))
    //        {
    //            Match mSrc = reSrc.Match(mImg.Groups[0].Value);
    //            imageUrl = "Handler/ImageResizeHandler.ashx?width=" + width + "&height=" + height + "&imgPath=" + mSrc.Groups["src"].Value;
    //            //images.Add(mSrc.Groups["src"].Value);
    //            //Console.WriteLine("     src is: {0}", mSrc.Groups["src"].Value);
    //        }


    //        string newImageSRC = "<img src='" + imageUrl + "'/>";

    //        images = htmlString.Replace(mImg.Groups[0].Value, newImageSRC);
    //    }





    //    //List<string> images = new List<string>();
    //    //string pattern = @"<(img)\b[^>]*>";// "<img.+?src=[\"'](.+?)[\"'].+?>";
    //    //    //@"<(img)\b[^>]*>";

    //    //Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
    //    //MatchCollection matches = rgx.Matches(htmlString);

    //    //for (int i = 0, l = matches.Count; i < l; i++)
    //    //{
    //    //    images.Add(matches[i].Value);
    //    //}

    //    return images;
    //}

    public List<Merchant_Banner> Merchant_Banners { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }

    public int? BannerType { get; set; }


    public int? CategoryType { get; set; }


    public int? Price { get; set; }

    public int? DiscountedPrice { get; set; }

    public string Description { get; set; }
}