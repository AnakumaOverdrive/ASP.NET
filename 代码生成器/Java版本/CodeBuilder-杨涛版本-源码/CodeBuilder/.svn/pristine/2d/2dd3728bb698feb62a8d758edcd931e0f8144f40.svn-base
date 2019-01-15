
function getHeight() {
    var scrollHeight,
            offsetHeight;
 
    if ($.browser.msie && $.browser.version < 7) {
        scrollHeight = Math.max(
                document.documentElement.scrollHeight,
                document.body.scrollHeight
            );  
        offsetHeight = Math.max(
                document.documentElement.offsetHeight,
                document.body.offsetHeight
            );

        if (scrollHeight < offsetHeight) {
            return $(window).height() + 'px';
        } else {
            return scrollHeight + 'px';
        }
        // handle "good" browsers 
    } else { 
        return $(document).height() + 'px';
    }
}


window.onresize = function() {
    var dv = document.getElementById('popupWin');

    //判断弹出层是否显示
    if (dv.style.display != 'none') {
        //弹出层已经打开

        //重现得到屏幕大小
        var range = getRange();

        //设置层高宽
        dv.style.top = 0;
        dv.style.left = 0;
        dv.style.width = range.width+'px'; 
        dv.style.height = getHeight();
        dv.style.display = '';
    }
}

document.write("<div id='popupWin' style='position: absolute; z-index: 9999; display: none'><iframe name='fm_popup' id='fm_popupWin' scrolling=auto frameborder=0 width=100% height=100%></iframe></div>");

function getRange()                      //得到屏幕的大小
{
    var top = document.body.scrollTop;
    var left = document.body.scrollLeft;
    var height = document.body.scrollHeight;
    var width = document.body.scrollWidth;

    if (top == 0 && left == 0 && height == 0 && width == 0) {
        top = document.documentElement.scrollTop;
        left = document.documentElement.scrollLeft;
        height = document.documentElement.clientHeight;
        width = document.documentElement.clientWidth;
    }
    return { top: top, left: left, height: height, width: width };
}
function openwin(url) { 
    var range = getRange();
    var dv = document.getElementById('popupWin'); 
    dv.style.display = '';
    dv.style.top = 0;
    dv.style.left = 0;
    dv.style.width = range.width+'px'; 
    dv.style.height = getHeight();
  
    var fm = document.getElementById('fm_popupWin');
    fm.src = url;
    return false;
}


function closewin() {
    var fm = document.getElementById('fm_popupWin');
    fm.src = "";
    var dv = document.getElementById('popupWin');
    dv.style.display = 'none';
}
 