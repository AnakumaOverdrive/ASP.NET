// JScript 文件

//由 温伟鹏 添加于 2008-11-19

//通过id获得元素
function $id(id)
{
    return window.document.getElementById(id);
}
//通过TagName获得元素数组
function $n(name)
{
    return window.document.getElementByTagName(name);
}

//---以下为字符串检测函数---

//检测是否是数字
function isDigit(s) 
{
    var patrn=/^[0-9]{1,20}$/; 
    return patrn.test(s);
}
//检测字符串是否为数字。包括整数、小数
function isNumeric(n)
{
    if(isNullOrEmpty(n))
        return true;
    if(isNaN(n))
        return false;
        
    return true;
}
//检测字符串是否是电话格式 +86-22-88888888
function isTel(s) 
{ 
    //var patrn=/^[+]{0,1}(\d){1,3}[ ]?([-]?(\d){1,12})+$/; 
    var patrn=/^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/; 
    if (!patrn.test(s)) 
        return false 
    return true 
}
//检测是否是日期格式 yyyy-MM-dd
function isDate(s)
{
    var pattern = /^[0-9]{2,4}-([1-9]|0[1-9]|1[0-2])-([1-9]|0[1-9]|[1-3][0-9])$/;
    if(!pattern.test(s))
        return false;
    return true;
}
//比较两个日期，如果D1大于D2，则返回1；等于D2，返回0；小于D2，返回-1;D1,D2都是日期格式的字符串
function DateCompare(d1,d2)
{
    d1 = d1.replace("-","/");
    d2 = d2.replace("-","/");
    //晕死，调试JavaScript太烦人了！
//    var date1 = new Date(d1);
//    var date2 = new Date(d2);
//    
//    alert("Year:" + date1.getFullYear() + ";Month:" + date1.getMonth() + ";Date:" + date1.getDate());
//    alert("Year:" + date2.getFullYear() + ";Month:" + date2.getMonth() + ";Date:" + date2.getDate());
//    
//    if(date1.getFullYear() == date2.getFullYear() 
//    && date1.getMonth() == date2.getMonth()
//    && date2.getDate() == date2.getDate())
//    {
//        return 0;
//    }
//    
//    if((date1.getFullYear() > date2.getFullYear())
//    || (date1.getFullYear()==date2.getFullYear() && date1.getMonth()>date2.getMonth())
//    || (date2.getFullYear()==date2.getFullYear() && date1.getMonth()==date2.getMonth() && date1.getDate()>date2.getDate()))
//    {
//        return 1;
//    }
//    
//    if((date1.getFullYear() < date2.getFullYear())
//    || (date1.getFullYear() == date2.getFullYear() && date1.getMonth()<date2.getMonth())
//    || (date1.getFullYear() == date2.getFullYear() && date1.getMonth()==date2.getMonth() && date1.getDate()<date2.getDate()))
//    {
//        return -1;
//    }
    var result = DateMinus(d1,d2);
    
    if(result>0)
    {
        return 1;
    }
    if(result == 0)
    {
        return 0;
    }
    if(result < 0)
    {
        return -1;
    }
}
//将两个日期格式的字符串进行相减，得到天数
function DateMinus(d1,d2)
{
    d1 = d1.replace("-","/");
    d2 = d2.replace("-","/");
    var date1 = new Date(d1);
    var date2 = new Date(d2);
    var days = (date1.getTime()-date2.getTime())/86400000;
    
//    alert(days);
    
    return days;
}
//获得两个日期相减所得的小时数
function GetDateMinusHours(d1,d2)
{
    var days = DateMinus(d1,d2);
    
    return days/24;
}
//获得两个日期相减所得的分钟数
function GetDateMinusMinutes(d1,d2)
{
    var hours = GetDateMinusHours(d1,d2);
    
    return hours/60;
}
//是否为空
function isNullOrEmpty( str )
{
    if ( str == "" || str==undefined || typeof(str) == "undefined") 
        return true;
    var regu = "^[ ]+$";
    var re = new RegExp(regu);
    return re.test(str);
}
//将字符串转换为数字
function StrToNumber(s)
{
    if(isDigit(s))
    {
        return Number(s);
    }
    else
    {
        return 0;
    }
}
//去掉给定字符串的前后空白
function trim(text)
{
    return (text || "").replace( /^\s+|\s+$/g, "" );
}
//去掉全部空格
function Trimlr(str) {
    return str.replace(/\s/g, "");

}
/**
* 检查输入的字符是否具有特殊字符
* 输入:str  字符串
* 返回:true 或 flase; true表示包含特殊字符
* 主要用于注册信息的时候验证
*/
function checkQuote(str) {
    var items = new Array("~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "{", "}", "[", "]", "(", ")");
    items.push(":", ";", "'", "|", "\\", "<", ">", "?", "/", "<<", ">>", "||", "//","+","-");
    items.push("admin", "administrators", "administrator", "管理员", "系统管理员");
    items.push("select", "delete", "update", "insert", "create", "drop", "alter", "trancate");
    str = str.toLowerCase();
    for (var i = 0; i < items.length; i++) {
        if (str.indexOf(items[i]) >= 0) {
            return true;
        }
    }
    return false;
}
