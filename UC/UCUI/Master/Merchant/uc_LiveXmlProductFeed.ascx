<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_LiveXmlProductFeed.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_LiveXmlProductFeed" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<div class="alert alert-info">
    <div class="form-group">
        <div class="row">
            <div class="col-lg-3">
                <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
            </div>           
            <div class="col-lg-6">
                <asp:Button runat="server" Text="Run Api" ID="btnUploadFile" ValidationGroup="cat"
                    OnClick="btnUploadFile_Click" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</div>