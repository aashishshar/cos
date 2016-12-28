<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ProductCommon.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_ProductCommon" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<div class="alert alert-info">
   
    <div class="form-group">
        <div class="row">
            <div class="col-lg-2">
                <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
            </div>
             <div class="col-lg-2">
             <asp:DropDownList ID="ddlAdv_Type" runat="server"></asp:DropDownList>                
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtTitle" placeholder="Title Name" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtMRP" placeholder="MRP" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtDiscountPrice" placeholder="Dis. Price" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtBrand" placeholder="Brand Name" runat="server"></asp:TextBox>
            </div>
           
        </div>
    </div>
    <div class="form-group">
        <div class="row">
         <div class="col-lg-2">
                <asp:TextBox ID="txtColor" placeholder="Color" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtImageURL" placeholder="Image URL" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="txtNavigateURL" placeholder="Navigate URL" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="txtDescription" placeholder="Description" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                <asp:Button runat="server" Text="ADD" ID="btnAdd" EnableTheming="false" CssClass="btn btn-outline btn-primary"
                    ValidationGroup="cat" onclick="btnAdd_Click" />
                <%--<asp:Button runat="server" Text="Live Data" ID="btnGetData" EnableTheming="true"
                    CssClass="btn btn-outline btn-primary" ValidationGroup="cat"  />
                 <asp:Button runat="server" Text="Push To DB" ID="btnPushToDB" 
                            EnableTheming="true" CssClass="btn btn-outline btn-primary" 
                            ValidationGroup="cat" onclick="btnPushToDB_Click"  />--%>
                <asp:Label CssClass="text-info" ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</div>
