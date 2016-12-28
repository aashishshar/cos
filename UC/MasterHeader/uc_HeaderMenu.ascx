<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_HeaderMenu.ascx.cs"
    Inherits="UC_MasterHeader_uc_HeaderMenu" %>
    <%@ Register Src="~/UC/UCUI/Menu/uc_MerchantMenu.ascx" TagName="uc_MerchantMenu" TagPrefix="uc2" %>
  <ul class="nav navbar-nav navbar-right"><li><a href="index.html">Coupons</a>
    <uc2:uc_merchantmenu id="uc_MerchantMenu1" runat="server" />
    <%-- <ul class="dropdown">
                                    <li><a href="index.html">Home Main Version</a></li>
                                </ul>--%>
</li>
<li><a class="active" href="about.html">Pages</a>
    <ul class="dropdown">
        <li><a href="about.html">About</a></li>
        <li><a href="services.html">Services</a></li>
        <li><a class="active" href="right-sidebar.html">Right Sidebar</a></li>
        <li><a href="left-sidebar.html">Left Sidebar</a></li>
        <li><a href="404.html">404 Page</a></li>
    </ul>
</li></ul>
<%--   <li><a href="#">shortcodes</a>
                                <ul class="dropdown">
                                    <li><a href="tabs.html">Tabs</a></li>
                                    <li><a href="buttons.html">Buttons</a></li>
                                    <li><a href="action-box.html">Action Box</a></li>
                                    <li><a href="testimonials.html">Testimonials</a></li>
                                    <li><a href="latest-posts.html">Latest Posts</a></li>
                                    <li><a href="latest-projects.html">Latest Projects</a></li>
                                    <li><a href="pricing.html">Pricing Tables</a></li>
                                    <li><a href="accordion-toggles.html">Accordion & Toggles</a></li>
                                </ul>
                            </li>
                            <li><a href="portfolio-3.html">Portfolio</a>
                                <ul class="dropdown">
                                    <li><a href="portfolio-2.html">2 Columns</a></li>
                                    <li><a href="portfolio-3.html">3 Columns</a></li>
                                    <li><a href="portfolio-4.html">4 Columns</a></li>
                                    <li><a href="single-project.html">Single Project</a></li>
                                </ul>
                            </li>
                            <li><a href="blog.html">Blog</a>
                                <ul class="dropdown">
                                    <li><a href="blog.html">Blog - right Sidebar</a></li>
                                    <li><a href="blog-left-sidebar.html">Blog - Left Sidebar</a></li>
                                    <li><a href="single-post.html">Blog Single Post</a></li>
                                </ul>
                            </li>
                            <li><a href="contact.html">Contact</a></li>--%>