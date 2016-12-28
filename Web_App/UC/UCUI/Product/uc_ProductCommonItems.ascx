<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ProductCommonItems.ascx.cs"
    Inherits="UC_UCUI_Product_uc_ProductCommonItems" %>
<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<asp:Repeater ID="dlItems" runat="server">
    <HeaderTemplate>
        <div class="">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-sm-3 col-xs-12" style="margin-bottom: 10px;">
            <div class="da-row">
                <div class="panel panel-default da-center-block">
                    <div class="panel-body">
                        <div class="row da-center-block-img">
                            <asp:Image ImageUrl='<%#Eval("MerchantLogourl")%>' Width="92px" Height="30px" runat="server"
                                ID="mImage" />
                        </div>
                        <div class="row da-center-block-img">
                            <asp:Image ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=100&height=90&imgPath="+Eval("ImageUrl") %>'
                                runat="server" ID="Image1" />
                        </div>
                        <div class="row da-center-block-Product-title">
                            <h6 title='<%#Eval("ProductTitle")%>' class="itl-tooltip" data-placement="bottom">
                                <div class="row">
                                    <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(string.IsNullOrEmpty(Eval("ProductTitle").ToString())? "" : Eval("ProductTitle").ToString())%></asp:Label>
                                </div>
                            </h6>
                            <div runat="server" class="row" id="divdesc" visible='<%#Eval("DiscountPercentage").ToString() == "" ?true : false%>'>
                                <h6>
                                    <%#Eval("DiscountPercentage").ToString() == "" ? Eval("Description") == null ? "" :ReduceString(Eval("Description").ToString()) : Eval("DiscountPercentage")%></h6>
                            </div>
                        </div>
                        <div class="row da-center-block-Product-Price">
                            <%#Eval("DiscountPercentage").ToString() == "" ? "" : Eval("DiscountPercentage")%>
                        </div>
                    </div>
                    <div class="row da-center-block-btn">
                        <asp:HyperLink ID="hlShop" Target="_blank" data-toggle='<%#Convert.ToBoolean(Eval("ISLOGIN"))?"":"modal" %>'
                            data-target='<%#"#myModalLogin"+Eval("ID") %>' EnableTheming="false" NavigateUrl='<%#Eval("NavigationURL") %>'
                            CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> BUY NOW</asp:HyperLink>
                        <small>
                            <asp:HyperLink ID="HyperLink1" data-toggle="modal" data-target='<%#"#prDetails"+Eval("ID") %>'
                                EnableTheming="true" ForeColor="Green" runat="server" NavigateUrl="#" data-container="body">Detail <i class="fa fa-angle-right"></i></asp:HyperLink>
                        </small>
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
                    <div class="panel-footer da-center-block-footer">
                        <%#Eval("UserCommision") %>
                        <%--<small><i class="fa fa-clock-o"></i>&nbsp;Posted&nbsp;<%#DateTimeAgo.TimeAgo(Eval("CreatedDate").ToString())%>
                    </small>
                   <asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("Description")%>'></asp:Label>--%></div>
                </div>
            </div>
        </div>
        <div class="modal fade" id='<%#"prDetails"+Eval("ID") %>' tabindex="-1" role="dialog"
            style="margin-top: 100px!important;" aria-labelledby="myModalpr" aria-hidden="true">
            <div class="modal-dialog" style="">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalpr">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <%--<i class="fa fa-user"></i>--%>&nbsp;Product's Detail</h4>
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
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
