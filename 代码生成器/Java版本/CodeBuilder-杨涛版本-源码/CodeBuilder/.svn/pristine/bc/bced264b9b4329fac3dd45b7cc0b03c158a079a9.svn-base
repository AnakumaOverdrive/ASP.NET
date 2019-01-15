<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleDisp.aspx.cs" Inherits="Esint.CodeSite.Web.Client.ArticleDisp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Js/SyntaxHighLight/styles/shCore.css" rel="stylesheet" type="text/css" />
    <link href="../Js/SyntaxHighLight/styles/shThemeDefault.css" rel="stylesheet" type="text/css" />

    <script src="../Js/SyntaxHighLight/scripts/shCore.js" type="text/javascript"></script>

    <script src="../Js/SyntaxHighLight/scripts/shBrushCss.js" type="text/javascript"></script>

    <script src="../Js/SyntaxHighLight/scripts/shBrushCSharp.js" type="text/javascript"></script>

    <script src="../Js/SyntaxHighLight/scripts/shBrushBash.js" type="text/javascript"></script>

    <script src="../Js/SyntaxHighLight/scripts/shBrushJScript.js" type="text/javascript"></script>

    <script src="../Js/SyntaxHighLight/scripts/shBrushXml.js" type="text/javascript"></script>

    <script type="text/javascript">
        SyntaxHighlighter.all();
    </script>

    <style>
        .body
        {
            line-height: 180%;
            text-indent: 2em;
            color: #444;
           
        }
        .info
        {
            text-align: center;
            color: #666;
            font-size: 12px;
            width: 100%;
            height: 50px;
            line-height: 50px;
        }
        body
        {
            margin: 0px;
            padding: 0px;
            padding-top:40px;
        }
        #toolbar
        {
            top: 0px;
            background: #e0ddd8;
            color: #fff;
            bottom: 0;
            margin: 0 auto;
            left: 0px;
            position: fixed;
            height: 27px; background-image:url('../images/toolbar_bg.gif');
            line-height: 27px;
            width: 100%;
            z-index: 999;
            _bottom: auto;
            _width: 100%;
            _position: absolute;
            _top: 0px; /*expression(eval(document.documentElement.scrollTop+document.documentElement.clientHeight-this.offsetHeight-(parseInt(this.currentStyle.marginTop,10)||0)-(parseInt(this.currentStyle.marginBottom,10)||0)));*/
        }
        .td_Label
        {
            height: 30px;
        }
        .srcTitle
        {
            font-size: 20px;
            text-align: center;
            width: 100%;
            font-weight: bold;
            line-height: 150%;
            display: block;
        }
    </style>
</head>
<body style="  padding-top:40px;">
    <form id="form1" runat="server"><div   id="toolbar" style="text-align:left;height:27px;display: block; position: fixed;width:100%;border-bottom:solid 1px #e0ddd8;"> 
    <div style="background-image:url(../images/toolbar.gif);background-repeat:no-repeat;">
        &nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="../images/toolbar_btn_return.gif" style="margin:1px;" 
            onclick="ImageButton1_Click"/>
        </div>
                    </div>
    
    <div>
        <h3 style="text-align: center; font-size: 24px;">
            <asp:Label ID="lbl_Title" runat="server" Text=""></asp:Label></h3>
        <div class="info">
            <asp:Label ID="lbl_Info" runat="server" Text=""></asp:Label></div>
        <div class="body">
            <asp:Label ID="lbl_Body" runat="server" Text=""></asp:Label></div>
    </div>
    </form>
</body>
</html>
