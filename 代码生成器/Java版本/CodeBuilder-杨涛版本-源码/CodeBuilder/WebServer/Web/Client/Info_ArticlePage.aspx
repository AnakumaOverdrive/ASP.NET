<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_ArticlePage.aspx.cs" Inherits="Esint.CodeSite.Web.Client.Info_ArticlePage"  ValidateRequest="false" %>

<%@ Register src="UC_Info_ArticleInfo.ascx" tagname="UC_Info_ArticleInfo" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="../Js/themes/default/easyui.css" rel="stylesheet" type="text/css" />  
     <script src="../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>

    
    <link href="../KindEditor/plugins/syntaxhighlight/styles/shThemeDjango.css" rel="stylesheet"
        type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:UC_Info_ArticleInfo ID="UC_Info_ArticleInfo1" runat="server" />
    <div class="OperateArea">
        <asp:Button ID="btn_Save" runat="server" Text="提交" CssClass="btn_Save" 
            onclick="btn_Save_Click" /><asp:Button ID="btn_Close" runat="server" Text="返回" CssClass="btn_Return" 
            onclick="btn_Close_Click" /></div>
    </div>
    </form>
</body>
</html>
