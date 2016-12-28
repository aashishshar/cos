<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Merchant.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Merchant" %>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Merchants
    </div>
    <div class="panel-body">
        <div class="form-group">
            <div class="alert alert-info">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlMerchantName" Visible="false" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMerchantLinkType" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtMerchantNameDetail" placeholder="Merchant Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtAffiliateID" placeholder="Affiliate ID(AID)" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtLiveMechantID" placeholder="LIVE (MID)" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtLogoUrl" placeholder="Logo URL" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtMerchantNameDescription" TextMode="MultiLine" placeholder="Merchant Name Description" runat="server"></asp:TextBox>
                    </div>
                     <div class="col-lg-2">
                     <asp:TextBox ID="txtTrackingURL" placeholder="Tracking URL" runat="server"></asp:TextBox>
                     </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtMerchantDetails" Rows="3" placeholder="Merchant Profile Details" TextMode="MultiLine"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <asp:Button runat="server" Text="add Merchant" ID="btnMerchantNameAdd" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnMerchantNameAdd_Click" />
                        <asp:Button runat="server" Text="Live Data" ID="btnGetData" EnableTheming="true"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnGetData_Click" />
                        <%-- <asp:Button runat="server" Text="Push To DB" ID="btnPushToDB" 
                            EnableTheming="true" CssClass="btn btn-outline btn-primary" 
                            ValidationGroup="cat" onclick="btnPushToDB_Click"  />--%>
                        <asp:Label CssClass="text-info" ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-6">
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lkbDeactive" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="lkbDeactive_Click">De-Active Merchant</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lkbActive" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="lkbActive_Click">Active Merchant</asp:LinkButton>
                    <asp:LinkButton runat="server" Visible="false" ID="lkbUpdate" EnableTheming="false"
                        CssClass="btn btn-primary"><i class="fa fa-user"></i>&nbsp;Move to user Histry</asp:LinkButton>
                </div>
                <div class="col-lg-2">
                    <asp:DropDownList ID="ddlCategoryType" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-2">
                    <asp:LinkButton runat="server" ID="lkbUpdateCategory" EnableTheming="false" CssClass="btn btn-primary"
                        OnClick="lkbUpdateCategory_Click">Update Category</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvLiveData" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="MerchantName" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MerchantLogoURL" HeaderText="MerchantLogoURL">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TrackingURL" HeaderText="TrackingURL">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvItems" ClientIDMode="Static" DataKeyNames="MId" runat="server"
                        AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MerchantNameDetail" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CategoryType" HeaderText="Category">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OMGMID" HeaderText="Live (MID)">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status_N" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="imgMerchant" CommandName="delMerchant" ImageUrl='<%#Eval("MerchantImage") %>'
                                        Width="80px" Height="30px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
