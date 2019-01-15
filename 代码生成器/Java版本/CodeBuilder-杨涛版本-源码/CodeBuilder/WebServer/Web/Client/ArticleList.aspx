<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="Esint.CodeSite.Web.Client.ArticleList" %>

<%@ Register src="UC_Info_ArticleList.ascx" tagname="UC_Info_ArticleList" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:UC_Info_ArticleList ID="UC_Info_ArticleList1" runat="server" />
    
    </div>
    </form>
</body>
</html>
