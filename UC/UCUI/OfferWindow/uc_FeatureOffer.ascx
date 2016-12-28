<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_FeatureOffer.ascx.cs"
    Inherits="UC_UCUI_OfferWindow_uc_FeatureOffer" %>
<h4 class="classic-title">
    <span>Feature Offers </span>
</h4>
<asp:Repeater ID="rptFeatureOffer" runat="server" DataSourceID="SqlDataSource1">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-sm-3 col-xs-12" style="margin-bottom: 10px;">
            <div class="da-row">
                <div class="panel panel-default da-center-block">
                    <div class="panel-body">
                        <div class="row da-center-block-img">
                            <asp:ImageButton ID="Image1" runat="server" CausesValidation="false" PostBackUrl='<%#"~/Merchant/"+Eval("MerchantNameDetail")%>'
                                AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantNameDetail") %>'
                                ImageAlign="Bottom" Style="vertical-align: middle;" ImageUrl='<%#Eval("LogoUrl") %>' />
                        </div>
                        <div class="row da-center-block-title">
                            <h6 title='<%#Eval("Title")%>' class="itl-tooltip" data-placement="bottom">
                                <div class="row">
                                    <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(string.IsNullOrEmpty(Eval("Title").ToString())? "" : Eval("Title").ToString())%></asp:Label>
                                </div>
                            </h6>
                        </div>
                        <%--<div class="row da-center-block-offer">
                            <%#Eval("MoreOffer").ToString()=="0"?"":Eval("MoreOffer")+" More Offers" %>
                        </div>--%>
                        <div class="row da-center-block-btn">
                            <asp:HyperLink ID="hlShop" Target="_blank" NavigateUrl='<%#"~/Offer/"+Eval("OfferID")%>'
                                CssClass="btn-system btn-mini border-btn" runat="server">View Offer</asp:HyperLink>
                        </div>
                    </div>
                    <div class="panel-footer ">
                        <small><b>
                             <%#"+ Upto "+Eval("UserCommision")+" CASHBACK"%></b> 
                        </small>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Ad_ConnectionStringMain %>"
    SelectCommand="Adv_Proc_FeatureOffer" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
