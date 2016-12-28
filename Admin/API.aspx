<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="API.aspx.cs" Inherits="Admin_API" %>

<%@ Register Src="../UC/UCUI/Master/Merchant/uc_MerchantList.ascx" TagName="uc_MerchantList"
    TagPrefix="uc1" %>
<%@ Register Src="~/UC/UCUI/Master/Category/UC_Category.ascx" TagName="UC_Category"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h2 class="page-header">
                API's<small>&nbsp;Add & Run API</small>
            </h2>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-2">
                <div class="form-group">
                    <uc1:uc_MerchantList ID="uc_MerchantListItem" runat="server" />
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <asp:DropDownList ID="rdbApiTypeURL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdbApiTypeURL_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <asp:DropDownList ID="ddlCategory" DataTextField="ResourceName" DataValueField="Get"
                        runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <uc1:UC_Category ID="UC_CategoryList" runat="server" />
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:Button runat="server" ID="btnRunAPI" Text="Run api" OnClick="btnRunAPI_Click" />
                    <asp:Button ID="btnNextProduct" runat="server" Enabled="false" Text="Next Product List"
                        OnClick="btnNextProduct_Click" />
                    <%--  <asp:Button runat="server" ID="Button1" Text="Upload XML" OnClick="btnRunAPI_Click" />--%>
                    <asp:Label ID="lblmsg" runat="server" CssClass="strMsg"></asp:Label>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="form-group">
                    <asp:GridView ID="gvProductList" runat="server" Font-Names="Verdana" Font-Size="Small"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <img src='<%# DataBinder.Eval(Container.DataItem, "ImageUrl")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="title">
                                <ItemTemplate>
                                    <a href='<%# DataBinder.Eval(Container.DataItem, "NavigationURL")%>' target="_blank">
                                        <%# DataBinder.Eval(Container.DataItem, "Title")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="producturl">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "producturl")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="MRP">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "ProductPrice")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "DiscountedPrice")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Cod">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "CodAvailable")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="color">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "color")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="stock">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Availability")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="SKU ID">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "SKUID")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
