<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AllCoupons.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_AllCoupons" %>
<asp:DataList ID="dlItems" runat="server" HorizontalAlign="Left" RepeatColumns="4"
    RepeatLayout="Flow">
    <%--  <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>--%>
    <ItemTemplate>
        <div class="col-md-3">
            <div class="panel panel-default" style="margin-top: 5px!important;">
                <div class="panel-body" style="text-align: center; height: 160px; min-height: 160px;">
                    <div class="row">
                        <%--<%#Eval("MerchantImage")%>--%>
                        <a href='<%#Eval("NavigationURL") %>' target="_blank">
                            <asp:Image runat="server" Width="92px" Height="30px" ID="pImage" ImageUrl='<%#Eval("MerchantImage") %>' />
                        </a>
                    </div>
                    <div class="row" style="height: 75px; min-height: 75px; max-height: 75px!important;">
                        <p>
                            <h6 title='<%#Eval("Offer")%>' class="itl-tooltip" data-placement="right">
                                <asp:Label ID="lblOffer" runat="server" ><%#ReduceString(Eval("Offer").ToString())%></asp:Label>
                            </h6>
                        </p>
                    </div>
                    <div class="row" style="margin-top: 15px!important;">
                        <%--<%#Eval("CID")%>--%>
                        <a href="#" data-toggle="modal" class="btn-system btn-mini border-btn"  data-target='#myModalNew<%#Eval("CID")%>'><i class="fa fa-cut"></i>|COUPON CODE</a>

                      <%--  <asp:HyperLink ID="hlCoupon"  EnableTheming="false" NavigateUrl="#" data-toggle="modal" data-target='#myModalNew+<%#Eval("CID")%>'
                            CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-cut"></i>|COUPON CODE</asp:HyperLink>--%>
                       </div>
                    
                    <div class="modal fade " id='myModalNew<%#Eval("CID")%>' tabindex="-1" role="dialog" style="margin-top: 100px!important;"
                        aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog" style="width: 350px!important;">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLabel">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            &times;</button>
                                       YOUR COUPON CODE IS HERE</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-12"><span class="btn-system btn-large border-btn" style="border:1px dotted red;"> <i class="fa fa-cut"></i>&nbsp;<%#Eval("Coupon")%></span>&nbsp;<asp:HyperLink ID="hlShopNow"  EnableTheming="false" NavigateUrl="#" data-toggle="modal" data-target='#myModalNew+<%#Eval("CID")%>'
                            CssClass="btn-system btn-large border-btn" runat="server"><i class="fa fa-shopping-cart"></i>&nbsp;SHOP NOW</asp:HyperLink>
                            <p><h4><%#Eval("Offer")%></h></p>
                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="modal-footer">
                                   <asp:Button ID="btnCreate" runat="server" Text="Create a group" />
                                    <asp:Label ID="lblMessage" Width="100%" CssClass="text-info" runat="server"></asp:Label>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer" style="padding: 2px 0px 2px 5px; text-align: center;">
                    <small>Valid Till&nbsp;:<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <%--<FooterTemplate>
        </div></FooterTemplate>--%>
</asp:DataList>