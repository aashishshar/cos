<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeFile="frmSearch.aspx.cs" Inherits="frmSearch" %>

<%@ Register Src="~/UC/UCUI/Product/uc_ProductCommonItems.ascx" TagName="uc_VwProduct"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-3 col-md-3 col-sm-3 sidebar left-sidebar">
        <div class="widget widget-categories">
            <div class="da-activepanel">
                <h4>
                    <b>Categories </b><span class="head-line"></span>
                </h4>
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
            <div class="da-activepanel">
                <h4>
                    <b>Price Range </b><span class="head-line"></span>
                </h4>
                <div class="row">
                    <div class="col-xs-5">
                        <asp:TextBox ID="txtpriceFrom" placeholder="From " CssClass="form-control" runat="server"></asp:TextBox></div>
                    <div class="col-xs-5" style="margin-left: -10px; padding-left: 0px">
                        <asp:TextBox ID="txtPriceTo" CssClass="form-control" placeholder="To" ClientIDMode="Static"
                            runat="server"></asp:TextBox></div>
                    <div class="col-xs-2" style="margin-left: -10px; padding-left: 0px;">
                        <asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go" EnableTheming="false" /></div>
                </div>
            </div>
            <div id="div1" runat="server" clientidmode="Static" style="display: none" class="da-activepanel">
                <h4>
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="Brand"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ClientIDMode="Static"
                    onkeyup="KeyUp(this,'#CheckBoxList1');" placeholder="Search Brand "></asp:TextBox>
                <div class="da-nice-scroll" style="max-height: 150px; min-height: 50px; overflow: auto;
                    margin-top: 3px;">
                    <asp:CheckBoxList ID="CheckBoxList1" RepeatLayout="Table" ClientIDMode="Static" AutoPostBack="true"
                        RepeatDirection="Vertical" RepeatColumns="1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="div2" clientidmode="Static" runat="server" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="Merchant"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList2');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                   ">
                    <div id="dvCheckBoxListControl">
                        <asp:CheckBoxList ID="CheckBoxList2" RepeatLayout="Table" ClientIDMode="Static" RepeatDirection="Vertical"
                            AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                            RepeatColumns="1" runat="server">
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
            <div id="div3" clientidmode="Static" runat="server" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList3');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                    ">
                    <asp:CheckBoxList ID="CheckBoxList3" RepeatLayout="Table" ClientIDMode="Static" OnDataBound="CheckBoxList1_DataBound"
                        RepeatDirection="Vertical" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        RepeatColumns="1" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="div4" runat="server" clientidmode="Static" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList4');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                    ">
                    <asp:CheckBoxList ID="CheckBoxList4" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        RepeatLayout="Table" OnDataBound="CheckBoxList1_DataBound" ClientIDMode="Static"
                        RepeatDirection="Vertical" AutoPostBack="true" RepeatColumns="1" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="div5" runat="server" clientidmode="Static" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList5');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                    ">
                    <asp:CheckBoxList ID="CheckBoxList5" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        RepeatLayout="Table" OnDataBound="CheckBoxList1_DataBound" ClientIDMode="Static"
                        RepeatDirection="Vertical" AutoPostBack="true" RepeatColumns="1" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="div6" runat="server" clientidmode="Static" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox6" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList6');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                    ">
                    <asp:CheckBoxList ID="CheckBoxList6" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        RepeatLayout="Table" OnDataBound="CheckBoxList1_DataBound" ClientIDMode="Static"
                        RepeatDirection="Vertical" AutoPostBack="true" RepeatColumns="1" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="div7" runat="server" clientidmode="Static" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox7" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList7');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                    ">
                    <asp:CheckBoxList ID="CheckBoxList7" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        RepeatLayout="Table" OnDataBound="CheckBoxList1_DataBound" ClientIDMode="Static"
                        RepeatDirection="Vertical" AutoPostBack="true" RepeatColumns="1" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="div8" runat="server" clientidmode="Static" class="da-activepanel" style="display: none">
                <h4>
                    <b>
                        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </b><span class="head-line"></span>
                </h4>
                <asp:TextBox ID="TextBox8" ClientIDMode="Static" runat="server" onkeyup="KeyUp(this,'#CheckBoxList8');"
                    placeholder="Search Merchant"></asp:TextBox>
                <div style="max-height: 150px; min-height: 50px; overflow: auto; margin-top: 3px;
                    ">
                    <asp:CheckBoxList ID="CheckBoxList8" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        RepeatLayout="Table" OnDataBound="CheckBoxList1_DataBound" ClientIDMode="Static"
                        RepeatDirection="Vertical" AutoPostBack="true" RepeatColumns="1" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-9 col-md-9 col-sm-9 page-content">
        <%-- <div class="row" style="text-align: center; border: 1px;border-right-color:White;border-left-color:White;border-color:LightGray;border-style:dashed">
            <asp:LinkButton ID="lnkDiscount" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">Discount</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lnkHighPrice" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">High Price</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lnkLowPrice" OnClick="lnkLowPrice_Click" ForeColor="Gray" runat="server">Low Price</asp:LinkButton>
        </div>--%>
        <div class="">
            <uc1:uc_VwProduct ID="uc_VwProduct1" runat="server" />
        </div>
        <div class="row" align="center">
            <div class="col-lg-12">
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
                            CausesValidation="false" OnClick="lbtnNext_Click" Text="Next"></asp:LinkButton>
                        <asp:LinkButton ID="lbtnLast" runat="server" CssClass="btn-system btn-mini border-btn"
                            CausesValidation="false" OnClick="lbtnLast_Click" Text="Last"></asp:LinkButton></div>
                </div>
            </div>
            <div class="row" align="center">
                <div class="col-lg-12">
                    <asp:Label ID="lblPageInfo" runat="server"></asp:Label></div>
            </div>
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
