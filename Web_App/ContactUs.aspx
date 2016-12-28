<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-8" style="margin-bottom:25px;">
        <!-- Classic Heading -->
        <h4 class="classic-title">
            <span>Contact Us</span></h4>
        <!-- Start Contact Form -->
        <%-- <form role="form" class="contact-form" id="contact-form" method="post">--%>
        <div class="form-group">
            <div class="controls">
                <asp:TextBox ID="txtName"  runat="server" CssClass="form-control" placeholder="Name" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="controls">
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control"  MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="controls">
                <asp:TextBox ID="txtSubject" placeholder="Subject" MaxLength="100" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="controls">
                <asp:TextBox ID="txtMessage" Rows="7" MaxLength="500" CssClass="form-control"  TextMode="MultiLine" placeholder="Message"
                    runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnSendMail" ValidationGroup="s" runat="server" EnableTheming="false"
            CssClass="main-button" Text="Send" OnClick="btnSendMail_Click" />
        <div id="success" runat="server" style="color: #34495e;">
        </div>
       
        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" ValidationGroup="s" ShowMessageBox="false" ShowSummary="true"
            runat="server" DisplayMode="List"  />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="s" ControlToValidate="txtName" Display="None"
            runat="server" ErrorMessage="<span style='coler:red;'>Plz Enter your name.</span>"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="s" ControlToValidate="txtEmail" Display="None"
            runat="server" ErrorMessage="<span style='coler:red;'>Plz Enter your emailid</span>"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="s" ControlToValidate="txtSubject" Display="None"
            runat="server" ErrorMessage="<span style='coler:red;'>Plz Enter subject.</span>"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="s" ControlToValidate="txtMessage" Display="None"
            runat="server" ErrorMessage="<span style='coler:red;'>Plz Enter message.</span>"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="None"
                ErrorMessage="Invalid email-Id." ValidationGroup="s" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <%--  </form>--%>
        <!-- End Contact Form -->
    </div>
    <div class="col-md-4">
        <!-- Classic Heading -->
        <h4 class="classic-title">
            <span>Contact Info</span></h4>
        <!-- Some Info -->
        <p>
            Plexis Software Solution LLP</p>
        <!-- Divider -->
        <div class="hr1" style="margin-bottom: 5px!important;">
        </div>
        <!-- Info - Icons List -->
        <ul class="icons-list">
            <li><i class="fa fa-globe"></i><strong>Website:</strong> http://www.plexistech.com</li>
            <li><i class="fa fa-envelope-o"></i><strong>Email:</strong> info@plexistech.com</li>
            <%--<li><i class="fa fa-mobile"></i> <strong>Phone:</strong> +12 345 678 001</li>--%>
        </ul>
        <!-- Divider -->
        <div class="hr1" style="margin-bottom: 15px;">
        </div>
        <!-- Classic Heading -->
        <h4 class="classic-title">
            <span>Working Hours</span></h4>
        <!-- Info - List -->
        <ul class="list-unstyled">
            <li><strong>Monday - Friday</strong> - 9am to 5pm</li>
            <li><strong>Saturday</strong> - 9am to 2pm</li>
            <li><strong>Sunday</strong> - Closed</li>
        </ul>
    </div>
</asp:Content>
