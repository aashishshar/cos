<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ChangePassword.ascx.cs"
    Inherits="UC_UCUI_Account_uc_ChangePassword" %>
<%-- <div class="latest-posts">
    <!-- Classic Heading -->
   <h5 class="classic-title">
        <span><b>Change Password</b> </span>
    </h5>
</div>
 <p>
        Use the form below to change your password.
    </p>--%>
<%-- <div class="col-md-12">--%>
<p>
    New passwords are required to be a minimum of
    <%= Membership.MinRequiredPasswordLength %>
    characters in length.
</p>
<asp:ChangePassword ID="ChangeUserPassword" runat="server" ContinueDestinationPageUrl="~/Default.aspx"
    ChangePasswordButtonStyle-CssClass="btn btn-success" CancelDestinationPageUrl="~/UC/User/Default.aspx"
    EnableViewState="false" RenderOuterTable="false">
    <ChangePasswordTemplate>
        <span class="failureNotification">
            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span>
        <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="ucChangeUserPasswordValidationGroup" />
        <div class="form-group" style="margin-bottom:0px;">
            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
            <asp:TextBox ID="CurrentPassword" Width="300px"  runat="server"  CssClass="form-control"
                TextMode="Password" ValidationGroup="ucChangeUserPasswordValidationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                ValidationGroup="ucChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group" style="margin-bottom:0px;">
            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
            <asp:TextBox ID="NewPassword" Width="300px"  runat="server"  CssClass="form-control"
                TextMode="Password" ValidationGroup="ucChangeUserPasswordValidationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                ValidationGroup="ucChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group" style="margin-bottom:5px;">
            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
            <asp:TextBox ID="ConfirmNewPassword" Width="300px"  runat="server"  CssClass="form-control"
                TextMode="Password" ValidationGroup="ucChangeUserPasswordValidationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                ToolTip="Confirm New Password is required." ValidationGroup="ucChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ucChangeUserPasswordValidationGroup">*</asp:CompareValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
            <asp:Button ID="ChangePasswordPushButton"  
                runat="server" CommandName="ChangePassword" Text="Change Password" ValidationGroup="ucChangeUserPasswordValidationGroup" />
        </div>
    </ChangePasswordTemplate>
</asp:ChangePassword>

<%--</div>--%>