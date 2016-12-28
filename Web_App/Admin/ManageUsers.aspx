<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ManageUsers.aspx.cs" Inherits="Admin_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   <%-- <script type="text/javascript">
        function makeButtonsVisible() {
            //$("#discontinueButton").removeClass("invisible");

            $("#<%=deleteButton.ClientID%>").removeClass("invisible");
        }
        function makeButtonsInvisible() {
            //$("#discontinueButton").addClass("invisible");
            $("#<%=deleteButton.ClientID%>").addClass("invisible");
        }
        function toggleDiscontinueDelete() {
            // Check if 'Action' button is checked or not
            if ($("#chkAction").is(':checked')) {
                // Select all Products in Grid
                $("input[id*='chkSelect']").prop("checked", true);
                // Make discontinue and delete buttons visible
                makeButtonsVisible();
            }
            else {
                // Unselect all Products in grid
                $("input[id*='chkSelect']").prop("checked", false);
                // Make discontinue and delete buttons Invisible
                makeButtonsInvisible();
            }
        }
        function selectAllProducts() {
            // Uncheck the 'Action' button
            $("#chkAction").prop("checked", true);

            // Select all Products in Grid
            $("input[id*='chkSelect']").prop("checked", true);

            // Make discontinue and delete buttons visible
            makeButtonsVisible();
        }

        function unselectAllProducts() {
            // Uncheck the 'Action' button
            $("#chkAction").prop("checked", false);

            // Unselect all Products in grid
            $("input[id*='chkSelect']").prop("checked", false);

            // Make discontinue and delete buttons Invisible
            makeButtonsInvisible();
        }


        $(function () {
            // Get all checkboxes in grid
            // They all will contain 'chkSelect'
            var checkboxes = $("input[id*='chkSelect']");

            // Connect to click event.
            checkboxes.click(function () {
                // If any are checked, make Discontinue and Delete
                // buttons visible
                if (checkboxes.is(":checked")) {
                    makeButtonsVisible();
                }
                else {
                    makeButtonsInvisible();
                }
            });
        })
        $(document).ready(function () {
            // init bootpag
            var count = GetTotalPageCount();
            $('#page-selection').bootpag(
                {
                    total: count
                }).on("page", function (event, num) {
                    GetGridData(num);
                });
        });

        function GetGridData(num) {
            $.ajax({
                type: "POST",
                url: "ManageUsers.aspx/GetAllUserByPage",
                data: "{ \"pageNo\":" + num + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    bindGrid(data.d);
                },
                error: function (xhr, status, err) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);

                }
            });
        }

        function bindGrid(data) {
            $("[id*=gvUsersList] tr").not(":first").not(":last").remove();
            var table1 = $('[id*=gvUsersList]');
            var firstRow = "$('[id*=gvUsersList] tr:first-child')";
            for (var i = 0; i < data.length; i++) {
                var rowNew = $("<tr><td></td><td></td><td></td><td></td><td></td></tr>");
                var t = "<span userid='" + data[i].UserName + "'><input id='MainContent_gvUsersList_chkSelect_" + i + "' type='checkbox' name='ctl00$MainContent$gvUsersList$ctl02$chkSelect_'" + i + "></input></span>";
                //var idC = document.getElementById("MainContent_gvUsersList_chkSelect_" + i);
                //alert(t);
                //idC.attributes["UserId"] = data[i].UserName;
                //rowNew.children().eq(0).text.apply(t);
                rowNew.children().eq(1).text(data[i].UserName);
                rowNew.children().eq(2).text(data[i].Email);
                rowNew.children().eq(3).text(data[i].IsLockedOut);
                rowNew.children().eq(4).text(formatJSONDate(data[i].CreationDate));
                //var btnEntry = document.getElementById("MainContent_gvUsersList_imgDelete_0");

                rowNew.insertBefore($("[id*=gvUsersList] tr:last-child"));
            }
        }
        function formatJSONDate(dateValue) {
            var value = new Date(parseInt(dateValue.replace(/(^.*\()|([+-].*$)/g, '')));
            var newDate = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
            return newDate;
        }
        function GetTotalPageCount() {
            var mytempvar = 0;
            $.ajax({
                type: "POST",
                url: "ManageUsers.aspx/GetTotalPageCount",
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    mytempvar = data.d;

                },
                error: function (xhr, status, err) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);

                }
            });
            return mytempvar;
        }
    </script>--%>
    <div class="row">
        <div class="col-lg-12">
            <h2 class="page-header">
                Manage User's
            </h2>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    User(s) List</div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <div id="dataTables-example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div id="dataTables-example_length" class="dataTables_length">
                                        <%-- <div class="form-group input-group">
                                        <input class="form-control" type="text"></input>
                                        <span class="input-group-btn">
                                            <button class="btn btn-default" type="button">
                                                <i class="fa fa-search"></i>
                                            </button>
                                        </span>
                                    </div>--%>
                                        <div class="btn-group">
                                           <%-- <div class="btn btn-primary btn-checkbox">
                                                <input type="checkbox" onclick="toggleDiscontinueDelete();" class="checkbox-inline"
                                                    id="chkAction" />
                                            </div>
                                            <button class="btn btn-primary dropdown-toggle" style="height: 34px;" data-toggle="dropdown">
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a href="#" onclick="selectAllProducts();">All</a> </li>
                                                <li><a href="#" onclick="unselectAllProducts();">None</a> </li>
                                            </ul>--%>
                                        </div>
                                        <%--<button class="btn btn-danger" type="button">
                                            <i class="glyphicon glyphicon-trash"></i> Danger
                                        </button>--%>
                                       <%-- <a class="btn btn-danger invisible" id="deleteButton" runat="server" onserverclick="deleteButton_ServerClick">
                                            <i class="glyphicon glyphicon-trash"></i>Delete</a>--%>
                                        <%--  <label>
                                            <asp:DropDownList ID="ddlRecordPerPage" EnableTheming="false" CssClass="form-control input-sm"
                                                runat="server">
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>100</asp:ListItem>
                                            </asp:DropDownList>
                                            records per page</label>--%>
                                    </div>
                                </div>
                                <%--<div class="col-sm-6">
                                    <div id="dataTables-example_filter" class="dataTables_filter">
                                        <label>
                                            Search:
                                            <input class="form-control input-sm" type="search" aria-controls="dataTables-example"></input>
                                        </label>
                                    </div>
                                </div>--%>
                            </div>
                            <asp:GridView ID="gvItems" runat="server" ClientIDMode="Static"  AutoGenerateColumns="False"
                                Width="100%" OnPreRender="gvUsersList_PreRender">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Select">

                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" UserId='<%# Eval("UserName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" UserId='<%# Eval("UserName") %>'></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:BoundField DataField="UserName" HeaderText="User Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsLockedOut" HeaderText="Is Locked">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastLoginDate" HeaderText="Last login" DataFormatString="{0:d}">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CreationDate" HeaderText="Create Date" DataFormatString="{0:d}">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <%--<PagerTemplate>
                                    <div id="page-selection" class="pagination-centered">
                                    </div>
                                </PagerTemplate>
--%>                            </asp:GridView>
                            <div class="row">
                                <div class="col-sm-6">
                                </div>
                                <div class="col-sm-6" style="visibility: hidden;">
                                    <div id="NavigationPanel" visible="false" runat="server" class="dataTables_paginate paging_simple_numbers">
                                        <%-- <ul class="pagination">
                                            <li id="dataTables-example_previous" class="paginate_button previous" aria-controls="dataTables-example"
                                                tabindex="0"><a href="#">Previous </a></li>
                                            <li class="paginate_button" aria-controls="dataTables-example" tabindex="0"><a href="#">
                                                1 </a></li>
                                            <li id="dataTables-example_next" class="paginate_button next disabled" aria-controls="dataTables-example"
                                                tabindex="0"><a href="#">Next </a></li>
                                        </ul>--%>
                                        <table border="0" cellpadding="3" cellspacing="3">
                                            <tr class="pagination">
                                                <td style="width: 100">
                                                    Page
                                                    <asp:Label ID="CurrentPageLabel" runat="server" />
                                                    of
                                                    <asp:Label ID="TotalPagesLabel" runat="server" />
                                                </td>
                                                <td style="width: 60">
                                                    <asp:LinkButton ID="PreviousButton" CssClass="paginate_button previous" aria-controls="dataTables-example"
                                                        Text="< Prev" OnClick="PreviousButton_OnClick" runat="server" />
                                                </td>
                                                <td style="width: 60">
                                                    <asp:LinkButton ID="NextButton" CssClass="paginate_button next disabled" aria-controls="dataTables-example"
                                                        Text="Next >" OnClick="NextButton_OnClick" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Manage Role
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtRoleName" placeholder="Role name" Width="242px" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <asp:Button runat="server" Text="Add Role.." ID="btnRoleName" OnClick="btnRoleName_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:GridView ID="gvRoles" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                            Width="100%" PageSize="5" OnPageIndexChanging="gvRoles_PageIndexChanging" OnRowCommand="gvRoles_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Role Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" CommandName="delRole" CommandArgument='<%#Eval("Name") %>'
                                            ImageUrl="~/Images/delete-xxl.png" Width="16px" Height="16px" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!--

             /.panel-body 

            -->
            </div>
            <!--

         /.panel 

        -->
        </div>
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Create user</div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:TextBox ID="txtUserName" placeholder="User Name " runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email ID"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlRoleList" runat="server" Width="200px" OnSelectedIndexChanged="ddlRoleList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnAddUserName" Text="Add user" OnClick="btnAddUserName_Click" />
                        <asp:Label ID="lblUserCreate" runat="server" CssClass="strMsg"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
