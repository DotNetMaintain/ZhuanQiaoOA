//jquery 获取url参数插件
eval(function(p,a,c,k,e,d){e=function(c){return c.toString(36)};if(!''.replace(/^/,String)){while(c--){d[c.toString(a)]=k[c]||c.toString(a)}k=[function(e){return d[e]}];e=function(){return'\\w+'};c=1};while(c--){if(k[c]){p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c])}}return p}('c.f.i=d(o){2 6=j.h.g();2 5;3(6&&6.9("?")){2 b=6.a("?");2 4=b[1];3(4&&4.9("&")){2 e=4.a("&");c.p(e,d(l,7){3(7&&7.9("=")){2 8=7.a("=");3(o){3(m(o)=="n"&&o==8[0]){5=8[1]==r?\'\':8[1]}}q{5=4}}})}}k 5}',28,28,'||var|if|parms|tmp|url|val|parmarr|indexOf|split|arr|jQuery|function|parmList|fn|toString|location|urlget|window|return|key|typeof|string||each|else|null'.split('|'),0,{}))

function closebox() {
    window.parent.document.body.removeChild(window.parent.document.getElementById("dialogCase"));
}

$(function()
{
	//获取url参数动作
	var action = $().urlget("action");

	//鼠标滑过表格的效果
	$(".table tr").mouseover(function()
	{
		$(this).addClass("hover");
		return false;
	})
	
	//鼠标离开表格的效果
	$(".table tr").mouseout(function()
	{
		$(this).removeClass("hover");
		return false;
	})
	
	//鼠标点击表格的效果
	/*
	$(".table tr").mousedown(function()
	{
		$(".table tr").removeClass("click");
		$(this).addClass("click");
		return false;
	})*/

	//显示文本框里的图片
	$(".showpic").click(function()
	{
		var s = $(this).prev().prev("input").val();
		if(s == "")
			s = "images/logo.gif";
		else
			s = "../" + s;
		window.open(s,"newWin","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,top=400,left=400,width=500,height=400");
		return false;
	})

	//添加按钮
	$("#ButtonManage,#ButtonConfig,#ButtonImport").hide();
	$("#ButtonManage,#ButtonConfig,#ButtonImport").after("<input type='button' id='ButtonManage1' value='"+ $("#ButtonManage,#ButtonConfig,#ButtonImport").val()  +"' class='button'>");

	//点击按钮后为不可用
	$("#ButtonManage1").click(function()
	{
		$(this).val("Loading...");
		$("#ButtonManage,#ButtonConfig,#ButtonImport").get(0).click();
		$(this).get(0).disabled = true;
	})

	//获取分辨率
	$("#resolution").text(window.screen.width + " x " + window.screen.height);

	//搜索数据的转向
	$(".search").click(function()
    {
        location.href = '?search=' + $("#searchtext").attr("name") + '&field=' + $("#searchtext").attr("title") + '&keyword=' + $("#searchtext").val();
    })

	//获取当前时间
	$(".datetime").click(function()
	{
		var d = new Date();
		$(this).prev().val(d.getFullYear() + "-" + (d.getMonth()+1) + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds());
		return false;
	})

	//删除数据的提示
	$("a[class=delete]").click(function()
    {
        return confirm($(this).attr("title"));
    })
	
	//删除数据的提示
	$("a[class=deleteall]").click(function()
    {
		
		var a = "";
		if($(".checkdelete[checked]").val() == null)
		{
			return false;
		}
		else
		{
			if(confirm($(this).attr("title")))
			{
				$(".checkdelete[checked]").each(function()
				{
					a += $(this).val() + ",";
				}); 
				location.href = "?action=deleteall&id="+ a.substring(0, a.lastIndexOf(","));
			}
		}
    })

	//删除全选
	$("input[class=checkall]").click(function()
	{
		 $(".checkdelete").attr("checked", $("input[class=checkall]").attr("checked"));
	});

	//恢复数据的提示
    $("a[name=undo]").click(function()
    {
        return confirm($(this).attr("title"));
    })
	
	//影藏字段说明
	$(".table td .note").hide();
	$(".table1 td .note").hide();

	//帮助字段提示
    $("a[class=help]").click(function()
    {
        $(this).parent().next().find(".note").slideToggle("fast");
		return false;
    })
	
	//帮助系统提示,全部显示帮助
    $("a[class=helpall]").click(function()
    {
        $(".table .note").slideToggle("fast");
        $(".table1 .note").slideToggle("fast");
		return false;
    })

	//上传按钮的打开小窗口
	$("a[class=upload]").click(function()
    {
		var height = 100;
		if($(this).attr("href").indexOf("action=original") > 0)
			height = 400;
        window.open($(this).attr("href"),"newWin","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,top=200,left=300,width=320,height=" + height);
        return false;
    })

	//连接内部系统
	$("a[class=link]").click(function()
    {
        window.open("system.aspx","newWin","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,top=400,left=400,width=200,height=250");
        return false;
    })

	//传入值的tag变化
	var tag = $().urlget("tag");
	if(tag != undefined)
	{
		$(".tag").removeClass("click");
		$(".tag").eq(eval(tag) - 1).addClass("hover");
		$(".table").hide();
		$(".table").eq(0).show();
		$(".table").eq(eval(tag)).show();
	}

	//Tag
	$(".tag").click(function()
	{
		$(".tag").removeClass("click");
		$(this).addClass("click");
		$(".table").hide();
		$(".table").eq(0).show();
		$(".table").eq($(".tag").index($(this))+1).show();
		return false;
	})

	//添加用户是否参与管理
	if($("#C_User").length != 0)
	{
		$("#manage_UserGroup").hide();
		$("#CB_IsAdmin").click(function()
		{
			$("#manage_UserGroup").slideToggle("fast");
		})
		
		if($("#CB_IsAdmin").attr("checked") && (action == "update" || action == "copy"))
		{
			$("#manage_UserGroup").show();
		}
	}


	//帮助系统页面显示
	$.each($("#help .note"), function(i)
	{
		if($(this).text() == "")
		{
			var style = "padding:10px; font-weight:bold; font-size:12px; border-bottom:5px solid #ccc; background:#0099FF; color:#fff;"
			$(this).prev().attr("style", style);
			$(this).attr("style", style);

			if($(this).parent().next().find(".note").text() == "")
			{
				$(this).parent().hide();
			}
		}
	})

	//添加数据时指定默认的参数
	var url = location.search;
	if(url.indexOf("controlid") != -1)
	{
		$("a[href=?action=insert],.show,.update,.copy").click(function()
		{
			$(this).attr("href", $(this).attr("href") + url.substring(url.lastIndexOf("controlid")-1, url.length));
		})
	}

	//指定隐藏字段
	if($().urlget("hide") != undefined)
	{
		var hide = $().urlget("hide").split(",");
		for(i=0; i< hide.length; i++)
		{
			$("#manage_" + hide[i]).hide();
		}
	}


	//下载文本框里的文件
	$(".showfile").click(function()
	{
		$(this).attr("href", "../" + $(this).prev().prev("input").val());
		return false;
	})

})

//==============================
//检测函数:检查输入字符串是否只由英文字母,数字,短线和下划线组成
//==============================
function isValidChar(Str) {
	var regu = "^[0-9a-zA-Z\_-]+$";
	var re = new RegExp(regu);
	if (re.test(Str)) return true;
	return false;
}
//==============================
//检测函数:检查输入字符串是否只由英文字母和数字组成
//==============================
function isOnlyNL(Str) {
	var regu = "^[0-9a-zA-Z]+$";
	var re = new RegExp(regu);
	if (re.test(Str)) return true;
	return false;
}
//==============================
//检查输入字符串是否只由中文组成
//==============================
function isChinese(Str) {
	if (Str.length == 0) { return false; }
	for (i = 0; i < Str.length; i++) {
		if (Str.charCodeAt(i) > 128) { return true; }
	}
	return false;
}
//==============================
//检测函数:字数限制,中文算两个字符
//==============================
function getLength(Str) {
	var len = 0;
	var i;
	for (i=0; i<Str.length; i++) {
		if (Str.charCodeAt(i) > 255) {
			len+=2;
		} else {
			len++;
		}
	}
	return len;
}

//==============================
//定位相关
//==============================
function getTotalHeight() {
	if ($.browser.msie) {
		return document.compatMode == "CSS1Compat" ? document.documentElement.clientHeight : document.body.clientHeight;
	} else {
		return self.innerHeight;
	}
}
function getTotalWidth() {
	if ($.browser.msie) {
		return document.compatMode == "CSS1Compat" ? document.documentElement.clientWidth : document.body.clientWidth;
	} else {
		return self.innerWidth;
	}
}
function getOffsetXY(e) {
	return { x : e.offsetLeft,y : e.offsetTop };
}
function getOffsetWH(e) {
	return { w : e.offsetWidth, h : e.offsetHeight };
}
function getClientXY(e) {
	e = e || event;
	return { cx : e.clientX, cy : e.clientY };
}

function checkValues(cf)
{
    var objs = document.getElementsByTagName("input"); 
    var nums = 0;
    for(var i=0; i<objs.length; i++)
    {
        if(objs[i].type=="checkbox" && objs[i].name !='ckb'){
            if(objs[i].checked)
            {
                nums++;
                break;
            }
         }   
    }
    if(nums==0)
    {
        alert('您还没选择 任何一项!');
        return false;
    }
    else
    {
        if(confirm(cf))
        return true;
        else return false;
    }
}

//jquery.bgiframe
//==============================
(function($){$.fn.bgIframe=$.fn.bgiframe=function(s){if($.browser.msie&&/6.0/.test(navigator.userAgent)){s=$.extend({top:'auto',left:'auto',width:'auto',height:'auto',opacity:true,src:'javascript:false;'},s||{});var prop=function(n){return n&&n.constructor==Number?n+'px':n;},html='<iframe class="bgiframe"frameborder="0"tabindex="-1"src="'+s.src+'"'+'style="display:block;position:absolute;z-index:-1;'+(s.opacity!==false?'filter:Alpha(Opacity=\'0\');':'')+'top:'+(s.top=='auto'?'expression(((parseInt(this.parentNode.currentStyle.borderTopWidth)||0)*-1)+\'px\')':prop(s.top))+';'+'left:'+(s.left=='auto'?'expression(((parseInt(this.parentNode.currentStyle.borderLeftWidth)||0)*-1)+\'px\')':prop(s.left))+';'+'width:'+(s.width=='auto'?'expression(this.parentNode.offsetWidth+\'px\')':prop(s.width))+';'+'height:'+(s.height=='auto'?'expression(this.parentNode.offsetHeight+\'px\')':prop(s.height))+';'+'"/>';return this.each(function(){if($('> iframe.bgiframe',this).length==0)this.insertBefore(document.createElement(html),this.firstChild);});}return this;};})(jQuery);

// 桌面部分
function showInterface() {
	var window_top	= 15;
	var window_left	= 145;
	var space_w		= 150;
	var space_h		= 55;
//	if ($("#interface").css("display") == "none") {
		$("#interface").css({width:getTotalWidth() - space_w + "px", height:getTotalHeight() - space_h + "px", top:window_top + "px", left:window_left + "px"});
		$("#interface_body").css({height:getTotalHeight() - space_h - parseInt($(".interface_head_center_td").css("height")) - parseInt($(".interface_foot_center_td").css("height")) + "px"});
		$("#interface").show();
		$("#interface_size").html('<img src="./style/images/ico_size1.gif" border="0" alt="最大化窗口" title="最大化窗口" align="absmiddle" onclick="maxInterface();" />');
//	}
	hideMenu();
}

function closeInterface() {
	$("#interface").hide();
	//$("#interfacewindow").attr("src","UUMLM_welcome.asp");
}
function showMenu() {
	$("#menubox").slideToggle("fast");
}
function hideMenu() {
	$("#back_manage_submenu").hide();
	$("#menubox").hide();
}
function menuHide(){
window.parent.document.getElementById("back_manage_submenu").style.display="none";
window.parent.document.getElementById("menubox").style.display="none";
}
function maxInterface() {
	var window_top	= 15;
	var window_left	= 10;
	var space_w		= 20;
	var space_h		= 55;
//	if ($("#interface").css("display") != "none") {
		$("#interface").css({width:getTotalWidth() - space_w + "px", height:getTotalHeight() - space_h + "px", top:window_top + "px", left:window_left + "px"});
		$("#interface_body").css({height:getTotalHeight() - space_h - parseInt($(".interface_head_center_td").css("height")) - parseInt($(".interface_foot_center_td").css("height")) + "px"});
		$("#interface").show();
		$("#interface_size").html("还原");
		$("#interface_size").html('<img src="./style/images/ico_size2.gif" border="0" alt="还原窗口" title="还原窗口" align="absmiddle" onclick="showInterface();" />');
//	}
	hideMenu();
}
// 获取当前日期 + 时间
function writeCurrentDate() {
	var today = new Date();
	var day;
	if(today.getDay()==0) day = "星期日";
	if(today.getDay()==1) day = "星期一";
	if(today.getDay()==2) day = "星期二";
	if(today.getDay()==3) day = "星期三";
	if(today.getDay()==4) day = "星期四";
	if(today.getDay()==5) day = "星期五";
	if(today.getDay()==6) day = "星期六";
	var theDate = (today.getFullYear()) + "年" + (today.getMonth() + 1 ) + "月" + today.getDate() + "日 " + day + " "+ today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
	$("#timebox").html(theDate);
}
// 列表的鼠标经过事件
function listItemEvent() {
	$("tr[id*=listitem_]").hover( function(){ if ($(this).attr("class") != "list_selected") { $(this).attr("class","list_over") } },function(){ if ($(this).attr("class") != "list_selected") { $(this).attr("class","list_out") } })
	$("input[name='SelectMark']").click(function(){
		var tempid = $(this).attr('id').replace("SelectMark_","");
		if ($(this).attr('checked') == true) {
			$("#listitem_"+tempid).attr('class', 'list_selected');
		} else {
			$("#listitem_"+tempid).attr('class', 'list_out');
		}
	})
	$("#selectEach").click(function() { $("input[name='SelectMark']").attr('checked', true); $("tr[id*=listitem_]").attr('class', 'list_selected') });
	$("#selectNone").click(function() { $("input[name='SelectMark']").attr('checked', false); $("tr[id*=listitem_]").attr('class', 'list_out') });
}
function listItemEvent__(part) {
	if (part == "photo") {
		$("input[name='SelectMark']").click(function(){
			var tempid = $(this).attr('id').replace("SelectMark_","");
			if ($(this).attr('checked') == true) {
				$("#listitem_"+tempid).attr('style','filter: gray');
			} else {
				$("#listitem_"+tempid).removeAttr("style");
			}
		})
		$("#selectEach").click(function() { $("input[name='SelectMark']").attr('checked', true); $("[id*=listitem_]").attr('style','filter: gray') });
		$("#selectNone").click(function() { $("input[name='SelectMark']").attr('checked', false); $("[id*=listitem_]").removeAttr("style") });
	} else {
		$("[id*=listitem_]").hover( function(){ if ($(this).attr("class") != "list_selected") { $(this).attr("class","list_over") } },function(){ if ($(this).attr("class") != "list_selected") { $(this).attr("class","list_out") } })
		$("input[name='SelectMark']").click(function(){
			var tempid = $(this).attr('id').replace("SelectMark_","");
			if ($(this).attr('checked') == true) {
				$("#listitem_"+tempid).attr('class', 'list_selected');
			} else {
				$("#listitem_"+tempid).attr('class', 'list_out');
			}
		})
		$("#selectEach").click(function() { $("input[name='SelectMark']").attr('checked', true); $("[id*=listitem_]").attr('class', 'list_selected') });
		$("#selectNone").click(function() { $("input[name='SelectMark']").attr('checked', false); $("[id*=listitem_]").attr('class', 'list_out') });
	}
}

