<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_RightSideTop.ascx.cs"
    Inherits="UC_UCUI_Master_Banners_uc_RightSideTop" %>
<asp:Repeater ID="rptItem" runat="server">
    <HeaderTemplate>
        <div class="widget widget-popular-posts">
            <!-- Classic Heading -->
            <h4>
               <b> Hot Deals</b><span class="head-line"></span></h4>
            <div class="custom-carousel show-one-slide touch-carousel owl-carousel owl-theme"
                style="width: 100%!important;" data-appeared-items="1">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="portfolio-item item">
            <div class="portfolio-border">
                <%#clsImageUrl.GetImagesInHTMLString(Eval("BannerURL").ToString(),"263","90")%>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div> </div>
    </FooterTemplate>
</asp:Repeater>
<%--<h4 class="classic-title">
    <span>Hot Deals</span></h4>
<!-- Start Testimonials Carousel -->
<div class="custom-carousel show-one-slide touch-carousel owl-carousel owl-theme" data-appeared-items="1">
    <!-- Testimonial 1 -->
    <div class="portfolio-item item">
      <div class="portfolio-border">
  <p>
                <a href="http://clk.omgt5.com/?AID=764019&MID=634489&PID=12495&CID=4470402&CRID=96839&WID=57715"
            rel="nofollow">
            <img src="http://track.in.omgpm.com/bs/?CRID=96839&AID=764019&PID=12495&CID=4470402&WID=57715"
                border="0" width="263" height="88"></a>
                 </p>
        </div>
       <div class="testimonial-author">
            <span>John Doe</span> - Customer</div></div>
    </div>
    <!-- Testimonial 2 -->
    <div class="classic-testimonials item">
        <div class="testimonial-content">
            <p>
                 <a href="http://clk.omgt5.com/?AID=764019&MID=634489&PID=12495&CID=4470402&CRID=93328&WID=57715"
            rel="nofollow">
            <img src="http://track.in.omgpm.com/bs/?CRID=93328&AID=764019&PID=12495&CID=4470402&WID=57715"
                border="0" width="300" height="100"></a>  </p>
        </div>
      <div class="testimonial-author">
            <span>John Doe</span> - Customer</div>
    </div>
    
    <!-- Testimonial 3 -->
    <div class="classic-testimonials item">
        <div class="testimonial-content">
            <p>
               <a href="http://clk.omgt5.com/?AID=764019&MID=478605&PID=10859&CID=4473616&CRID=83801&WID=57715"
            rel="nofollow" target="_blank">
            <img src="http://track.in.omgpm.com/bs/?CRID=83801&AID=764019&PID=10859&CID=4473616&WID=57715"
                border="0" width="300" height="100"></a></p>
        </div>
        <div class="testimonial-author">
            <span>John Doe</span> - Customer</div>
    </div>
</div>
--%>
<%--    <a href="http://clk.omgt5.com/?AID=764019&MID=634489&PID=12495&CID=4470402&CRID=96839&WID=57715"
            rel="nofollow">
            <img src="http://track.in.omgpm.com/bs/?CRID=96839&AID=764019&PID=12495&CID=4470402&WID=57715"
                border="0" width="300" height="100"></a><br />
                <a href="http://clk.omgt5.com/?AID=764019&MID=634489&PID=12495&CID=4470402&CRID=93328&WID=57715"
            rel="nofollow">
            <img src="http://track.in.omgpm.com/bs/?CRID=93328&AID=764019&PID=12495&CID=4470402&WID=57715"
                border="0" width="300" height="100"></a> <br />
                 <a href="http://clk.omgt5.com/?AID=764019&MID=478605&PID=10859&CID=4473616&CRID=83801&WID=57715"
            rel="nofollow" target="_blank">
            <img src="http://track.in.omgpm.com/bs/?CRID=83801&AID=764019&PID=10859&CID=4473616&WID=57715"
                border="0" width="300" height="100"></a>--%>
