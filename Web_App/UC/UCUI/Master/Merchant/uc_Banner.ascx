<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Banner.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Banner" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<%--<script>
    $('#myButton').on('click', function () {
        var $btn = $(this).button('loading');
        // business logic...
        $btn.button('reset');
    });
</script>
<button type="button" id="myButton" data-loading-text="Loading..." class="btn btn-primary" autocomplete="off">
  Loading state
</button>
using button.js follow:http://getbootstrap.com/javascript/ this
<script>
    $('#myButton').on('click', function () {
        var $btn = $(this).button('loading')
        // business logic...
        $btn.button('reset')
    })
</script>--%>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Banner's
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtBannerText" placeholder="BannerText" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtDescription" placeholder="Description" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtPrice" placeholder="Price" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtDiscountedPrice" placeholder="Discounted Price" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlBanner" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlBannerLocation" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtBannerURL" TextMode="MultiLine" placeholder="Banner URL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:FileUpload ID="imgUpload" runat="server" />
                    </div>
                    <div class="col-lg-2">
                       <asp:Button runat="server" Text="Upload" ID="btnUploadFile" 
                            ValidationGroup="cat" onclick="btnUploadFile_Click" />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button runat="server" ClientIDMode="Static" Text="Submit" ID="Button1" data-loading-text="Loading..."
                            EnableTheming="false" CssClass="btn btn-outline btn-primary" ValidationGroup="cat"
                            OnClick="btnMerchantNameAdd_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="gvItems" AllowPaging="True" runat="server" DataKeyNames="BannerID"
                        AutoGenerateColumns="False" Width="100%" PageSize="500">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MerchantName" HeaderText="Merchant">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BannerText" HeaderText="Banner Text">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BannerTypeName" HeaderText="Banner Type">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BannerLocationName" HeaderText="Banner Location">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%-- <asp:TemplateField HeaderText="User Commision">
                                <ItemTemplate>
                                    <%#Eval("BannerURL")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CurrencyName" HeaderText="Currency">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
