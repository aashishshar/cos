<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Subscribebox.ascx.cs"
    Inherits="UC_UCUI_Product_uc_Subscribebox" %>
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


    function SaveRecord() {

        //var Email = $.trim($('#<%=txtSubscribe.ClientID %>').val());
        var _loginMsg = $('#subscribemsg');
        var param = { Email: $('#txtSubscribe').val() };

        if (param.Email == '') {
            _loginMsg.addClass("text-danger").removeClass("text-success");
            _loginMsg.html("Subscribe Email should not be empty");
            //alert(param.Email);
        }

        else {
            //validateEmail(param.Email);
            var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            if (filter.test(param.Email)) {
                $.ajax({
                    url: '<%=ResolveUrl("~/CommonService.asmx/SubscribeEmail") %>',
                    data: JSON.stringify(param),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $('#txtSubscribe').val("");
                        _loginMsg.addClass("text-danger").removeClass("text-success");
                        _loginMsg.html("Subscribed successfully");

                        if (data.d == true) {


                        }
                        else {

                        }

                    },
                    Error: function (textMsg) {

                        // $('#Result').text("Error: " + Error);
                    }
                });

            }
            else {
                _loginMsg.addClass("text-danger").removeClass("text-success");
                _loginMsg.html("Invalid Email ID");
            }
        }
       
    } 

</script>
<div class="row">
    <div class="container">
        <div class="subscribebox">
            <div class="col-sm-6">
                <div class="pos">
                    <div class="hd_subscr clearfix">
                        Sign-up for Free Coupons &amp; Offers</div>
                    <p>
                        Enter your Email ID. We promise to keep it to ourselves!</p>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="formsubscribebox">
                    <asp:TextBox ID="txtSubscribe" ClientIDMode="Static" placeholder="mail@example.com" runat="server"></asp:TextBox>
                    <input type="submit" onclick="SaveRecord(); return false;" class="main-button" value="Send">
                     <span class="text-success">
                                      <div id="subscribemsg"></div>
                                </span>
                </div>
            </div>
        </div>
       
       
    </div>
</div>
