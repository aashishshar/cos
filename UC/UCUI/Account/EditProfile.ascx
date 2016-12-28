<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditProfile.ascx.cs" Inherits="UC_UCUI_Account_EditProfile" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("[id$=txtDOB]").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+0"
        });

    });
    //        $(function () {

    //           
    //        });

    function showUpload(input) {
        //alert(input);
        document.getElementById("fileUpload").style.visibility = 'visible';
        // $('#fileUpload').attr('src', e.target.result);
    }

    function showimagepreview(input) {
        if (input.files && input.files[0]) {
            var filerdr = new FileReader();
            filerdr.onload = function (e) {
                $('#imgProfilePic').attr('src', e.target.result);
                //$("[id$ = imgProfilePic]").attr('src', e.target.result);

            }
            filerdr.readAsDataURL(input.files[0]);
        }
        document.getElementById("fileUpload").style.visibility = 'hidden';
    }

    //    function resizeImage(input) {
    //        showimagepreview(input);
    //        var filesToUpload = input.files;
    //        var file = filesToUpload[0];
    //        //var docImg =  document.getElementById("imgProfilePic");
    //        //alert(docImg);
    //        var img = document.createElement("img");
    //        var reader = new FileReader();
    //        reader.onload = function (e) { img.src = e.target.result }
    //        reader.readAsDataURL(file);

    //        // reader returns null (actually, "e" is returning null here)

    //        var canvas = document.createElement('canvas');
    //        var ctx = canvas.getContext("2d");
    //        ctx.drawImage(img, 0, 0);

    //        var MAX_WIDTH = 80;
    //        var MAX_HEIGHT = 60;
    //        var width = img.width;
    //        var height = img.height;

    //        if (width > height) {
    //            if (width > MAX_WIDTH) {
    //                height *= MAX_WIDTH / width;
    //                width = MAX_WIDTH;
    //            }
    //        } else {
    //            if (height > MAX_HEIGHT) {
    //                width *= MAX_HEIGHT / height;
    //                height = MAX_HEIGHT;
    //            }
    //        }
    //        canvas.width = width;
    //        canvas.height = height;
    //        var ctx = canvas.getContext("2d");
    //        ctx.drawImage(img, 0, 0, width, height);

    //        var dataurl = canvas.toDataURL("image/png");
    //        img.src = dataurl;
    //        
    //    }
       
</script>
<%--<div class="row">
    <div class="col-md-12">
        <h3 class="page-header">
            Your Profile<small> [ <asp:Literal runat="server" ID="litUserName"></asp:Literal> ]</small>
        </h3>
    </div>
</div>
<div class="row">
    <div class="col-md-12">--%>
<h5 class="classic-title">
    <span><b>User Detail</b></span></h5>
<div class="row">
    <%--<div class="col-md-5">
            <div class="form-group">
                <label>
                    Email-ID / User Name</label>
                <asp:TextBox ID="txtEmailUserName" runat="server" placeholder="Email-ID / user name"
                    disabled></asp:TextBox>
            </div>
        </div>--%>
    <div class="col-md-4">
        <div class="form-group">
           <%-- <label>
                Full Name</label>--%>
            <asp:TextBox ID="txtFullName" runat="server" required="" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
           <%-- <label>
                Date of Birth</label>--%>
            <asp:TextBox ID="txtDOB" runat="server" required="" CssClass="form-control" placeholder="DOB"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
    </div>
</div>
<h5 class="classic-title">
    <span><b>Bank Detail</b></span></h5>
<div class="row">
    <div class="col-md-4">
   <%-- div class="form-group required">
            <label class="control-label">
                Bank Account Holder Name</label>--%>
        <div class="form-group ">
           <%-- <label class="control-label">
                Bank Account Holder Name</label>--%>
            <asp:TextBox ID="txtBankAcHolderName"  runat="server" CssClass="form-control" placeholder="Bank Account Holder Name"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group ">
        <%--    <label>
                Bank Name</label>--%>
            <asp:TextBox ID="txtBankName" runat="server"  placeholder="Bank Name" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group ">
           <%-- <label>
                Bank Branch Name</label>--%>
            <asp:TextBox ID="txtBankBranchName" runat="server"  placeholder="Bank Branch Name"
                CssClass="form-control"></asp:TextBox>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
           <%-- <label>
                Bank Account No.</label>--%>
            <asp:TextBox ID="txtBankAccountNo" runat="server"  placeholder="Bank Account No."
                CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <%--<label>
                IFSC Code</label>--%>
            <asp:TextBox ID="txtIFSCCode" runat="server"  placeholder="IFSC Code" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
    </div>
</div>
<h5 class="classic-title">
    <span><b>Notification</b></span></h5>
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <asp:CheckBox ID="ckIsOfferReceiveWeekly"  runat="server" Text="<b>&nbsp;&nbsp;Offer Receive Weekly</b>">
            </asp:CheckBox>
        </div>
    </div>
    <div class="col-md-4" style="visibility: hidden;">
        <div class="form-group">
            <asp:CheckBox ID="ckbIsEmailVerified" Enabled="false" runat="server" Text="<b>&nbsp;&nbsp;Email Verified</b>">
            </asp:CheckBox>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <asp:CheckBox ID="ckOtherInfo" runat="server" Text="<b>&nbsp;&nbsp;News Letter</b>">
            </asp:CheckBox>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <asp:Button ID="bneditProfileRegistration" Width="20%" runat="server" EnableTheming="false"
            Text="Update" ValidationGroup="editProfileReg" CssClass="btn-system btn-medium" OnClick="bnRegistration_Click" />
    </div>
    <%--<div class="col-md-6">
                    <asp:Button ID="btnReset" Width="100%" runat="server" EnableTheming="false" Text="Cancel"
                        ValidationGroup="editProfileReg" CssClass="btn btn-lg btn-success btn-block" />
                </div>--%>
    <div class="col-md-12">
        <asp:Label ID="lblMessage" CssClass="text-info" runat="server"></asp:Label>
    </div>
</div>
<div class="col-md-2" style="visibility: hidden;">
    <div>
        <input type="file" name="filUpload" runat="server" visible="false" id="filUpload"
            onchange="showimagepreview(this)" />
    </div>
    <img id="imgprvw" alt="uploaded image preview" runat="server" visible="false" />
    <asp:Image runat="server" ID="imgProfilePic" onclick="showUpload(this)" ClientIDMode="Static"
        Height="150px" Width="150px" />
    <div id="fileUpload" style="visibility: hidden;">
        <br />
        <input type="file" class="default" id="ctrl_Upload" runat="server" accept="image/*"
            onchange="showimagepreview(this)" />
    </div>
    <asp:Button runat="server" ID="btn_Upload" Visible="false" Text="Upload" OnClick="btn_Upload_Click" />
</div>
<div runat="server" id="check">
    <div class="row" style="visibility: hidden;">
        <h5 class="classic-title">
            <span>For Check Detail</span></h5>
        <div class="col-md-4">
            <div class="form-group">
                <label>
                    Full Name On Address</label>
                <asp:TextBox ID="txtFullNameOnAdd" runat="server" placeholder="Full Name On Address"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-8">
            <div class="form-group">
                <label>
                    Address</label>
                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row" style="visibility: hidden;">
        <div class="col-md-4">
            <div class="form-group">
                <label>
                    State</label>
                <asp:DropDownList ID="ddlState" runat="server" placeholder="State">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>
                    City</label>
                <asp:TextBox ID="txtCity" runat="server" placeholder="City"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label>
                    Pin Code</label>
                <asp:TextBox ID="txtPincode" runat="server" placeholder="Pin code"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
