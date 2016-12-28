<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_MerchantListCB_List.ascx.cs"
    Inherits="UC_UCUI_RightSidebar_uc_MerchantListCB_List" %>

<asp:CheckBoxList ID="ckbAllMerchant" runat="server" ClientIDMode="Static" RepeatLayout="Table"
    TextAlign="Right">
</asp:CheckBoxList>
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
