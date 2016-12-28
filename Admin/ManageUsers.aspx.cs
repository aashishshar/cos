using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.Services;
using System.Web.Script.Services;

public partial class Admin_ManageUsers : AdminBasePage
{
    static int pageSize = 5;
    static int totalUsers;
    static int totalPages;
    static int currentPage = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoleList();
            //GetAllUser();
            GetAllRoles();
            MembershipUserCollection revenue = GetAllUserByPage(currentPage);
            gvItems.DataSource = revenue;
            gvItems.DataBind();
            if (gvItems.Rows.Count > 0)
            {
                gvItems.UseAccessibleHeader = true;
                gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void deleteButton_ServerClick(object sender, EventArgs e)
    { 

    }

    private void BindRoleList()
    {
        ddlRoleList.Items.Clear();
        ddlRoleList.DataSource = clsRole.GetAllRoles();
        ddlRoleList.DataBind();
        //ddlRoleList.Text = "Name";
        ddlRoleList.Items.Insert(0, new ListItem(" Role Name ", "ROLENAME"));
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public static MembershipUserCollection GetAllUserByPage(int pageNo)
    {
        MembershipUserCollection mc =Membership.GetAllUsers();//.GetAllUsers(pageNo-1,pageSize,out totalUsers);//clsuser.getAllUser(pageNo,pageSize,out totalRecords);

        return mc;

    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public static int GetTotalPageCount()
    {
        int count = 0;
        count = totalUsers;
        count = count / pageSize;
        return count;
    }

   
    private void GetAllUser()
    {

        gvItems.DataSource = clsuser.getAllUser(currentPage - 1, pageSize, out totalUsers); //clsRole.GetUsersInRole(ddlRoleList.SelectedItem.Text);
        //gvUsersList.DataBind();
        //gvUsersList.HeaderRow.TableSection = TableRowSection.TableHeader;
        totalPages = ((totalUsers - 1) / pageSize) + 1;


        // Ensure that we do not navigate past the last page of users.

        if (currentPage > totalPages)
        {
            currentPage = totalPages;
            GetAllUser();
            return;
        }

        gvItems.DataBind();
        CurrentPageLabel.Text = currentPage.ToString();
        TotalPagesLabel.Text = totalPages.ToString();

        if (currentPage == totalPages)
            NextButton.Visible = false;
        else
            NextButton.Visible = true;

        if (currentPage == 1)
            PreviousButton.Visible = false;
        else
            PreviousButton.Visible = true;

        if (totalUsers <= 0)
            NavigationPanel.Visible = false;
        else
            NavigationPanel.Visible = true;
    }
    public void NextButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage++;
        GetAllUser();
    }

    public void PreviousButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage--;
        GetAllUser();
    }
    private void GetAllRoles()
    {
        string[] array = clsRole.GetAllRoles();
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        for (int i = 0; i < array.Count(); i++)
        {
            dt.Rows.Add();
            dt.Rows[i]["Name"] = array[i].ToString();
        }
        gvRoles.DataSource = dt;//clsRole.GetUsersInRole(ddlRoleList.SelectedItem.Text);
        gvRoles.DataBind();
        // gvRoles.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void ddlRoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAllUser();
    }

    protected void btnRoleName_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtRoleName.Text))
        {
            clsRole.CreateRole(txtRoleName.Text.Trim());
            txtRoleName.Text = string.Empty;
            GetAllRoles();
            BindRoleList();
        }
    }

    protected void btnAddUserName_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUserName.Text) && ddlRoleList.SelectedIndex > -1)
        {
            try
            {
                lblUserCreate.Text = string.Empty;
                //clsuser.CreateUser(txtUserName.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text, ddlRoleList.SelectedItem.Text);
                txtUserName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                ddlRoleList.SelectedIndex = -1;
                GetAllUser();
            }
            catch (MembershipCreateUserException ex)
            {
                lblUserCreate.Text = clsuser.GetErrorMessage(ex.StatusCode);
            }
        }
    }

    //protected void gvUsersList_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "delUser")
    //    {
    //        string userName = e.CommandArgument.ToString();
    //        clsuser.DeleteUser(userName);
    //        GetAllUser();
    //    }
    //}


    protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoles.PageIndex = e.NewPageIndex;
        GetAllRoles();
    }

    //protected void gvUsersList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvUsersList.PageIndex = e.NewPageIndex;
    //    GetAllUser();
    //}

    protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRole")
        {
            string roleName = e.CommandArgument.ToString();
            clsRole.DeleteRole(roleName);
            GetAllRoles();
            BindRoleList();//deleteButton_ServerClick
        }
    }

    protected void gvUsersList_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        GridViewRow pagerRow = (GridViewRow)gv.BottomPagerRow;

        if (pagerRow != null && pagerRow.Visible == false)
            pagerRow.Visible = true;
    }
}