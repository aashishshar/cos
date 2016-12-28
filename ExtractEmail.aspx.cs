using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;

public partial class ExtractEmail : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
        if (!IsPostBack)
        {
            //emas("abcd abcd@gmail.com mukesh kumar singh pass@gmail.com new@gmail.com");
        }
    }

    public void emas(string text)
    {
        try
        {
            const string MatchEmailPattern =
           @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex rx = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Find matches.
            MatchCollection matches = rx.Matches(text);
            // Report the number of matches found.
            int noOfMatches = matches.Count;
            // Report on each match.
            string email = string.Empty;
            //foreach (Match match in matches)
            //{
            //    SqlCommand cmd = new SqlCommand("adv_SubscribeMail", con);
            //    cmd.Parameters.AddWithValue("@Email", match.Value.ToString());
            //    cmd.Parameters.AddWithValue("@Status", "A");
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //}
            string b="m,k";
            string[] a = b.Split(',');
            a.AsDataTable();
        }
        catch (Exception ex)
        { }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        //Upload and save the file
        string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
        
        FileUpload1.SaveAs(excelPath);

        string conString = string.Empty;
        string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

        String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", excelPath);
        //switch (extension)
        //{
        //    case ".xls": //Excel 97-03
        //        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
        //        break;
        //    case ".xlsx": //Excel 07 or higher
        //        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
        //        break;

        //}
        //conString = string.Format(conString+"{0}", excelPath);
        using (OleDbConnection excel_con = new OleDbConnection(excelConnString))
        {
           // excel_con.Close();
            excel_con.Open();
            string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["Table_Name"].ToString();
            DataTable dtExcelData = new DataTable();

            //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
            dtExcelData.Columns.AddRange(new DataColumn[2] { new DataColumn("SubscribeEmail", typeof(string)),
                new DataColumn("Status", typeof(int))
                 });

            using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
            {
                oda.Fill(dtExcelData);
            }
            excel_con.Close();

            string consString = ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.Adv_Subscribe";

                    //[OPTIONAL]: Map the Excel columns with that of the database table
                    sqlBulkCopy.ColumnMappings.Add("SubscribeEmail", "SubscribeEmail");
                    sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                    
                    con.Open();
                    sqlBulkCopy.WriteToServer(dtExcelData);
                    con.Close();
                }
            }
        }
    }
}