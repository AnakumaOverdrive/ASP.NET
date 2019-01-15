function ShowNo() {
    document.getElementById("doing").style.display = "none";
    document.getElementById("divLogin").style.display = "none";
}
function $(id) {
    return (document.getElementById) ? document.getElementById(id) : document.all[id];
}
function showFloat()                    //根据屏幕的大小显示两个层 
{
    var range = getRange();
    $('doing').style.width = range.width + "px";
    $('doing').style.height = 600 + "px";
    $('doing').style.display = "block";
    document.getElementById("divLogin").style.display = "";
}
function getRange()                      //得到屏幕的大小 
{
    var top = document.body.scrollTop;
    var left = document.body.scrollLeft;
    var height = document.body.clientHeight;
    var width = document.body.clientWidth;

    if (top == 0 && left == 0 && height == 0 && width == 0) {
        top = document.documentElement.scrollTop;
        left = document.documentElement.scrollLeft;
        height = document.documentElement.clientHeight;
        width = document.documentElement.clientWidth;
    }
    return { top: top, left: left, height: height, width: width };
} 