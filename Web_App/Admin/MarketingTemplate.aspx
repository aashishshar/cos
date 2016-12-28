<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="MarketingTemplate.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header">
                Template Design's<small>&nbsp;Add & Run Template Design</small>
            </h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Run Template Design</div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-4">
                                <asp:DropDownList ID="ddlTemplateType" runat="server" >
                                    <%--<asp:ListItem >-- Select --</asp:ListItem>
                                    <asp:ListItem Text="Image Template" Value="ImageTemplate"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-1">
                                <asp:Button runat="server" ID="btnRunTemplateDesign" Text="Generate Code" OnClick="btnRunTemplateDesign_Click" />
                            </div>
                            <div class="col-lg-7">
                                <asp:Label ID="lblmsg" runat="server" CssClass="strMsg"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:TextBox ID="txtCodeGenerate" TextMode="MultiLine" Rows="20" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
