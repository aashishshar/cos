<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        function KeyUp(txtboxID, chklistboxID) {
            if ($(txtboxID).val() != "") {

                $(chklistboxID).children('tbody').children('tr').each(function () {
                    $(this).show();
                });

                $(chklistboxID).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtboxID).val().toUpperCase()) > -1) match = true;
                    });
                    if (match) $(this).show();
                    else $(this).hide();
                });
            }
            else {

                $(chklistboxID).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
            }
        }

    </script>
    <style type="text/css">
        .treeNode
        {
            color: red;
            font: 14px Arial, Sans-Serif;
            width: 30px;
        }
        
        .rootNode
        {
            font-size: 18px;
            color: blue;
            width: 30px;
        }
        
        .leafNode
        {
            padding: 4px;
            color: orange;
            width: 30px;
        }
        
        .selectNode
        {
            font-weight: bold;
            color: purple;
        }
    </style>
    <title></title>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
   
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
   
    <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <script type="text/javascript">
        $(function () {
            $("#txtBrand").autocomplete({
                source: function (request, response) {

                    var param = { empName: $('#txtBrand').val() };
                    $.ajax({
                        url: "Default3.aspx/GetEmpNames",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {

                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }))
                            BindCheckBoxList(data);

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)
                            // console.log("Ajax Error!");  
                        }
                    });
                },
                minLength: 1 //This is the Char length of inputTextBox  
            });
        }); 
        
        function BindCheckBoxList(result) {
            
            var fruits = (result.d);
            //CreateCheckBoxList(items);
            var repeatColumns = parseInt("<%=chkMerchant.RepeatColumns%>");
            if (repeatColumns == 0) {
                repeatColumns = 1;
            }
            var cell = $("[id*=chkMerchant] td").eq(0).clone(true);
            $("[id*=chkMerchant] tr").remove();
            //$("[id*=chkMerchant] tbody").append(fruits);
            $.each(fruits, function (i) {
                var row;
                if (i % repeatColumns == 0) {
                    row = $("<tr />");
                    $("[id*=chkMerchant] tbody").append(row);
                } else {
                    row = $("[id*=chkMerchant] tr:last-child");
                }

                var checkbox = $("input[type=checkbox]", cell);

                //Set Unique Id to each CheckBox.
                checkbox[0].id = checkbox[0].id.replace("0", i);

                //Give common name to each CheckBox.
                checkbox[0].name = "Brand";
                
                //Set the CheckBox value.
                checkbox.val(this.Value);

                var label = cell.find("label");
                if (label.length == 0) {
                    label = $("<label />");
                }

                //Set the 'for' attribute of Label.
                label.attr("for", checkbox[0].id);

                //Set the text in Label.
                label.html(this.Text);

                //Append the Label to the cell.
                cell.append(label);

                //Append the cell to the Table Row.
                row.append(cell);
                cell = $("[id*=chkMerchant] td").eq(0).clone(true);
            });

            $("[id*=chkMerchant] input[type=checkbox]").click(function () {
                var cell = $(this).parent();
                var hidden = cell.find("input[type=hidden]");
                var label = cell.find("label");
                if ($(this).is(":checked")) {
                    //Add Hidden field if not present.
                    if (hidden.length == 0) {
                        hidden = $("<input type = 'hidden' />");
                        cell.append(hidden);
                    }
                    hidden[0].name = "Brand";
                    
                    //Set the Hidden Field value.
                    hidden.val(label.text());
                    cell.append(hidden);
                } else {
                    cell.remove(hidden);
                }
            });
        }
        function CreateCheckBoxList(checkboxlistItems) {
            var table = $('<table></table>');
            var counter = 0;
            $(checkboxlistItems).each(function () {
                table.append($('<tr></tr>').append($('<td></td>').append($('<input>').attr({
                    type: 'checkbox', name: 'chkMerchanta', value: this.Value, id: 'chkMerchanta' + counter
                })).append(
                $('<label>').attr({
                    foreach: 'chkMerchanta' + counter++
                }).text(this.Name))));
            });
 
            $('#dvCheckBoxListControl').append(table);
        }
        
       
         
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery(".content").show();
            //toggle the componenet with class msg_body
            jQuery(".heading").click(function () {
                jQuery(this).next(".content").slideToggle(500);
            });
        });
    </script>--%>
    <style type="text/css">
        .checkboxlist input
        {
            font: inherit;
            font-size: 0.875em; /* 14px / 16px */
            color: #494949;
            float: left;
            margin-top: 2px;
            margin-bottom: 18px;
        }
        .checkboxlist label
        {
            font: inherit;
            font-size: 0.875em; /* 14px / 16px */
            color: #494949;
            position: relative;
            margin-top: 2px;
            display: block;
            width: 150px;
        }
    </style>
    <style type="text/css">
        .layer1
        {
            margin: 0;
            padding: 0;
            width: 220px;
        }
        
        .heading
        {
            margin: 1px;
            color: #fff;
            padding: 3px 10px;
            cursor: pointer;
            position: relative;
            background-color: #c30;
        }
        .content
        {
            padding: 5px 10px;
            background-color: #fafafa;
        }
        p
        {
            padding: 5px 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="layer1">
        <p class="heading">
            Header-3</p>
        <div class="content">
            <div style="overflow: auto">
                <%--<asp:CheckBoxList ID="CheckBoxList3" RepeatDirection="Horizontal" RepeatColumns="1" runat="server">
    <asp:ListItem Text="A"></asp:ListItem>
    <asp:ListItem Text="B"></asp:ListItem>
    <asp:ListItem Text="C"></asp:ListItem>
    <asp:ListItem Text="D"></asp:ListItem>
    <asp:ListItem Text="E"></asp:ListItem>
    </asp:CheckBoxList>--%>
                <asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/Images/portlet-collapse-icon.png"
                    ExpandImageUrl="~/Images/portlet-collapse-icon.png" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    <LeafNodeStyle CssClass="leafNode" />
                    <NodeStyle CssClass="treeNode" />
                    <RootNodeStyle CssClass="rootNode" />
                </asp:TreeView>
            </div>
        </div>
        <div class="content" id="divmerchant" runat="server" visible="false">
            <p class="heading">
                Merchant
            </p>
            <div style="height: 100px; overflow: auto">
                <asp:TextBox ID="txtmerchant" runat="server" onkeyup="KeyUp(this,'#chkMerchant');"
                    CssClass="searchicon forminput" placeholder="Search Merchant"></asp:TextBox>
                <div id="dvCheckBoxListControl">
                    <asp:CheckBoxList ID="chkMerchant" CssClass="checkboxlist" RepeatDirection="Horizontal"
                        RepeatColumns="1" runat="server" OnSelectedIndexChanged="chkMerchant_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div id="divBrand" runat="server" visible="false">
            <p class="heading">
                Brand</p>
            <div class="content">
                <div style="height: 100px; overflow: auto">
                    <asp:TextBox ID="txtBrand" runat="server" onkeyup="KeyUp(this,'#chkBrand');" CssClass="searchicon forminput"
                        placeholder="Search Merchant"></asp:TextBox>
                    <div>
                        <asp:CheckBoxList ID="chkBrand" CssClass="checkboxlist" RepeatDirection="Horizontal"
                            RepeatColumns="1" runat="server">
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:GridView ID="grvItems" AutoGenerateColumns="false" runat="server">
    </asp:GridView>
    </form>
</body>
</html>
