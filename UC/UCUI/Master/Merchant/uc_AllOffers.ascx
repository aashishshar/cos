<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AllOffers.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_AllOffers" %>
<%@ Register Src="../../../MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl"
    TagPrefix="uc1" %>
<asp:Repeater ID="rpItems" runat="server">
    <HeaderTemplate>
        <%-- <div class="row">--%>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="call-action call-action-style1 clearfix" style="padding: 10px;">
            <div class="col-md-2" style="padding-right: 5px!important;">
                <asp:Image runat="server" class="img-thumbnail image-text" ID="pImage" ImageUrl='<%#Eval("MerchantImage") %>' />
            </div>
            <div class="col-md-10">
                <h2 class="primary">
                    <%#Eval("Title")%></h2>
                <p>
                    <%#Eval("Description")%></p>
                <p>
                    <a href="<%#Server.UrlDecode(Eval("NavigationURL").ToString())%>" target="_blank"
                        class="btn-system btn-mini border-btn" data-toggle='<%#Eval("ISLOGIN").ToString()=="False"?"modal":"" %>'
                        data-target='<%#"#myModalLogin"+Eval("OfferID") %>'><i class="icon-gift-1"></i>
                        Grab Offer</a> <a href="<%#Server.UrlDecode(Eval("NavigationURL").ToString())%>" target="_blank"
                            class="btn-system btn-mini border-btn btn-black">
                            <%#Eval("ISLOGIN").ToString() == "False" ? "coupon will shown here" : "Coupon:&nbsp;" + Eval("CouponCode")%></a>
                    <%--<a
                                href="#" data-toggle="modal" data-target="#myModalLogin"><i class="fa fa-lock"></i>&nbsp;LOGIN</a>--%>
                    <small><i class="fa fa-clock-o"></i>&nbsp;Expire on&nbsp;
                        <%#Eval("ValidTill") != null ? DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString()) : "running now"%></small>


                    <div class="modal fade" id='<%#"myModalLogin"+Eval("OfferID") %>' tabindex="-1" role="dialog"
                        style="margin-top: 100px!important;" aria-labelledby="myModalLoginLabel" aria-hidden="true">
                        <div class="modal-dialog" style="width: 350px!important;">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLoginLabel">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                            &times;</button>
                                        <i class="fa fa-user"></i>&nbsp;SIGN IN USER</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <uc1:uc_LoginCtrl ID="uc_LoginCtrl1" runat="server" />
                                            <div class="form-group">
                                                <asp:HyperLink ID="hlContinue"  ClientIDMode="Static" Target="_blank" NavigateUrl='<%#Server.UrlDecode(Eval("NavigationURL").ToString())%>'
                                                    runat="server"><b>Continue without login..</b></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </p>
            </div>
        </div>
        <div class="hr1" style="margin-bottom: 4px;">
        </div>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>
