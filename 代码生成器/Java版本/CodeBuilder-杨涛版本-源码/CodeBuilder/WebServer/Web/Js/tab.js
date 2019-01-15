/**********************
标签显示控制
***********************/
var stabid = 0;
function tabit(btn) {
    var idname = new String(btn.id);
    var s = idname.indexOf("_");
    var e = idname.lastIndexOf("_") + 1;
    var tabName = idname.substr(0, s);
    var id = parseInt(idname.substr(e, 1));
    var tabNumber = btn.parentNode.childNodes.length-1;
    for (i = 0; i < tabNumber; i++) {
        document.getElementById(tabName + "_div_" + i).style.display = "none";
        document.getElementById(tabName + "_btn_" + i).className = "tab_" + i;

    };

    document.getElementById(tabName + "_div_" + id).style.display = "block";
    btn.className = "tab_select" + btn.id;

};
var fodTime;
function delaytabit(btn) {
    clearTimeout(fodTime);
    fodTime = setTimeout(function() { tabit(btn) }, 100);
}