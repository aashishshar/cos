<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Offers.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Offers" %>
<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<asp:Repeater ID="rpItems" runat="server">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="call-action call-action-style1 " style="padding: 10px;">
            <small class="da-redText"><i class="fa fa-clock-o"></i>&nbsp;Expire on&nbsp;<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small>
            <h1 class="primary">
                <strong>
                    <%#Eval("Title")%></strong></h1>
            <p id="descri" runat="server" visible='<%#Eval("Title")==Eval("Description")?false:true%>'>
                <%#Eval("Description")%></p>
            <div class="hr2" style="margin-top: 25px; margin-bottom: 10px;">
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-5">
                            <a href="<%#"../GoToOffer/"+Eval("OfferID")%>" target="_blank" data-toggle='<%#Eval("ISLOGIN").ToString()=="False"?"modal":"" %>'
                                data-target='<%#"#loginModal" %>' class="btn-system btn-mini"><i class="icon-gift-1">
                                </i>Grab Offer</a> <span class="btn-mini lbl-black da-lbl-system-offer-box">
                                    <%#Eval("ISLOGIN").ToString() == "False" ? "<i class='fa fa-scissors da-marg-right'></i>" + "Login to view coupon" : "<i class='fa fa-scissors da-marg-right'></i>" +Eval("CouponCode")%></span></div>
                        <div class='col-sm-7 da-alignRight'>
                            <h6>
                                <small>
                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"~/Offer/"+Eval("OfferID") %>' Target="_blank"
                                        runat="server"><i class="fa fa-eye">
                                </i>&nbsp;view</asp:HyperLink>
                                </small>
                            </h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="hr1" style="margin-bottom: 5px;">
        </div>
    </ItemTemplate>
    <FooterTemplate>
        <div visible='<%#rpItems.Items.Count == 0 %>' id="EmptyMerchant" style="width: 100%;"
            class="emptyText" runat="server">
            Currently their is no offer on this merchant. Click on "Go to cashback" for extra
            cashback.</div>
        </div>
    </FooterTemplate>
</asp:Repeater>
<%--<a name="sharebutton" type="button" href="http://www.facebook.com/sharer.php">
                                    Share</a>
<small ><i class="fa fa-clock-o"></i>&nbsp;Expire on&nbsp;<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small><small class='da-pipe'>|</small><small ><i class="fa fa-clock-o"></i>&nbsp;Expire on&nbsp;<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small><small class='da-pipe'>|</small><small ><i class="fa fa-clock-o"></i>&nbsp;Expire on&nbsp;<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small> 
+"/"+Server.UrlEncode(clsUtility.RemoveSpecialCharForURL(Eval("Title").ToString()))<div
    class="modal fade in" id='<%#"myModalLoginOffer"+Eval("OfferID") %>' tabindex="-1"
    role="dialog" aria-labelledby="myModalLoginMerchant" aria-hidden="true">
    <div class="modal-dialog da-login-modal" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close pull-right" data-dismiss="modal" id="logclose">
                    <span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                <h3>
                    <i class="fa fa-user"></i>&nbsp;<span>SIGN IN</span></h3>
            </div>
            <section class="clearfix p_sign">
      <div class="modal-body">
        <uc1:uc_LoginCtrl ID="uc_LoginCtrl2" runat="server" />
         <asp:HyperLink ID="hlContinueMerchant" ClientIDMode="Static" CssClass="btn login-btn" style="width:100%;" Target="_blank" NavigateUrl='<%#Server.UrlDecode(Eval("NavigationURL").ToString())%>'
                                                        runat="server"><b>Continue without login..</b></asp:HyperLink>
        
       </div>
                       
                        </section>
        </div>
    </div>
</div>
--%>