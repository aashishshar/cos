$('#logintosingup').click(function(){	
	

	$('#loginModal').removeClass('in');
	$("#loginModal").attr( "aria-hidden", "true" );
	$('#loginModal').hide();
	$('#registerModal').addClass('in');	
	$("#registerModal").attr( "aria-hidden", "false" );
	$('#registerModal').slideDown( "slow" );	
});

$('#signuptologin').click(function(){
	
	$('#registerModal').removeClass('in');
	$("#registerModal").attr( "aria-hidden", "true" );
	$('#registerModal').hide();
	$('#loginModal').addClass('in');
	$("#loginModal").attr( "aria-hidden", "false" );
	$('#loginModal').slideDown( "slow" );	
});

$('#regclose').click(function(){   
	
	$('body').removeClass('modal-open');
	$('#registerModal').removeClass('in');
	$('#registerModal').attr( "aria-hidden", "true" );
	/*$('#logsignblack').removeClass('in');*/
	$('div').remove("#logsignblack" );
	$('#registerModal').hide();	
});

$('#logclose').click(function(){   
	
	$('body').removeClass('modal-open');
	$('#loginModal').removeClass('in');
	$('#loginModal').attr( "aria-hidden", "true" );
	/*$('#logsignblack').removeClass('in');*/
	$('div').remove( "#logsignblack" );
	$('#loginModal').hide();
});


$('#loginmodule').click(function(){
	
		
		$('body').addClass('modal-open');
		$('#loginModal').addClass('in');
		$('#loginModal').attr( "aria-hidden", "false" );
		$('#loginModal').slideDown( "slow" );
		/*if (!($('#logsignblack').length)) { 
		  $('<div id="logsignblack" class="modal-backdrop fade in"></div>').appendTo(document.body);
		}*/
		getlatlong();
});
$('#regmodule').click(function(){
		
		$('body').addClass('modal-open');
		$('#registerModal').addClass('in');
		$('#registerModal').attr( "aria-hidden", "false" );
		$('#registerModal').slideDown( "slow" );
		/*if (!($('#logsignblack').length)) { 
		  $('<div id="logsignblack" class="modal-backdrop fade in"></div>').appendTo(document.body);
		}*/
		getlatlong();
});

/*$('body').click(function(){
	if($(this).attr('class').length < 1){ alert("sandeep");
		$('div').remove( ".modal-backdrop" );
	}
});

$("body > div:not(#registerModal)").click(function(e) {
    alert("hi");
});
$(document).click(function(event) { 
    if(!$(event.target).closest('#loginModal').length) {
        if($('#loginModal').is(":visible")) {
            $('#loginModal').hide()
        }
    }        
})*/


/*signup from signup popup 

$( "#popupsignup" ).click(function(){*/
$( "#registerform" ).submit(function( event ) {
	
	$('.bg-red').remove();
	$('.bg-green').remove();
	
	event.preventDefault();
	
	sName  = $('#fullname').val();
	fullnames = fullnamesv(sName);	
	if(fullnames !=1 ){  $( '<p class="bg-red padding">'+fullnames+'</p>' ).insertAfter( "#showregmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	sEmail = $('#emailid').val();
	email_status = emailid(sEmail);
	if(email_status !=1 ){ $( '<p class="bg-red padding">'+email_status+'</p>' ).insertAfter( "#showregmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	sPassword = $('#passwordsign').val();
	password_status = checkStrength(sPassword);
	if(password_status != 1 ){ $( '<p class="bg-red padding">'+password_status+'<br>Password more than 6 character.<br>and use at least a-z and one 0-9.</p>' ).insertAfter( "#showregmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }

	sCaptcha  = $('#fancycaptcha_entered').val();
	if($.trim(sCaptcha).length < 1 ){ $( '<p class="bg-red padding">Please enter valid captch.</p>' ).insertAfter( "#showregmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;  }
	
	var postingpopreg = $.post( '/ajax-calling/action/register/index.php',  $( "#registerform" ).serialize());
	postingpopreg.done(function( data ) {
		if(data == 1){	
			location.href = document.location; return true; /*'/account/profile'; */ 
			return true;
		}else{
			$( '<p class="bg-red padding">'+data+'</p>' ).insertAfter( "#showregmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;
		}
	});	
});

/*login from login popup 

$('#popuplogin').click(function(){*/
$('#loginpop').submit(function( event ) {
	
	$('.bg-red').remove();
	$('.bg-green').remove();
	
	event.preventDefault();

	sUsername  = $('#username').val();
	username = $.trim(sUsername).length;
	if(username < 1 ){ $('<p class="bg-red padding">Please enter valid username or email.</p>' ).insertAfter( "#showloginmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }

	sPassword  = $('#password').val();
	password = $.trim(sPassword).length;
	if(password < 1 ){ $('<p class="bg-red padding">Please enter password.</p>' ).insertAfter( "#showloginmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }

	var postingsp = $.post( '/ajax-calling/action/login/index.php',  $( "#loginpop" ).serialize());
	postingsp.done(function( data ) {
		if(data == 1){	
			location.href = document.location;  return true;/*'/account/profile';*/
		}else{
			$( '<p class="bg-red padding">Invalid Email-Password Combination.</p>' ).insertAfter( "#showloginmsgpop" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;
		}
	});
});

/*Use for GetCashback Login button*/
$('#user_not_reg').click(function(){
		
		$('body').addClass('modal-open');
		$('#registerModal').addClass('in');
		$('#registerModal').attr( "aria-hidden", "false" );
		$('#registerModal').slideDown( "slow" );
		if (!($('#logsignblack').length)) { 
		  $('<div id="logsignblack" class="modal-backdrop fade in"></div>').appendTo(document.body);
		}
});

/*login from login land */
$( "#loginland" ).submit(function( event ) {
			
	$('.bg-red').remove();
	$('.bg-green').remove();
	
	event.preventDefault();
	
	sUsername  = $('#username').val();
	username = $.trim(sUsername).length;
	if(username < 1 ){ $( '<p class="bg-red padding">Please enter valid username or email.</p>' ).insertAfter( "#showloginmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }

	sPassword  = $('#password').val();
	password = $.trim(sPassword).length;
	if(password < 1 ){ $( '<p class="bg-red padding">Please enter password.</p>' ).insertAfter( "#showloginmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	/*var postings = $.post( '/login',  $( "#loginland" ).serialize());*/
	var postings = $.post( '/ajax-calling/action/login/index.php',  $( "#loginland" ).serialize());
	postings.done(function( data ) {
		if(data == 1){	
			value = getCookie('g2p');
			if($.trim(value).length > 0){
				document.cookie = "g2p=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
				location.href = '/go2store/coid/'+value; return true;
			}else{
				/*location.href = '/'; return true;location.href = '/account'; return true;'/account/profile';*/
				location.href =document.referrer; return true;
			}
		}else{
			$( '<p class="bg-red padding">Invallid Email-Password Combination.</p>' ).insertAfter( "#showloginmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;
		}
	});

});

/*register from signup land */
$( "#signup_land" ).submit(function( event ) {
	
	$('.bg-red').remove();
	$('.bg-green').remove();
	
	event.preventDefault();
	
	sName  = $('#fullname').val();
	fullnames = fullnamesv(sName);	
	if(fullnames !=1 ){  $( '<p class="bg-red padding">'+fullnames+'</p>' ).insertAfter( "#showregmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	sEmail = $('#emailid').val();
	email_status = emailid(sEmail);
	if(email_status !=1 ){ $( '<p class="bg-red padding">'+email_status+'</p>' ).insertAfter( "#showregmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	sPassword = $('#passwordsign').val();
	password_status = checkStrength(sPassword);
	if(password_status != 1 ){ $( '<p class="bg-red padding">'+password_status+'<br>Password more than 6 character.<br>and use at least a-z and one 0-9.</p>' ).insertAfter( "#showregmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }

	sCaptcha  = $('#fancycaptcha_entered').val();
	if($.trim(sCaptcha).length < 1 ){ $( '<p class="bg-red padding">Please enter valid captch.</p>' ).insertAfter( "#showregmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;  }
	
	/*var postingreg = $.post( '/register',  $( "#signup_land" ).serialize());*/
	var postingreg = $.post( '/ajax-calling/action/register/index.php',  $( "#signup_land" ).serialize());
	postingreg.done(function( data ) {
		if(data == 1){	
			value = getCookie('g2p');
			if($.trim(value).length > 0){
				document.cookie = "g2p=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
				location.href = '/go2store/coid/'+value; return true;
			}else{
				/*location.href = '/account';'/account/profile';*/;
				location.href =document.referrer; return true;
			}
			return true;
		}else{
			$( '<p class="bg-red padding">'+data+'</p>' ).insertAfter( "#showregmsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;
		}
	});
});

/*forgot password land */
$( "#forgot_land").submit(function( event ) {
	
	$('.bg-red').remove();
	$('.bg-green').remove();

	event.preventDefault();

	sEmail = $('#femailid').val();	
	email_status = emailid(sEmail);
	if(email_status !=1 ){ $( '<p class="bg-red padding">'+email_status+'</p>' ).insertAfter( "#shomsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }

	var posting = $.post( '/forgot',  $( "#forgot_land" ).serialize());
	posting.done(function( data ) {
		if(data == 1){	
			$( '<p class="bg-green padding">Please check your Email to reset your password.</p>' ).insertAfter( "#shomsg" ); $( "#forgot_land" ).hide(); return true;
		}else{
			$( '<p class="bg-red padding">You are not an existing user.</p>' ).insertAfter( "#shomsg" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;
		}
	});
});

/*forgot password land*/
$('#change_forgot_land').submit(function ( event ){ 
	
	$('.bg-red').remove();
	$('.bg-green').remove();

	event.preventDefault();

	sPassword = $('#newpassword').val();
	password_status = checkStrength(sPassword);
	if(password_status != 1 ){ $( '<p class="bg-red padding">'+password_status+'<br>Password more than 6 character.<br>and use at least a-z and one 0-9.</p>' ).insertAfter( "#shomsgcon" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	scPassword = $('#con_password').val();
	if(sPassword != scPassword){ $('<p class="bg-red padding">Password miss match, enter new password and confirm password same.</p>' ).insertAfter( "#shomsgcon" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false; }
	
	var posting = $.post( '/forgot',  $( "#change_forgot_land" ).serialize());
	posting.done(function( data ) {
		if(data == 1){		
			$( '<p class="bg-green padding">Your password update successfully. Please login with your new password.</p>' ).insertAfter( "#shomsgcon" ); $( "#change_forgot_land" ).hide(); return true;
		}else{
			$( '<p class="bg-red padding">Your authentication id miss match.</p>' ).insertAfter( "#shomsgcon" ).delay(13000).queue(function(next){ $('.bg-red').fadeOut('slow').remove(); }); return false;
		}
	});
});


var getlatlong = function(){
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(showPosition);
	}
};

var showPosition =function(position) {
	$('#latitude').val(position.coords.latitude); 
	$('#longitude').val(position.coords.longitude);	
};

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for(var i=0; i<ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1);
        if (c.indexOf(name) != -1) return c.substring(name.length,c.length);
    }
    return "";
} 