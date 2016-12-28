<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_CategoryEntry.ascx.cs"
    Inherits="UC_UCUI_Master_Category_UC_CategoryEntry" %>
<%@ Register Src="UC_Category.ascx" TagName="UC_Category" TagPrefix="uc1" %>
<div class="panel panel-default">
    <div class="panel-heading">
        Category
    </div>
    <div class="panel-body">
        <div class="form-group">
            <div class="alert alert-info">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <uc1:UC_Category ID="UC_CategoryList" runat="server" />
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <asp:TextBox ID="txtCategoryName" placeholder="Category name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <%--<div class="col-lg-3">
                        <div class="form-group">
                            <asp:TextBox ID="txtMasterCategoryName"  placeholder="Master Category" runat="server"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Button runat="server" Text="add category.." ID="btnCategoryAdd" EnableTheming="false"
                                CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnCategoryAdd_Click" />
                            <asp:Button runat="server" Text="Update Items" ID="btnUpdatecategoryItems" EnableTheming="false"
                                CssClass="btn btn-outline btn-primary" OnClick="btnUpdatecategoryItems_Click" /><asp:Label
                                    CssClass="text-info" ID="lblMessage" runat="server"></asp:Label></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:GridView ID="gvLiveItems" CssClass="display" ClientIDMode="Static" runat="server">
                        <Columns>
                            <%-- <asp:TemplateField HeaderText="Map" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbMap" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Category" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <uc1:UC_Category ID="UC_CategoryLink" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton runat="server" Visible="false" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <asp:GridView ID="gvItems" ClientIDMode="Static" DataKeyNames="CategoryID_N" runat="server" AutoGenerateColumns="False"
                        Width="100%" OnRowCommand="gvItems_RowCommand">
                        <Columns>
                           <%-- <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="CategoryID_N" HeaderText="ID">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ParentCategoryID_N" HeaderText="PID">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%-- <asp:BoundField DataField="MCategoryName_V" HeaderText="Master Category">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="CategoryName_V" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status_N" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedDate" HeaderText="Create date">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" CommandName="delCal" CommandArgument='<%#Eval("CategoryID_N") %>'
                                        ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
