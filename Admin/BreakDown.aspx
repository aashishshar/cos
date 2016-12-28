<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="BreakDown.aspx.cs" Inherits="Admin_BreakDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$=ToValidDateTextBox]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            });
            $("[id$=txtTodate]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            }).datepicker("setDate", "0");
        });
    </script>
    <div class="row">
        <div class="col-lg-12">
            <h2 class="page-header">
                Break-down<small>&nbsp;Add & Update</small>
            </h2>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="row">
            <asp:FormView ID="FormView1" Width="100%" runat="server" DataKeyNames="BreakDownID" DataSourceID="EntityDataSource2">
                <%--  <EditItemTemplate>
                BreakDownID:
                <asp:Label ID="BreakDownIDLabel1" runat="server" 
                    Text='<%# Eval("BreakDownID") %>' />
                <br />
                MID:
                <asp:TextBox ID="MIDTextBox" runat="server" Text='<%# Bind("MID") %>' />
                <br />
                BreakDownText:
                <asp:TextBox ID="BreakDownTextTextBox" runat="server" 
                    Text='<%# Bind("BreakDownText") %>' />
                <br />
                BreakDownStartAmount:
                <asp:TextBox ID="BreakDownStartAmountTextBox" runat="server" 
                    Text='<%# Bind("BreakDownStartAmount") %>' />
                <br />
                BreakDownEndAmount:
                <asp:TextBox ID="BreakDownEndAmountTextBox" runat="server" 
                    Text='<%# Bind("BreakDownEndAmount") %>' />
                <br />
                BreakDownMaxCommission:
                <asp:TextBox ID="BreakDownMaxCommissionTextBox" runat="server" 
                    Text='<%# Bind("BreakDownMaxCommission") %>' />
                <br />
                UserBreakDownMaxCommission:
                <asp:TextBox ID="UserBreakDownMaxCommissionTextBox" runat="server" 
                    Text='<%# Bind("UserBreakDownMaxCommission") %>' />
                <br />
                CommissionType:
                <asp:TextBox ID="CommissionTypeTextBox" runat="server" 
                    Text='<%# Bind("CommissionType") %>' />
                <br />
                ToValidDate:
                <asp:TextBox ID="ToValidDateTextBox" runat="server" 
                    Text='<%# Bind("ToValidDate") %>' />
                <br />
                CreatedDate:
                <asp:TextBox ID="CreatedDateTextBox" runat="server" 
                    Text='<%# Bind("CreatedDate") %>' />
                <br />
                Adv_Mst_Merchant:
                <asp:TextBox ID="Adv_Mst_MerchantTextBox" runat="server" 
                    Text='<%# Bind("Adv_Mst_Merchant") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>--%>
                <InsertItemTemplate>  <div class="form-group">
                    <div class="row">
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlMerchant" AppendDataBoundItems="True" SelectedValue='<%# Bind("MID") %>'
                                DataSourceID="EntityDataSource3" DataTextField="MerchantNameDetail" DataValueField="MID"
                                runat="server">
                                <asp:ListItem Value="-1" Text="Select Merchant" />
                            </asp:DropDownList>
                        </div>
                        <%-- MID:
                <asp:TextBox ID="MIDTextBox" runat="server" Text='<%# Bind("MID") %>' />--%>
                        <div class="col-lg-3">
                            <asp:TextBox ID="BreakDownTextTextBox" placeholder="BreakDownText" runat="server"
                                Text='<%# Bind("BreakDownText") %>' /></div>
                        <div class="col-lg-3">
                            
                            <asp:TextBox ID="BreakDownStartAmountTextBox" placeholder="BreakDownStartAmount" runat="server"
                                Text='<%# Bind("BreakDownStartAmount") %>' /></div>
                        <div class="col-lg-3">
                            
                            <asp:TextBox ID="BreakDownEndAmountTextBox" placeholder="BreakDownEndAmount" runat="server"
                                Text='<%# Bind("BreakDownEndAmount") %>' /></div></div>
                    </div>  <div class="form-group">
                    <div class="row">
                        <div class="col-lg-3">
                            <asp:TextBox ID="BreakDownMaxCommissionTextBox" placeholder="BreakDownMaxCommission"
                                runat="server" Text='<%# Bind("BreakDownMaxCommission") %>' /></div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="UserBreakDownMaxCommissionTextBox" placeholder="UserBreakDownMaxCommission"
                                runat="server" Text='<%# Bind("UserBreakDownMaxCommission") %>' /></div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="CommissionTypeTextBox" placeholder="CommissionType" runat="server"
                                Text='<%# Bind("CommissionType") %>' /></div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="ToValidDateTextBox" placeholder="ToValidDate" ClientIDMode="Static"
                                runat="server" Text='<%# Bind("ToValidDate") %>' /></div>
                        <div class="col-lg-2">
                            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                Text="Submit" />
                            &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" /></div></div>
                    </div>
                </InsertItemTemplate>
                <ItemTemplate>
                    <%-- BreakDownID:
                <asp:Label ID="BreakDownIDLabel" runat="server" 
                    Text='<%# Eval("BreakDownID") %>' />
                <br />
                MID:
                <asp:Label ID="MIDLabel" runat="server" Text='<%# Bind("MID") %>' />
                <br />
                BreakDownText:
                <asp:Label ID="BreakDownTextLabel" runat="server" 
                    Text='<%# Bind("BreakDownText") %>' />
                <br />
                BreakDownStartAmount:
                <asp:Label ID="BreakDownStartAmountLabel" runat="server" 
                    Text='<%# Bind("BreakDownStartAmount") %>' />
                <br />
                BreakDownEndAmount:
                <asp:Label ID="BreakDownEndAmountLabel" runat="server" 
                    Text='<%# Bind("BreakDownEndAmount") %>' />
                <br />
                BreakDownMaxCommission:
                <asp:Label ID="BreakDownMaxCommissionLabel" runat="server" 
                    Text='<%# Bind("BreakDownMaxCommission") %>' />
                <br />
                UserBreakDownMaxCommission:
                <asp:Label ID="UserBreakDownMaxCommissionLabel" runat="server" 
                    Text='<%# Bind("UserBreakDownMaxCommission") %>' />
                <br />
                CommissionType:
                <asp:Label ID="CommissionTypeLabel" runat="server" 
                    Text='<%# Bind("CommissionType") %>' />
                <br />
                ToValidDate:
                <asp:Label ID="ToValidDateLabel" runat="server" 
                    Text='<%# Bind("ToValidDate") %>' />
                <br />
                CreatedDate:
                <asp:Label ID="CreatedDateLabel" runat="server" 
                    Text='<%# Bind("CreatedDate") %>' />
                <br />
                Adv_Mst_Merchant:
                <asp:Label ID="Adv_Mst_MerchantLabel" runat="server" 
                    Text='<%# Bind("Adv_Mst_Merchant") %>' />
                <br />--%>
                    <asp:Button ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                        Text="Add Break-Down" /> <br /> <br />
                </ItemTemplate>
            </asp:FormView>
            <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=Ad_ConnectionString"
                DefaultContainerName="Ad_ConnectionString" EnableFlattening="False" EnableInsert="True"
                EntitySetName="adv_CommissionBreakdown">
            </asp:EntityDataSource>
            <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=Ad_ConnectionString"
                DefaultContainerName="Ad_ConnectionString" EnableFlattening="False" EntitySetName="Adv_Mst_Merchants"
                Select="it.[MID], it.[MerchantNameDetail]">
            </asp:EntityDataSource>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="row">
            <asp:GridView ID="gvItems" runat="server" ClientIDMode="Static" 
                AutoGenerateColumns="False" AutoGenerateEditButton="True" DataKeyNames="BreakDownID"
                DataSourceID="EntityDataSource1">
                <Columns>
                    <asp:BoundField DataField="BreakDownID" HeaderText="BreakDownID" ReadOnly="True"
                        SortExpression="BreakDownID" Visible="False" />
                    <asp:BoundField DataField="MID" HeaderText="MID" SortExpression="MID" Visible="False" />
                    <asp:TemplateField HeaderText="M.Name" SortExpression="BreakDownText">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "Adv_Mst_Merchant.MerchantNameDetail")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BreakDown" SortExpression="BreakDownText">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("BreakDownText") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Text='<%# Bind("BreakDownText") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BreakDownStartAmount" HeaderText="B-DStartAmt" SortExpression="BreakDownStartAmount" />
                    <asp:BoundField DataField="BreakDownEndAmount" HeaderText="B-DEndAmt" SortExpression="BreakDownEndAmount" />
                    <asp:BoundField DataField="BreakDownMaxCommission" HeaderText="B-DMaxCom" SortExpression="BreakDownMaxCommission" />
                    <asp:BoundField DataField="UserBreakDownMaxCommission" HeaderText="UserB-DMaxCom"
                        SortExpression="UserBreakDownMaxCommission" />
                    <asp:BoundField DataField="CommissionType" HeaderText="ComType(1-Rs,0-%)" SortExpression="CommissionType" />
                    <asp:BoundField DataField="ToValidDate" HeaderText="To Date" SortExpression="ToValidDate" />
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=Ad_ConnectionString"
                DefaultContainerName="Ad_ConnectionString" EnableDelete="True" EnableFlattening="False"
                EnableInsert="True" EnableUpdate="True" EntitySetName="adv_CommissionBreakdown"
                EntityTypeFilter="adv_CommissionBreakdown" Include="Adv_Mst_Merchant">
            </asp:EntityDataSource>
        </div>
    </div>
</asp:Content>
