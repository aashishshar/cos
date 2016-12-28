<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MissingCashback.ascx.cs"
    Inherits="UC_UCUI_User_uc_MissingCashback" %>
<%@ Register Src="../Master/Merchant/uc_MerchantList.ascx" TagName="uc_MerchantList"
    TagPrefix="uc1" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("[id$=txtTransactionDate]").datepicker({
            changeMonth: true,
            changeYear: false,
            yearRange: "-100:+0"
        });

    });
</script>
<div class="row">
    <div class="col-md-12">
        <h5 class="classic-title">
            <span><b>Raise Ticket</b></span>
        </h5>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <uc1:uc_MerchantList ID="uc_MerchantNameList" runat="server" />
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <asp:TextBox ID="txtTransactionDate" runat="server" CssClass="form-control" placeholder="Transaction Date" ValidationGroup="missingVgroupDDL"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1" style="margin-left: 0px; padding-left: 0px;">
                <div class="form-group">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="missingVgroupDDL"
                        ControlToValidate="txtTransactionDate" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <asp:TextBox ID="txtAmount" runat="server" MaxLength="6" CssClass="form-control" ValidationGroup="missingVgroupDDL"
                        placeholder="Transaction Amount*"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1" style="margin-left: 0px; padding-left: 0px;">
                <div class="form-group">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="missingVgroupDDL"
                        ControlToValidate="txtAmount" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <asp:TextBox ID="txtOrderID" runat="server" CssClass="form-control" MaxLength="20" ValidationGroup="missingVgroupDDL"
                        placeholder="Order ID*"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1" style="margin-left: 0px; padding-left: 0px;">
                <div class="form-group">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="missingVgroupDDL"
                        ControlToValidate="txtOrderID" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <asp:TextBox ID="txtCouponCode" runat="server" CssClass="form-control" MaxLength="10" ValidationGroup="missingVgroupDDL"
                        placeholder="Coupon Code"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1" style="margin-left: 0px; padding-left: 0px;">
                <div class="form-group">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="missingVgroupDDL"
                        ControlToValidate="txtCouponCode" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:FileUpload ID="fuFileUpload" placeholder="Add file" runat="server" />(eg:".gif",
                    ".png", ".jpeg", ".jpg")
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <asp:TextBox ID="txtContactNo" MaxLength="12" runat="server" CssClass="form-control"
                        placeholder="Contact No.*" ValidationGroup="missingVgroupDDL"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1" style="margin-left: 0px; padding-left: 0px;">
                <div class="form-group">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="missingVgroupDDL"
                        ControlToValidate="txtContactNo" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:TextBox ID="txtOrderDetail" MaxLength="240" CssClass="form-control" TextMode="MultiLine"
                        runat="server" placeholder="Order Details" ValidationGroup="missingVgroupDDL"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="form-group">
            <asp:Button ID="btnTicket" Width="20%" runat="server" EnableTheming="false" ValidationGroup="missingVgroupDDL"
                Text="Add Ticket" CssClass="btn-system btn-medium" OnClick="btnTicket_Click" />
        </div>
    </div>
    <div class="col-md-12">
        <div class="form-group">
            <asp:Label ID="lblMessage" CssClass="text-info" runat="server"></asp:Label>
        </div>
    </div>
    <div class="col-md-12">
        <div class="table-responsive">
            <asp:GridView ID="gvItems" Width="100%" CssClass="table table-condensed" AutoGenerateColumns="false"
                runat="server" GridLines="None" EmptyDataRowStyle-BackColor="#FF3300"
                EmptyDataRowStyle-BorderStyle="Dotted" EmptyDataRowStyle-BorderWidth="1" EmptyDataRowStyle-ForeColor="White"
                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-VerticalAlign="Middle"
                EmptyDataRowStyle-Width="100%" EmptyDataText="Their is no transaction history.">
                <Columns>
                    <asp:TemplateField  ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=70&height=25&imgPath="+Eval("MerchantLogoUrl") %>'>
                            </asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Merchant" >
                        <ItemTemplate>
                            <%#Eval("TicketNo")%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Transaction Date">
                        <ItemTemplate>
                            <%#DateTimeAgo.GetFormatDate(Eval("TransactionDate").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order ID">
                        <ItemTemplate>
                            <%#Eval("OrderID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                           <i class="fa fa-inr"></i>&nbsp;<%#Eval("AmountPaid")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Submited On">
                        <ItemTemplate>
                            <%#DateTimeAgo.GetFormatDate(Eval("CreatedDate").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <%#Eval("Status")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
