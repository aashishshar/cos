<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTableTest.aspx.cs" Inherits="DataTableTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css"
        rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <link rel="stylesheet" href="http://cdn.datatables.net/1.10.2/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.2/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table-responsive">
        <table id="myTable" class="display table" width="100%">
            <thead>
                <tr>
                    <th>
                        ENO
                    </th>
                    <th>
                        EMPName
                    </th>
                    <th>
                        Country
                    </th>
                    <th>
                        Salary
                    </th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                   <th>
                        ENO
                    </th>
                    <th>
                        EMPName
                    </th>
                    <th>
                        Country
                    </th>
                    <th>
                        Salary
                    </th>
                </tr>
            </tfoot>
            <tbody>
                <tr>
                    <td>
                        001
                    </td>
                    <td>
                        Anusha
                    </td>
                    <td>
                        India
                    </td>
                    <td>
                        10000
                    </td>
                </tr>
                <tr>
                    <td>
                        002
                    </td>
                    <td>
                        Charles
                    </td>
                    <td>
                        United Kingdom
                    </td>
                    <td>
                        28000
                    </td>
                </tr>
                <tr>
                    <td>
                        003
                    </td>
                    <td>
                        Sravani
                    </td>
                    <td>
                        Australia
                    </td>
                    <td>
                        7000
                    </td>
                </tr>
                <tr>
                    <td>
                        004
                    </td>
                    <td>
                        Amar
                    </td>
                    <td>
                        India
                    </td>
                    <td>
                        18000
                    </td>
                </tr>
                <tr>
                    <td>
                        005
                    </td>
                    <td>
                        Lakshmi
                    </td>
                    <td>
                        India
                    </td>
                    <td>
                        12000
                    </td>
                </tr>
                <tr>
                    <td>
                        006
                    </td>
                    <td>
                        James
                    </td>
                    <td>
                        Canada
                    </td>
                    <td>
                        50000
                    </td>
                </tr>
                <tr>
                    <td>
                        007
                    </td>
                    <td>
                        Ronald
                    </td>
                    <td>
                        US
                    </td>
                    <td>
                        75000
                    </td>
                </tr>
                <tr>
                    <td>
                        008
                    </td>
                    <td>
                        Mike
                    </td>
                    <td>
                        Belgium
                    </td>
                    <td>
                        100000
                    </td>
                </tr>
                <tr>
                    <td>
                        009
                    </td>
                    <td>
                        Andrew
                    </td>
                    <td>
                        Argentina
                    </td>
                    <td>
                        45000
                    </td>
                </tr>
                <tr>
                    <td>
                        010
                    </td>
                    <td>
                        Stephen
                    </td>
                    <td>
                        Austria
                    </td>
                    <td>
                        30000
                    </td>
                </tr>
                <tr>
                    <td>
                        011
                    </td>
                    <td>
                        Sara
                    </td>
                    <td>
                        China
                    </td>
                    <td>
                        750000
                    </td>
                </tr>
                <tr>
                    <td>
                        012
                    </td>
                    <td>
                        JonRoot
                    </td>
                    <td>
                        Argentina
                    </td>
                    <td>
                        65000
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            // Setup - add a text input to each footer cell
            $('#myTable tfoot th').each(function () {
                var title = $('#myTable thead th').eq($(this).index()).text();
                $(this).html('<input type="text" placeholder="Search ' + title + '" />');
            });

            // DataTable
            var table = $('#myTable').DataTable();

            // Apply the search
            table.columns().every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change', function () {
                    that
                .search(this.value)
                .draw();
                });
            });
        });
        //        $(document).ready(function () {
        //            $('#myTable').dataTable({
        //                //                "scrollY": 200,
        //                //                "scrollX": true,
        ////                "scrollCollapse": true,
        ////                "jQueryUI": true

        //            });
        //        });
    </script>
    </form>
</body>
</html>
