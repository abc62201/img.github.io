var intNO=0;
var inttxt1="";
var intro_d1;
var intro_d2;
var gun=false;
function jingyin(){
	
	document.getElementById('video-player').muted = true;
}
function shengyin(){
	document.getElementById('video-player').muted = false;
}
function IEVersion() {
// if (document.documentMode) return document.documentMode;
   let userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
   let isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1; //判断是否IE<11浏览器
   let isEdge = userAgent.indexOf("Edge") > -1 && !isIE; //判断是否IE的Edge浏览器
   let isIE11 = userAgent.indexOf('Trident') > -1 && userAgent.indexOf("rv:11.0") > -1;
  	if(isIE) {
      let reIE = new RegExp("MSIE (\\d+\\.\\d+);");
      reIE.test(userAgent);
      let fIEVersion = parseFloat(RegExp["$1"]);
      if(fIEVersion == 7) {
        return 7;
      } else if(fIEVersion == 8) {
        return 8;
      } else if(fIEVersion == 9) {
        return 9;
      } else if(fIEVersion == 10) {
        return 10;
      } else {
        return 6;//IE版本<=7
      }
    } else if(isEdge) {
      return 'edge';//edge
    } else if(isIE11) {
      return 11; //IE11
    }else{
      return -1;//不是ie浏览器
    }
}

window.onload=function(){
	window.external.chushi();
	document.getElementById("ziti").focus();
	document.getElementById("xuanzhong").setAttribute("style","background-color: #ffffff");
//鼠标右键被单击

document.onmousedown = function(){
if(event.button == 2){
window.external.htmlDoc_ContextMenuShowing();
			return false;
	}
}
		
var js_fmt = document.getElementById("fmt").src;
if(js_fmt="")
{
document.getElementById("fmt").style.display='none';
}
var js_yemei = document.getElementById("yemei").src;
if(js_yemei="")
{
document.getElementById("yemei").style.display='none';
}
var js_logo = document.getElementById("logo").src;
if(js_logo="")
{
document.getElementById("logo").style.display='none';
}
var js_dsh = document.getElementById("dsh").src;
if(js_dsh="")
{
document.getElementById("dsh").style.display='none';
}
var js_jiz = document.getElementById("jiz").src;
if(js_jiz="")
{
document.getElementById("jiz").style.display='none';
}
var js_renwu = document.getElementById("renwu").src;
if(js_renwu="")
{
document.getElementById("renwu").style.display='none';
}
var js_mengban = document.getElementById("mengban").src;
if(js_mengban="")
{
document.getElementById("mengban").style.display='none';
}
 liebiao();
 
 intNO=document.getElementById("ziti").selectedIndex;
 
 inttxt1=document.getElementsByTagName("option")[intNO].innerHTML;
 
obj = document.getElementById("listtxt"); 
if (obj){  romtxt(); } else{init();}


//alert(document.getElementById("intro_d1").offsetHeight);
intro=document.getElementById("intro");
intro_d1=document.getElementById("intro_d1");
intro_d2=document.getElementById("intro_d2");

var scrollSpeed=200;//值越大，滚动的越慢
if(intro_d1.offsetHeight>intro.offsetHeight){
intro_d2.innerHTML=intro_d1.innerHTML;
}
function ScrollMarquee(){
	
if(intro_d1.offsetHeight>intro.offsetHeight){
if(intro_d2.offsetTop-intro.scrollTop<=0){

intro.scrollTop-=intro_d1.offsetHeight;
}

else{
intro.scrollTop++;

}
}
}

var ScrollTime=setInterval(ScrollMarquee,scrollSpeed);
if(IEVersion()!="11"){
	 window.external.dwie11();
}
}


document.onkeydown=function(event)
 {


 if(event.keyCode == 123){
 window.external.shezhi();
 }
 //禁用上下左右按键
if(event.keyCode==37||event.keyCode==38||event.keyCode==39||event.keyCode==40){
		event.preventDefault();
	}
	
if(event.keyCode==37||event.keyCode==38||event.keyCode==39||event.keyCode==40){
				window.event.returnValue == false;
		}
 }
  
   function romtxt(){ 
   	intro_d1=document.getElementById("intro_d1");
	intro_d2=document.getElementById("intro_d2");
	if(intro_d1.offsetHeight>intro.offsetHeight){
	intro_d2.innerHTML=intro_d1.innerHTML;}
   document.getElementById("listtxt").innerHTML=document.getElementsByTagName("option")[document.getElementById("ziti").selectedIndex].innerHTML;
   window.setTimeout(romtxt,500);
   }
  
  function init(){ 
  
 var caidan=document.getElementById("ziti").selectedIndex;
var os=document.getElementsByTagName("option"); 

 if(gun){
var tx=os[caidan].innerHTML; 
tx=tx.replace("&nbsp;","")
var l=tx.length; 
var b=tx.substring(0,1); 
var e=tx.substring(1); 

if(intNO==caidan){
	os[caidan].innerHTML=e; 
	
}else
{
	
	intro_d1=document.getElementById("intro_d1");
	intro_d2=document.getElementById("intro_d2");
	if(intro_d1.offsetHeight>intro.offsetHeight){
	intro_d2.innerHTML=intro_d1.innerHTML;}
	
	 try {
		 
		// inttxt1=os[intNO].innerHTML;
	os[intNO].innerHTML=inttxt1; 
	 //alert(intNO);
	intNO=caidan;
	inttxt1=os[intNO].innerHTML;
	gun=false;
	}
	catch(err) {
     intNO=document.getElementById("ziti").selectedIndex;

	gun=false;
	
}
}
if(l<=0){
	
	
	os[intNO].innerHTML=inttxt1;
}
 }
 if(gun){
	 window.setTimeout(init,200);
 }else{
	 
	 
 window.setTimeout("gun=true;init();",2000); 
 }
} 

function intNO_up_text(text1){
	
	inttxt1=text1;
	intNO=0;
}


var scrollFunc = function (e) {  
        e = e || window.event;  
        if (e.wheelDelta) {  //判断浏览器IE，谷歌滑轮事件               
            if (e.wheelDelta > 50) { //当滑轮向上滚动时 
window.external.htmdoc_wheel_dw();			
               
            }  
            if (e.wheelDelta < -50) { //当滑轮向下滚动时  
                 window.external.htmdoc_wheel_up();
            }  
        } else if (e.detail) {  //Firefox滑轮事件  
            if (e.detail> 50) { //当滑轮向下滚动时  
             window.external.htmdoc_wheel_dw();	
            }  
            if (e.detail< -50) { //当滑轮向上滚动时  
                window.external.htmdoc_wheel_up();
            }  
        }  
    } 
    /*IE、Opera注册事件*/
    if(document.attachEvent){
        document.attachEvent('onmousewheel',scrollFunc);
 
    }
    //Firefox使用addEventListener添加滚轮事件  
    if (document.addEventListener) {//firefox  
        document.addEventListener('DOMMouseScroll', scrollFunc, false);  
    }  
    //Safari与Chrome属于同一类型
    window.onmousewheel = document.onmousewheel = scrollFunc; 
	function color_web(ziti_color,a_color,a_bgcolor,az_color,az_bgcolor,intro_color,intro_bgcolor)
{
var url;
//超链接字体颜色
url=document.getElementById("id1").getElementsByTagName("a");
for(i=0;i<url.length;i++){
url[i].style.color=a_color
}

//alert(a_bgcolor);
document.getElementById("id1").style.background = a_bgcolor;
//超链接背景颜色
document.getElementById("xuanzhong").style.color=az_color;
//超链接选中后的字体颜色
document.getElementById("xuanzhong").style.background=az_bgcolor;
//超链接选中后背景颜色
document.getElementById("intro").style.color=intro_color;
//信息栏字体颜色
document.getElementById("intro").style.background=intro_bgcolor;
//信息栏背景颜色
document.getElementById("ziti").style.color=ziti_color;
//菜单栏字体颜色
}