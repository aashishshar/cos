using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityData;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Configuration;
using System.Data.Entity;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsCommonMethods
/// </summary>
public class clsCommonMethods
{
    string userID = string.Empty;
    bool IsUserLogin = false;
    public clsCommonMethods()
    {
        //if (HttpContext.Current.Session["UserID"] == null)
        //{
        //    HttpContext.Current.Session["UserID"] = "Ashish";
        //    userName = "Ashish";
        //}
        //else
        //{
        //    userName = HttpContext.Current.Session["UserID"].ToString();
        //}
    }

    private void assignUSERID()
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if (string.IsNullOrEmpty(userID))
            {
                userID = GetGlobalUserID();
                if (userID == "0")
                    userID = null;
            }
            IsUserLogin = true;
        }
    }

    #region IMstCategoryService Members

    public Category GetCategoryByID(int catID)
    {

        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            try
            {
                Int16 currentStatus = Convert.ToInt16(Constants.Status.Active);
                Category q = new Category();
                var catDetails = (from cat in model.Mst_Categories
                                  where cat.CategoryID_N == catID
                                  select cat).FirstOrDefault();
                q = DTO_Category(catDetails);
                return q;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public Category GetCategoryIDByText(string CategorySearchText)
    {

        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            try
            {
                Int16 currentStatus = Convert.ToInt16(Constants.Status.Active);
                Category q = new Category();
                var catDetails = (from cat in model.Mst_Categories
                                  where CategorySearchText.Contains(cat.CategoryName_V)
                                  select cat).FirstOrDefault();
                q = DTO_Category(catDetails);
                return q;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public List<Category> GetAllCategories()
    {
        try
        {
            Int16 currentStatus = Convert.ToInt16(Constants.Status.Active);
            List<Category> vList = new List<Category>();
            using (Ad_ConnectionString model = new Ad_ConnectionString())
            {
                var varlist = (from var in model.Mst_Categories
                               // where var.Status_N == currentStatus
                               select var).OrderBy(o => o.CategoryName_V);

                foreach (Mst_Category var in varlist)
                {

                    Category q = new Category();
                    q = DTO_Category(var);
                    vList.Add(q);
                }
            }
            return vList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void InsertCategory(Category catDetails)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            Mst_Category var = new Mst_Category();
            var.CategoryName_V = catDetails.CategoryName_V;
            var.CreatedDate = DateTime.Now;
            //var.MCategoryName_V = catDetails.MCategoryName_V;
            var.ParentCategoryID_N = catDetails.ParentCategoryID_N;
            var.Status_N = Convert.ToInt16(catDetails.Status_N);
            model.AddToMst_Categories(var);
            model.SaveChanges();    
        }
    }

    public void DeleteCategory(int catID)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Mst_Categories.Where(x => x.CategoryID_N == catID).ToList().ForEach(model.Mst_Categories.DeleteObject);

            model.SaveChanges();
        }
    }

    public List<Category> DTO_Categories(EntityCollection<Mst_Category> _sub_categories)
    {
        List<Category> vList = new List<Category>();
        foreach (Mst_Category var in _sub_categories)
        {
            Category sub_category = new Category();
            sub_category = DTO_Category(var);
            vList.Add(sub_category);
        }

        return vList;
    }

    public Category DTO_Category(Mst_Category _category)
    {
        Category category = new Category();
        if (_category != null)
        {
            category.CategoryID_N = _category.CategoryID_N;
            category.CategoryName_V = _category.CategoryName_V;
            //category.MCategoryName_V = _category.MCategoryName_V;
            category.ParentCategoryID_N = _category.ParentCategoryID_N;
            if (_category.Mst_SubCategory != null)
                category.SubCategory = DTO_SubCategories(_category.Mst_SubCategory);
            category.Status_N = (Constants.Status)_category.Status_N;
            category.CreatedBy = _category.CreatedBy;           
            category.CreatedDate = _category.CreatedDate;
            category.ModifiedDate = _category.UpdatedDate;

        }

        return category;
    }

    #endregion

    #region ISubCategoryService Members

    public List<Sub_Category> GetAllSubCategories()
    {
        List<Sub_Category> vList = new List<Sub_Category>();
        int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Mst_SubCategories
                           select var);
            foreach (Mst_SubCategory var in varlist)
            {
                Sub_Category q = new Sub_Category();
                q = DTO_SubCategory(var);

                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Sub_Category> GetAllSubCategoriesByID(int categoryID_N)
    {
        List<Sub_Category> vList = new List<Sub_Category>();
        int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Mst_SubCategories
                           where var.CategoryID_N == categoryID_N
                           && var.Status_N == CurrentStatus
                           select var);

            foreach (Mst_SubCategory var in varlist)
            {
                Sub_Category q = new Sub_Category();
                q = DTO_SubCategory(var);
                //q.SubCategoryID_N = var.SubCategoryID_N;                    
                //q.SubCategoryName_V = var.SubCategoryName_V;
                vList.Add(q);
            }
        }
        return vList;
    }

    public void InsertSubCategory(Sub_Category subCatDetails)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            Mst_SubCategory var = new Mst_SubCategory();
            var.SubCategoryName_V = subCatDetails.SubCategoryName_V;
            var.CategoryID_N = subCatDetails.CategoryID_N;
            var.SubCategoryName_V = subCatDetails.SubCategoryName_V;
            var.CreatedDate = DateTime.Now;
            // var.CreatedBy = subCatDetails.CreatedBy;
            var.Status_N = Convert.ToInt16(Constants.Status.Active);
            model.AddToMst_SubCategories(var);
            model.SaveChanges();
        }
    }



    public void DeleteSubCategory(int subCatID)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Mst_SubCategories.Where(x => x.SubCategoryID_N == subCatID).ToList().ForEach(model.Mst_SubCategories.DeleteObject);

            model.SaveChanges();
        }
    }


    public List<Sub_Category> DTO_SubCategories(EntityCollection<Mst_SubCategory> _sub_categories)
    {
        List<Sub_Category> vList = new List<Sub_Category>();
        foreach (Mst_SubCategory var in _sub_categories)
        {
            Sub_Category sub_category = new Sub_Category();
            sub_category = DTO_SubCategory(var);
            vList.Add(sub_category);
        }

        return vList;
    }

    public Sub_Category DTO_SubCategory(Mst_SubCategory _sub_category)
    {
        Sub_Category sub_category = new Sub_Category();
        if (_sub_category != null)
        {
            sub_category.CategoryID_N = _sub_category.CategoryID_N;
            sub_category.CategoryName_V = _sub_category.Mst_Category.CategoryName_V;
            sub_category.SubCategoryID_N = _sub_category.SubCategoryID_N;
            sub_category.SubCategoryName_V = _sub_category.SubCategoryName_V;
            sub_category.Status_N = (Constants.Status)_sub_category.Status_N;
            //sub_category.Products_Common = DTO_ProductCommons(_sub_category.Adv_Product_Common);
            sub_category.CreatedBy = _sub_category.CreatedBy;
            sub_category.CreatedDate = _sub_category.CreatedDate;
            sub_category.ModifiedDate = _sub_category.UpdatedDate;
            //sub_category.UpdatedDate = _sub_category.UpdatedDate;
            // sub_category.DeletedBy = _sub_category.DeletedBy;
            //sub_category.DeletedDate = _sub_category.DeletedDate;
        }

        return sub_category;
    }

    #endregion

    #region "ProductCommon"

    public List<vw_Product> GetAll_Proc_Product(int pageIndex,int pageSize,out int totalRecord )
    {
        DataTable dt = new DataTable();
        List<vw_Product> vList = new List<vw_Product>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var oMyString = new ObjectParameter("RecordCount", typeof(int));
            //var oMyStringDT = new ObjectParameter("RecordCount", typeof(DataTable));

            var list = (from var in model.GetOfferItemPageWise(pageIndex, pageSize, oMyString, "", "", "", "M") select var).ToList();
            totalRecord = Convert.ToInt32(oMyString.Value.ToString());


            foreach (vw_OfferItem var in list)
            {
                vw_Product q = new vw_Product();
                q = DTO_ProductCommonVW(var);
                vList.Add(q);
            }
        }
        return vList;
    }



    public void DeleteCommonProduct(List<Int64> ids)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Product_Commons.Where(x => ids.Contains(x.ProductID)).ToList().ForEach(model.Adv_Product_Commons.DeleteObject);

            model.SaveChanges();
        }
    }
    public void InsertCommonProduct(Product_Common _product)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            Int16 merchantID = Convert.ToInt16(_product.Ad_For);

            model.Adv_Product_Commons.Where(x => x.Ad_For == merchantID).ToList().ForEach(model.Adv_Product_Commons.DeleteObject);

            var original = (from pro in model.Adv_Product_Commons
                            where (pro.SKUID == _product.SKUID || pro.MerchantProductID == _product.MerchantProductID) && (pro.Ad_For==_product.MID)
                            select pro).SingleOrDefault();

            if (original != null)
            {
                original.Description = _product.Description;
                original.ProductPrice = _product.ProductPrice;
                original.ProductPrice = _product.ProductPrice;
                original.DiscountedPrice = _product.DiscountedPrice;
                original.Color = _product.Color;
                original.NavigationURL = _product.NavigationURL;
                original.ImageUrl = _product.ImageUrl;
                original.ModifiedDate = DateTime.Now;
                model.SaveChanges();
            }
            else
            {
                if (_product.Ad_Type == Constants.APITypeURL.FlipKart_TOP_Offers_API || _product.Ad_Type == Constants.APITypeURL.FlipKart_DOTD_OffersAPI)
                {
                    Adv_Offer var = new Adv_Offer();
                    var.MID = _product.MID;
                    var.Title = _product.Title;// string.IsNullOrEmpty(_product.Description) != null ? _product.Title + " on " + _product.Description : _product.Title;
                    var.Description = _product.Description;
                    //var.Description = _product.Description;
                    var.ValidTill =DateTime.Now.AddDays(1);
                    var.NavigationURL = clsUtility.GetDeeplinkInHTMLString(_product.NavigationURL);
                    //var.CouponCode = _Offer.CouponCode;
                    var.OfferForDevice = Convert.ToInt16(Constants.Device.Desktop);
                    var.CouponCode = "No Coupon required.";
                    var.ActivationDate = DateTime.Now;
                    var.OfferType = _product.Ad_Type == Constants.APITypeURL.FlipKart_TOP_Offers_API ? Convert.ToInt16(Constants.Adv_Type.TopOffer) : Convert.ToInt16(Constants.Adv_Type.DOTD);
                    var.ImageUrl = _product.ImageUrl;
                    //var.OfferForDevice = Convert.ToInt16(_product.CouponForDevice);
                    var.CreatedDate = DateTime.Now;


                    model.AddToAdv_Offers(var);
                    model.SaveChanges();


                }
                else
                {
                    Adv_Product_Common item = new Adv_Product_Common();
                    item.Availability = _product.Availability;
                    item.CreatedBy = _product.CreatedBy;
                    item.CreatedDate = _product.CreatedDate;
                    item.Description = _product.Description;
                    item.ImageUrl = _product.ImageUrl;
                    item.ModifiedDate = _product.ModifiedDate;
                    item.NavigationURL = clsUtility.GetDeeplinkInHTMLString(_product.NavigationURL);

                    item.ProductCategoryName = _product.ProductCategoryName;

                    var sNo = (from s in model.Adv_Product_Commons
                               where s.Ad_For == _product.MID
                               select s.SerialNo).Max();

                    if (sNo != null)
                        item.SerialNo = sNo + 1;
                    else
                        item.SerialNo = 1;


                    if (_product.CategoryID_N.HasValue)
                        item.CategoryID_N = _product.CategoryID_N;
                    item.Title = ReduceString(_product.Title, 299);
                    //if (Convert.ToInt32(_product.Ad_Type) > 0)
                    item.Ad_Type = Convert.ToInt32(_product.Ad_Type);
                    item.PID = _product.PID;
                    //item.Ad_For = Convert.ToInt32(_product.Ad_For);
                    item.Ad_For = _product.MID;
                    item.MerchantProductID = _product.MerchantProductID;
                    item.SKUID = _product.SKUID;
                    item.ProductPrice = _product.ProductPrice;
                    item.DiscountedPrice = _product.DiscountedPrice;
                    item.Brand = _product.Brand;
                    item.Color = _product.Color;
                    item.ProductPriceCurrency = _product.ProductPriceCurrency;
                    item.Location = _product.Location;
                    item.Custom1 = _product.Custom1;
                    item.Custom2 = _product.Custom2;
                    item.Custom3 = _product.Custom3;

                    model.AddToAdv_Product_Commons(item);
                    model.SaveChanges();
                }
            }
        }
    }

    public string ReduceString(string obj,int count)
    {
        return obj.Truncate(count, "...");
    }
    public List<Product_Common> DTO_ProductCommons(EntityCollection<Adv_Product_Common> _products)
    {
        List<Product_Common> vList = new List<Product_Common>();
        foreach (Adv_Product_Common var in _products)
        {
            Product_Common item = new Product_Common();
            item = DTO_ProductCommon(var);
            vList.Add(item);
        }

        return vList;
    }

    public Product_Common DTO_ProductCommon(Adv_Product_Common _product)
    {
        Product_Common item = new Product_Common();
        if (_product != null)
        {
            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            item.Availability = _product.Availability;
            item.CreatedBy = _product.CreatedBy;
            item.CreatedDate = _product.CreatedDate;
            item.Description = _product.Description;
            item.ImageUrl = _product.ImageUrl;
            item.ModifiedDate = _product.ModifiedDate;
            item.NavigationURL = IsUserLogin ? _product.NavigationURL.Replace("=cos", "=" + userID) : _product.NavigationURL; 
            item.ProductID = _product.ProductID;
            item.ProductCategoryName = _product.ProductCategoryName;
            item.SerialNo = _product.SerialNo.Value;
            item.CategoryID_N = _product.CategoryID_N.Value;
            item.Title = _product.Title;
            item.Location = _product.Location;
            item.Custom1 = _product.Custom1;
            item.Custom2 = _product.Custom2;
            item.Custom3 = _product.Custom3;
            item.PID = _product.PID;
        }

        return item;
    }


    #endregion

    #region "view ProductCommon"
    public List<vw_Product> GetAll_VW_Products()
    {
        
        List<vw_Product> vList = new List<vw_Product>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.vw_OfferItems
                           select var);

            foreach (vw_OfferItem var in varlist)
            {
                vw_Product q = new vw_Product();
                q = DTO_ProductCommonVW(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<vw_Product> GetAll_VW_ProductsWithMID(int MID)
    {

        List<vw_Product> vList = new List<vw_Product>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.vw_OfferItems
                           where var.MerchantName==MID
                           select var);

            foreach (vw_OfferItem var in varlist)
            {
                vw_Product q = new vw_Product();
                q = DTO_ProductCommonVW(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<vw_Product> DTO_ProductsVW(EntityCollection<vw_OfferItem> _products)
    {
        List<vw_Product> vList = new List<vw_Product>();
        foreach (vw_OfferItem var in _products)
        {
            vw_Product item = new vw_Product();
            item = DTO_ProductCommonVW(var);
            vList.Add(item);
        }

        return vList;
    }

    public vw_Product DTO_ProductCommonVW(vw_OfferItem _product)
    {
        assignUSERID();      

        vw_Product item = new vw_Product();
        if (_product != null)
        {
            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            item.ID = _product.ID;
            item.MerchantName = _product.MerchantName;
            item.MerchantLogourl = _product.MerchantLogoUrl ;//? clsImageUrl.GetMerchantImage((Constants.NameOfMerchants)Enum.Parse(typeof(Constants.NameOfMerchants), _product.MerchantName.Value.ToString())) : _product.MerchantLogoUrl;
            item.AdType = _product.AdType;

            item.MName =_product.MerchantNameDetail.ToString();
            //item.MName = _product..MerchantName.Value).ToString();
            item.AdTypeName = ((Constants.APITypeURL)_product.AdType.Value).ToString();
            item.CategoryName = _product.CategoryName_V;
            item.ProductTitle = _product.ProductTitle;
            item.Description = _product.Description;
            item.ImageUrl = _product.ImageUrl;

            item.Availability = _product.Availability;
            item.NavigationURL = IsUserLogin ? _product.NavigationURL.Replace("=cos", "=" + userID) : _product.NavigationURL;
            item.SerialNo = _product.SerialNo.Value;
            if (_product.CreatedDate.HasValue)
                item.CreatedDate = _product.CreatedDate.Value;
            item.ModifiedDate = _product.ModifiedDate;
            item.CreatedBy = _product.CreatedBy;

            item.ProductPrice =Convert.ToSingle(_product.ProductPrice);//.HasValue ? Convert.ToSingle(_product.ProductPrice) : null;
            item.DiscountedPrice =Convert.ToSingle(_product.DiscountedPrice);
            if (item.DiscountedPrice > 0)
            {
                double percentagePrice = 100 - (Convert.ToSingle(_product.DiscountedPrice) * 100 / Convert.ToSingle(_product.ProductPrice));
                if (Math.Round(percentagePrice) > 0)
                {
                    item.DiscountPercentage = "<span style='text-decoration:line-through;'><b>Rs " + _product.ProductPrice.ToString() + "</b></span>" + " " + "<span style='color: Black;'><b>Rs " + _product.DiscountedPrice.ToString() + "</b></span> " + " " + " <span style='color: White;background-color:Green;border-radius:3px;padding:2px 3px 2px 3px;'><b>" + Math.Round(percentagePrice).ToString() + "%</b></span>";
                }
                else
                {
                    item.DiscountPercentage = "<span style='color: Black;'><b>Rs " + _product.ProductPrice.ToString() + "</b></span> ";
                }
            }
            else if(item.ProductPrice>0 && item.DiscountedPrice==0) 
            {
                item.DiscountPercentage = "<span style='color: Black;'><b>Rs " + _product.ProductPrice.ToString() + "</b></span> ";
            }
            if (item.ProductPrice == 0 && item.DiscountedPrice == 0)
            {
                item.DiscountPercentage = "";
            }
            //DiscountPercentageack
            item.Custom1 = _product.Custom1;
            item.Custom2 = _product.Custom2;
            item.Custom3 = _product.Custom3;
            item.PID = _product.PID;
            if (_product.PriceType == Convert.ToInt32(Constants.PriceType.INR))
            {
                item.UserCommision = "+ Extra <i class='fa fa-inr'></i> "+ _product.UserCommision+" Cashback";
            }
            else if (_product.PriceType == Convert.ToInt32(Constants.PriceType.Percentage))
            {
                item.UserCommision = "+ Extra " + _product.UserCommision + "% Cashback";
            }
            else
            {
                item.UserCommision = "+ Extra <i class='fa fa-inr'></i> 0 Cashback";
            }
            item.Location = _product.Location;
            item.Brand = _product.Brand;
            item.Color = _product.Color;
            item.ProductPriceCurrency = _product.ProductPriceCurrency;          

        }

        return item;
    }
    #endregion

    #region "Merchant"

    public void DeleteMerchants(List<Int64> MerchantIDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Mst_Merchants.Where(x => MerchantIDs.Contains(x.MID)).ToList().ForEach(model.Adv_Mst_Merchants.DeleteObject);

            model.SaveChanges();
        }
    }

    public void InsertMerchant(Merchant _Merchant)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            //adv_CommissionBreakdown com11 = new adv_CommissionBreakdown();
            //com11.adv_CommissionBreakdown.Adv_Mst_Merchant.me
            //model.Adv_Mst_Merchants.Where(x => x.MerchantName == _Merchant.MerchantID).ToList().ForEach(model.Adv_Mst_Merchants.DeleteObject);
            var original = model.Adv_Mst_Merchants.Where(c => c.OMGMID == _Merchant.OMGMID).SingleOrDefault();
            if (original != null)
            {
                if (_Merchant.MerchantLogoUrl != null)
                    original.LogoUrl = _Merchant.MerchantLogoUrl;
                original.MerchantDetails = _Merchant.MerchantDetails;
                if (_Merchant.MerchantNameDescription != null)
                    original.MerchantNameDescription = _Merchant.MerchantNameDescription;

                if (_Merchant.TrackingURL != null)
                original.TrackingURL = _Merchant.TrackingURL;

                model.SaveChanges();
            }
            else
            {
                Adv_Mst_Merchant item = new Adv_Mst_Merchant();
                item.MerchantName = _Merchant.MerchantID;
                item.MerchantDetails = _Merchant.MerchantDetails;
                item.Status = Convert.ToInt32(_Merchant.Status_N);
                item.LogoUrl = _Merchant.MerchantLogoUrl;
                item.AffiliateID = _Merchant.AffiliateID;
                item.OMGMID = _Merchant.OMGMID;
                item.CountryCode = _Merchant.CountryCode;
                item.MerchantNameDetail = _Merchant.MerchantNameDetail;
                item.MerchantNameDescription = _Merchant.MerchantNameDescription;
                item.MerchantLinkType = _Merchant.MerchantLinkType;
                item.TrackingURL = _Merchant.TrackingURL;

                model.AddToAdv_Mst_Merchants(item);
                model.SaveChanges();
            }
        }
    }

    public void UpdateMerchant(Merchant _Merchant)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var original = model.Adv_Mst_Merchants.Where(c => (c.MID == _Merchant.MID) || (c.OMGMID==_Merchant.OMGMID) || (c.MerchantNameDetail == _Merchant.MerchantNameDetail)).SingleOrDefault();
            if (original != null)
            {
                short AffiliateFrom = Convert.ToInt16(Constants.MerchantLinkType.Optimise);
                if (original.MerchantLinkType == AffiliateFrom)
                {
                    if (_Merchant.Status > 0)
                        original.Status = _Merchant.Status;
                    if (!string.IsNullOrEmpty(_Merchant.TrackingURL))
                    {
                        if (!ExcludeMerchantList(_Merchant.MerchantNameDetail))
                        {
                            //original.TrackingURL = clsUtility.GetDeeplinkInHTMLString(_Merchant.TrackingURL);
                        }
                    }
                    if (_Merchant.CategoryType.HasValue)
                        original.CategoryType = Convert.ToInt32(_Merchant.CategoryType);
                    if (_Merchant.OMGMID > 0)
                        original.OMGMID = _Merchant.OMGMID;
                    if (_Merchant.MerchantLogoUrl != null)
                    { }
                    //original.LogoUrl = _Merchant.MerchantLogoUrl;
                    //original.AffiliateID = _Merchant.AffiliateID;
                    //original.OMGMID = _Merchant.OMGMID;  
                    model.SaveChanges();
                }
            }
        }
    }

    private bool ExcludeMerchantList(string merchantName)
    {
        string[] merchantList = Constants.ExcludeMerchant.ToUpper().Split(',');
        var result = merchantList.Where(i => i.ToUpper().Contains(merchantName.ToUpper())).ToList();
        if (result.Count>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Merchant FindMerchant(string MerchantName)
    {
        Merchant vList = new Merchant();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Mst_Merchants
                           where var.MerchantNameDetail.Contains(MerchantName) 
                           select var).AsParallel().FirstOrDefault();

            if (varlist == null)
            {
                var varlistDescription = (from var in model.Adv_Mst_Merchants
                               where var.MerchantNameDescription.Contains(MerchantName)
                               select var).AsParallel().FirstOrDefault();

                vList = DTO_Merchant(varlistDescription);                   
            }
            else
            {
                vList = DTO_Merchant(varlist);                   
            }
                    
            
        }
        return vList;
    }

    public Merchant FindMerchantMID(int OMGMID)
    {
        Merchant vList = new Merchant();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Mst_Merchants
                           where var.OMGMID==OMGMID
                           select var).FirstOrDefault();

            vList = DTO_Merchant(varlist);

        }
        return vList;
    }

    public Merchant FindMerchantMID(int OMGMID, string MerchantNameDescription)
    {
        Merchant vList = new Merchant();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Mst_Merchants
                           where var.OMGMID == OMGMID && MerchantNameDescription.Contains(var.MerchantNameDetail)
                           select var).FirstOrDefault();

            vList = DTO_Merchant(varlist);

        }
        return vList;
    }


    public Merchant FindMerchant(Int64 MID)
    {
        Merchant vList = new Merchant();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Mst_Merchants
                           where var.MID == MID
                           select var).FirstOrDefault();

            vList = DTO_Merchant(varlist);

        }
        return vList;
    }

    public List<Merchant> GetAllMerchants()
    {
        List<Merchant> vList = new List<Merchant>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
            {
                assignUSERID();
                int status=Convert.ToInt32(Constants.Status.Active);
                var varlistA = (from var in model.Adv_Mst_Merchants
                               where var.Status == status
                               select var).OrderBy(p => p.MerchantNameDetail);

                if (varlistA.Count() > 0)
                {
                    foreach (Adv_Mst_Merchant var in varlistA)
                    {
                        Merchant q = new Merchant();
                        q = DTO_Merchant(var);
                        vList.Add(q);
                    }
                }
            }
            else
            {

                var varlist = (from var in model.Adv_Mst_Merchants
                               where var.OMGMID.HasValue
                               select var).OrderBy(p => p.MerchantNameDetail);

                if (varlist.Count() > 0)
                {
                    foreach (Adv_Mst_Merchant var in varlist)
                    {
                        Merchant q = new Merchant();
                        q = DTO_Merchant(var);
                        vList.Add(q);
                    }
                }
            }
        }
        return vList;
    }

    public List<Merchant> GetAllMerchantsList()
    {
        List<Merchant> vList = new List<Merchant>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            int status = Convert.ToInt32(Constants.Status.Active);
            var varlist = (from var in model.Adv_Mst_Merchants
                           where var.Status == status
                           select var).OrderBy(p => p.MerchantNameDetail).AsParallel();

            if (varlist.Count() > 0)
            {
                foreach (Adv_Mst_Merchant var in varlist)
                {
                    Merchant q = new Merchant();
                    q = DTO_MerchantGeneric(var);
                    vList.Add(q);
                }
            }
        }
        return vList;
    }

    //public List<Merchant> DTO_Merchants(EntityCollection<Adv_Mst_Merchant> _Merchants)
    //{
    //    List<Merchant> vList = new List<Merchant>();
    //    foreach (Adv_Mst_Merchant var in _Merchants)
    //    {
    //        Merchant item = new Merchant();
    //        item = DTO_Merchant(var);
    //        vList.Add(item);
    //    }

    //    return vList;
    //}

    public Merchant DTO_Merchant(Adv_Mst_Merchant _Merchant)
    {
        Merchant item = new Merchant();
        if (_Merchant != null)
        {
            assignUSERID();

            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            item.MID = _Merchant.MID;
            item.MerchantID = _Merchant.MerchantName.Value;
            item.MerchantName = ((Constants.NameOfMerchants)_Merchant.MerchantName.Value).ToString();
            item.MerchantDetails = _Merchant.MerchantDetails;
            item.MerchantImage = _Merchant.LogoUrl;// string.IsNullOrEmpty(_Merchant.LogoUrl) ? clsImageUrl.GetMerchantImage((Constants.NameOfMerchants)Enum.Parse(typeof(Constants.NameOfMerchants), _Merchant.MerchantName.Value.ToString())) : _Merchant.LogoUrl;
            item.Status_N = (Constants.Status)_Merchant.Status.Value;
           // item.Merchant_Coupons = DTO_Coupons(_Merchant.Adv_Coupon);
            //item.Merchant_Deals = DTO_Deals(_Merchant.Adv_Deal);//WILL USE LATER NEED TO ANALYSIS IT


            var dt = (from com in _Merchant.Adv_Commision
                      where com.PayoutType == "Sale" & !string.IsNullOrEmpty(com.UserCommision)
                      select new
                      {
                          UserCommision = string.IsNullOrEmpty(com.UserCommision.Trim()) ? 0 : Convert.ToSingle(com.UserCommision.Trim()),
                          PriceType = com.PriceType.Value
                      }).OrderByDescending(o => o.UserCommision).FirstOrDefault();

            if (dt != null)
                item.UserCommission = dt.PriceType == 0 ? dt.UserCommision.ToString() + " %" : "<i class='fa fa-inr'></i>&nbsp;" + dt.UserCommision.ToString();

            //.var//var oofList=;
            item.Merchant_Offers = DTO_Offers(_Merchant.Adv_Offer);
            //item.Merchant_ProductDeals = GetAll_VW_ProductsWithMID(Convert.ToInt32(_Merchant.MID));
            item.Merchant_Banners = DTO_Banners(_Merchant.Adv_Trn_Banner);
            item.TrackingURL = !string.IsNullOrEmpty(_Merchant.TrackingURL) ? IsUserLogin ? _Merchant.TrackingURL.Replace("=cos", "=" + userID) : _Merchant.TrackingURL : ""; 
            item.CategoryType = _Merchant.CategoryType.HasValue ? (Constants.CategoryType)_Merchant.CategoryType : Constants.CategoryType.None;
            item.MerchantNameDetail = _Merchant.MerchantNameDetail;
            item.Status = _Merchant.Status.Value;
            item.AffiliateID = _Merchant.AffiliateID;
            item.OMGMID = _Merchant.OMGMID;
            item.Merchant_BreakDowns = DTO_BreakDowns(_Merchant.adv_CommissionBreakdown);
            
            item.Seo_Title = _Merchant.Seo_Title;
            item.Seo_Description = _Merchant.Seo_Description;
            item.Seo_Keyword = _Merchant.Seo_Keyword;
            item.MerchantLinkType = _Merchant.MerchantLinkType;
            item.MerchantNameDescription = _Merchant.MerchantNameDescription;
    //        public string Seo_Title { get; set; }
    //public string Seo_Description { get; set; }
    //public string Seo_Keyword { get; set; }
            //item.PID = _Merchant.PID;
            ////item.MerchantLogoUrl = _Merchant.MerchantLogoUrl;
            //item.ProgramName = _Merchant.ProgramName;
            //item.ProductDescription = _Merchant.ProductDescription;
            //item.Sector = _Merchant.Sector;
            //item.Commision = _Merchant.Commision;
            //item.CountryCode = _Merchant.CountryCode;
            //item.PayoutType = _Merchant.PayoutType;
            //item.CookieDuration = _Merchant.CookieDuration;
            //item.DeepLinkEnabled = _Merchant.DeepLinkEnabled.HasValue ? (Constants.YesNo)_Merchant.DeepLinkEnabled : Constants.YesNo.No;
            //item.ProductfeedAvailable = _Merchant.ProductfeedAvailable.HasValue ? (Constants.YesNo)_Merchant.ProductfeedAvailable : Constants.YesNo.No;
            //item.UIDTracking = _Merchant.UIDTracking.HasValue ? (Constants.YesNo)_Merchant.UIDTracking : Constants.YesNo.No;
            //item.WebsiteUrl = _Merchant.WebsiteUrl;
            //item.TrackingURL = _Merchant.TrackingURL;


        }

        return item;
    }
   
    public Merchant DTO_MerchantGeneric(Adv_Mst_Merchant _Merchant)
    {    

        Merchant item = new Merchant();
        if (_Merchant != null)
        {
            assignUSERID();

            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            item.MID = _Merchant.MID;
            item.MerchantID = _Merchant.MerchantName.Value;
            item.MerchantName = ((Constants.NameOfMerchants)_Merchant.MerchantName.Value).ToString();
            item.MerchantDetails = _Merchant.MerchantDetails;
            item.MerchantImage = _Merchant.LogoUrl;

            item.TotalOffer = (from d in _Merchant.Adv_Offer
                               where d.ValidTill >= DateTime.Now.Date && d.ActivationDate <= DateTime.Now.Date
                               select d).ToList().Count();

            var dt = (from com in _Merchant.Adv_Commision
                      where com.PayoutType == "Sale" & !string.IsNullOrEmpty(com.UserCommision)
                      select new
                      {
                          UserCommision = string.IsNullOrEmpty(com.UserCommision.Trim()) ? 0 : Convert.ToSingle(com.UserCommision.Trim()),
                          PriceType = com.PriceType.Value
                      }).OrderByDescending(o => o.UserCommision).FirstOrDefault();

            if (dt != null)
                item.UserCommission = dt.PriceType == 0 ? dt.UserCommision.ToString() + " %" : "<i class='fa fa-inr'></i>&nbsp;" + dt.UserCommision.ToString();

            item.TrackingURL = !string.IsNullOrEmpty(_Merchant.TrackingURL) ? IsUserLogin ? _Merchant.TrackingURL.Replace("=cos", "=" + userID) : _Merchant.TrackingURL : "";
            item.CategoryType = _Merchant.CategoryType.HasValue ? (Constants.CategoryType)_Merchant.CategoryType : Constants.CategoryType.None;
            if (_Merchant.MerchantNameDetail.ToString().IndexOf(".") >= 0)
                item.MerchantNameDetail = _Merchant.MerchantNameDetail.Substring(0, _Merchant.MerchantNameDetail.ToString().IndexOf("."));
            else
                item.MerchantNameDetail = _Merchant.MerchantNameDetail;


            item.Seo_Title = _Merchant.Seo_Title;
            item.Seo_Description = _Merchant.Seo_Description;
            item.Seo_Keyword = _Merchant.Seo_Keyword;
            item.MerchantLinkType = _Merchant.MerchantLinkType;
            item.MerchantNameDescription = _Merchant.MerchantNameDescription;
        }

        return item;
    }

    #endregion

    #region "Merchant Breakdown"
    public List<Merchant_BreakDown> DTO_BreakDowns(EntityCollection<adv_CommissionBreakdown> _BreakDowns)
    {
        List<Merchant_BreakDown> vList = new List<Merchant_BreakDown>();
        foreach (adv_CommissionBreakdown var in _BreakDowns.ToList())
        {
            Merchant_BreakDown item = new Merchant_BreakDown();
            item = DTO_BreakDown(var);
            vList.Add(item);
        }

        return vList.OrderByDescending(o => o.CreatedDate).ToList();
    }
    public Merchant_BreakDown DTO_BreakDown(adv_CommissionBreakdown _BreakDown)
    {
        Merchant_BreakDown item = new Merchant_BreakDown();
        if (_BreakDown != null)
        {
            item.BreakDownID = _BreakDown.BreakDownID;
            item.MID = _BreakDown.MID;
            item.BreakDownText = _BreakDown.BreakDownText;
            item.BreakDownStartAmount = _BreakDown.BreakDownStartAmount;
            item.BreakDownEndAmount = _BreakDown.BreakDownEndAmount;
            item.BreakDownMaxCommission = _BreakDown.BreakDownMaxCommission;
            item.UserBreakDownMaxCommission = _BreakDown.UserBreakDownMaxCommission;
            item.MID = _BreakDown.MID.Value;
            if (_BreakDown.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf(".") >= 0)
                item.MerchantName = _BreakDown.Adv_Mst_Merchant.MerchantNameDetail.Substring(0, _BreakDown.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf("."));
            else
                item.MerchantName = _BreakDown.Adv_Mst_Merchant.MerchantNameDetail;
            if (_BreakDown.ToValidDate.HasValue)
                item.ToValidDate = _BreakDown.ToValidDate;
            if (_BreakDown.CommissionType.HasValue)
                item.CommissionType = (Constants.PriceType)_BreakDown.CommissionType;
            item.CreatedDate = _BreakDown.CreatedDate;
        }

        return item;
    }

    #endregion

    #region "Coupon"


    public void DeleteCoupons(List<Int64> CouponIDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Coupons.Where(x => CouponIDs.Contains(x.CID)).ToList().ForEach(model.Adv_Coupons.DeleteObject);

            model.SaveChanges();
        }
    }

    public List<Merchant_Coupon> GetAllCouponsSearchText(string searctText)
    {
        List<Merchant_Coupon> vList = new List<Merchant_Coupon>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Coupons
                           join sa in model.Adv_Mst_Merchants on var.MID equals sa.MID
                           where string.Concat(var.Coupon, var.Offer, sa.MerchantDetails, sa.MerchantNameDetail).Contains(searctText)
                           select var);

            foreach (Adv_Coupon var in varlist)
            {
                Merchant_Coupon q = new Merchant_Coupon();
                q = DTO_Coupon(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Merchant_Coupon> GetAllCoupons()
    {
        List<Merchant_Coupon> vList = new List<Merchant_Coupon>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Coupons
                           select var);

            foreach (Adv_Coupon var in varlist)
            {
                Merchant_Coupon q = new Merchant_Coupon();
                q = DTO_Coupon(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Merchant_Coupon> GetLatestCoupons(int takeCoupon)
    {
        List<Merchant_Coupon> vList = new List<Merchant_Coupon>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Coupons
                           where var.ValidTill>=DateTime.Now
                           orderby var.CreatedDate
                           select var).Take(takeCoupon);

            foreach (Adv_Coupon var in varlist)
            {
                Merchant_Coupon q = new Merchant_Coupon();
                q = DTO_Coupon(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public void InsertCoupon(Merchant_Coupon _Coupon)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_Coupon var = new Adv_Coupon();
            var.MID = _Coupon.MID;
           
            var.Coupon = _Coupon.Coupon;
            var.CouponForDevice =Convert.ToInt16(_Coupon.CouponForDevice);
            var.Offer = _Coupon.Offer;
            var.ValidTill=_Coupon.ValidTill;
            var.NavigationURL=clsUtility.GetDeeplinkInHTMLString(_Coupon.NavigationURL);
            var.CreatedDate=DateTime.Now;
            model.AddToAdv_Coupons(var);
            model.SaveChanges();
        }
    }

    public List<Merchant_Coupon> DTO_Coupons(EntityCollection<Adv_Coupon> _Coupon)
    {
        List<Merchant_Coupon> vList = new List<Merchant_Coupon>();
        foreach (Adv_Coupon var in _Coupon)
        {
            Merchant_Coupon item = new Merchant_Coupon();
            item = DTO_Coupon(var);
            vList.Add(item);
        }

        return vList;
    }
    public Merchant_Coupon DTO_Coupon(Adv_Coupon _Coupon)
    {
        assignUSERID();   
        Merchant_Coupon item = new Merchant_Coupon();
        if (_Coupon != null)
        {
            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;


            item.MerchantName = _Coupon.Adv_Mst_Merchant.MerchantNameDetail;
            item.MID = _Coupon.MID.Value;
            item.MerchantImage = string.IsNullOrEmpty(_Coupon.Adv_Mst_Merchant.LogoUrl) ? clsImageUrl.GetMerchantImage((Constants.NameOfMerchants)_Coupon.Adv_Mst_Merchant.MerchantName) : _Coupon.Adv_Mst_Merchant.LogoUrl;
            item.CID = _Coupon.CID;
            item.CouponForDevice = (Constants.Device)_Coupon.CouponForDevice;
            item.Offer = _Coupon.Offer;
            item.Coupon = _Coupon.Coupon;
            item.ValidTill = _Coupon.ValidTill.Value;
            item.NavigationURL = IsUserLogin ? _Coupon.NavigationURL.Replace("=cos", "=" + userID) : _Coupon.NavigationURL; 
            item.CreatedDate = _Coupon.CreatedDate.Value;
        }

        return item;
    }
    #endregion

    #region "Deal"

    public void DeleteDeals(List<Int64> DealIDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Deals.Where(x => DealIDs.Contains(x.DealID)).ToList().ForEach(model.Adv_Deals.DeleteObject);

            model.SaveChanges();
        }
    }
    

    public List<Merchant_Deal> GetAllDealsSearchText(string searctText)
    {
        List<Merchant_Deal> vList = new List<Merchant_Deal>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Deals
                           join sa in model.Adv_Mst_Merchants on var.MID equals sa.MID
                           where string.Concat(var.Title, var.Description, sa.MerchantDetails, sa.MerchantNameDetail).Contains(searctText)
                           select var);

            foreach (Adv_Deal var in varlist)
            {
                Merchant_Deal q = new Merchant_Deal();
                q = DTO_Deal(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Merchant_Deal> GetAllDeals()
    {
        List<Merchant_Deal> vList = new List<Merchant_Deal>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Deals
                           select var);

            foreach (Adv_Deal var in varlist)
            {
                Merchant_Deal q = new Merchant_Deal();
                q = DTO_Deal(var);
                vList.Add(q);
            }
        }
        return vList;
    }


    public void InsertDeal(Merchant_Deal _deal)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_Deal var = new Adv_Deal();
            var.MID = _deal.MID;
            var.ProductCategoryName = _deal.ProductCategoryName;
            var.Title = _deal.Title;
            var.Description = _deal.Description;
            var.Availability = _deal.Availability;
            var.CouponCode = _deal.CouponCode;
            var.ImageUrl = _deal.ImageUrl;

            var.ProductID = _deal.ProductID;
            var.ProductSKU = _deal.ProductSKU;
            var.ProductPrice = _deal.ProductPrice;
            var.ProductPriceCurrency = _deal.ProductPriceCurrency;
            var.Location = _deal.Location;
            var.Color = _deal.Color;
            var.Brand = _deal.Brand;
            var.Availability = _deal.Availability;
            var.DiscountedPrice = _deal.DiscountedPrice;
            var.WasPrice = _deal.WasPrice;

            var.SerialNo = _deal.SerialNo;
            var.NavigationURL =clsUtility.GetDeeplinkInHTMLString( _deal.NavigationURL);
            var.CreatedDate = DateTime.Now;
            //var.ModifiedDate = _deal.ModifiedDate;
            var.CreatedBy = _deal.CreatedBy; 

            model.AddToAdv_Deals(var);
            model.SaveChanges();
        }
    }

    public List<Merchant_Deal> DTO_Deals(EntityCollection<Adv_Deal> _Merchants)
    {
        List<Merchant_Deal> vList = new List<Merchant_Deal>();
        foreach (Adv_Deal var in _Merchants)
        {
            Merchant_Deal item = new Merchant_Deal();
            item = DTO_Deal(var);
            vList.Add(item);
        }

        return vList;
    }
    public Merchant_Deal DTO_Deal(Adv_Deal _deal)
    {
         assignUSERID();      
            
        Merchant_Deal item = new Merchant_Deal();
        if (_deal != null)
        {
            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            item.MID = _deal.MID.Value;
            item.DealID = _deal.DealID;
            item.MerchantName = _deal.Adv_Mst_Merchant.MerchantNameDetail;
            item.ProductCategoryName = _deal.ProductCategoryName;

            item.ProductID = _deal.ProductID;
            item.ProductSKU = _deal.ProductSKU;
            item.ProductPrice = _deal.ProductPrice;
            item.ProductPriceCurrency = _deal.ProductPriceCurrency;
            item.Location = _deal.Location;
            item.Color = _deal.Color;
            item.Brand = _deal.Brand;
            item.Availability = _deal.Availability;
            item.DiscountedPrice = _deal.DiscountedPrice;
            item.WasPrice = _deal.WasPrice;

            if (item.DiscountedPrice > 0)
            {
                double percentagePrice = 100 - (Convert.ToSingle(_deal.DiscountedPrice) * 100 / Convert.ToSingle(_deal.ProductPrice));
                if (Math.Round(percentagePrice) > 0)
                {
                    item.DiscountPercentage = "<span style='color: Black;'><b>Rs " + _deal.DiscountedPrice.ToString() + "</b></span> " + " " + " <span style='text-decoration:line-through;'><b>Rs " + _deal.ProductPrice.ToString() + "</b></span>" + " <span style='color: Green;'><b>" + Math.Round(percentagePrice).ToString() + "%</b></span>";
                }
                else
                {
                    item.DiscountPercentage = "<span style='color: Black;'><b>Rs " + _deal.ProductPrice.ToString() + "</b></span> ";
                }
            }
            else
            {
                item.DiscountPercentage = "<span style='color: Black;'><b>Rs " + _deal.ProductPrice.ToString() + "</b></span> ";
            }




            item.Title = _deal.Title;
            item.Description = _deal.Description;
            item.Availability = _deal.Availability;
            item.CouponCode = _deal.CouponCode;
            item.ImageUrl = _deal.ImageUrl;
            //item.ValidTill = _deal.ValidTill.Value;
            item.NavigationURL = IsUserLogin ? _deal.NavigationURL.Replace("=cos", "=" + userID) : _deal.NavigationURL; 
            item.CreatedDate = _deal.CreatedDate.Value;
            item.ModifiedDate = _deal.ModifiedDate;
            item.CreatedBy = _deal.CreatedBy;
        }

        return item;
    }
    #endregion
   
    #region "Offer"

    public List<Merchant_Offer> GetAll_Proc_Offer(int pageIndex, int pageSize, out int totalRecord,string offerType)
    {
        DataTable dt = new DataTable();
        List<Merchant_Offer> vList = new List<Merchant_Offer>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var oMyString = new ObjectParameter("RecordCount", typeof(int));
            //var oMyStringDT = new ObjectParameter("RecordCount", typeof(DataTable));

            var list = (from var in model.GetMerchantOffer(pageIndex, pageSize, oMyString, offerType) select var).ToList();
            totalRecord = Convert.ToInt32(oMyString.Value.ToString());


            foreach (vw_Offer_List var in list.OrderByDescending(o=>o.CreatedDate))
            {
                Merchant_Offer q = new Merchant_Offer();
                q = DTO_vw_To_Offer(var);
                vList.Add(q);
            }
        }
        return vList;
    }


    public void DeleteOffers(List<Int64> offerIDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Offers.Where(x => offerIDs.Contains(x.OfferID)).ToList().ForEach(model.Adv_Offers.DeleteObject);
            //model.Adv_Offers.Where(x => string.Concat(x.OfferID.ToString(), x.NavigationURL.ToString()).con=="1").ToList().ForEach(model.Adv_Offers.DeleteObject);
            
            model.SaveChanges();
        }
    }

    public List<Merchant_Offer> GetAllOffersSearchText(string searctText)
    {
        List<Merchant_Offer> vList = new List<Merchant_Offer>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Offers
                           join sa in model.Adv_Mst_Merchants on var.MID equals sa.MID
                           where string.Concat(var.Title,var.Description,sa.MerchantDetails,sa.MerchantNameDetail).Contains(searctText)
                           select var);

            foreach (Adv_Offer var in varlist)
            {
                Merchant_Offer q = new Merchant_Offer();
                q = DTO_Offer(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Merchant_Offer> GetLatestOffers(int takeOffer)
    {
        List<Merchant_Offer> vList = new List<Merchant_Offer>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Offers
                           where var.ValidTill >= DateTime.Now
                           orderby var.CreatedDate
                           select var).Take(takeOffer);

            foreach (Adv_Offer var in varlist)
            {
                Merchant_Offer q = new Merchant_Offer();
                q = DTO_Offer(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Merchant_Offer> GetAllOffers()
    {
        List<Merchant_Offer> vList = new List<Merchant_Offer>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Offers
                           select var);

            foreach (Adv_Offer var in varlist)
            {
                Merchant_Offer q = new Merchant_Offer();
                q = DTO_Offer(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public void InsertOffer(Merchant_Offer _Offer)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_Offer var = new Adv_Offer();

            if (_Offer.VoucherCodeID != null || _Offer.VoucherCodeID != 0)
            {
                var offer = model.Adv_Offers.SingleOrDefault(p => p.VoucherCodeID== _Offer.VoucherCodeID);
                if (offer != null)
                {
                    offer.ValidTill = _Offer.ValidTill;
                    offer.CouponCode = _Offer.CouponCode;
                    offer.NavigationURL = _Offer.NavigationURL;
                    
                    model.SaveChanges();
                    model.Dispose();
                    return;
                }                
            }

            var.MID = _Offer.MID;          
            var.Title = _Offer.Title;
            var.Description = _Offer.Description;
            var.ValidTill = _Offer.ValidTill;
            var.NavigationURL =clsUtility.GetDeeplinkInHTMLString(_Offer.NavigationURL);
            var.CouponCode = _Offer.CouponCode;
            var.VoucherCodeID = _Offer.VoucherCodeID;
            var.ImageUrl = _Offer.ImageUrl;
            var.ActivationDate = _Offer.ActivationDate;
            var.OfferType =Convert.ToInt16(_Offer.OfferType);

            var.OfferForDevice = Convert.ToInt16(_Offer.CouponForDevice);
            var.CreatedDate = DateTime.Now;
          
            
            model.AddToAdv_Offers(var);
            model.SaveChanges();
        }
    }

    public List<Merchant_Offer> DTO_Offers(EntityCollection<Adv_Offer> _Merchants)
    {
        List<Merchant_Offer> vList = new List<Merchant_Offer>();
        foreach (Adv_Offer var in _Merchants.Where(off => off.ValidTill >= DateTime.Now.Date && off.ActivationDate <= DateTime.Now.Date).OrderByDescending(o => o.OfferID).Take(30).ToList())
        {
            Merchant_Offer item = new Merchant_Offer();
            item = DTO_Offer(var);
            vList.Add(item);
        }

        return vList.OrderByDescending(o => o.CreatedDate).ToList();
    }
    public Merchant_Offer DTO_Offer(Adv_Offer _Offer)
    {
        

        Merchant_Offer item = new Merchant_Offer();
        if (_Offer != null)
        {
            assignUSERID();

            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;
            item.ActivationDate = _Offer.ActivationDate;
            item.OfferType = _Offer.OfferType;
            item.MID = _Offer.MID.Value;
            if (_Offer.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf(".") >= 0)
                item.MerchantName = _Offer.Adv_Mst_Merchant.MerchantNameDetail.Substring(0, _Offer.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf("."));
            else
                item.MerchantName = _Offer.Adv_Mst_Merchant.MerchantNameDetail;
            //item.MerchantName = _Offer.Adv_Mst_Merchant.MerchantNameDetail;
            item.MerchantImage = string.IsNullOrEmpty(_Offer.Adv_Mst_Merchant.LogoUrl) ? clsImageUrl.GetMerchantImage((Constants.NameOfMerchants)_Offer.Adv_Mst_Merchant.MerchantName) : _Offer.Adv_Mst_Merchant.LogoUrl;
            item.OfferID = _Offer.OfferID;
            item.CouponForDevice =_Offer.OfferForDevice.HasValue? (Constants.Device)_Offer.OfferForDevice:Constants.Device.Desktop;
            //item.MoreOffer = 0;
            item.Title = _Offer.Title;
            item.CouponCode = _Offer.CouponCode;
            item.Description = _Offer.Title != _Offer.Description ? _Offer.Description : "";
            item.ValidTill = _Offer.ValidTill;
            item.NavigationURL = IsUserLogin ? _Offer.NavigationURL.Replace("=cos", "=" + userID) : _Offer.NavigationURL;//clsUtility.GetDeeplinkInHTMLString(_Offer.NavigationURL,userID);
            item.CreatedDate = _Offer.CreatedDate.Value;
        }

        return item;
    }

    public Merchant_Offer DTO_vw_To_Offer(vw_Offer_List _Offer)
    {
        assignUSERID();

        Merchant_Offer item = new Merchant_Offer();
        if (_Offer != null)
        {
            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            //item.ActivationDate = _Offer.ActivationDate;
            //item.OfferType = _Offer.OfferType;
            item.MID = _Offer.MID.Value;
            item.MerchantName = _Offer.MerchantName;//.Adv_Mst_Merchant.MerchantNameDetail;
            item.MerchantImage = _Offer.MerchantImage;
            item.OfferID = _Offer.OfferID;
            item.CouponForDevice = (Constants.Device)_Offer.CouponForDevice;
            item.MoreOffer=_Offer.MoreOffer;
            item.TrackingURL = _Offer.TrackingURL;
            item.OfferType = _Offer.OfferType;
            item.Title = _Offer.Title;
            item.CouponCode = _Offer.CouponCode;
            item.Description = _Offer.Title != _Offer.Description ? _Offer.Description : "";
            item.ValidTill = _Offer.ValidTill;
            item.NavigationURL = IsUserLogin ? _Offer.NavigationURL.Replace("=cos", "=" + userID) : _Offer.NavigationURL;//clsUtility.GetDeeplinkInHTMLString(_Offer.NavigationURL,userID);
            item.CreatedDate = _Offer.CreatedDate.Value;
            item.ImageUrl = _Offer.ImageUrl;
            item.UserCommision = _Offer.UserCommision;
        }

        return item;
    }
    #endregion

    #region "API-URL"
    public void DeleteApiURLs(List<Int64> urlIDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Mst_ApiUrls.Where(x => urlIDs.Contains(x.APIID)).ToList().ForEach(model.Adv_Mst_ApiUrls.DeleteObject);

            model.SaveChanges();
        }
    }
    public List<Merchant_ApiURL> GetAllApiURLs()
    {
        List<Merchant_ApiURL> vList = new List<Merchant_ApiURL>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Mst_ApiUrls
                           select var);

            foreach (Adv_Mst_ApiUrl var in varlist)
            {
                Merchant_ApiURL q = new Merchant_ApiURL();
                q = DTO_ApiURL(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public void InsertApiURL(Merchant_ApiURL _ApiURL)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_Mst_ApiUrl var = new Adv_Mst_ApiUrl();
            var.APIType = _ApiURL.APIType;

            var.ApiName = _ApiURL.ApiName;
            var.ApiURL = _ApiURL.ApiURL;
            var.ExpireOn = _ApiURL.ExpireOn;
            var.ApiScheduleType = _ApiURL.ApiScheduleType;
            var.RunOnTime = _ApiURL.RunOnTime;

            //var.OfferForDevice = Convert.ToInt16(_Offer.CouponForDevice);
            //var.CreatedDate = DateTime.Now;

            model.AddToAdv_Mst_ApiUrls(var);
            model.SaveChanges();
        }
    }

    public List<Merchant_ApiURL> DTO_ApiURLs(EntityCollection<Adv_Mst_ApiUrl> _ApiURLs)
    {
        List<Merchant_ApiURL> vList = new List<Merchant_ApiURL>();
        foreach (Adv_Mst_ApiUrl var in _ApiURLs)
        {
            Merchant_ApiURL item = new Merchant_ApiURL();
            item = DTO_ApiURL(var);
            vList.Add(item);
        }

        return vList;
    }
    public Merchant_ApiURL DTO_ApiURL(Adv_Mst_ApiUrl _ApiURL)
    {
        Merchant_ApiURL item = new Merchant_ApiURL();
        if (_ApiURL != null)
        {
            item.APIID = _ApiURL.APIID;
            item.APIType = _ApiURL.APIType.Value;
            item.ApiName = _ApiURL.ApiName;// ((Constants.NameOfMerchants)_ApiURL.Adv_Mst_ApiUrl.MerchantName).ToString();
            item.ApiURL = _ApiURL.ApiURL;
            item.ExpireOn =_ApiURL.ExpireOn.HasValue?_ApiURL.ExpireOn:null;
            item.ApiScheduleType = _ApiURL.ApiScheduleType.Value;
            item.RunOnTime =_ApiURL.RunOnTime.HasValue?_ApiURL.RunOnTime:null;
            if (_ApiURL.RunOnTime.HasValue)
            {
                DateTime time = DateTime.Today.Add(_ApiURL.RunOnTime.Value);
                string displayTime = time.ToString("hh:mm tt");

                item.RunOnTimeName = _ApiURL.RunOnTime.HasValue ? displayTime : null;
            }

            item.APITypeName = ((Constants.API_URL_Type)_ApiURL.APIType.Value).ToString();
            item.ApiScheduleTypeName = ((Constants.ApiScheduleType)_ApiURL.ApiScheduleType.Value).ToString();
           
        }

        return item;
    }
    #endregion

    #region IUserProfileService Members

    public static string GetGlobalUserID()
    {
        string userID = string.Empty;
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            Guid currentUserID = (Guid)user.ProviderUserKey;
            UserProfile q = new UserProfile();            
            var details = (from var in model.Adv_Trn_UserProfiles
                           where var.UserProfileID == currentUserID
                           select var.UserID).FirstOrDefault();
            if (details != null)
            {
                userID= details.ToString();
            }
        }

        return userID;
    }
    

    public UserProfile GetUserByuserID(Guid userID)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            UserProfile q = new UserProfile();
            var details = (from var in model.Adv_Trn_UserProfiles
                           where var.UserProfileID == userID
                           select var).FirstOrDefault();
            if (details != null)
            {
                q = DTO_User(details);
            }
            
            return q;
        }
    }

    public UserProfile GetUserByuserID(Int64 userID)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            UserProfile q = new UserProfile();
            var details = (from var in model.Adv_Trn_UserProfiles
                           where var.UserID == userID
                           select var).FirstOrDefault();
            if (details != null)
            {
                q = DTO_User(details);
            }

            return q;
        }
    }

    public List<UserProfile> GetAllUserProfiles()
    {
        throw new NotImplementedException();
    }

    public void InsertUserProfile(UserProfile UserProfile)
    {
        try
        {

            using (Ad_ConnectionString model = new Ad_ConnectionString())
            {

                Adv_Trn_UserProfile q = new Adv_Trn_UserProfile();                               
                q.UserProfileID = UserProfile.UserProfileID;
                q.FullName = UserProfile.FullName;
                q.IsEmailVerified = UserProfile.IsEmailVerified;                              
                q.IsEmailVerified = UserProfile.IsEmailVerified;
                q.PhoneNo = UserProfile.PhoneNo;
                model.AddToAdv_Trn_UserProfiles(q);
                model.SaveChanges(SaveOptions.DetectChangesBeforeSave);

                model.AcceptAllChanges();
                model.Dispose();

            }
        }
        catch (Exception ex)
        {
            //ExceptionMessage em = new ExceptionMessage();
            //em.exceptionMessage = "Hi this is exception message";
            //throw new FaultException(em.exceptionMessage);
        }
    }

    public void UpdateUserProfile(UserProfile _userProfile)
    {
        try
        { 
          
            using (var model = new Ad_ConnectionString())
            {
                var original = model.Adv_Trn_UserProfiles.Where(c => c.UserProfileID == _userProfile.UserProfileID).SingleOrDefault();
                                 

                original.Picture = _userProfile.ProfilePicture;
                original.LoginUserName = _userProfile.LoginUserName;
                original.FullName = _userProfile.FullName;
                original.IsEmailVerified = _userProfile.IsEmailVerified;
                original.IsOfferReceiveWeekly = _userProfile.IsOfferReceiveWeekly;
                original.IsOtherInfo = _userProfile.IsOtherInfo;
                original.BankAcHolderName = _userProfile.BankAcHolderName;
                original.BankName = _userProfile.BankName;
                original.BankBranchName = _userProfile.BankBranchName;
                original.BankAccountNo = _userProfile.BankAccountNo;
                original.IFSCCode = _userProfile.IFSCCode;
                original.FullNameOnAdd = _userProfile.FullNameOnAdd;
                original.FullAddress = _userProfile.FullAddress;
                original.City = _userProfile.City;
                original.State = _userProfile.State;
                original.PinCode = _userProfile.PinCode;
                
                original.DOB = _userProfile.DOB;

               
                model.SaveChanges();


                model.Dispose();
            }
        }
        catch (Exception ex)
        {
         
        }
    }

    public void DeleteUserProfile(Guid userID)
    {
        throw new NotImplementedException();
    }


    public List<UserProfile> DTO_Users(EntityCollection<Adv_Trn_UserProfile> _users)
    {
        List<UserProfile> vList = new List<UserProfile>();
        foreach (Adv_Trn_UserProfile var in _users)
        {
            UserProfile item = new UserProfile();
            item = DTO_User(var);
            vList.Add(item);
        }
        return vList;
    }

    public UserProfile DTO_User(Adv_Trn_UserProfile _user)
    {
        UserProfile item = new UserProfile();
        if (_user != null)
        {
          
            item.UserID = _user.UserID;
            item.LoginUserName = _user.LoginUserName;
            item.UserProfileID = _user.UserProfileID;
            item.FullName = _user.FullName;
            item.EmailID = Membership.GetUser(_user.UserProfileID).Email.ToString();

            item.IsEmailVerified = _user.IsEmailVerified;
            item.IsOfferReceiveWeekly = _user.IsOfferReceiveWeekly;
            item.IsOtherInfo = _user.IsOtherInfo;
            item.DOB = _user.DOB;

            item.BankAcHolderName = _user.BankAcHolderName;
            item.BankName = _user.BankName;
            item.BankBranchName = _user.BankBranchName;
            item.BankAccountNo = _user.BankAccountNo;
            item.IFSCCode = _user.IFSCCode;
            item.FullNameOnAdd = _user.FullNameOnAdd;
            item.FullAddress = _user.FullAddress;
            item.City = _user.City;
            item.State = _user.State;
            item.PinCode = _user.PinCode;
            item.ProfilePicture = string.IsNullOrEmpty(_user.Picture) ? Constants.DefaultUserImageUrl : _user.Picture;
           
        }
        return item;
    }

    #endregion

    #region "Commision"
    public void DeleteCommisions(List<int> ids)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Commisions.Where(x => ids.Contains(x.CommisionID)).ToList().ForEach(model.Adv_Commisions.DeleteObject);

            model.SaveChanges();
        }
    }
    public List<Merchant_Commision> GetAllCommisions()
    {
        List<Merchant_Commision> vList = new List<Merchant_Commision>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Commisions
                           select var);

            foreach (Adv_Commision var in varlist)
            {
                Merchant_Commision q = new Merchant_Commision();
                q = DTO_Commision(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public List<Merchant_Commision> GetCommisionsByMID(string MerchantName)
    {
        List<Merchant_Commision> vList = new List<Merchant_Commision>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Commisions
                           where var.Adv_Mst_Merchant.MerchantNameDetail.Contains(MerchantName) && var.PayoutType.Contains("Sale")
                           select var);

            foreach (Adv_Commision var in varlist)
            {
                Merchant_Commision q = new Merchant_Commision();
                q = DTO_Commision(var);
                vList.Add(q);
            }
        }
        return vList;
    }

    public void UpdateCommisions(List<Merchant_Commision> _commisions)
    {
        try
        {

            using (var model = new Ad_ConnectionString())
            {
                _commisions.ForEach(com =>
                {
                    var original = model.Adv_Commisions.SingleOrDefault(E => E.CommisionID == com.CommisionID);
                    original.MaximumCommision = com.MaximumCommision.HasValue ? com.MaximumCommision : null;
                    original.UserCommision = com.UserCommision;
                    original.Commision = com.Commision;
                    original.ProgramName = com.ProgramName;

                    Adv_Commision_HISTORY varHis = new Adv_Commision_HISTORY();
                    varHis.MerchantID = original.MerchantID;
                    varHis.Commision = com.Commision;
                    varHis.UserCommision = com.UserCommision;
                    varHis.Currency = original.Currency;
                    varHis.COMID = original.CommisionID;
                    varHis.PID = original.PID;
                    // var.MerchantLogoUrl = _commision.MerchantLogoUrl;
                    varHis.ProgramName = ReduceString(original.ProgramName, 148);
                    varHis.ProductDescription = original.ProductDescription;
                    varHis.Sector = original.Sector;
                    varHis.PayoutType = original.PayoutType;
                    varHis.CookieDuration = original.CookieDuration;
                    varHis.DeepLinkEnabled = Convert.ToInt16(original.DeepLinkEnabled);
                    varHis.ProductfeedAvailable = Convert.ToInt16(original.ProductfeedAvailable);
                    varHis.UIDTracking = Convert.ToInt16(original.UIDTracking);
                    varHis.WebsiteUrl = original.WebsiteUrl;
                    varHis.TrackingURL = original.TrackingURL;
                    varHis.PriceType = Convert.ToInt32(original.PriceType);
                    varHis.Status = Convert.ToInt32(original.Status);
                    varHis.MaximumCommision = com.MaximumCommision.HasValue ? com.MaximumCommision : null;
                    varHis.CreatedDate = DateTime.Now;
                    model.AddToAdv_Commision_HISTORYs(varHis);
                    model.SaveChanges();

                });
                model.SaveChanges();
                model.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void InsertCommision(Merchant_Commision _commision)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            var original = model.Adv_Commisions.Where(c => c.PID == _commision.PID).SingleOrDefault();
            if (original != null)
            {
                original.ProgramName = _commision.ProgramName;
                original.ProductDescription = _commision.ProductDescription;
                original.Sector = _commision.Sector;
                original.PayoutType = _commision.PayoutType;
                original.CookieDuration = _commision.CookieDuration;
                original.DeepLinkEnabled = Convert.ToInt16(_commision.DeepLinkEnabled);
                original.ProductfeedAvailable = Convert.ToInt16(_commision.ProductfeedAvailable);
                original.UIDTracking = Convert.ToInt16(_commision.UIDTracking);
                original.PriceType = Convert.ToInt32(_commision.PriceType);
                original.Commision = _commision.Commision;
                original.UpdatedDate = DateTime.Now;
                model.SaveChanges();
            }
            else
            {
                Adv_Commision var = new Adv_Commision();
                var.MerchantID = _commision.MerchantID;

                var.ProgramName =ReduceString(_commision.ProgramName,148);
                var.Commision = _commision.Commision;
                var.UserCommision = _commision.UserCommision;
                var.Currency = _commision.Currency;

                var.PID = _commision.PID;
                // var.MerchantLogoUrl = _commision.MerchantLogoUrl;
                var.ProgramName = _commision.ProgramName;
                var.ProductDescription = _commision.ProductDescription;
                var.Sector = _commision.Sector;
                var.PayoutType = _commision.PayoutType;
                var.CookieDuration = _commision.CookieDuration;
                var.DeepLinkEnabled = Convert.ToInt16(_commision.DeepLinkEnabled);
                var.ProductfeedAvailable = Convert.ToInt16(_commision.ProductfeedAvailable);
                var.UIDTracking = Convert.ToInt16(_commision.UIDTracking);
                var.WebsiteUrl = _commision.WebsiteUrl;
                var.TrackingURL = _commision.TrackingURL;
                var.PriceType = Convert.ToInt32(_commision.PriceType);
                var.Status = Convert.ToInt32(_commision.Status);
                var.MaximumCommision = _commision.MaximumCommision.HasValue ? _commision.MaximumCommision : null;
                //var.UpdatedDate = DateTime.Now;
                model.AddToAdv_Commisions(var);
                model.SaveChanges();

                var comHistory = model.Adv_Commision_HISTORYs.Where(h => h.PID == _commision.PID);
                if (comHistory == null)
                {
                    Adv_Commision_HISTORY varHis = new Adv_Commision_HISTORY();
                    varHis.MerchantID = original.MerchantID;
                    varHis.Commision = original.Commision;
                    varHis.UserCommision = original.UserCommision;
                    varHis.Currency = original.Currency;
                    varHis.COMID = var.CommisionID;
                    varHis.PID = original.PID;
                    // var.MerchantLogoUrl = _commision.MerchantLogoUrl;
                    varHis.ProgramName = ReduceString(original.ProgramName, 148);
                    varHis.ProductDescription = original.ProductDescription;
                    varHis.Sector = original.Sector;
                    varHis.PayoutType = original.PayoutType;
                    varHis.CookieDuration = original.CookieDuration;
                    varHis.DeepLinkEnabled = Convert.ToInt16(original.DeepLinkEnabled);
                    varHis.ProductfeedAvailable = Convert.ToInt16(original.ProductfeedAvailable);
                    varHis.UIDTracking = Convert.ToInt16(original.UIDTracking);
                    varHis.WebsiteUrl = original.WebsiteUrl;
                    varHis.TrackingURL = original.TrackingURL;
                    varHis.PriceType = Convert.ToInt32(original.PriceType);
                    varHis.Status = Convert.ToInt32(original.Status);
                    varHis.MaximumCommision = original.MaximumCommision.HasValue ? original.MaximumCommision : null;
                    varHis.CreatedDate = DateTime.Now;
                    model.AddToAdv_Commision_HISTORYs(varHis);
                    model.SaveChanges();
                }
            }
        }
    }

    public List<Merchant_Commision> DTO_Commisions(EntityCollection<Adv_Commision> _commisions)
    {
        List<Merchant_Commision> vList = new List<Merchant_Commision>();
        foreach (Adv_Commision var in _commisions)
        {
            Merchant_Commision item = new Merchant_Commision();
            item = DTO_Commision(var);
            vList.Add(item);
        }

        return vList;
    }
    public Merchant_Commision DTO_Commision(Adv_Commision _commision)
    {
        Merchant_Commision item = new Merchant_Commision();
        if (_commision != null)
        {
            item.CommisionID = _commision.CommisionID;
            item.MerchantID = _commision.MerchantID;
            item.MerchantName = _commision.Adv_Mst_Merchant.MerchantNameDetail;// ((Constants.NameOfMerchants)_commision.MerchantID).ToString();
            item.ProgramName = _commision.ProgramName;
            item.Commision = _commision.Commision;
            item.UserCommision = _commision.UserCommision;
            item.Currency = _commision.Currency;

            item.PID = _commision.PID;
            item.MerchantLogoUrl = _commision.Adv_Mst_Merchant.LogoUrl;
            item.ProgramName = _commision.ProgramName;
            item.ProductDescription = _commision.ProductDescription;
            item.Sector = _commision.Sector; 
            item.PayoutType = _commision.PayoutType;
            item.CookieDuration = _commision.CookieDuration;
            item.DeepLinkEnabled =_commision.DeepLinkEnabled.HasValue?(Constants.YesNo)_commision.DeepLinkEnabled:Constants.YesNo.No;
            item.ProductfeedAvailable = _commision.ProductfeedAvailable.HasValue ? (Constants.YesNo)_commision.ProductfeedAvailable : Constants.YesNo.No;
            item.UIDTracking = _commision.UIDTracking.HasValue ? (Constants.YesNo)_commision.UIDTracking : Constants.YesNo.No;
            item.WebsiteUrl = _commision.WebsiteUrl;
            item.TrackingURL = _commision.TrackingURL;

            item.PriceType = (Constants.PriceType)_commision.PriceType;
            item.Status = (Constants.Status)_commision.Status;
            item.MaximumCommision = _commision.MaximumCommision.HasValue?_commision.MaximumCommision:null;
            
            //item.PID = _commision.PID;
            //item.MerchantLogoUrl = _commision.MerchantLogoUrl;
            //item.ProgramName = _commision.ProgramName;
            //item.ProductDescription = _commision.ProductDescription;
            //item.Sector = _commision.Sector;
            //item.PayoutType = _commision.PayoutType;
            //item.CookieDuration = _commision.CookieDuration;
            //item.DeepLinkEnabled = Convert.ToInt16(_commision.DeepLinkEnabled);
            //item.ProductfeedAvailable = Convert.ToInt16(_commision.ProductfeedAvailable);
            //item.UIDTracking = Convert.ToInt16(_commision.UIDTracking);
            //item.WebsiteUrl = _commision.WebsiteUrl;
            //item.TrackingURL = _commision.TrackingURL;

            item.CurrencyName = _commision.Currency.HasValue?((Constants.CurrencyType)_commision.Currency).ToString():null;
        }

        return item;
    }
    #endregion

    #region "Banner"
    public void DeleteBanners(List<Int64> ids)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Trn_Banners.Where(x => ids.Contains(x.BannerID)).ToList().ForEach(model.Adv_Trn_Banners.DeleteObject);

            model.SaveChanges();
        }
    }
    public List<Merchant_Banner> GetAllBanners(int? bannerTypeID,int? categoryType=null)
    {
        List<Merchant_Banner> vList = new List<Merchant_Banner>();
        int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            //model.Connection.Open();
            var varlist = (from var in model.Adv_Trn_Banners
                           join mer in model.Adv_Mst_Merchants on var.MID equals mer.MID
                           where (bannerTypeID.HasValue ? var.BannerLocation == bannerTypeID : var.BannerLocation >= 0) && (var.Adv_Mst_Merchant.Status == CurrentStatus) && (categoryType!=null ? mer.CategoryType == categoryType : mer.CategoryType > 0)
                           select var);
            if (varlist != null)
            {
                foreach (Adv_Trn_Banner var in varlist)
                {
                    Merchant_Banner q = new Merchant_Banner();
                    q = DTO_Banner(var);
                    vList.Add(q);
                }
            }
        }
        return vList;
    }

    public void InsertBanner(Merchant_Banner _Banners)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_Trn_Banner var = new Adv_Trn_Banner();

            var.BannerText = _Banners.BannerText;

            var.BannerType = _Banners.BannerType;
          
            var.BannerURL =clsUtility.AppendUIDinHrefURl(_Banners.BannerURL);
            var.BannerLocation = _Banners.BannerLocation;
            var.Price = _Banners.Price;
            var.DiscountedPrice = _Banners.DiscountedPrice;
            var.Description = _Banners.Description;
            var.MID = _Banners.MID;

            //var.OfferForDevice = Convert.ToInt16(_Offer.CouponForDevice);
            //var.CreatedDate = DateTime.Now;

            model.AddToAdv_Trn_Banners(var);
            model.SaveChanges();
        }
    }

    public List<Merchant_Banner> DTO_Banners(EntityCollection<Adv_Trn_Banner> _Banners)
    {
        List<Merchant_Banner> vList = new List<Merchant_Banner>();
        foreach (Adv_Trn_Banner var in _Banners)
        {
            Merchant_Banner item = new Merchant_Banner();
            item = DTO_Banner(var);
            vList.Add(item);
        }

        return vList;
    }
    public Merchant_Banner DTO_Banner(Adv_Trn_Banner _Banner)
    {
        assignUSERID();  
        Merchant_Banner item = new Merchant_Banner();
        if (_Banner != null)
        {
            item.USERID = userID;
            item.ISLOGIN = IsUserLogin;

            item.BannerText = _Banner.BannerText;
            item.BannerID = _Banner.BannerID;
            item.BannerType = _Banner.BannerType;
            item.BannerURL = IsUserLogin ? _Banner.BannerURL.Replace("=cos", "=" + userID) : _Banner.BannerURL;
            item.MID = _Banner.MID;
            if (_Banner.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf(".") >= 0)
                item.MerchantName = _Banner.Adv_Mst_Merchant.MerchantNameDetail.Substring(0, _Banner.Adv_Mst_Merchant.MerchantNameDetail.ToString().IndexOf("."));
            else
                item.MerchantName = _Banner.Adv_Mst_Merchant.MerchantNameDetail;

           // item.MerchantName = _Banner.Adv_Mst_Merchant.MerchantNameDetail;
            item.LogoURL = _Banner.Adv_Mst_Merchant.LogoUrl;
            item.Price = _Banner.Price;
            item.DiscountedPrice = _Banner.DiscountedPrice;
            item.Description = _Banner.Description;
            
            if (_Banner.DiscountedPrice!=null && _Banner.DiscountedPrice > 0)
            {
                item.DiscountPercentageText = "<span style='text-decoration:line-through;'><small><b>Rs." + _Banner.Price.ToString() + "</b></small></span>&nbsp;&nbsp;" + " " + "<span style='color: Black;'><b>Rs." + _Banner.DiscountedPrice.ToString() + "</b></span> ";               
             
            }
            else if (_Banner.Price != null && _Banner.Price > 0 && (_Banner.DiscountedPrice == null || _Banner.DiscountedPrice == 0))
            {
                item.DiscountPercentageText = "<span style='color: Black;'><b>Rs " + _Banner.Price.ToString() + "</b></span> ";
            }

            //string i = clsUtility.AppendUIDinHrefURl(_Banner.BannerURL);
            item.BannerLocationName = _Banner.BannerLocation.HasValue ? ((Constants.BannerLocation)_Banner.BannerLocation.Value).ToString() : "";
            item.BannerTypeName =((Constants.BannerType)_Banner.BannerType).ToString();
            //item.MerchantDetail =DTO_Merchant(_Banner.Adv_Mst_Merchant);
        }

        return item;
    }
    #endregion

    #region "Transaction Feed"
    public void DeleteTransactionFeed(List<Int64> ids)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_OMG_Transactions.Where(x => ids.Contains(x.TransactionID)).ToList().ForEach(model.Adv_OMG_Transactions.DeleteObject);

            model.SaveChanges();
        }
    }

    public List<Transaction_Feed> GetSarchTransactionFeed(string fromdate, string todate, string amountStatus)
    {
        List<Transaction_Feed> vList = new List<Transaction_Feed>();
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);
            var varlist = (from var in model.Adv_OMG_Transactions
                           where var.TransactionTime >= dtFrom &&
                          var.TransactionTime <= dtTo
                           && var.Status == amountStatus
                           select var).OrderByDescending(o => o.OmgTransactionID);
            if (varlist.Any())
            {
                foreach (Adv_OMG_Transaction var in varlist)
                {
                    Transaction_Feed q = new Transaction_Feed();
                    q = DTO_TransactionFeed(var);
                    vList.Add(q);
                }
            }
        }
        return vList;
    }

    
    public List<Transaction_Feed> GetAllTransactionFeeds()
    {
        List<Transaction_Feed> vList = new List<Transaction_Feed>();
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
            {
                assignUSERID();
                           

                var varlistUser = (from var in model.Adv_OMG_Transactions
                                   where var.UID == userID
                                   select var).OrderByDescending(o =>o.OmgTransactionID); 
                if (varlistUser.Any())
                {
                    foreach (Adv_OMG_Transaction var in varlistUser)
                    {
                        Transaction_Feed q = new Transaction_Feed();
                        q = DTO_TransactionFeed(var);
                        vList.Add(q);
                    }
                }


            }
            else
            {
                var varlist = (from var in model.Adv_OMG_Transactions
                               where var.SendToUser==false
                               select var).OrderByDescending(o => o.OmgTransactionID);
                if (varlist.Any())
                {
                    foreach (Adv_OMG_Transaction var in varlist)
                    {
                        Transaction_Feed q = new Transaction_Feed();
                        q = DTO_TransactionFeed(var);
                        vList.Add(q);
                    }
                }
            }
        }
        return vList;
    }

    public void InsertTransactionFeed(Transaction_Feed _Transaction)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            if (model.Adv_OMG_Transactions.Any(a => a.OmgTransactionID == _Transaction.OmgTransactionID))
            {
                var original = model.Adv_OMG_Transactions.Where(c => c.OmgTransactionID == _Transaction.OmgTransactionID).SingleOrDefault();
                if (original != null)
                {
                    if (!string.IsNullOrEmpty(_Transaction.Status))
                        original.Status = _Transaction.Status;
                    if (!string.IsNullOrEmpty(_Transaction.SR))
                        original.SR = _Transaction.SR;
                    if (!string.IsNullOrEmpty(_Transaction.VR))
                        original.VR = _Transaction.VR;
                    if (!string.IsNullOrEmpty(_Transaction.NVR))
                        original.NVR = _Transaction.NVR;
                    if (_Transaction.FinalCommision>0)
                        original.FinalCommision = _Transaction.FinalCommision;
                    //if (!string.IsNullOrEmpty(_Transaction.Status))
                    //    original.UserPercentage = _Transaction.UserPercentage;
                    if (!string.IsNullOrEmpty(_Transaction.Paid))
                        original.Paid = _Transaction.Paid;
                    if (!string.IsNullOrEmpty(_Transaction.Completed))
                        original.Completed = _Transaction.Completed;

                    model.SaveChanges();
                }
                return;
            }

            Adv_OMG_Transaction item = new Adv_OMG_Transaction();

            item.ClickTime = _Transaction.ClickTime;
            item.TransactionTime = Convert.ToDateTime(_Transaction.TransactionTime);
            item.OmgTransactionID = _Transaction.OmgTransactionID;
            item.OmgMerchantRef = _Transaction.OmgMerchantRef;
            item.UID = _Transaction.UID.Replace("cos","0");
            item.UID2 = _Transaction.UID2;
            item.MID = _Transaction.MID;
            item.MerchantName = _Transaction.MerchantName;
            item.PID = _Transaction.PID;
            item.Product = _Transaction.Product;
            item.Referrer = _Transaction.Referrer;
            item.SR = _Transaction.SR;
            item.VR = _Transaction.VR;
            item.NVR = _Transaction.NVR;
            item.Status = _Transaction.Status;
            item.Paid = _Transaction.Paid;
            item.Completed = _Transaction.Completed;
            item.UKey = _Transaction.UKey;
            item.TransactionValue = _Transaction.TransactionValue;
            item.VoucherCode = _Transaction.VoucherCode;
            item.SendToUser = false;
            int mstPID = Convert.ToInt32(_Transaction.PID);
            var commAmount = (from p in model.Adv_Commisions
                             where p.PID == mstPID
                             select p).FirstOrDefault();
            if (commAmount != null)
            {
                item.Commision = commAmount.Commision;
                item.UserCommision = Convert.ToDecimal(commAmount.UserCommision);
                item.MaximumCommision = commAmount.MaximumCommision;
                item.PriceType = commAmount.PriceType;
            }
            //item.FinalCommision = _Transaction.FinalCommision;
            //item.UserPercentage = _Transaction.UserPercentage;

            model.AddToAdv_OMG_Transactions(item);
            model.SaveChanges();
        }
    }

    public void UpdateTransactionFeed(List<Int64> _TransactionIds)
    {
        try
        {

            using (var model = new Ad_ConnectionString())
            {
                var original = model.Adv_OMG_Transactions.Where(f => _TransactionIds.Contains(f.TransactionID)).ToList();
                original.ForEach(a => a.SendToUser = true);
                //Here Multiple value can be update here using this
                //original.ForEach(a =>
                //{
                //    a.SendToUser = true;
                //    a.SendToUser = true;
                //});
                model.SaveChanges();

                model.Dispose();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void UpdateTransactionFeed(List<Int64> _TransactionIds,Int16 statusAmount)
    {
        try
        {

            using (var model = new Ad_ConnectionString())
            {
                var original = model.Adv_OMG_Transactions.Where(f => _TransactionIds.Contains(f.TransactionID)).ToList();
                original.ForEach(a => a.AmountStatus= statusAmount);
                
                model.SaveChanges();

                model.Dispose();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public List<Transaction_Feed> DTO_TransactionFeeds(EntityCollection<Adv_OMG_Transaction> _Banners)
    {
        List<Transaction_Feed> vList = new List<Transaction_Feed>();
        foreach (Adv_OMG_Transaction var in _Banners)
        {
            Transaction_Feed item = new Transaction_Feed();
            item = DTO_TransactionFeed(var);
            vList.Add(item);
        }

        return vList;
    }
    public Transaction_Feed DTO_TransactionFeed(Adv_OMG_Transaction _Transaction)
    {
        Transaction_Feed item = new Transaction_Feed();
        if (_Transaction != null)
        {
            item.TransactionID = _Transaction.TransactionID;
            item.ClickTime = _Transaction.ClickTime;
            item.TransactionTime = Convert.ToDateTime(_Transaction.TransactionTime);
            item.OmgTransactionID = _Transaction.OmgTransactionID;
            item.OmgMerchantRef = _Transaction.OmgMerchantRef;
            item.UID = _Transaction.UID;
            item.UID2 = _Transaction.UID2;
            item.MID = _Transaction.MID;
            item.MerchantImage =FindMerchantMID(Convert.ToInt32(_Transaction.MID)).MerchantImage;// _Transaction.MerchantName;
            item.MerchantName = FindMerchantMID(Convert.ToInt32(_Transaction.MID)).MerchantNameDetail;
            if (!string.IsNullOrEmpty(_Transaction.UID))
            {
                item.UserName = GetUserByuserID(Convert.ToInt64(_Transaction.UID)).FullName;
                item.UserEmail = GetUserByuserID(Convert.ToInt64(_Transaction.UID)).EmailID;
            }
            else
            {
                item.UserName ="Default";
                item.UserEmail = "aashishshar@gmail.com";
            }
            item.PID = _Transaction.PID;
            item.Product = _Transaction.Product;
            item.Referrer = _Transaction.Referrer;
            item.SR = _Transaction.SR;
            item.VR = _Transaction.VR;
            item.NVR = _Transaction.NVR;
           
            item.Paid = _Transaction.Paid;
            item.Completed = _Transaction.Completed;
            item.UKey = _Transaction.UKey;
            item.TransactionValue = _Transaction.TransactionValue;
            item.VoucherCode = _Transaction.VoucherCode;
            item.SendToUser = _Transaction.SendToUser.HasValue ? _Transaction.SendToUser.Value : false;
            item.FinalCommision = _Transaction.FinalCommision;
            item.UserPercentage = _Transaction.UserPercentage;//Constants.AmountStatus
            if (_Transaction.AmountStatus.HasValue)
                item.AmountStatus = (Constants.AmountStatus)_Transaction.AmountStatus;
            else
                item.AmountStatus = Constants.AmountStatus.Pending;

            if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
            {
                if (_Transaction.Status == Constants.AmountStatus.Validated.ToString() && _Transaction.AmountStatus == 2)
                    item.Status = _Transaction.Status;
                else if (_Transaction.Status == Constants.AmountStatus.Rejected.ToString())
                    item.Status = Constants.AmountStatus.Rejected.ToString();
                else
                    item.Status = Constants.AmountStatus.Pending.ToString();
            }
            else
                item.Status = _Transaction.Status;

        }

        return item;
    }
    #endregion

    #region "Wallet History"
    public List<Wallet_History> GetWallet_Histroy()
    {
        //DataTable dt = new DataTable();
        //List<Wallet_History> vList = new List<Wallet_History>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            //var oMyString = new ObjectParameter("UID", typeof(string));
            //var oMyStringDT = new ObjectParameter("RecordCount", typeof(DataTable));
            if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
            {
                assignUSERID();
            }
            else
            {
                return null;
            }
            //var list1 = (from var in model.Adv_WalletHistory(userID)
            //            select var).ToList().ToEntityCollection();
            clsFramework objFramework = new clsFramework();

            SqlParameter[] parameters =
        {    
            new SqlParameter("@uid", SqlDbType.VarChar) { Value = userID }
        };
            DataTable dt = objFramework.GetRecordSet("Adv_WalletHistory", CommandType.StoredProcedure, parameters);
            if (dt == null)
            {
                return null;
            }
                var list = (from var in dt.AsEnumerable()
                            select new Wallet_History
                            {
                                PendingAmount = var.Field<string>("PendingAmount"),
                                ValidatedAmount = var.Field<string>("ValidatedAmount"),
                                TransferableAmount = var.Field<string>("TransferableAmount"),
                                RejectedAmount = var.Field<string>("RejectedAmount"),
                                RechargeAmount = var.Field<string>("RechargeAmount")
                            }).ToList();

                return list;
           

           
            //totalRecord = Convert.ToInt32(oMyString.Value.ToString());


            //foreach (vw_Offer_List var in list.OrderByDescending(o => o.CreatedDate))
            //{
              //  Merchant_Offer q = new Merchant_Offer();
               // q = DTO_vw_To_Offer(var);
               // vList.Add(q);
            //} 
            
           
        }
       
    }
#endregion 

    #region "Missing Cashback"


    public void DeleteCashIssue(List<int> IDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_MissingCashbacks.Where(x => IDs.Contains(x.TicketNo)).ToList().ForEach(model.Adv_MissingCashbacks.DeleteObject);

            model.SaveChanges();
        }
    }


    public List<MissingCashBack> GetAllMissingCashBacks()
    {
        List<MissingCashBack> vList = new List<MissingCashBack>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            if (HttpContext.Current.User.IsInRole(Constants.RoleNamePreDefine.User.ToString()))
            {
                Guid userid=(Guid)Membership.GetUser().ProviderUserKey;
                var varlistA = from var in model.Adv_MissingCashbacks
                               where var.UserID == userid 
                              select var;

                foreach (Adv_MissingCashback var in varlistA)
                {
                    MissingCashBack q = new MissingCashBack();
                    q = DTO_CashIssue(var);
                    vList.Add(q);
                }
            }
            else
            {
                var varlist = from var in model.Adv_MissingCashbacks
                              select var;

                foreach (Adv_MissingCashback var in varlist)
                {
                    MissingCashBack q = new MissingCashBack();
                    q = DTO_CashIssue(var);
                    vList.Add(q);
                }
            }
        }
        return vList.OrderByDescending(o=>o.CreatedDate).ToList();
    }

    public void UpdateCashIssue(MissingCashBack _item)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var original = model.Adv_MissingCashbacks.Where(c => c.TicketNo == _item.TicketNo).SingleOrDefault();
            if (original != null)
            {
                if (_item.Status > 0)
                    original.Status =Convert.ToInt32(_item.Status);

                if (_item.MailSend.HasValue)
                    original.IsMailSend = _item.MailSend;
               
                model.SaveChanges();
            }
        }
    }
    public void InsertCashIssue(MissingCashBack _item)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_MissingCashback item = new Adv_MissingCashback();
            item.TransactionDate = _item.TransactionDate;
            item.MID = _item.MID;
            item.UserID = (Guid)Membership.GetUser().ProviderUserKey;
            item.OrderID = _item.OrderID;
            item.AmountPaid = _item.AmountPaid;
            item.CouponCode = _item.CouponCode;
            item.Details = _item.Details;
            item.FileUrl = _item.FileUrl;
            item.ContactNo = _item.ContactNo;
            item.CreatedDate = DateTime.Now;
            item.Status =Convert.ToInt16(_item.Status);

            model.AddToAdv_MissingCashbacks(item);
            model.SaveChanges();
        }
    }
        
    public List<MissingCashBack> DTO_CashIssueAll(EntityCollection<Adv_MissingCashback> _item)
    {
        List<MissingCashBack> vList = new List<MissingCashBack>();
        foreach (Adv_MissingCashback var in _item)
        {
            MissingCashBack item = new MissingCashBack();
            item = DTO_CashIssue(var);
            vList.Add(item);
        }

        return vList;
    }
    public MissingCashBack DTO_CashIssue(Adv_MissingCashback _item)
    {
        assignUSERID();
        MissingCashBack item = new MissingCashBack();
        if (_item != null)
        {
            item.TransactionDate = _item.TransactionDate;
            item.MID = FindMerchant(Convert.ToInt64(_item.MID)).OMGMID;// _item.MID;
            item.TicketNo = _item.TicketNo;
            item.UserID = _item.UserID;
            item.MailSend = _item.IsMailSend;
            MembershipUser user = Membership.GetUser(_item.UserID);
            if (user != null)
            {
                item.UserName = user.UserName;
            }
            //item.UserName =Membership.GetUser( GetUserByuserID(_item.UserID).;
            item.OrderID = _item.OrderID;
            item.AmountPaid = _item.AmountPaid; ;
            item.CouponCode = _item.CouponCode;
            item.Details = _item.Details;
            item.FileUrl = _item.FileUrl;
            item.ContactNo = _item.ContactNo;
            item.CreatedDate = _item.CreatedDate;
            item.Status = (Constants.Status)_item.Status;
            item.MerchantLogoUrl = FindMerchant(Convert.ToInt64(_item.MID)).MerchantImage;
            item.MerchantName = FindMerchant(Convert.ToInt64(_item.MID)).MerchantNameDetail;
        }

        return item;
    }
    #endregion

    #region "Notification"


    public void DeleteNotification(List<int> IDs)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.Adv_Notifications.Where(x =>IDs.Contains(x.NotificationId)).ToList().ForEach(model.Adv_Notifications.DeleteObject);

            model.SaveChanges();
        }
    }


    public List<Notification> GetAllNotification()
    {
        List<Notification> vList = new List<Notification>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = from var in model.Adv_Notifications
                              select var;

                foreach (Adv_Notification var in varlist)
                {
                    Notification q = new Notification();
                    q = DTO_Notification(var);
                    vList.Add(q);
                }
           
        }
        return vList;
    }

    public List<Notification> GetNotificationTextByType(Int16 notificationType)
    {
        List<Notification> vList = new List<Notification>();
        //int CurrentStatus = Convert.ToInt16(Constants.Status.Active);
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            var varlist = (from var in model.Adv_Notifications
                          where var.NotificationType == notificationType
                          select var).OrderByDescending(d=>d.CreatedDate).SingleOrDefault();

            if (varlist != null)
            {
                vList.Add(DTO_Notification(varlist));
            }

        }
        return vList;
    }

    public void UpdateNotification(Notification _item)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
        }
    }
    public void InsertNotification(Notification _item)
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {

            Adv_Notification item = new Adv_Notification();
            item.NotificationText = _item.NotificationText;            
            item.NotificationType = Convert.ToInt16(_item.NotificationType);                     
            item.CreatedDate = DateTime.Now;
            item.Status = Convert.ToInt16(_item.Status);
            model.AddToAdv_Notifications(item);
            model.SaveChanges();
        }
    }

    public List<Notification> DTO_Notification(EntityCollection<Adv_Notification> _item)
    {
        List<Notification> vList = new List<Notification>();
        foreach (Adv_Notification var in _item)
        {
            Notification item = new Notification();
            item = DTO_Notification(var);
            vList.Add(item);
        }

        return vList;
    }
    public Notification DTO_Notification(Adv_Notification _item)
    {
        //assignUSERID();
        Notification item = new Notification();
        if (_item != null)
        {
            item.NotificationID = _item.NotificationId;
            item.NotificationText = _item.NotificationText;
            item.NotificationType =(Constants.NotificationType)_item.NotificationType;                  
            item.CreatedDate = _item.CreatedDate;
            item.Status = (Constants.Status)_item.Status;           
        }

        return item;
    }
    #endregion
}