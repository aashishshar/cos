<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Brand.ascx.cs" Inherits="Admin_UC_uc_Brand" %>
<%@ Register Src="~/UC/UCUI/Master/Category/UC_Category.ascx" TagName="UC_Category"
    TagPrefix="uc1" %>
<div class="col-lg-12">
    <div class="row">
        <div class="col-lg-3">
            <uc1:UC_Category ID="UC_CategoryList" runat="server" />
        </div>
        <div class="col-lg-3">
            <asp:TextBox ID="txtBrandName" placeholder="Brand Name" runat="server"></asp:TextBox></div>
        <div class="col-lg-6">
            <asp:Button ID="btnRefresh" runat="server" Text="Get" 
                onclick="btnRefresh_Click" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnActive" runat="server" Text="Active" OnClick="btnActive_Click" />
            <asp:Button ID="btnDeactive" runat="server" Text="De-Active" OnClick="btnDeactive_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="update All" OnClick="btnUpdate_Click" />
            <asp:ImageButton ID="imgDelete" ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px"
                runat="server" OnClick="imgDelete_Click" />
        </div>
    </div>
    <br />
</div>
<div class="col-lg-12">
    <asp:GridView ID="gvItems" runat="server" Font-Names="Verdana" AutoGenerateColumns="false"
        Font-Size="10px" DataKeyNames="BrandID">
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
            <asp:BoundField DataField="BrandName" HeaderText="BrandName">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Min">
                <ItemTemplate>
                    <asp:TextBox runat="server" Width="70px" ID="txtMinPrice" Text='<%#Eval("MinPrice") %>'>
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Max">
                <ItemTemplate>
                    <asp:TextBox runat="server" Width="70px" ID="txtMaxPrice" Text='<%#Eval("MaxPrice") %>'>
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Range">
                <ItemTemplate>
                    <asp:TextBox runat="server" Width="70px" ID="txtRangePrice" Text='<%#Eval("RangePrice") %>'>
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="isrun" HeaderText="Run App">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</div>
