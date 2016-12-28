<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Coupons.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Coupons" %>
<asp:DataList ID="dlItems" runat="server" HorizontalAlign="Left" RepeatColumns="4"
    RepeatLayout="Flow">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-md-3">
            <div class="panel panel-default">
                <div class="panel-body" style="text-align: center; height: 120px; min-height: 120px;">
                    <%--<asp:Image runat="server" ID="pImage" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=100&height=90&imgPath="+Eval("ImageUrl") %>' />--%>
                    <!-- End Project Thumb -->
                    <!-- Start Project Details -->
                    <div class="row" style="height: 80px!important;">
                        <a href='<%#Eval("NavigationURL") %>' target="_blank">
                          <b> <%#ReduceString(Eval("Offer").ToString())%></b>
                        </a>
                    </div>
                    <div class="row">
                        <asp:HyperLink ID="hlShop" Target="_blank" style="border:1px dotted red;" EnableTheming="false" NavigateUrl='<%#Eval("NavigationURL") %>'
                            CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-cut"></i>&nbsp;<%#Eval("ISLOGIN").ToString() == "False" ? "Login for coupon" : "" + Eval("Coupon")%></asp:HyperLink>
                    </div>
                </div>
                <div class="panel-footer" style="padding: 2px 0px 2px 5px;">
                    <small>#Valid Till&nbsp;:<%#DateTimeAgo.GetFormatDate(Eval("ValidTill").ToString())%></small>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div></FooterTemplate>
</asp:DataList>