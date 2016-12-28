<%@ Page Title="" Language="C#" MasterPageFile="~/UC/UserMain.master" AutoEventWireup="true" CodeFile="UserCashBack.aspx.cs" Inherits="UC_User_UserCashBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="col-lg-12 col-md-12 col-sm-12 sidebar left-sidebar" id="dvRecharge">
        <div class="da-activepanel">
            <div class="widget widget-popular-posts"> <h4>
                    <b>CASH BACK HISTORY</b><span class="head-line"></span></h4>
               <%-- <h4 class="classic-title">
                    <b>CASH BACK HISTORY</b><span class="head-line"></span></h4>--%>
                <div class="da-nice-scroll" style="max-height: 1000px; min-height: 200px; overflow: auto;
                    margin-top: 3px;">
                    <table id="tblOrders" cellpadding="0" class="table table-condensed" cellspacing="0">
                        <thead>
                            <tr>
                                <th>
                                    Operator Name
                                </th>
                                <th>
                                    Recharge Type
                                </th>
                                <th>
                                    OrderID
                                </th>
                                <th>
                                    Mobile/DTH
                                </th>
                                <th>
                                    Paid Amount
                                </th>
                                <th>
                                    Cash Back Amount
                                </th>
                                <th>
                                    CashBack Status
                                </th>
                                <th>
                                    Dated On
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div style="text-align: center;">
                    <button type="button" style="width: 25%;" class="btn-system btn-medium" id="like">
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
            GetAllCashBackDetails();
        });
        </script>
<script type="text/javascript">
    function GetAllCashBackDetails() {
        var num = parseInt($(".figure").text());
        var param = { PageIndex: num };
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "UserCashBack.aspx/GetCaskBackdetailForUser",
            data: JSON.stringify(param),
            dataType: "json",
            success: function (data) {
                
                                if (data.d.length <= 15) {
                                    $("#like").hide();
                                }
                                for (var i = 0; i < data.d.length; i++) {
                                    $("#tblOrders").append("<tr><td>" + data.d[i].operatorName + "</td><td>" + data.d[i].RechargeType + "</td><td>" + data.d[i].OrderID + "</td><td>" + data.d[i].Mobile + "</td><td>" + data.d[i].RechargeAmount + "</td><td>" + data.d[i].CashBackAmount + "</td><td>" + data.d[i].Status + "</td><td>" + data.d[i].CreatedDate + "</td> </tr>");
                                }

            },
            error: function (result) {
                alert(result.d);
            }
        });
    }
    
</script>
</asp:Content>

