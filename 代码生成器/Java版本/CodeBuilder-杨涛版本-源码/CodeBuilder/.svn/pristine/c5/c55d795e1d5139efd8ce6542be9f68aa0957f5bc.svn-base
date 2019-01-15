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

namespace Esint.Template.TemplateUnionQueries
{
    public partial class UnionQueries : Form, ITemplate
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
        public UnionQueries()
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
            txt_FileName.Text = String.Format(FileName, GetewPascalName());
            //
            // 设置事件事先选中
            //
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);

            //隐藏 "其他设置" TagPage
            tabControl1.TabPages.Remove(tabPage1);

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

            returnCode[0] = GetMapperXml();
            returnCode[1] = GetMapperJava();
            //returnCode[2] = GetAspxDesignerCode();
            //returnCode[3] = GetBLLCode();
            //returnCode[4] = GetPageAspxCsCode();
            return returnCode;
        }

        #region 生成 mybatis 代码

        public IReturnCode GetMapperXml()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();

            #region 生成代码区
            sb.AppendLine("<select id=\"select" + txt_FileName.Text + "\" resultType=\"java.util.Map\" parameterType=\"java.util.Map\">");
            sb.AppendLine("	<include refid=\"Base_Page_Begin\" />");
            sb.AppendLine(getSqlString());
            // 如果生成Where条件查询,则生成该部分代码
            if (this.cbx_IsWhere.Checked)
            {
                int i = 0;
                sb.AppendLine("		<where>");
                foreach (DataGridViewRow row in gv_ColsWhere.Rows)
                {
                    // 如果不显示,但选中了,判断是否己赋值,如己赋值,在SQL语句中拼上,没赋值,拼上属性
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());

                        if (DataAccess.DataBaseType == "ORACLE")
                        {
                            if (col.DataType.DbDataType.ToUpper() == "DATE")
                            {
                                sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                                sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = TO_DATE(#{" + OneStringLower(col.PascalName) + "},'YYYY-MM-DD HH24:MI:SS')");
                                sb.AppendLine("			</if>");
                            }
                            else if (col.DataType.DbDataType.ToUpper() == "NUMBER" || col.DataType.DbDataType.ToUpper() == "INTEGER")
                            {
                                sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                                sb.AppendLine("			 	 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                                sb.AppendLine("		    </if>");
                            }
                            else
                            {
                                sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                                sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                                sb.AppendLine("			</if>");
                            }
                        }
                        if (DataAccess.DataBaseType == "SQLSERVER")
                        {
                            if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "MONEY" || col.DataType.DbDataType.ToUpper() == "NUMERIC")
                            {
                                sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                                sb.AppendLine("			 	 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                                sb.AppendLine("		    </if>");
                            }
                            else
                            {
                                sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                                sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                                sb.AppendLine("			</if>");
                            }
                        }
                        if (DataAccess.DataBaseType == "MYSQL")
                        {
                            if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INTEGER" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "DOUBLE")
                            {
                                sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                                sb.AppendLine("			 	 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                                sb.AppendLine("		    </if>");
                            }
                            else
                            {
                                sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                                sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                                sb.AppendLine("			</if>");
                            }
                        }
                    }
                }
                sb.AppendLine("		</where>");
            }
            sb.AppendLine("	<include refid=\"Base_Page_End\" />");
            sb.AppendLine("</select>");
            #endregion

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = txt_FileName.Text + "Mapper.xml";
            returnCode.CodeType = "JAVA";
            return returnCode;
        }

        public IReturnCode GetMapperJava()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            #region 生成代码区

            sb.AppendLine("/**");
            sb.AppendLine("* 根据条件获取数据列表");
            sb.AppendLine("* ");
            sb.AppendLine("* @param params");
            sb.AppendLine("*            其中isPage 1分页 0不分页");
            sb.AppendLine("* @return");
            sb.AppendLine("* @throws Exception");
            sb.AppendLine("*/");
            sb.AppendLine("public List<Map<String, Object>> select" + txt_FileName.Text + "(Map<String, Object> params)");
            sb.AppendLine("		throws Exception;");

            #endregion

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = txt_FileName.Text + "Mapper.java";
            returnCode.CodeType = "JAVA";
            return returnCode;
        }

        #endregion


        //public void BuilderDALFunction(StringBuilder sb, string dbType)
        //{

        //    if (this.cbx_Page.Checked)
        //    {
        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  " + dbType + " DAL层 数据访问方法，请将下面方法复制到 " + Tbl.CamelName + "Data.cs 文件中使用 ");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  注意：不要复制到" + Tbl.CamelName + "Data.designer.cs中，不要复制本段！！！");
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
        //        sb.AppendLine("        ReturnTable returnTable = new ReturnTable();");
        //    }
        //    else
        //    {

        //        sb.AppendLine("//***************************************************************************************/");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  " + dbType + " DAL层 数据访问方法，请将下面方法复制到 " + Tbl.CamelName + "Data.cs 文件中使用 ");
        //        sb.AppendLine("//*                                                                                 ");
        //        sb.AppendLine("//*  注意：不要复制到" + Tbl.CamelName + "Data.designer.cs中，不要复制本段！！！");
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
        //    }

        //    sb.AppendLine("        DataQuery query = new DataQuery();");
        //    sb.AppendLine();
        //    sb.AppendLine("        query.SQLText = @\"" + getSqlString() + "\";");
        //    sb.AppendLine();
        //    foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //    {
        //        if (row.Cells[1].Value.ToString() == "True")
        //        {
        //            IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //            if (row.Cells[8].Value.ToString() == "R日期框")
        //            {
        //                if (dbType.ToUpper() == "SQLSERVER")
        //                {
        //                    sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=@Start" + col.PascalName + "\";");
        //                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
        //                    sb.AppendLine("        }");
        //                    sb.AppendLine();

        //                    sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=@End" + col.PascalName + "\";");
        //                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
        //                    sb.AppendLine("        }");
        //                    sb.AppendLine();
        //                }
        //                if (dbType.ToUpper() == "ORACLE")
        //                {
        //                    sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=to_date(:Start" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
        //                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
        //                    sb.AppendLine("        }");
        //                    sb.AppendLine();

        //                    sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
        //                    sb.AppendLine("        {");
        //                    sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=to_date(:End" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
        //                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
        //                    sb.AppendLine("        }");
        //                    sb.AppendLine();

        //                }
        //            }
        //            else
        //            {
        //                if (col.DataType.CSharpType == "Guid")
        //                {
        //                    sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
        //                }
        //                else if (col.DataType.CSharpType.IndexOf("?") != -1)
        //                {
        //                    sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
        //                }
        //                else
        //                {
        //                    sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
        //                }
        //                sb.AppendLine("        {");

        //                if (row.Cells[6].Value.ToString().ToLower() == "like")
        //                {
        //                    if (dbType.ToUpper() == "SQLSERVER")
        //                    {
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
        //                    }

        //                    if (dbType.ToUpper() == "ORACLE")
        //                    {
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
        //                    }
        //                }
        //                else
        //                {
        //                    if (dbType.ToUpper() == "SQLSERVER")
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
        //                    if (dbType.ToUpper() == "ORACLE")
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

        //                }

        //                if (dbType.ToUpper() == "SQLSERVER")
        //                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

        //                if (dbType.ToUpper() == "ORACLE")
        //                    sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");

        //                sb.AppendLine("        }");
        //                sb.AppendLine();
        //            }
        //        }
        //        else
        //        {
        //            if (row.Cells[0].Value.ToString() == "True")
        //            {
        //                IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //                if (string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
        //                {
        //                    if (col.DataType.CSharpType == "Guid")
        //                    {
        //                        sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
        //                    }
        //                    else if (col.DataType.CSharpType.IndexOf("?") != -1)
        //                    {
        //                        sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
        //                    }
        //                    else
        //                    {
        //                        sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
        //                    }
        //                    sb.AppendLine("        {");

        //                    if (row.Cells[6].Value.ToString().ToLower() == "like")
        //                    {
        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                        {
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
        //                        }

        //                        if (dbType.ToUpper() == "ORACLE")
        //                        {
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
        //                        if (dbType.ToUpper() == "ORACLE")
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

        //                    }

        //                    if (dbType.ToUpper() == "SQLSERVER")
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

        //                    if (dbType.ToUpper() == "ORACLE")
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");


        //                    sb.AppendLine("        }");
        //                }
        //                else
        //                {

        //                    if (row.Cells[6].Value.ToString().ToLower() == "like")
        //                    {
        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                        {
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
        //                        }

        //                        if (dbType.ToUpper() == "ORACLE")
        //                        {
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
        //                        if (DataAccess.DataBaseType == "ORACLE")
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

        //                    }

        //                    if (dbType.ToUpper() == "SQLSERVER")
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");

        //                    if (dbType.ToUpper() == "ORACLE")
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");



        //                }

        //            }
        //        }
        //    }
        //    sb.AppendLine("        query.OrderByString = orderStr;");
        //    sb.AppendLine();
        //    if (this.cbx_Page.Checked)
        //    {
        //        sb.AppendLine("        query.PageView = pageView;      //分页");

        //        sb.AppendLine("        // 排序");
        //        sb.AppendLine();
        //        sb.AppendLine("        returnTable.Table = BaseData.ExecuteDataTable(query);");
        //        sb.AppendLine("        returnTable.PageInfo = query.PageView;");
        //        sb.AppendLine("        return returnTable;");
        //    }
        //    else
        //        sb.AppendLine("       return BaseData.ExecuteDataTable(query);");

        //    sb.AppendLine("     }");


        //    if (cbx_IsImp.Checked)
        //    {
        //        sb.AppendLine("    /// <summary>");
        //        sb.AppendLine("    /// 功能说明: 根据条件查询 " + Tbl.TableDescription + " 列表，返回DataTable");
        //        sb.AppendLine("    /// 作    者: " + OperName);
        //        sb.AppendLine("    /// 日    期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
        //        sb.AppendLine("    /// </summary>");
        //        sb.AppendLine("    /// <param name=\"orderStr\">排序字段</param>");
        //        sb.AppendLine("    " + GetWhereSummaryString());
        //        sb.AppendLine("    /// <returns> " + Tbl.TableDescription + " DataTable结果集</returns>");
        //        sb.AppendLine("    public DataTable Get" + Tbl.PascalName + "ImportTable(int rowNum,string orderStr, " + GetWhereParasString() + ")");
        //        sb.AppendLine("    {");

        //        sb.AppendLine("        DataQuery query = new DataQuery();");

        //        sb.AppendLine("        PageSplit pageView = new PageSplit();");
        //        sb.AppendLine("        pageView.PageIndex = 1;");
        //        sb.AppendLine("        pageView.PageSize = rowNum;");

        //        sb.AppendLine();
        //        sb.AppendLine("        query.SQLText = @\"" + getImportSqlString() + "\";");
        //        sb.AppendLine();
        //        foreach (DataGridViewRow row in gv_ColsWhere.Rows)
        //        {
        //            if (row.Cells[1].Value.ToString() == "True")
        //            {
        //                IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //                if (row.Cells[8].Value.ToString() == "R日期框")
        //                {
        //                    if (dbType.ToUpper() == "SQLSERVER")
        //                    {
        //                        sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
        //                        sb.AppendLine("        {");
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=@Start" + col.PascalName + "\";");
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
        //                        sb.AppendLine("        }");
        //                        sb.AppendLine();

        //                        sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
        //                        sb.AppendLine("        {");
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=@End" + col.PascalName + "\";");
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
        //                        sb.AppendLine("        }");
        //                        sb.AppendLine();
        //                    }
        //                    if (dbType.ToUpper() == "ORACLE")
        //                    {
        //                        sb.AppendLine("        if (!string.IsNullOrEmpty(start" + col.PascalName + "))");
        //                        sb.AppendLine("        {");
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + ">=to_date(:Start" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":Start" + col.PascalName + "\", start" + col.PascalName + ")); ");
        //                        sb.AppendLine("        }");
        //                        sb.AppendLine();

        //                        sb.AppendLine("        if (!string.IsNullOrEmpty(end" + col.PascalName + "))");
        //                        sb.AppendLine("        {");
        //                        sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + "<=to_date(:End" + col.PascalName + ",'yyyy-mm-dd hh24:mi:ss')\";");
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":End" + col.PascalName + "\", end" + col.PascalName + "+\" 23:59:59\")); ");
        //                        sb.AppendLine("        }");
        //                        sb.AppendLine();

        //                    }
        //                }
        //                else
        //                {
        //                    if (col.DataType.CSharpType == "Guid")
        //                    {
        //                        sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
        //                    }
        //                    else if (col.DataType.CSharpType.IndexOf("?") != -1)
        //                    {
        //                        sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
        //                    }
        //                    else
        //                    {
        //                        sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
        //                    }
        //                    sb.AppendLine("        {");

        //                    if (row.Cells[6].Value.ToString().ToLower() == "like")
        //                    {
        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                        {
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
        //                        }

        //                        if (dbType.ToUpper() == "ORACLE")
        //                        {
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
        //                        if (dbType.ToUpper() == "ORACLE")
        //                            sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

        //                    }

        //                    if (dbType.ToUpper() == "SQLSERVER")
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

        //                    if (dbType.ToUpper() == "ORACLE")
        //                        sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");

        //                    sb.AppendLine("        }");
        //                    sb.AppendLine();
        //                }
        //            }
        //            else
        //            {
        //                if (row.Cells[0].Value.ToString() == "True")
        //                {
        //                    IColumn col = GetColByName(row.Cells[5].Value.ToString(), row.Cells[3].Value.ToString());
        //                    if (string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
        //                    {
        //                        if (col.DataType.CSharpType == "Guid")
        //                        {
        //                            sb.AppendLine("        if (Guid.Empty!=" + col.CamelName + ")");
        //                        }
        //                        else if (col.DataType.CSharpType.IndexOf("?") != -1)
        //                        {
        //                            sb.AppendLine("        if (" + col.CamelName + ".HasValue)");
        //                        }
        //                        else
        //                        {
        //                            sb.AppendLine("        if (!string.IsNullOrEmpty(" + col.CamelName + "))");
        //                        }
        //                        sb.AppendLine("        {");

        //                        if (row.Cells[6].Value.ToString().ToLower() == "like")
        //                        {
        //                            if (dbType.ToUpper() == "SQLSERVER")
        //                            {
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
        //                            }

        //                            if (dbType.ToUpper() == "ORACLE")
        //                            {
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (dbType.ToUpper() == "SQLSERVER")
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
        //                            if (dbType.ToUpper() == "ORACLE")
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

        //                        }

        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", " + col.CamelName + ")); ");

        //                        if (dbType.ToUpper() == "ORACLE")
        //                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", " + col.CamelName + ")); ");


        //                        sb.AppendLine("        }");
        //                    }
        //                    else
        //                    {

        //                        if (row.Cells[6].Value.ToString().ToLower() == "like")
        //                        {
        //                            if (dbType.ToUpper() == "SQLSERVER")
        //                            {
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'+@" + col.PascalName + "+'%'\";");
        //                            }

        //                            if (dbType.ToUpper() == "ORACLE")
        //                            {
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + " " + row.Cells[6].Value.ToString() + " '%'||:" + col.PascalName + "||'%'\";");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (dbType.ToUpper() == "SQLSERVER")
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " @" + col.PascalName + "\";");
        //                            if (DataAccess.DataBaseType == "ORACLE")
        //                                sb.AppendLine("            query.SQLText +=\" And " + row.Cells[4].Value.ToString() + "." + col.ColumnName.ToUpper() + row.Cells[6].Value.ToString() + " :" + col.PascalName + "\";");

        //                        }

        //                        if (dbType.ToUpper() == "SQLSERVER")
        //                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\"@" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");

        //                        if (dbType.ToUpper() == "ORACLE")
        //                            sb.AppendLine("            query.WhereParameters.Add(new WhereParameter(\":" + col.PascalName + "\", '" + row.Cells[7].Value.ToString() + "')); ");



        //                    }

        //                }
        //            }
        //        }
        //        sb.AppendLine("        query.OrderByString = orderStr;");
        //        sb.AppendLine();
        //        if (this.cbx_Page.Checked)
        //        {
        //            sb.AppendLine("        query.PageView = pageView;      //分页");

        //            sb.AppendLine("        // 排序");
        //            sb.AppendLine();
        //            sb.AppendLine("        return BaseData.ExecuteDataTable(query);");
        //        }
        //        else
        //            sb.AppendLine("       return BaseData.ExecuteDataTable(query);");

        //        sb.AppendLine("     }");

        //    }

        //}


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
            string sql = "		SELECT ";

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

            sql += "\r\n		FROM " + Tbl.TableName + " " + txt_MainTableAlias.Text + " ";

            foreach (DataGridViewRow row in gv_SubTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == "True")
                {
                    if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "")
                    {
                        sql += "\r\n			" + row.Cells[1].Value.ToString().ToString() + " " + row.Cells[5].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    }
                    else
                    {
                        sql += "\r\n			" + row.Cells[1].Value.ToString().ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    }
                }
            }

            sql += "\r\n		WHERE 1=1 ";
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

        /// <summary>
        /// 将字段的首字母变成小写，其他驼峰命名规则
        /// 杨涛
        /// </summary>
        /// <param name="colname"></param>
        /// <returns></returns>
        public string OneStringLower(string colname)
        {
            string newcolname = "";
            newcolname = colname.Substring(0, 1).ToLower();
            newcolname += colname.Substring(1, colname.Length - 1);
            return newcolname;
        }

        private void gv_ColsWhere_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
