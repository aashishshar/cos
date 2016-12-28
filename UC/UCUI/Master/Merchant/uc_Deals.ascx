<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Deals.ascx.cs" Inherits="UC_UCUI_Master_Merchant_uc_Deals" %>
<%@ Register Src="~/UC/MasterHeader/uc_LoginCtrl.ascx" TagName="uc_LoginCtrl" TagPrefix="uc1" %>
<style>
    .product_category_list .extea_discounts
    {
        text-align: center;
    }
    .fl
    {
        float: left;
    }
    .fw
    {
        width: 100%;
    }
    .product_category_list .extea_discounts .cashback
    {
        background: #ff0018;
        color: Green;
        font-size: 11px;
        font-weight: bold;
      
        text-align: center;
        display: block;
    }
</style>
<style>
  .tagcashback
  {
      color:white;
      position:absolute;
      top:2%;
      padding:2px;
      margin-right:15px;
      background-color:Green;
      right:5px;
      font-size:13px;
      border-radius:3px;
      z-index:800; 
      
  }
    
</style>
<asp:DataList ID="dlItems" runat="server" HorizontalAlign="Left" RepeatColumns="4"
    RepeatLayout="Flow">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-md-3">
            <div class="panel panel-default">
                <div class="panel-body" style="text-align: center; height: 200px; min-height: 200px;
                    padding-bottom: 5px!important">
                    <div class="row " style="height: 90px; min-height: 90px; max-height: 90px!important;">
                        <%-- <a href='<%#Eval("NavigationURL") %>' target="_blank">
                            <p class="cashback pos">
                                +2%</p>
                            <p class="no_coupon">
                            </p>
                           <p>
                                <a href="javaScript:void(0);" class="product_tool_tip" data-id="PPS8-364054128">See
                                    Details</a></p>--%>
                        
                        <asp:Image runat="server" ID="Image1" Height="90px" Width="100px" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=100&height=90&imgPath="+Eval("ImageUrl") %>' />
                        <%-- <div class="tagcashback">+50%
                                    </div>--%>
                        <%-- </a>--%>
                    </div>
                    <div class="row" style="height: 40px; min-height: 40px; max-height: 40px!important;
                        margin-left: 1px!important; margin-right: 1px!important;">
                        <h6 title='<%#Eval("ProductTitle")%>' class="itl-tooltip" data-placement="right">
                            <div class="row">
                                <asp:Label ID="lblProductTitle" runat="server"><%#ReduceString(Eval("ProductTitle") == null ? "" : Eval("ProductTitle").ToString())%></asp:Label>
                            </div>
                            <%#Eval("DiscountPercentage").ToString() == "" ? Eval("Description") : ""%>
                            <%-- <asp:Label ID="lblDescription" runat="server" ToolTip='<%#Eval("Description")%>'><%#ReduceString(Eval("Description")==null?"": Eval("Description").ToString())%></asp:Label>--%>
                        </h6>
                    </div>
                    <%-- <div class="row" style="height: 65px; min-height: 65px; max-height: 65px!important;">
                        <h6>
                            <%#Eval("Title") %><br />
                            <asp:Label ID="lblDescription" runat="server" ToolTip='<%#Eval("Description")%>'><%#ReduceString(Eval("Description").ToString())%></asp:Label>
                        </h6>
                    </div>--%>
                    <div class="row" runat="server" id="divPer" style="height: 23px!important;">
                        <%#Eval("DiscountPercentage").ToString() == "" ? "" : Eval("DiscountPercentage")%>
                    </div>
                    <div class="row" style="margin-top: 3px!important;">
                        <asp:HyperLink ID="hlShop" Target="_blank" data-toggle='<%#Convert.ToBoolean(Eval("ISLOGIN"))?"":"modal" %>'
                            data-target='<%#"#myModalLogin"+Eval("ID") %>' EnableTheming="false" NavigateUrl='<%#Eval("NavigationURL") %>'
                            CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i> BUY NOW</asp:HyperLink>
                        <%--    <asp:HyperLink ID="hlShop" Target="_blank" EnableTheming="false" NavigateUrl='<%#Eval("NavigationURL") %>'
                            CssClass="btn-system btn-mini border-btn" runat="server"><i class="fa fa-shopping-cart"></i>&nbsp;BUY NOW</asp:HyperLink>--%>
                        <small>
                            <asp:HyperLink ID="HyperLink1" data-toggle="modal" data-target='<%#"#prDetails"+Eval("ID") %>'
                                EnableTheming="true" ForeColor="Green" runat="server" NavigateUrl="#" data-container="body">Detail <i class="fa fa-angle-right"></i></asp:HyperLink>
                        </small>
                    </div>
                </div>
                <div class="panel-footer" style="padding: 2px 0px 2px 5px; text-align: center;">
                    <small><i class="fa fa-clock-o"></i>&nbsp;Posted&nbsp;<%#DateTimeAgo.TimeAgo(Eval("CreatedDate").ToString())%></small><%--<asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("Description")%>'></asp:Label>--%>
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
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:DataList>