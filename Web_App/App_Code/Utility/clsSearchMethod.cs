using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for clsSearchMethod
/// </summary>
public class clsSearchMethod
{
    DataTable dt;
    SqlConnection con = new SqlConnection();
	public clsSearchMethod()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Ad_ConnectionStringMain"].ToString());
	}
    public DataTable BindSearchMethodsForCategory(string categoryName,CheckBoxList[] chkl,HtmlControl[] div,Label[] lblCtrl,TextBox[] txtctrl,DataTable dtProduct)
    {
        dt = new DataTable();
        string strAllcategory = BindAllCategories(categoryName);
        string getQuery = "select DSEARCHID, A.categoryid_n,brandid,DisplayText,QueryText,DataTextField,DataValueField,whereclause,GroupByClause,status from  adv_dynamicSearch A inner join mst_category B on A.categoryid_n=B.categoryid_n  where status in(1,2) and CategoryName_V='" + categoryName + "' order by SEQUENCE ";
        SqlDataAdapter da = new SqlDataAdapter(getQuery,con);
        da.Fill(dt);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    #region Check for Selected Values in current Checkboxe
                    string strCurrentSelectedText = string.Empty;
                    if (chkl[i].ClientID == chkl[8].ClientID)
                    {
                       
                        if (chkl[8].Items.Count > 0)
                        {
                            foreach (ListItem lstSelected in chkl[8].Items)
                            {
                                if (lstSelected.Selected)
                                {
                                    string input = string.Empty;
                                    int index = lstSelected.Text.LastIndexOf("(");
                                    if (index > 0)
                                        input = lstSelected.Text.Substring(0, index - 1);
                                    strCurrentSelectedText = strCurrentSelectedText + input + ",";
                                }
                            }
                            strCurrentSelectedText = strCurrentSelectedText.TrimEnd(',');
                        }
                    }
                    #endregion

                    if (strCurrentSelectedText==string.Empty)
                    {

                        #region Check for Selected Values in Checkboxes
                    string strSelectedText = string.Empty;
                    if (chkl[i].Items.Count > 0)
                    {
                        foreach (ListItem lstSelected in chkl[i].Items)
                        {
                            if (lstSelected.Selected)
                            {
                                string input = string.Empty;
                                int index = lstSelected.Text.LastIndexOf("(");
                                if (index > 0)
                                    input = lstSelected.Text.Substring(0, index - 1);
                                strSelectedText = strSelectedText + input + ",";
                            }
                        }
                        strSelectedText = strSelectedText.TrimEnd(',');
                    }
                    #endregion

                        if (dt.Rows[i]["Status"].ToString() == "1")
                        {


                            string strwhereCondition = dt.Rows[i]["whereclause"].ToString();
                            string strgroupby = dt.Rows[i]["GroupByClause"].ToString();
                            var query1 = (from t in dtProduct.AsEnumerable()
                                          where !string.IsNullOrEmpty(t.Field<string>(strwhereCondition))
                                          group t by t.Field<string>(strgroupby) into g
                                          select new
                                          {
                                              DisplayText = g.Key + " (" + g.Count() + ")"
                                          }
                           ).AsParallel().ToList();

                            chkl[i].DataTextField = dt.Rows[i]["DataTextField"].ToString();
                            chkl[i].DataValueField = dt.Rows[i]["DataValueField"].ToString();
                            chkl[i].DataSource = query1;
                            chkl[i].DataBind();
                            if (query1.Count > 0)
                                div[i].Style.Add("display", "block");
                            else
                                div[i].Style.Add("display", "none");

                            lblCtrl[i].Text = dt.Rows[i]["DisplayText"].ToString();
                            txtctrl[i].Attributes.Add("placeholder", dt.Rows[i]["DisplayText"].ToString());

                        }
                        else
                        {

                            DataTable dt1 = new DataTable();
                            string getQuery1 = "select BindText,CollectionText from  adv_DynamicChildSearch A inner join mst_category B on A.categoryid_n=B.categoryid_n  where status=1 and CategoryName_V='" + categoryName + "'  and DSEARCHID='" + dt.Rows[i]["DSEARCHID"].ToString() + "'";
                            SqlDataAdapter da1 = new SqlDataAdapter(getQuery1, con);
                            da1.Fill(dt1);
                            chkl[i].DataTextField = "BindText";
                            chkl[i].DataValueField = "CollectionText";
                            chkl[i].DataSource = dt1;
                            chkl[i].DataBind();
                            if (dt1.Rows.Count > 0)
                                div[i].Style.Add("display", "block");
                            else
                                div[i].Style.Add("display", "none");

                            lblCtrl[i].Text = dt.Rows[i]["DisplayText"].ToString();
                            txtctrl[i].Attributes.Add("placeholder", dt.Rows[i]["DisplayText"].ToString());
                        }


                        #region Check For Selecting All
                        string[] ary = strSelectedText.Split(',');
                        for (int j = 0; j < ary.Length; j++)
                        {
                            foreach (ListItem lstSelected in chkl[i].Items)
                            {
                                string input = string.Empty;
                                int index = lstSelected.Text.LastIndexOf("(");
                                if (index > 0)
                                    input = lstSelected.Text.Substring(0, index - 1);
                                if (input == ary[j].ToString())
                                    lstSelected.Selected = true;
                            }
                        }
                        #endregion

                    }
                    else
                    {
                        for (int l = 0; l < chkl[i].Items.Count; l++)
                        {
                            string input = string.Empty;
                            int index = chkl[i].Items[l].Text.LastIndexOf("(");
                            if(index==-1)
                                chkl[i].Items[l].Attributes.Add("style", "display:none;");
                        }
                    }
                }

            }
        }
        
        return dt;
    }

    public int BindSearchMethods(string categoryName, DataTable dtProduct)
    {

        string[] strwhereCondition = categoryName.Split(',');
        var query1 = (from t in dtProduct.AsEnumerable()
                      where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("description")) ? t.Field<string>("description").Contains(s):false)
                      select new {
                          brand = t.Field<string>("Brand")
                      }).AsParallel().ToList();
        return query1.Count;

    }

    public string BindAllCategories(string categoryName)
    {
        SqlCommand cmd = new SqlCommand("adv_FindAllChildForCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", categoryName);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);
        string strAllcategory = string.Empty;
        if (dtp != null)
        {
            if (dtp.Rows.Count > 0)
            {
                for (int i = 0; i < dtp.Rows.Count; i++)
                {
                    strAllcategory = strAllcategory + "'" + dtp.Rows[i]["CategoryID_N"].ToString() + "',";
                }
                strAllcategory = strAllcategory.TrimEnd(',');
            }
            else
            {
                SqlDataAdapter daCat = new SqlDataAdapter("select categoryid_n from mst_category where categoryname_v='" + categoryName + "'", con);
                DataTable dtcat = new DataTable();
                daCat.Fill(dtcat);
                if (dtcat != null)
                {
                    if (dtcat.Rows.Count > 0)
                        strAllcategory = dtcat.Rows[0]["categoryid_n"].ToString();
                }

            }
        }
        return strAllcategory;
    }

    public DataTable BindSearchResult(CheckBoxList[] chkl, HtmlControl[] div, DataTable dtProduct)
    {
        
        if (div[0].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[0].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[0].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Text.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Brand")) ? t.Field<string>("Brand").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }


        if (div[1].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[1].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[1].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Text.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("MerchantNameDetail")) ? t.Field<string>("MerchantNameDetail").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }


        if (div[2].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[2].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[2].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Value;//.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Description")) ? t.Field<string>("Description").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }


        if (div[3].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[3].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[3].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Value;//.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Description")) ? t.Field<string>("Description").Contains(s) : false)
                                  select t);
                    if(query1.Count()>0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }



        if (div[4].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[4].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[4].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Value;//.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Description")) ? t.Field<string>("Description").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }


        if (div[5].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[5].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[5].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Value;//.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Description")) ? t.Field<string>("Description").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }


        if (div[6].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[6].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[6].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Value;//.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Description")) ? t.Field<string>("Description").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }


        if (div[7].Visible == true)
        {
            string strsearchText = string.Empty;
            if (chkl[7].Items.Count > 0)
            {
                foreach (ListItem lst1 in chkl[7].Items)
                {
                    if (lst1.Selected)
                    {
                        string input = string.Empty;
                        int index = lst1.Text.LastIndexOf("(");
                        if (index > 0)
                        {
                            input = lst1.Value;//.Substring(0, index - 1);
                            strsearchText = strsearchText + input + ",";
                        }
                    }

                }
                strsearchText = strsearchText.TrimEnd(',');
                if (strsearchText != string.Empty)
                {
                    string[] strwhereCondition = strsearchText.Split(',');
                    var query1 = (from t in dtProduct.AsEnumerable()
                                  where strwhereCondition.Any(s => !string.IsNullOrEmpty(t.Field<string>("Description")) ? t.Field<string>("Description").Contains(s) : false)
                                  select t);
                    if (query1.Count() > 0)
                        dtProduct = query1.CopyToDataTable();
                }
            }
        }

        return dtProduct;
    }

    public DataTable FunctionForPaging(DataTable dtResult,int currentpage,int pagesize)
    {
        var a = dtResult.AsEnumerable().Skip(currentpage * pagesize).Take(pagesize).ToList();
        dtResult = a.CopyToDataTable();
        return dtResult;
    }
}