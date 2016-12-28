<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_VoucherCode.ascx.cs"
    Inherits="UC_UCUI_Master_API_uc_VoucherCode" %>
<asp:GridView ID="gvXMLDate" runat="server" PageSize="500" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkXMLData" runat="server"></asp:CheckBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="VoucherCodeId" HeaderText="Code">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Name">
            <HeaderTemplate>
                <asp:DropDownList ID="ddlHeader" OnSelectedIndexChanged="ddlHeader_SelectedIndexChanged"
                    AutoPostBack="true" runat="server">
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblMname" Text='<%#Eval("Merchant") %>' runat="server" />
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <%-- <asp:BoundField DataField="Merchant" HeaderText="Merchant">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
        <asp:BoundField DataField="Code" HeaderText="Code">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Title">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="Description" HeaderText="Description">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="ActivationDate" HeaderText="ActivationDate">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="ExpiryDate" HeaderText="ExpiryDate">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="TrackingUrl" HeaderText="TrackingUrl">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
