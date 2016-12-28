<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ApiURL.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_ApiURL" %>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage API-URL's
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-3">
                        <asp:DropDownList ID="ddlAPIType" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="txtApiName" placeholder="Api Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtApiURL" placeholder="Api URL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtExpireOn" placeholder="Expire On" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <%--<div class="col-lg-4">
                        <asp:TextBox ID="txtDealDescription" Rows="4" placeholder="Deal Description" TextMode="MultiLine"
                            runat="server"></asp:TextBox>
                    </div>--%>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlApiScheduleType" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlRunTime" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-8">
                        <asp:Button runat="server" Text="add API" ID="btnMerchantNameAdd" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnMerchantNameAdd_Click" />
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
                        <asp:GridView ID="gvItems"  runat="server" DataKeyNames="APIId"
                            AutoGenerateColumns="False" Width="100%" ClientIDMode="Static">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="APITypeName" HeaderText="API Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApiName" HeaderText="Api Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--    <asp:BoundField DataField="CouponForDevice" HeaderText="Device">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                                <asp:BoundField DataField="ApiScheduleTypeName" HeaderText="Api Schedule">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RunOnTimeName" HeaderText="Run On">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <%--<asp:BoundField DataField="NavigationURL" HeaderText="Navigation URL">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                              <%--  <asp:TemplateField HeaderText="Expire On">
                                    <ItemTemplate>
                                    
                                        <%#Eval("ExpireOn") != null ? DateTimeAgo.GetFormatDate(Eval("ExpireOn").ToString()) : "-"%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created Date">
                                    <ItemTemplate>
                                        <%#DateTimeAgo.GetFormatDate(Eval("CreatedDate").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="ApiURL">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffer" runat="server"><%#Eval("ApiURL")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" CommandName="delMerchant" CommandArgument='<%#Eval("MerchantName") %>'
                                        ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
    </div>
       
</div>
