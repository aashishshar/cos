<%@ Page Title="" Language="C#" MasterPageFile="~/UC/UserMain.master" AutoEventWireup="true"
    CodeFile="AllowCouponCode.aspx.cs" Inherits="UC_User_AllowCouponCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-lg-12 col-md-12 col-sm-12 sidebar left-sidebar">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
                <h4>
                    <b>RECHARGE / BILL PAYMENT</b><span class="head-line"></span></h4>
                <div class="row" >
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-1 col-md-1 col-sm-1 lbl-system lbl-white da-leftbox" style="padding:0px;width:70px;"  >
                            <asp:Image runat="server" Height="50px"  Width="92px" ImageAlign="AbsMiddle" ID="ImgOperator" />
                        </div>
                        <div class="col-lg-11 col-md-11 col-sm-11" style="margin-right:-25px;">
                          
                                <p style="margin-bottom: 10px; font-weight: bold; font-size: 16px;text-align:center;">
                                    <%--    <asp:Image ID="ImgOperator" Height="30px" ImageAlign="AbsMiddle" Width="30px" runat="server" />--%>
                                   <span style="border-bottom: 1px solid gray;"><asp:Label ID="llbmsg" runat="server"></asp:Label></span> </p>
                           
                        </div>
                       
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-10 col-md-10 col-sm-10">
                        </div>
                        <div class="col-lg-1 col-md-1 col-sm-1">
                            <p style="text-align: right; padding-right: 0px; margin-right: -10px;">
                                Amount :</p>
                        </div>
                        <div class="col-lg-1 col-md-1 col-sm-1" style="margin-right: -25px; padding-right: 0px;
                            border-bottom: 1px dotted gray;">
                            <p style="text-align: center; padding-right: 0px; margin-right: -10px;">
                                <asp:Literal ID="litAmount" runat="server"></asp:Literal></p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-xs-6">
                    <div class="col-lg-9 col-md-9 col-sm-9">
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3" style="margin-right: -25px; padding-right: 0px;">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-8">
                                    <div class="row">
                                        <asp:TextBox ID="txtCouponCode" CssClass="form-control" MaxLength="10" placeholder="Have a coupon code?"
                                            ClientIDMode="Static" runat="server"></asp:TextBox></div>
                                </div>
                                <div class="col-sm-4" style="padding-right: 0px;">
                                    <asp:Button ID="btnCouponCode" CausesValidation="false" OnClientClick="ApplyCoupon();return false;"
                                        ClientIDMode="Static" runat="server" Text="Apply" Width="100%" />
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div id="subscribemsg" style="font-size: 10px;" class="text-success">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-xs-6">
                    <div class="col-lg-8 col-md-8 col-sm-8">
                    </div>
                    <div class="checkbox checkboxlist col-lg-4 col-md-4 col-sm-4" style="margin-right: -25px;
                        margin-left: 20px;"><p>
                        <asp:CheckBox ID="chkWallet" ClientIDMode="Static" Text="Use COS wallet" runat="server" /></p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-xs-6">
                    <div class="col-lg-8 col-md-8 col-sm-8">
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4" style="padding-right: 0px;">
                        <asp:Button ID="btnPayment" Width="100%" CausesValidation="false" ClientIDMode="Static"
                            runat="server" Text="Proceed to Pay Amount" OnClick="btnPayment_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="hdnMobile" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnOperatorCode" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnOperatorName" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnRechargeAmount" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnRechargeType" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnProductInfo" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnWalletAmount" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnOrderID" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hdnUserID" ClientIDMode="Static" runat="server" />
    <input type="hidden" runat="server" id="key" name="key" />
    <input type="hidden" runat="server" id="hash" name="hash" />
    <input type="hidden" runat="server" id="txnid" name="txnid" />
    <input type="hidden" runat="server" id="enforce_paymethod" name="enforce_paymethod" />
    <script type="text/javascript">

        function ApplyCoupon() {
            var _loginMsg = $('#subscribemsg');

            var param = { coupon: $('#txtCouponCode').val(), RechargeType: $('#hdnRechargeType').val(), UserID: $('#hdnUserID').val(), RechargeAmount: $('#hdnRechargeAmount').val() };

            $.ajax({
                url: '<%=ResolveUrl("~/CommonService.asmx/ApplyCouponCode") %>',
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    _loginMsg.addClass("text-danger").removeClass("text-success");
                    _loginMsg.html(data.d);

                    if (data.d.toLowerCase().indexOf("success") >= 0) {
                        if ($('#btnCouponCode').val() == "Remove") {
                            $('#btnCouponCode').val("Apply");
                            $('#txtCouponCode').val("");
                            _loginMsg.html('');
                        }
                        else {
                            $('#btnCouponCode').val("Remove");
                        }
                        return true;
                    }
                    else {
                        $('#txtCouponCode').val("");
                    }

                },
                Error: function (textMsg) {

                }
            });
        }





    </script>
</asp:Content>
