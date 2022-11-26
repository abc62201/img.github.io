	function tiaozhuan(self)
{
	var web_url = self;	
	web_url=web_url.replace("/","\\");
window.external.indexY(web_url);
}
function k_dw()
{
	//alert("dw")
}
function k_up()
{
	//alert("up")
}
function k_left()
{
	//alert("left")
}
function k_right()
{
	//alert("right")
}
function k_start()
{
	//alert("start")
}
function k_last()
{
	//alert("last")
	document.documentElement.scrollTop-=100;
}
function k_next()
{
	//alert("next")
	document.documentElement.scrollTop+=100;
}
document.onkeydown=function(event)
 {


 if(event.keyCode == 123){
 window.external.shezhi();
 }
  
  }