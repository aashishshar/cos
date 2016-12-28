$('#logintosingup').click(function(){	
	$('#loginModal').removeClass('in');
	$("#loginModal").attr( "aria-hidden", "true" );
	$('#loginModal').hide();
	$('#regModal').addClass('in');	
	$("#regModal").attr( "aria-hidden", "false" );
	$('#regModal').slideDown( "slow" );	
});

$('#signuptologin').click(function(){
	
	$('#regModal').removeClass('in');
	$("#regModal").attr( "aria-hidden", "true" );
	$('#regModal').hide();
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

