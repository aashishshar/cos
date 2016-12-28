<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LoginCtrl.ascx.cs"
    Inherits="UC_MasterHeader_uc_LoginCtrl" %>
<div class="fl sign_left">
    <%--<h2>NEW USERS, REGISTER NOW</h2>--%>
    <a rel="nofollow" href="#" class="button">JOIN US TO GET EXTRA CASHBACK</a>
    <ul class="clearfix">
        <li class="pos"><strong>Extra cashback when you shop by us</strong></li>
        <li class="pos"><strong>Fast cashback paid</strong></li>
        <%--<li class="pos"><strong>OVER 10 LAKH HAPPY MEMBERS</strong></li>
        <li class="pos"><strong>500+ PARTNER SITES</strong></li>--%>
    </ul>
</div>
<div class="sign_right">
    <%--<h3>LOGIN</h3>--%>
    <a class="fbbutton" data-text="OR" href="javascript:void(0);">Login With Facebook <i
        class="fa fa-facebook" style="font-size: 18px; margin-left: 5px;"></i></a>
    <asp:TextBox ID="UserName" CssClass="form-control" runat="server" TabIndex="0" ClientIDMode="Static"
        EnableTheming="false" required="" oninvalid="this.setCustomValidity('Please Enter User ID.')"
        placeholder="E-mail" autofocus></asp:TextBox>
    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TabIndex="1" ClientIDMode="Static"
        EnableTheming="false" placeholder="Password" TextMode="Password"></asp:TextBox>
    <asp:HyperLink ID="hlForgotPassword" EnableTheming="false" CssClass="fl link" runat="server"
        NavigateUrl="~/fpass.aspx"><b>Forgot Password?</b></asp:HyperLink>
    <div class="fw fl">
        <span class="fl">
            <input type="checkbox" value="1" tabindex="3" name="rem_user" id="rem_user">Keep
            me signed in</span>
        <asp:Button ID="btnMainLoginUserwindow" CssClass="pull-right btn login-btn" TabIndex="2"
            runat="server" EnableTheming="false" CommandName="Login" Text="Sign in" />
    </div>
    <span class="text-success">
        <%--<asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
        <div id="msg">
        </div>
    </span>
    <div class="hr5 clearfix">
    </div>
    <div class="fa-align-center alignCenter">
        <strong>Don't have an account yet? <a href="javascript:void(0);" data-dismiss="modal"
            data-toggle="modal" data-target="#regModal"><b>Register now</b></a> </strong>
    </div>
</div>
