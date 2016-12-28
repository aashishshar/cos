<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="KeyAPI.aspx.cs" Inherits="Admin_KeyAPI" %>

<%@ Register Src="~/UC/UCUI/Master/Category/UC_Category.ascx" TagName="UC_Category"
    TagPrefix="uc1" %>
<%@ Register Src="UC/uc_Brand.ascx" TagName="uc_Brand" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:DropDownList ID="ddlCategory" Visible="false" DataTextField="ResourceName" DataValueField="Get"
        runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnItems" Visible="false" runat="server" Text="Category Flipkart"
        OnClick="btnItems_Click" />
    <asp:Button ID="btnUpdateItemInDatabase" Visible="false" runat="server" Text="Update Item IN DB"
        OnClick="btnUpdateItemInDatabase_Click" />
    <br />
    <div class="row">
        <div class="col-lg-6">
            <uc1:uc_Brand ID="uc_Brand1" runat="server" />
        </div>
        <div class="col-lg-6">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-3">
                        <uc1:UC_Category ID="UC_CategoryList" runat="server" />
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtCategory" placeholder="Category" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtMerchant" placeholder="Merchant" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    </div>
                </div>
                <br />
            </div>
            <div class="col-lg-12">
                <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="false" Font-Names="Verdana"
                    Font-Size="10px" DataKeyNames="ItemID">
                    <HeaderStyle Font-Names="Verdana" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CategoryID_N" HeaderText="CategoryID_N">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CategoryName_V" HeaderText="CategoryName_V">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="merchantname" HeaderText="merchantname">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" CommandName="delCal" CommandArgument='<%#Eval("ItemID") %>'
                                        ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
