<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="frmViewOffer.aspx.cs" Inherits="frmViewOffer" %>

<%@ Register Src="UC/UCUI/Master/SmallWindow/uc_ExtraCashBack.ascx" TagName="uc_ExtraCashBack"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-9 col-md-9 col-sm-9">
        <asp:Repeater ID="rpItems" runat="server">
            <HeaderTemplate>
                <div class="call-action call-action-style1 " style="padding: 10px;padding-left:10px; min-height: 450px;">
                    <h4 class="classic-title">
                       <b><span>Offer Detail</span></b> 
                    </h4>
            </HeaderTemplate>
            <ItemTemplate>
                <%--<div class="call-action call-action-style1 " style="padding: 5px;min-height:450px;">
                --%>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="col-sm-2 vendor-image height105">
                            <asp:Image ID="Image1" runat="server" CssClass="img-responsive" alt='<%#DataBinder.Eval(Container.DataItem, "Adv_Mst_Merchant.MerchantNameDetail") %>'
                                ImageUrl='<%#DataBinder.Eval(Container.DataItem, "Adv_Mst_Merchant.LogoUrl") %>' />
                        </div>
                        <div class="col-sm-10">
                            <small class="da-redText"><i class="fa fa-clock-o"></i>&nbsp;Expire on&nbsp;<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small><h1
                                class="primary">
                                <strong>
                                    <%#Eval("Title")%></strong></h1>
                            <p id="descri" runat="server" visible='<%#Eval("Title")==Eval("Description")?false:true%>'>
                                <%#Eval("Description")%></p>
                            <div class="hr2" style="margin-top: 25px; margin-bottom: 10px;">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-10">
                            <a href="<%#"../GoToOffer/"+Eval("OfferID")%>" target="_blank" data-toggle="modal"
                                data-target='<%#"#loginModal" %>' class="btn-system btn-mini"><i class="icon-gift-1">
                                </i>Grab Offer</a> <span class="btn-mini lbl-black da-lbl-system-offer-box">
                                    <%#IsUserLogin().ToString() == "False" ? "<i class='fa fa-scissors da-marg-right'></i>" + "Login to view coupon" : "<i class='fa fa-scissors da-marg-right'></i>" + Eval("CouponCode")%></span></div>
                        <div class='col-sm-7 da-alignRight'>
                        </div>
                    </div>
                </div>
                <%--  <div class="hr1" style="margin-bottom: 5px;">
                </div>--%>
            </ItemTemplate>
            <FooterTemplate>
                </div>
                <div visible='<%#rpItems.Items.Count == 0 %>' id="EmptyMerchant" style="width: 100%;"
                    class="emptyText" runat="server">
                    Currently their is no offer on this merchant. Click on "Go to cashback" for extra
                    cashback.</div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-3 sidebar right-sidebar">
        <uc6:uc_ExtraCashBack ID="uc_ExtraCashBackList" runat="server" />
    </div>
</asp:Content>
