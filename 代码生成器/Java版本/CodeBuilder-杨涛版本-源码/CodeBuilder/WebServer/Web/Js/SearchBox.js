<!--
var $ = document.getElementById;
document.write("<div id='SearchBoxLayer'  style='font-size:12px;border:solid 1px #a2c3db;position: absolute;verticalAlign:top;z-index: 9999;height:200px; display: none;'>");
document.write("<iframe name='SearchBoxIframe' scrolling='no' frameborder='0' width='100%' height='100%'></iframe></div>");

function TSearchBox() //初始化查询框配置
{
    this.Items =null;  //定义对象列表
    this.posturl = null;
    this.value_obj = null;
    this.eventSrc   = null;                     //日历显示的触发控件    this.list_parent = null;
    

    this.iframe     = window.frames("SearchBoxIframe"); //日历的 iframe 载体
    this.searchboxlayer   = document.getElementById("SearchBoxLayer");  //日历的层
    

     var strIframe = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=gb2312'></head><body onselectstart='return false' style='margin: 0px' oncontextmenu='return false'><TABLE id='listItem'></TABLE></body></html>";
 
     this.iframe.document.writeln(strIframe);this.iframe.document.close();
     this.list_parent = this.iframe.eval("listItem");
     
  
}

var SearchBox = new TSearchBox();

function searchbox(url,valueCtrl) //主调函数
{
    SearchBox.Items = new Array(); 
    SearchBox.posturl =url;
    SearchBox.eventSrc = event.srcElement;  
    startRequest();
    if(valueCtrl != ""&&valueCtrl!="undefine")
       SearchBox.value_obj = valueCtrl;
    
}

function hiddenSearchBox(){SearchBox.searchboxlayer.style.display="none";}

var events; 
this.oldEventHandler ;
if(document.onclick)
{
    events =  'this.oldEventHandler ='+ document.onclick.toString();
    
}
document.onclick   = function()
{  
     if(SearchBox.eventSrc != window.event.srcElement) hiddenSearchBox();
     if (events!=undefined) { eval(events); this.oldEventHandler();}
}
 



function createXMLHttpRequest() 
{
    if (window.ActiveXObject)
    {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    } 
    else if (window.XMLHttpRequest) 
    {
        xmlHttp = new XMLHttpRequest();
    }
}

function startRequest() 
{
    currentObj = event.srcElement;
    createXMLHttpRequest();
    try
    {
         xmlHttp.onreadystatechange = handleStateChange;
         xmlHttp.open("GET", encodeURI(SearchBox.posturl + event.srcElement.value.toUpperCase()), true);
         xmlHttp.send(null);
    }
    catch (exception) 
    {
        alert("您要访问的资源不存在!");
    }
}

function handleStateChange() 
{
    if (xmlHttp.readyState == 4)
    {
        if (xmlHttp.status == 200 || xmlHttp.status == 0) 
        {
            var resp = xmlHttp.responseText;
            if (resp == "")
                hiddenSearchBox();
            else 
            { 
                SearchBox.Items = JSON.parse(resp);
                if (SearchBox.Items.length >0)
                   showDiv();
            }
        }
    }
}


function showDiv() 
{  
    var e = SearchBox.eventSrc; 
    SearchBox.searchboxlayer.style.display="";
    SearchBox.searchboxlayer.style.width = e.offsetWidth+"px"; 
    SearchBox.searchboxlayer.style.maxHeight=SearchBox.Items.length*16+"px";
//   e.onblur=function(){hiddenSearchBox();}
  
    var o = SearchBox.searchboxlayer.style;
    var t = e.offsetTop,  h = e.clientHeight, l = e.offsetLeft, p = e.type;
	while (e = e.offsetParent){t += e.offsetTop; l += e.offsetLeft;}
    var cw = SearchBox.searchboxlayer.clientWidth, ch = SearchBox.searchboxlayer.clientHeight;
    var dw = document.body.clientWidth, dl = document.body.scrollLeft, dt = document.body.scrollTop;
    if (document.body.clientHeight + dt - t - h >= ch) o.top = (p=="image")? t + h : t + h + 3;
    else o.top  = (t - dt < ch) ? ((p=="image")? t + h : t + h + 3) : t - ch;
    if (dw + dl - l >= cw) o.left = l+1; else o.left = (dw >= cw) ? dw - cw + dl+1 : dl+1; 
    //if(SearchBox.list_parent.children.length > 0 ){
    SearchBox.list_parent.children[0].removeNode(true);
    //}
 
    // ul_list = document.createElement("TBODY");
     //ul_list.id = "ul_list";
     SearchBox.list_parent.style.width = "100%";
     SearchBox.list_parent.style.padding="0px";
     SearchBox.list_parent.style.margin="0px";
     SearchBox.list_parent.style.listStyleType="none";
     SearchBox.list_parent.style.verticalAlign="top";

    li_Items = new Array();tr_Items = new Array();
    for (i = 0; i < SearchBox.Items.length; i++) {
       tr_Items[i] = SearchBox.list_parent.insertRow(i);
       li_Items[i] = tr_Items[i].insertCell(0);
       // tr_Items[i]  = document.createElement("TR");
       //li_Items[i] = document.createElement("TD");
        li_Items[i].innerHTML = " " + SearchBox.Items[i].Text;
        li_Items[i].title = SearchBox.Items[i].Text;
        li_Items[i].setAttribute("Tvalue", SearchBox.Items[i]);
        li_Items[i].style.height = "20px";
        li_Items[i].style.lineHeight = "20px";
        li_Items[i].style.cursor = "hand";
        li_Items[i].style.fontSize ="12px";
        li_Items[i].style.width = SearchBox.searchboxlayer.offsetWidth +"px";
        li_Items[i].style.overflow ="hidden";
        li_Items[i].onclick = function() {
                                              SearchBox.eventSrc.innerText =this.innerText;// event.srcElement.innerHTML;
                                              //SearchBox.eventSrc.setAttribute("tvalue",this.Tvalue);
                                              if (SearchBox.value_obj!=null&&SearchBox.value_obj!=""&&SearchBox.value_obj!="undefine")
                                               SearchBox.value_obj(this.Tvalue);
                                              hiddenSearchBox();
                                         };
                                         
        li_Items[i].onmouseover = function () {this.style.backgroundColor ="#a2c3db"; 
        };
        li_Items[i].onmouseout = function () {this.style.backgroundColor ="white";
        };
      
    } 
   
}

//-->