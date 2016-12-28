<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="frmGeneralSearch.aspx.cs" Inherits="frmGeneralSearch" %>


<%@ Register Src="~/UC/UCUI/Product/uc_ProductCommonItems.ascx" TagName="uc_VwProduct"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="col-md-9 page-content">
       <%--<div class="row" style="text-align: center;">
            <div class="col-lg-12" style="text-align: center;">
              <span style="margin-right:20px"> <asp:LinkButton ID="lnkDiscount" OnClick="lnkLowPrice_Click"  ForeColor="Gray" runat="server">Discount</asp:LinkButton></span> 
              <span style="margin-right:20px">  <asp:LinkButton ID="lnkHighPrice" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">High Price</asp:LinkButton></span> 
                <span style="margin-right:20px"><asp:LinkButton ID="lnkLowPrice" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">Low Price</asp:LinkButton></span> 
            </div>
        </div>--%>
        <div class="hr5" style="margin-top: 10px; margin-bottom: 15px;">
        </div>
        <div class="row">
            <uc1:uc_VwProduct ID="uc_VwProduct1" runat="server" />
        </div>
       <%-- <div class="row" align="center">
            <asp:LinkButton ID="lnkLoadmoreRecords" Font-Bold="true" ForeColor="Green" Font-Size="20px" OnClick="lnkLoadmoreRecords_Click" runat="server">Load More Records</asp:LinkButton>
        </div>--%>
    </div>
</asp:Content>

