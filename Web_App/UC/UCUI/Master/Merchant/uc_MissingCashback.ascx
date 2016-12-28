<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MissingCashback.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_MissingCashback" %>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Missing Cashback
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtToEmail" placeholder="Email ID" Text="sahil.singhani@optimisemedia.com"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <asp:TextBox ID="txtNote" placeholder="Any Note" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:LinkButton runat="server" ID="lkbDelete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lkbSendmail" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="lkbSendmail_Click"><i class="fa fa-refresh"></i>&nbsp;Send Mail</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lkbResolve" EnableTheming="false" 
                        CssClass="btn btn-danger" onclick="lkbResolve_Click"><i class="fa fa-envelope-o"></i>&nbsp;Resolve Issue</asp:LinkButton>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="gvItems" runat="server" ClientIDMode="Static" DataKeyNames="TicketNo"
                        AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <%#Eval("MerchantName")%>
                                   <%-- <asp:Image ID="imgMerchant" ImageUrl='<%#Eval("MerchantLogoUrl") %>' Height="35px"
                                        Width="100px" runat="server" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="User">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="TransactionDate">
                                <ItemTemplate>
                                    <%#DateTimeAgo.GetFormatDate(Eval("TransactionDate").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="OrderID" HeaderText="Order ID">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactNo" HeaderText="Contact No">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MailSend" HeaderText="MailSend">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <%#DateTimeAgo.GetFormatDate(Eval("CreatedDate").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="imgMerchant" ImageUrl='<%#Eval("FileUrl") %>' Height="35px" Width="100px"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Commision">
                                <ItemTemplate>
                                    <%#Eval("BannerURL")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CurrencyName" HeaderText="Currency">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
