<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OMG_Excel_Product_Feed.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_OMG_Excel_Product_Feed" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<div class="alert alert-info">
    <div class="form-group">
        <div class="row">
            <div class="col-lg-3">
                <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
            </div>
            <div class="col-lg-3">
                <asp:FileUpload ID="fuUpload" runat="server" />
            </div>
            <div class="col-lg-6">
                <asp:Button runat="server" Text="Upload" ID="btnUploadFile" ValidationGroup="cat"
                    OnClick="btnUploadFile_Click" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="form-group">
        <div class="col-lg-12">
            <%-- <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>--%>
            <br />
            <br />
            <div class="table-responsive">
                <asp:GridView ID="gvItems" CssClass="display table" EnableTheming="true" ClientIDMode="Static"
                     runat="server" AutoGenerateColumns="False" Width="100%">
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
                                <%--<asp:Image Height="30px" Width="80px" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=92&height=30&imgPath="+Eval("MerchantLogoURL") %>'
                                    runat="server" ID="Image1" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:BoundField DataField="MerchantLogoURL" SortExpression="MerchantLogoURL" />--%>
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
                        <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                        <asp:BoundField DataField="DiscountedPrice" HeaderText="Dis. Price" SortExpression="DiscountedPrice" />
                        <asp:BoundField DataField="ProductPrice" HeaderText="Price" />
                        <asp:BoundField DataField="Custom3" HeaderText="%" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
