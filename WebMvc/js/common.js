//jquery ��ȡurl�������
eval(function(p,a,c,k,e,d){e=function(c){return c.toString(36)};if(!''.replace(/^/,String)){while(c--){d[c.toString(a)]=k[c]||c.toString(a)}k=[function(e){return d[e]}];e=function(){return'\\w+'};c=1};while(c--){if(k[c]){p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c])}}return p}('c.f.i=d(o){2 6=j.h.g();2 5;3(6&&6.9("?")){2 b=6.a("?");2 4=b[1];3(4&&4.9("&")){2 e=4.a("&");c.p(e,d(l,7){3(7&&7.9("=")){2 8=7.a("=");3(o){3(m(o)=="n"&&o==8[0]){5=8[1]==r?\'\':8[1]}}q{5=4}}})}}k 5}',28,28,'||var|if|parms|tmp|url|val|parmarr|indexOf|split|arr|jQuery|function|parmList|fn|toString|location|urlget|window|return|key|typeof|string||each|else|null'.split('|'),0,{}))

function closebox() {
    window.parent.document.body.removeChild(window.parent.document.getElementById("dialogCase"));
}

$(function()
{
	//��ȡurl��������
	var action = $().urlget("action");

	//��껬������Ч��
	$(".table tr").mouseover(function()
	{
		$(this).addClass("hover");
		return false;
	})
	
	//����뿪����Ч��
	$(".table tr").mouseout(function()
	{
		$(this).removeClass("hover");
		return false;
	})
	
	//���������Ч��
	/*
	$(".table tr").mousedown(function()
	{
		$(".table tr").removeClass("click");
		$(this).addClass("click");
		return false;
	})*/

	//��ʾ�ı������ͼƬ
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

	//��Ӱ�ť
	$("#ButtonManage,#ButtonConfig,#ButtonImport").hide();
	$("#ButtonManage,#ButtonConfig,#ButtonImport").after("<input type='button' id='ButtonManage1' value='"+ $("#ButtonManage,#ButtonConfig,#ButtonImport").val()  +"' class='button'>");

	//�����ť��Ϊ������
	$("#ButtonManage1").click(function()
	{
		$(this).val("Loading...");
		$("#ButtonManage,#ButtonConfig,#ButtonImport").get(0).click();
		$(this).get(0).disabled = true;
	})

	//��ȡ�ֱ���
	$("#resolution").text(window.screen.width + " x " + window.screen.height);

	//�������ݵ�ת��
	$(".search").click(function()
    {
        location.href = '?search=' + $("#searchtext").attr("name") + '&field=' + $("#searchtext").attr("title") + '&keyword=' + $("#searchtext").val();
    })

	//��ȡ��ǰʱ��
	$(".datetime").click(function()
	{
		var d = new Date();
		$(this).prev().val(d.getFullYear() + "-" + (d.getMonth()+1) + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds());
		return false;
	})

	//ɾ�����ݵ���ʾ
	$("a[class=delete]").click(function()
    {
        return confirm($(this).attr("title"));
    })
	
	//ɾ�����ݵ���ʾ
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

	//ɾ��ȫѡ
	$("input[class=checkall]").click(function()
	{
		 $(".checkdelete").attr("checked", $("input[class=checkall]").attr("checked"));
	});

	//�ָ����ݵ���ʾ
    $("a[name=undo]").click(function()
    {
        return confirm($(this).attr("title"));
    })
	
	//Ӱ���ֶ�˵��
	$(".table td .note").hide();
	$(".table1 td .note").hide();

	//�����ֶ���ʾ
    $("a[class=help]").click(function()
    {
        $(this).parent().next().find(".note").slideToggle("fast");
		return false;
    })
	
	//����ϵͳ��ʾ,ȫ����ʾ����
    $("a[class=helpall]").click(function()
    {
        $(".table .note").slideToggle("fast");
        $(".table1 .note").slideToggle("fast");
		return false;
    })

	//�ϴ���ť�Ĵ�С����
	$("a[class=upload]").click(function()
    {
		var height = 100;
		if($(this).attr("href").indexOf("action=original") > 0)
			height = 400;
        window.open($(this).attr("href"),"newWin","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,top=200,left=300,width=320,height=" + height);
        return false;
    })

	//�����ڲ�ϵͳ
	$("a[class=link]").click(function()
    {
        window.open("system.aspx","newWin","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,top=400,left=400,width=200,height=250");
        return false;
    })

	//����ֵ��tag�仯
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

	//����û��Ƿ�������
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


	//����ϵͳҳ����ʾ
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

	//�������ʱָ��Ĭ�ϵĲ���
	var url = location.search;
	if(url.indexOf("controlid") != -1)
	{
		$("a[href=?action=insert],.show,.update,.copy").click(function()
		{
			$(this).attr("href", $(this).attr("href") + url.substring(url.lastIndexOf("controlid")-1, url.length));
		})
	}

	//ָ�������ֶ�
	if($().urlget("hide") != undefined)
	{
		var hide = $().urlget("hide").split(",");
		for(i=0; i< hide.length; i++)
		{
			$("#manage_" + hide[i]).hide();
		}
	}


	//�����ı�������ļ�
	$(".showfile").click(function()
	{
		$(this).attr("href", "../" + $(this).prev().prev("input").val());
		return false;
	})

})

//==============================
//��⺯��:��������ַ����Ƿ�ֻ��Ӣ����ĸ,����,���ߺ��»������
//==============================
function isValidChar(Str) {
	var regu = "^[0-9a-zA-Z\_-]+$";
	var re = new RegExp(regu);
	if (re.test(Str)) return true;
	return false;
}
//==============================
//��⺯��:��������ַ����Ƿ�ֻ��Ӣ����ĸ���������
//==============================
function isOnlyNL(Str) {
	var regu = "^[0-9a-zA-Z]+$";
	var re = new RegExp(regu);
	if (re.test(Str)) return true;
	return false;
}
//==============================
//��������ַ����Ƿ�ֻ���������
//==============================
function isChinese(Str) {
	if (Str.length == 0) { return false; }
	for (i = 0; i < Str.length; i++) {
		if (Str.charCodeAt(i) > 128) { return true; }
	}
	return false;
}
//==============================
//��⺯��:��������,�����������ַ�
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
//��λ���
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
        alert('����ûѡ�� �κ�һ��!');
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

// ���沿��
function showInterface() {
	var window_top	= 15;
	var window_left	= 145;
	var space_w		= 150;
	var space_h		= 55;
//	if ($("#interface").css("display") == "none") {
		$("#interface").css({width:getTotalWidth() - space_w + "px", height:getTotalHeight() - space_h + "px", top:window_top + "px", left:window_left + "px"});
		$("#interface_body").css({height:getTotalHeight() - space_h - parseInt($(".interface_head_center_td").css("height")) - parseInt($(".interface_foot_center_td").css("height")) + "px"});
		$("#interface").show();
		$("#interface_size").html('<img src="./style/images/ico_size1.gif" border="0" alt="��󻯴���" title="��󻯴���" align="absmiddle" onclick="maxInterface();" />');
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
		$("#interface_size").html("��ԭ");
		$("#interface_size").html('<img src="./style/images/ico_size2.gif" border="0" alt="��ԭ����" title="��ԭ����" align="absmiddle" onclick="showInterface();" />');
//	}
	hideMenu();
}
// ��ȡ��ǰ���� + ʱ��
function writeCurrentDate() {
	var today = new Date();
	var day;
	if(today.getDay()==0) day = "������";
	if(today.getDay()==1) day = "����һ";
	if(today.getDay()==2) day = "���ڶ�";
	if(today.getDay()==3) day = "������";
	if(today.getDay()==4) day = "������";
	if(today.getDay()==5) day = "������";
	if(today.getDay()==6) day = "������";
	var theDate = (today.getFullYear()) + "��" + (today.getMonth() + 1 ) + "��" + today.getDate() + "�� " + day + " "+ today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
	$("#timebox").html(theDate);
}
// �б����꾭���¼�
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

