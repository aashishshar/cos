<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Commision.ascx.cs"
    Inherits="UC_UCUI_Master_Merchant_uc_Commision" %>
<%@ Register Src="uc_MerchantList.ascx" TagName="uc_MerchantList" TagPrefix="uc1" %>
<div class="panel panel-default">
    <div class="panel-heading">
        Manage Commsion
    </div>
    <div class="panel-body">
        <div class="alert alert-info">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <uc1:uc_MerchantList ID="uc_MerchantDDlList" runat="server" />
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtPID" placeholder="PID" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtProgramName" placeholder="Program Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtCommision" placeholder="Commision Amount" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtUserCommision" placeholder="UserCommision" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlPayoutType" placeholder="UserCommision" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtCookieDuration" placeholder="Cookie Duration" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlProductfeedAvailable" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlUIDTracking" ToolTip="UID Tracking" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlDeepLinkEnabled" runat="server" ToolTip="DeepLink Enabled">
                        </asp:DropDownList>
                    </div>
                    <%--  <div class="col-lg-2">
                        <asp:TextBox ID="txtMerchantLogoUrl" placeholder="Logo URL" runat="server"></asp:TextBox>
                    </div>--%>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtProductDescription" placeholder="Program Desc" runat="server"></asp:TextBox>
                    </div>
                    <%--<div class="col-lg-1">
                        <asp:TextBox ID="txtSector" placeholder="Sector" runat="server"></asp:TextBox>
                    </div>--%>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtWebsiteUrl" placeholder="Website Url" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtTrackingURL" placeholder="TrackingURL" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlPriceType" runat="server" ToolTip="Price Type">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlCurrency" runat="server" ToolTip="Currency">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlStatus" runat="server" ToolTip="Status">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button runat="server" Text="Submit" ID="Button1" EnableTheming="false" CssClass="btn btn-outline btn-primary"
                            ValidationGroup="commisionCatVGroup" OnClick="btnMerchantNameAdd_Click" />
                        <asp:Button runat="server" Text="Get" ID="btnPushToDB" EnableTheming="true" CssClass="btn btn-outline btn-primary"
                            ValidationGroup="commisionCatVGroup" OnClick="btnPushToDB_Click" />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-lg-12">
                    <asp:LinkButton runat="server" ID="Delete" EnableTheming="false" CssClass="btn  btn-danger"
                        OnClick="Delete_Click"><i class="fa fa-trash-o"></i>&nbsp;Delete All</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lkbUpdate" EnableTheming="false" 
                        CssClass="btn btn-success" onclick="lkbUpdate_Click"
                        >Update All</asp:LinkButton>
                         <asp:LinkButton runat="server" ID="lkbDeactive" EnableTheming="false" 
                        CssClass="btn btn-success" onclick="lkbDeactive_Click" 
                        >Active/Deactive</asp:LinkButton>
                </div>
            </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-12">
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                        <asp:GridView ID="gvItemsCOM" ClientIDMode="Static"  runat="server" DataKeyNames="CommisionID"
                            AutoGenerateColumns="False" Width="100%" >
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRow" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Merchant Name">
                                    <ItemTemplate><%#Eval("MerchantName")%>
                                        <%--<div class="tooltip-demo">
                                            <asp:Image ID="imgMerchnatLogo" data-toggle="tooltip" data-placement="right" title='<%#Eval("MerchantName")%>'
                                                AlternateText='<%#Eval("MerchantName")%>' Width="80px" Height="25px" ImageUrl='<%#Eval("MerchantLogoUrl")%>'
                                                runat="server" />
                                        </div>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:BoundField DataField="MerchantName" HeaderText="Merchant Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PID" HeaderText="PID">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                                <asp:TemplateField HeaderText="Program Name">
                                    <ItemTemplate>
                                        <%--<div class="tooltip-demo">
                                            <asp:Label data-toggle="tooltip" data-placement="right" title='<%#Eval("ProductDescription")%>'
                                                runat="server" Text='<%#Eval("ProgramName")%>'></asp:Label>
                                        </div>--%>
                                         <asp:TextBox ID="txtTitle" MaxLength="147" runat="server" Text='<%#Eval("ProgramName") %>'
                                            Width="260px" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="Commision" HeaderText="Commision">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <asp:TemplateField HeaderText="Commision">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCommision" MaxLength="10" runat="server" Text='<%#Eval("Commision") %>'
                                            Width="70px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Com.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUserCommision" MaxLength="4" runat="server" Text='<%#Eval("UserCommision") %>'
                                            Width="70px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Max Comm.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMaxCommision" MaxLength="4" runat="server" Text='<%#Eval("MaximumCommision") %>'
                                            Width="70px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PriceType" HeaderText="Price Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="PayoutType" HeaderText="Payout Type">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                                <asp:BoundField DataField="DeepLinkEnabled" HeaderText="DeepLink">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProductfeedAvailable" HeaderText="Pro. feed">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UIDTracking" HeaderText="UID">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="Status" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="TrackingURL" HeaderText="Currency">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
<script>
    // tooltip demo
    $('.tooltip-demo').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    })

    // popover demo
    $("[data-toggle=popover]")
        .popover()
</script>
