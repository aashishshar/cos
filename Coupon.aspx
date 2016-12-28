<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="Coupon.aspx.cs" Inherits="Coupon" %>

<%@ Register Src="UC/UCUI/Master/Merchant/uc_AllCoupons.ascx" TagName="uc_AllCoupons"
    TagPrefix="uc1" %>
<%@ Register Src="UC/UCUI/RightSidebar/uc_MerchantListCB_List.ascx" TagName="uc_MerchantListCB_List"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-9 page-content">
        <div class="latest-posts">
            <!-- Classic Heading -->
            <h4 class="classic-title">
                <span>Search Coupons</span></h4>
            <p>
                <div class="row">
                    <uc1:uc_AllCoupons ID="uc_AllCouponsList" runat="server" />
                </div>
            </p>
        </div>
    </div>
    <div class="col-md-3 sidebar right-sidebar">
        <div class="widget widget-categories">
            <h4>
                Find Coupons <span class="head-line"></span>
            </h4>
            <ul>
                <li>
                    <asp:CheckBox ID="ckbAll" AutoPostBack="true" runat="server" Text="&nbsp;ALL" OnCheckedChanged="ckbAll_CheckedChanged" /></li>
            </ul>
            <ul>
                <li>
                    <asp:TextBox ID="txtmerchant" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#ckbAllMerchant');"
                        placeholder="Search Merchant"></asp:TextBox></li></ul>
            <div style="overflow-y: scroll; height: 400px; margin-bottom: 10px!important">
                <uc2:uc_MerchantListCB_List ID="uc_MerchantListCB_ListItem" runat="server" />
                <%--<asp:CheckBoxList ID="ckbAllMerchant"  runat="server" RepeatLayout="UnorderedList"
                    TextAlign="Right" OnSelectedIndexChanged="ckbAllMerchant_SelectedIndexChanged">
                </asp:CheckBoxList>--%>
            </div>
            <p style="text-align: center;">
                <asp:LinkButton ID="lkbFilterSearch" EnableTheming="false" Width="100%" CssClass="btn-system btn-large border-btn"
                    runat="server" OnClick="lkbFilterSearch_Click"><i class='fa fa-filter'></i>&nbsp;Refine your search here</asp:LinkButton>
            </p>
        </div>
    </div>
</asp:Content>
