using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


public class Constants
{
    #region "Affiliate ID"
    //public const string DefaultUserImageUrl = "~/ProfilePic/Default/user-image.png";
    public const string FlipKart_AffiliateId = "aashishsh";
    public const string FlipKart_AffiliateToken = "7fbe41311d1241a2afd9e164028f7cf6";
    public const string OMG_TrackinfURL_AID = "http://track.in.omgpm.com/?AID=764019&";
    public const string SEO_Title = "Cashonshop.com|Best Cashback Offers & Online Shopping Coupons on 100 + Websites|Recharge|Bill Payment";
    public const string SEO_Description = "Get Cashback Offers, Discount Coupons & Promo Codes for India's Top Online Selling Websites like Shopclues, Amazon, Paytm, Greendust, Snapdeal & many more. Join Us Free @Cashonshop.com!";
    public const string SEO_Keyword = "Extra Cash On Shopping, Discount Coupons, Cash Back Sites, Extra Cashback Online,Online Cashback, Free Deals, Free Shopping Deals, Free Coupons, Free Offers, Free Shopping Coupons, Free Cashback Deals, Extra Cashback, Best Cashback Sites, Online Shopping Coupons, Cashback Coupons, Cashback Shopping, Best Offers On Online Shopping";
    public const string ExcludeMerchant = "flipkart.com,snapdeal.com";

    #endregion

    #region "Affiliate API URL"
    public const string DefaultUserImageUrl = "~/ProfilePic/Default/user-image.png";
    public const string FlipKart_DOTD_Offers_API = "https://affiliate-api.flipkart.net/affiliate/offers/v1/dotd/json";
    public const string FlipKart_Product_Feeds_API = "https://affiliate-api.flipkart.net/affiliate/api/" + FlipKart_AffiliateId + ".json";
    public const string FlipKart_TOP_Offers_API = "https://affiliate-api.flipkart.net/affiliate/offers/v1/top/json";
    public const string FlipKart_API_Search_Query_based_Product_ID = "https://affiliate-api.flipkart.net/affiliate/product/json?id=";
    public const string OmgVoucherCode = "https://admin.omgpm.com/v2/VoucherCodes/Affiliate/ExportVoucherCodes.ashx?Auth=95:764019:31600E6D4717172FC8C62F9C1D35CE11&Status=Active&Format=Xml&Agency=95";
    public const string AmericanSwanCPA = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=357&Format=xml";
    public const string JabongcomSales = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=283&Format=xml";
    public const string KoovscomCostPerSale = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=335&Format=xml";
    public const string MyntracomSaleExistingUser = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=304&Format=xml";
    public const string PaytmPaytmnonrecharge = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=352&Format=xml";
    public const string TrendincomCostPerSale = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=321&Format=xml";
    public const string ZoviComSale = "http://feeds.omgpm.com/GetFeed/?aid=764019&feedid=277&Format=xml";

    #endregion

    public enum RoleNamePreDefine
    {
        Administrator,
        User,
        Author
    };

    public enum FromAddress
    {
        Care,
        Info,
        Newsletter,
        Support
    };

    public enum Action
    {
        Insert,
        Update,
        Delete
    };

    public enum Master
    {
        Category,
        SubCategory,
        Merchant,
        Coupon,
        Offer,
        Deal,
        Campaigns,
        ApiURL,
        Commision,
        Banner,
        Wallet,
        Payment,
        Cashback,
        Profile,
        DashBoard,
        Password,
        Notification,
        MissingCashback
    };

    public enum Availability
    {
        [Description("In-stock")]
        InStock,
        [Description("Out-stock")]
        OutStock
    }

    public enum Device
    {
        [Description("Website Channel")]
        Desktop,
        [Description("Mobile App")]
        Mobile

    }

    public enum BannerType
    {
        [Description("Image")]
        Image,
        [Description("Html Content")]
        Html,
        [Description("Flash Banners")]
        Flash,
        [Description("Editorial")]
        Editorial,
        [Description("Mixed")]
        Mixed,
        [Description("TextLink")]
        TextLink,
        [Description("Email")]
        Email
    }

    public enum BannerLocation
    {
        [Description("Left Top Crousal")]
        LeftTop,
        [Description("Right Top")]
        RightTop,
        [Description("Left Bottom")]
        LeftBottom,
        [Description("Right Bottom")]
        RightBottom,
         [Description("Left Crowsel Home")]
        LeftCrowselWindow,
         [Description("Email Image Marketing")]
         EmailImageMarketing
    }

    public enum MailFormatContentType
    {
        [Description("Image Template")]
        ImageContent,
        [Description("Offer Content")]
        OfferContent
    }

    public enum CurrencyType
    {
        [Description("INR")]
        INR,
        [Description("USD")]
        USD
    }

    public enum MerchantDeepLinkType
    {
        [Description("Payoom")]
        Payoom,
        [Description("OMGPM")]
        OMGPM
    }

    public enum NameOfMerchants
    {
        //[Description("184858_100bestbuy.com")]
        //bestbuycom = 34,
        //[Description("743116_Aasha-online.com")]
        //Aashaonlinecom = 35,
        //[Description("747840_ace2three")]
        //ace2three = 36,
        //[Description("712998_Acropolis")]
        //Acropolis = 37,
        //[Description("595677_Adda52")]
        //Adda52 = 38,
        //[Description("748432_Adlabs Entertainment")]
        //AdlabsEntertainment = 39,
        //[Description("715876_Agoda")]
        //Agoda = 40,
        //[Description("703012_Air Asia- AEGIS")]
        //AirAsiaAEGIS = 41,
        //[Description("676364_Aircel")]
        //Aircel = 42,
        //[Description("693537_Airstream")]
        //Airstream = 43,
        //[Description("516635_Airtel")]
        //Airtel = 44,
        //[Description("665833_Airtel Online Recharge")]
        //AirtelOnlineRecharge = 45,
        //[Description("743102_ali-ina.com")]
        //aliinacom = 46,
        //[Description("660352_Amar Chitra katha")]
        //AmarChitrakatha = 47,
        //[Description("739111_American Express")]
        //AmericanExpress = 48,
        ////[Description("523796_American Swan")]
        ////AmericanSwan = 49,
        //[Description("715267_Angel Broking")]
        //AngelBroking = 50,
        //[Description("695593_Ashiana")]
        //Ashiana = 51,
        //[Description("659534_Asian Paints")]
        //AsianPaints = 52,       
        //[Description("707061_Axis Bank")]
        //AxisBank = 54,       
        //[Description("192436_Babyoye.com")]
        //Babyoyecom = 56,
        //[Description("691486_Bankbazar.com")]
        //Bankbazarcom = 57,
        //[Description("660390_Bharatmatrimony")]
        //Bharatmatrimony = 58,
        //[Description("640427_BigfLix")]
        //BigfLix = 59,
        //[Description("769127_Bing")]
        //Bing = 60,
        //[Description("671651_Birla Mutual Fund")]
        //BirlaMutualFund = 61,
        //[Description("701606_Booking Khazana")]
        //BookingKhazana = 62,
        //[Description("332564_Bookmyflowers.com")]
        //Bookmyflowerscom = 63,
        //[Description("672265_Buongiorno")]
        //Buongiorno = 64,
        //[Description("551253_BuyHatke")]
        //BuyHatke = 65,
        //[Description("598762_BVP")]
        //BVP = 66,
        //[Description("579264_Cairon.me")]
        //Caironme = 67,
        //[Description("773803_Campus Sutra")]
        //CampusSutra = 68,
        //[Description("529741_Candere")]
        //Candere = 69,
        //[Description("759482_Car Trade")]
        //CarTrade = 70,
        //[Description("629887_Chumbak.com")]
        //Chumbakcom = 71,
        //[Description("655147_Citi Bank")]
        //CitiBank = 72,
        //[Description("195797_Cleartrip Private Limited")]
        //CleartripPrivateLimited = 73,
        //[Description("751203_Club Mahindra")]
        //ClubMahindra = 74,
        //[Description("612812_Coke2home")]
        //Coke2home = 75,
        //[Description("705111_Collegedunia")]
        //Collegedunia = 76,
        //[Description("679042_Cord Life")]
        //CordLife = 77,
        //[Description("555354_Daburaroma.com")]
        //Daburaromacom = 78,
        //[Description("391962_Dailyobjects.com")]
        //Dailyobjectscom = 79,
        //[Description("692459_Darveys.com")]
        //Darveyscom = 80,
        //[Description("657300_DBS")]
        //DBS = 81,
        //[Description("584203_Deal4loans")]
        //Deal4loans = 82,
        //[Description("754096_DealPly")]
        //DealPly = 83,
        //[Description("599428_Dell.co.in")]
        //Dell_co_in = 84,
        //[Description("703161_Designemporia")]
        //Designemporia = 85,
        //[Description("754565_Diagnose Coupon")]
        //DiagnoseCoupon = 86,
        //[Description("751966_Dishtv")]
        //Dishtv = 87,
        //[Description("779634_Dogspot.in")]
        //Dogspotin = 88,
        //[Description("772511_Droom.in")]
        //Droomin = 89,
        //[Description("770437_Dx.com")]
        //Dxcom = 90,
        //[Description("619500_Easypolicy.com")]
        //Easypolicycom = 91,
        //[Description("673024_Ebay")]
        //Ebay = 92,
        //[Description("692121_Edukart")]
        //Edukart = 93,
        //[Description("769113_ELITIFY")]
        //ELITIFY = 94,
        //[Description("603791_Etihad Airways")]
        //EtihadAirways = 95,
        //[Description("770435_Eureka Forbes")]
        //EurekaForbes = 96,
        //[Description("763566_Evok.in")]
        //Evokin = 97,
        //[Description("155755_Expedia")]
        //Expedia = 98,
        //[Description("519499_ezeego1.co.in")]
        //ezeego1coin = 99,
        //[Description("598830_Faballey.com")]
        //Faballeycom = 100,
        //[Description("324020_Fabfurnish.com")]
        //Fabfurnishcom = 101,
        //[Description("754240_Fabindia")]
        //Fabindia = 102,
        //[Description("769749_Faircent")]
        //Faircent = 103,
        //[Description("362378_Fashionara Enterprise Private Ltd")]
        //FashionaraEnterprisePrivateLtd = 104,
        //[Description("176598_Ferns N Petals Pvt. Ltd.")]
        //FernsNPetalsPvtLtd = 105,
        //[Description("453300_Fetise.com")]
        //Fetisecom = 106,
        //[Description("34863_FindYahan")]
        //FindYahan = 107,
        //[Description("382128_Firstcry.com")]
        //Firstcrycom = 108,
        //[Description("672194_Fisher Price")]
        //FisherPrice = 109,
        //[Description("670306_Flexing it Services Pvt Ltd")]
        //FlexingitServicesPvtLtd = 110,    
        //[Description("687903_Flirchi.com")]
        //Flirchicom = 111,
        //[Description("494299_Floweraura")]
        //Floweraura = 112,
        //[Description("673684_Foreseegame")]
        //Foreseegame = 113,
        //[Description("745374_Forever21")]
        //Forever21 = 114,
        //[Description("644513_Frankfinn")]
        //Frankfinn = 115,
        //[Description("420563_Freecharge.in")]
        //Freechargein = 116,
        //[Description("555943_Fundsindia.com")]
        //Fundsindiacom = 117,
        //[Description("709952_Game Of War")]
        //GameOfWar = 118,
        //[Description("523843 Getitbazaar.com")]
        //Getitbazaarcom = 119,
        //[Description("710332 Gifts By Meeta")]
        //GiftsByMeeta = 120,
        //[Description("757042 Giftsnideas")]
        //Giftsnideas = 121,
        //[Description("327612 Globus")]
        //Globus = 122,
        //[Description("680899 GM Test Drive")]
        //GMTestDrive = 123,
        //[Description("645727 GNIIT")]
        //GNIIT = 124,
        //[Description("735870 GOSF")]
        //GOSF = 125,
        //[Description("619435 GRABMORE INTERNET PVT LTD")]
        //GRABMOREINTERNETPVTLTD = 126,
        //[Description("04223 Greendust.com")]
        //Greendustcom = 127,
        //[Description("447877 Greetzap.com")]
        //Greetzapcom = 128,
        //[Description("499760 Groupon.co.in")]
        //Grouponcoin = 129,
        //[Description("754220 Handygo.com")]
        //Handygocom = 130,
        //[Description("776794 HCL Technologies")]
        //HCLTechnologies = 131,
        //[Description("656509 HDFC BANK")]
        //HDFCBANK = 132,
        //[Description("670605 HDFC BANK Auto Loan")]
        //HDFCBANKAutoLoan = 133,
        //[Description("754099 HDFC Life C2PP")]
        //HDFCLifeC2PP = 134,
        //[Description("674497 Healthgenie.in")]
        //Healthgeniein = 135,
        //[Description("763644 Healthians")]
        //Healthians = 136,
        //[Description("752612 Healthkart.com")]
        //Healthkartcom = 137,
        //[Description("758909 Health-total")]
        //Healthtotal = 138,
        //[Description("378517 Hilton.com")]
        //Hiltoncom = 139,
        //[Description("606497 Himalaya")]
        //Himalaya = 140,
        //[Description("535020 HolidayIQ.com")]
        //HolidayIQcom = 141,
        //[Description("331902 Homeshop18.com")]
        //Homeshop18com = 142,
        //[Description("681251 Honda Motor Scooter India")]
        //HondaMotorScooterIndia = 143,
        //[Description("361822 Hotels.com")]
        //Hotelscom = 144,
        //[Description("743540 Housing.com")]
        //Housingcom = 145,
        //[Description("569035 IACT Global Education Pvt. Ltd")]
        //IACTGlobalEducationPvtLtd = 146,
        //[Description("659530 Idea worldwide")]
        //Ideaworldwide = 147,
        //[Description("706358 IDP Education India Pvt ltd")]
        //IDPEducationIndiaPvtltd = 148,
        //[Description("643391 IIM L")]
        //IIML = 149,
        //[Description("760122 Imobile")]
        //Imobile = 150,
        //[Description("747162 IMRB")]
        //IMRB = 151,
        //[Description("470042 Indiacircus.com")]
        //Indiacircuscom = 152,
        //[Description("674817 IndianGiftsportal")]
        //IndianGiftsportal = 153,
        //[Description("629054 Indiaproperty.com")]
        //Indiapropertycom = 154,
        //[Description("475309 Indiarush.com")]
        //Indiarushcom = 155,
        //[Description("312452 Inkfruit")]
        //Inkfruit = 156,
        //[Description("155514 Jet Airways (India) Ltd")]
        //JetAirways = 157,
        //[Description("603828 Junglee.com")]
        //Jungleecom = 158,
        //[Description("739175 Just Recharge It")]
        //JustRechargeIt = 159,
        //[Description("762513 Kenscio American Express")]
        //KenscioAmericanExpress = 160,
        //[Description("595671 Kotak")]
        //Kotak = 161,
        //[Description("774516 Kotak Mahindra Bank")]
        //KotakMahindraBank = 162,
        //[Description("723659 Learn Social")]
        //LearnSocial = 163,
        //[Description("350174 Lenskart.com")]
        //Lenskartcom = 164,
        //[Description("636059 Levi's")]
        //Levi = 165,
        //[Description("477707 Limeroad.com")]
        //Limeroadcom = 166,
        //[Description("656128 Lodha")]
        //Lodha = 167,
        //[Description("705062 LODHA Cost Per Mailer")]
        //LODHACostPerMailer = 168,
        //[Description("674503 LSBF")]
        //LSBF = 169,
        //[Description("688733 Lufthansa Airlines")]
        //LufthansaAirlines = 170,
        //[Description("Luxottica Group S.p.A")]
        //LuxotticaGroupSpA = 171,
        //[Description("Makemytrip.com")]
        //Makemytripcom = 172,
        //[Description("Mastercard Usgae Campaign")]
        //MastercardUsgaeCampaign = 173,
        //[Description("Max Bupa")]
        //MaxBupa = 174,
        //[Description("Max Life Insurance Company Limited")]
        //MaxLifeInsuranceCompanyLimited = 175,
        //[Description("MIS")]
        //MIS = 176,
        //[Description("MLZS")]
        //MLZS = 177,
        //[Description("Mobikwik")]
        //Mobikwik = 178,
        //[Description("Mobogenie")]
        //Mobogenie = 179,
        //[Description("MSN")]
        //MSN = 180,
        //[Description("Muthoot Finance")]
        //MuthootFinance = 181,
        //[Description("Myflowertree")]
        //Myflowertree = 182,
        //[Description("Myntra.com")]
        //Myntracom = 183,
        //[Description("Mysmartleap")]
        //Mysmartleap = 184,
        //[Description("Net distribution Pvt. Ltd.")]
        //NetdistributionPvtLtd = 185,
        //[Description("NIIT")]
        //NIIT = 186,
        //[Description("NIIT Imperia")]
        //NIITImperia = 187,
        //[Description("Nissan")]
        //Nissan = 188,
        //[Description("Nokia")]
        //Nokia = 189,
        //[Description("Nykaa.com")]
        //Nykaacom = 190,
        //[Description("OLX.in")]
        //OLXin = 191,
        //[Description("One Assist=34,")]
        //OneAssist = 192,
        //[Description("Paytm promotion")]
        //Paytmpromotion = 193,
        //[Description("PayU Money")]
        //PayUMoney = 194,
        //[Description("People lnteractive(l) Pvt Ltd")]
        //PeoplelnteractivePvtLtd = 195,
        //[Description("Pepperfry.com")]
        //Pepperfrycom = 196,
        //[Description("Perfect MBA.com")]
        //PerfectMBAcom = 197,
        //[Description("Phillipines Tourism")]
        //PhillipinesTourism = 198,
        //[Description("Pickupflowers")]
        //Pickupflowers = 199,
        //[Description("PNBHFL")]
        //PNBHFL = 200,
        //[Description("Policy Advisor")]
        //PolicyAdvisor = 201,
        //[Description("Prettysecrets.com")]
        //Prettysecretscom = 202,
        //[Description("Printvenue.com")]
        //Printvenuecom = 203,
        //[Description("Amazon.com")]
        //purpllecom = 204,
        //[Description("Quikr.com")]
        //Quikrcom = 205,
        //[Description("Realvista")]
        //Realvista = 206,
        //[Description("Redbus")]
        //Redbus = 207,
        //[Description("Rediff Shopping")]
        //RediffShopping = 208,
        //[Description("Samsung")]
        //Samsung = 209,
        //[Description("Samsung Note III")]
        //SamsungNoteIII = 210,
        //[Description("Sare Properties")]
        //SareProperties = 211,
        //[Description("Sharekhan Ltd")]
        //SharekhanLtd = 212,
        //[Description("Shine")]
        //Shine = 213,
        //[Description("Sikkim Manipal")]
        //SikkimManipal = 214,
        //[Description("690131 Simplilearn")]
        //Simplilearn = 215,
        //[Description("595551 Simplymarry.com")]
        //Simplymarrycom = 216,
        //[Description("701197 SOIL India")]
        //SOILIndia = 218, 
        //[Description("768201 South African Tourism")]
        //SouthAfricanTourism = 219,
        //[Description("694625 Soyng.com")]
        //Soyngcom = 220, 
        //[Description("569109 SpringFragrance Pvt Ltd")]
        //SpringFragrancePvtLtd = 221,        
        //[Description("642089 Standard Charted Credit Card")]
        //StandardChartedCreditCard = 223,
        //[Description("668413 Standard Chartered Personal Loan")]
        //StandardCharteredPersonalLoan = 224,
        //[Description("389383 StarCJ")]
        //StarCJ = 225,
        //[Description("209814 Suratdiamond.com")]
        //Suratdiamondcom = 226,
        //[Description("691502 Surpluss.in")]
        //Surplussin = 227,
        //[Description("659288 Symbiosis")]
        //Symbiosis = 228,
        //[Description("662471 Tapmi")]
        //Tapmi = 229,
        //[Description("745378 Tara medium")]
        //Taramedium = 230,
        //[Description("715834 Tarsan MVAS Private Limited")]
        //TarsanMVASPrivateLimited = 231,
        //[Description("762469 TaskBucks")]
        //TaskBucks = 232,
        //[Description("644730 Tata Docomo")]
        //TataDocomo = 233,
        //[Description("717938 TATA Docomo Broadband")]
        //TATADocomoBroadband = 234, 
        //[Description("654698 Tata Motors")]
        //TataMotors = 235,
        //[Description("663999 Taxi For Sure")]
        //TaxiForSure = 236,
        //[Description("769391 theelectronicstore.in")]
        //theelectronicstorein = 237,
        //[Description("625128 Thekha.com")]
        //Thekhacom = 238,
        //[Description("716700 Times Pro")]
        //TimesPro = 239,
        //[Description("669042 TimesGuru")]
        //TimesGuru = 240,
        //[Description("624726 TimesJobs.com")]
        //TimesJobscom = 241,
        ////[Description("710739 Travel Khana")]
        ////TravelKhana = 242,
        //[Description("408660 Travel Mob")]
        //TravelMob = 243,
        //[Description("658087 Twillsonline.com")]
        //Twillsonlinecom = 244,
        //[Description("692467 UC Mobile")]
        //UCMobile = 245,
        //[Description("555336 UTI Mutual Fund")]
        //UTIMutualFund = 246,
        //[Description("667309 UTS")]
        //UTS = 247,
        //[Description("727617 Verisign")]
        //Verisign = 248,
        //[Description("745385_World Vision")]
        //WorldVision = 249,
        //[Description("155512_Yatra Online Pvt Ltd")]
        //YatraOnlinePvtLtd = 250,       
        //[Description("248729_Yebhi")]
        //Yebhi = 252,
        //[Description("530930_Zansaar.com")]
        //Zansaarcom = 33,
        //[Description("Amazon.com")]
        //Amazon = 0,
        //[Description("American Swan")]
        //AmericanSwan = 1,
        //[Description("Askmebazaar")]
        //Askmebazaar = 2,
        //[Description("BabyHugz")]
        //BabyHugz = 3,
        //[Description("Basicslife.com")]
        //Basicslife = 4,
        //[Description("Bata.in")]
        //Bata = 5,
        //[Description("Bluestone")]//
        //Bluestone = 6,
        //[Description("Body Shop")]
        //BodyShop = 7,
        //[Description("FlipKart.com")]
        //FlipKart = 8,
        //[Description("Foodpanda.in")]//
        //Foodpanda = 9,
        //[Description("dominos.co.in")]
        //GMCampaigns = 10,
        //[Description("Goibibo.com")]
        //Goibibo = 11,
        //[Description("Groupon.co.in")]
        //Groupon = 12,
        //[Description("ITC Foods")]
        //ITCFoods = 13,
        //[Description("Jabong.com")]
        //Jabong = 14,
        //[Description("Justeat.in")]
        //Justeat = 15,
        //[Description("Koovs.com")]//
        //Koovs = 16,
        //[Description("Myntra.com")]
        //Myntra = 17,
        //[Description("Paytm")]
        //Paytm = 18,
        //[Description("Pizza Hut")]
        //PizzaHut = 19,
        //[Description("SnapDeal.com")]
        //SnapDeal = 20,
        //[Description("stalkbuylove.com")]//
        //Stalkbuylove = 21,
        //[Description("ShopClues.com")]
        //ShopClues = 22,
        //[Description("Ticketgoose.com")]
        //Ticketgoose = 23,
        //[Description("Times Internet")]
        //TimesInternet = 24,
        //[Description("Travel Khana")]
        //TravelKhana = 25,
        //[Description("Travelguru.com")]//
        //Travelguru = 26,
        //[Description("Trendin.com")]//
        //Trendin = 27,
        //[Description("Uninor")]//
        //Uninor = 28,
        //[Description("Voylla.in")]//
        //Voylla = 29,
        //[Description("Yepme.com")]//
        //Yepme = 30,
        //[Description("Zivame.com")]//
        //Zivame = 31,
        //[Description("Zovi.com")]//
        //Zovi = 32
    };

    public enum FeatureTypeOffer
    {
        [Description("Feature Offer")]
        FeatureOffer = 1,
        [Description("Top Offer")]
        TopOffer = 2        
    };

    public enum APITypeURL
    {
        [Description("Flipkart DOTD")]
        FlipKart_DOTD_OffersAPI = 1,
        [Description("FlipKart Product Feeds")]
        FlipKart_Product_Feeds_API = 2,
        [Description("FlipKart Top Offers")]
        FlipKart_TOP_Offers_API = 3,       
        [Description("Features Deal")]
        FeatureDeal = 4,
        [Description("Hot Deals")]
        HotDeals = 5,
        [Description("Recharge Deals")]
        RechargeDeals = 6,
        [Description("Product Feed")]
        ProductFeed = 7
    };

    public enum API_URL_Type
    {
        [Description("FlipKart-DOTD URL")]
        FlipKart_DOTD_OffersAPI = 1,
        //[Description("FlipKart Product Feeds API Directory")]
        //FlipKart_Product_Feeds_API = 2,
        [Description("FlipKart-Top Offer URL")]
        FlipKart_TOP_Offers_API = 3,
        //[Description("FlipKart API Search Query based on Product ID (pid)")]
        //FlipKart_API_Search_Query_based_Product_ID = 4,
        [Description("OMG-Product Feed URL")]
        OMGProductFeed = 5,
        [Description("OMG-Voucher Code URL")]
        OMGVoucherCode = 6,
        [Description("OMG-Product Feed-Beta URL")]
        OMGProductFeedBeta = 7,
        [Description("Deeplinking Product URL")]
        DeeplinkingURL = 8
        //,
        //[Description("American Swan - CPA")]
        //AmericanSwanCPA = 7,
        //[Description("Jabong.com - Sales")]
        //JabongcomSales = 8,
        //[Description("Koovs.com - Cost Per Sale")]
        //KoovscomCostPerSale = 9,
        //[Description("Myntra.com - Sale-Existing User")]
        //MyntracomSaleExistingUser = 10,
        //[Description("Paytm - Paytm (CPS) - non recharge")]
        //PaytmPaytmnonrecharge = 11,
        //[Description("Trendin.com - Cost Per Sale")]
        //TrendincomCostPerSale = 12,
        //[Description("Zovi.com - Sale ")]
        //ZoviComSale = 13
    };

    public enum ApiScheduleType
    {
        [Description("Daily")]
        Daily = 1,
        [Description("Monthly")]
        Month = 2,
        [Description("Weekly")]
        Weekly = 3,
        [Description("Every 15 Days")]
        Fifteen_Days = 4
    };

    public enum Adv_Type
    {
        [Description("Deal")]
        Deal = 1,
        [Description("Offer")]
        Offer = 2,
        [Description("Coupon")]
        Coupon = 3,
        [Description("Deal of the Day")]
        DOTD = 4,
        [Description("Top Offers")]
        TopOffer = 5,
        //[Description("Hot Coupons")]
        //HotCoupons = 6,
        [Description("Hot Offer")]
        HotOffers = 6,
        [Description("Feature Offers")]
        FeaturedOffers=7
    };
    
    public enum GenderTitle
    {
        None = 0,
        Mr = 1,
        Ms = 2,
        Mrs = 3,
        Miss = 4,
        Dr = 5
    };

    public enum YesNo
    {
        [Description("Yes")]
        Yes,
        [Description("No")]
        No
    };

    public enum PayoutType
    {
        [Description("Sale")]
        Sale,
        [Description("Lead")]
        Lead,
        [Description("Click")]
        Click,
        [Description("Click+Lead")]
        ClickLead,
        [Description("Click+Sale")]
        ClickSale,
        [Description("Lead+Sale")]
        LeadSale
    };

    public enum PriceType
    {
        [Description("%")]
        Percentage=0,
        [Description("INR")]
        INR=1        
    };

    public enum MerchantLinkType
    {
        [Description("Optimise Media")]
        Optimise=1,
        [Description("Payoom")]
        Payoom=2,
        [Description("Self")]
        Self = 3,
        [Description("Other")]
        Other = 4
        
    };

    
    public enum CategoryType
    {
        [Description("None")]
        None = 0,
        [Description("Recharge")]
        Recharge = 1,
        [Description("Shopping")]
        Shopping = 2,
        [Description("Travel")]
        Travel = 3,
        [Description("Books")]
        Books = 4
    };

    public enum NotificationType
    {
        [Description("Home")]
        Home = 0,
        [Description("User Home Top")]
        UserHome = 1,
        [Description("User on Right")]
        UserOnRight = 2
    };
    public enum AmountStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Rejected")]
        Rejected = 0,
        [Description("Validated")]
        Validated = 2
    }
    public enum Status
    {
        [Description("DeActive")]
        DeActive = 10,
        [Description("Active")]
        Active = 1,
        [Description("Delete")]
        Delete = 2,
        [Description("Open")]
        Open = 3,
         [Description("Solve")]
        Solve = 4,
         [Description("Close")]
        Close = 5,
         [Description("NotApplied")]
        NotApplied = 6,
         [Description("Cancelled")]
        Cancelled = 7,
         [Description("Waiting")]
        Waiting = 8,
         [Description("Live")]
        Live = 9,
         [Description("Pending")]
         Pending = 11,
         [Description("Resolve")]
         Resolve = 12
    };


}

