var li_shu=0;
function ul_li_chushi(li_shu2)
{
	document.getElementsByTagName("li")[li_shu2].setAttribute("style","text-shadow: 2px 2px 5px red; ");
}
	function ul_li(rom_name,rom_NO,li_shu1)
{
	li_shu=li_shu1;
var list_li=document.getElementById("list_cs").innerHTML;
 list_li+= "<li>";
 list_li+= rom_name;
 list_li+= "</li>";
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
	document.getElementsByTagName("li")[op_no-1].setAttribute("style","");
	document.getElementsByTagName("li")[op_no].setAttribute("style","text-shadow: 2px 2px 5px red; ");
	
	}else{
	document.getElementsByTagName("li")[op_no].setAttribute("style","text-shadow: 2px 2px 5px red; ");
	
	}
}
function k_up()
{
	var op_no=document.getElementById("ziti").selectedIndex;
	if(op_no<li_shu){
	document.getElementsByTagName("li")[op_no].setAttribute("style","text-shadow: 2px 2px 5px red; ");
	document.getElementsByTagName("li")[op_no+1].setAttribute("style","");
	}else{
		document.getElementsByTagName("li")[op_no].setAttribute("style","text-shadow: 2px 2px 5px red; ");
	}
}