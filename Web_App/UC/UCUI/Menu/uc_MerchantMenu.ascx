<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MerchantMenu.ascx.cs"
    Inherits="UC_UCUI_Menu_uc_MerchantMenu" %>
<%--<asp:BulletedList ID="blMenu" runat="server" CssClass="dropdown">
</asp:BulletedList>--%>
<asp:Repeater ID="blMenu" runat="server">
    <HeaderTemplate>
        <ul class="dropdown">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="hlViewMerchant" NavigateUrl='<%#"~/MerchantOffers.aspx?m="+Eval("Key")%>'
                runat="server"><%#Eval("Value")%></asp:HyperLink>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul></FooterTemplate>
</asp:Repeater>
