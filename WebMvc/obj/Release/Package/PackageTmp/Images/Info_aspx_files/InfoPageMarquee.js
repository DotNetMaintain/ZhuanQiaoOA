var marqueecontent = new Array();
marqueecontent[0] = '<span><a href=http://www.job18.net target=_blank>官方唯一网站</a></span>'; marqueecontent[1] = '<span><a href=http://demo.job18.net target=_blank> 懒人工作通协同管理软件演示站全面开放</a></span>'; marqueecontent[2] = '<span><a href=http://bbs.job18.net target=_blank>懒人工作通协同管理软件开放论坛交流</a></span>'; marqueecontent[3] = '<span><a href=http://www.job18.net target=_blank>job18_oa v5.0.0标准版发布</a></span>'; 
var marqueeInterval = new Array(); var marqueeId = 0; var marqueeDelay = 2000; var marqueeHeight = 17;
function initMarquee() {var str = marqueecontent[0];
document.write('<div id="marqueeBox" style="float:left;margin: 0px; font-weight:bold; line-height: 140%; text-align:center;overflow:hidden;width:98%;height:' + marqueeHeight + 'px" onmouseover="clearInterval(marqueeInterval[0])" onmouseout="marqueeInterval[0]=setInterval(\'startMarquee()\',marqueeDelay)"><div>' + str + '</div></div>'); marqueeId++;
marqueeInterval[0] = setInterval("startMarquee()", marqueeDelay);}
function startMarquee() {
var str = marqueecontent[marqueeId];marqueeId++;
if (marqueeId >= marqueecontent.length) marqueeId = 0;
if (document.getElementById("marqueeBox").childNodes.length == 1) {
var nextLine = document.createElement('DIV');nextLine.innerHTML = str;
document.getElementById("marqueeBox").appendChild(nextLine);} else {
document.getElementById("marqueeBox").childNodes[0].innerHTML = str;
document.getElementById("marqueeBox").appendChild(document.getElementById("marqueeBox").childNodes[0]);
document.getElementById("marqueeBox").scrollTop = 0;}
clearInterval(marqueeInterval[1]); marqueeInterval[1] = setInterval("scrollMarquee()", 20);}
function scrollMarquee() {document.getElementById("marqueeBox").scrollTop++;
if (document.getElementById("marqueeBox").scrollTop % marqueeHeight == (marqueeHeight - 1)) { clearInterval(marqueeInterval[1]);}} initMarquee(); 