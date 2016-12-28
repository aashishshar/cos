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
using System.Data.SqlClient;
using System.Net;

public partial class UC_User_ResponseHandling : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

            clsFramework objFrame = new clsFramework();
            SqlParameter[] parametersNew = { };
            DataTable dt=new DataTable();
            

            if (Request.Form["status"] == "success")
            {

                dt = objFrame.GetRecordSet("select Time, operator,Service,Amount,WalletAmount,RechargeType,OperatorName,OperatorImage from adv_Operator_APIResponse A inner join adv_OperatorCode B on A.Operator=B.OperatorCodeName where OurOrderID='" + Convert.ToString(Request.Form["udf1"]) + "'", CommandType.Text, parametersNew);
                decimal rechAmount=Convert.ToDecimal(dt.Rows[0]["Amount"])-Convert.ToDecimal(dt.Rows[0]["WalletAmount"]);
                merc_hash_vars_seq = hash_seq.Split('|');
                Array.Reverse(merc_hash_vars_seq);
                merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];

                foreach (string merc_hash_var in merc_hash_vars_seq)
                {
                    merc_hash_string += "|";
                    merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");
                }
                merc_hash = Generatehash512(merc_hash_string).ToLower();

                if (merc_hash != Request.Form["hash"])
                {
                    //Response.Write("Hash value did not matched");

                }
                else
                {
                    order_id = Request.Form["txnid"];
                    clsFramework objFramework = new clsFramework();
                    MembershipUser mu = Membership.GetUser();
                    SqlParameter[] parameters = { 
                                               
                    new SqlParameter ("@CashOnShopUserID",SqlDbType.VarChar){Value=mu.ProviderUserKey.ToString()},
                    new SqlParameter ("@GatewayTransactionID",SqlDbType.VarChar){Value=order_id},
                    new SqlParameter ("@ProductInfo",SqlDbType.VarChar){Value=Convert.ToString(Request.Form["productinfo"])},
                    new SqlParameter ("@RechargeType",SqlDbType.VarChar){Value=dt.Rows[0]["RechargeType"].ToString()},
                    new SqlParameter ("@OperatorCode",SqlDbType.VarChar){Value=dt.Rows[0]["operator"].ToString()},
                    new SqlParameter ("@MobileOrDTH",SqlDbType.VarChar){Value=dt.Rows[0]["Service"].ToString()},
                    new SqlParameter ("@AmountPaid",SqlDbType.VarChar){Value=rechAmount.ToString()},
                    new SqlParameter ("@TransactionStatus",SqlDbType.VarChar){Value="1"},
                    new SqlParameter ("@CashOnShopOrderID",SqlDbType.VarChar){Value=Convert.ToString(Request.Form["udf1"])}};
                    objFramework.ExecuteNonQuery("adv_Proc_PaymentGatewayTransaction", CommandType.StoredProcedure, parameters);
                    lblmsg.Text = RechargeAndBillpayment(Convert.ToString(Request.Form["udf1"]), order_id,dt);
                    //Response.Write("value matched");


                    //Details
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            lblTransationNo.Text = Convert.ToString(Request.Form["udf1"]);
                            lblOrderNo.Text = Convert.ToString(Request.Form["udf1"]);
                            lblWalletAmount.Text = Convert.ToString(dt.Rows[0]["WalletAmount"]);
                            lblTransationAmount.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0]["Amount"]) - Convert.ToDecimal(dt.Rows[0]["WalletAmount"]));
                            lblTotalAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                            lblAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                            lblTime.Text = Convert.ToString(dt.Rows[0]["Time"]);
                            pImage.ImageUrl = "~/Images/OperatorImage/" + dt.Rows[0]["OperatorImage"].ToString();

                            if (Convert.ToString(dt.Rows[0]["RechargeType"]).ToLower() == "prepaid")
                                lblRechargeMessage.Text = "Recharge of " + Convert.ToString(dt.Rows[0]["OperatorName"]) + " Mobile " + Convert.ToString(dt.Rows[0]["Service"]) + " For Amount Rs. " + Convert.ToString(dt.Rows[0]["Amount"]);
                            else if (Convert.ToString(dt.Rows[0]["RechargeType"]).ToLower() == "postpaid")
                                lblRechargeMessage.Text = "Bill Payment of " + Convert.ToString(dt.Rows[0]["OperatorName"]) + " Mobile " + Convert.ToString(dt.Rows[0]["Service"]) + " For Amount Rs. " + Convert.ToString(dt.Rows[0]["Amount"]);
                        }
                    }
                    //End details
                }

            }
            else if (Request.Form["status"] == null)
            {
                dt = objFrame.GetRecordSet("select Time, operator,Service,Amount,WalletAmount,RechargeType,OperatorName,OperatorImage from adv_Operator_APIResponse A inner join adv_OperatorCode B on A.Operator=B.OperatorCodeName where OurOrderID='" + Convert.ToString(Session["OrderID"]) + "'", CommandType.Text, parametersNew);

                //Details
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lblTransationNo.Text = Convert.ToString(Session["OrderID"]);
                        lblOrderNo.Text = Convert.ToString(Session["OrderID"]);
                        lblWalletAmount.Text = Convert.ToString(dt.Rows[0]["WalletAmount"]);
                        lblTransationAmount.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0]["Amount"]) - Convert.ToDecimal(dt.Rows[0]["WalletAmount"]));
                        lblTotalAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                        lblAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                        lblTime.Text = Convert.ToString(dt.Rows[0]["Time"]);
                        pImage.ImageUrl = "~/Images/OperatorImage/" + dt.Rows[0]["OperatorImage"].ToString();

                        if (Convert.ToString(dt.Rows[0]["RechargeType"]).ToLower() == "prepaid")
                            lblRechargeMessage.Text = "Recharge of " + Convert.ToString(dt.Rows[0]["OperatorName"]) + " Mobile " + Convert.ToString(dt.Rows[0]["Service"]) + " For Amount Rs. " + Convert.ToString(dt.Rows[0]["Amount"]);
                        else if (Convert.ToString(dt.Rows[0]["RechargeType"]).ToLower() == "postpaid")
                            lblRechargeMessage.Text = "Bill Payment of " + Convert.ToString(dt.Rows[0]["OperatorName"]) + " Mobile " + Convert.ToString(dt.Rows[0]["Service"]) + " For Amount Rs. " + Convert.ToString(dt.Rows[0]["Amount"]);
                    }
                }
                //End details

                lblmsg.Text = RechargeAndBillpayment(Convert.ToString(Session["OrderID"]), "",dt);
                //Session.Remove("mobile");
                //Session.Remove("OperatorCode");
                //Session.Remove("RechAmount");
                Session.Remove("OrderID");
            }

            else
            {






                //Details
                dt = objFrame.GetRecordSet("select Time, operator,Service,Amount,WalletAmount,RechargeType,OperatorName,OperatorImage from adv_Operator_APIResponse A inner join adv_OperatorCode B on A.Operator=B.OperatorCodeName where OurOrderID='" + Convert.ToString(Request.Form["udf1"]) + "'", CommandType.Text, parametersNew);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lblTransationNo.Text = Convert.ToString(Request.Form["udf1"]);
                        lblOrderNo.Text = Convert.ToString(Request.Form["udf1"]);
                        lblWalletAmount.Text = Convert.ToString(dt.Rows[0]["WalletAmount"]);
                        lblTransationAmount.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0]["Amount"]) - Convert.ToDecimal(dt.Rows[0]["WalletAmount"]));
                        lblTotalAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                        lblAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                        lblTime.Text = Convert.ToString(dt.Rows[0]["Time"]);
                        pImage.ImageUrl = "~/Images/OperatorImage/" + dt.Rows[0]["OperatorImage"].ToString();

                        if (Convert.ToString(dt.Rows[0]["RechargeType"]).ToLower() == "prepaid")
                            lblRechargeMessage.Text = "Recharge of " + Convert.ToString(dt.Rows[0]["OperatorName"]) + " Mobile " + Convert.ToString(dt.Rows[0]["Service"]) + " For Amount Rs. " + Convert.ToString(dt.Rows[0]["Amount"]);
                        else if (Convert.ToString(dt.Rows[0]["RechargeType"]).ToLower() == "postpaid")
                            lblRechargeMessage.Text = "Bill Payment of " + Convert.ToString(dt.Rows[0]["OperatorName"]) + " Mobile " + Convert.ToString(dt.Rows[0]["Service"]) + " For Amount Rs. " + Convert.ToString(dt.Rows[0]["Amount"]);
                    }
                }
                //End details




                //Response.Write("Hash value did not matched");
                lblmsg.Text = "Transaction Failed";
                //osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));
                order_id = Request.Form["txnid"];
                clsFramework objFramework = new clsFramework();
                MembershipUser mu = Membership.GetUser();
                decimal rechAmount = Convert.ToDecimal(dt.Rows[0]["Amount"]) - Convert.ToDecimal(dt.Rows[0]["WalletAmount"]);
                SqlParameter[] parameters = { 
                                               
                    new SqlParameter ("@CashOnShopUserID",SqlDbType.VarChar){Value=mu.ProviderUserKey.ToString()},
                    new SqlParameter ("@GatewayTransactionID",SqlDbType.VarChar){Value=order_id},
                    new SqlParameter ("@ProductInfo",SqlDbType.VarChar){Value=Convert.ToString(Request.Form["productinfo"])},
                    new SqlParameter ("@RechargeType",SqlDbType.VarChar){Value=dt.Rows[0]["RechargeType"].ToString()},
                    new SqlParameter ("@OperatorCode",SqlDbType.VarChar){Value=dt.Rows[0]["operator"].ToString()},
                    new SqlParameter ("@MobileOrDTH",SqlDbType.VarChar){Value=dt.Rows[0]["Service"].ToString()},
                    new SqlParameter ("@AmountPaid",SqlDbType.VarChar){Value=rechAmount.ToString()},
                    new SqlParameter ("@TransactionStatus",SqlDbType.VarChar){Value="2"},
                    new SqlParameter ("@CashOnShopOrderID",SqlDbType.VarChar){Value=Convert.ToString(Request.Form["udf1"])}};
                    objFramework.ExecuteNonQuery("adv_Proc_PaymentGatewayTransaction", CommandType.StoredProcedure, parameters);
                    SqlParameter[] parameters1 = { };
                    objFramework.ExecuteNonQuery("update adv_Operator_APIResponse set SuccessStatus='Pament Failed',PaymentGatewayTransactionID='" + order_id + "' where ourOrderID='" + Convert.ToString(Request.Form["udf1"]) + "'", CommandType.Text, parameters1);
            }
        }

        catch (Exception ex)
        {
            //Response.Write("<span style='color:red'>" + ex.Message + "</span>");
            litMessage.Text = ex.Message;
            //Response.Redirect("~/Security.ashx");
        }
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

    public string RechargeAndBillpayment(string OrderID, string PaymentGatewayTransactionID,DataTable dtRecord)
    {
        clsFramework objFramework = new clsFramework();
        string mess = string.Empty;
        #region Find Operator Code
        SqlParameter[] parametersOperator = { };
        DataTable dtOperator = new DataTable();
        string operatorcodeName =  Convert.ToString(dtRecord.Rows[0]["operator"]) ;
        //dtOperator = objFramework.GetRecordSet("select  opratorcode,operatorname,operatorCodename from adv_OperatorCode where Activestatus =1 and serviceType='" + Convert.ToString(dtRecord.Rows[0]["RechargeType"]) + "' and  opratorcode='" + Convert.ToString(dtRecord.Rows[0]["operator"]) + "' ", CommandType.Text, parametersOperator);
        //if (dtOperator != null)
        //{
        //    if (dtOperator.Rows.Count > 0)
        //        operatorcodeName = dtOperator.Rows[0]["operatorCodename"].ToString();
        //}
        #endregion
        SqlParameter[] parameters = { };
        WebClient client = new WebClient();
        //string OrderID = string.Empty;
        //DataTable dtMaxID = objFramework.GetRecordSet("select isnull(max(APIResponseID),0)+1 from adv_Operator_APIResponse", CommandType.Text, parameters);
        //OrderID = dtMaxID.Rows[0][0].ToString().PadLeft(6, '1');
        Int64 uniqueID = DateTime.Now.Ticks;
        string API = string.Empty;
        if (Convert.ToString(dtRecord.Rows[0]["RechargeType"]).ToLower() == "prepaid")
            API = "https://joloapi.com/api/recharge.php?mode=1&userid=cashonshop&key=899388873156283&operator=" + operatorcodeName + "&service=" + Convert.ToString(dtRecord.Rows[0]["Service"]) + "&amount=" + Convert.ToString(dtRecord.Rows[0]["Amount"]) + "&orderid=" + OrderID + "&type=text";
        else if (Convert.ToString(dtRecord.Rows[0]["RechargeType"]).ToLower() == "postpaid")
            API = "https://joloapi.com/api/cbill.php?mode=1&userid=cashonshop&key=899388873156283&operator=" + operatorcodeName + "&service=" + Convert.ToString(dtRecord.Rows[0]["Service"]) + "&amount=" + Convert.ToString(dtRecord.Rows[0]["Amount"]) + "&orderid=" + OrderID + "&type=text";
        var dotd = client.DownloadString(API);
        DataTable dt = new DataTable();

        if (dotd.Split(',').Length == 2)
        {
            dt = objFramework.GetRecordSet("SELECT ErrorCode, ErrorDetail, Status FROM  adv_OperatorErrorCode where isnull(Status,1) =1 and ErrorCode='" + dotd.Split(',')[1].ToString() + "' ", CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
                mess = dt.Rows[0]["ErrorDetail"].ToString();
            objFramework.ExecuteNonQuery("update adv_Operator_APIResponse set SuccessStatus='" + dotd.Split(',')[0].ToString() + "',ErrorCode='" + dotd.Split(',')[1].ToString() + "',PaymentGatewayTransactionID='" + PaymentGatewayTransactionID + "',Time=getdate() where ourOrderID='" + OrderID + "'", CommandType.Text, parameters);
            
            //if Payment gateway transaction is successfull but mobile recharge failed then call for refund
        }

        else if (dotd.Split(',').Length > 2)
        {
            MembershipUser mu = Membership.GetUser();
            string[] data = dotd.Split(',');
            if (data[7].ToString() == string.Empty)
            {
                DataTable dtDispute = new DataTable();
                string uri1 = "https://joloapi.com/api/dispute.php?userid=cashonshop&key=899388873156283&servicetype=1&txn=" + data[0].ToString() + "&type=text";
                var dotd1 = client.DownloadString(uri1);
                objFramework.ExecuteNonQuery("update adv_Operator_APIResponse set JoloOrderID='" + data[0].ToString() + "',SuccessStatus='" + dotd1[0].ToString() + "',ErrorCode='" + data[6].ToString() + "',OperatorID='" + data[7].ToString() + "',Balance='" + data[8].ToString() + "',Margin='" + data[9].ToString() + "',Time='" + data[10].ToString() + "',PaymentGatewayTransactionID='" + PaymentGatewayTransactionID + "' where ourOrderID='" + OrderID + "' ", CommandType.Text, parameters);
                mess = "Waiting For Operator Confirmation.";
            }
            else
            {
                //objFramework.ExecuteNonQuery("insert into adv_Operator_APIResponse(CashOnShopUserID,JoloOrderID,SuccessStatus,Operator,Service,Amount,OurOrderID,ErrorCode,OperatorID,Balance,Margin,Time,WalletAmount,PaymentGatewayTransactionID)values('" + mu.ProviderUserKey.ToString() + "','" + data[0].ToString() + "','" + data[1].ToString() + "','" + data[2].ToString() + "','" + data[3].ToString() + "','" + data[4].ToString() + "','" + data[5].ToString() + "','" + data[6].ToString() + "','" + data[7].ToString() + "','" + data[8].ToString() + "','" + data[9].ToString() + "','" + data[10].ToString() + "','" + WalletAmt + "','" + PaymentGatewayTransactionID + "')", CommandType.Text, parameters);
                objFramework.ExecuteNonQuery("update adv_Operator_APIResponse set JoloOrderID='" + data[0].ToString() + "',SuccessStatus='" + data[1].ToString() + "',ErrorCode='" + data[6].ToString() + "',OperatorID='" + data[7].ToString() + "',Balance='" + data[8].ToString() + "',Margin='" + data[9].ToString() + "',Time='" + data[10].ToString() + "',PaymentGatewayTransactionID='" + PaymentGatewayTransactionID + "' where ourOrderID='"+OrderID+"'", CommandType.Text, parameters);
                mess = "Transaction Completed Successfully.";
            }


        }
        return mess;
    }
}