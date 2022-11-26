
var index_li="";

var index_li_index=0;
var index_sul=document.getElementById("flipbook");
index_li=index_sul.innerHTML;
for (i = 0; i < text_name.length; i++) {
    
			index_li+='<div>';
			index_li+='<a href="#1"onclick="tiaozhuan(';
			index_li+="'"+text_name[i].web_url+"')";
			index_li+='">\n';
			index_li+='<img src="';
			index_li+=text_name[i].img_url_left;
			index_li+='"alt="" width="100%" height="100%" border="0" title="">\n';
			index_li+='</img>\n';
			index_li+='</a>\n';
			index_li+='</div>\n';
			
			index_li+='<div>';
			index_li+='<a href="#1"onclick="tiaozhuan(';
			index_li+="'"+text_name[i].web_url+"')";
			index_li+='">\n';
			index_li+='<img src="';
			index_li+=text_name[i].img_url_right;
			index_li+='"alt="" width="100%" height="100%" border="0" title="">\n';
			index_li+='</img>\n';
			index_li+='</a>\n';
			index_li+='</div>\n';
}
index_sul.innerHTML = index_li;
document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[0].bi_url+");");
function index_html(index_html_index){			
	index_li_index=index_html_index;
	
	}
window.onload=function(){
	window.external.weizhi();
	window.external.fanye_audio("html\\basic\\11133.wav");
	function loadApp() {
		$('.flipbook').turn({
			width: 914,
			height: 643,
			elevation: 500,
			gradients: true,
			autoCenter: true

		});
		if(index_li_index==0){
		$(".flipbook").turn("page",2);
		//$(".flipbook").turn("next");
	}else{
	
		$(".flipbook").turn("page",(index_li_index+1)*2);
		
	}	
document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[index_li_index].bi_url+");");

	}
	yepnope({
		test: Modernizr.csstransforms,
		yep: ['basic/lib/turn.js'],
		nope: ['basic/lib/turn.html4.min.js'],
		both: ['basic/css/basic.css'],
		complete: loadApp
		
	});

	$(".prev-btn").on("click", function (event) {
		index_left();
	});
	//上一页按钮
	$(".next-btn").on("click", function (event) {
	
		index_right();
	});

	$('.seal').on('click', function () {
		var str = '梦童年'; //假设公司名称
		var letter = str.split('');
		var o = 7 - Math.floor(letter.length / 2);
		$(this).parent().siblings('.box').children('span').html();
		for (var i = 0; i < letter.length; i++) {
			$(this).parent().siblings('.box').children('span').eq(o + i).html(letter[i]);
		}
		$(this).hide().siblings('.qx-seal').show().parent().siblings('.box').show();
	})
	
	$('.qx-seal').on('click', function () {
		$(this).hide().siblings('.seal').show().parent().siblings('.box').hide();
	})

	$('.disabled').find('input').attr('disabled', 'disabled');
	$('.disabled').find('.seal').attr('disabled', 'disabled');
}


	function index_left(){
		
		window.external.fanye_audio("html\\basic\\11133.wav");
		if(index_li_index>0){
			$(".flipbook").turn("previous");
		index_li_index=index_li_index-1
		document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[index_li_index].bi_url+");");

	}
	if(index_li_index==0){
		//$(".flipbook").turn("page",2);
	}
	}
	function index_right(){
		
		window.external.fanye_audio("html\\basic\\11133.wav");
	if(text_name.length-1>index_li_index){
		$(".flipbook").turn("next");
		index_li_index=index_li_index+1;
		document.getElementById("zhuye").setAttribute("style", "background-image:url("+text_name[index_li_index].bi_url+");");

	}
}