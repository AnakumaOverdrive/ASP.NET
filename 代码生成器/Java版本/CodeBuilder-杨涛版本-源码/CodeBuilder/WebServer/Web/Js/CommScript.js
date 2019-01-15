
function autoResize(frm) {
    if (document.getElementById(frm)==undefined)
        return;
   // alert(window.screenTop);
    
    var f = document.getElementById(frm);  
    f.height = window.screen.availHeight - window.screenTop - f.offsetTop - document.body.clientTop - 25;
 
}