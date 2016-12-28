using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

/// <summary>
/// Summary description for clsFramework
/// </summary>
public class clsFramework
{
	public clsFramework()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void ExecuteNonQuery(string cmdText, CommandType type,SqlParameter[] prms)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = type;

                if (prms != null)
                {
                    foreach (SqlParameter p in prms)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
        }
    }

    public DataTable GetRecordSet(string cmdText, CommandType type, SqlParameter[] prms)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = type;

                if (prms != null)
                {
                    foreach (SqlParameter p in prms)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                da.SelectCommand = cmd;
                da.Fill(dt);
            }

        }
        return dt;
    }
}

