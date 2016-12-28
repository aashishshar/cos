<%@ Page Title="" Language="C#" MasterPageFile="~/UC/UserMain.master" AutoEventWireup="true" CodeFile="RechargeOrder.aspx.cs" Inherits="UC_User_RechargeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
  <div class="col-lg-12 col-md-12 col-sm-12 sidebar left-sidebar" id="dvRecharge" style="display: none">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts">
            <h4>
                    <b>Recharge/Bill Payment Order History</b><span class="head-line"></span></h4>
               <%-- <h4 class="classic-title">
                    <b><span class="head-line"></b></span></h4>--%>
                <div class="da-nice-scroll" style="min-height: 200px; overflow: auto;
                    margin-top: 3px;">
                    <table id="tblOrders" cellpadding="0" class="table table-condensed" cellspacing="0">
                        <thead>
                            <tr>
                                <th>
                                    Operator Name
                                </th>
                                 <th>
                                    Mobile/DTH
                                </th>
                                <th>
                                    Status
                                </th>
                                <th>
                                    Amount
                                </th>
                                <th>
                                    Order No.
                                </th>
                                <th>
                                    Order Time
                                </th> <th> </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div style="text-align: center;"> 
                    <button type="button" style="width: 25%;border:0px;" class="btn-system btn-medium" id="like">
                        VIEW MORE
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div id="likes" style="display: none">
        <span class="figure">1 </span>
    </div>



    <script type="text/javascript">

        $(document).ready(function () {
            
            GetAllOrders();
        });

        $("#like").click(function () {
            var num = parseInt($(".figure").text());
            $(".figure").text(num + 1);
            GetAllOrders();
        })


        function GetAllOrders() {
            var num = parseInt($(".figure").text());
            var param = { PageIndex: num };
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '<%=ResolveUrl("~/CommonService.asmx/BindRechargeOrders") %>',
                data: JSON.stringify(param),
                dataType: "json",
                success: function (data) {
                    if (data.d.length < 10) {
                        $("#like").hide();
                    }
                    for (var i = 0; i < data.d.length; i++) {
                        if (data.d[i].RefundProcess != '') {
                            $("#tblOrders").append("<tr id='myrow'><td class='nr'>" + "<img src=../../Images/OperatorImage/" + data.d[i].OperatorImage + " alt='' border=3 height=40 width=40></img>" + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].SuccessStatus + "</td><td><i class='fa fa-inr'></i> " + data.d[i].Amount + "</td><td>" + data.d[i].ourorderid + "</td><td>" + data.d[i].Time + "</td><td>" + data.d[i].RefundProcess + "</td> </tr>");
                        }
                        else {
                            if (data.d[i].RefundStatus != '') {
                                $("#tblOrders").append("<tr id='myrow'><td class='nr'>" + "<img src=../../Images/OperatorImage/" + data.d[i].OperatorImage + " alt='' border=3 height=40 width=40></img>" + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].SuccessStatus + "</td><td><i class='fa fa-inr'></i> " + data.d[i].Amount + "</td><td>" + data.d[i].ourorderid + "</td><td>" + data.d[i].Time + "</td><td>" + "<input id='btnRefund'  class='main-button' onclick='RefundMoney()'  type='button' value='Transfer To Bank' />" + "</td> </tr>");
                            }
                            else {
                                $("#tblOrders").append("<tr id='myrow'><td class='nr'>" + "<img src=../../Images/OperatorImage/" + data.d[i].OperatorImage + " alt='' border=3 height=40 width=40></img>" + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].SuccessStatus + "</td><td><i class='fa fa-inr'></i> " + data.d[i].Amount + "</td><td>" + data.d[i].ourorderid + "</td><td>" + data.d[i].Time + "</td><td>" + "" + "</td> </tr>");
                            }
                        }

                    }
                    if (($('#tblOrders tr').length) > 1)
                        $("#dvRecharge").show();
                    else
                        $("#dvRecharge").hide();
                },
                error: function (result) {
                    alert(result.d);
                }
            });
        }

        function RefundMoney() {
            $("#tblOrders td").click(function () {
                var column_num = parseInt($(this).index()) + 1;
                var row_num = parseInt($(this).parent().index()) + 1;
                //alert($('#tblOrders tr:eq(' + row_num + ') > td:eq(3)').text());


                var _loginMsg = $('#subscribemsg');
                var param = { OrderID: $('#tblOrders tr:eq(' + row_num + ') > td:eq(3)').text() };

                $.ajax({
                    //url: "Recharge.aspx/RefundMoneyToBank",
                    url: '<%=ResolveUrl("~/CommonService.asmx/RefundMoneyToBank") %>',
                    data: JSON.stringify(param),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $('#tblOrders tbody').empty();
                        GetAllOrders();
                        return;

                    },
                    Error: function (textMsg) {

                    }
                });
            });
        }
    </script>
</asp:Content>

