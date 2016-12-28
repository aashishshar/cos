<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/NestedMasters.master"
    AutoEventWireup="true" CodeFile="Masters.aspx.cs" Inherits="Admin_Master_Masters" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/Admin/Master/NestedMasters.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:PlaceHolder ID="phDynamicControls" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
