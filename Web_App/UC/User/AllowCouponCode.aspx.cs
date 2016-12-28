using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Data.SqlClient;

public partial class UC_User_AllowCouponCode : BasePage
{
    public string action1 = string.Empty;
    public string hash1 = string.Empty;
    public string txnid1 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];
        if (!IsPostBack)
        {
            BindOperatorImage( Convert.ToString(Request.Form["OperatorName"]));
            if (Request.Form["RechargeType"].ToLower().ToString() == "prepaid")//" + Convert.ToString(Request.Form["OperatorName"]) + "
            {
                llbmsg.Text = "Recharge of  Mo.No. " + Convert.ToString(Request.Form["name"]) ;
                litAmount.Text = "Rs." + Convert.ToString(Request.Form["Amount"]);
            }
            else if (Request.Form["RechargeType"].ToLower().ToString() == "postpaid")
                llbmsg.Text = "Bill Payment for Mo.No. " + Convert.ToString(Request.Form["name"]) + " Rs." + Convert.ToString(Request.Form["Amount"]);

            hdnMobile.Value = Convert.ToString(Request.Form["name"]);
            hdnOperatorCode.Value = Convert.ToString(Request.Form["OperatorCode"]);
            hdnOperatorName.Value = Convert.ToString(Request.Form["OperatorName"]);
            hdnRechargeAmount.Value = Convert.ToString(Request.Form["Amount"]);
            hdnRechargeType.Value = Convert.ToString(Request.Form["RechargeType"]);
            hdnProductInfo.Value = Convert.ToString(Request.Form["RechargeType"]);
            hdnWalletAmount.Value = Convert.ToString(CalculateWalletAmount());
            hdnOrderID.Value = Convert.ToString(Request.Form["OrderId"]);
            MembershipUser mu1 = Membership.GetUser(Page.User.Identity.Name);
            hdnUserID.Value = mu1.ProviderUserKey.ToString();
        }
    }

    public void BindOperatorImage(string operatorName)
    {
        
        clsFramework objFramework = new clsFramework();
        SqlParameter[] parameters1 = { };
        DataTable dtimage = objFramework.GetRecordSet("Select OperatorImage from adv_OperatorCode where operatorname='" + operatorName + "'", CommandType.Text, parameters1);
        ImgOperator.ImageUrl = "~/Images/OperatorImage/" + dtimage.Rows[0]["OperatorImage"].ToString();
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

    private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
    {
        //Set a name for the form
        string formID = "PostForm";
        //Build the form using the specified data to be posted.
        StringBuilder strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" +
                       formID + "\" action=\"" + url +
                       "\" method=\"POST\">");

        foreach (System.Collections.DictionaryEntry key in data)
        {

            strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                           "\" value=\"" + key.Value + "\">");
        }


        strForm.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." +
                         formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return strForm.ToString() + strScript.ToString();
    }

    public void AllowpaymetGateWay(decimal WalletAmount)
    {
        try
        {
            
            string[] hashVarsSeq;
            string hash_string = string.Empty;

            string RechAmount = Convert.ToString(Convert.ToDecimal(hdnRechargeAmount.Value) - WalletAmount);
            ModelUserProfile userProfile = new ModelUserProfile();
            MembershipUser mu = Membership.GetUser(Page.User.Identity.Name);
            //Guid userKey=
            UserProfile profile = userProfile.GetUserProfileByID(new Guid(mu.ProviderUserKey.ToString()));


            if (string.IsNullOrEmpty(Request.Form["txnid"])) // generating txnid
            {
                Random rnd = new Random();
                string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                txnid1 = strHash.ToString().Substring(0, 20);

            }
            else
            {
                txnid1 = Request.Form["txnid"];
            }
            //string amount = "100";
            //string firstname = "aa";
            if (string.IsNullOrEmpty(Request.Form["hash"])) // generating hash value
            {
                if (
                    string.IsNullOrEmpty(ConfigurationManager.AppSettings["MERCHANT_KEY"]) ||
                    string.IsNullOrEmpty(txnid1)
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$amount"])|| 
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$firstname"]) ||
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$email"]) ||
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$phone"]) ||
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$productinfo"]) ||
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$surl"]) ||
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$furl"]) ||
                    //string.IsNullOrEmpty(Request.Form["ctl00$MainContent$service_provider"])
                    )
                {
                    //error

                    //frmError.Visible = true;
                    return;
                }

                else
                {
                    //frmError.Visible = false;
                    //key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5||||||salt
                    hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|'); // spliting hash sequence from config
                    hash_string = "";
                    foreach (string hash_var in hashVarsSeq)
                    {
                        if (hash_var == "key")
                        {
                            hash_string = hash_string + ConfigurationManager.AppSettings["MERCHANT_KEY"];
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "txnid")
                        {
                            hash_string = hash_string + txnid1;
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "amount")
                        {
                            hash_string = hash_string + RechAmount;
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "productinfo")
                        {
                            hash_string = hash_string + hdnProductInfo.Value;
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "firstname")
                        {
                            hash_string = hash_string + profile.FullName;
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "email")
                        {
                            hash_string = hash_string + profile.EmailID;
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf1")
                        {
                            hash_string = hash_string + hdnOrderID.Value.Trim();
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf2")
                        {
                            hash_string = hash_string + hdnOperatorCode.Value.Trim();
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf3")
                        {
                            hash_string = hash_string + WalletAmount.ToString().Trim();
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf4")
                        {
                            hash_string = hash_string + hdnRechargeAmount.Value.Trim();
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf5")
                        {
                            hash_string = hash_string + mu.ProviderUserKey.ToString();
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf6")
                        {
                            hash_string = hash_string + "";
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf7")
                        {
                            hash_string = hash_string + "";
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf8")
                        {
                            hash_string = hash_string + "";
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf9")
                        {
                            hash_string = hash_string + "";
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "udf10")
                        {
                            hash_string = hash_string + "";
                            hash_string = hash_string + '|';
                        }
                        else if (hash_var == "salt")
                        {
                            hash_string = hash_string + ConfigurationManager.AppSettings["SALT"];
                        }
                        else
                        {

                            hash_string = hash_string + (Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                        }
                    }

                    //hash_string += ConfigurationManager.AppSettings["SALT"];// appending SALT

                    hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                    action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";// setting URL

                }


            }

            else if (!string.IsNullOrEmpty(Request.Form["hash"]))
            {
                hash1 = Request.Form["hash"];
                action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";

            }




            if (!string.IsNullOrEmpty(hash1))
            {
                hash.Value = hash1;
                txnid.Value = txnid1;

                System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                data.Add("hash", hash.Value);
                data.Add("txnid", txnid.Value);
                data.Add("key", key.Value);
                string AmountForm = Convert.ToDecimal(RechAmount).ToString("g29");// eliminating trailing zeros
                data.Add("amount", AmountForm);
                data.Add("productinfo", hdnProductInfo.Value.Trim());
                data.Add("firstname", profile.FullName.Trim());
                data.Add("email", profile.EmailID.Trim());
                data.Add("phone", hdnMobile.Value.Trim());
                data.Add("abcz", hash_string);
                data.Add("surl", "http://cashonshop.com/UC/User/ResponseHandling.aspx");
                data.Add("furl", "http://cashonshop.com/UC/User/ResponseHandling.aspx");
                data.Add("lastname", "");
                data.Add("curl", "http://cashonshop.com/UC/User/ResponseHandling.aspx");
                data.Add("address1", "");
                data.Add("address2", "");
                data.Add("city", "");
                data.Add("state", "");
                data.Add("country", "");
                data.Add("zipcode", "");
                data.Add("udf1", hdnOrderID.Value.Trim());
                data.Add("udf2", hdnOperatorCode.Value.Trim());
                data.Add("udf3", WalletAmount.ToString());
                data.Add("udf4", hdnRechargeAmount.Value.Trim());
                data.Add("udf5", mu.ProviderUserKey.ToString());
                data.Add("pg", "");
                data.Add("service_provider", "payu_paisa");
                string strForm = PreparePOSTForm(action1, data);
                Page.Controls.Add(new LiteralControl(strForm));

            }

            else
            {
                //no hash

            }
        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");

        }
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
                walletAmount = Convert.ToDecimal(dt.Rows[0]["ConfirmAmount"]);
        }
        return walletAmount;
    }

    protected void btnPayment_Click(object sender, EventArgs e)
    {
        try
        {
            btnPayment.Text = "waiting..";
            btnPayment.Enabled = false;
            clsFramework objFramework = new clsFramework();
            SqlParameter[] parameters ={};
            string a = string.Empty;
            decimal WAmount = 0;
            if (chkWallet.Checked == true)
            {
                WAmount = Convert.ToDecimal(hdnWalletAmount.Value);
                if (Convert.ToDecimal(hdnRechargeAmount.Value) < WAmount)
                    WAmount = WAmount = Convert.ToDecimal(hdnRechargeAmount.Value);
            }
            
            objFramework.ExecuteNonQuery("update adv_Operator_APIResponse set CouponCode='" + txtCouponCode.Text.Trim() + "',WalletAmount='" + WAmount.ToString() + "' where OurOrderID='" + hdnOrderID.Value + "' ", CommandType.Text, parameters);
            if (WAmount >= Convert.ToDecimal(hdnRechargeAmount.Value))
            {
                Session["OrderID"] = hdnOrderID.Value;
                Response.Redirect("ResponseHandling.aspx");
            }
            else
                AllowpaymetGateWay(WAmount);
        }
        catch (Exception ex)
        { }
    }
}