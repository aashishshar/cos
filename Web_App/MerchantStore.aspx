<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="MerchantStore.aspx.cs" Inherits="MerchantStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12">
        <div class="latest-posts">
            <!-- Classic Heading -->
            <h4 class="classic-title">
                <span>Merchant's Store</span></h4>
            <asp:Repeater ID="dlMerchants" runat="server">
                <HeaderTemplate>
                    <ul id="portfolio-list" data-animated="fadeIn">
                        <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-3">
                        <asp:HyperLink Target="_blank" ID="hlNav" NavigateUrl='<%#"~/Merchant/"+Eval("MerchantNameDetail")%>'
                            runat="server">
                            <li style="margin-bottom: 5px; width: 100%; border: 1px solid #E8E8E8; text-align: center;
                                height: 100px; min-height: 100px; padding-bottom: 5px!important; background-color: White;">
                                
                                    <div class="">
                                        <asp:ImageButton ID="Image1" Height="42px" Width="125px" Style="margin: 10% auto;"
                                            runat="server" CssClass="img-responsive" AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantNameDetail") %>'
                                            ImageAlign="AbsMiddle" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "MerchantImage") %>' /></div>
                               
                                <div class="portfolio-item-content">
                                    <div style="margin-top: 10px;">
                                        <div class="col-sm-6">
                                            <span class="header"><b>Cashback</b></span>
                                        </div>
                                        <div class="col-sm-6">
                                            <span class="header"><b>Offer</b></span></div>
                                    </div>
                                    <div class="col-sm-6">
                                        <p class="body da-alignCenter">
                                            <b style="border-bottom: 1px dotted white;">
                                                <%#Eval("UserCommission")%></b></p>
                                    </div>
                                    <div class="col-sm-6">
                                        <p class="body da-alignCenter">
                                            <b style="border-bottom: 1px dotted white;"><i class="fa fa-cut"></i>&nbsp;<%#Eval("TotalOffer")%></b></p>
                                    </div>
                                    <%-- <span class="header">Monocle issue 69</span>
                                <p class="body">
                                    web develpment, design</p>--%>
                                </div>
                                <%--<a href="#"><i class="more">+</i></a>--%>
                            </li>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div> </ul>
                </FooterTemplate>
            </asp:Repeater>
            <%--  <asp:DataList ID="dlMerchants" Width="100%" runat="server" RepeatColumns="6" ItemStyle-VerticalAlign="Middle"
                RepeatLayout="Flow" RepeatDirection="Horizontal">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-2">
                        <div class="panel panel-default">
                            <div class="panel-body" style="text-align: center; height:70px; min-height: 70px;
                                padding-bottom: 5px!important">
                                <div class="row" style="height: 31px; min-height: 32px; max-height: 32px!important;">
                           
                                    <asp:ImageButton ID="Image1" runat="server" PostBackUrl='<%#"~/MerchantOffers.aspx?m="+Eval("MerchantNameDetail")%>'
                                        AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantNameDetail") %>'
                                        ImageAlign="Bottom" Style="vertical-align:middle;max-height:65px; width: 100px;" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "MerchantImage") %>' />
                               
                               
                                </div>
                            </div>
                        </div>
                       <div style="min-height: 50px; height: 100px; width: 140px; margin-bottom: 10px; vertical-align: middle!important;"
                            class="img-thumbnail image-text">
                            <span style="vertical-align: middle">
                                <asp:ImageButton ID="Image1" runat="server" PostBackUrl='<%#"~/MerchantOffers.aspx?m="+Eval("MerchantNameDetail")%>'
                                    AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantNameDetail") %>'
                                    ImageAlign="Bottom" Style="float: left; width: 120px;" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "MerchantImage") %>' /></span></div>
                        ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=92&height=30&imgPath="+Eval("MerchantImage") %>' />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div></FooterTemplate>
            </asp:DataList>--%>
        </div>
    </div>
    <%--<div class="col-md-3">
        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <!-- Text OnRight Side -->
        <ins class="adsbygoogle" style="display: inline-block; width: 100%; height: 90px"
            data-ad-client="ca-pub-2047998762919253" data-ad-slot="1437251607"></ins>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>
    </div>
    --%></asp:Content>
