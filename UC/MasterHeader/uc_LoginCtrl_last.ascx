<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LoginCtrl_last.ascx.cs"
    Inherits="UC_MasterHeader_uc_LoginCtrl" %>
<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
    DestinationPageUrl="~/Security.ashx">
    <LayoutTemplate>
        <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="LoginUserValidationGroup" />
        <div class="form-group">
            <div class="row">
                <div class="col-md-10">
                    <asp:TextBox ID="UserName" runat="server" Width="" CssClass="form-control" placeholder="E-mail"
                        autofocus></asp:TextBox></div>
                <div class="col-md-2" style="text-align: left; padding: 0px!important; color: Red;">
                    <asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="UserName" ValidationGroup="login"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-md-10">
                    <asp:TextBox ID="Password" runat="server" Width="" CssClass="form-control" placeholder="Password"
                        TextMode="Password"></asp:TextBox></div>
                <div class="col-md-2" style="text-align: left; padding: 0px!important; color: Red;">
                    <asp:RequiredFieldValidator ID="rfvPass" ControlToValidate="Password" ValidationGroup="login"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
            </div>
        </div>
        <div class="form-group">
            <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="~/fpass.aspx"><b>Forgot Password!</b></asp:HyperLink>
        </div>
        <div class="form-group">
            <%--<div class="row">
                <div class="col-md-12">
                   <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>--%>
            <asp:Button ID="LoginButton" runat="server" Width="" EnableTheming="false" CommandName="Login"
                Text="log in" ValidationGroup="login" CssClass="btn-system btn-medium" />
            <br />
            <span class="text-danger">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <%-- </div>
            </div>--%>
        </div>
    </LayoutTemplate>
</asp:Login>
