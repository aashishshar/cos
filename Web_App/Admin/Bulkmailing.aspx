<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Bulkmailing.aspx.cs" Inherits="Admin_Bulkmailing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    .<div class="row">
        <div class="col-lg-12">
            <h3 class="page-header">
                Bulk Mailing
            </h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Mailer</div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-2">
                                <asp:DropDownList ID="ddlTemplateType" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtEmailTo" placeholder="To Email-ID" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtSubject" placeholder="Mail Subject" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfv" ControlToValidate="txtSubject" ValidationGroup="mailSend" runat="server"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtSendMail" ClientIDMode="Static" placeholder="Send Mail After" MaxLength="7" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtMailCount"  ClientIDMode="Static" placeholder="Total Mail Send" MaxLength="7" runat="server"></asp:TextBox></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:Button runat="server" ValidationGroup="mailSend" ID="btnRunTemplateDesign" Text="Send with API "
                                OnClick="btnRunTemplateDesign_Click" />
                        </div>
                        <div class="col-lg-1">
                            <asp:Button runat="server" ValidationGroup="mailSend" ID="Button1" Text="Send" 
                                onclick="Button1_Click" />
                            <asp:Label ID="lblmsg" runat="server" CssClass="strMsg"></asp:Label></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtSendMail").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A, Command+A
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
