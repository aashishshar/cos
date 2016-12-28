<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Offer.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Offer" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<%@ Register Src="uc_DeepLinkUrl.ascx" TagName="uc_DeepLinkUrl" TagPrefix="uc2" %>
<%@ Register Src="../SmallWindow/uc_CommisionProgramDDL.ascx" TagName="uc_CommisionProgramDDL"
    TagPrefix="uc3" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("[id$=txtValiDate]").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+0"
        });
        $("[id$=txtStartDate]").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+0"
        });
    });
</script>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Offer's
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
                        <asp:DropDownList ID="ddlLinkFor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkFor_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <uc3:uc_CommisionProgramDDL ID="uc_CommisionProgramDDLList" runat="server" />
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtStartDate" placeholder="Start Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtValiDate" placeholder="Valid Till" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtOffer" placeholder="Offer Title" runat="server" 
                            ></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtNavigationUrl" placeholder="Navigation URL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtCouponCode" placeholder="Coupon Code" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtOfferDescription" Rows="3" placeholder="Offer Description" TextMode="MultiLine"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlDevice" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlOfferType" runat="server">
                        </asp:DropDownList>
                    </div>

                    
                </div>
            </div>
            <div class="form-group">
                <div class="row"><div class="col-lg-1">
                        <asp:Button runat="server" Text="add Offer" ID="btnMerchantNameAdd" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnMerchantNameAdd_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-lg-8">
                      
                        <asp:Button runat="server" Text="Upload" ID="btnUploadFile" ValidationGroup="cat"
                            OnClick="btnUploadFile_Click" />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:Button runat="server" Text="refresh" ID="btnRefresh" EnableTheming="false" CssClass="btn btn-outline btn-primary"
                            ValidationGroup="cat" OnClick="btnRefresh_Click" />
                        <asp:Button runat="server" Text="Get Live offer Update" ID="btnSubmitOffer" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnSubmitOffer_Click" />
                        <asp:Button runat="server" Text="Import Excel" ID="btnExcel" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnExcel_Click" />
                    </div>
                    <div class="col-lg-1"> <asp:FileUpload ID="fuUpload" runat="server" />
                        <asp:RadioButton ID="rbListUrl" Text="From Url" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gvXMLDate" runat="server" PageSize="500" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="VoucherCodeId" HeaderText="Code">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Name">
                                <HeaderTemplate>
                                    <asp:DropDownList ID="ddlHeader" OnSelectedIndexChanged="ddlHeader_SelectedIndexChanged"
                                        AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMname" Text='<%#Eval("Merchant") %>' runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="Merchant" HeaderText="Merchant">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="Code" HeaderText="Code">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Title" HeaderText="Title">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Description">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ActivationDate" HeaderText="ActivationDate">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ExpiryDate" HeaderText="ExpiryDate">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TrackingUrl" HeaderText="TrackingUrl">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="gvItems" ClientIDMode="Static" runat="server" DataKeyNames="OfferId"
                        AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvItems_RowDataBound">
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
                            <asp:BoundField DataField="Title" HeaderText="Offer">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%--    <asp:BoundField DataField="CouponForDevice" HeaderText="Device">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblOffer" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Description")!=null?ReduceString(Eval("Description").ToString()):""%></asp:Label>
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
                                    <asp:Label ID="lblValiDate" Text='<%#Eval("ValidTill")!=null?DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString()):"UNTILL"%>'
                                        runat="server"></asp:Label>
                                    <%--<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <%#DateTimeAgo.GetFormatDate(Eval("CreatedDate").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" CommandName="delMerchant" CommandArgument='<%#Eval("MerchantName") %>'
                                        ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
