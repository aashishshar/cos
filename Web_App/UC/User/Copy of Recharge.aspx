<%@ Page Title="" Language="C#" MasterPageFile="~/UC/UserMain.master" AutoEventWireup="true"
    CodeFile="Copy of Recharge.aspx.cs" Inherits="Recharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script src="jquery-1.3.2.min.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-lg-3 col-md-3 col-sm-3 sidebar left-sidebar">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
                <h4>
                    <b>RECHARGE</b><span class="head-line"></span></h4>
                <div class="row">
                    <div class="col-sm-12 col-xs-6">
                        <div class="form-group">
                          <asp:TextBox ID="txtMobileno" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Enter Mobile No."
                    onkeyup="ValidateOperator();return false;" MaxLength="10" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-12 col-xs-6">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlOperator" CssClass="form-control" ClientIDMode="Static"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-12 col-xs-6">
                        <div class="form-group">
                            <asp:TextBox ID="txtAmount" CssClass="form-control" placeholder="Enter Amount" ClientIDMode="Static"
                                runat="server" MaxLength="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-12 col-xs-6">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlCircle" CssClass="form-control" ClientIDMode="Static" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-12 col-xs-6">
                        <div class="form-group">
                          <asp:Button ID="btnRecharge" OnClientClick="RechargeMobile();return false;" runat="server" Text="Recharge" />
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <span class="text-success">
                                <div id="subscribemsg">
                                </div>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-9 col-md-9 col-sm-9 sidebar right-sidebar">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
                <h4>
                    <b>Plans of All Operators</b><span class="head-line"></span></h4>
                <div class="tabs-section">
                    <!-- Nav Tabs -->
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#tab-1" data-toggle="tab">Top Up </a></li>
                        <li class=""><a href="#tab-2" data-toggle="tab">Full TalkTime</a></li>
                        <li class=""><a href="#tab-3" data-toggle="tab">2G</a></li>
                        <li class=""><a href="#tab-4" data-toggle="tab">3G/4G</a></li>
                        <li class=""><a href="#tab-5" data-toggle="tab">LOCAL/STD/ISD</a></li>
                        <li class=""><a href="#tab-6" data-toggle="tab">Roaming</a></li>
                    </ul>
                    <!-- Tab panels -->
                    <div class="tab-content">
                        <!-- Tab Content 1 -->
                        <div class="tab-pane fade active in" id="tab-1">
                            <div class="table-responsive">
                                <div class="da-nice-scroll" style="max-height: 450px; min-height: 450px; overflow: auto;
                                    margin-top: 3px;">
                                    <table id="tbTopUP" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Detail</td>
<td>Validity</td>
<td>Amount</td>
</tr>
</thead>
<tbody>
</tbody>
</table>
                                </div>
                            </div>
                        </div>
                        <!-- Tab Content 2 -->
                        <div class="tab-pane fade" id="tab-2">
                            <div class="table-responsive">
                                <div class="da-nice-scroll" style="max-height: 450px; min-height: 450px; overflow: auto;
                                    margin-top: 3px;">
                                     <table id="tbFulltacktime" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Detail</td>
<td>Validity</td>
<td>Amount</td>
</tr>
</thead>
<tbody>
</tbody>
</table>
                                </div>
                            </div>
                        </div>
                        <!-- Tab Content 3 -->
                        <div class="tab-pane fade" id="tab-3">
                            <div class="table-responsive">
                                <div class="da-nice-scroll" style="max-height: 450px; min-height: 450px; overflow: auto;
                                    margin-top: 3px;">
                                     <table id="tb2g" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Detail</td>
<td>Validity</td>
<td>Amount</td>
</tr>
</thead>
<tbody>
</tbody>
</table>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="tab-4">
                            <div class="table-responsive">
                                <div class="da-nice-scroll" style="max-height: 450px; min-height: 450px; overflow: auto;
                                    margin-top: 3px;">
                                     <table id="tb3g" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Detail</td>
<td>Validity</td>
<td>Amount</td>
</tr>
</thead>
<tbody>
</tbody>
</table>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="tab-5">
                            <div class="table-responsive">
                                <div class="da-nice-scroll" style="max-height: 450px; min-height: 450px; overflow: auto;
                                    margin-top: 3px;">
                                    <table id="tblocal" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Detail</td>
<td>Validity</td>
<td>Amount</td>
</tr>
</thead>
<tbody>
</tbody>
</table>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="tab-6">
                            <div class="table-responsive">
                                <div class="da-nice-scroll" style="max-height: 450px; min-height: 450px; overflow: auto;
                                    margin-top: 3px;">
                                   <table id="tbRoaming" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Detail</td>
<td>Validity</td>
<td>Amount</td>
</tr>
</thead>
<tbody>
</tbody>
</table>
                                </div>
                            </div>
                        </div>
                        <%--<div class="tab-pane fade" id="tab-7">
                       <asp:GridView ID="GridView7" runat="server">
                        </asp:GridView>
                    </div>--%>
                    </div>
                    <!-- End Tab Panels -->
                </div>
            </div>
        </div>
    </div>
 <script type="text/javascript">
     $(document).ready(function () {
         $.ajax({
             type: "POST",
             contentType: "application/json; charset=utf-8",
             url: '<%=ResolveUrl("~/CommonService.asmx/BindRechargeOperator") %>',
             data: "{}",
             dataType: "json",
             success: function (Result) {
                 $('#ddlOperator').empty();
                 $('#ddlOperator').append("<option value='0'>--Select--</option>");
                 $.each(Result.d, function (key, value) {
                     $("#ddlOperator").append($("<option></option>").val(value.opratorcode).html(value.operatorname));
                 });
             },
             error: function (Result) {
                 alert("Error");
             }
         });

     });

     $(document).ready(function () {
         $.ajax({
             type: "POST",
             contentType: "application/json; charset=utf-8",
             url: '<%=ResolveUrl("~/CommonService.asmx/BindRechargeCircle") %>',
             data: "{}",
             dataType: "json",
             success: function (Result) {
                 $('#ddlCircle').empty();
                 $('#ddlCircle').append("<option value='0'>--Select--</option>");
                 $.each(Result.d, function (key, value) {
                     $("#ddlCircle").append($("<option></option>").val(value.Circlecode).html(value.Circlename));
                 });
             },
             error: function (Result) {
                 alert("Error");
             }
         });
     });
         
    
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtMobileno").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A, Command+A
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
        });

        $(document).ready(function () {
            $("#txtAmount").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A, Command+A
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
        });
        //}
        function ValidateOperator() {
            var _loginMsg = $('#subscribemsg');
            _loginMsg.html('');
            if ($('#txtMobileno').val().length == 4) {
                var param = { mobile: $('#txtMobileno').val() };
                $.ajax({
                    url: '<%=ResolveUrl("~/CommonService.asmx/FindOperator") %>',
                    data: JSON.stringify(param),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var arr = data.d.split(',');
                        if (arr[0] != 'Failed') {
                            $("#ddlOperator option[value=" + arr[0] + "]").prop('selected', true);
                            $("#ddlCircle option[value=" + arr[1] + "]").prop('selected', true);
                            BindPlans();
                        }
                        return;
                    },
                    Error: function (textMsg) {

                    }
                });
            }
            else if ($('#txtMobileno').val().length <= 4) {
                $("#ddlOperator option[value= 0]").prop('selected', true);
                $("#ddlCircle option[value=0]").prop('selected', true);
                $('#tbTopUP tbody').empty();
                $('#tbFulltacktime tbody').empty();
                $('#tb2g tbody').empty();
                $('#tb3g tbody').empty();
                $('#tblocal tbody').empty();
                $('#tbRoaming tbody').empty();
            }

        }



        function BindPlans() {
            $('#tbTopUP tbody').empty();
            var param = { CircleCode: $('#ddlCircle :selected').val(), OperatorCode: $('#ddlOperator :selected').val() };
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Recharge.aspx/BindTopUP",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        $("#tbTopUP").append("<tr><td>" + data.d[i].Detail + "</td><td>" + data.d[i].Validity + "</td><td style=display:none>" + data.d[i].Amount + "</td><td><button type=button onclick='PutValueInTextBox();return false;'  class='remove'>" + data.d[i].Amount + "</button></td> </tr>");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });
            //2
            $('#tbFulltacktime tbody').empty();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Recharge.aspx/BindFullTalkTime",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        $("#tbFulltacktime").append("<tr><td>" + data.d[i].Detail + "</td><td>" + data.d[i].Validity + "</td><td style=display:none>" + data.d[i].Amount + "</td><td><button type=button onclick='PutValueInTextBox();return false;'  class='remove'>" + data.d[i].Amount + "</button></td> </tr>");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });
            //3
            $('#tb2g tbody').empty();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Recharge.aspx/Bind2G",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        $("#tb2g").append("<tr><td>" + data.d[i].Detail + "</td><td>" + data.d[i].Validity + "</td><td style=display:none>" + data.d[i].Amount + "</td><td><button type=button onclick='PutValueInTextBox();return false;'  class='remove'>" + data.d[i].Amount + "</button></td> </tr>");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });
            //4
            $('#tb3g tbody').empty();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Recharge.aspx/Bind3G4G",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        $("#tb3g").append("<tr><td>" + data.d[i].Detail + "</td><td>" + data.d[i].Validity + "</td><td style=display:none>" + data.d[i].Amount + "</td><td><button type=button onclick='PutValueInTextBox();return false;'  class='remove'>" + data.d[i].Amount + "</button></td> </tr>");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });

            //5
            $('#tblocal tbody').empty();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Recharge.aspx/BindLocal",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        $("#tblocal").append("<tr><td>" + data.d[i].Detail + "</td><td>" + data.d[i].Validity + "</td><td style=display:none>" + data.d[i].Amount + "</td><td><button type=button onclick='PutValueInTextBox();return false;'  class='remove'>" + data.d[i].Amount + "</button></td> </tr>");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });
            //6
            $('#tbRoaming tbody').empty();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Recharge.aspx/BindRoaming",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        $("#tbRoaming").append("<tr><td>" + data.d[i].Detail + "</td><td>" + data.d[i].Validity + "</td><td style=display:none>" + data.d[i].Amount + "</td><td><button type=button onclick='PutValueInTextBox();return false;'  class='remove'>" + data.d[i].Amount + "</button></td> </tr>");
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });

        }
    </script>
     
    <script type="text/javascript">
        function RechargeMobile() {
            var _loginMsg = $('#subscribemsg');
            var param = { mobile: $('#txtMobileno').val(), OperatorCode: $('#ddlOperator :selected').val(), Amount: $('#txtAmount').val() };
            $.ajax({
                url: '<%=ResolveUrl("~/CommonService.asmx/RechargeAPI") %>',
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    _loginMsg.addClass("text-danger").removeClass("text-success");
                    _loginMsg.html(data.d);
                    return;

                },
                Error: function (textMsg) {

                }
            });
        }


        function PutValueInTextBox() {
            $("#tbTopUP tr").click(function () {
                var value = $('#txtAmount').val($(this).find('td:eq(2)').html());
                return false;

            });

            $("#tbFulltacktime tr").click(function () {
                var value = $('#txtAmount').val($(this).find('td:eq(2)').html());
                return false;

            });

            $("#tb2g tr").click(function () {
                var value = $('#txtAmount').val($(this).find('td:eq(2)').html());
                return false;

            });

            $("#tb3g tr").click(function () {
                var value = $('#txtAmount').val($(this).find('td:eq(2)').html());
                return false;

            });

            $("#tblocal tr").click(function () {
                var value = $('#txtAmount').val($(this).find('td:eq(2)').html());
                return false;

            });

            $("#tbRoaming tr").click(function () {
                var value = $('#txtAmount').val($(this).find('td:eq(2)').html());
                return false;

            });

        }
    </script>
</asp:Content>
