<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="MerchantOffers.aspx.cs" Inherits="MerchantOffers" %>

<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<%@ Register Src="UC/UCUI/Master/SmallWindow/uc_BreakDownCommsion.ascx" TagName="uc_BreakDownCommsion"
    TagPrefix="uc7" %>
<%--<%@ Register Src="UC/UCUI/Product/uc_MerchantOffers.ascx" TagName="uc_MerchantOffers"
    TagPrefix="uc1" %>--%>
<%@ Register Src="UC/UCUI/Master/Merchant/uc_Coupons.ascx" TagName="uc_Coupons" TagPrefix="uc2" %>
<%@ Register Src="UC/UCUI/Master/Merchant/uc_Offers.ascx" TagName="uc_Offers" TagPrefix="uc3" %>
<%@ Register Src="UC/UCUI/RightSidebar/uc_MerchantList.ascx" TagName="uc_MerchantList"
    TagPrefix="uc4" %>
<%@ Register Src="UC/UCUI/Master/Merchant/uc_Deals.ascx" TagName="uc_Deals" TagPrefix="uc5" %>
<%@ Register Src="UC/UCUI/Master/SmallWindow/uc_ExtraCashBack.ascx" TagName="uc_ExtraCashBack"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-12 col-md-12 col-sm-12">
        <asp:Repeater ID="fmViewMerchantsHeader" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <%-- <div class="call-action call-action-boxed call-action-style3 clearfix" style="padding: 10px;">
                --%>
                <div class="page-cover">
                    <div class="page-cover-content">
                        <div class="col-sm-2">
                            <div class="vendor-image height105">
                                <asp:Image ID="Image1" runat="server" CssClass="img-responsive" alt='<%#DataBinder.Eval(Container.DataItem, "MerchantNameDetail") %>'
                                    ImageUrl='<%#DataBinder.Eval(Container.DataItem, "MerchantImage") %>' />
                            </div>
                        </div>
                        <div class="col-sm-10">
                            <div class="da-title-name">
                                <%-- <span>  <%#"" + DataBinder.Eval(Container.DataItem, "MerchantNameDetail") + ""%>--%>
                                + Upto&nbsp;<%# DataBinder.Eval(Container.DataItem, "UserCommission")%>&nbsp;extra
                                cashback from cashonshop.com
                            </div>
                            <%--  <h3 class="primary">
                    Online Website</h3>--%>
                            <div class="da-web-type">
                                Online Website</div>
                            <%-- <div class="hr2 white" style="margin-top:25px;margin-bottom:10px;"></div>

                                     <div class="hr2" style="margin-top:10px;margin-bottom:10px;"></div>--%>
                            <div class="cover-actions">
                                <ul class="col-sm-12">
                                    <li class="col-sm-8">
                                        <div style="margin-top: 6px; color: #fff;">
                                            <i class="fa fa-tag"></i><a href="#">Total Offers&nbsp;(<%# (int)DataBinder.Eval(Container.DataItem, "Merchant_Offers.Count")%>)</a></div>
                                    </li>
                                    <li class="col-sm-4">
                                        <asp:HyperLink ID="hlNvigation" runat="server" data-toggle='<%#Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"ISLOGIN"))?"":"modal" %>'
                                            data-target='<%#"#loginModal" %>' EnableTheming="false" Target="_blank" NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "TrackingURL") %>'
                                            CssClass="pull-right btn-system border-btn btn-medium btn-wite btn-icon"> <i class="fa fa-sign-in " ></i> GO TO CASHBACK</asp:HyperLink>
                                    </li>
                                </ul>
                                <div class="modal fade in" id='<%#"myModalLoginMerchant"+Eval("MID") %>' tabindex="-1"
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
         <asp:HyperLink ID="hlContinueMerchant" ClientIDMode="Static" CssClass="btn login-btn" style="width:100%;" Target="_blank" NavigateUrl='<%#Server.UrlDecode(Eval("TrackingURL").ToString())%>'
                                                        runat="server"><b>Continue without login..</b></asp:HyperLink>
        
       </div>
                       
                        </section>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--</div>--%>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <%--  <asp:Button ID="Button1" runat="server" Text="Button" />--%>
    <div class="col-lg-9 col-md-9 col-sm-9">
        <asp:Repeater ID="fmViewMerchants" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-lg-12">
                    <uc3:uc_Offers ID="uc_Offers1" Offers='<%#DataBinder.Eval(Container.DataItem, "Merchant_Offers") %>'
                        runat="server" />
                </div>
              <%--  <div class="hr5" style="margin-top: 60px; margin-bottom: 50px;">
                </div>--%>
               <div class="col-lg-12">
               <div class="row">
                    <h4 class="classic-title">
                        <span>About Merchant</span></h4>
                    <!-- Some Text -->
                    <p>
                        <asp:Literal ID="litMercharDetails" runat="server" Text='<%#Eval("MerchantDetails") %>'></asp:Literal>
                    </p></div>
               </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-3 sidebar right-sidebar">
        <uc6:uc_ExtraCashBack ID="uc_ExtraCashBackList" runat="server" />
        <uc7:uc_BreakDownCommsion ID="uc_BreakDownCommsionDescription" runat="server" />
        <%-- <uc4:uc_MerchantList ID="uc_MerchantList1" runat="server" />--%>
        <br />
        <br />
        <script src="http://ib.adnxs.com/ttj?id=6012073&size=300x600" type="text/javascript"></script>
    </div>
</asp:Content>
