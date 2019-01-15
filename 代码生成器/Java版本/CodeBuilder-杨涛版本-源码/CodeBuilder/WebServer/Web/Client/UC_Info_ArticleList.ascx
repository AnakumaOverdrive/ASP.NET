<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="UC_Info_ArticleList.ascx.cs" Inherits="Esint.CodeSite.Web.UC_Info_ArticleList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!-- 脚本引用 -->
<script src="../Js/validate.js" type="text/javascript"></script>

<table cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td>
            <table class="tb_query1">
                <tr>
                    <td class="td_Label">标题：</td>
                    <td class="td_Input"><asp:TextBox ID="txt_Title" runat="server" CssClass="TextBox"></asp:TextBox></td><td class="td_Button" style="width:260px;">
                    <asp:Button ID="btn_Search" runat="server" Text="查询"  CssClass="btn_Search" 
                        onclick="btn_Search_Click"/>
                    <asp:Button ID="btn_Add" runat="server" Text="新增" CssClass ="btn_Add" 
                        onclick="btn_Add_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_Info_Article" SkinID="GridViewSkin" runat="server" 
                AutoGenerateColumns="False"  OnSorting="gv_Info_Article_Sorting" 
                OnRowDatabound="gv_Info_Article_RowDataBound" 
                OnRowCommand ="gv_Info_Article_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle HorizontalAlign="Center"  Width="60px"/>
                        <ItemTemplate><asp:Label ID="lblIndex" runat="server"><%#Container.DataItemIndex + 1%></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标题" SortExpression="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_Title" runat="server" CommandName="Disp" CommandArgument='<%# Bind("AritcleID") %>' Text='<%# Bind("Title") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OpName" HeaderText="添加人" SortExpression="OpName"  ItemStyle-Width="80px"/>
                    <asp:BoundField DataField="OPTime" HeaderText="添加时间" SortExpression="OPTime" ItemStyle-Width="120px"/>
                    <asp:TemplateField HeaderText="操作">
                        <ItemStyle CssClass="GridViewOperate" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_edit" runat="server" CommandName="RowEdit" CommandArgument='<%#Eval("AritcleID")%>'>修改</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_delete" runat="server" CommandName="RowDelete" CommandArgument='<%#Eval("AritcleID")%>'>删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CssClass="pages"
            CurrentPageButtonClass="currentpage" CustomInfoHTML="共%RecordCount%条记录，当前为第%CurrentPageIndex%页，共%PageCount%页"
            CustomInfoSectionWidth="30%" CustomInfoTextAlign="Left" HorizontalAlign="Right"
            NextPageText="下一页&lt;img src='../images/arrow4.gif' border='0'/&gt;" NumericButtonCount="10"
            OnPageChanged="AspNetPager1_PageChanged" ShowBoxThreshold="10" ShowCustomInfoSection="Left"
            ShowFirstLast="False" ShowPageIndexBox="Never" Width="100%" PageSize="10">
            </webdiyer:AspNetPager>
        </td>
    </tr>
</table>
