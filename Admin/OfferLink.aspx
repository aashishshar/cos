<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="OfferLink.aspx.cs" Inherits="Admin_OfferLink" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" DocumentMapWidth="100%" 
        Font-Names="Verdana" Font-Size="8pt" Height="500px" 
        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Admin\rpt_OfferLinkView.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="GetOfferLink" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Ad_ConnectionStringMain %>" 
        SelectCommand="Adv_Proc_GetOfferLink" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

</asp:Content>

