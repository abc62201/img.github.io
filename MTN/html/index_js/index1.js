	function tiaozhuan(self)
{
	var web_url = self;	
	web_url=web_url.replace("/","\\");
//window.external.indexY(web_url);
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
	//alert(index_li_left);

	index_right();

}
function k_right()
{
	//alert("right")
	index_left();

}
function k_start()
{
	//alert(text_name[index_li_index].web_url);
		var web_url = text_name[index_li_index].web_url;	
	web_url=web_url.replace("/","\\");
window.external.indexY(web_url);
}
function k_last()
{
	//alert("last")
	
}
function k_next()
{
	//alert("next")

}
document.onkeydown=function(event)
 {


 if(event.keyCode == 123){
 window.external.shezhi();
 }
  
  }