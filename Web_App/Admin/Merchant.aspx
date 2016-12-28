<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Merchant.aspx.cs" Inherits="Admin_Merchant" %>

<%@ Register Src="../UC/UCUI/Master/Merchant/uc_ApiURLs.ascx" TagName="uc_ApiURLs"
    TagPrefix="uc1" %>
<%@ Register Src="../UC/UCUI/Master/API/uc_VoucherCode.ascx" TagName="uc_VoucherCode"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header">
                API's<small>&nbsp;Add & Run API</small>
            </h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Run Api</div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="col-lg-4">
                            <uc1:uc_ApiURLs ID="uc_ApiURLName" runat="server" />
                        </div>
                        <div class="col-lg-1">
                            <asp:Button runat="server" ID="btnRunAPI" Text="Run api" OnClick="btnRunAPI_Click" />
                        </div>
                        <div class="col-lg-7">
                            <asp:Label ID="lblmsg" runat="server" CssClass="strMsg"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <br />
                            <uc2:uc_VoucherCode ID="uc_VoucherCode1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
