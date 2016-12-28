<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MerchantList.ascx.cs"
    Inherits="UC_UCUI_RightSidebar_UC_MerchantList" %>
<%--<div class="widget widget-categories">
							<h4>Categories <span class="head-line"></span></h4>
							<ul>
								<li>
									<a href="#">Brandign</a>
								</li>
								<li>
									<a href="#">Design</a>
								</li>
								<li>
									<a href="#">Development</a>
								</li>
								<li>
									<a href="#">Graphic</a>
								</li>
							</ul>
						</div>--%>
<asp:Repeater ID="rptMerchants" runat="server">
    <HeaderTemplate>
        <div class="widget widget-categories">
            <h4>
              <b> Offers By Merchants</b>  <span class="head-line"></span>
            </h4>
            <div style="overflow-y: scroll; height: 500px">
                <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="hlViewMerchant" NavigateUrl='<%#"~/MerchantOffers.aspx?m="+Eval("MerchantNameDetail")%>'
                runat="server"><%#Eval("MerchantNameDetail")%></asp:HyperLink>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul> </div></div></FooterTemplate>
</asp:Repeater>
