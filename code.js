
	function recordClick(ad_id){
if (window.XMLHttpRequest) httpRequest = new XMLHttpRequest();
	if (window.ActiveXObject) httpRequest = ActiveXObject("Microsoft.XMLHTTP");
		httpRequest.open( "POST", "http://theadstracker.com/click.php", true );
		httpRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		httpRequest.send("ID="+ad_id);
	}

	function recordLoad(ad_id){
if (window.XMLHttpRequest) httpRequest = new XMLHttpRequest();
	if (window.ActiveXObject) httpRequest = ActiveXObject("Microsoft.XMLHTTP");
		httpRequest.open( "POST", "http://theadstracker.com/load.php", true );
		httpRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		httpRequest.send("ID="+ad_id);
	}

