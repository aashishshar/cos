<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 <div class="well">
    <a href="#" data-toggle="modal" class="btn btn-primary" style="width: 100%;" data-target="#myModal">
        <i class="fa fa-group"></i>&nbsp;Create a new group</a>
   
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <i class="fa fa-group"></i>&nbsp;Create User Group</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtGroup" runat="server" Width="100%" placeholder="Enter a group name here.." />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                    <asp:Button ID="btnCreate" runat="server" Text="Create a group"  />
                    <asp:Label ID="lblMessage" Width="100%" CssClass="text-info" runat="server"></asp:Label>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
                <%--<script>
                    // tooltip demo
                    $('.tooltip-demo').tooltip({
                        selector: "[data-toggle=tooltip]",
                        container: "body"
                    })

                    // popover demo
                    $("[data-toggle=popover]")
        .popover()
    </script>--%>
</asp:Content>
