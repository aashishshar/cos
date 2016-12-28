<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_UserDashBoard.ascx.cs"
    Inherits="UC_UCUI_User_uc_UserDashBoard" %>
    <script type="text/javascript">
        $(function () {

            //GetCustomersTrasaction();

        });
        function GetCustomersTrasaction() {
            //     debugger;
            $.ajax({
                type: "POST",
                url: '<%=ResolveUrl("~/CommonService.asmx/GetCustomersTrasaction") %>',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            // debugger;
            //alert("ss"+response.d);
            var xmlDoc = response.d;
            //var xml = $(xmlDoc);
            //alert(xmlDoc);
            //var customers = xml.find("Customers");
            var row = $("[id*=gvItems] tr:last-child").clone(true);
            $("[id*=gvItems] tr").not($("[id*=gvItems] tr:first-child")).remove();
            $.each(xmlDoc, function () {
                alert("dddd");
                //  debugger;
                var customer = $(this);
                $("td", row).eq(0).html($(this).find("Status").text());
                // $("td", row).eq(1).html($(this).find("ContactName").text());
                // $("td", row).eq(2).html($(this).find("City").text());
                $("[id*=gvItems]").append(row);
                row = $("[id*=gvItems] tr:last-child").clone(true);
            });
        };
    
    
    </script>
<div class="row">
    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse-one"><i class="fa fa-angle-up control-icon">
                    </i><i class="fa fa-desktop"></i>Wallet</a>
                </h4>
            </div>
            <div id="collapse-one" class="panel-collapse collapse in">
                <div class="panel-body">
                    <asp:FormView ID="fvUserPaymentPanel" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-md-6" style="text-align: right;">
                                Total Paid Amount :</div>
                            <div class="col-md-6" style="text-align: left;">
                                <b>Rs.
                                    <%#Math.Round(Convert.ToSingle(Eval("RechargeAmount")), 2)%></b>
                            </div>
                            <div class="col-md-6" style="text-align: right;">
                                Payable Amount :</div>
                            <div class="col-md-6" style="text-align: left;">
                                <b>Rs.
                                    <%#Math.Round(Convert.ToSingle(Eval("TransferableAmount")), 2)%></b>
                            </div>
                            <div class="col-md-6" style="text-align: right;">
                                Confirm Amount :</div>
                            <div class="col-md-6" style="text-align: left;">
                                <b>Rs.
                                    <%#Math.Round(Convert.ToSingle(Eval("ValidatedAmount")), 2)%></b>
                            </div>
                            <div class="col-md-6" style="text-align: right;">
                                Cashback Pending :</div>
                            <div class="col-md-6" style="text-align: left;">
                                <b>Rs.
                                    <%#Math.Round(Convert.ToSingle(Eval("PendingAmount")), 2)%></b>
                            </div>
                            <div class="col-md-6" style="text-align: right;">
                                Rejected Amount :</div>
                            <div class="col-md-6" style="text-align: left;">
                                <b>Rs.
                                    <%#Math.Round(Convert.ToSingle(Eval("RejectedAmount")), 2)%></b>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:FormView>
                </div>
            </div>
        </div>
        <%--<div class="clearfix">&nbsp;</div>
         <i class="fa fa-download icon-mini-effect icon-effect-2  da-skyblue-btn">Rs.10000<br />Redeem Now</i>
        <div class="classic-testimonials">
        <div class="testimonial-content">
            <p>
               Wallet
               </p>
        </div>
    </div>--%>
    </div>
     <div class="col-md-2">
        <div class="classic-testimonials">
            <asp:Button ID="btnRedeem" CausesValidation="false" runat="server" Width="100%" 
                Font-Size="20px" Font-Bold="true" Height="80px" Text="Redeem" 
                onclick="btnRedeem_Click" Enabled="false" /> 
                <div id="divMessage" style="font-size:11px;" runat="server"></div>
        
        </div>
    </div>
    <div class="col-md-6">
        <div class="classic-testimonials">
            <div class="testimonial-content">
                T&C:<br />
                1. Add your bank account details to redeem amount.<br />
                2. Minimum confirm amount to redeem must be Rs.50/- (Wallet amount).<br />
                3. Bank account details should be correct.Once transfered Cashonshop will not be liable to any wrong information about your account.<br />
                4. Amount will be transfered within 3 working days after redeem request.<br />
                5. To redeem confirm amount using (Recharge/Bill Payment, Transfer to bank)
            </div>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="hr5" style="margin-top: 25px; margin-bottom: 15px;">
        </div>
        <h5 class="classic-title">
            <span><b>Transaction History</b></span>
        </h5>
        <div class="table-responsive">
            <asp:GridView ID="gvItems" ClientIDMode="Static" CssClass="table table-condensed"
                runat="server" DataKeyNames="" AutoGenerateColumns="False" Width="100%"
                GridLines="None" EmptyDataRowStyle-BackColor="#FF3300" EmptyDataRowStyle-BorderStyle="Dotted"
                EmptyDataRowStyle-BorderWidth="1" EmptyDataRowStyle-ForeColor="White" EmptyDataRowStyle-HorizontalAlign="Center"
                EmptyDataRowStyle-VerticalAlign="Middle" EmptyDataRowStyle-Width="100%" EmptyDataText="Their is no transaction history.">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="120px">
                        <ItemTemplate><%#Eval("MerchantName") %>
                           <%-- <asp:Image runat="server" ImageUrl='<%#Eval("MerchantName") %>'>
                            </asp:Image>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction On">
                        <ItemTemplate>
                            <%#DateTimeAgo.GetFormatDate(Eval("TransactionTime").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OMGMerchantRef" HeaderText="Order ID">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Commision">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <i class="fa fa-inr"></i>&nbsp;<%#Eval("FinalCommision")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Value">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <i class="fa fa-inr"></i>&nbsp;<%#Eval("TransactionValue")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Status" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
