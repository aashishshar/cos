<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Registration.ascx.cs"
    Inherits="UC_UCUI_Account_Registration" %>
<script type="text/javascript">
    function checkAgreement(source, args) {
        var elem = document.getElementById('<%= chkTermAndCondition.ClientID %>');
        if (elem.checked) {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
        
</script>
<script type="text/javascript">

    function validateEmail(sEmail) {
        var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        if (filter.test(sEmail)) {
            return true;
        }
        else {
            alert('Invalid Email');
        }
    }


    function ValidateRecord() {

        var _loginMsg = $('#regmsg');
        var param = { Name: $('#txtFullName').val(), Email: $('#txtEmailUserName').val(), Mobile: $('#txtMobile').val(), Password: $('#txtPassword').val(), ConfirmPassword: $('#txtConfirmPassword').val(), Terms: $('#chkTermAndCondition').is(':checked') };
        $.ajax({
            url: '<%=ResolveUrl("~/CommonService.asmx/RegisterValidation") %>',
            data: JSON.stringify(param),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                _loginMsg.addClass("text-danger").removeClass("text-success");
                _loginMsg.html(data.d);
                return;

            },
            Error: function (textMsg) {

            }
        });
    }
</script>
<span class="text-success">
    <div id="regmsg">
    </div>
</span>
<div class="row">
    <div class="col-lg-12">
        <asp:TextBox ID="txtFullName" ClientIDMode="Static" runat="server" CssClass="form-control"
            placeholder="Full name" autofocus></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <asp:TextBox ID="txtEmailUserName" ClientIDMode="Static" runat="server" CssClass="form-control"
            placeholder="User name/Email-id"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <asp:TextBox ID="txtMobile" ClientIDMode="Static" runat="server" MaxLength="10" CssClass="form-control"
            placeholder="Mobile No."></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <asp:TextBox ID="txtPassword" ClientIDMode="Static" runat="server" TextMode="Password"
            CssClass="form-control" placeholder="password"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <asp:TextBox ID="txtConfirmPassword" ClientIDMode="Static" runat="server" TextMode="Password"
            CssClass="form-control" placeholder="confirm password"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <asp:CheckBox ID="chkTermAndCondition" runat="server" ClientIDMode="Static" Text="&nbsp;I agree to the" />
        <asp:HyperLink ID="HyperLink1" Target="_blank" ForeColor="Blue" Text="Terms & Conditions"
            NavigateUrl="~/TermsAndCondition.aspx" runat="server"></asp:HyperLink>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <span style="color: Red">
            <asp:CustomValidator runat="server" ID="CustomValidator1" ErrorMessage="Please accept Terms 
& Conditions." EnableClientScript="true" Display="None" ClientValidationFunction="checkAgreement"></asp:CustomValidator></span>
    </div>
</div>
<div class="row">
    <div class="col-lg-12">
        <asp:Button ID="bnRegistration" runat="server" ClientIDMode="Static" Width="100%"
            EnableTheming="false" Text="register" OnClientClick="ValidateRecord();" CssClass="btn-system
btn-medium" OnClick="bnRegistration_Click" />
        <asp:Label ID="lblMessage" CssClass="text-info" runat="server"></asp:Label>
    </div>
</div>
