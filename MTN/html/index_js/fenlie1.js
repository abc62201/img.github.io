
var index_li="";
var index_li_NO=text_name.length-1;
var index_li_index=0;
var li_index=1;
var index_li_left=0;
var w;
var left;
var index_sul=document.getElementById("index_ul");
for (i = 0; i < text_name.length; i++) {
    index_li+= "<li>";
	
			index_li+='<a href="#1"onclick="tiaozhuan(';
			index_li+="'"+text_name[i].web_url+"')";
			index_li+='">\n';
			index_li+='<img src="';
			if(text_name[i].img_url=="kong"){
				index_li+="../theme/logo.png";
			}else{
				index_li+=text_name[i].img_url;}
			index_li+='"alt="" width="520" height="250" border="0" title="">\n';
			index_li+='</img>\n';
			index_li+='</a>\n';

			index_li+='</li>\n';
}
index_li_left=(window.innerWidth/2)-(904/2)-125;
index_sul.setAttribute("style","left:"+(index_li_left).toString()+"px;");
index_sul.innerHTML = index_li;
index_sul.getElementsByTagName("li")[0].setAttribute("style","opacity:1;");
var index_li_css=index_sul.getElementsByTagName("li");
index_li_css[index_li_index].getElementsByTagName("img")[0].setAttribute("style","width:900px;height:450px;position:relative;top:-150px;");

document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[0].bi_url+");");
w=index_sul.getElementsByTagName("li")[0].offsetWidth;
left=index_sul.getElementsByTagName("li")[0].offsetLeft;
function index_html(index_html_index){
	//alert(left);
	index_li_index=index_html_index;
	li_index=index_html_index+1;
		if(index_li_NO>=index_li_index & index_li_index>0){
	index_li_left=(window.innerWidth/2)-(904/2)*li_index-(262*index_li_index+30);
	index_sul.setAttribute("style","left:"+(index_li_left).toString()+"px;");
index_sul.getElementsByTagName("li")[index_li_index].setAttribute("style","opacity:1;");
var index_li_css=index_sul.getElementsByTagName("li");
index_li_css[index_li_index].getElementsByTagName("img")[0].setAttribute("style","width:900px;height:450px;position:relative;top:-150px;");
index_li_css[0].getElementsByTagName("img")[0].setAttribute("style","width:540px;height:250px;");
index_sul.getElementsByTagName("li")[0].setAttribute("style","opacity:0.2;");
document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[index_li_index].bi_url+");");
	}
}
	
function index_left(){
	if(index_li_NO>index_li_index){
	index_li_index=index_li_index+1;
	li_index=li_index+1;
	index_li_left=(window.innerWidth/2)-(904/2)*li_index-(262*index_li_index+30);
	//alert(window.innerWidth);
	index_sul.setAttribute("style","left:"+(index_li_left).toString()+"px");
	
index_sul.getElementsByTagName("li")[index_li_index].setAttribute("style","opacity:1;");
var index_li_css=index_sul.getElementsByTagName("li");
index_li_css[index_li_index].getElementsByTagName("img")[0].setAttribute("style","width:900px;height:450px;position:relative;top:-150px;");
index_sul.getElementsByTagName("li")[index_li_index-1].setAttribute("style","opacity:0.2;");
index_li_css[index_li_index-1].getElementsByTagName("img")[0].setAttribute("style","width:540px;height:250px;");
document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[index_li_index].bi_url+");");
//alert(index_sul.getElementsByTagName("li")[index_li_index].offsetLeft-((904/2)*li_index+(262*index_li_index)+30));
	}
}
function index_right(){
	if(index_li_index>0){
	index_li_index=index_li_index-1;
	li_index=li_index-1;
	index_li_left=(window.innerWidth/2)-(904/2)*li_index-(262*index_li_index+30);
	
	//alert(index_sul.getElementsByTagName("li")[index_li_index].offsetLeft);
	index_sul.setAttribute("style","left:"+(index_li_left).toString()+"px;");
index_sul.getElementsByTagName("li")[index_li_index].setAttribute("style","opacity:1;");

var index_li_css=index_sul.getElementsByTagName("li");
index_li_css[index_li_index].getElementsByTagName("img")[0].setAttribute("style","width:900px;height:450px;position:relative;top:-150px;");
index_sul.getElementsByTagName("li")[index_li_index+1].setAttribute("style","opacity:0.2;");
index_li_css[index_li_index+1].getElementsByTagName("img")[0].setAttribute("style","width:540px;height:250px;");
document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[index_li_index].bi_url+");");

	}
}
window.onload=function(){
	window.external.weizhi();
}