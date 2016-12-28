<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DOTD.ascx.cs" Inherits="UC_UCUI_Product_uc_DOTD" %>
<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<asp:Repeater ID="rpItems" runat="server">
    <HeaderTemplate>
        <div class="latest-posts">
            <!-- Classic Heading -->
            <h4 class="classic-title">
                <span>DEALS <i><b>of the</b></i> DAY</span></h4>
            <div class="projects-carousel touch-carousel owl-carousel owl-theme" style="width: 100%!important;"
                data-appeared-items="6">
    </HeaderTemplate>
    <ItemTemplate>
        <%--<div class="col-md-3">
            <div class="panel panel-default">
                <div class="panel-body" style="text-align: center; height: 150px; min-height: 150px;
                    padding-bottom: 5px!important">--%>
        <div class="portfolio-item item" style="text-align: center;">
            <div class="portfolio-border" style="height: 200px; min-height: 200px; padding-bottom: 5px!important;">
                <div style="height: 20px; min-height: 20px; max-height: 20px!important; padding-bottom: 2px;">
                    <div class="row">
                        <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(string.IsNullOrEmpty(Eval("Title").ToString())? "" : Eval("Title").ToString())%></asp:Label>
                    </div>
                    <%--<asp:ImageButton ID="Image1" runat="server" PostBackUrl='<%#"~/MerchantOffers.aspx?m="+Eval("MerchantName")%>'
                        AlternateText='<%#DataBinder.Eval(Container.DataItem,"MerchantName") %>' ImageAlign="Bottom"
                        Style="vertical-align: middle;" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=130&height=40&imgPath="+Eval("MerchantImage") %>' />
                    --%>
                </div>
                <%--  <div style="top: 3px; right: 15px; padding: 0 5px; position: absolute; z-index: 29;"
                    runat="server" id="dotddiv" visible='<%#Eval("OfferType").ToString()=="4"?true:false %>'>
                    <asp:Image ID="Image2" ImageUrl="~/ProfilePic/Default/dotd.png" runat="server" />
                </div>--%>
                <div style="height: 100px; min-height: 100px; margin-left: 3px!important; margin-right: 3px!important;">
                    <asp:Image ID="imgProduct" runat="server" Style="vertical-align: middle;" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=100&height=100&imgPath="+Eval("ImageUrl") %>' />
                </div>
                <div class="hr5" style="margin-top: 2px; margin-bottom: 5px;">
                </div>
                <div class="row" style="margin-top: 3px; margin-left: 3px!important; margin-right: 3px!important;
                    height: 30px; min-height: 30px;">
                    <h6 title='<%#Eval("Description")%>' class="itl-tooltip" data-placement="bottom">
                        <%#ReduceString(string.IsNullOrEmpty(Eval("Description").ToString()) ? "" : Eval("Description").ToString())%>
                    </h6>
                    <h6>
                        <small>Buy From&nbsp;:&nbsp;<%#Eval("MerchantName")%></small></h6>
                </div>
                <div style="margin-bottom: 2px!important; margin-top: 5px; vertical-align: baseline;">
                    <asp:HyperLink ID="hlShop" Target="_blank" NavigateUrl='<%#Eval("NavigationUrl")%>'
                        CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> Grab Deal</asp:HyperLink>
                </div>
            </div>
                     <%--<div class="modal fade" id='<%#"myModalLoginDOTD"+Eval("OfferID") %>' tabindex="-1"
                        role="dialog" style="margin-top: 100px!important;" aria-labelledby="myModalLoginLabel"
                        aria-hidden="true">
                        <div class="modal-dialog" style="width: 350px!important;">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLoginLabel">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            &times;</button>
                                        <i class="fa fa-user"></i>&nbsp;SIGN IN USER</h4>
                                </div>
                                <div class="modal-body">
                                    <uc1:uc_LoginCtrl ID="uc_LoginCtrl1" runat="server" />
                                    <div class="form-group">
                                        <asp:HyperLink ID="hlContinue" Target="_blank" NavigateUrl='<%#Server.UrlDecode(Eval("NavigationUrl").ToString())%>'
                                            runat="server"><b>Continue without login..</b></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
        </div>
        <%-- </div>--%>
    </ItemTemplate>
    <FooterTemplate>
        </div> </div>
    </FooterTemplate>
</asp:Repeater>
