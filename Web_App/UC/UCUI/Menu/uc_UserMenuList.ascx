<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_UserMenuList.ascx.cs"
    Inherits="UC_UCUI_Menu_uc_UserMenuList" %>
<div class="alert alert-Normal">
    <div class="row">
        <div class="col-lg-10 col-md-10 col-sm-10">
            <i class="fa fa-user"></i>
            <asp:HyperLink ID="hlAccount" NavigateUrl="~/UC/User/Default.aspx" runat="server">My Account</asp:HyperLink>
            |&nbsp;<i class="fa fa-flash"></i>
            <asp:HyperLink ID="hlRecharge" NavigateUrl="~/UC/User/Recharge.aspx"  runat="server">Bill Payment/Recharge</asp:HyperLink>
            |&nbsp;<i class="fa fa-shopping-cart icon-middle"></i>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UC/User/RechargeOrder.aspx"  runat="server">Recharge Order</asp:HyperLink>
            |&nbsp;<i class="fa fa-repeat"></i>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/UC/User/UserCashBack.aspx"  runat="server">Recharge Cashback</asp:HyperLink>
        </div>
        <div class="col-lg-2 col-md-2 col-sm-2 text-right">
            <asp:Image ID="imgWallet" ImageUrl="~/Images/wallet.png" AlternateText="Wallet" ImageAlign="TextTop"
                runat="server" /><%--&nbsp;<i class='fa fa-inr'></i>--%>
          
            <asp:Label ID="lblWalletAmount" ClientIDMode="Static" runat="server"  
                ></asp:Label>
        </div>
    </div>
</div>
