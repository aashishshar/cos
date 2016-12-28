<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_HeaderCommon.ascx.cs"
    Inherits="UC_MasterHeader_uc_HeaderCommon" %>
<%@ Register Src="../UCUI/Account/Registration.ascx" TagName="Registration" TagPrefix="uc1" %>
<%-- <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>--%>
<%-- <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />
--%>
<script type="text/javascript">


    // $('.input').keypress(function (e) { if (e.which == 13 ||e.keycode==13) { jQuery(this).blur(); jQuery('#Button1').focus().click(); } });



    $(function () {
        $("#txtSearchHome").autocomplete({
            source: function (request, response) {
                var param = { TitleName: $('#txtSearchHome').val() };
                $.ajax({
                    url: '<%=ResolveUrl("~/CommonService.asmx/GetTitleNames") %>',
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

    $(document).ready(function () {
        //        $('#MenuItem li ').click(function () {
        //            alert("HI");
        //            //$('#MenuItem li').removeClass('active');
        //            //$(this).addClass('active');
        //            //$('#MenuItem li').click(function () {
        //            localStorage.setItem('thisLink', $(this).child().attr("id"));
        //            //});


        //            //            $('ul#navlist li a').click(function () {
        //            //                localStorage.setItem('thisLink', $(this).parent().attr("id"));
        //            //            });

        //            //            var thisLink = localStorage.getItem('thisLink');
        //            //            if (thisLink) {
        //            //                $('#' + thisLink).addClass('current');
        //            //            }

        //        });

        //        var thisLink = localStorage.getItem('thisLink');
        //        if (thisLink) {
        //            $('#' + thisLink).addClass('active');
        //        };

    });


    $(function () {
        $(document).on('click', '.login-btn', function (e) {
            //            alert("login");
            var username = $('#UserName').val();
            var password = $('#Password').val();
            var remeberMe = $('#rem_user').val();
            var _loginMsg = $('#msg');
            if (username == '' || password == '') {
                _loginMsg.addClass("text-danger").removeClass("text-success");
                _loginMsg.html("Fields should not be empty");
                //                   $('.login-box')
                //                            .animate({ left: -25 }, 20)
                //                            .animate({ left: 0 }, 60)
                //                            .animate({ left: 25 }, 20)
                //                            .animate({ left: 0 }, 60);
            } else {
                //alert("hihi");
                var Objdata = {};
                Objdata.username = username;
                Objdata.password = password;
                Objdata.remeberMe = true;
                var url = '<%=ResolveUrl("~/CommonService.asmx/AuthenticateToUser") %>';
                $.ajax({
                    type: "POST",
                    url: url,
                    data: JSON.stringify(Objdata),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == true) {
                            _loginMsg.addClass("text-success").removeClass("text-danger");
                            $('#loginModal').dialog("close");
                            window.location.reload();
                            // _loginMsg.html("Login was successful!");
                            //$('.modal-content').animate({ 'top': '-165px' }, 800);
                            //$('.modal fade').fadeOut(500);

                        } else {
                            _loginMsg.addClass("text-danger").removeClass("text-success");
                            _loginMsg.html("Invalid username & Password");
                            $('.modal-content')
                                    .animate({ left: -25 }, 20)
                                    .animate({ left: 0 }, 60)
                                    .animate({ left: 25 }, 20)
                                    .animate({ left: 0 }, 60);
                        }
                    },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        alert('Error');
                    }
                });
            }

            e.preventDefault();
        });
    });
   

</script>
<!-- Start  Logo & Naviagtion  -->
<div class="navbar navbar-default navbar-top">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <div class="navbar-header">
                    <!-- Stat Toggle Nav Link For Mobiles -->
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <i class="fa fa-bars"></i>
                    </button>
                    <!-- End Toggle Nav Link For Mobiles -->
                    <button id="search-button" type="button" class="navbar-toggle" data-toggle="button"
                        data-target="#search">
                        <span class="fa fa-search"></span>
                    </button>
                    <asp:HyperLink class="navbar-brand" ID="hlHeaderNavigation" NavigateUrl="~/Default.aspx"
                        runat="server">
                        <asp:Image ID="imgHeader" ImageUrl="~/Images/logo.png" CssClass="img-responsive"
                            runat="server" /></asp:HyperLink>
                </div>
            </div>
            <div class="col-sm-5">
                <!-- Stat Search -->
                <div class="widget widget-search da-top-search row hidden-xs" id="search">
                    <asp:TextBox ID="txtSearchHome" runat="server" ClientIDMode="Static" placeholder="Search..."></asp:TextBox>
                    <button class="search-btn" type="submit" id="searchButton" causesvalidation="false"
                        runat="server" onserverclick="btnSubmitPost_Click">
                        <i class="fa fa-search"></i>
                    </button>
                </div>
                <!-- End Search -->
            </div>
            <div class="col-sm-4">
                <div class="da-top-links">
                    <ul class="nav nav-pills">
                        <li>
                            <asp:HyperLink ID="hlHIW" runat="server" NavigateUrl="~/HowITWorks.aspx"><b>How it Works</b></asp:HyperLink></li>
                        <li runat="server" id="liAccount" class="dropdown">
                            <asp:HyperLink ID="hlProfile" EnableTheming="false" CssClass="main-button logoutlink"
                                NavigateUrl="~/Security.ashx" runat="server">
                                <i class="fa fa-user fa-fw"></i>
                                <asp:LoginName ID="LoginName1" FormatString="{0}" runat="server" />
                                <i class="caret"></i>
                            </asp:HyperLink>
                            <ul class="dropdown-menu" style="margin-top:0px;padding-top:0px;">
                                <%-- <li><a href="#"><i class="fa fa-money fa-fw"></i>&nbsp;Cashback Detail</a></li>
                                <li><a href="#"><i class="fa fa-support fa-fw"></i>&nbsp;Cashback Issue</a></li>--%>
                                <li>
                                    <asp:HyperLink ID="hlProfileUser"  NavigateUrl="~/UC/User/Default.aspx" runat="server"><i class="fa fa-user fa-fw"></i>&nbsp;Profile</asp:HyperLink>
                                </li>
                                <%-- <li><a href="#"><i class="fa fa-gear fa-fw"></i>&nbsp;Change Password</a></li>--%>
                                <li>
                                    <asp:LoginStatus ID="LoginStatus1" CssClass="" LogoutText="&nbsp;<i class='fa fa-sign-out'></i> Logout"
                                        runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" />
                                </li>
                            </ul>
                        </li>
                        <li runat="server" id="liLogout">
                            <asp:LoginStatus ID="HeadLoginStatus" CssClass="main-button logoutlink" LogoutText="Logout"
                                runat="server" LoginText="<i class='fa fa-sign-in'></i> Log In / Sign Up" LogoutAction="Redirect"
                                LogoutPageUrl="~/Default.aspx" />
                        </li>
                    </ul>
                </div>
                <!-- Login Modal -->
                <div class="modal fade in" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog da-login-modal" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close pull-right" data-dismiss="modal" id="logclose">
                                    <span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
                                <h3>
                                    <i class="fa fa-user"></i>&nbsp;<span>SIGN IN</span></h3>
                            </div>
                            <section class="clearfix p_sign">
      <div class="modal-body">
     
        
        <div class="fl sign_left">
       <%--<h2>NEW USERS, REGISTER NOW</h2>--%>
        <a rel="nofollow" href="#" class="button">JOIN US TO GET EXTRA CASHBACK</a>
        
        <ul class="clearfix">
        <li class="pos"><strong>Extra cashback when you shop by us</strong></li>
        <li class="pos"><strong>Fast cashback paid</strong></li>
        <%--<li class="pos"><strong>OVER 10 LAKH HAPPY MEMBERS</strong></li>
        <li class="pos"><strong>500+ PARTNER SITES</strong></li>--%>
        </ul>
        </div>
        
        <div class="sign_right">
       <%--<h3>LOGIN</h3>--%>              
        <a class="fbbutton" data-text="OR" href="javascript:void(0);">Login With Facebook <i class="fa fa-facebook" style="font-size:18px; margin-left:5px;"></i></a>
          <asp:TextBox ID="UserName" CssClass="form-control" runat="server" TabIndex="0" ClientIDMode="Static"  EnableTheming="false"  placeholder="E-mail"
                                        autofocus></asp:TextBox>
        
       
        
       <asp:TextBox ID="Password" runat="server" CssClass="form-control" TabIndex="0"  ClientIDMode="Static"  EnableTheming="false" placeholder="Password"
                                        TextMode="Password"></asp:TextBox>
        <asp:HyperLink ID="hlForgotPassword" EnableTheming="false" CssClass="fl link" TabIndex="2" runat="server"
                                    NavigateUrl="~/fpass.aspx"><b>Forgot Password?</b></asp:HyperLink>
                                    
        <div class="fw fl">
        <span class="fl">
        <input type="checkbox" value="1" tabindex="3" name="rem_user" id="rem_user">Keep me signed in</span>
        <asp:Button ID="btnMainLoginUserwindow" CssClass="pull-right btn login-btn" TabIndex="0" runat="server"  EnableTheming="false"
                                        CommandName="Login" Text="Sign in" ValidationGroup="HeaderCommonLoginUserValidationGroup" />
                                        
                                        <%--<button class="pull-right btn login-btn" value="Sign In" type="submit" id="btnMainLoginUserwindow" runat="server" validationgroup="HeaderCommonLoginUserValidationGroup"></button>--%>
        </div>

         <span class="text-success">
                                    <%--<asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
                                      <div id="msg"></div>
                                </span>
                                <div class="hr5 clearfix">
                                </div>
                                <div class="fa-align-center alignCenter">
       
		<strong>Don't have an account yet? <a href="javascript:void(0);" data-dismiss="modal"  data-toggle="modal" data-target="#regModal"><b>Register now</b></a> </strong></div>
        </div>
               <asp:Button ID="Button2" CssClass="btn login-btn" style="width:100%;" Visible="false"  runat="server"  EnableTheming="false"
                                        CommandName="Login" Text="Continue without login.." ValidationGroup="HeaderCommonLoginUserValidationGroup" />   
           <asp:HyperLink ID="HyperLinkc1" CssClass="main-button logoutlink" Visible="false" style="width:100%;text-align:center;" runat="server">Continue without login..</asp:HyperLink> </div>
                       
                        </section>
                        </div>
                    </div>
                </div>
                <!-- Register Modal -->
                <div class="modal fade in" id="regModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog" style="width: 388px!important;">
                        <div class="modal-content">
                            <section class="clearfix p_sign">
                            <div class="modal-header">
                                <h4 class="modal-title" id="myModalLabel">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <i class="fa fa-user"></i>&nbsp;SIGN UP</h4>
                            </div>
                            <div class="modal-body">
                               
   <uc1:Registration ID="Registration1" runat="server" />
    <%-- <asp:TextBox ID="txtFullName" runat="server" ClientIDMode="Static" CssClass="form-control" required="" oninvalid="this.setCustomValidity('Please Enter Full Name.')" placeholder="Full name"
                autofocus></asp:TextBox>
        


    
       
            <asp:TextBox ID="txtEmailUserName" runat="server" CssClass="form-control" required="" placeholder="Email-id"></asp:TextBox>
        

        
            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Mobile No." required=""></asp:TextBox>
        
    
    
        
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="" CssClass="form-control"
                placeholder="Password"></asp:TextBox>
        
    
    
        
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" required="" CssClass="form-control"
                placeholder="Confirm password"></asp:TextBox>
        
    
    
       
            <asp:CheckBox ID="chkTermAndCondition" runat="server"  Text="&nbsp;I agree to the" required="" />
            <asp:HyperLink ID="HyperLink92" Target="_blank" ForeColor="Blue" Text="Terms & Conditions"
                NavigateUrl="~/TermsAndCondition.aspx" runat="server"></asp:HyperLink>
       
     <div class="fw fl">
     <asp:Button ID="btnCreateUser" class="button da-signup-btn-width" Width="100%" runat="server" Text="REGISTER" />
                                              
                                            </div>
    --%>                                        <div class="hr5 clearfix">
                                            </div>
                                            <div class="alignCenter">
                                                <strong>Already have an account?<strong> <a href="javascript:void(0);" data-dismiss="modal"
                                                    data-toggle="modal" data-target="#loginModal">Login</a> now</strong></div>
                                                                         

                                           
                                          
                               
                        </div>
                        
                        
                        </section>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>
</div>
<!-- End Header Logo & Naviagtion -->
<div class="stikynav navbar-default navbar-top">
    <div class="container" style="position: relative;">
        <div class="row">
            <div class="navbar-header">
                <!-- Start Navigation List -->
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-left">
                        <li>
                            <asp:HyperLink ID="hlHome" NavigateUrl="~/Default.aspx" runat="server"><i class="fa fa-home icon-middle"></i>&nbsp;&nbsp;Home&nbsp;</asp:HyperLink>
                        </li>
                        <%--<li><a href="#">SHOP BY PRODUCT <span class="caret"></span></a>
                            <div class="dropdown">
                                <ul class="col-sm-2 col-xs-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink4" CssClass="active" NavigateUrl="~/category/ELECTRONICS"
                                            runat="server">ELECTRONICS</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/category/Mobile Phones" runat="server">Mobile Phones</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl="~/category/Mobile Accessories" runat="server">Mobile Accessories</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink3" NavigateUrl="~/category/Laptops And Computer" runat="server">Laptops & Computer</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-xs-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink10" NavigateUrl="~/category/Data Storage" runat="server">Data Storage</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink11" NavigateUrl="~/category/Cameras" runat="server">Cameras</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink12" NavigateUrl="~/category/TV, Video And Audio" runat="server">TV, Video & Audio</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink13" NavigateUrl="~/category/Tablets" runat="server">Tablets</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-xs-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink14" NavigateUrl="~/category/Tablet Accessories" runat="server">Tablet Accessories</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink15" NavigateUrl="~/category/Blutooth Devices" runat="server">Blutooth Devices</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink16" NavigateUrl="~/category/Speakers" runat="server">Speakers</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink17" NavigateUrl="~/category/Networking" runat="server">Networking</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-xs-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink18" NavigateUrl="~/category/Security Systems" runat="server">Security Systems</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink19" NavigateUrl="~/category/Gaming" runat="server">Gaming</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink20" NavigateUrl="~/category/Home Appliances" runat="server">Home Appliances</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink21" NavigateUrl="~/category/Kitchen Appliances" runat="server">Kitchen Appliances</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-xs-12">
                                    <li><a class="active" href="index.html">Home Main Version</a> </li>
                                    <li><a href="index-01.html">Home Version 1</a> </li>
                                    <li><a href="index-02.html">Home Version 2</a> </li>
                                    <li><a href="index-03.html">Home Version 3</a> </li>
                                    <li><a href="index-04.html">Home Version 4</a> </li>
                                    <li><a href="index-05.html">Home Version 5</a> </li>
                                    <li><a href="index-06.html">Home Version 6</a> </li>
                                    <li><a href="index-07.html">Home Version 7</a> </li>
                                </ul>
                                <ul class="col-sm-2 col-xs-12">
                                    <li><a class="active" href="index.html">Home Main Version</a> </li>
                                    <li><a href="index-01.html">Home Version 1</a> </li>
                                    <li><a href="index-02.html">Home Version 2</a> </li>
                                    <li><a href="index-03.html">Home Version 3</a> </li>
                                    <li><a href="index-04.html">Home Version 4</a> </li>
                                    <li><a href="index-05.html">Home Version 5</a> </li>
                                    <li><a href="index-06.html">Home Version 6</a> </li>
                                    <li><a href="index-07.html">Home Version 7</a> </li>
                                </ul>
                            </div>
                        </li>--%>
                        <li>
                            <asp:HyperLink ID="hlSHBM" NavigateUrl="~/MerchantStore.aspx" ClientIDMode="Static"
                                runat="server"><i class="fa fa-shopping-cart icon-middle"></i>&nbsp;&nbsp;SHOP BY MERCHANT&nbsp;<span class="caret"></span></asp:HyperLink>
                            <div class="dropdown">
                                <ul class="col-sm-2 col-sx-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink5" CssClass="active" NavigateUrl="" runat="server">Travel</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink34" NavigateUrl="~/Merchant/Makemytrip" runat="server">Makemytrip</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink35" NavigateUrl="~/Merchant/Goibibo" runat="server">Goibibo</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink36" NavigateUrl="~/Merchant/Travelguru" runat="server">Travelguru</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink49" NavigateUrl="~/Merchant/Expedia" runat="server">Expedia</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink50" NavigateUrl="~/Merchant/Cleartrip" runat="server">Cleartrip</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink51" NavigateUrl="~/Merchant/Musafir" runat="server">Musafir</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink52" NavigateUrl="~/Merchant/Ticketgoose" runat="server">Ticketgoose</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink53" NavigateUrl="~/Merchant/Thomascook" runat="server">Thomascook</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink54" NavigateUrl="~/Merchant/Vistara" runat="server">Vistara</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink83" NavigateUrl="" CssClass="active" runat="server">Hotels</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink84" NavigateUrl="~/Merchant/OYO Rooms" runat="server">OYO Rooms</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink85" NavigateUrl="~/Merchant/ZO Rooms" runat="server">ZO Rooms</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-sx-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink41" NavigateUrl="" CssClass="active" runat="server">Health</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink58" NavigateUrl="~/Merchant/1mg" runat="server">1mg</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink42" NavigateUrl="~/Merchant/Healthkart" runat="server">Healthkart</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink43" NavigateUrl="~/Merchant/Healthians" runat="server">Healthians</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink44" NavigateUrl="~/Merchant/Healthgenie" runat="server">Healthgenie</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink57" NavigateUrl="~/Merchant/Lenskart" runat="server">Lenskart</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink69" NavigateUrl="~/Merchant/Himalaya" runat="server">Himalaya</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink7" NavigateUrl="" CssClass="active" runat="server">Babies and toys</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink8" NavigateUrl="~/Merchant/Firstcry" runat="server">Firstcry</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink9" NavigateUrl="~/Merchant/Babyoye" runat="server">Babyoye</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink22" NavigateUrl="~/Merchant/Hopscotch" runat="server">Hopscotch</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink23" NavigateUrl="~/Merchant/Kidskart" runat="server">Kidskart</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink24" NavigateUrl="~/Merchant/KinderCart" runat="server">KinderCart</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-sx-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink45" CssClass="active" NavigateUrl="" runat="server">Electronins</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink46" NavigateUrl="~/Merchant/Amazon" runat="server">Amazon</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink47" NavigateUrl="~/Merchant/Flipkart" runat="server">Flipkart</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink48" NavigateUrl="~/Merchant/Paytm" runat="server">Paytm</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink59" NavigateUrl="~/Merchant/Snapdeal" runat="server">SnapDeal</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink60" NavigateUrl="~/Merchant/Shopclues" runat="server">Shop Clue</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink74" NavigateUrl="~/Merchant/Shopcj" runat="server">Shop CJ</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink61" NavigateUrl="~/Merchant/Ebay" runat="server">Ebay</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink62" NavigateUrl="~/Merchant/Homeshop18" runat="server">HomeShop18</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink63" NavigateUrl="~/Merchant/Times Internet" runat="server">India Times</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink64" NavigateUrl="~/Merchant/Rediff Shopping" runat="server">Rediff</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink65" NavigateUrl="~/Merchant/Askmebazaar" runat="server">Askmebazaar</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-sx-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink66" NavigateUrl="" CssClass="active" runat="server">Clothing</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink67" NavigateUrl="~/Merchant/Amazon" runat="server">Amazon</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink6" NavigateUrl="~/Merchant/American Swan" runat="server">American Swan</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink68" NavigateUrl="~/Merchant/Flipkart" runat="server">Flipkart</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink70" NavigateUrl="~/Merchant/Paytm" runat="server">Paytm</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink71" NavigateUrl="~/Merchant/Snapdeal" runat="server">SnapDeal</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink72" NavigateUrl="~/Merchant/Shopclues" runat="server">Shop Clue</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink73" NavigateUrl="~/Merchant/Ebay" runat="server">Ebay</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink76" NavigateUrl="~/Merchant/Rediff Shopping" runat="server">Rediff</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink77" NavigateUrl="~/Merchant/Askmebazaar" runat="server">Askmebazaar</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink78" NavigateUrl="~/Merchant/Jabong" runat="server">Jabong</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink31" NavigateUrl="~/Merchant/Cross Roads" runat="server">Cross Roads</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-sx-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink25" NavigateUrl="" CssClass="active" runat="server">HomeFurnishings</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink26" NavigateUrl="~/Merchant/Homeshop18" runat="server">Homeshop18</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink27" NavigateUrl="~/Merchant/Pepperfry" runat="server">Pepperfry</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink28" NavigateUrl="~/Merchant/Indiarush" runat="server">Indiarush</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink29" NavigateUrl="~/Merchant/Shopcj" runat="server">Shopcj</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink30" NavigateUrl="~/Merchant/Fabfurnish" runat="server">Fabfurnish</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink86" NavigateUrl="" CssClass="active" runat="server">Fashion</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink87" NavigateUrl="~/Merchant/Yepme" runat="server">Yepme</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink88" NavigateUrl="~/Merchant/Zivame" runat="server">Zivame</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink89" NavigateUrl="~/Merchant/Trendin" runat="server">Trendin</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink90" NavigateUrl="~/Merchant/Fashionara Enterprise Private Ltd"
                                            runat="server">Fashionara</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink91" NavigateUrl="~/Merchant/Freecultr" runat="server">Freecultr</asp:HyperLink></li>
                                </ul>
                                <ul class="col-sm-2 col-sx-12">
                                    <li>
                                        <asp:HyperLink ID="HyperLink32" NavigateUrl="" CssClass="active" runat="server">Others</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink33" NavigateUrl="~/Merchant/Archies Online" runat="server">Archies Online</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink37" NavigateUrl="~/Merchant/Bata" runat="server">Bata</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink38" NavigateUrl="~/Merchant/Body Shop" runat="server">Body Shop</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink39" NavigateUrl="~/Merchant/Clovia" runat="server">Clovia</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink40" NavigateUrl="~/Merchant/Droom" runat="server">Droom</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink55" NavigateUrl="~/Merchant/Ferns N Petals Pvt. Ltd."
                                            runat="server">Ferns N Petals</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink56" NavigateUrl="~/Merchant/Gifts By Meeta" runat="server">Gifts By Meeta</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink75" NavigateUrl="~/Merchant/Groupon" runat="server">Groupon</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink79" NavigateUrl="~/Merchant/Koovs" runat="server">Koovs</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink80" NavigateUrl="~/Merchant/Myflowertree" runat="server">Myflowertree</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink81" NavigateUrl="~/Merchant/Nykaa" runat="server">Nykaa</asp:HyperLink></li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink82" NavigateUrl="~/Merchant/Printvenue" runat="server">Printvenue</asp:HyperLink></li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink92" NavigateUrl="~/MerchantStore.aspx" ClientIDMode="Static"
                                runat="server"><i class="fa fa-shopping-cart icon-middle"></i>&nbsp;&nbsp;ALL MERCHANT</asp:HyperLink>
                        </li>
                        <%--<li><a href="#">SHOP BY BRAND <span class="caret"></span></a>
                                <div class="dropdown">
                                    <ul class="col-sm-2 col-sx-12">
                                        <li>
                                            <asp:HyperLink ID="HyperLink6" NavigateUrl="~/Brand/All/208" CssClass="active" runat="server">Mobile Phones & Tablets</asp:HyperLink>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink7" NavigateUrl="~/Brand/Micromax/208" runat="server">Micromax</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink8" NavigateUrl="~/Brand/Nokia/208" runat="server">Nokia</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink9" NavigateUrl="~/Brand/Samsung/208" runat="server">Samsung</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink22" NavigateUrl="~/Brand/Nexus/208" runat="server">Nexus</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink23" NavigateUrl="~/Brand/Apple/208" runat="server">Apple</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink24" NavigateUrl="~/Brand/Motorola/208" runat="server">Motorola</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink25" NavigateUrl="~/Brand/HTC/208" runat="server">HTC</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink26" NavigateUrl="~/Brand/Xolo/208" runat="server">Xolo</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink27" NavigateUrl="~/Brand/Gionee/208" runat="server">Gionee</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink28" NavigateUrl="~/Brand/Blackberry/208" runat="server">Blackberry</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink29" NavigateUrl="~/Brand/Karbonn/208" runat="server">Karbonn</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink30" NavigateUrl="~/Brand/Asus/208" runat="server">Asus</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink31" NavigateUrl="~/Brand/Huawei/208" runat="server">Huawei</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink32" NavigateUrl="~/Brand/Lava/208" runat="server">Lava</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink33" NavigateUrl="~/Brand/Intex/208" runat="server">Intex</asp:HyperLink></li>
                                    </ul>
                                    <ul class="col-sm-2 col-sx-12">
                                        <li>
                                            <asp:HyperLink ID="HyperLink39" CssClass="active" NavigateUrl="~/Brand/All/209" runat="server">Electronics & Appliances</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink55" NavigateUrl="~/Brand/Dell/209" runat="server">Dell</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink56" NavigateUrl="~/Brand/Sony/209" runat="server">Sony</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink75" NavigateUrl="~/Brand/Microsoft/209" runat="server">Microsoft</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink79" NavigateUrl="~/Brand/LG/209" runat="server">LG</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink80" NavigateUrl="~/Brand/HP/209" runat="server">HP</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink81" NavigateUrl="~/Brand/Canon/209" runat="server">Canon</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink82" NavigateUrl="~/Brand/Lenovo/209" runat="server">Lenovo</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink83" NavigateUrl="~/Brand/Panasonic/209" runat="server">Panasonic</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink84" NavigateUrl="~/Brand/Philips/209" runat="server">Philips</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink85" NavigateUrl="~/Brand/Videocon/209" runat="server">Videocon</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink86" NavigateUrl="~/Brand/Intex/209" runat="server">Intex</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink87" NavigateUrl="~/Brand/Nikon/209" runat="server">Nikon</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink88" NavigateUrl="~/Brand/Sandisk/209" runat="server">Sandisk</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink89" NavigateUrl="~/Brand/Acer/209" runat="server">Acer</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink90" NavigateUrl="~/Brand/Toshiba/209" runat="server">Toshiba</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink91" NavigateUrl="~/Brand/Whirlpool/209" runat="server">Whirlpool</asp:HyperLink></li>
                                    </ul>
                                </div>
                            </li>--%>
                    </ul>
                </div>
                 
                <!-- End Navigation List -->
            </div>
        </div>
    </div>
</div>

