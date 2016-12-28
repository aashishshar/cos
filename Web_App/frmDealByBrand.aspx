<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="frmDealByBrand.aspx.cs" Inherits="frmDealByBrand" %>

<%@ Register Src="~/UC/UCUI/Product/uc_ProductCommonItems.ascx" TagName="uc_VwProduct"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-3 sidebar left-sidebar">
        <div class="widget widget-categories">
            <h4>
                <b>Brand </b><span class="head-line"></span>
            </h4>
            <div style="margin-bottom: 25px;">
                <%--style="overflow-y: scroll; height: 400px; margin-bottom: 10px!important">--%>
               <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                    ImageSet="Arrows">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                </asp:TreeView>
            </div>
            <h4>
                <b>Price Range </b><span class="head-line"></span>
            </h4>
            <div style="margin-bottom: 25px;">
                <div class="row">
                    <div class="col-xs-5">
                        <asp:TextBox ID="txtpriceFrom" placeholder="Price From " runat="server"></asp:TextBox></div>
                    <div class="col-xs-5" style="margin-left: -10px; padding-left: 0px">
                        <asp:TextBox ID="txtPriceTo" placeholder="Price To" ClientIDMode="Static" runat="server"></asp:TextBox></div>
                    <div class="col-xs-2" style="margin-left: -10px; padding-left: 0px;">
                        <asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go" EnableTheming="false" /></div>
                </div>
            </div>
            <h4>
                <b>Category </b><span class="head-line"></span>
            </h4>
            <asp:TextBox ID="txtCategory" runat="server" ClientIDMode="Static" onkeyup="KeyUp(this,'#chkCategory');"
                placeholder="Search Category "></asp:TextBox>
            <div style="height: 200px; overflow: auto; margin-top: 3px; margin-bottom: 25px;"
                id="divCategory" runat="server" visible="false">
                <asp:CheckBoxList ID="chkCategory" RepeatLayout="Table" ClientIDMode="Static" AutoPostBack="true"
                    RepeatDirection="Vertical" RepeatColumns="1" runat="server" OnSelectedIndexChanged="chkCategory_SelectedIndexChanged">
                </asp:CheckBoxList>
            </div>
            <h4>
                <b>Merchant </b><span class="head-line"></span>
            </h4>
            <asp:TextBox ID="txtmerchant" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#chkMerchant');"
                placeholder="Search Merchant"></asp:TextBox>
            <div style="height: 130px; overflow: auto; margin-top: 3px; margin-bottom: 25px;"
                id="divmerchant" runat="server" visible="false">
                <div id="dvCheckBoxListControl">
                    <asp:CheckBoxList ID="chkMerchant" RepeatLayout="Table" ClientIDMode="Static" RepeatDirection="Vertical"
                        AutoPostBack="true" RepeatColumns="1" runat="server" OnSelectedIndexChanged="chkMerchant_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-9 page-content">
        <div class="row" style="text-align: center;">
            <div class="col-lg-12" style="text-align: center;">
                <span style="margin-right: 20px">
                    <asp:LinkButton ID="lnkDiscount" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">Discount</asp:LinkButton></span>
                <span style="margin-right: 20px">
                    <asp:LinkButton ID="lnkHighPrice" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">High Price</asp:LinkButton></span>
                <span style="margin-right: 20px">
                    <asp:LinkButton ID="lnkLowPrice" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">Low Price</asp:LinkButton></span>
            </div>
        </div>
        <div class="hr5" style="margin-top: 10px; margin-bottom: 15px;">
        </div>
        <div class="row">
            <uc1:uc_VwProduct ID="uc_VwProduct1" runat="server" />
        </div>
       <div class="row" align="center">
            <div class="col-lg-12" style="width: 100%; text-align: center; background-color: #F5F5F5;">
                <asp:LinkButton ID="lbtnFirst" runat="server" CssClass="btn-system btn-mini border-btn"
                    CausesValidation="false" OnClick="lbtnFirst_Click" Text="First"></asp:LinkButton>
                <asp:LinkButton ID="lbtnPrevious" runat="server" CssClass="btn-system btn-mini border-btn"
                    CausesValidation="false" OnClick="lbtnPrevious_Click" Text="Previous"></asp:LinkButton>
                <asp:Repeater ID="dlPaging" runat="server" OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                            CssClass="btn-system btn-mini border-btn" CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>&nbsp;
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinkButton ID="lbtnNext" runat="server" CssClass="btn-system btn-mini border-btn"
                    CausesValidation="false" OnClick="lbtnNext_Click" Text="Next" ></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" CssClass="btn-system btn-mini border-btn"
                    CausesValidation="false" OnClick="lbtnLast_Click" Text="Last"></asp:LinkButton></div>
        </div>
        <div class="row" align="center">
            <div class="col-lg-12">
              <b><asp:Label ID="lblPageInfo" runat="server"></asp:Label></b>  </div>
        </div>
    </div>
    <script type="text/javascript">
        function KeyUp(txtboxID, chklistboxID) {
            if ($(txtboxID).val() != "") {

                $(chklistboxID).children('tbody').children('tr').each(function () {
                    $(this).show();
                });

                $(chklistboxID).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtboxID).val().toUpperCase()) > -1) match = true;
                    });
                    if (match) $(this).show();
                    else $(this).hide();
                });
            }
            else {

                $(chklistboxID).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
            }
        }

    </script>
</asp:Content>
