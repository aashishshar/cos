<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Notification.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_Notification" %>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Notifications's
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-3">
                        <asp:DropDownList ID="ddlNotificationType" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-7">
                        <asp:TextBox ID="txtNotificationText" placeholder="Notification Text" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button runat="server" Text="add Notification" ID="btnMerchantNameAdd" EnableTheming="false"
                            CssClass="btn btn-outline btn-primary" ValidationGroup="cat" OnClick="btnMerchantNameAdd_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" 
                        CssClass="btn  btn-danger" onclick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="gvItems" runat="server" DataKeyNames="NotificationId" AutoGenerateColumns="False"
                        Width="100%" ClientIDMode="Static">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NotificationText" HeaderText="Notification Text">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NotificationType" HeaderText="Place">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
