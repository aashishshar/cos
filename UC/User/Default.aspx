<%@ Page Title="" Language="C#" MasterPageFile="~/UC/UserMain.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="UC_User_Default" %>

<%@ Register Src="../UCUI/User/uc_UserSideMenu.ascx" TagName="uc_UserSideMenu" TagPrefix="uc1" %>
<%@ Register Src="../UCUI/User/uc_UserDashBoard.ascx" TagName="uc_UserDashBoard"
    TagPrefix="uc2" %>
<%@ Register Src="../UCUI/Account/uc_ChangePassword.ascx" TagName="uc_ChangePassword"
    TagPrefix="uc3" %>
<%@ Register Src="../UCUI/Account/EditProfile.ascx" TagName="EditProfile" TagPrefix="uc4" %>
<%@ Register src="../UCUI/User/uc_MissingCashback.ascx" tagname="uc_MissingCashback" tagprefix="uc5" %>
<%--<%@ Register Src="../UCUI/Account/EditProfile.ascx" TagName="EditProfile" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 
      <div class="col-lg-12 col-md-12 col-sm-12">
            <h5 class="classic-title">
                <span><b>My Account</b></span>  </h5>
            <div class="tabs-section">
                <!-- Nav Tabs -->
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#tab-1" data-toggle="tab"><i class="fa fa-money"></i>Cashback
                        Detail</a></li>
                    <li class=""><a href="#tab-2" data-toggle="tab"><i class="fa fa-support"></i>Cashback Issue</a></li>
                    <li class=""><a href="#tab-3" data-toggle="tab"><i class="fa fa-user fa-fw"></i>Profile</a></li>
                    <li class=""><a href="#tab-4" data-toggle="tab"><i class="fa fa-gear fa-fw"></i>Change
                        Password</a></li>
                </ul>
                <!-- Tab panels -->
                <div class="tab-content">
                    <!-- Tab Content 1 -->
                    <div class="tab-pane fade active in" id="tab-1">
                        <uc2:uc_UserDashBoard ID="uc_UserDashBoard1"  runat="server" />
                    </div>
                    <!-- Tab Content 2 -->
                    <div class="tab-pane fade" id="tab-2">
                    <uc5:uc_MissingCashback ID="uc_MissingCashback1" runat="server" />
                    </div>
                    <!-- Tab Content 3 -->
                    <div class="tab-pane fade" id="tab-3">
                        <uc4:EditProfile ID="EditProfile1" runat="server" />
                    </div>
                    <div class="tab-pane fade" id="tab-4">
                        <uc3:uc_ChangePassword ID="uc_ChangePassword1" runat="server" />
                    </div>
                </div>
                <!-- End Tab Panels -->
            </div>
            <%--<asp:PlaceHolder ID="phDynamicControls" runat="server"></asp:PlaceHolder>--%>
       </div>
   
    <%-- <div class="col-md-3">
        <div class="col-md-12 sidebar right-sidebar">
            <uc1:uc_UserSideMenu ID="uc_UserSideMenuNavigation" runat="server" />
        </div>
    </div>--%>
</asp:Content>
