var script_arr = [
    'jquery-ui-1.10.1.custom.min.js', 
    'jquery-migrate-1.2.1.min.js',
	'jquery.mousewheel.min.js',
	'jquery.cookies.2.2.0.min.js',
	
	
	'jquery.flot.js',
	'jquery.flot.stack.js',
	'jquery.flot.pie.js',
	'jquery.flot.resize.js',
	'jquery.sparkline.min.js',
	
	
	'jquery.validationEngine-en.js', /*charset="utf-8"*/
	'jquery.validationEngine.js', /*charset="utf-8"*/
	'jquery.mCustomScrollbar.min.js',
	'animated_progressbar.js',
	'jquery.qtip-1.0.0-rc3.min.js',
	'jquery.cleditor.js',
	'jquery.dataTables.min.js',
	'jquery.fancybox.pack.js',
	'jquery.pnotify.min.js',
	'jquery.ibutton.min.js',
	'jquery.scrollUp.min.js'
];

for (var file in script_arr) {
    $.getScript(file);
}