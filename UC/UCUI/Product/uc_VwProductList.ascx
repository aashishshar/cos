<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_VwProductList.ascx.cs"
    Inherits="UC_UCUI_Product_uc_VwProductList" %>
<%@ Register Src="../Master/Merchant/uc_ProductCommon.ascx" TagName="uc_ProductCommon"
    TagPrefix="uc1" %>
<%@ Register Src="../Master/Merchant/uc_LiveProductFeedData.ascx" TagName="uc_LiveProductFeedData"
    TagPrefix="uc2" %>
<%@ Register Src="../Master/Merchant/uc_OMG_Excel_Product_Feed.ascx" TagName="uc_OMG_Excel_Product_Feed"
    TagPrefix="uc3" %>
<%@ Register src="../Master/Merchant/uc_LiveXmlProductFeed.ascx" tagname="uc_LiveXmlProductFeed" tagprefix="uc4" %>
<%--<script type="text/javascript">
    $(document).ready(function () {
        //For Lower Checkboxes: to check the header checkbox if all are checked otherwise uncheck the header checkbox.
//        $("#<%=gvItems.ClientID%> input[id*='chkDelete']:checkbox").click(function () {
//            //Get number of checkboxes in list either checked or not checked\
//            var totalCheckboxes = $("#<%=gvItems.ClientID%>input[id*='chkDelete']:checkbox").size();
//            //Get number of checked checkboxes in list
//            var checkedCheckboxes = $("#<%=gvItems.ClientID%>input[id*='chkDelete']:checkbox:checked").size();
//            //check and uncheck the header checkbox on the basis of difference of both values
//            $("#<%=gvItems.ClientID%> input[id*='chkAll']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
//        });
//        $("#<%=gvItems.ClientID%>input[id*='chkAll']:checkbox").click(function () {
//            //Header checkbox is checked or not
//            var bool = $("#<%=gvItems.ClientID%>input[id*='chkAll']:checkbox").is(':checked');
//            //check and check the checkboxes on basis of Boolean value
//            $("#<%=gvItems.ClientID%> input[id*='chkDelete']:checkbox").attr('checked', bool);
//        });

        //        $("#<%=gvItems.ClientID%> input[id*='chkDelete']:checkbox").click(function () {
        //            //Get number of checkboxes in list either checked or not checked
        //            var totalCheckboxes = $("#<%=gvItems.ClientID%> input[id*='chkDelete']:checkbox").size();
        //            //Get number of checked checkboxes in list
        //            var checkedCheckboxes = $("#<%=gvItems.ClientID%> input[id*='chkDelete']:checkbox:checked").size();
        //            //Check / Uncheck top checkbox if all the checked boxes in list are checked
        //            $("#<%=gvItems.ClientID%> input[id*='chkAll']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
        //        });

        //        $("#<%=gvItems.ClientID%> input[id*='chkAll']:checkbox").click(function () {
        //            //Check/uncheck all checkboxes in list according to main checkbox 
        //            $("#<%=gvItems.ClientID%> input[id*='chkDelete']:checkbox").attr('checked', $(this).is(':checked'));
        //        });
    });  
</script>
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Campaign's&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButtonList RepeatLayout="Flow"
            RepeatDirection="Horizontal" ID="rblProductFeed" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="rblProductFeed_SelectedIndexChanged">
            <asp:ListItem Text="Live Feed&nbsp;&nbsp;" Value="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Manual&nbsp;&nbsp;" Value="0" ></asp:ListItem>
            <asp:ListItem Text="OMG Exl Upload" Value="2"></asp:ListItem>
             <asp:ListItem Text="&nbsp;&nbsp;OMG XML Live Read &nbsp;&nbsp;" Value="3"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="panel-body">
        <uc2:uc_LiveProductFeedData ID="uc_LiveProductFeedDataList" runat="server" />
        <uc1:uc_ProductCommon ID="uc_ProductCommonList" runat="server" />
        <uc3:uc_OMG_Excel_Product_Feed ID="uc_OMG_Excel_Product_FeedItems" runat="server" />
        <uc4:uc_LiveXmlProductFeed ID="uc_LiveXmlProductFeed1" runat="server" />
&nbsp;<div class="row">
            <div class="form-group">
                <div class="col-lg-12">
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="gvItems" ClientIDMode="Static" runat="server" DataKeyNames="ID"
                        AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MName" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AdTypeName" HeaderText="Type API">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductTitle" HeaderText="Title">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblOffer" runat="server" ToolTip='<%#Eval("Description") %>'><%#ReduceString(Eval("Description") == null ? "" : Eval("Description").ToString())%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Availability" HeaderText="Availability">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="ImageUrl" HeaderText="Valid Till">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NavigationURL" HeaderText="Navigation URL">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>  --%>
                            <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image Height="30px" Width="50px" ImageUrl='<%#"~/Handler/ImageResizeHandler.ashx?width=50&height=30&imgPath="+Eval("ImageUrl") %>'
                                        runat="server" ID="Image1" />
                                   
                                    <div style="width: 50px; height: 50px; text-align: center; background-image: url('~/Images/fkm-loader.gif');
                                        background-repeat: no-repeat;">
                                        <asp:Image ID="imgpRO" ImageUrl='<%#Eval("ImageUrl") %>' Width="50px" Height="50px"
                                            runat="server" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
