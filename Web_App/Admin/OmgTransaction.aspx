<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="OmgTransaction.aspx.cs" Inherits="Admin_OmgTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$=txtFromdate]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            }).datepicker("setDate", "-2");
            $("[id$=txtTodate]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            }).datepicker("setDate", "0");
            $("[id$=txtFromSearchDate]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            }).datepicker("setDate", "-2");
            $("[id$=txtToSearchDate]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            }).datepicker("setDate", "0");
            //For Transaction Time
            $("[id$=TransactionTimeTextBox]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            }).datepicker("setDate", "0");
        });
    </script>
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header">
                OMG Transaction's<small>&nbsp;Summary</small>
            </h3>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            Manage Transaction
        </div>
        <div class="panel-body">
            <div class="alert alert-info">
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:TextBox ID="txtFromdate" ClientIDMode="Static" placeholder="From Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="txtTodate" ClientIDMode="Static" placeholder="To Date" runat="server"></asp:TextBox>
                        </div>
                        <%-- <div class="col-lg-6">
                            <asp:TextBox ID="txtBannerURL" TextMode="MultiLine" placeholder="Banner URL" runat="server"></asp:TextBox>
                        </div>--%>
                        <div class="col-lg-8">
                            <asp:Button runat="server" Text="Submit" ID="Button1" data-loading-text="Loading..."
                                EnableTheming="false" CssClass="btn btn-outline btn-primary" ValidationGroup="cat"
                                OnClick="btnMerchantNameAdd_Click" />
                            <asp:Button runat="server" Text="Push to DB" ID="btnPushToDB" data-loading-text="Loading..."
                                ValidationGroup="cat" OnClick="btnPushToDB_Click" />
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <!--New Addes for Add OMG Transaction -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="TransactionID" Width="100%"
                        DataSourceID="EntityDataSource1" >
                        <InsertItemTemplate>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="TransactionTimeTextBox" placeholder="Transaction Time" runat="server"
                                            ClientIDMode="Static" Text='<%# Bind("TransactionTime") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="OmgTransactionIDTextBox" placeholder="Omg Transaction ID" runat="server"
                                            Text='<%# Bind("OmgTransactionID") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="UIDTextBox" placeholder="UID" runat="server" Text='<%# Bind("UID") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:DropDownList ID="ddlMerchant" AppendDataBoundItems="True" SelectedValue='<%# Bind("MID") %>'
                                            DataSourceID="EntityDataSource3" DataTextField="MerchantNameDetail" DataValueField="OMGMID"
                                            runat="server">
                                            <asp:ListItem Value="-1" Text="Select Merchant" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="ProductTextBox" placeholder="Product" runat="server" Text='<%# Bind("Product") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="SRTextBox" placeholder="SR" runat="server" Text='<%# Bind("SR") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="VRTextBox" placeholder="VR" runat="server" Text='<%# Bind("VR") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="NVRTextBox" placeholder="NVR" runat="server" Text='<%# Bind("NVR") %>' />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:DropDownList ID="ddlInsertStatus" runat="server">
                                            <asp:ListItem Selected="True" Value="-1">- Status -</asp:ListItem>
                                            <asp:ListItem Value="1">Pending</asp:ListItem>
                                            <asp:ListItem Value="2">Validated</asp:ListItem>
                                            <asp:ListItem Value="0">Rejected</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="PaidTextBox" placeholder="Paid" runat="server" Text='<%# Bind("Paid") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="TransactionValueTextBox" placeholder="Transaction Value" runat="server"
                                            Text='<%# Bind("TransactionValue") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="CommisionTextBox" placeholder="Commision" runat="server" Text='<%# Bind("Commision") %>' />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="UserCommisionTextBox" placeholder="User Commision" runat="server"
                                            Text='<%# Bind("UserCommision") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="MaximumCommisionTextBox" placeholder="Maximum Commision" runat="server"
                                            Text='<%#Convert.ToInt32(Eval("MaximumCommision")) %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="PriceTypeTextBox" placeholder="Price Type" runat="server" Text='<%# Bind("PriceType") %>' />
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="UserPercentageTextBox" placeholder="User Percentage" runat="server"
                                            Text='<%# Bind("UserPercentage") %>' />
                                        <%-- <asp:TextBox ID="FinalCommisionTextBox" placeholder="Final Commision" runat="server"
                                            Text='<%# Bind("FinalCommision") %>' />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12" align="right">
                                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                            Text="Insert" />
                                        &nbsp; &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" /></div>
                                </div>
                            </div>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                                Text="Add Commision" />
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=Ad_ConnectionString"
                        DefaultContainerName="Ad_ConnectionString" EnableFlattening="False" EnableInsert="True"
                        EntitySetName="Adv_OMG_Transactions" EntityTypeFilter="Adv_OMG_Transaction">
                    </asp:EntityDataSource>
                    <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=Ad_ConnectionString"
                        DefaultContainerName="Ad_ConnectionString" EnableFlattening="False" EntitySetName="Adv_Mst_Merchants"
                        Select="it.[OMGMID], it.[MerchantNameDetail]">
                    </asp:EntityDataSource>
                </div>
            </div>
            <!-- -->
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-5">
                        <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                            OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lkbUpdate" EnableTheming="false" CssClass="btn btn-primary"
                            OnClick="lkbUpdate_Click"><i class="fa fa-user"></i>&nbsp;Move to user Histry</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lkbValidateAmount" EnableTheming="false" CssClass="btn btn-primary"
                            OnClick="lkbUpdateValidate_Click">Validate user Amount</asp:LinkButton>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtFromSearchDate" ClientIDMode="Static" placeholder="From Date"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtToSearchDate" ClientIDMode="Static" placeholder="To Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Selected="True" Value="-1">- Status -</asp:ListItem>
                            <asp:ListItem Value="1">Pending</asp:ListItem>
                            <asp:ListItem Value="2">Validated</asp:ListItem>
                            <asp:ListItem Value="0">Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button runat="server" Text="Search" ID="btnSearchTransaction" data-loading-text="Loading..."
                            OnClick="btnSearchTransaction_Click" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-12">
                        <asp:GridView ID="gvItems" ClientIDMode="Static" runat="server" DataKeyNames="TransactionID,OmgTransactionID,omgmerchantref,finalcommision,MerchantName,UserEmail"
                            AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvItems_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelName" runat="server" ToolTip='<%#Eval("Product")%>' Text='<%#Eval("MerchantName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelUser" runat="server" ToolTip='<%#Eval("UserEmail")%>' Text='<%#Eval("UserName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trn. Time" HeaderStyle-Width="95px">
                                    <ItemTemplate>
                                        <%#DateTimeAgo.GetFormatDate(Eval("TransactionTime").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--   <asp:BoundField DataField="ClickTime" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Click Time">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TransactionTime" HeaderText="Trans. Time">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OMGTransactionID" HeaderText="Omg.Trn.ID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OMGMerchantRef" HeaderStyle-Width="95px" HeaderText="M.Trn.ID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <%--  <asp:BoundField DataField="UID" HeaderText="UID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UID2" HeaderText="Banner Type">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="MID" HeaderText="MID">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
          <asp:BoundField DataField="Merchantname" HeaderText="Banner Type">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PID" HeaderText="PID">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>--%>
                                <asp:TemplateField HeaderText="Final Comm.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFinalCommision" Text='<%#Eval("FinalCommision") %>' Width="80px"
                                            runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SR" HeaderText="SR">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VR" HeaderText="VR">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NVR" HeaderText="NVR">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Paid" HeaderText="Paid">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="Completed" HeaderText="Completed">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UKey" HeaderText="UKey">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>--%>
                                <asp:BoundField DataField="TransactionValue" HeaderText="Tran. Value">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="VoucherCode" HeaderText="Voucher Code">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="SendToUser" HeaderText="User Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AmountStatus" HeaderText="Admin Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
