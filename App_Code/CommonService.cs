using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using System.Web.Security;
using System.Data;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI;

/// <summary>
/// Summary description for CommonService
/// </summary>
[WebService(Namespace = "http://www.cashonshop.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class CommonService : System.Web.Services.WebService
{
    
    public class OperatorInfo
    {
        public string opratorcode { get; set; }
        public string opratorcodename { get; set; }
        public string operatorname { get; set; }
    }
    public List<OperatorInfo> OperatorInformation { get; set; }
    [WebMethod]
    public List<OperatorInfo> BindRechargeOperator(string RechargeType)
    {
        
        OperatorInfo ci = new OperatorInfo();
        List<OperatorInfo> CountryInformation = new List<OperatorInfo>();
         SqlParameter[] parameters =
        {    
            new SqlParameter("@ServiceType", SqlDbType.VarChar) { Value = RechargeType }
        };
         DataTable dt = objFramework.GetRecordSet("adv_proc_BindOperator", CommandType.StoredProcedure, parameters);
        try
        {
              if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            CountryInformation.Add(new OperatorInfo()
                            {
                                opratorcode = Convert.ToString(dr["opratorcode"]),
                                operatorname = dr["operatorname"].ToString()
                            });
                        }
                    }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return CountryInformation;
    }

    #region
    public class CircleInfo
    {
        public string Circlecode { get; set; }
        public string Circlecodename { get; set; }
        public string Circlename { get; set; }
    }
    public List<CircleInfo> CircleInformation { get; set; }
    [WebMethod]
    public List<CircleInfo> BindRechargeCircle()
    {
        CircleInfo ci = new CircleInfo();
        List<CircleInfo> CountryInformation = new List<CircleInfo>();
        SqlParameter[] parameters =
        {    
           
        };
        DataTable dt = objFramework.GetRecordSet("adv_proc_BindCircle", CommandType.StoredProcedure, parameters);
        try
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CountryInformation.Add(new CircleInfo()
                    {
                        Circlecode = Convert.ToString(dr["CircleCode"]),
                        Circlename = dr["CircleName"].ToString()
                    });
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return CountryInformation;
    }
    #endregion

    [WebMethod]
    public string FindOperator(string mobile)
    {
        WebClient client = new WebClient();
        DataTable dt=new DataTable();
        string uri = "https://joloapi.com/api/findoperator.php?userid=cashonshop&key=899388873156283&mob=" + mobile + "&type=text";
        var dotd = client.DownloadString(uri);
        return dotd;
    }


    [WebMethod]
    public string RechargeAPI(string mobile, string OperatorCode, string Amount, string RechargeType)
    {
        string mess = string.Empty;
        try
        {
            ///decimal RechargeAmount = CalculateWalletAmount();
            

            if (mobile == string.Empty)
                mess = "Please Enter Mobile Number";
            else if (mobile.Length != 10)
                mess = "Mobile number is not valid";
            else if (OperatorCode == "0")
                mess = "Please Select Operator";
            else if (Amount == string.Empty)
                mess = "Please Enter Recharge Amount";
            else if (RechargeType.ToLower() == "postpaid" && Convert.ToInt32(Amount) < 100)
                mess = "Amount must be atleast 100 for bill payment";
            else if (RechargeType.ToLower() == "prepaid" && Convert.ToInt32(Amount) < 10)
                mess = "Minimum recharge amount is Rs. 10";
            else
            {
                #region Find Operator Code
                SqlParameter[] parametersOperator = { };
                DataTable dtOperator = new DataTable();
                string operatorcodeName = string.Empty;
                dtOperator = objFramework.GetRecordSet("select  opratorcode,operatorname,operatorCodename from adv_OperatorCode where Activestatus =1 and serviceType='" + RechargeType + "' and  opratorcode='" + OperatorCode + "' ", CommandType.Text, parametersOperator);
                if (dtOperator != null)
                {
                    if (dtOperator.Rows.Count > 0)
                        operatorcodeName = dtOperator.Rows[0]["operatorCodename"].ToString();
                }
                #endregion

                Random rnd = new Random();
                string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                string OrderID = strHash.ToString().Substring(0, 20);
                MembershipUser mu = Membership.GetUser(User.Identity.Name);
                SqlParameter[] parameters = { };
                objFramework.ExecuteNonQuery("insert into adv_Operator_APIResponse(CashOnShopUserID,Operator,Service,Amount,OurOrderID,RechargeType,SuccessStatus,Time)values('" + mu.ProviderUserKey.ToString() + "','" + operatorcodeName + "','" + mobile + "','" + Amount + "','" + OrderID + "','" + RechargeType + "','PENDING',getdate())", CommandType.Text, parameters);
                mess = "Success," + OrderID;

            }

            return mess;
        }
        catch (Exception ex)
        {
            mess = "Failed";
            return mess;
        }
    }

    [WebMethod]
    public string ApplyCouponCode(string coupon, string RechargeType, string UserID, int RechargeAmount)
    {
        string mess=string.Empty;
        SqlParameter[] parameters =
        {    
            new SqlParameter("@CouponCode", SqlDbType.VarChar) { Value = coupon },
            new SqlParameter("@RechargeType", SqlDbType.VarChar) { Value = RechargeType },
            new SqlParameter("@UserID", SqlDbType.VarChar) { Value = UserID },
            new SqlParameter("@RechargeAmount", SqlDbType.Int) { Value = RechargeAmount }
        };
       DataTable dt= objFramework.GetRecordSet("adv_Proc_ValidateCouponCode", CommandType.StoredProcedure, parameters);
       if (dt != null)
       {
           if (dt.Rows.Count > 0)
               mess = dt.Rows[0]["CouponMessage"].ToString();
           else
               mess = "Invalid Coupon Code";
       }
       return mess;
    }

    public string Generatehash512(string text)
    {

        byte[] message = Encoding.UTF8.GetBytes(text);

        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        SHA512Managed hashString = new SHA512Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;

    }

    public decimal CalculateWalletAmount()
    {
        decimal walletAmount = 0;
        clsFramework objFramework = new clsFramework();
        MembershipUser mu = Membership.GetUser();

        SqlParameter[] parameters =
        {    
            new SqlParameter("@userid", SqlDbType.VarChar) { Value = mu.ProviderUserKey.ToString() }
        };
        DataTable dt = objFramework.GetRecordSet("Adv_WalletHistory_New", CommandType.StoredProcedure, parameters);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
                walletAmount= Convert.ToDecimal(dt.Rows[0]["ConfirmAmount"]);
        }
        return walletAmount;
    }

    clsFramework objFramework;
    public CommonService()
    {
        objFramework = new clsFramework();
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public bool AuthenticateToUser(string username, string password, bool remeberMe)
    {
        if (Membership.ValidateUser(username, password))
        {
            //ProfileCommon
            
            FormsAuthentication.SetAuthCookie(username, remeberMe);
            return true;
        }
        else
        {
            return false;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<string> GetTitleNames(string TitleName)
    {
        List<string> Emp = new List<string>();
        //string query = string.Format("SELECT top 20 Title FROM adv_product_common WHERE Title LIKE '%{0}%'", TitleName);
        //string query = string.Format("select MerchantNamedetail as Title from adv_mst_merchant where MerchantNamedetail like '%{0}%' union all SELECT top 20 Title FROM adv_product_common WHERE Title like '%{0}%'", TitleName);
        string query = string.Format("select case when charindex('.', MerchantNamedetail)>0 then left(MerchantNamedetail, charindex('.', MerchantNamedetail)-1) else MerchantNamedetail  end    as Title from adv_mst_merchant where MerchantNamedetail like '%{0}%' ", TitleName);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Emp.Add(reader.GetString(0));
            }
        }
        return Emp;
    }


    [WebMethod]
    public void SubscribeEmail(string Email)
    {
        
        SqlParameter[] parameters =
        {    
            new SqlParameter("@SubscribeEmail", SqlDbType.VarChar) { Value = Email },
            new SqlParameter("@Status", SqlDbType.VarChar) { Value = "1" }
        };
        objFramework.ExecuteNonQuery("Adv_Proc_SubscribeUnsubscribeEmail", CommandType.StoredProcedure, parameters);

    }


    [WebMethod]
    public string RegisterValidation(string Name, string Email, string Mobile, string Password, string ConfirmPassword, bool Terms)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(Email);
        string msg = string.Empty;
        Regex re = new Regex("^[0-9]");

        if (Name == "")
            msg= "Please Enter Name";
        else if (Email == "")
            msg = "Please enter Email ID";
        else if (!match.Success && Email != "")
            msg = "Please enter valid email";
        else if (Mobile == "")
            msg = "Please enter Mobile Number";
        else if (re.IsMatch(Mobile.Trim()) == false || Mobile.Length != 10)
            msg = "Invalid Mobile Number";
        else if (Password == "")
            msg = "Please enter Password";
        else if (ConfirmPassword == "")
            msg = "Please enter ConfirmPassword";
        else if (Password != ConfirmPassword)
            msg = "Password and ConfirmPassword must be same";
        else if (Terms == false)
            msg = "Please select terms and condition";
        else
        {
            if(!string.IsNullOrEmpty(Email))
            {
                var member  =  Membership.GetUser(Email);
                if(member!=null)
                {
                    msg = "User with this e-mail address already exists.";
                }
            }
        }
        return msg;
    }


    #region Offer Detail For Prepaid Mobile
    //
    [WebMethod]
    public string BindTopup()
    {
        string operatorcode = "AT";
        string circlecode = "1";
        string type = "TUP";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt="+operatorcode+"&cir="+circlecode+"&typ="+type+"&amt=300&max=10&type=json";
        var dotd = client.DownloadString(uri);
        return dotd;
    }
    #endregion



    public class UserDetails
    {
        public string Detail { get; set; }
        public string Validity { get; set; }
        public string Amount { get; set; }
        public string operatorName { get; set; }
        public string SuccessStatus { get; set; }
        public string ourorderid { get; set; }
        public string Time { get; set; }
        public string RefundStatus { get; set; }
        public string RefundProcess { get; set; }
        public string Mobile { get; set; }
        public string OperatorImage { get; set; }
    }

    //Code to Bind All user orders

    [WebMethod]
    public UserDetails[] BindRechargeOrders(string PageIndex)
    {
        MembershipUser mu = Membership.GetUser();
        clsFramework objFramework = new clsFramework();
        SqlParameter[] parameters =
        {    
            new SqlParameter ("@PageIndex",SqlDbType.VarChar){Value=PageIndex},
            new SqlParameter ("@PageSize",SqlDbType.VarChar){Value=10},
            new SqlParameter ("@CashOnShopUserID",SqlDbType.VarChar){Value=mu.ProviderUserKey.ToString()}
        };

        DataTable dt = new DataTable();
        //DataTable data = objFramework.GetRecordSet("select ourorderid,Service,Amount,SuccessStatus,operatorName,Time from adv_Operator_APIResponse A inner join adv_OperatorCode  B on A.Operator=B.OperatorCodeName where A.CashOnShopUserID='"+mu.ProviderUserKey.ToString()+"'", CommandType.Text, parameters);
        DataTable data = objFramework.GetRecordSet("usp_proc_GetOrdersPageWise", CommandType.StoredProcedure, parameters);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.operatorName = dtrow["operatorName"].ToString();
            user.SuccessStatus = dtrow["SuccessStatus"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            user.ourorderid = dtrow["ourorderid"].ToString();
            user.Time = dtrow["Time"].ToString();
            user.RefundStatus = dtrow["RefundStaus"].ToString();
            user.RefundProcess = dtrow["RefundProcess"].ToString();
            user.Mobile = dtrow["Service"].ToString();
            user.OperatorImage = dtrow["OperatorImage"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    [WebMethod]
    public void RefundMoneyToBank(string OrderID)
    {
        try
        {
            clsFramework objFramework = new clsFramework();
            SqlParameter[] parameters = { };
            objFramework.ExecuteNonQuery("update adv_PaymentGatewayTransaction set TransactionStatus=3 where CashOnShopOrderID='" + OrderID + "'", CommandType.Text, parameters);
        }
        catch (Exception ex)
        { }
    }
}
