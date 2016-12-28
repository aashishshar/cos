<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LiveProductFeedData.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_LiveProductFeedData" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<%@ Register Src="~/UC/UCUI/Master/Category/UC_Category.ascx" TagName="UC_Category" TagPrefix="uc1" %>
<div class="alert alert-info">
    <div class="form-group">
        <div class="row">
            <div class="col-lg-2">
                <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtSignData" placeholder="2015-05-12 07:07:50.483" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtKeyword" placeholder="Search Keyword" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txtMinPrice" placeholder="MIN" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                <asp:TextBox ID="txtMaxPrice" placeholder="MAX" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtProductSKU" placeholder="Product SKU" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtNoOfRecord" placeholder="Get Record" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-lg-2">
                <asp:RadioButtonList ID="rblDiscount" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Text="true" Value="true"></asp:ListItem>
                    <asp:ListItem Text="false" Selected="True" Value="false"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
             <div class="col-lg-2">
             <uc1:UC_Category ID="UC_CategoryList" runat="server" />
             
             </div>
            <div class="col-lg-2">
                <asp:Button runat="server" Text="Get Products" ID="btnGetProduct" EnableTheming="false"
                    CssClass="btn btn-outline btn-primary" OnClick="btnGetProduct_Click" /></div>
            <div class="col-lg-4">
                <asp:Button runat="server" Text="Do Live" ID="btnDoLive" EnableTheming="false" CssClass="btn btn-outline btn-primary"
                    OnClick="btnDoLive_Click" />
                <asp:Button runat="server" Text="Bulk Insert" ID="btnPushCollectionData" EnableTheming="false"
                    CssClass="btn btn-outline btn-primary" OnClick="btnPushCollectionData_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</div>
<div class="form-group">
    <asp:GridView ID="gvItems" ClientIDMode="Static" DataKeyNames="MID,MerchantDomain,PID,ProductSKU,ProductURL,WasPrice,ProductDescription"
        runat="server" AutoGenerateColumns="false">
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
                    <asp:Image Height="30px" Width="80px" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=92&height=30&imgPath="+Eval("MerchantLogoURL") %>'
                        runat="server" ID="Image1" />
                </ItemTemplate>
            </asp:TemplateField>
            <%-- <asp:BoundField DataField="MerchantLogoURL" SortExpression="MerchantLogoURL" />--%>
            <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
            <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
            <asp:BoundField DataField="DiscountedPrice" HeaderText="Dis. Price" SortExpression="DiscountedPrice" />
            <asp:BoundField DataField="ProductPrice" HeaderText="Price" />
            <asp:BoundField DataField="Custom3" HeaderText="%" />
            <%-- <asp:TemplateField>
                <ItemTemplate>
                  
                    <asp:Image Height="30px" Width="80px" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=92&height=30&imgPath="+clsImageUrl.GetProductImageURL(Eval("ProductSmallImageURL")+";"+Eval("ProductMediumImageURL") +";"+Eval("ProductLargeImageURL")) %>'
                        runat="server" ID="imgLiveImage" />
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
</div>
