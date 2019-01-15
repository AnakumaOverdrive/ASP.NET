    function openwindow(url)
    {
        window.open(url,'','left='+(screen.width/2-800/2)+'px,top='+(screen.height/2-600/2)+'px,height=600,width=800,toolbar=no, location=no, status=no, menubar=no, scrollbars=yes, resizable=no');
    }
    //打开服务台

     function openwindowFW(url)
    {
        window.open(url,'','left='+(screen.width/2-800/2)+'px,top='+(screen.height/2-660/2)+'px,height=660,width=800,toolbar=no, location=no, status=no, menubar=no, scrollbars=yes, resizable=no');
    }
//获得URL参数
function getQueryString(queryStringName)
{
     var returnValue="";
     var URLString=new String(document.location);
     var serachLocation=-1;
     var queryStringLength=queryStringName.length;
     do
     {
        serachLocation=URLString.indexOf(queryStringName+"\=");
        if (serachLocation!=-1)
        {
            if ((URLString.charAt(serachLocation-1)=='?') || (URLString.charAt(serachLocation-1)=='&'))
            {
                URLString=URLString.substr(serachLocation);
                break;
            }
            URLString=URLString.substr(serachLocation+queryStringLength+1);
        }
     }
     while (serachLocation!=-1)
     if (serachLocation!=-1)
     {
        var seperatorLocation=URLString.indexOf("&");
        if (seperatorLocation==-1)
        {
            returnValue=URLString.substr(queryStringLength+1);
        }
        else
        {
            returnValue=URLString.substring(queryStringLength+1,seperatorLocation);
        } 
     }
     return returnValue;
}
//检查邮件

function checkEmail(value)
{
    var pattern = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
//检查URL
function checkHttp(value)
{
  /*
   //修改人:XHF  将输入转换成小写
    var valueconvert=value.toLowerCase();
    var pattern = /(http|ftp|https):\/\/[\w]+(.[\w]+)([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])/;
    if(valueconvert.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
    */
    return true;
}
//检查电话号码

function checkTel(value)
{
  /*
    var pattern = /(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
    */
    return true;
}
//
function CheckMobileTel(value)
{
  /*
    var pattern = /^0{0,1}13[0-9]{9}$/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
    */
    return true;
}
//检查传真

function CheckFax(value)
{
    var pattern =/^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    } 
}
//检查邮政编码

function CheckPostCode(value)
{
    var pattern = /[1-9]\d{5}(?!\d)/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    } 
}
function CheckDegree(value)
{
    var pattern = /[1-9]{1}$/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
         if(parseInt(value)>10 || parseInt(value)<1)
         {
           return false;
         }
         else
        {
           return true;
        }
    } 
}
//字符串长度

function strlen(str)
{
    var len;
    var i;
    len = 0;
    for (i=0;i<str.length;i++)
    {
    if (str.charCodeAt(i)>255) len+=2; else len++;
    }
    return len;
}
//检查浮点数
function checkDecimal(value)
{
    var pattern = /^\d*\.?\d{0,2}$/;
    //var pattern=/^((-\d+(\.\d+)?)|(0+(\.0+)?))$/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
function checkDecimal2(value)
{
    var pattern=/^((-\d+(\.\d+)?)|(0+(\.0+)?))$/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
function checkDecimal3(value)
{
   var pattern=/^(([-]{0,1}\d+(\.\d+)?)|(0+(\.0+)?))$/;
    if(value.match(pattern)==null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
