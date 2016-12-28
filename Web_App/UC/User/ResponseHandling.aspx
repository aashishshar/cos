<%@ Page Title="" Language="C#" MasterPageFile="~/UC/UserMain.master" AutoEventWireup="true"
    CodeFile="ResponseHandling.aspx.cs" Inherits="UC_User_ResponseHandling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-lg-3 col-md-3 col-sm-3 sidebar left-sidebar">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
                <h4>
                    <b>Payment Summary</b><span class="head-line"></span></h4>
                <div class="row">
                    <div class="col-sm-12 col-xs-6" style="margin-bottom:15px;margin-top:0px;">
                        <p style="text-align: left;text-transform:uppercase;">
                       Order ID : <asp:Label ID="lblTransationNo" runat="server"></asp:Label></p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-9 col-md-9 col-sm-9" style="margin-left: -15px; font-weight: normal!important;">
                            <p style="text-align: left;">
                                Transaction Amount</p>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3" style="margin-left: 15px; font-weight: normal!important;">
                                <p>
                                    <asp:Label ID="lblWalletAmount" runat="server"></asp:Label></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-9 col-md-9 col-sm-9" style="margin-left: -15px; font-weight: normal!important;">
                            <p>
                                Subtotal</p>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3" style="margin-left: 15px; font-weight: normal!important;">
                                <p>
                                    <asp:Label ID="lblTransationAmount" runat="server"></asp:Label></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-9 col-md-9 col-sm-9" style="margin-left: -15px;">
                            <p style="padding-top: 7px; padding-bottom: 7px; border-top: 1px dotted gray; border-bottom: 1px dotted gray;
                                margin-top: 10px; margin-bottom: 10px;">
                                Total Order</p>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3" style="margin-left: 15px;">
                                <p style="padding-top: 7px; padding-bottom: 7px; border-top: 1px dotted gray; border-bottom: 1px dotted gray;
                                    margin-top: 10px; margin-bottom: 10px;">
                                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-9 col-md-9 col-sm-9 sidebar left-sidebar">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
                <h4>
                    <b>RECHARGE / BILL PAYMENT Details</b><span class="head-line"></span></h4>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <asp:Literal ID="litMessage" runat="server"></asp:Literal></div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-1 col-md-1 col-sm-1 lbl-system lbl-white da-leftbox" style="padding: 0px;">
                            <asp:Image runat="server" Width="92px" Height="50px" ImageAlign="AbsMiddle" ID="pImage" />
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-7">
                            <p>
                                <b>
                                    <asp:Label ID="lblRechargeMessage" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label><br />
                                    <%--Payment of Rs. 1 received by Paytm !<br />--%>
                                </b>
                            </p>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4" style="margin-right: -25px; padding-right: 0px;">
                            <p>
                                Order No :
                                <asp:Label ID="lblOrderNo" runat="server"></asp:Label><br />
                                <asp:Label ID="lblTime" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="col-lg-9 col-md-9 col-sm-9">
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2" style="border-top: 1px dotted gray; border-bottom: 1px dotted gray;">
                            <p style="text-align: right;">
                                Total Amount:</p>
                        </div>
                        <div class="col-lg-1 col-md-1 col-sm-1" style="border-top: 1px dotted gray; border-bottom: 1px dotted gray;
                            padding-right: 0px;">
                            <p style="text-align: left;">
                                Rs.<asp:Label ID="lblAmount" runat="server"></asp:Label></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
