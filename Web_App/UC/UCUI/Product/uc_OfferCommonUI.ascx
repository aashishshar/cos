<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OfferCommonUI.ascx.cs"
    Inherits="UC_UCUI_Product_uc_OfferCommonUI" %>
<div id="myCarousellrg" class="carousel slide">
    <div class="carousel-inner">
        <div class="active item" style="padding: 0 36px">
            <div class="row">
                <asp:Repeater ID="rpItems" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-sm-3 col-xs-12" style="margin-bottom: 10px;">
                            <div class="da-row">
                                <div class="panel panel-default da-center-block">
                                    <div class="panel-body">
                                        <div class="row da-center-block-img">
                                            <asp:ImageButton ID="Image1" runat="server" CausesValidation="false" PostBackUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                                                AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantName") %>' ImageAlign="Bottom"
                                                Style="vertical-align: middle;" ImageUrl='<%#Eval("MerchantImage") %>' />
                                        </div>
                                        <div class="row da-center-block-title">
                                            <h6 title='<%#Eval("Title")%>' class="itl-tooltip" data-placement="bottom">
                                                <div class="row">
                                                    <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(string.IsNullOrEmpty(Eval("Title").ToString())? "" : Eval("Title").ToString())%></asp:Label>
                                                </div>
                                            </h6>
                                        </div>
                                        <div class="row da-center-block-offer">
                                            <%#Eval("MoreOffer").ToString()=="0"?"":Eval("MoreOffer")+" More Offers" %>
                                        </div>
                                        <div class="row da-center-block-btn">
                                            <asp:HyperLink ID="hlShop" Target="_blank" NavigateUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                                                CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> Get Offer</asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="panel-footer da-center-block-footer">
                                        <small><b>
                                            <%#"+ Upto "+Eval("UserCommision")+" CASHBACK"%></b> </small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!--Item 2nd-->
        <div class="item" style="padding: 0 36px">
            <div class="row">
                <asp:Repeater ID="rpItems1" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-sm-3 col-xs-12" style="margin-bottom: 10px;">
                            <div class="da-row">
                                <div class="panel panel-default da-center-block">
                                    <div class="panel-body">
                                        <div class="row da-center-block-img">
                                            <asp:ImageButton ID="Image1" runat="server" PostBackUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                                                AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantName") %>' ImageAlign="Bottom"
                                                Style="vertical-align: middle;" ImageUrl='<%#Eval("MerchantImage") %>' />
                                        </div>
                                        <div class="row da-center-block-title">
                                            <h6 title='<%#Eval("Title")%>' class="itl-tooltip" data-placement="bottom">
                                                <div class="row">
                                                    <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(string.IsNullOrEmpty(Eval("Title").ToString())? "" : Eval("Title").ToString())%></asp:Label>
                                                </div>
                                            </h6>
                                        </div>
                                        <div class="row da-center-block-offer">
                                            <%#Eval("MoreOffer").ToString()=="0"?"":Eval("MoreOffer")+" More Offers" %>
                                        </div>
                                        <div class="row da-center-block-btn">
                                            <asp:HyperLink ID="hlShop" Target="_blank" NavigateUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                                                CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> Get Offer</asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="panel-footer da-center-block-footer">
                                        <small><b>
                                            <%#"+ Upto "+Eval("UserCommision")+" CASHBACK"%></b> </small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="item" style="padding: 0 36px">
            <div class="row">
                <asp:Repeater ID="rpItems2" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-sm-3 col-xs-12" style="margin-bottom: 10px;">
                            <div class="da-row">
                                <div class="panel panel-default da-center-block">
                                    <div class="panel-body">
                                        <div class="row da-center-block-img">
                                            <%--ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=150&height=50&imgPath="+Eval("MerchantImage") %>'--%>
                                            <asp:ImageButton ID="Image1" runat="server" PostBackUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                                                AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantName") %>' ImageAlign="Bottom"
                                                Style="vertical-align: middle;" ImageUrl='<%#Eval("MerchantImage") %>' />
                                        </div>
                                        <div class="row da-center-block-title">
                                            <h6 title='<%#Eval("Title")%>' class="itl-tooltip" data-placement="bottom">
                                                <div class="row">
                                                    <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(string.IsNullOrEmpty(Eval("Title").ToString())? "" : Eval("Title").ToString())%></asp:Label>
                                                </div>
                                            </h6>
                                        </div>
                                        <div class="row da-center-block-offer">
                                            <%#Eval("MoreOffer").ToString()=="0"?"":Eval("MoreOffer")+" More Offers" %>
                                        </div>
                                        <div class="row da-center-block-btn">
                                            <asp:HyperLink ID="hlShop" Target="_blank" NavigateUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                                                CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> Get Offer</asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="panel-footer da-center-block-footer">
                                        <small><b>
                                            <%#"+ Upto "+Eval("UserCommision")+" CASHBACK"%></b> </small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <a class="carousel-control left" href="#myCarousellrg" data-slide="prev">&lsaquo;</a>
    <a class="carousel-control right" href="#myCarousellrg" data-slide="next">&rsaquo;</a>
</div>
