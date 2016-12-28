<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="FeatureOffers.aspx.cs" Inherits="Admin_FeatureOffers" %>

<%@ Register Src="~/UC/UCUI/Master/Merchant/uc_MerchantList.ascx" TagName="uc_MerchantList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h2 class="page-header">
                Feature Offers
            </h2>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="row">
                <div class="col-lg-3">
                    <uc1:uc_MerchantList ID="uc_MerchantListItem" runat="server" />
                </div>
                <div class="col-lg-3">
                    <asp:Button ID="btnGetOffers" runat="server" Text="Get Offers" OnClick="btnGetOffers_Click" />
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-2">
            <asp:LinkButton runat="server" ID="lkbFeatureOffer" EnableTheming="false" CssClass="btn  btn-danger"
                OnClick="lkbFeatureOffer_Click">&nbsp;Mark as Feature offer</asp:LinkButton></div>
        <div class="col-lg-2">
            <asp:DropDownList ID="ddlOfferType" runat="server" Width="150px">
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn btn-danger"
                OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete Feature Offer</asp:LinkButton></div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView ID="gvItems" ClientIDMode="Static" runat="server" DataKeyNames="OfferId"
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
                            <%# DataBinder.Eval(Container.DataItem, "Adv_Mst_Merchant.MerchantNameDetail")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="MerchantName" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                    <asp:BoundField DataField="Title" HeaderText="Offer">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <%--    <asp:BoundField DataField="CouponForDevice" HeaderText="Device">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblOffer" runat="server" ToolTip='<%#Eval("Description") %>'><%#Eval("Description")%></asp:Label>
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
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Valid Till">
                                <ItemTemplate>
                                    <asp:Label ID="lblValiDate" Text='<%#Eval("ValidTill")!=null?DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString()):"UNTILL"%>'
                                        runat="server"></asp:Label>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <%#DateTimeAgo.GetFormatDate(Eval("CreatedDate").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
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
</asp:Content>
