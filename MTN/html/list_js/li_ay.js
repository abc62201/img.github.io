var li_shu=0;
function ul_li_chushi(li_shu2)
{
	document.getElementsByTagName("article")[li_shu2].setAttribute("style","transform: scale(1.2);box-shadow: 0 9px 47px 11px rgba(51, 51, 51, 0.18); ");
}
	function ul_li(rom_name,rom_NO,li_shu1)
{
li_shu=li_shu1;
var list_li=document.getElementById("list_cs").innerHTML;
list_li+="<li>";
  list_li+="<article class='leaderboard__profile'>";
  //list_li+=" <img src='list_js/img/32.jpg' class='leaderboard__picture'/>";
   list_li+="<span class='leaderboard__name'>"+rom_name+'</span>';     
   list_li+=" </article>";
   list_li+="</li>";
document.getElementById("list_cs").innerHTML = list_li;
var op_no=document.getElementById("ziti").selectedIndex;
var li_no=document.getElementsByTagName("li").length;
}
function ul_li_c()
{
	document.getElementById("list_cs").innerHTML =""
}
function k_dw()
{
	var op_no=document.getElementById("ziti").selectedIndex;
	if(op_no>0){
	document.getElementsByTagName("article")[op_no-1].setAttribute("style","");
	document.getElementsByTagName("article")[op_no].setAttribute("style","transform: scale(1.2);box-shadow: 0 9px 47px 11px rgba(51, 51, 51, 0.18); ");
	window.external.fanye_audio("html\\list_js\\listm.wav");
	}else{
	document.getElementsByTagName("article")[op_no].setAttribute("style","transform: scale(1.2);box-shadow: 0 9px 47px 11px rgba(51, 51, 51, 0.18); ");
	
	}
}
function k_up()
{
	var op_no=document.getElementById("ziti").selectedIndex;
	if(op_no<li_shu){
	document.getElementsByTagName("article")[op_no].setAttribute("style","transform: scale(1.2);box-shadow: 0 9px 47px 11px rgba(51, 51, 51, 0.18); ");
	document.getElementsByTagName("article")[op_no+1].setAttribute("style","");
	window.external.fanye_audio("html\\list_js\\listm.wav");
	}else{
		document.getElementsByTagName("article")[op_no].setAttribute("style","transform: scale(1.2);box-shadow: 0 9px 47px 11px rgba(51, 51, 51, 0.18); ");
	}
}