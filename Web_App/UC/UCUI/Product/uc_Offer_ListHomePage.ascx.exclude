<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Offer_ListHomePage.ascx.cs" Inherits="UC_UCUI_Product_uc_Offer_ListHomePage" %>

<%@ Register src="uc_OfferCommonUI.ascx" tagname="uc_OfferCommonUI" tagprefix="uc1" %>


<h4 class="classic-title">
    <span>DISCOUNT <i><b> Coupons & Offers</b></i> </span></h4>
<uc1:uc_OfferCommonUI ID="dlItems" runat="server" />

<div style="width:100%;text-align:center;background-color:#F5F5F5;">
<asp:Repeater ID="rptPager" runat="server" >
    <HeaderTemplate>
        <%--<div class="row">
            <div class="col-md-12">--%>
    </HeaderTemplate>
    <ItemTemplate>
        
           <%-- <div class="paginate_button current">--%><%--'<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'--%>
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                    CssClass="btn-system btn-mini border-btn"
                    OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
           <%-- </div>--%>
    </ItemTemplate>
    <FooterTemplate>
        <%--</div></div>--%>
    </FooterTemplate>
</asp:Repeater>
</div>