<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="TrackingLink.aspx.cs" Inherits="Admin_TrackingLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h2 class="page-header">
                Update Merchant
            </h2>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="row">
            Note : - Optimise=1, Payoom=2, Self=3, Other=4
            <asp:GridView ID="gvTracking" runat="server" AutoGenerateColumns="False" DataKeyNames="MID"
                DataSourceID="EntityDataSource1">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <%--<asp:BoundField DataField="MID" HeaderText="MID" ReadOnly="True" 
                        SortExpression="MID" />--%>
                    <asp:BoundField DataField="AffiliateID" HeaderText="AffiliateID" SortExpression="AffiliateID" />
                    <%-- <asp:BoundField DataField="MerchantName" HeaderText="MerchantName" 
                        SortExpression="MerchantName" />--%>
                    <asp:TemplateField HeaderText="Aff. From">
                        <ItemTemplate>
                            <asp:Label ID="LabelMerchantLinkType" runat="server" Text='<%#Eval("MerchantLinkType")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMerchantLinkType" runat="server" Text='<%# Bind("MerchantLinkType") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MerchantNameDetail" HeaderText="Name" SortExpression="MerchantNameDetail" />
                    <asp:TemplateField HeaderText="MerchantDetails" SortExpression="MerchantDetails">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("MerchantDetails")!=null?Eval("MerchantDetails").ToString().Truncate(50):"--" %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Text='<%# Bind("MerchantDetails") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OMGMID" HeaderText="OMGMID" SortExpression="OMGMID" />
                    <asp:BoundField DataField="TrackingURL" HeaderText="TrackingURL" SortExpression="TrackingURL" />
                    <%--<asp:BoundField DataField="MerchantLinkType" HeaderText="MerchantLinkType" 
                        SortExpression="MerchantLinkType" />--%>
                    <asp:BoundField DataField="MerchantNameDescription" HeaderText="MerchantNameDescription"
                        SortExpression="MerchantNameDescription" />
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=Ad_ConnectionString"
                DefaultContainerName="Ad_ConnectionString" EnableFlattening="False" EnableUpdate="True"
                EntitySetName="Adv_Mst_Merchants" EntityTypeFilter="Adv_Mst_Merchant">
            </asp:EntityDataSource>
        </div>
    </div>
</asp:Content>
