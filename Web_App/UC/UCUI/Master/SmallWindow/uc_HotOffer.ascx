<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_HotOffer.ascx.cs" Inherits="UC_UCUI_Master_SmallWindow_uc_HotOffer" %>
<asp:Repeater ID="rptItem" runat="server">
    <HeaderTemplate>
        <div class="widget widget-popular-posts">
            <h4>
              <b>HOT DEals & Offers</b> <span class="head-line"></span></h4>
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <div class="widget-thumb" style="height: 71px; min-height: 71px; vertical-align: middle!important;">
                <a href='<%#Server.UrlDecode(Eval("NavigationURL").ToString()) %>' target="_blank">
                    <asp:Image runat="server" Width="90px" Height="30px" ImageAlign="AbsMiddle" ID="pImage"
                        ImageUrl='<%#Eval("MerchantImage") %>' />
                </a>
            </div>
            <div class="widget-content">
                <a href="<%#Server.UrlDecode(Eval("NavigationURL").ToString()) %>">
                    <h5 >
                     <div title='<%#Eval("Description")%>' class="itl-tooltip" data-placement="top">   <%#ReduceString(Eval("Title").ToString())%></div>
                    </h5>
                    <span><a href="<%#Server.UrlDecode(Eval("NavigationURL").ToString())%>" target="_blank"
                        class="btn-system btn-mini border-btn btn-black"><i class="fa fa-shopping-cart">
                        </i>&nbsp;SHOP NOW</span></a>
                <%--<span class="btn-system btn-mini border-btn" style="border: 1px dotted red; color: Black!important;
                            width: 50%;"><i class="fa fa-cut"></i>&nbsp;<%#Eval("Coupon")%></span> 
                   <%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%>--%></a>
            </div>
            <div class="clearfix">
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul> </div>
    </FooterTemplate>
</asp:Repeater>
