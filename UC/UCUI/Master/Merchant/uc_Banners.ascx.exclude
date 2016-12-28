<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Banners.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Banners" %>
<%--<img src="Handler/ImageResizeHandler.ashx?width=100&amp;height=90&amp;imgPath=https://media.go2speed.org/brand/files/payoom/524/20150212115128-200x200.jpg"/>--%>
<asp:Repeater ID="rptItem" runat="server">
    <HeaderTemplate>
        <div class="latest-posts">
            <!-- Classic Heading -->
            <h4 class="classic-title">
                <span>Featured Offers</span></h4>
            <div class="projects-carousel touch-carousel owl-carousel owl-theme" style="width: 100%!important;"
                data-appeared-items="4">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="portfolio-item item">
            <div class="portfolio-border" style="text-align: center;">
                <%-- <%#Eval("BannerURL")%>--%>
                <%#clsImageUrl.GetImagesInHTMLString(Eval("BannerURL").ToString(),"155","110")%>
                <div class="" style="height: 45px; min-height: 45px;margin-left:2px;margin-right:2px;">
                  <%#ReduceString(Eval("Description")==null ? "" : Eval("Description").ToString())%></div>
                <div class="" style="height: 20px; min-height: 20px;">
                    <%#Eval("DiscountPercentageText")%></div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div> </div>
    </FooterTemplate>
</asp:Repeater>
