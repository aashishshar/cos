<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Deal.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Deal" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<%--<link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet"/>   
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<link rel="stylesheet" href="http://cdn.datatables.net/1.10.2/css/jquery.dataTables.min.css"></style>
<script type="text/javascript" 
src="http://cdn.datatables.net/1.10.2/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" 
src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>--%>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Deal's
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
                    </div>
                    <div class="col-lg-5">
                        <asp:TextBox ID="txtDeal" placeholder="Deal Title" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtProductCategoryName" placeholder="Item Category Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtCouponCode" placeholder="Coupon Code" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtDealDescription" Rows="4" placeholder="Deal Description" TextMode="MultiLine"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtNavigationUrl" placeholder="Navigation URL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtImageUrl" placeholder="Image URL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <asp:Button runat="server" Text="add Deal" ID="btnMerchantNameAdd" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnMerchantNameAdd_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <asp:FileUpload ID="fuUpload" runat="server" /><br />
                        <asp:Button runat="server" Text="Upload" ID="btnUploadFile" ValidationGroup="cat"
                            OnClick="btnUploadFile_Click" />
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
                    <div class="table-responsive">
                        <asp:GridView ID="gvItems" CssClass="display table" EnableTheming="true" ClientIDMode="Static"
                            DataKeyNames="DealID" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MerchantName" HeaderText="Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Title" HeaderText="Deal">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProductPrice" HeaderText="Price">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WasPrice" HeaderText="Was Rs.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DiscountedPrice" HeaderText="Dis. Rs.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Brand" HeaderText="Brand">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Availability" HeaderText="In Stock">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="NavigationURL" HeaderText="Navigation URL">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Valid Till">
                                <ItemTemplate>
                                    <%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Width="50px" Height="50px" ImageUrl='<%#Eval("ImageUrl")%>'
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblOffer" runat="server" ToolTip='<%#Eval("Description") %>'><%#ReduceString(Eval("Description").ToString())%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
