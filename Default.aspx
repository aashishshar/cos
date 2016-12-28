<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="UC/UCUI/Product/uc_VwProduct.ascx" TagName="uc_VwProduct" TagPrefix="uc1" %>
<%@ Register Src="UC/UCUI/Master/Merchant/uc_Banners.ascx" TagName="uc_Banners" TagPrefix="uc2" %>
<%@ Register Src="UC/UCUI/Master/Banners/uc_RightSideTop.ascx" TagName="uc_RightSideTop"
    TagPrefix="uc3" %>
<%@ Register Src="UC/UCUI/Master/SmallWindow/uc_HotCoupon.ascx" TagName="uc_HotCoupon"
    TagPrefix="uc4" %>
<%@ Register Src="UC/UCUI/Master/SmallWindow/uc_HotOffer.ascx" TagName="uc_HotOffer"
    TagPrefix="uc5" %>
<%@ Register Src="UC/UCUI/Master/SmallWindow/uc_TextBannerRecharge.ascx" TagName="uc_TextBannerRecharge"
    TagPrefix="uc6" %>
<%@ Register Src="UC/UCUI/Product/uc_Offer_ListHomePage.ascx" TagName="uc_Offer_ListHomePage"
    TagPrefix="uc7" %>
<%@ Register Src="UC/UCUI/Product/uc_DOTD.ascx" TagName="uc_DOTD" TagPrefix="uc8" %>
<%@ Register Src="UC/UCUI/Product/uc_CashBackProcess.ascx" TagName="uc_CashBackProcess"
    TagPrefix="uc9" %>
<%@ Register Src="UC/UCUI/Product/uc_CrowselMainWindow.ascx" TagName="uc_CrowselMainWindow"
    TagPrefix="uc10" %>
<%@ Register Src="UC/UCUI/Product/uc_Subscribebox.ascx" TagName="uc_Subscribebox"
    TagPrefix="uc11" %>
<%@ Register Src="UC/UCUI/OfferWindow/uc_FeatureOffer.ascx" TagName="uc_FeatureOffer"
    TagPrefix="uc12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
    <h4 class="classic-title">
        <span>Page With Right Sidebar</span></h4>
    <p>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server"><%#Eval("Title") %></asp:Label>
                <asp:Label ID="Label2" runat="server"><%#Eval("description")%></asp:Label>
                <asp:Label ID="Label4" runat="server"><%#Eval("availability")%></asp:Label>
               
                <asp:Repeater ID="Repeater2" DataSource='<%#Eval("imageUrls")%>' runat="server">
                    <ItemTemplate>
                        
                        <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" ImageUrl='<%#Eval("url")%>'>
                        </asp:Image>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </p>--%>
    <div class="col-md-9">
        <uc10:uc_CrowselMainWindow ID="uc_CrowselMainWindow1" runat="server" />
        <uc7:uc_Offer_ListHomePage ID="uc_Offer_ListHomePage1" runat="server" />
<br/>
<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- Cashonshop -->
<ins class="adsbygoogle"
     style="display:block"
     data-ad-client="ca-pub-2047998762919253"
     data-ad-slot="6609202400"
     data-ad-format="auto"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
<br/>        <uc12:uc_FeatureOffer ID="uc_FeatureOffer1" runat="server" />
        <div style="margin-top: 15px;">
        </div>
        <%--<uc8:uc_DOTD ID="uc_DOTD1" runat="server" />--%><br />
        <br />

        <script src="http://ib.adnxs.com/ttj?id=6012073&size=728x90" type="text/javascript"></script>
        <%--<uc8:uc_DOTD ID="uc_DOTD1" runat="server" />
        <uc1:uc_VwProduct ID="uc_VwProduct1" runat="server" />--%>
    </div>
    <div class="col-md-3 sidebar right-sidebar">
        <%-- <uc3:uc_RightSideTop ID="uc_RightSideTop1" runat="server" />--%>
        <uc6:uc_TextBannerRecharge ID="uc_TextBannerRecharge1" runat="server" />
        <%-- <uc4:uc_HotCoupon ID="uc_HotCoupon1" runat="server" />
        <uc5:uc_HotOffer ID="uc_HotOffer1" runat="server" />--%>
        <uc9:uc_CashBackProcess ID="uc_CashBackProcess1" runat="server" />
        <script src="http://ib.adnxs.com/ttj?id=6012073&size=300x250" type="text/javascript"></script>
        <br />
        <br />

        <%-- <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <!-- cashonshop right top -->
        <ins class="adsbygoogle" style="display: inline-block; width: 320px; height: 100px"
            data-ad-client="ca-pub-2047998762919253" data-ad-slot="8903346808"></ins>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>
        <br />
        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <ins class="adsbygoogle" style="display: block" data-ad-client="ca-pub-2047998762919253"
            data-ad-slot="4359828808" data-ad-format="auto"></ins>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>--%>
    </div>
    <div style="margin-top: 15px;" class="clearfix">
    </div>
    <%--  <uc2:uc_Banners ID="uc_Banners1" runat="server" />
       <div class="hr5" style="margin-top: 15px; margin-bottom: 15px;">
        </div>--%>
    <uc11:uc_Subscribebox ID="uc_Subscribebox1" runat="server" />
</asp:Content>
