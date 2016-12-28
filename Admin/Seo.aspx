<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Seo.aspx.cs" Inherits="Admin_Seo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h2 class="page-header">
                Break-down<small>&nbsp;Add & Update</small>
            </h2>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True"
                DataKeyNames="MID" DataSourceID="EntityDataSource1">
                <Columns>
                    <asp:BoundField DataField="MerchantNameDetail" HeaderText="Name" ReadOnly="True"
                        SortExpression="MID" Visible="true" />
                    <asp:TemplateField HeaderText="Seo_Title" SortExpression="Seo_Title">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Seo_Title") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" Rows="4" runat="server" Text='<%# Bind("Seo_Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seo_Description" SortExpression="Seo_Description">
                        <ItemTemplate>
                            <asp:Label ID="Label2" TextMode="MultiLine" Rows="4" runat="server" Text='<%# Bind("Seo_Description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="4" Text='<%# Bind("Seo_Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seo_Keyword" SortExpression="Seo_Keyword">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Seo_Keyword") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Rows="4" Text='<%# Bind("Seo_Keyword") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LogoURL">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("LogoUrl") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" Width="250px" TextMode="MultiLine" Rows="4" runat="server"
                                Text='<%# Bind("LogoUrl") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="TrackingURL" SortExpression="TrackingURL">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server"  Text='<%# Bind("TrackingURL") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" Width="250px" TextMode="MultiLine" Rows="4" runat="server" Text='<%# Bind("TrackingURL") %>'></asp:TextBox>
                        </EditItemTemplate>
                       
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=Ad_ConnectionString"
                DefaultContainerName="Ad_ConnectionString" EnableFlattening="False" EnableInsert="True"
                EnableUpdate="True" EntitySetName="Adv_Mst_Merchants">
            </asp:EntityDataSource>
        </div>
    </div>
</asp:Content>
