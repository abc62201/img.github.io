
var index_li="";
for (i = 0; i < text_name.length; i++) {
    index_li+= "<li>";
	index_li+="<div>\n";
			index_li+='<a href=""onclick="tiaozhuan(';
			index_li+="'"+text_name[i].web_url+"')";
			index_li+='">\n';
			index_li+='<img src="';
			index_li+=text_name[i].img_url;
			index_li+='"alt="" width="235" height="188" border="0" title="">\n';
			index_li+='</img>\n';
			index_li+='</a>\n';
			index_li+='</div>\n';
			index_li+='<div>\n';
			index_li+='</div>\n';
			index_li+='<ul class="azen-viewit list-viewit"></ul>\n';
			index_li+='<div class="azen-paddin">\n';
			index_li+='<a href=""onclick="tiaozhuan(';
			index_li+="'"+text_name[i].web_url+"')";
			index_li+='">'+text_name[i].name+'</a>\n';
			index_li+='</div>\n';
			index_li+='</li>\n';
}

document.getElementById("demo").innerHTML = index_li;