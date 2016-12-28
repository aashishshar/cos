using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Data.SqlClient;

public partial class Recharge : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebClient client = new WebClient();
            string uri = "https://joloapi.com/api/recharge.php?mode=0&userid=cashonshop&key=899388873156283&operator=AT&service=9871255867&amount=10&orderid=1234&type=text";
            var dotd = client.DownloadString(uri);
            Label1.Text = dotd.Split(',')[0].ToString() + dotd.Split(',')[1].ToString(); 
           
        }
    }

    #region
    public DataTable JsonStringToDataTable(string jsonString)
    {
        DataTable dt = new DataTable();
        string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
        List<string> ColumnsName = new List<string>();
        foreach (string jSA in jsonStringArray)
        {
            string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
            foreach (string ColumnsNameData in jsonStringData)
            {
                try
                {
                    int idx = ColumnsNameData.IndexOf(":");
                    string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                    if (!ColumnsName.Contains(ColumnsNameString))
                    {
                        ColumnsName.Add(ColumnsNameString);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                }
            }
            break;
        }
        foreach (string AddColumnName in ColumnsName)
        {
            dt.Columns.Add(AddColumnName);
        }
        foreach (string jSA in jsonStringArray)
        {
            string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
            DataRow nr = dt.NewRow();
            foreach (string rowData in RowData)
            {
                try
                {
                    int idx = rowData.IndexOf(":");
                    string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                    string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                    nr[RowColumns] = RowDataString;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            dt.Rows.Add(nr);
        }
        return dt;
    }
    #endregion

    [WebMethod]
    public static UserDetails[] BindTopUP(string CircleCode, string OperatorCode)
    {

        string type = "TUP";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt=" + OperatorCode + "&cir=" + CircleCode + "&typ=" + type + "&max=500&type=json";
        var dotd = client.DownloadString(uri);
        dotd.Split(',')[0].ToString();
        DataTable data = JsonConvert.DeserializeObject<DataTable>(dotd);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.Detail = dtrow["Detail"].ToString();
            user.Validity = dtrow["Validity"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    [WebMethod]
    public static UserDetails[] BindFullTalkTime(string CircleCode, string OperatorCode)
    {
        string type = "FTT";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt=" + OperatorCode + "&cir=" + CircleCode + "&typ=" + type + "&max=500&type=json";
        var dotd = client.DownloadString(uri);
        DataTable data = JsonConvert.DeserializeObject<DataTable>(dotd);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.Detail = dtrow["Detail"].ToString();
            user.Validity = dtrow["Validity"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    [WebMethod]
    public static UserDetails[] Bind2G(string CircleCode, string OperatorCode)
    {
        string type = "2G";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt=" + OperatorCode + "&cir=" + CircleCode + "&typ=" + type + "&max=500&type=json";
        var dotd = client.DownloadString(uri);
        DataTable data = JsonConvert.DeserializeObject<DataTable>(dotd);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.Detail = dtrow["Detail"].ToString();
            user.Validity = dtrow["Validity"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    [WebMethod]
    public static UserDetails[] Bind3G4G(string CircleCode, string OperatorCode)
    {
        string type = "3G";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt=" + OperatorCode + "&cir=" + CircleCode + "&typ=" + type + "&max=500&type=json";
        var dotd = client.DownloadString(uri);
        DataTable data = JsonConvert.DeserializeObject<DataTable>(dotd);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.Detail = dtrow["Detail"].ToString();
            user.Validity = dtrow["Validity"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    [WebMethod]
    public static UserDetails[] BindLocal(string CircleCode, string OperatorCode)
    {
        string type = "LSC";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt=" + OperatorCode + "&cir=" + CircleCode + "&typ=" + type + "&max=100&type=json";
        var dotd = client.DownloadString(uri);
        DataTable data = JsonConvert.DeserializeObject<DataTable>(dotd);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.Detail = dtrow["Detail"].ToString();
            user.Validity = dtrow["Validity"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    [WebMethod]
    public static UserDetails[] BindRoaming(string CircleCode, string OperatorCode)
    {
        string type = "RMG";
        WebClient client = new WebClient();
        DataTable dt = new DataTable();
        string uri = "https://joloapi.com/api/findplan.php?userid=cashonshop&key=899388873156283&opt=" + OperatorCode + "&cir=" + CircleCode + "&typ=" + type + "&max=500&type=json";
        var dotd = client.DownloadString(uri);
        DataTable data = JsonConvert.DeserializeObject<DataTable>(dotd);
        List<UserDetails> details = new List<UserDetails>();
        foreach (DataRow dtrow in data.Rows)
        {
            UserDetails user = new UserDetails();
            user.Detail = dtrow["Detail"].ToString();
            user.Validity = dtrow["Validity"].ToString();
            user.Amount = dtrow["Amount"].ToString();
            details.Add(user);
        }
        return details.ToArray();
    }

    public class UserDetails
    {
        public string Detail { get; set; }
        public string Validity { get; set; }
        public string Amount { get; set; }
    }
}