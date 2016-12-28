<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_NotificationView.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_NotificationView" %>
<asp:Repeater ID="rptNotification" runat="server">
<HeaderTemplate> <div class="container clearfix"></HeaderTemplate>
    <ItemTemplate>

        <div class="alert alert-warning alert-dismissable" >
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                x</button>
                <%#Eval("NotificationText") %>
            <%--Lorem ipsum dolor adipisicing elit. <a href="#" class="alert-link">Alert Link</a>.--%>
        </div>
    </ItemTemplate>
    <FooterTemplate></div></FooterTemplate>
</asp:Repeater>
