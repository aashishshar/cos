<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Coupon.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Coupon" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<%@ Register Src="uc_DeepLinkUrl.ascx" TagName="uc_DeepLinkUrl" TagPrefix="uc2" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("[id$=txtValidTill]").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+0"
        });

    });
</script>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Coupon's
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
                    </div>
                    <div class="col-lg-2">
                        <uc2:uc_DeepLinkUrl ID="uc_DeepLinkUrlDDL" runat="server" />
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlLinkFor" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtCoupon" MaxLength="100" placeholder="Coupon Code" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtNavigationURL" MaxLength="300" placeholder="Navigation URL" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtValidTill" placeholder="Valid Till" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlDevice" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtCouponDescription" MaxLength="500" Rows="3" placeholder="Coupon Description"
                            TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button runat="server" Text="Add" ID="btnMerchantNameAdd" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnMerchantNameAdd_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:FileUpload ID="fuUpload" runat="server" /><br /><asp:Button runat="server" Text="Import Excel"
                            ID="btnExcel" EnableTheming="false" CssClass="btn btn-outline btn-primary" ValidationGroup="cat"
                            OnClick="btnExcel_Click" /></div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="gvItems"  DataKeyNames="CID" runat="server" AutoGenerateColumns="False"
                        Width="100%" ClientIDMode="Static" onrowdatabound="gvItems_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MerchantName" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Coupon" HeaderText="Coupon">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%--    <asp:BoundField DataField="CouponForDevice" HeaderText="Device">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblOffer" runat="server" ToolTip='<%#Eval("Offer") %>'><%#ReduceString(Eval("Offer").ToString())%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:BoundField DataField="Offer" HeaderText="Description">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                               <asp:BoundField DataField="ValidTill" HeaderText="Valid Till">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <%--<asp:BoundField DataField="NavigationURL" HeaderText="Navigation URL">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Valid Till">
                                <ItemTemplate>
                                <asp:Label ID="lblValiDate" Text='<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <%#DateTimeAgo.GetFormatDate(Eval("CreatedDate").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
