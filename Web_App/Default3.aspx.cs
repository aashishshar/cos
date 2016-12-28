using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class Default3 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
            Load_tree("electronics");
        }
    }

    public void BindWithSubcategory(string subCat)
    {
       
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        SqlDataAdapter da = new SqlDataAdapter("select distinct MCategoryName_V  from Mst_Category C inner join Mst_SubCategory S on C.CategoryID_N=S.CategoryID_N where CategoryName_V='" + subCat + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TreeView1.Nodes.Clear();
            TreeNode rootNode1 = new TreeNode(dt.Rows[0]["MCategoryName_V"].ToString(), dt.Rows[0]["MCategoryName_V"].ToString());
            TreeView1.Nodes.Add(rootNode1);
            TreeNode rootNode2 = new TreeNode(subCat);
            rootNode1.ChildNodes.Add(rootNode2);

            SqlDataAdapter da1 = new SqlDataAdapter("select SubCategoryName_V, (SubCategoryName_V + '('+(select cast(count(*) as varchar(50)) from Adv_Product_Common where ProductCategoryName=S.SubCategoryName_V)+')') as SubCategoryName   from Mst_Category C inner join Mst_SubCategory S on C.CategoryID_N=S.CategoryID_N where CategoryName_V='" + subCat + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    TreeNode child = new TreeNode(dt1.Rows[i]["SubCategoryName"].ToString(), dt1.Rows[i]["SubCategoryName_V"].ToString());
                    rootNode2.ChildNodes.Add(child);
                }
            }
        }
        
        TreeView1.ExpandAll();
    }

    public void BindWithCategory()
    {
            
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
            //SqlDataAdapter da = new SqlDataAdapter("select CategoryName_V,MCategoryName_V,(SubCategoryName_V + '('+(select cast(count(*) as varchar(50)) from Adv_Product_Common where ProductCategoryName=S.SubCategoryName_V)+')') as SubCategoryName_V ,SubCategoryID_N,C.CategoryID_N from Mst_Category C inner join Mst_SubCategory S on C.CategoryID_N=S.CategoryID_N where MCategoryName_V='Electronics'", con);
            SqlDataAdapter da = new SqlDataAdapter("select distinct CategoryName_V, (CategoryName_V + '('+(select cast(count(*) as varchar(50)) from Adv_Product_Common where ProductCategoryName=C.CategoryName_V)+')') as CategoryName from Mst_Category C left outer join Mst_SubCategory S on C.CategoryID_N=S.CategoryID_N where MCategoryName_V='Electronics'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                TreeView1.Nodes.Clear();
                TreeNode rootNode1 = new TreeNode("Electronics", "Electronics");
                TreeView1.Nodes.Add(rootNode1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode child = new TreeNode(dt.Rows[i]["CategoryName"].ToString(), dt.Rows[i]["CategoryName_V"].ToString());
                    rootNode1.ChildNodes.Add(child);
                }
            }
            
            TreeView1.ExpandAll();
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string val = TreeView1.SelectedNode.Text;
        Load_tree(TreeView1.SelectedNode.Text);
    }

    public string BindAllCategories(string categoryName)
    {
        string strAllcategory = string.Empty;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        SqlCommand cmd = new SqlCommand("adv_FindAllChildForCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", categoryName);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);
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
        }
        return strAllcategory;
    }
    public void BindMerchant(string categoryName)
    {
        string strAllcategory = BindAllCategories(categoryName);
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        string sql = "select distinct MID,MerchantNameDetail + ' ('+ cast(COUNT(*) as varchar(50))+')' as MerchantNameDetail from Mst_Category A  inner join Adv_Product_Common C on A.CategoryID_N=C.CategoryID_N inner join Adv_Mst_Merchant D on D.MID=C.Ad_For where isnull(Brand,'')!='' and A.CategoryID_N in(" + strAllcategory + ") group by MID,MerchantNameDetail";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        chkMerchant.DataSource = dt;
        chkMerchant.DataTextField = "MerchantNameDetail";
        chkMerchant.DataValueField = "MID";
        chkMerchant.DataBind();
        if (chkMerchant.Items.Count > 0)
            divmerchant.Visible = true;
        else
            divmerchant.Visible = false;
    }

    public void BindBrand(string categoryName)
    {
        string strAllcategory = BindAllCategories(categoryName);
        string sql = "select distinct Brand,Brand + ' ('+ cast(COUNT(*) as varchar(50))+')' as Branddetail from Mst_Category A inner join Adv_Product_Common C on A.CategoryID_N=C.CategoryID_N  where  A.CategoryID_N in(" + strAllcategory + ") and isnull(Brand,'')!='' group by Brand";
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        chkBrand.DataSource = dt;
        chkBrand.DataTextField = "Branddetail";
        chkMerchant.DataValueField = "Brand";
        chkBrand.DataBind();
        if (chkBrand.Items.Count > 0)
            divBrand.Visible = true;
        else
            divBrand.Visible = false;
        
    }

    [WebMethod]
    public static List<string> GetEmpNames(string empName)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        List<string> Emp = new List<string>();
        string query = string.Format("select distinct Brand from Mst_Category A left outer join Mst_SubCategory B on A.CategoryID_N=B.CategoryID_N left outer join Adv_Product_Common C on A.CategoryName_V=C.ProductCategoryName or B.SubCategoryName_V=C.ProductCategoryName where Brand is not null and Brand LIKE '%{0}%'", empName);
        //SqlDataAdapter da = new SqlDataAdapter(query, con);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        
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

    

    #region Bind Category Tree
    public void Load_tree(string category)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        SqlCommand cmd = new SqlCommand("adv_FindAllParentForCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", category);
        SqlDataAdapter daP = new SqlDataAdapter(cmd);
        DataTable dtp = new DataTable();
        daP.Fill(dtp);
        ViewState["checkvalue"] = null;
        TreeView1.Nodes.Clear();
        foreach (DataRow dr in dtp.Rows)
        {
            if (Convert.ToString(dr["ParentCategoryID_N"]) == string.Empty)
            {
                TreeNode tnParent = new TreeNode();
                tnParent.Text = dr["CategoryName_V"].ToString();
                tnParent.Value = dr["CategoryID_N"].ToString();
                string value = dr["CategoryID_N"].ToString();
                tnParent.Expand();
                TreeView1.Nodes.Add(tnParent);
                FillParentChild(tnParent, value,category);
            }
        }
        BindBrand(category);
        BindMerchant(category);
    }
    public void FillParentChild(TreeNode parent, string ID, string category)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        SqlCommand cmd = new SqlCommand("adv_FindAllParentForCategoryNew", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@categoryname", category);
        cmd.Parameters.AddWithValue("@parentcategoryId", ID);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode child = new TreeNode();
            child.Text = dr["CategoryName_V"].ToString().Trim();
            child.Value = dr["CategoryID_N"].ToString().Trim();
            string temp = dr["CategoryID_N"].ToString();
            child.Expand();
            parent.ChildNodes.Add(child);
            FillParentChild(child, temp,category);
        }
       
        if (dt.Rows.Count == 0 && Convert.ToString(ViewState["checkvalue"]) != "assign")
            FillChild(parent, ID);
    }
    public int FillChild(TreeNode parent, string ID)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Free"].ToString());
        string Childquery = " SELECT CategoryName_V,CategoryID_N from vw_FindAllChildForCategory where ParentCategoryID_N='" + ID + "'";
        SqlDataAdapter da = new SqlDataAdapter(Childquery, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode child = new TreeNode();
                child.Text = dr["CategoryName_V"].ToString().Trim();
                child.Value = dr["CategoryID_N"].ToString().Trim();
                string temp = dr["CategoryID_N"].ToString();
                child.Expand();
                parent.ChildNodes.Add(child);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }
    #endregion

   
    protected void chkMerchant_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}