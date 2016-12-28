<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_UserSideMenu.ascx.cs"
    Inherits="UC_UCUI_User_uc_UserSideMenu" %>
<b>
    <div class="widget widget-categories">
        <h4>
            User Account <span class="head-line"></span>
        </h4>
        <ul>
            <li>
                <asp:LinkButton ID="lkbDashBoard" CommandName="DashBoard" runat="server" OnClick="lkbClicked_Click">DashBoard</asp:LinkButton>
            </li>
           <%-- <li>
                <asp:LinkButton ID="lkbWallet" CommandName="Wallet" runat="server" OnClick="lkbClicked_Click">Wallet</asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lkbPayment" CommandName="Payment" runat="server" OnClick="lkbClicked_Click">Payment</asp:LinkButton>
            </li>--%>
            <li>
                <asp:LinkButton ID="lkbCashBack" CommandName="Cashback" runat="server" OnClick="lkbClicked_Click">CashBack Issue</asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lkbProfile" CommandName="Profile" runat="server" OnClick="lkbClicked_Click"><%--<i class="fa fa-user fa-fw"></i>--%>Profile</asp:LinkButton>
            </li>
           <%-- <li>
                <asp:LinkButton ID="lkbCommision" CommandName="Commision" runat="server" OnClick="lkbClicked_Click">Commision</asp:LinkButton>
            </li>--%>
             <li>
                <asp:LinkButton ID="lkbChangePassword" CommandName="Password" runat="server" OnClick="lkbClicked_Click">Change Password</asp:LinkButton>
            </li>
            <li>
                <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect"
                    LogoutPageUrl="~/Default.aspx" />
            </li>
            <%-- <li><a href="#">Design</a> </li>
                    <li><a href="#">Development</a> </li>
                    <li><a href="#">Graphic</a> </li>--%>
        </ul>
        </div>
</b>