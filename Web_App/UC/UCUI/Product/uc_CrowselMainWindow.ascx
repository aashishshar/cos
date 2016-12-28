<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CrowselMainWindow.ascx.cs"
    Inherits="UC_UCUI_Product_uc_CrowselMainWindow" %>
<div id="carousel-custom" class="carousel slide" data-ride="carousel" style="margin-bottom: 20px;">
    <%--<ol class="carousel-indicators">
  <li data-target="#carousel-custom" data-slide-to="0" class="active"></li>
  <li data-target="#carousel-custom" data-slide-to="1"></li>
</ol>main-slide--%>
    <asp:Repeater ID="rptItem" runat="server">
        <HeaderTemplate>
            <div class="carousel-outer">
                <div id="divContentCrowsel" class="carousel-inner" style="min-height:280px;">
        </HeaderTemplate>
        <ItemTemplate>
            <!-- Wrapper for slides -->
            <div class='item' style="min-height:280px;">
                <asp:HyperLink ID="hlmerchantcrowsel" Target="_blank" NavigateUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                    runat="server">
                    <asp:Image ID="Image1" Height="280px" Width="100%" ImageUrl='<%#Eval("bannerurl") %>'
                        BorderWidth="0" ImageAlign="AbsMiddle" runat="server" />
                </asp:HyperLink>
            </div>
            <%-- <div class='item'>
                    <asp:Image ID="Image2" ImageUrl="~/Images/2.jpg" runat="server" />
                </div>
                <div class='item'>
                    <asp:Image ID="Image3" ImageUrl="~/Images/2.jpg" runat="server" />
                </div>
                <div class='item'>
                    <asp:Image ID="Image4" ImageUrl="~/Images/2.jpg" runat="server" />
                </div>
                <div class='item'>
                    <asp:Image ID="Image5" ImageUrl="~/Images/2.jpg" runat="server" />
                </div>
                <div class='item'>
                    <asp:Image ID="Image6" ImageUrl="~/Images/2.jpg" runat="server" />
                </div>--%>
        </ItemTemplate>
        <FooterTemplate>
            </div>
            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-custom" data-slide="prev"><span><i
                class="fa fa-angle-left"></i></span></a><a class="right carousel-control" href="#carousel-custom"
                    data-slide="next"><span><i class="fa fa-angle-right"></i></span></a></div>
        </FooterTemplate>
    </asp:Repeater>
    <!-- Indicators -->
    <%--<ul class='carousel-indicators'>
        <li data-target='#carousel-custom' data-slide-to='0' class='active pos'>Lenovo A2010<br />Most affordable 4G</li>
        <li data-target='#carousel-custom' data-slide-to='1' class='pos'>Lenovo A2010<br />Most affordable 4G</li>
        <li data-target='#carousel-custom' data-slide-to='2' class='pos'>Lenovo A2010<br />Most affordable 4G</li>
        <li data-target='#carousel-custom' data-slide-to='3' class='pos'>Lenovo A2010<br />Most affordable 4G</li>
        <li data-target='#carousel-custom' data-slide-to='4' class='pos'>Lenovo A2010<br />Most affordable 4G</li>
        <li data-target='#carousel-custom' data-slide-to='5' class='pos'>Lenovo A2010<br />Most affordable 4G</li>
    </ul>--%>
</div>
<%--<script type="text/javascript"  src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>
