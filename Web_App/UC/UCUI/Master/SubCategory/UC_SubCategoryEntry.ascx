<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_SubCategoryEntry.ascx.cs"
    Inherits="UC_UCUI_Master_SubCategory_UC_SubCategoryEntry" %>
<%@ Register Src="../Category/UC_Category.ascx" TagName="UC_Category" TagPrefix="uc1" %>
<div class="panel panel-default">
    <div class="panel-heading">
        <b>Sub-Category</b>
    </div>
    <div class="panel-body">
        <div class="form-group">
            <div class="alert alert-info">
                <div class="row">
                    <div class="col-lg-2">
                        <uc1:UC_Category ID="UC_Category_List" runat="server" />
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtSubCategory" placeholder="Sub-Category name" runat="server" ValidationGroup="scat"></asp:TextBox>
                        <asp:Label CssClass="text-info" ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-lg-3">
                        <asp:Button runat="server" Text="add Sub-category.." ID="btnSubmitSubcategory" ValidationGroup="scat"
                            EnableTheming="false" CssClass="btn btn-outline btn-primary" OnClick="btnSubmitSubcategory_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:GridView ID="gvSubCategories" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                Width="100%" PageSize="100" DataKeyNames="SubCategoryID_N" onrowcommand="gvSubCategories_RowCommand">
                <Columns>
                    <asp:BoundField DataField="SubCategoryName_V" HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <%#  Eval("CategoryName_V")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="CategoryName_V" HeaderText="Category">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                    <asp:BoundField DataField="Status_N" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Createddate" HeaderText="Created Date">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" CommandName="delSubCat" CommandArgument='<%#Eval("SubCategoryID_N") %>'
                                ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
