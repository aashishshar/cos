<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="fpass.aspx.cs" Inherits="Account_fpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-12">
        <h4 class="classic-title">
            <span>Forgot Password!</span></h4>
        <div style="margin-bottom: 0px;">
            <asp:TextBox ID="txtEmail" placeholder="email@mail.com" CssClass="form-control" ValidationGroup="vFpass" Width="300px"
                runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server" Display="Static" ControlToValidate="txtEmail"  ValidationGroup="vFpass" ForeColor="Red"
                    ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator  ValidationGroup="vFpass" ID="RegularExpressionValidator1"
                        Display="Static" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email ID"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
        <div style="margin-bottom: 5px; margin-top: 5px;">
            <asp:Button ID="btnSendMail" runat="server" Text="Submit" Visible="false" OnClick="btn_Submit" />
            <asp:LinkButton ID="btnSendMailLink" CssClass="main-button"  Text="Submit" runat="server" ValidationGroup="vFpass" OnClick="btn_Submit"></asp:LinkButton>
        </div>
        <div class="form-group" style="margin-bottom: 20px;">
            <asp:Label ID="lblMessage" CssClass="text-info" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
