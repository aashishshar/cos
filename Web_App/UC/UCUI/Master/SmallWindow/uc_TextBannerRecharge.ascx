<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TextBannerRecharge.ascx.cs"
    Inherits="UC_UCUI_Master_SmallWindow_uc_TextBanner" %>
<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<asp:Repeater ID="rptItem" runat="server">
    <HeaderTemplate>
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
                <h4>
                    <b>HOT RECHARGE</b><span class="head-line"></span></h4>
                <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-sm-12 col-xs-6">
            <div class="col-sm-4 lbl-system lbl-white da-leftbox">
                <asp:ImageButton runat="server" PostBackUrl='<%#"~/Merchant/"+Eval("MerchantName")%>'
                    Width="92px" Height="30px" ImageAlign="AbsMiddle" ID="pImage" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "LogoURL")%>' />
            </div>
            <%-- <div>
                        class="hr5" style="margin-top: 3px; margin-bottom: 8px;">
                    </div>
                <div class="da-center-block-btn-right">--%>
            <div class="col-sm-8">
                <b class="da-lbl-white">
                    <asp:HyperLink ID="hlNvigation" runat="server" CssClass="btn-system btn-mini border-btn da-border-btn info"
                        data-toggle='<%#Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"ISLOGIN"))?"":"modal" %>'
                        data-target='<%#"#loginModal"%>' Target="_blank" NavigateUrl='<%#clsUtility.GetTagStringInHtmlString(Eval("BannerURL").ToString(),"href") %>'><i class="fa fa-shopping-cart"></i> Recharge Here</asp:HyperLink>
                       <%-- <span class="da-small-text">+2% Extra Cashback <a href="#">Detail ></a></span>
                    <div class="modal fade" id='<%#"myModalLoginBanner"+Eval("BannerID") %>' tabindex="-1"
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
                                        <asp:HyperLink ID="hlContinue" ClientIDMode="Static" Target="_blank" NavigateUrl='<%#Server.UrlDecode(clsUtility.GetTagStringInHtmlString(Eval("BannerURL").ToString(),"href"))%>'
                                            runat="server"><b>Continue without login..</b></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </b>
            </div>
            <%--</div>--%>
             <div class="clearfix">
                    </div>
                    <hr class="da-thin" />
        </div>
       
    </ItemTemplate>
    <FooterTemplate>
        </div> </div></div>
    </FooterTemplate>
</asp:Repeater>
