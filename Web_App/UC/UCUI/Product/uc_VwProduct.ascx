<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_VwProduct.ascx.cs"
    Inherits="UC_UCUI_Product_uc_VwProduct" %>
<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<%@ Register Src="uc_ProductCommonItems.ascx" TagName="uc_ProductCommonItems" TagPrefix="uc2" %>
<h4 class="classic-title">
    <span>Feature Product</span></h4>
<%--<asp:ListView ID="ListView1" runat="server">
</asp:ListView>--%>

<uc2:uc_ProductCommonItems ID="dlItems" runat="server" />
<%--<asp:DataList ID="dlItems" runat="server" HorizontalAlign="Left" RepeatColumns="4"
    RepeatLayout="Flow">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-md-3">
            <div class="panel panel-default">
                <div class="panel-body" style="text-align: center; height: 230px; min-height: 230px;
                    padding-bottom: 5px!important">
                    <div class="row" style="height: 31px; min-height: 32px; max-height: 32px!important;">
                       
                        <asp:Image ImageUrl='<%#Eval("MerchantLogourl")%>' Width="92px" Height="30px" runat="server"
                            ID="mImage" />
                      
                    </div>
                    <div class="row" style="height: 91px; min-height: 91px; max-height: 91px!important;">
                        <asp:Image Height="90px" Width="100px" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=100&height=90&imgPath="+Eval("ImageUrl") %>'
                            runat="server" ID="Image1" />
                         <div class="member-name">John Doe <span>Developer</span>
                                    </div>
                    </div>
                    <div class="row" style="height: 40px; min-height: 40px; max-height: 40px!important;
                        margin-left: 1px!important; margin-right: 1px!important;">
                        <h6 title='<%#Eval("ProductTitle")%>' class="itl-tooltip" data-placement="right">
                            <div class="row">
                                <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(Eval("ProductTitle") == null ? "" : Eval("ProductTitle").ToString())%></asp:Label>
                            </div>
                            <div runat="server" id="divdesc" visible='<%#Eval("DiscountPercentage").ToString() == "" ?true : false%>'>
                                <h6>
                                    <%#Eval("DiscountPercentage").ToString() == "" ? Eval("Description") : ""%></h6>
                            </div>
                             <asp:Label ID="lblDescription" runat="server" ToolTip='<%#Eval("Description")%>'><%#ReduceString(Eval("Description")==null?"": Eval("Description").ToString())%></asp:Label>
                        </h6>
                    </div>
                    <div class="row" runat="server" id="divPer" style="height:23px!important;">
                        <%#Eval("DiscountPercentage").ToString() == "" ? "" : Eval("DiscountPercentage")%>
                    </div>
                    <div class="row" style="margin-top:3px!important;">
                        <asp:HyperLink ID="hlShop" Target="_blank" data-toggle='<%#Convert.ToBoolean(Eval("ISLOGIN"))?"":"modal" %>'
                            data-target='<%#"#myModalLogin"+Eval("ID") %>' EnableTheming="false" NavigateUrl='<%#Eval("NavigationURL") %>'
                            CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> BUY NOW</asp:HyperLink>
                        <small>
                            <asp:HyperLink ID="HyperLink1" data-toggle="modal" data-target='<%#"#prDetails"+Eval("ID") %>'
                                EnableTheming="true" ForeColor="Green" runat="server" NavigateUrl="#" data-container="body">Detail <i class="fa fa-angle-right"></i></asp:HyperLink>
                        </small>
                    </div>
                </div>
                <div class="modal fade" id='<%#"myModalLogin"+Eval("ID") %>' tabindex="-1" role="dialog"
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
                                            <asp:HyperLink ID="hlContinue" ClientIDMode="Static" Target="_blank" NavigateUrl='<%#Server.UrlDecode(Eval("NavigationURL").ToString())%>'
                                                runat="server"><b>Continue without login..</b></asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer" style="padding: 1px 0px 1px 1px; text-align: center;">
                    <small><i class="fa fa-clock-o"></i>&nbsp;Posted&nbsp;<%#DateTimeAgo.TimeAgo(Eval("CreatedDate").ToString())%>
                    </small>
                    <%--<asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("Description")%>'></asp:Label></div>
            </div>
            <div class="modal fade" id='<%#"prDetails"+Eval("ID") %>' tabindex="-1" role="dialog"
                style="margin-top: 100px!important;" aria-labelledby="myModalpr" aria-hidden="true">
                <div class="modal-dialog" style="">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalpr">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <%--<i class="fa fa-user"></i>&nbsp;Product's Detail</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <%#Eval("Description") == null ? "No Product Detail found. <br/>Thank you. " : Eval("Description")%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:DataList>--%>
<asp:Repeater ID="rptPager" runat="server">
    <HeaderTemplate>
        <%--<div class="row">
            <div class="col-md-12">--%>
    </HeaderTemplate>
    <ItemTemplate>
        
           <%-- <div class="paginate_button current">--%>
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                    CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                    OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
           <%-- </div>--%>
    </ItemTemplate>
    <FooterTemplate>
        <%--</div></div>--%>
    </FooterTemplate>
</asp:Repeater>
