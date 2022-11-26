$(function(){
			$('#keyboard').keyboard({
			layout: 'custom',
			display : {  
                'accept' : '确定:Accept (Shift-Enter)', 
				'bksp'   : '退格:Backspace', 
                'c'      : '取消:Cancel (Esc)', 
			},
		customLayout: {
			'default' : [
				'1 2 3 4 5 6 7 8 9 0',
				'Q W E R T Y U I O P',
				'A S D F G H J K L {bksp}',
				'{accept} Z X C V B N M {c} ',

				
			]
		},
		//maxLength : 6,
		restrictInput : true, // Prevent keys not in the displayed keyboard from being typed in
		useCombos : false, // don't want A+E to become a ligature
		acceptValid: true,
validate: function(keyboard, value, isClosing){
if(isClosing){
window.external.search(value);
}
return value.length > 0;
}
			   
			});
		});
function sou(){
	var input = document.getElementById("keyboard").value;
	if(input=="")
	{document.getElementById("keyboard").focus();
}	

	document.getElementById("keyboard").value="";
	
	}