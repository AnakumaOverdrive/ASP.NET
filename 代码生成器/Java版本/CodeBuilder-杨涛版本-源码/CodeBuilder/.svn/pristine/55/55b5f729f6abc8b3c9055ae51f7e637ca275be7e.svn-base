<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Info_ArticleInfo.ascx.cs" Inherits="Esint.CodeSite.Web.UC_Info_ArticleInfo" %>

<!-- 样式引用 -->
<link href="../Css/Common.css" rel="stylesheet" type="text/css" />

<!-- 脚本引用 -->
<script src="../Js/validate.js" type="text/javascript"></script>
<script charset="utf-8" src="../KindEditor/kindeditor.js"></script>
<script charset="utf-8" src="../KindEditor/lang/zh_CN.js"></script>

<!-- 验证脚本开始 -->
<script language="javascript" type="text/javascript">
    function chkform_info_Article(){
        var alert_msg="";
        var istrue=true;
        if(Require("<%=this.ID %>_txt_Title"))
        {
            alert_msg += "标题不能为空。";
            istrue = false;
        }
        if(istrue)
        {
            return true;
        }
        else
        {
            alert(alert_msg);
            return false;
        }
    }
    
    


 
    KindEditor.ready(function(K) {
    editor = K.create('textarea[name="<% =this.txt_InfoBody.ClientID%>"]', {
            cssPath: '../KindEditor/plugins/code/prettify.css',
            uploadJson: '../KindEditor/asp.net/upload_json.ashx',
            fileManagerJson: '../KindEditor/asp.net/file_manager_json.ashx',
            allowFileManager: true
        });
    });
</script>
<table class="tb_form">
        <tr>
            <td class="td_Label">标题：</td>
            <td class="td_InputW" colspan="3"><asp:TextBox ID="txt_Title" MaxLength="1000" CssClass="MustTextBox" runat="server"></asp:TextBox><span class="requestCss"></span></td>
        </tr>
        <tr>
            
            <td class="td_InputW" colspan="4"><asp:TextBox ID="txt_InfoBody" runat="server"  
                    CssClass="MustTextBox" TextMode="MultiLine" Height="543px" ></asp:TextBox><span class="requestCss"></span></td>
        </tr>
        <tr style="display:none;">
            <td class="td_Label">添加人：</td>
            <td class="td_Input"><asp:Label ID="lbl_OpName" runat="server"></asp:Label></td>
            <td class="td_Label">添加时间：</td>
            <td class="td_Input"><asp:Label ID="lbl_OPTime" runat="server"></asp:Label></td>
        </tr>
</table>
