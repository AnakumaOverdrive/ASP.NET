function CheckControl(obj) {
    if (document.getElementById(obj) == null)
    {
        alert('对象' + obj + ' 不存在，请检查代码是否正确！');
        return ;
    }
}

function ReturnFalse(obj) {
    document.getElementById(obj).style.backgroundColor = "#FFFFFF";
    document.getElementById(obj).title = "";
    return false;
}


function ReturnTrue(obj, str) {
    document.getElementById(obj).style.backgroundColor = "#FFEEEE";
    document.getElementById(obj).title = str;
    return true;
}

function  ValidateExp(exp,obj,str) {
    if (document.getElementById(obj) == null) {
        alert('对象' + obj + ' 不存在，请检查代码是否正确！');
        return true;
    }
    var obj_value = document.getElementById(obj).value;
    if (obj_value == "")
        return false;
    
    if (!exp.test(obj_value)) 
        return  ReturnTrue(obj,str);
    else 
        return ReturnFalse(obj);
}

/**************************************

    验证方法

***************************************/

//非空验证
function Require(obj) {
   
    if (document.getElementById(obj) == null) {
        alert('对象' + obj + ' 不存在，请检查代码是否正确！');
        return false;
    }
    var obj_value = document.getElementById(obj).value;
    
    if (obj_value=="")
        return ReturnTrue(obj, '该项不能为空！');  
    else
       return ReturnFalse(obj);
}

function MaxLen(obj,len) {
    if (document.getElementById(obj) == null) {
        alert('对象' + obj + ' 不存在，请检查代码是否正确！');
        return false;
    }
    var obj_value = document.getElementById(obj).value;
    if (obj_value.length > len)
        return ReturnTrue(obj, '该项长度不能大于' + len + '！');
    else
        return ReturnFalse(obj);
}


//营业执照号码验证
function Enterprise_Code(obj){
    return ValidateExp(/^[A-Za-z0-9]{8}-[A-Za-z0-9]{1}$/, obj, '请输入正确的营业执照号码');
}
//Email验证
function Email(obj) {
    return ValidateExp(/^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/, obj,'请输入正确的Email');
}

//邮政编码验证
function Zip(obj) {
    return ValidateExp(/^[1-9]\d{5}$/, obj,'请输入正确的邮政编码');
}

//数值类型验证
function IsNumber(obj) {
    //return ValidateExp(/^\d*(.\d*)$/, obj, '请输入正确的数值');
    //return ValidateExp(/^-?\\d+(\\.\\d+)?$/, obj, '请输入正确的数值');
   var NUM = document.getElementById(obj).value;
    if(isNaN(NUM)) 
     return ReturnTrue(obj, '该项必须为数值！');  
}

//身份证号验证
function IdCardNum(obj) {
    var idNo = document.getElementById(obj).value;
    if (idNo.length==15)
       return ValidateExp(/^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$/,obj,'身份证号不正确，请输入正确的身份证号');
    else if (idNo.length ==18)
       return ValidateExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/,obj,'身份证号不正确，请输入正确的身份证号');
    else
       return  ReturnTrue(obj,'身份证号不正确，请输入正确的身份证号');

}

//手机号码验证
function Mobile(obj) {
    return ValidateExp(/^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$/, obj,'请输入正确的手机号码');
}

//电话号码验证keliang.huang
function Tel(obj){
     if(ValidateExp(/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/, obj,'请输入正确的电话号码') && Mobile(obj))
     {
       return true;
     }
 
}

//整型数据验证
function IsInteger(obj) {

    return ValidateExp(/^(-){0,1}\d+$/, obj);
}

//日期格式验证
function IsDate(obj) {
   // return ValidateExp(/^((((19|20)\d{2})(0?[13-9]|1[012])(0?[1-9]|[12]\d|30))|(((19|20)\d{2})(0?[13578]|1[02])31)|(((19|20)\d{2})0?2(0?[1-9]|1\d|2[0-8]))|((((19|20)([13579][26]|[2468][048]|0[48]))|(2000))0?229))$/, obj, '请输入正确的日期格式');

   return ValidateExp(/^((((19|20)\d{2})-(0?[13-9]|1[012])-(0?[1-9]|[12]\d|30))|(((19|20)\d{2})-(0?[13578]|1[02])-31)|(((19|20)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|((((19|20)([13579][26]|[2468][048]|0[48]))|(2000))-0?2-29))$/, obj, '请输入正确的日期格式');

}
//keliang.huang designed
//生日验证不能大于当前日期
function IsBirthday(obj){
     if (document.getElementById(obj) == null) {
        alert('对象' + obj + ' 不存在，请检查代码是否正确！');
        return false;
    }
    var obj_value = document.getElementById(obj).value;

    if (obj_value == "") return false; 
    
     var myDate = new Date();
        var myYear = myDate.getFullYear();
        var myMonth = myDate.getMonth()+1;
        //alert(myYear.toString().length);
        if(myMonth.toString().length==1)//必须使用toString()否则认不出来是string类型 length会报undefined
          myMonth="0"+myMonth;
          
        
        var myDay = myDate.getDate();
        if(myDay.toString().length ==1)
            myDay = "0" + myDay;
        if (obj_value > myYear + "" + myMonth + "" + myDay) {
           
            return ReturnTrue(obj, '该项不能大于当前日期！');
        }
        else
            return ReturnFalse(obj);
}

//测试后者日期必须大于前者日期JS
function DateCompare_obj1bigerobj2(obj1,obj2,msg)
{
     if (document.getElementById(obj1) == null) {
        alert('对象' + obj1 + ' 不存在，请检查代码是否正确！');
        return false;
    }
     if (document.getElementById(obj2) == null) {
        alert('对象' + obj2 + ' 不存在，请检查代码是否正确！');
        return false;
    }
   if (document.getElementById(obj1).value != "" && document.getElementById(obj2).value != "") {
        if(document.getElementById(obj1).value> document.getElementById(obj2).value)
        {
            return ReturnTrue(obj2, msg); 
        }
    }
}

//验证网址合法性
function IsURL(str_url) {
    var strRegex = /^[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;

    var re = new RegExp(strRegex);

    if (re.test(str_url)) {

        return (true);
    } else {

        return (false);
    }
}

function IsCYCertNo(obj) {
    return ValidateExp(/^((津餐证字|津滨食药餐证字)\d{16}|津卫食证字\[\d{4}\]第\d{6}\w+号|津餐证字\d{10}-[^x00-xff]\d{4}|津卫食证字\[\d{4}\]第\d{6}-[^x00-xff]\w+号)$/, obj, '正确格式为：\r\n 津餐证字2012120221001274 或 津餐证字2011120000-高0010 或 津滨食药餐证字201212011605008 或 津卫食证字[2011]第120221C01275号 或 津卫食证字[2012]第120000-保C00301号');
}