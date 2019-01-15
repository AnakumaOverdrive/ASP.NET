using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;

namespace Esint.Template.TemplateWeb
{
    public partial class WebListJAVA : Form, ITemplate
    {
        #region 模板接口

        //生成代码的主表
        public IDbTable Tbl { get; set; }

        //表空间
        public string NameSpace { get; set; }

        //文件名
        public string FileName { get; set; }

        //代码类型列表
        public List<ICodeType> CodeTypeList { get; set; }

        // 操作者姓名
        public string OperName { get; set; }

        //连接字符串
        public string ConnectString { get; set; }

        // 数据访问类
        public ICodeBuilder DataAccess { get; set; }

        // 表列表(用于多表生成)
        public List<IDbTable> Tbls { get; set; }

        // 是否打包生成(即是否批量生成)
        public bool IsPackage { get; set; }

        //程序名称(为名称空间指定名称时使用，因为bll和dal层是不能全称的。)
        public string AppName { get; set; }

        #endregion

        #region 窗口控制

        #region 局部变量
        //
        // 局部变量
        //  
        private int selectionIdx;       // 行拖动时,当前拖动的行号
        private string oldTablesAlias;  // 原表的别名,用于批量修改别名
        private string oldsubAlias;     // 原子表的别名.
        private bool fieldsReload;      // 字段列表是否重新加载,当选择第一个B标签后,会重新加载字段列表(该变量为True)
        private bool whereReload;       // 条件列表是否重新加载,当选择第一个B标签后,会重新加载字段列表(该变量为True)
        #endregion

        #region 初始化窗口

        //
        // 初始化窗口
        //
        public WebListJAVA()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 初始化设置窗口
        /// </summary>
        public void Initi()
        {
            fieldsReload = true; // 初始时,设置需要重新加载字段列表
            whereReload = true;  // 初始时,设置需要重新加载条件列表

            // 判断主数据表是否为空,如果为空,则提示错误
            if (Tbl == null)
            {
                MessageBox.Show("没有获取到数据表！", "错误");
                return;
            }

            lbl_MasterTableName.Text = Tbl.TableName;  // 设置主表显示表名
            txt_MainTableAlias.Text = Tbl.TableName;   //默认别名为表名
            oldTablesAlias = Tbl.TableName;            //修改前别名也为表名
            txt_MName.Text = "base";

            //
            // 根据主表的外键列表,初始化外键关联表
            //
            foreach (IForeignKeyClass fk in Tbl.ForeignKeys)
            {
                string onWhere = "ON ";
                int i = 0;
                foreach (IForeignKeyColumn fkc in fk.FKColumns)
                {
                    if (i == 0)
                        onWhere += fkc.PKTableName + "." + fkc.PKColumnName + "= " + fkc.FKTableName + "." + fkc.FKColumnName;
                    else
                        onWhere += " And " + fkc.PKTableName + "." + fkc.PKColumnName + "= " + fkc.FKTableName + "." + fkc.FKColumnName;
                    i++;
                }
                gv_SubTable.Rows.Add(new object[] { false, "Inner Join", fk.FKColumns[0].FKTableName, fk.FKColumns[0].FKTableName, onWhere });
            }

            //
            // 设置文件名
            // 
            txt_FileName.Text = Lower();

            //
            // 设置事件事先选中
            //
            // checkedListBox1.SetItemChecked(0, true);
            // checkedListBox1.SetItemChecked(1, true);

        }
        #endregion

        /// <summary>
        /// 新增数据表按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddTable_Click(object sender, EventArgs e)
        {
            Esint.TemplateCommon.SelectLinkTable select_Table_Form = new Esint.TemplateCommon.SelectLinkTable(DataAccess, ConnectString);

            Dictionary<string, string> stbs = new Dictionary<string, string>();

            foreach (DataGridViewRow row in gv_SubTable.Rows)
            {
                if (row.Cells[0].EditedFormattedValue.ToString() == "True")
                    stbs.Add(row.Cells[3].EditedFormattedValue.ToString(), row.Cells[2].EditedFormattedValue.ToString());//添加选中的子表
            }

            stbs.Add(txt_MainTableAlias.Text, Tbl.TableName);//添加主表

            select_Table_Form.Tables = stbs;
            select_Table_Form.ShowDialog();
            gv_SubTable.Rows.Add(new object[] { true, select_Table_Form.JoinType, select_Table_Form.SubTableName, select_Table_Form.SubAlias, select_Table_Form.OnWhere, select_Table_Form.FilterStr });
        }

        /// <summary>
        /// B标签改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    // 当选择了第一个选项卡后,要求重新加载字段和条件列表
                    fieldsReload = true;
                    whereReload = true;
                    break;

                case 1:
                    // 判断是否需要重新加载 字段 列表,加载后,将是否需要加载设置为false;
                    if (fieldsReload == false)
                        break;
                    else
                        fieldsReload = false;
                    //
                    // 重新加载列表
                    //
                    gv_Cols.Rows.Clear();
                    // IDbTable db = DataAccess.GetTableByTableName(ConnectString, Tbl.TableName);

                    foreach (IColumn col in this.Tbl.Columns)
                    {
                        gv_Cols.Rows.Add(new object[] { false, true, col.Description, col.ColumnName, col.ColumnName, Tbl.TableName, txt_MainTableAlias.Text });
                    }
                    foreach (DataGridViewRow row in gv_SubTable.Rows)
                    {
                        if (row.Cells[0].EditedFormattedValue.ToString() == "True")
                        {
                            string tableName = row.Cells[2].EditedFormattedValue.ToString();
                            IDbTable db = DataAccess.GetTableByTableName(ConnectString, tableName);
                            foreach (IColumn col in db.Columns)
                            {
                                gv_Cols.Rows.Add(new object[] { false, true, col.Description, col.ColumnName, col.ColumnName, tableName, row.Cells[3].EditedFormattedValue.ToString() });
                            }
                        }
                    }

                    break;
                case 2:
                    // 判断是否需要重新加载 条件 列表,加载后,将是否需要加载设置为false;
                    if (whereReload == false)
                        break;
                    else
                        whereReload = false;

                    //
                    // 重新加载列表
                    //
                    gv_ColsWhere.Rows.Clear();

                    // IDbTable db1 = DataAccess.GetTableByTableName(ConnectString, Tbl.TableName);
                    foreach (IColumn col in Tbl.Columns)
                    {
                        if (col.DataType.CSharpType == "DateTime" || col.DataType.CSharpType == "DateTime?")
                            gv_ColsWhere.Rows.Add(new object[] { false, false, col.Description, col.ColumnName, txt_MainTableAlias.Text, Tbl.TableName, "=", "", "R日期框", "" });
                        else
                            gv_ColsWhere.Rows.Add(new object[] { false, false, col.Description, col.ColumnName, txt_MainTableAlias.Text, Tbl.TableName, "=", "", "W文本框", "" });
                    }
                    foreach (DataGridViewRow row in gv_SubTable.Rows)
                    {
                        if (row.Cells[0].EditedFormattedValue.ToString() == "True")
                        {
                            string tableName = row.Cells[2].EditedFormattedValue.ToString();
                            string aliasName = row.Cells[3].EditedFormattedValue.ToString();
                            IDbTable db1 = DataAccess.GetTableByTableName(ConnectString, tableName);
                            foreach (IColumn col in db1.Columns)
                            {
                                if (col.DataType.CSharpType == "DateTime" || col.DataType.CSharpType == "DateTime?")
                                    gv_ColsWhere.Rows.Add(new object[] { false, false, col.Description, col.ColumnName, aliasName, tableName, "=", "", "R日期框", "" });
                                else
                                    gv_ColsWhere.Rows.Add(new object[] { false, false, col.Description, col.ColumnName, aliasName, tableName, "=", "", "W文本框", "" });
                            }
                        }
                    }
                    break;
                case 3:
                    // SQL语句
                    txt_SqlText.Text = getSqlString();
                    break;
            }
        }

        /// <summary>
        /// 条件列表选择值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_ColsWhere_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 如果
            if (e.ColumnIndex == 8 && e.RowIndex != -1 && !gv_ColsWhere.Rows[e.RowIndex].IsNewRow && gv_ColsWhere.Rows[e.RowIndex].Cells[8].Value.ToString() == "X下拉框")
            {
                ((DataGridViewComboBoxCell)this.gv_ColsWhere.CurrentRow.Cells[9]).DataSource = CodeTypeList;
                ((DataGridViewComboBoxCell)this.gv_ColsWhere.CurrentRow.Cells[9]).DisplayMember = "Meaning";
                ((DataGridViewComboBoxCell)this.gv_ColsWhere.CurrentRow.Cells[9]).ValueMember = "Flag";
            }

            if (e.ColumnIndex == 0)
            {
                gv_ColsWhere.Sort(gv_ColsWhere.Columns[0], ListSortDirection.Descending);
            }
        }

        private void txt_MainTableAlias_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gv_SubTable.Rows)
            {
                row.Cells[4].Value = row.Cells[4].EditedFormattedValue.ToString().Replace(" " + oldTablesAlias + ".", " " + txt_MainTableAlias.Text.Trim() + "."); //替换别名
            }
            oldTablesAlias = txt_MainTableAlias.Text;
        }

        private void gv_SubTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                gv_SubTable.Rows[e.RowIndex].Cells[4].Value = gv_SubTable.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(" " + oldsubAlias + ".", " " + gv_SubTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "."); //替换别名
            }
        }

        private void gv_SubTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                oldsubAlias = gv_SubTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void gv_ColsWhere_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (gv_ColsWhere.Rows[e.RowIndex].Cells[0].Value.ToString() == "True")
                {
                    gv_ColsWhere.Rows[e.RowIndex].Cells[1].Value = "True";
                    gv_ColsWhere.Rows[e.RowIndex].Cells[6].Value = "=";
                }
                else
                {
                    gv_ColsWhere.Rows[e.RowIndex].Cells[1].Value = "False";
                    gv_ColsWhere.Rows[e.RowIndex].Cells[6].Value = "";
                }
            }
        }

        private void btn_BuilderCode_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        public IReturnCode[] GetCode()
        {
            if (!IsPackage)
            {
                Initi();
                this.ShowDialog();
            }
            IReturnCode[] returnCode = new IReturnCode[2];

            returnCode[0] = GetAspxCode();
            returnCode[1] = GetAspxcsCode();
            // returnCode[2] = GetAspxDesignerCode();
            // returnCode[3] = GetBLLCode();
            // returnCode[4] = GetPageAspxCsCode();
            return returnCode;
        }

        #region 生成前台页面

        public IReturnCode GetAspxCode()
        {

            string textBoxCss = "TextBox"; //W文本框样式

            string mustTextBoxCss = "MustTextBox"; //必填项W文本框样式

            string tb_Form = "tb_Form"; //表单样式

            string td_label = "td_Label"; //B标签单元格样式

            string td_input = "td_Input"; //输入域单元格样式

            string td_MaxInput = "td_MaxInput"; // 跨列输入域样式

            string dropDownListCss = "DropDownList"; //下拉列表样式

            string MustdropDownList = "MustDropDownList"; //必填下拉列表样式

            string checkBoxCss = "CheckBoxCss"; //F复选框样式

            string mustCheckBoxCss = "MustCheckBoxCss"; // 必填F复选框样式

            string requestCss = "requestCss"; //必填提示符样式


            StringBuilder sb = new StringBuilder();

            #region 生成引用区

            //sb.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\"  CodeBehind=\"" + txt_FileName.Text + ".ascx.cs\" Inherits=\"" + string.Format(NameSpace, DataAccess.AppName) + "." + txt_FileName.Text + "\" %>");
            //sb.AppendLine("<%@ Register Assembly=\"AspNetPager\" Namespace=\"Wuqi.Webdiyer\" TagPrefix=\"webdiyer\" %>");
            //sb.AppendLine();
            //sb.AppendLine("<!-- 脚本引用 -->");
            //sb.AppendLine("<script src=\"../Js/validate.js\" type=\"text/javascript\"></script>");
            //if (HasControl(Tbl, "R日期框"))
            //{
            //    sb.AppendLine("<script src=\"../Js/calendar.js\" type=\"text/javascript\"></script>");
            //}
            sb.AppendLine("<%@ page language=\"java\" import=\"java.util.*\" pageEncoding=\"utf-8\"%>");

            sb.AppendLine("<!DOCTYPE html>");

            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title></title>");
            //sb.AppendLine("<script type=\"text/javascript\" src="" + txt_MName.Text+ "/scripts/" + Lower() + "List.js\"></script>");
            sb.AppendLine("<script type=\"text/javascript\" src=\"" + txt_MName.Text + "/scripts/" + Lower() + "List.js\"></script>");
            sb.AppendLine("</head>");

            sb.AppendLine("<body>");
            sb.AppendLine("<!-- 表格Div -->");
            sb.AppendLine("<div id=\"grid\" ></div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");


            #endregion

            #region 生成代码区
            //sb.AppendLine("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%\">");


            //// 如果生成Where条件查询,则生成该部分代码
            //if (this.cbx_IsWhere.Checked)
            //{
            //    sb.AppendLine("    <tr>");
            //    sb.AppendLine("        <td>");
            //    sb.AppendLine("            <table class=\"tb_form\">");
            //    int i = 0;
            //    foreach (DataGridViewRow row in gv_ColsWhere.Rows)
            //    {
            //        if (row.Cells[1].Value.ToString() == "True")
            //        {
            //            if (i == 0)
            //            {
            //                sb.AppendLine("                <tr>");
            //            }
            //            if (i / 2.0 == Convert.ToInt32(i / 2.0) && i != 0)
            //            {
            //                sb.AppendLine("                </tr>");
            //                sb.AppendLine("                <tr>");
            //            }

            //            sb.AppendLine("                    <td class=\"" + td_label + "\">" + row.Cells[2].Value.ToString() + "：" + "</td>");
            //            sb.Append("                    <td class=\""+td_input+"\">");

            //            if (row.Cells[8].Value.ToString() == "W文本框")
            //                sb.Append("<asp:TextBox ID=\"txt_" + row.Cells[3].Value.ToString() + "\" runat=\"server\" CssClass=\"" + textBoxCss + "\"></asp:TextBox>");
            //            if (row.Cells[8].Value.ToString() == "X下拉框")
            //            {
            //                sb.Append(" <asp:DropDownList ID=\"drp_" + row.Cells[3].Value.ToString() + "\" runat=\"server\" CssClass=\"" + dropDownListCss + "\"></asp:DropDownList>");
            //            }
            //            if (row.Cells[8].Value.ToString() == "R日期框")
            //            {
            //                sb.Append("<asp:TextBox ID=\"txt_Start" + row.Cells[3].Value.ToString() + "\" MaxLength=\"10\" CssClass=\"" + textBoxCss + "\"  onFocus=\"calendar()\" runat=\"server\"></asp:TextBox>");
            //                sb.Append("至");
            //                sb.Append("<asp:TextBox ID=\"txt_End" + row.Cells[3].Value.ToString() + "\" MaxLength=\"10\" CssClass=\"" + textBoxCss + "\"  onFocus=\"calendar()\" runat=\"server\"></asp:TextBox>");
            //            }

            //            sb.AppendLine("</td>");
            //            if (i == 1)
            //            {
            //                sb.AppendLine("                    <td rowspan=\"2\"><asp:Button ID=\"btn_Search\" runat=\"server\" CssClass=\"btn_Search\" Text=\"查询\" OnClick=\"btn_Search_Click\" />");

            //                if (cbx_IsImp.Checked)
            //                { 
            //                      sb.AppendLine("                    <br /><asp:Button ID=\"btn_Import\" runat=\"server\" CssClass=\"btn_Import\" Text=\"导出\" onclick=\"btn_Import_Click\" />");
            //                }

            //                sb.AppendLine("</td>");
            //            }
            //            i++;
            //        }
            //    }
            //    sb.AppendLine("                </tr>");
            //    sb.AppendLine("            </table>");
            //    sb.AppendLine("        </td>");
            //    sb.AppendLine("    </tr>");
            //}

            //sb.AppendLine("    <tr>");
            //sb.AppendLine("        <td>");
            //sb.AppendLine("            <asp:GridView ID=\"gv_" + Tbl.PascalName + "\" SkinID=\"GridViewSkin\" runat=\"server\" AutoGenerateColumns=\"False\" PageSize=\""+txt_PageSize.Text+"\"  OnSorting=\"gv_" + Tbl.PascalName + "_Sorting\" OnRowDatabound=\"gv_" + Tbl.PascalName + "_RowDataBound\" OnRowCommand =\"gv_" + Tbl.PascalName + "_RowCommand\">");
            //sb.AppendLine("                <Columns>");
            ////
            //// 如果复选列选中,生成复选列
            ////
            //if (cbx_IsCheck.Checked)
            //{
            //    sb.AppendLine("                    <asp:TemplateField HeaderText=\"\">");
            //    sb.AppendLine("                        <ItemStyle HorizontalAlign=\"Center\" />");
            //    sb.AppendLine("                        <ItemTemplate><asp:CheckBox runat=\"server\" ID=\"chk_Selected\" /></ItemTemplate>");
            //    sb.AppendLine("                    </asp:TemplateField>");
            //}
            ////
            //// 如果序号列选中,生成序号列
            ////
            //if (cbx_IsNum.Checked)
            //{
            //    sb.AppendLine("                    <asp:TemplateField HeaderText=\"序号\">");
            //    sb.AppendLine("                        <ItemStyle HorizontalAlign=\"Center\" />");
            //    sb.AppendLine("                        <ItemTemplate><asp:Label ID=\"lblIndex\" runat=\"server\"><%#Container.DataItemIndex + 1%></asp:Label></ItemTemplate>");
            //    sb.AppendLine("                    </asp:TemplateField>");
            //}


            //foreach (DataGridViewRow row in gv_Cols.Rows)
            //{
            //    if (row.Cells[0].Value.ToString() == "True")
            //    {
            //        sb.AppendLine("                    <asp:BoundField DataField=\"" + row.Cells["col_Field"].Value.ToString() + "\" HeaderText=\"" + row.Cells["col_Meaning"].Value.ToString() + "\" SortExpression=\"" + row.Cells["col_Alias"].Value.ToString() + "\" />");
            //    }
            //}
            //if (cbx_IsEdit.Checked||cbx_IsDelete.Checked)
            //{
            //    sb.AppendLine("                    <asp:TemplateField HeaderText=\"操作\">");
            //    sb.AppendLine("                        <ItemStyle CssClass=\"GridViewOperate\" />");
            //    sb.AppendLine("                        <ItemTemplate>");
            //    if (cbx_IsEdit.Checked)
            //    {
            //        sb.AppendLine("                            <asp:LinkButton ID=\"lbtn_edit\" runat=\"server\" CommandName=\"RowEdit\" CommandArgument='<%#Eval(\"" + Tbl.PrimaryKey.Columns[0].ColumnName + "\")%>'>修改</asp:LinkButton>");
            //    }
            //    if (cbx_IsDelete.Checked)
            //    {
            //        sb.AppendLine("                            <asp:LinkButton ID=\"lbtn_delete\" runat=\"server\" CommandName=\"RowDelete\" CommandArgument='<%#Eval(\"" + Tbl.PrimaryKey.Columns[0].ColumnName + "\")%>'>删除</asp:LinkButton>");
            //    }
            //    sb.AppendLine("                        </ItemTemplate>");
            //    sb.AppendLine("                    </asp:TemplateField>");
            //}
            //sb.AppendLine("                </Columns>");
            //sb.AppendLine("            </asp:GridView>");
            //sb.AppendLine("        </td>");
            //sb.AppendLine("    </tr>");
            //if (cbx_Page.Checked)
            //{
            //    sb.AppendLine("    <tr>");
            //    sb.AppendLine("        <td>");
            //    sb.AppendLine("            <webdiyer:AspNetPager ID=\"AspNetPager1\" runat=\"server\" AlwaysShow=\"True\" CssClass=\"pages\"");
            //    sb.AppendLine("            CurrentPageButtonClass=\"currentpage\" CustomInfoHTML=\"共%RecordCount%条记录，当前为第%CurrentPageIndex%页，共%PageCount%页\"");
            //    sb.AppendLine("            CustomInfoSectionWidth=\"30%\" CustomInfoTextAlign=\"Left\" HorizontalAlign=\"Right\"");
            //    sb.AppendLine("            NextPageText=\"下一页&lt;img src='../images/arrow4.gif' border='0'/&gt;\" NumericButtonCount=\"10\"");
            //    sb.AppendLine("            OnPageChanged=\"AspNetPager1_PageChanged\" ShowBoxThreshold=\"10\" ShowCustomInfoSection=\"Left\"");
            //    sb.AppendLine("            ShowFirstLast=\"False\" ShowPageIndexBox=\"Never\" Width=\"100%\" PageSize=\""+txt_PageSize.Text+"\">");
            //    sb.AppendLine("            </webdiyer:AspNetPager>");
            //    sb.AppendLine("        </td>");
            //    sb.AppendLine("    </tr>");
            //}
            //sb.AppendLine("</table>");


            #endregion


            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = txt_FileName.Text + "List.jsp";
            returnCode.CodeType = "HTML";







            return returnCode;

        }

        /// <summary>
        /// 生成js文件
        /// </summary>
        /// <returns></returns>
        public IReturnCode GetAspxcsCode()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("    var formdata={};//form提交数据");
            sb.AppendLine("	$(function(){");
            sb.AppendLine("		//列数据");
            sb.AppendLine("	    var columns = [");
            int num = getSelectCount();
            foreach (DataGridViewRow row in gv_Cols.Rows)
            {
                //选中列
                if (row.Cells[0].Value.ToString() == "True")
                {

                    sb.AppendLine("	       {title : \"" + row.Cells["col_Meaning"].Value.ToString() + "\",name : \"" + getNewColumn(row.Cells["col_Field"].Value.ToString()) + "\",width : 100, sortable:\"true\", sortName:\"" + row.Cells["col_Field"].Value.ToString() + "\",");
                    sb.AppendLine("			maxLength : 10,showTip : true");
                    if (num > 0)
                    {
                        if (row.Index == getSelectCount() - 1)
                        { sb.AppendLine("	       }"); }
                        else
                        {
                            sb.AppendLine("	       },");
                        }
                    }
                }
            }
            sb.AppendLine("          ];");






            sb.AppendLine("		//表格按钮");
            sb.AppendLine("		var buttons = [");
            sb.AppendLine("		       		{content: '<button class=\"btn btn-primary\" type=\"button\"><span class=\"glyphicon glyphicon-plus\"><span>创建</button>', action: 'add'},");
            sb.AppendLine("		            {content: '<button class=\"btn btn-success\" type=\"button\"><span class=\"glyphicon glyphicon-edit\"></span>&nbsp;修改</button>', action: 'edit'},");
            sb.AppendLine("		            {content: '<button class=\"btn btn-danger\" type=\"button\"><span class=\"glyphicon glyphicon-remove\"></span>&nbsp;删除</button>', action: 'del'}");
            sb.AppendLine("	            ];");

            sb.AppendLine("		 /**");
            sb.AppendLine("		  * 初始化表格");
            sb.AppendLine("		  */");
            sb.AppendLine("		$(\"#grid\").grid({");
            sb.AppendLine("			 identity: '" + GetPrimary() + "',");
            sb.AppendLine("             columns: columns,");
            sb.AppendLine("             buttons: buttons,");

            sb.AppendLine("             isUserLocalData:false,			//如果为false，则发送ajax请求到url端，获取数据，否则，则视为获取静态数据");
            sb.AppendLine("             url:basepath+\"" + Lower() + "/query" + GetewPascalName() + "List.do\",");
            sb.AppendLine("             isShowIndexCol:true,//是否显示复选框");
            sb.AppendLine("             pageNo:1,//分页起始页");
            sb.AppendLine("             pageSize:50,//分页");
            sb.AppendLine("             showPage:5//分页快捷显示页数");
            sb.AppendLine("        }).on({");
            sb.AppendLine("        	//创建按钮事件");
            sb.AppendLine("        	'add': function(){");
            sb.AppendLine("        		add();      		");
            sb.AppendLine("        	},");
            sb.AppendLine("        	'edit': function(event, data){");
            sb.AppendLine("        		edit(event, data);");
            sb.AppendLine("        	},");
            sb.AppendLine("        	'del': function(event, data){ ");
            sb.AppendLine("        		showRemoveTip(event,data);");
            sb.AppendLine("        	}");
            sb.AppendLine("	    })");
            sb.AppendLine("});");
            //   sb.AppendLine("");









            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = txt_FileName.Text + "List.js";
            returnCode.CodeType = "HTML";
            return returnCode;
        }




        #endregion

        #region 暂时隐藏

        //#region 生成前面页CS代码


        //public IReturnCode GetAspxcsCode()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("using System;");
        //    sb.AppendLine("using System.Collections;");
        //    sb.AppendLine("using System.Configuration;");
        //    sb.AppendLine("using System.Data;");
        //    sb.AppendLine("using System.Linq;");
        //    sb.AppendLine("using System.Web;");
        //    sb.AppendLine("using System.Web.Security;");
        //    sb.AppendLine("using System.Web.UI;");
        //    sb.AppendLine("using System.Web.UI.HtmlControls;");
        //    sb.AppendLine("using System.Web.UI.WebControls;");
        //    sb.AppendLine("using System.Web.UI.WebControls.WebParts;");
        //    sb.AppendLine("using System.Xml.Linq;");
        //    sb.AppendLine("using Esint.Common.Model;");
        //    sb.AppendLine("using Esint.Common.Web;");
        //    sb.AppendLine("using Esint." + AppName + ".BLL;");

        //    sb.AppendLine("");
        //    sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
        //    sb.AppendLine("{");
        //    sb.AppendLine("    /// <summary>");
        //    sb.AppendLine("    /// 模块名称： " + Tbl.TableDescription + "表单控件");
        //    sb.AppendLine("    /// 作    者：" + OperName);
        //    sb.AppendLine("    /// 日    期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
        //    sb.AppendLine("    /// 修改日期：");
        //    sb.AppendLine("    /// 修 改 人：");
        //    sb.AppendLine("    /// </summary>");
        //    sb.AppendLine("    public partial class " + txt_FileName.Text + ": BaseUserControl");
        //    sb.AppendLine("    {");
        //    sb.AppendLine("");


        //    #region 生成控件事件区

        //    sb.AppendLine("       #region 控件事件区");

        //    if (checkedListBox1.CheckedItems.IndexOf("OnRowCommand") >= 0)
        //    {
        //        sb.AppendLine("        //GridView 行命令事件 ");
        //        sb.AppendLine("        public event GridViewCommandEventHandler OnRowCommand;");
        //        sb.AppendLine();
        //    }

        //    if (checkedListBox1.CheckedItems.IndexOf("OnRowDataBound") >= 0)
        //    {
        //        sb.AppendLine("        //GridView 行数据绑定事件 ");
        //        sb.AppendLine("        public event GridViewRowEventHandler  OnRowDataBound;");    
        //        sb.AppendLine();

        //    }

        //    sb.AppendLine("       #endregion");

        //    #endregion

        //    sb.AppendLine("");

        //    #region 生成控件属性区

        //    /**********************************************/
        //    sb.AppendLine("       #region 控件属性区");
        //    foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //    {

        //        // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
        //        if (row.Cells[0].Value.ToString() == "True" && (row.Cells[1].Value.ToString() == "False" && string.IsNullOrEmpty(row.Cells[7].Value.ToString()) || !cbx_IsWhere.Checked))
        //        {
        //            IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //            if (row.Cells[8].Value.ToString() == "R日期框")
        //            {
        //                sb.AppendLine("        ///<summary>");
        //                sb.AppendLine("        ///" + col.Description + "");
        //                sb.AppendLine("        ///<summary>");
        //                sb.AppendLine("        public " + col.DataType.CSharpType + " Start" + col.PascalName);
        //                sb.AppendLine("        {");
        //                sb.AppendLine("            get { return (" + col.DataType.CSharpType + ")ViewState[\"Start" + col.PascalName + "\"]; }");
        //                sb.AppendLine("            set { ViewState[\"Start" + col.PascalName + "\"] = value; }");
        //                sb.AppendLine("        }");
        //                sb.AppendLine();
        //                sb.AppendLine("        ///<summary>");
        //                sb.AppendLine("        ///" + col.Description + "");
        //                sb.AppendLine("        ///<summary>");
        //                sb.AppendLine("        public " + col.DataType.CSharpType + " End" + col.PascalName);
        //                sb.AppendLine("        {");
        //                sb.AppendLine("            get { return (" + col.DataType.CSharpType + ")ViewState[\"End" + col.PascalName + "\"]; }");
        //                sb.AppendLine("            set { ViewState[\"End" + col.PascalName + "\"] = value; }");
        //                sb.AppendLine("        }");
        //            }
        //            else
        //            {
        //                sb.AppendLine("        ///<summary>");
        //                sb.AppendLine("        ///" + col.Description + "");
        //                sb.AppendLine("        ///<summary>");
        //                sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName);
        //                sb.AppendLine("        {");
        //                sb.AppendLine("            get { return (" + col.DataType.CSharpType + ")ViewState[\"" + col.PascalName + "\"]; }");
        //                sb.AppendLine("            set { ViewState[\"" + col.PascalName + "\"] = value; }");
        //                sb.AppendLine("        }");
        //            }
        //        }

        //    }
        //    sb.AppendLine("       #endregion");
        //    sb.AppendLine();

        //    #endregion

        //    #region 生成页面加载区

        //    sb.AppendLine("        #region 页面加载");
        //    sb.AppendLine();
        //    sb.AppendLine("        protected void Page_Init(object sender, EventArgs e)");
        //    sb.AppendLine("        { ");
        //    sb.AppendLine("            if (!Page.IsPostBack)");
        //    sb.AppendLine("            {");

        //    foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //    {
        //        // 如果该控件用于显示,则转化成属性
        //        if (row.Cells[1].Value.ToString() == "True" && row.Cells[8].Value.ToString() == "X下拉框")
        //        {
        //            sb.AppendLine("                //" + row.Cells[2].Value.ToString() + " drp绑定字典表");
        //            sb.AppendLine("                drp_" + row.Cells[3].Value.ToString() + ".CodeBinding(\"" + row.Cells[9].Value.ToString() + "\");");
        //            sb.AppendLine();
        //        }
        //    }
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine();

        //    #endregion

        //    #region 生成 GridView 数据操作区

        //    sb.AppendLine("        #region GridView 数据操作区[绑定，排序，分页]");
        //    sb.AppendLine();
        //    sb.AppendLine("        #region  数据表格绑定");
        //    sb.AppendLine();
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 数据表格绑定");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        public void DataGridBinding()");
        //    sb.AppendLine("        {");
        //    if (cbx_Page.Checked)
        //    {
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            // 设置手动分页");
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            PageSplit pages = new PageSplit();");
        //        sb.AppendLine("            pages.IsPageView = true;");
        //        sb.AppendLine("            pages.PageSize = AspNetPager1.PageSize;");
        //        sb.AppendLine("            pages.PageIndex = AspNetPager1.CurrentPageIndex;");
        //        sb.AppendLine();
        //        sb.AppendLine("            // 查询数据源");
        //        sb.AppendLine("            ReturnTable returnTable = new " + Tbl.PascalName + "Service().Get" + Tbl.PascalName + "Table(pages, SortExpression," + GetWhereParas() + "); ");
        //        sb.AppendLine();
        //        sb.AppendLine("            // 绑定分页控件");
        //        sb.AppendLine("            AspNetPager1.RecordCount = returnTable.PageInfo.RecordCount;");
        //        sb.AppendLine("            if (AspNetPager1.CurrentPageIndex != returnTable.PageInfo.PageIndex)");
        //        sb.AppendLine("                AspNetPager1.CurrentPageIndex = returnTable.PageInfo.PageIndex;");
        //        sb.AppendLine();
        //        sb.AppendLine("            // 绑定GridView");
        //        sb.AppendLine("            gv_" + Tbl.PascalName + ".DataSource = returnTable.Table;");
        //        sb.AppendLine("            gv_" + Tbl.PascalName + ".DataBind();");
        //    }
        //    else
        //    {
        //        sb.AppendLine("            // 查询数据源");
        //        sb.AppendLine("            DataTable returnTable =new " + Tbl.PascalName + "Service().Get" + Tbl.PascalName + "Table(SortExpression," + GetWhereParas() + ");");
        //        sb.AppendLine("            AspNetPager1.RecordCount = returnTable.Rows.Count;");
        //        sb.AppendLine();
        //        sb.AppendLine("            PagedDataSource dataSource = new PagedDataSource();");
        //        sb.AppendLine("            dataSource.AllowPaging = true;");
        //        sb.AppendLine("            dataSource.PageSize = AspNetPager1.PageSize;");
        //        sb.AppendLine("            dataSource.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;");
        //        sb.AppendLine("            dataSource.DataSource = returnTable.DefaultView;");
        //        sb.AppendLine("            ");
        //        sb.AppendLine("            // 绑定GridView");
        //        sb.AppendLine("            gv_" + Tbl.PascalName + ".DataSource = dataSource;");
        //        sb.AppendLine("            gv_" + Tbl.PascalName + ".DataBind();");
        //    }
        //    sb.AppendLine("        }");
        //    sb.AppendLine();
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine();
        //    sb.AppendLine("        #region GridView 行数据绑定事件 ");
        //    sb.AppendLine();
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 行数据绑定事件");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        protected void gv_" + Tbl.PascalName + "_RowDataBound(object sender, GridViewRowEventArgs e)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            if (e.Row.RowType== DataControlRowType.DataRow)");
        //    sb.AppendLine("            {");
        //    if (cbx_IsDelete.Checked)
        //    {
        //        sb.AppendLine("                 e.Row.SetDeleteMsg(\"lbtn_delete\");");
        //    }

        //    if (checkedListBox1.CheckedItems.IndexOf("OnRowDataBound") >= 0)
        //    {
        //        sb.AppendLine("                 this.OnRowDataBound(sender, e);");
        //    }

        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");
        //    sb.AppendLine();
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine();

        //    if (checkedListBox1.CheckedItems.IndexOf("OnRowCommand") >= 0)
        //    {
        //        sb.AppendLine("        #region GridView 行命令 事件 ");
        //        sb.AppendLine();
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// 行 命令 RowCommand 事件");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        protected void gv_" + Tbl.PascalName + "_RowCommand(object sender, GridViewCommandEventArgs e)");
        //        sb.AppendLine("        {");
        //        sb.AppendLine("            this.OnRowCommand(sender, e);");
        //        sb.AppendLine("        }");
        //        sb.AppendLine();
        //        sb.AppendLine("        #endregion");
        //        sb.AppendLine();
        //    }
        //    else
        //    {
        //        sb.AppendLine();
        //    }
        //    sb.AppendLine("        #region GridView 列头排序 事件 ");
        //    sb.AppendLine();
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 列头排序方法");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        /// <param name=\"sender\"></param>");
        //    sb.AppendLine("        /// <param name=\"e\"></param>");
        //    sb.AppendLine("        protected void gv_" + Tbl.PascalName + "_Sorting(object sender, GridViewSortEventArgs e)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            SortExpression = e.ToSortString(sender);");
        //    sb.AppendLine("            DataGridBinding();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine();
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine();
        //    if (cbx_Page.Checked)
        //    {
        //        sb.AppendLine("        #region GridView 分页 事件 ");
        //        sb.AppendLine();
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// 分页事件");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        protected void AspNetPager1_PageChanged(object sender, EventArgs e)");
        //        sb.AppendLine("        {");
        //        sb.AppendLine("            DataGridBinding();");
        //        sb.AppendLine("        }");
        //        sb.AppendLine();
        //        sb.AppendLine("        #endregion");
        //        sb.AppendLine();
        //    }
        //    sb.AppendLine("        #endregion");
        //    sb.AppendLine();

        //    #endregion

        //    #region 生成 查询按钮操作区 
        //    sb.AppendLine("        #region 查询按钮查询 事件 ");
        //    sb.AppendLine();
        //    sb.AppendLine("        /// <summary>");
        //    sb.AppendLine("        /// 查询按钮 单击事件 ");
        //    sb.AppendLine("        /// </summary>");
        //    sb.AppendLine("        protected void btn_Search_Click(object sender, EventArgs e)");
        //    sb.AppendLine("        {");
        //    sb.AppendLine("            DataGridBinding();");
        //    sb.AppendLine("        }");
        //    sb.AppendLine();
        //    if (cbx_IsImp.Checked)
        //    {
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// 将查询结果导出到Excel ");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        /// <param name=\"sender\"></param>");
        //        sb.AppendLine("        /// <param name=\"e\"></param>");
        //        sb.AppendLine("        protected void btn_Import_Click(object sender, EventArgs e)");
        //        sb.AppendLine("        {");
        //       // sb.AppendLine("            PageSplit pages = new PageSplit();");
        //        //sb.AppendLine("            pages.IsPageView = false;");
        //        sb.AppendLine("            DataTable returnTable = new " + Tbl.PascalName + "Service().Get" + Tbl.PascalName + "ImportTable("+txt_ImpRows.Text+", SortExpression," + GetWhereParas() + "); ");
        //        sb.AppendLine();
        //        sb.AppendLine("            Response.AddHeader(\"Content-Disposition\", \"attachment;filename=" + Tbl.PascalName + "List.xls\");");
        //        sb.AppendLine("            Response.ContentType = \"application/vnd.ms-excel\";");
        //        sb.AppendLine("            Response.Write(returnTable.ExportExcel(gv_" + Tbl.PascalName + "," + this.txt_ImpRows.Text + "));");
        //        sb.AppendLine("            try");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                Response.Flush();");
        //        sb.AppendLine("            }");
        //        sb.AppendLine("            catch");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("            }");
        //        sb.AppendLine("            finally");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();");
        //        sb.AppendLine("            }");
        //        sb.AppendLine("            Response.End();");
        //        sb.AppendLine("         } ");
        //    }
        //    sb.AppendLine("        #endregion");





        //    #endregion

        //    sb.AppendLine("    }");
        //    sb.AppendLine("}");


        //    ReturnCode returnCode = new ReturnCode();
        //    returnCode.CodeText = sb;
        //    returnCode.FileName = txt_FileName.Text + ".ascx.cs";
        //    returnCode.CodeType = "C#";
        //    return returnCode;
        //}

        //#endregion

        //public IReturnCode GetAspxDesignerCode()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("//------------------------------------------------------------------------------");
        //    sb.AppendLine("// <auto-generated>");
        //    sb.AppendLine("//     此代码由工具生成。");
        //    sb.AppendLine("//     运行时版本:2.0.50727.3053");
        //    sb.AppendLine("//");
        //    sb.AppendLine("//     对此文件的更改可能会导致不正确的行为，并且如果");
        //    sb.AppendLine("//     重新生成代码，这些更改将会丢失。");
        //    sb.AppendLine("// </auto-generated>");
        //    sb.AppendLine("//------------------------------------------------------------------------------");
        //    sb.AppendLine("");
        //    sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName) + "{");
        //    sb.AppendLine("    ");
        //    sb.AppendLine("    ");
        //    sb.AppendLine("    public partial class " + txt_FileName.Text + " {");
        //    if (cbx_IsWhere.Checked == true)
        //    {
        //        foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //        {
        //            // 如果该控件用于显示,则转化成属性
        //            if (row.Cells[1].Value.ToString() == "True")
        //            {
        //                if (row.Cells[8].Value.ToString() == "W文本框")
        //                {
        //                    sb.AppendLine();
        //                    sb.AppendLine("    /// <summary>");
        //                    sb.AppendLine("    /// txt_" + row.Cells[3].Value.ToString() + " 控件。");
        //                    sb.AppendLine("    /// </summary>");
        //                    sb.AppendLine("    /// <remarks>");
        //                    sb.AppendLine("    /// 自动生成的字段。");
        //                    sb.AppendLine("    /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
        //                    sb.AppendLine("    /// </remarks>");
        //                    sb.AppendLine("    protected global::System.Web.UI.WebControls.TextBox txt_" + row.Cells[3].Value.ToString() + ";");
        //                }
        //                if (row.Cells[8].Value.ToString() == "X下拉框")
        //                {
        //                    sb.AppendLine();
        //                    sb.AppendLine("    /// <summary>");
        //                    sb.AppendLine("    /// drp_" + row.Cells[3].Value.ToString() + " 控件。");
        //                    sb.AppendLine("    /// </summary>");
        //                    sb.AppendLine("    /// <remarks>");
        //                    sb.AppendLine("    /// 自动生成的字段。");
        //                    sb.AppendLine("    /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
        //                    sb.AppendLine("    /// </remarks>");
        //                    sb.AppendLine("    protected global::System.Web.UI.WebControls.DropDownList drp_" + row.Cells[3].Value.ToString() + ";");
        //                }

        //                if (row.Cells[8].Value.ToString() == "R日期框")
        //                {
        //                    sb.AppendLine();
        //                    sb.AppendLine("    /// <summary>");
        //                    sb.AppendLine("    /// txt_Start" + row.Cells[3].Value.ToString() + " 控件。");
        //                    sb.AppendLine("    /// </summary>");
        //                    sb.AppendLine("    /// <remarks>");
        //                    sb.AppendLine("    /// 自动生成的字段。");
        //                    sb.AppendLine("    /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
        //                    sb.AppendLine("    /// </remarks>");
        //                    sb.AppendLine("    protected global::System.Web.UI.WebControls.TextBox txt_Start" + row.Cells[3].Value.ToString() + ";");
        //                    sb.AppendLine();
        //                    sb.AppendLine("    /// <summary>");
        //                    sb.AppendLine("    /// txt_End" + row.Cells[3].Value.ToString() + " 控件。");
        //                    sb.AppendLine("    /// </summary>");
        //                    sb.AppendLine("    /// <remarks>");
        //                    sb.AppendLine("    /// 自动生成的字段。");
        //                    sb.AppendLine("    /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
        //                    sb.AppendLine("    /// </remarks>");
        //                    sb.AppendLine("    protected global::System.Web.UI.WebControls.TextBox txt_End" + row.Cells[3].Value.ToString() + ";");
        //                }
        //            }
        //        }
        //    }
        //    sb.AppendLine();
        //    sb.AppendLine("    /// <summary>");
        //    sb.AppendLine("    /// gv_" + Tbl.PascalName + " 控件。");
        //    sb.AppendLine("    /// </summary>");
        //    sb.AppendLine("    /// <remarks>");
        //    sb.AppendLine("    /// 自动生成的字段。");
        //    sb.AppendLine("    /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
        //    sb.AppendLine("    /// </remarks>");
        //    sb.AppendLine("    protected global::System.Web.UI.WebControls.GridView gv_" + Tbl.PascalName + ";");
        //    sb.AppendLine("     ");
        //    if (cbx_Page.Checked)
        //    {
        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// AspNetPager1 控件。");
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    /// <remarks>");
        //        sb.AppendLine("    /// 自动生成的字段。");
        //        sb.AppendLine("    /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
        //        sb.AppendLine("    /// </remarks>");
        //        sb.AppendLine("    protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;");
        //        sb.AppendLine();
        //    }
        //    sb.AppendLine("            }");
        //    sb.AppendLine("        }");

        //    ReturnCode returnCode = new ReturnCode();
        //    returnCode.CodeText = sb;
        //    returnCode.FileName = txt_FileName.Text  + ".ascx.designer.cs";
        //    returnCode.CodeType = "C#";
        //    return returnCode;
        //}


        //public IReturnCode GetBLLCode()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine();

        //    #region 生成 接口层 和 业务逻辑层
        //    if (this.cbx_Page.Checked)
        //    {
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  IDAL 接口层 接口方法，请将下面方法复制到 I" + Tbl.CamelName + "Service.cs 文件中使用 ");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  注意：不要复制到 I" + Tbl.CamelName + "Service.designer.cs中，不要复制本段！！！");
        //        sb.AppendLine("//*  ");
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine();
        //        sb.AppendLine();
        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
        //        sb.AppendLine("    /// 作    者: " + OperName);
        //        sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    /// <param name=\"pageView\">分页对象</param>");
        //        sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //        sb.AppendLine("    " + GetWhereSummaryString());
        //        sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //        sb.AppendLine("    ReturnTable Get" + Tbl.PascalName + "Table(PageSplit pageView, string orderStr, " + GetWhereParasString() + ");");
        //        sb.AppendLine();

        //        if (cbx_IsImp.Checked)
        //        {
        //            sb.AppendLine();
        //            sb.AppendLine("    /// <summary>");
        //            sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 导出数据列表，返回DataTable");
        //            sb.AppendLine("    /// 作    者: " + OperName);
        //            sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //            sb.AppendLine("    /// </summary>");
        //            sb.AppendLine("    /// <param name=\"rowNum\">记录数</param>");
        //            sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //            sb.AppendLine("    " + GetWhereSummaryString());
        //            sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //            sb.AppendLine("    DataTable Get" + Tbl.PascalName + "ImportTable(int rowNum, string orderStr, " + GetWhereParasString() + ");");
        //            sb.AppendLine();

        //        }
        //        sb.AppendLine();
        //        sb.AppendLine();

        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  BLL 层 业务逻辑方法，请将下面方法复制到 " + Tbl.CamelName + "Service.cs 文件中使用 ");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  注意：不要复制到" + Tbl.CamelName + "Service.designer.cs中，不要复制本段！！！");
        //        sb.AppendLine("//*  ");
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine();
        //        sb.AppendLine();
        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
        //        sb.AppendLine("    /// 作    者: " + OperName);
        //        sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    /// <param name=\"pageView\">分页对象</param>");
        //        sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //        sb.AppendLine("    " + GetWhereSummaryString());
        //        sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //        sb.AppendLine("    public ReturnTable Get" + Tbl.PascalName + "Table(PageSplit pageView, string orderStr, " + GetWhereParasString() + ")");
        //        sb.AppendLine("    {");
        //        sb.AppendLine("         return dataAccess.Get" + Tbl.PascalName + "Table(pageView,orderStr," + GetWhereParasValueString() + ");");
        //        sb.AppendLine("    }");
        //        sb.AppendLine();

        //        if (cbx_IsImp.Checked)
        //        {
        //            sb.AppendLine();
        //            sb.AppendLine("    /// <summary>");
        //            sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 导出列表，返回DataTable");
        //            sb.AppendLine("    /// 作    者: " + OperName);
        //            sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //            sb.AppendLine("    /// </summary>");
        //            sb.AppendLine("    /// <param name=\"rowNum\">分页对象</param>");
        //            sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //            sb.AppendLine("    " + GetWhereSummaryString());
        //            sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //            sb.AppendLine("    public DataTable Get" + Tbl.PascalName + "ImportTable(int rowNum, string orderStr, " + GetWhereParasString() + ")");
        //            sb.AppendLine("    {");
        //            sb.AppendLine("         return dataAccess.Get" + Tbl.PascalName + "ImportTable(rowNum,orderStr," + GetWhereParasValueString() + ");");
        //            sb.AppendLine("    }");
        //            sb.AppendLine();
        //        }
        //        sb.AppendLine();
        //        sb.AppendLine();
        //    }
        //    else
        //    {
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  IDAL 接口层 接口方法，请将下面方法复制到 I" + Tbl.CamelName + "Data.cs 文件中使用 ");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  注意：不要复制到 I" + Tbl.CamelName + "Data.designer.cs中，不要复制本段！！！");
        //        sb.AppendLine("//*  ");
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine();
        //        sb.AppendLine();
        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
        //        sb.AppendLine("    /// 作    者: " + OperName);
        //        sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //        sb.AppendLine("    "+GetWhereSummaryString());
        //        sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //        sb.AppendLine("    ReturnTable Get" + Tbl.PascalName + "Table(string orderStr, " + GetWhereParasString() + ");");
        //        sb.AppendLine();
        //        if (cbx_IsImp.Checked)
        //        {
        //            sb.AppendLine();
        //            sb.AppendLine("    /// <summary>");
        //            sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 导出数据列表，返回DataTable");
        //            sb.AppendLine("    /// 作    者: " + OperName);
        //            sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //            sb.AppendLine("    /// </summary>");
        //            sb.AppendLine("    /// <param name=\"rowNum\">记录数</param>");
        //            sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //            sb.AppendLine("    " + GetWhereSummaryString());
        //            sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //            sb.AppendLine("    DataTable Get" + Tbl.PascalName + "ImportTable(int rowNum, string orderStr, " + GetWhereParasString() + ");");
        //            sb.AppendLine();

        //        }

        //        sb.AppendLine();
        //        sb.AppendLine();


        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  BLL 层 业务逻辑方法，请将下面方法复制到 " + Tbl.CamelName + "Service.cs 文件中使用 ");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  注意：不要复制到" + Tbl.CamelName + "Service.designer.cs中，不要复制本段！！！");
        //        sb.AppendLine("//*  ");
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine();
        //        sb.AppendLine();
        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
        //        sb.AppendLine("    /// 作    者: " + OperName);
        //        sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //        sb.AppendLine("    " + GetWhereSummaryString());
        //        sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //        sb.AppendLine("    public ReturnTable Get" + Tbl.PascalName + "Table(string orderStr, " + GetWhereParasString() + ")");
        //        sb.AppendLine("    {");
        //        sb.AppendLine("         return dataAccess.Get" + Tbl.PascalName + "Table(orderStr," + GetWhereParasValueString() + ");");
        //        sb.AppendLine("    }");
        //        sb.AppendLine();
        //        if (cbx_IsImp.Checked)
        //        {
        //            sb.AppendLine();
        //            sb.AppendLine("    /// <summary>");
        //            sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 导出数据列表，返回DataTable");
        //            sb.AppendLine("    /// 作    者: " + OperName);
        //            sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //            sb.AppendLine("    /// </summary>");
        //            sb.AppendLine("    /// <param name=\"rowNum\">记录数</param>");
        //            sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //            sb.AppendLine("    " + GetWhereSummaryString());
        //            sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //            sb.AppendLine("    DataTable Get" + Tbl.PascalName + "ImportTable(int rowNum, string orderStr, " + GetWhereParasString() + ");");
        //            sb.AppendLine();

        //        }
        //        sb.AppendLine();
        //        sb.AppendLine();

        //    }

        //    #endregion

        //    #region 生成 数据访问层

        //    BuilderDALFunction(sb, "Oracle");
        //    sb.AppendLine();
        //    sb.AppendLine();
        //    sb.AppendLine();
        //    BuilderDALFunction(sb, "SqlServer");
        //    #endregion

        //    ReturnCode returnCode = new ReturnCode();
        //    returnCode.CodeText = sb;
        //    returnCode.FileName = txt_FileName.Text  + "BLL.cs";
        //    returnCode.CodeType = "C#";
        //    return returnCode;

        //}

        //public IReturnCode GetPageAspxCsCode()
        //{ 
        //   StringBuilder sb = new StringBuilder();

        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// 功能说明: "+Tbl.TableDescription+" 查询页面；");
        //        sb.AppendLine("    /// 作    者: "+this.OperName);
        //        sb.AppendLine("    /// 日    期: "+DateTime.Now.ToString("yyyy年MM月dd日"));
        //        sb.AppendLine("    /// 参数说明: ");
        //        sb.AppendLine("    /// 修改说明: ");
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    public partial class "+Tbl.PascalName+"ListPage : BasePage");
        //        sb.AppendLine("    {");
        //        sb.AppendLine("        #region  页面权限点");
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// 权限点说明: 有此权限点可打开，无权限不能访问");
        //        sb.AppendLine("        ///             [权限名称]:     权限含义");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        const string PAGE_POWERPOINT = \"\";");
        //        sb.AppendLine();
        //        sb.AppendLine("        #endregion");


        //        /**********************************************/
        //        sb.AppendLine("       #region 控件属性区");
        //        foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //        {

        //            // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
        //            if (row.Cells[0].Value.ToString() == "True" && (row.Cells[1].Value.ToString() == "False" && string.IsNullOrEmpty(row.Cells[7].Value.ToString()) || !cbx_IsWhere.Checked))
        //            {
        //                IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //                if (row.Cells[8].Value.ToString() == "R日期框")
        //                {
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        ///" + col.Description + "");
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        public " + col.DataType.CSharpType + " Start" + col.PascalName);
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            get { return string.IsNullOrEmpty(Request.QueryString[\"Start" + col.PascalName + "\"])?DateTime.MinValue:Convert.ToDateTime(Request.QueryString[\"Start" + col.PascalName + "\"]); }");
        //                    //sb.AppendLine("            set { ViewState[\"Start" + col.PascalName + "\"] = value; }");
        //                    sb.AppendLine("        }");
        //                    sb.AppendLine();
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        ///" + col.Description  + "");
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        public " + col.DataType.CSharpType + " End" + col.PascalName);
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            get {  return string.IsNullOrEmpty(Request.QueryString[\"End" + col.PascalName + "\"])?DateTime.MaxValue:Convert.ToDateTime(Request.QueryString[\"End" + col.PascalName + "\"]); }");
        //                   // sb.AppendLine("            set { ViewState[\"End" + col.PascalName + "\"] = value; }");
        //                    sb.AppendLine("        }");
        //                }
        //                else if (col.DataType.CSharpType == "Guid")
        //                {
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        ///" + col.Description + "");
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName);
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            get { return string.IsNullOrEmpty(Request.QueryString[\"" + col.PascalName + "\"]) ? Guid.Empty:new Guid(Request.QueryString[\"" + col.PascalName + "\"]); }");
        //                   // sb.AppendLine("            set { ViewState[\"" + col.PascalName + "\"] = value; }");
        //                    sb.AppendLine("        }");
        //                }
        //                else
        //                {
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        ///" + col.Description + "");
        //                    sb.AppendLine("        ///<summary>");
        //                    sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName);
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            get {return string.IsNullOrEmpty(Request.QueryString[\"" + col.PascalName + "\"]) ?null:(" + col.DataType.CSharpType + ")Request.QueryString[\"" + col.PascalName + "\"]; }");
        //                   // sb.AppendLine("            set { ViewState[\"" + col.PascalName + "\"] = value; }");
        //                    sb.AppendLine("        }");
        //                }
        //            }

        //        }
        //        sb.AppendLine("       #endregion");
        //        sb.AppendLine();
        //        sb.AppendLine();
        //        sb.AppendLine("        #region 页面加载事件");
        //        sb.AppendLine();
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// 页面加载事件");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        /// <param name=\"sender\"></param>");
        //        sb.AppendLine("        /// <param name=\"e\"></param>");
        //        sb.AppendLine("        protected void Page_Load(object sender, EventArgs e)");
        //        sb.AppendLine("        {");
        //        sb.AppendLine("            #region 注册GridView事件");
        //        sb.AppendLine();
        //        sb.AppendLine("            // 注册GridView事件");
        //        sb.AppendLine("            " + txt_FileName.Text + "1.OnRowCommand += new GridViewCommandEventHandler(" + txt_FileName.Text + "1_OnRowCommand);");
        //        sb.AppendLine("            " + txt_FileName.Text + "1.OnRowDataBound += new GridViewRowEventHandler(" + txt_FileName.Text + "1_OnRowDataBound);");
        //        sb.AppendLine();
        //        sb.AppendLine("            #endregion");
        //        sb.AppendLine();
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            // 绑定 GridView 数据列表");
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            if (!Page.IsPostBack)");
        //        sb.AppendLine("            {");

        //        foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //        {

        //            // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
        //            if (row.Cells[0].Value.ToString() == "True" && (row.Cells[1].Value.ToString() == "False" && string.IsNullOrEmpty(row.Cells[7].Value.ToString()) || !cbx_IsWhere.Checked))
        //            {
        //                IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //                if (row.Cells[8].Value.ToString() == "R日期框")
        //                {
        //                    sb.AppendLine("                this." + txt_FileName.Text + "1.Start" + col.PascalName + " = Start" + col.PascalName + ";");
        //                    sb.AppendLine("                this." + txt_FileName.Text + "1.End" + col.PascalName + " = End" + col.PascalName + ";");
        //                }
        //                else
        //                sb.AppendLine("                this." + txt_FileName.Text + "1."+col.PascalName+" = "+col.PascalName+";");
        //            }
        //        }

        //        sb.AppendLine("                this." + txt_FileName.Text + "1.DataGridBinding();");
        //        sb.AppendLine("            }");
        //        sb.AppendLine("        }");
        //        sb.AppendLine();
        //        sb.AppendLine("        #endregion");
        //        sb.AppendLine();
        //        sb.AppendLine("        #region GridView 事件");
        //        sb.AppendLine();
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// UC_" + Tbl.PascalName + "List1 行记录绑定事件");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        /// <param name=\"sender\"></param>");
        //        sb.AppendLine("        /// <param name=\"e\"></param>");
        //        sb.AppendLine("        void " + txt_FileName.Text + "1_OnRowDataBound(object sender, GridViewRowEventArgs e)");
        //        sb.AppendLine("        {");
        //        string p = "", p1 = "";
        //        foreach(IColumn  col in Tbl.PrimaryKey.Columns)
        //        {
        //            p+="+\""+col.PascalName+"=\" + DataBinder.Eval(e.Row.DataItem,\""+col.PascalName+"\").ToString()+\"&\"";
        //            p1 += "+\"" + col.PascalName + "=\" + e.CommandArgument.ToString()+\"&\"";
        //        }
        //        p=p.Substring(0,p.Length-4);
        //        p1 = p1.Substring(0, p1.Length - 4);
        //        sb.AppendLine("            //JsHelper.Window.OpenModalDialog(((LinkButton)e.Row.FindControl(\"lbtn_edit\")), \""+Tbl.PascalName+"Page.aspx?\""+p+", 600, 700);" );
        //        sb.AppendLine("        }");
        //        sb.AppendLine();
        //        sb.AppendLine("        /// <summary>");
        //        sb.AppendLine("        /// UC_"+Tbl.PascalName+"List1 行命令事件");
        //        sb.AppendLine("        /// </summary>");
        //        sb.AppendLine("        /// <param name=\"sender\"></param>");
        //        sb.AppendLine("        /// <param name=\"e\"></param>");
        //        sb.AppendLine("        public void " + txt_FileName.Text + "1_OnRowCommand(object sender, GridViewCommandEventArgs e)");
        //        sb.AppendLine("        {");
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            // 修改按钮单击事件");
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            if (e.CommandName.ToUpper() == \"ROWEDIT\")");
        //        sb.AppendLine("            {");
        //        sb.AppendLine("                  //Response.Redirect(\""+Tbl.PascalName+"Page.aspx?\""+p+");\");");
        //        sb.AppendLine("            }");
        //        sb.AppendLine();
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            // 删除按钮单击事件");
        //        sb.AppendLine("            //");
        //        sb.AppendLine("            if (e.CommandName.ToUpper() == \"ROWDELETE\")");
        //        sb.AppendLine("            {   ");
        //        sb.AppendLine("                // 根据主键 删除 企业基本信息 ");
        //        if (Tbl.PrimaryKey.Columns.Count == 1)
        //        {
        //            if (Tbl.PrimaryKey.Columns[0].DataType.CSharpType == "Guid")
        //            {
        //                sb.AppendLine("                new BLL." + Tbl.PascalName + "Service().Delete(new Guid(e.CommandArgument.ToString()));");
        //            }
        //            else
        //            {
        //                sb.AppendLine("                new BLL." + Tbl.PascalName + "Service().Delete(("+Tbl.PrimaryKey.Columns[0].DataType.CSharpType+")e.CommandArgument.ToString());");
        //            }
        //        }
        //        else
        //        {
        //            sb.AppendLine("            string [] args = e.CommandArgument.ToString().split(',')");
        //            string arg = "";int i=0;
        //            foreach (IColumn col in Tbl.PrimaryKey.Columns)
        //            {
        //                arg += "args["+(i++)+"],";
        //            }
        //            arg = arg.Substring(0, arg.Length - 1);
        //            sb.AppendLine("                new BLL." + Tbl.PascalName + "Service().Delete("+arg+");");

        //        }
        //        sb.AppendLine();      
        //        sb.AppendLine("                // 显示删除成功");
        //        sb.AppendLine("                JsHelper.Message.ShowMessage(\"删除成功！\");");
        //        sb.AppendLine();
        //        sb.AppendLine("                // 刷新 列表");
        //        sb.AppendLine("                " + txt_FileName.Text + "1.DataGridBinding();");
        //        sb.AppendLine("             }");
        //        sb.AppendLine("         }");
        //        sb.AppendLine("        #endregion");
        //        sb.AppendLine("    }");

        //    ReturnCode returnCode = new ReturnCode();
        //    returnCode.CodeText = sb;
        //    returnCode.FileName = Tbl.PascalName+"ListPage .cs";
        //    returnCode.CodeType = "C#";
        //    return returnCode;
        //}
        #endregion

        public void BuilderDALFunction(StringBuilder sb, string dbType)
        {

            if (this.cbx_Page.Checked)
            {
                sb.AppendLine("//***************************************************************************************/");
                sb.AppendLine("//*                                                                                 ");
                sb.AppendLine("//*  " + dbType + " DAL层 数据访问方法，请将下面方法复制到 " + Tbl.CamelName + "Data.cs 文件中使用 ");
                sb.AppendLine("//*                                                                                 ");
                sb.AppendLine("//*  注意：不要复制到" + Tbl.CamelName + "Data.designer.cs中，不要复制本段！！！");
                sb.AppendLine("//*  ");
                sb.AppendLine("//***************************************************************************************/");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("    /// <summary>");
                sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
                sb.AppendLine("    /// 作    者: " + OperName);
                sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
                sb.AppendLine("    /// </summary>");
                sb.AppendLine("    /// <param name=\"pageView\">分页对象</param>");
                sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
                sb.AppendLine("    " + GetWhereSummaryString());
                sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
                sb.AppendLine("    public ReturnTable Get" + Tbl.PascalName + "Table(PageSplit pageView, string orderStr, " + GetWhereParasString() + ")");
                sb.AppendLine("    {");
                sb.AppendLine("        ReturnTable returnTable = new ReturnTable();");
            }
            else
            {

                sb.AppendLine("//***************************************************************************************/");
                sb.AppendLine("//*                                                                                 ");
                sb.AppendLine("//*  " + dbType + " DAL层 数据访问方法，请将下面方法复制到 " + Tbl.CamelName + "Data.cs 文件中使用 ");
                sb.AppendLine("//*                                                                                 ");
                sb.AppendLine("//*  注意：不要复制到" + Tbl.CamelName + "Data.designer.cs中，不要复制本段！！！");
                sb.AppendLine("//*  ");
                sb.AppendLine("//***************************************************************************************/");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("    /// <summary>");
                sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
                sb.AppendLine("    /// 作    者: " + OperName);
                sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
                sb.AppendLine("    /// </summary>");
                sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
                sb.AppendLine("    " + GetWhereSummaryString());
                sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
                sb.AppendLine("    public ReturnTable Get" + Tbl.PascalName + "Table(string orderStr, " + GetWhereParasString() + ")");
                sb.AppendLine("    {");
            }

            sb.AppendLine("        DataQuery query = new DataQuery();");
            sb.AppendLine();
            sb.AppendLine("        query.SQLText = @\"" + getSqlString() + "\";");
            sb.AppendLine();
            foreach (DataGridViewRow row in gv_ColsWhere.Rows)
            {
                if (row.Cells[1].Value.ToString() == "True")
                {
                    IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                    if (row.Cells[8].Value.ToString() == "R日期框")
                    {
                        if (dbType.ToUpper() == "SQLSERVER")
                        {
                            sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
                            sb.AppendLine("        {");
                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=@Start" + col.PascalName + "\";");
                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
                            sb.AppendLine("        }");
                            sb.AppendLine();

                            sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
                            sb.AppendLine("        {");
                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=@End" + col.PascalName + "\";");
                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
                            sb.AppendLine("        }");
                            sb.AppendLine();
                        }
                        if (dbType.ToUpper() == "ORACLE")
                        {
                            sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
                            sb.AppendLine("        {");
                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=to_date(:Start" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
                            sb.AppendLine("        }");
                            sb.AppendLine();

                            sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
                            sb.AppendLine("        {");
                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=to_date(:End" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
                            sb.AppendLine("        }");
                            sb.AppendLine();

                        }
                    }
                    else
                    {
                        if (col.DataType.CSharpType == "Guid")
                        {
                            sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
                        }
                        else if (col.DataType.CSharpType.IndexOf("?") != -1)
                        {
                            sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
                        }
                        else
                        {
                            sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
                        }
                        sb.AppendLine("        {");

                        if (row.Cells[6].Value.ToString().ToLower() == "like")
                        {
                            if (dbType.ToUpper() == "SQLSERVER")
                            {
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
                            }

                            if (dbType.ToUpper() == "ORACLE")
                            {
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
                            }
                        }
                        else
                        {
                            if (dbType.ToUpper() == "SQLSERVER")
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
                            if (dbType.ToUpper() == "ORACLE")
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

                        }

                        if (dbType.ToUpper() == "SQLSERVER")
                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

                        if (dbType.ToUpper() == "ORACLE")
                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");

                        sb.AppendLine("        }");
                        sb.AppendLine();
                    }
                }
                else
                {
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                        if (string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                        {
                            if (col.DataType.CSharpType == "Guid")
                            {
                                sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
                            }
                            else if (col.DataType.CSharpType.IndexOf("?") != -1)
                            {
                                sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
                            }
                            else
                            {
                                sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
                            }
                            sb.AppendLine("        {");

                            if (row.Cells[6].Value.ToString().ToLower() == "like")
                            {
                                if (dbType.ToUpper() == "SQLSERVER")
                                {
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
                                }

                                if (dbType.ToUpper() == "ORACLE")
                                {
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
                                }
                            }
                            else
                            {
                                if (dbType.ToUpper() == "SQLSERVER")
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
                                if (dbType.ToUpper() == "ORACLE")
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

                            }

                            if (dbType.ToUpper() == "SQLSERVER")
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

                            if (dbType.ToUpper() == "ORACLE")
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");


                            sb.AppendLine("        }");
                        }
                        else
                        {

                            if (row.Cells[6].Value.ToString().ToLower() == "like")
                            {
                                if (dbType.ToUpper() == "SQLSERVER")
                                {
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
                                }

                                if (dbType.ToUpper() == "ORACLE")
                                {
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
                                }
                            }
                            else
                            {
                                if (dbType.ToUpper() == "SQLSERVER")
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
                                if (DataAccess.DataBaseType == "ORACLE")
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

                            }

                            if (dbType.ToUpper() == "SQLSERVER")
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");

                            if (dbType.ToUpper() == "ORACLE")
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");



                        }

                    }
                }
            }
            sb.AppendLine("        query.OrderByString = orderStr;");
            sb.AppendLine();
            if (this.cbx_Page.Checked)
            {
                sb.AppendLine("        query.PageView = pageView;      //分页");

                sb.AppendLine("        // 排序");
                sb.AppendLine();
                sb.AppendLine("        returnTable.Table = BaseData.ExecuteDataTable(query);");
                sb.AppendLine("        returnTable.PageInfo = query.PageView;");
                sb.AppendLine("        return returnTable;");
            }
            else
                sb.AppendLine("       return BaseData.ExecuteDataTable(query);");

            sb.AppendLine("     }");


            if (cbx_IsImp.Checked)
            {
                sb.AppendLine("    /// <summary>");
                sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
                sb.AppendLine("    /// 作    者: " + OperName);
                sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
                sb.AppendLine("    /// </summary>");
                sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
                sb.AppendLine("    " + GetWhereSummaryString());
                sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
                sb.AppendLine("    public DataTable Get" + Tbl.PascalName + "ImportTable(int rowNum,string orderStr, " + GetWhereParasString() + ")");
                sb.AppendLine("    {");

                sb.AppendLine("        DataQuery query = new DataQuery();");

                sb.AppendLine("        PageSplit pageView = new PageSplit();");
                sb.AppendLine("        pageView.PageIndex = 1;");
                sb.AppendLine("        pageView.PageSize = rowNum;");

                sb.AppendLine();
                sb.AppendLine("        query.SQLText = @\"" + getImportSqlString() + "\";");
                sb.AppendLine();
                foreach (DataGridViewRow row in gv_ColsWhere.Rows)
                {
                    if (row.Cells[1].Value.ToString() == "True")
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                        if (row.Cells[8].Value.ToString() == "R日期框")
                        {
                            if (dbType.ToUpper() == "SQLSERVER")
                            {
                                sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
                                sb.AppendLine("        {");
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=@Start" + col.PascalName + "\";");
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
                                sb.AppendLine("        }");
                                sb.AppendLine();

                                sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
                                sb.AppendLine("        {");
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=@End" + col.PascalName + "\";");
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
                                sb.AppendLine("        }");
                                sb.AppendLine();
                            }
                            if (dbType.ToUpper() == "ORACLE")
                            {
                                sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
                                sb.AppendLine("        {");
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=to_date(:Start" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
                                sb.AppendLine("        }");
                                sb.AppendLine();

                                sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
                                sb.AppendLine("        {");
                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=to_date(:End" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
                                sb.AppendLine("        }");
                                sb.AppendLine();

                            }
                        }
                        else
                        {
                            if (col.DataType.CSharpType == "Guid")
                            {
                                sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
                            }
                            else if (col.DataType.CSharpType.IndexOf("?") != -1)
                            {
                                sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
                            }
                            else
                            {
                                sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
                            }
                            sb.AppendLine("        {");

                            if (row.Cells[6].Value.ToString().ToLower() == "like")
                            {
                                if (dbType.ToUpper() == "SQLSERVER")
                                {
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
                                }

                                if (dbType.ToUpper() == "ORACLE")
                                {
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
                                }
                            }
                            else
                            {
                                if (dbType.ToUpper() == "SQLSERVER")
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
                                if (dbType.ToUpper() == "ORACLE")
                                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

                            }

                            if (dbType.ToUpper() == "SQLSERVER")
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

                            if (dbType.ToUpper() == "ORACLE")
                                sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");

                            sb.AppendLine("        }");
                            sb.AppendLine();
                        }
                    }
                    else
                    {
                        if (row.Cells[0].Value.ToString() == "True")
                        {
                            IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                            if (string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                            {
                                if (col.DataType.CSharpType == "Guid")
                                {
                                    sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
                                }
                                else if (col.DataType.CSharpType.IndexOf("?") != -1)
                                {
                                    sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
                                }
                                else
                                {
                                    sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
                                }
                                sb.AppendLine("        {");

                                if (row.Cells[6].Value.ToString().ToLower() == "like")
                                {
                                    if (dbType.ToUpper() == "SQLSERVER")
                                    {
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
                                    }

                                    if (dbType.ToUpper() == "ORACLE")
                                    {
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
                                    }
                                }
                                else
                                {
                                    if (dbType.ToUpper() == "SQLSERVER")
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
                                    if (dbType.ToUpper() == "ORACLE")
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

                                }

                                if (dbType.ToUpper() == "SQLSERVER")
                                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

                                if (dbType.ToUpper() == "ORACLE")
                                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");


                                sb.AppendLine("        }");
                            }
                            else
                            {

                                if (row.Cells[6].Value.ToString().ToLower() == "like")
                                {
                                    if (dbType.ToUpper() == "SQLSERVER")
                                    {
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
                                    }

                                    if (dbType.ToUpper() == "ORACLE")
                                    {
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
                                    }
                                }
                                else
                                {
                                    if (dbType.ToUpper() == "SQLSERVER")
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
                                    if (DataAccess.DataBaseType == "ORACLE")
                                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

                                }

                                if (dbType.ToUpper() == "SQLSERVER")
                                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");

                                if (dbType.ToUpper() == "ORACLE")
                                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");



                            }

                        }
                    }
                }
                sb.AppendLine("        query.OrderByString = orderStr;");
                sb.AppendLine();
                if (this.cbx_Page.Checked)
                {
                    sb.AppendLine("        query.PageView = pageView;      //分页");

                    sb.AppendLine("        // 排序");
                    sb.AppendLine();
                    sb.AppendLine("        return BaseData.ExecuteDataTable(query);");
                }
                else
                    sb.AppendLine("       return BaseData.ExecuteDataTable(query);");

                sb.AppendLine("     }");

            }

        }


        #region 公用方法

        public IColumn GetColByName(string tableName, string colName)
        {
            IDbTable table;
            if (tableName.ToUpper() != Tbl.TableName.ToUpper())
                table = DataAccess.GetTableByTableName(ConnectString, tableName);
            else
                table = Tbl;
            IColumn col1 = table.Columns.Find(delegate(IColumn col) { return col.ColumnName == colName; });
            return col1;
        }

        public string GetWhereParas()
        {
            StringBuilder returnsb = new StringBuilder();
            foreach (DataGridViewRow row in gv_ColsWhere.Rows)
            {
                // 如果该控件用于显示,则转化成属性
                if (row.Cells[1].Value.ToString() == "True" && cbx_IsWhere.Checked)
                {
                    IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                    if (row.Cells[8].Value.ToString() == "W文本框")
                    {
                        returnsb.Append("txt_" + row.Cells[3].Value.ToString() + ".Text.Trim(),");
                    }
                    if (row.Cells[8].Value.ToString() == "R日期框")
                    {
                        returnsb.Append("txt_Start" + row.Cells[3].Value.ToString() + ".Text.Trim(),");
                        returnsb.Append("txt_End" + row.Cells[3].Value.ToString() + ".Text.Trim(),");
                    }
                    if (row.Cells[8].Value.ToString() == "X下拉框")
                    {
                        returnsb.Append("drp_" + row.Cells[3].Value.ToString() + ".SelectedItem.Value,");
                    }
                }
                else
                {
                    // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
                    if (row.Cells[0].Value.ToString() == "True" && (string.IsNullOrEmpty(row.Cells[7].Value.ToString()) || !cbx_IsWhere.Checked))
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                        if (row.Cells[8].Value.ToString() == "R日期框")
                        {
                            returnsb.Append("Start" + col.PascalName + ",");
                            returnsb.Append("End" + col.PascalName + ",");
                        }
                        else
                            returnsb.Append(col.PascalName + ",");
                    }
                }
            }
            string returnStr = returnsb.ToString();

            if (returnStr.Length > 0)
                returnStr = returnStr.Substring(0, returnStr.Length - 1);
            return returnStr;
        }

        /// <summary>
        /// 得到where参数列表
        /// </summary>
        /// <returns></returns>
        public string GetWhereParasString()
        {
            string returnStr = "";
            foreach (DataGridViewRow row in gv_ColsWhere.Rows)
            {
                // 如果该控件用于显示,则转化成属性
                if (row.Cells[1].Value.ToString() == "True")
                {
                    IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                    if (row.Cells[8].Value.ToString() == "R日期框")
                    {
                        returnStr += "string start" + col.PascalName + ",";
                        returnStr += "string end" + col.PascalName + ",";
                    }
                    else
                    {
                        returnStr += "string " + col.CamelName + ",";
                    }
                }
                else
                {

                    // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
                    if (row.Cells[0].Value.ToString() == "True" && string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());

                        returnStr += col.DataType.CSharpType + " " + col.CamelName + ",";
                    }
                }
            }
            returnStr = returnStr.Trim();
            if (returnStr.Length > 0)
                returnStr = returnStr.Substring(0, returnStr.Length - 1);
            return returnStr;
        }

        /// <summary>
        /// 得到where参数调用列表
        /// </summary>
        /// <returns></returns>
        public string GetWhereParasValueString()
        {
            string returnStr = "";
            foreach (DataGridViewRow row in gv_ColsWhere.Rows)
            {
                // 如果该控件用于显示,则转化成属性
                if (row.Cells[1].Value.ToString() == "True")
                {
                    IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                    if (row.Cells[8].Value.ToString() == "R日期框")
                    {
                        returnStr += "start" + col.PascalName + ",";
                        returnStr += "end" + col.PascalName + ",";
                    }
                    else
                    {
                        returnStr += col.CamelName + ",";
                    }
                }
                else
                {

                    // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
                    if (row.Cells[0].Value.ToString() == "True" && string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());

                        returnStr += col.CamelName + ",";
                    }
                }
            }
            returnStr = returnStr.Trim();
            if (returnStr.Length > 0)
                returnStr = returnStr.Substring(0, returnStr.Length - 1);
            return returnStr;
        }

        /// <summary>
        /// 得到wheresummary参数列表
        /// </summary>
        /// <returns></returns>
        public string GetWhereSummaryString()
        {
            string returnStr = "";
            foreach (DataGridViewRow row in gv_ColsWhere.Rows)
            {
                // 如果该控件用于显示,则转化成属性
                if (row.Cells[1].Value.ToString() == "True")
                {
                    IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
                    if (row.Cells[8].Value.ToString() == "R日期框")
                    {
                        returnStr += "    /// <param name=\"start" + col.PascalName + "\">" + col.Description + "</param>\r\n";
                        returnStr += "    /// <param name=\"end" + col.PascalName + "\">" + col.Description + "</param>\r\n";

                    }
                    else
                    {
                        returnStr += "    /// <param name=\"" + col.CamelName + "\">" + col.Description + "</param>\r\n";
                    }
                }
                else
                {

                    // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
                    if (row.Cells[0].Value.ToString() == "True" && string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());

                        returnStr += "    /// <param name=\"" + col.CamelName + "\">" + col.Description + "</param>\r\n";
                    }
                }
            }
            returnStr = returnStr.Trim();

            return returnStr;
        }

        public string getSqlString()
        {
            string sql = "SELECT ";

            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sql += txt_MainTableAlias.Text + "." + col.ColumnName + ",";
            }

            foreach (DataGridViewRow row in gv_Cols.Rows)
            {
                if (row.Cells["col_Select"].Value.ToString() == "True")
                {
                    if (row.Cells["col_IsCode"].Value != null && row.Cells["col_IsCode"].Value.ToString() == "True")
                    {
                        sql += "(" + string.Format(DataAccess.CodeSQL, row.Cells["col_Code"].Value.ToString(), row.Cells["col_TableAlias"].Value.ToString() + "." + row.Cells["col_Field"].Value.ToString()) + ")  As " + row.Cells["col_Alias"].Value.ToString() + ",";
                    }
                    else
                    {
                        sql += row.Cells["col_TableAlias"].Value.ToString() + "." + row.Cells["col_Field"].Value.ToString() + " As " + row.Cells["col_Alias"].Value.ToString() + ",";
                    }
                }
            }

            sql = sql.Substring(0, sql.Length - 1);

            sql += " FROM " + Tbl.TableName + " " + txt_MainTableAlias.Text + " ";

            foreach (DataGridViewRow row in gv_SubTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == "True")
                {
                    if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "")
                    {
                        sql += "\r\n                            " + row.Cells[1].Value.ToString().ToString() + " " + row.Cells[5].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    }
                    else
                    {
                        sql += "\r\n                            " + row.Cells[1].Value.ToString().ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    }
                }
            }

            sql += "\r\n                            WHERE 1=1 ";
            return sql;
        }

        public string getImportSqlString()
        {
            string sql = "SELECT ";

            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sql += txt_MainTableAlias.Text + "." + col.ColumnName + " As " + col.Description + ",";
            }

            foreach (DataGridViewRow row in gv_Cols.Rows)
            {
                if (row.Cells["col_Import"].Value.ToString() == "True")
                {
                    if (row.Cells["col_IsCode"].Value != null && row.Cells["col_IsCode"].Value.ToString() == "True")
                    {
                        sql += "(" + string.Format(DataAccess.CodeSQL, row.Cells["col_Code"].Value.ToString(), row.Cells["col_TableAlias"].Value.ToString() + "." + row.Cells["col_Field"].Value.ToString()) + ")  As " + row.Cells["col_Meaning"].Value.ToString() + ",";
                    }
                    else
                    {
                        sql += row.Cells["col_TableAlias"].Value.ToString() + "." + row.Cells["col_Field"].Value.ToString() + " As " + row.Cells["col_Meaning"].Value.ToString() + ",";
                    }
                }
            }

            sql = sql.Substring(0, sql.Length - 1);

            sql += " FROM " + Tbl.TableName + " " + txt_MainTableAlias.Text + " ";

            foreach (DataGridViewRow row in gv_SubTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == "True")
                {
                    if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "")
                    {
                        sql += "\r\n                            " + row.Cells[1].Value.ToString().ToString() + " " + row.Cells[5].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    }
                    else
                    {
                        sql += "\r\n                            " + row.Cells[1].Value.ToString().ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    }
                }
            }

            sql += "\r\n                            WHERE 1=1 ";
            return sql;
        }
        #endregion

        #region 列 列表排序方法

        private void gv_Cols_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks < 2) && (e.Button == MouseButtons.Left))
            {
                if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
                    gv_Cols.DoDragDrop(gv_Cols.Rows[e.RowIndex], DragDropEffects.Move);
            }
        }

        private void gv_Cols_DragDrop(object sender, DragEventArgs e)
        {
            MoveRow(gv_Cols, e);
        }

        private void gv_Cols_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectionIdx = e.RowIndex;

        }

        private void gv_Cols_SelectionChanged(object sender, EventArgs e)
        {

            SelectionChanged(gv_Cols);
        }

        private void gv_Cols_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void gv_Cols_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                gv_Cols.Sort(gv_Cols.Columns[0], ListSortDirection.Descending);
            }

            if (this.gv_Cols.CurrentRow != null && e.ColumnIndex == 7)
            {
                if (((DataGridViewCheckBoxCell)gv_Cols.CurrentRow.Cells[7]).Value.ToString() == "True")
                {
                    ((DataGridViewComboBoxCell)this.gv_Cols.CurrentRow.Cells[8]).DataSource = CodeTypeList;
                    ((DataGridViewComboBoxCell)this.gv_Cols.CurrentRow.Cells[8]).DisplayMember = "Meaning";
                    ((DataGridViewComboBoxCell)this.gv_Cols.CurrentRow.Cells[8]).ValueMember = "Flag";

                }
                else
                {
                    ((DataGridViewComboBoxCell)this.gv_Cols.CurrentRow.Cells[8]).Value = "";
                    // ((DataGridViewComboBoxCell)this.gv_Cols.CurrentRow.Cells[6]).Items.Clear();
                }
            }

        }
        #endregion

        #region 条件列表排序

        private void gv_ColsWhere_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectionIdx = e.RowIndex;
        }

        private void gv_ColsWhere_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks < 2) && (e.Button == MouseButtons.Left))
            {
                if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
                    gv_ColsWhere.DoDragDrop(gv_ColsWhere.Rows[e.RowIndex], DragDropEffects.Move);

            }
        }

        private void gv_ColsWhere_DragDrop(object sender, DragEventArgs e)
        {
            MoveRow(gv_ColsWhere, e);
        }

        private void gv_ColsWhere_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void gv_ColsWhere_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged(gv_ColsWhere);
        }
        #endregion

        #region 排序公共方法

        public void MoveRow(DataGridView gv, DragEventArgs e)
        {
            int idx = GetRowFromPoint(gv, e.X, e.Y);
            if (idx < 0) return;
            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                DataGridViewRow row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                gv.Rows.Remove(row);
                gv.Rows.Insert(idx, row);
                selectionIdx = idx;
            }
        }

        public void SelectionChanged(DataGridView gv)
        {
            if ((gv.Rows.Count > 0) && (gv.SelectedRows.Count > 0) && (gv.SelectedRows[0].Index != selectionIdx))
            {
                if (gv.Rows.Count <= selectionIdx)
                    selectionIdx = gv.Rows.Count - 1;
                gv.Rows[selectionIdx].Selected = true;
                gv.CurrentCell = gv.Rows[selectionIdx].Cells[0];
            }
        }

        private int GetRowFromPoint(DataGridView gv, int x, int y)
        {
            for (int i = 0; i < gv.RowCount; i++)
            {
                Rectangle rec = gv.GetRowDisplayRectangle(i, false);

                if (gv.RectangleToScreen(rec).Contains(x, y))
                    return i;
            }
            return -1;
        }
        #endregion

        private void btn_copy_Click(object sender, EventArgs e)
        {

        }




        private string GetewPascalName()
        {
            //去掉表名中的第一个 T
            string NewPascalName = "";
            if (Tbl.PascalName.IndexOf('T') == 0)
            {
                NewPascalName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }
            else { NewPascalName = Tbl.PascalName; }
            return NewPascalName;
        }



        public string Lower()
        {
            string str = GetewPascalName();
            string newStr = string.Empty;

            if (str.Length > 0)
            {
                newStr = str.Substring(0, 1).ToLower() + str.Substring(1);
            }
            return newStr;
        }


        public int getSelectCount()
        {
            int num = 0;
            foreach (DataGridViewRow row in gv_Cols.Rows)
            {
                if (row.Cells[0].Value.ToString() == "True")
                {
                    num++;
                }
            }
            return num;
        }
        public string getNewColumn(string oldColumn)
        {
            string newColumn = string.Empty;

            foreach (IColumn item in Tbl.Columns)
            {
                if (item.CamelName.ToUpper() == oldColumn.ToUpper())
                {
                    newColumn = OneStringLower(item.PascalName);
                }
            }
            return newColumn;
        }
        /// <summary>
        /// 返回单表主键
        /// </summary>
        /// <returns></returns>
        private string GetPrimary()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                returnstr = col.CamelName;
            }
            return returnstr;
        }


        public string OneStringLower(string colname)
        {
            string newcolname = "";
            newcolname = colname.Substring(0, 1).ToLower();
            newcolname += colname.Substring(1, colname.Length - 1);
            return newcolname;
        }

    }
}
