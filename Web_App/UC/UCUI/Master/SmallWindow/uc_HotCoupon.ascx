<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_HotCoupon.ascx.cs"
    Inherits="UC_UCUI_Master_SmallWindow_uc_HotCoupon" %>
<asp:Repeater ID="rptItem" runat="server">
    <HeaderTemplate>
        <div class="widget widget-popular-posts">
            <h4>
              <b> HOT COUPON</b> <span class="head-line"></span></h4>
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <div class="widget-thumb" style="height: 71px; min-height: 71px; vertical-align: middle!important;">
                <a href='<%#Eval("NavigationURL") %>' target="_blank">
                    <asp:Image runat="server" Width="92px" Height="30px" ImageAlign="AbsMiddle" ID="pImage"
                        ImageUrl='<%#Eval("MerchantImage") %>' />
                </a>
            </div>
            <div class="row">
                <div class="widget-content">
                    <a href="<%#Eval("NavigationURL") %>">
                        <h5>
                            <%#ReduceString(Eval("Offer").ToString())%></h5>
                        <span class="btn-system btn-mini border-btn" style="border: 1px dotted red; color: Black!important;
                            width: 50%;"><i class="fa fa-cut"></i>&nbsp;<%#Eval("Coupon")%></span> </a>
                    <%--<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%>--%>
                </div>
            </div>
            <div class="clearfix">
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul> </div>
    </FooterTemplate>
</asp:Repeater>
