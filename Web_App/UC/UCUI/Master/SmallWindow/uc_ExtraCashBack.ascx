<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ExtraCashBack.ascx.cs"
    Inherits="UC_UCUI_Master_SmallWindow_uc_ExtraCashBack" %>
<asp:Repeater ID="rptItem" runat="server">
    <HeaderTemplate>
        <div class="da-activepanel">
            <div class="widget widget-popular-posts ">
                <h4>
                    <b>OUR EXTRA CASHBACK</b> <span class="head-line"></span>
                </h4>
                <div class="row">
    </HeaderTemplate>
    <ItemTemplate>
        <ul>
            <li>
                <div class="col-sm-12 col-xs-6">
                    <div class="col-sm-4 lbl-system lbl-black da-leftbox">
                        <%# Eval("PriceType").ToString() == Constants.PriceType.Percentage.ToString() ? "" : "<i class='fa fa-inr'></i>&nbsp;"%><%# Eval("usercommision") == null ? "0" : Eval("usercommision")%><%# Eval("PriceType").ToString() == Constants.PriceType.Percentage.ToString() ? "%" : ""%></div>
                    <div class="col-sm-8">
                        <b class="da-lbl-black">
                            <div class="row" style="margin-left: 0px;">
                                <%#Eval("ProgramName").ToString()%>
                            </div>
                        </b>
                    </div>
                     <div class="clearfix">
                        </div>
                        <hr class="da-thin" />
                </div>
               
            </li>
        </ul>
    </ItemTemplate>
    <FooterTemplate>
        </div>
        <div visible='<%# rptItem.Items.Count == 0 %>' id="EmptyRep" style="width: 100%;"
            class="emptyText" runat="server">
            No Extra CashBack
        </div>
        </div></div>
    </FooterTemplate>
</asp:Repeater>
