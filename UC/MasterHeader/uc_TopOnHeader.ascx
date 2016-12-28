<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TopOnHeader.ascx.cs"
    Inherits="UC_MasterHeader_uc_TopOnHeader" %>
<ul class="contact-details ">
    <li><a href="#"><i class="fa fa-envelope-o"></i>&nbsp;care@cashonshop.com</a>
    </li>
   <%-- <li><a href="#"><i class="fa fa-whatsapp"></i>&nbsp;+91-9643069614</a> </li>--%>
</ul>
<%--<div class="col-md-6" style="float: right; text-align: right!important; vertical-align: bottom!important;">
    <ul class="contact-details">
        <div id="divUserPanel" runat="server" style="color:White;" >
            <li >
                <asp:HyperLink ID="hlProfile" NavigateUrl="~/Security.ashx" runat="server">
                    <i class="fa fa-user fa-fw"></i>
                    <asp:LoginName ID="HeadLoginName" runat="server" />
                </asp:HyperLink>
            </li>
            <li >
                <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" />
            </li>
        </div>
        <div id="divDefaultPanel" runat="server" style="color:White;">
            <li><b><a href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-lock">
            </i>&nbsp;LOGIN</a></b></li>
            <li><b><a href="Account/Login.aspx">JOIN NOW</a> </b></li>
        </div>
    </ul>
    <!-- End Contact Info -->
</div>--%><%--
<div class="modal fade " id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
    aria-hidden="true">
    <div class="modal-dialog" style="width: 350px!important;">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title" id="myModalLabel">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <i class="fa fa-user"></i>&nbsp;SIGN IN USER</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
                            DestinationPageUrl="~/Security.ashx">
                            <LayoutTemplate>
                                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                                    ValidationGroup="LoginUserValidationGroup" />
                                <div class="form-group">
                                    <asp:TextBox ID="UserName" runat="server" Width="" CssClass="form-control" placeholder="E-mail"
                                        autofocus></asp:TextBox>
                                </div>
                                <div class="form-group">
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="Password" runat="server" Width="" CssClass="form-control" placeholder="Password"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group" style="background:#ee3733;padding:3px;">
                                    <asp:HyperLink ID="hlForgotPassword"  runat="server" NavigateUrl="~/fpass.aspx" ><b>Forgot Password!</b></asp:HyperLink>
                                </div>
                                <div class="form-group">
                                   <%-- <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Close</button>
                                    <asp:Button ID="LoginButton" runat="server" Width="" EnableTheming="true" CommandName="Login"
                                        Text="log in" ValidationGroup="LoginUserValidationGroup" CssClass="btn-system btn-medium" />
                                </div>
                                <p class="text-danger">
                                    <span>
                                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                    </span>
                                </p>
                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                </div>
            </div>
             <div class="modal-footer">


               
                <asp:Button ID="btnCreate" runat="server" Text="Create a group" />
                <asp:Label ID="lblMessage" Width="100%" CssClass="text-info" runat="server"></asp:Label>





            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>--%>
<asp:HiddenField ID="hfUserName" ClientIDMode="Static" runat="server" />
<asp:HiddenField ID="hfIsLogin" ClientIDMode="Static" runat="server" />
