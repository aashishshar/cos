<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Commisions.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_Commisions" %>
<h4 class="classic-title">
    <span>User Commision</span></h4>
<asp:GridView ID="gvItems" AllowPaging="True" runat="server" DataKeyNames="CommisionID"
    AutoGenerateColumns="False" Width="100%" PageSize="500">
    <Columns>
        <%-- <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:BoundField DataField="ProgramName" HeaderText="Merchant Name">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <%-- <asp:BoundField DataField="Commision" HeaderText="Commision">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>--%>
        <asp:TemplateField HeaderText="Commision">
            <ItemTemplate>
                <%#Eval("UserCommision") %>&nbsp;(<%#Eval("CurrencyName")%>)
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
