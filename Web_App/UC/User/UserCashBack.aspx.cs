using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

public partial class UC_User_UserCashBack : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static UserDetails[] GetCaskBackdetailForUser(string PageIndex)
    {
        MembershipUser mu = Membership.GetUser();
        clsFramework objFramework = new clsFramework();
        SqlParameter[] parameters =
        {  
           new SqlParameter ("@PageIndex",SqlDbType.VarChar){Value=PageIndex},
           new SqlParameter ("@PageSize",SqlDbType.VarChar){Value=2},
           new SqlParameter ("@CashOnShopUserID",SqlDbType.VarChar){Value=mu.ProviderUserKey.ToString()}
        };

        DataTable dt = new DataTable();
        DataTable data = objFramework.GetRecordSet("adv_PROC_CashBackHistory", CommandType.StoredProcedure, parameters);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.operatorName = dtrow["OperatorName"].ToString();
            user.RechargeType = dtrow["RechargeType"].ToString();
            user.Mobile = dtrow["Mobile"].ToString();
            user.RechargeAmount = dtrow["RechargeAmount"].ToString();
            user.CouponCode = dtrow["CouponCode"].ToString();
            user.OrderID = dtrow["OrderID"].ToString();
            user.CashBackAmount = dtrow["CashBackAmount"].ToString();
            user.Status = dtrow["Status"].ToString();
            user.CreatedDate = dtrow["CreatedDate"].ToString();
            details.Add(user);
        }
        return details.ToArray();

        
    }

    public class UserDetails
    {
        public string RechargeType { get; set; }
        public string Mobile { get; set; }
        public string RechargeAmount { get; set; }
        public string operatorName { get; set; }
        public string CouponCode { get; set; }
        public string OrderID { get; set; }
        public string CashBackAmount { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
    }
}

