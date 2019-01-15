using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Esint.CodeBuilder.InterFace;
using System.Reflection;
 
/*********************************
 * 
 *   模块名称: 数据表选择窗口
 *   功    能: 选择所需的数据表,返回数据表列表
 *   作    者: 刘伟通
 * 
 * *******************************/
namespace Esint.TemplateCommon
{
    public partial class SelectTable : Form
    {
        List<IDbTable> tables; // 全部数据表列表

        /// <summary>
        /// 构造时,初始化窗口
        /// </summary>
        /// <param name="dataAccess"></param>
        /// <param name="connectString"></param>
        public SelectTable(ICodeBuilder dataAccess, string connectString)
        {
            DataAccess = dataAccess;
            ConnectString = connectString;

            InitializeComponent();
            tables = DataAccess.GetTableList(ConnectString);
           BindGrid(tables);
        }
        // 数据库连接字符串
        private string ConnectString { get; set; }

        // 数据访问对象
        private ICodeBuilder DataAccess { get; set; }

        // 返回的数据表 列表
        public List<IDbTable> Tables = new List<IDbTable>();

        /// <summary>
        /// 确定按钮单击事件,返回选中的数据表列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gv_SubTable.Rows)
            {
                if (row.Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    IDbTable dbTable = DataAccess.GetTableByTableName(ConnectString, row.Cells[1].EditedFormattedValue.ToString());
                    Tables.Add(dbTable);
                }
            }
            this.Close();
        }

        /// <summary>
        /// 取消按钮,关闭当前对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 过滤文本发生改变时,过滤可供选择的表窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_TableName_TextChanged(object sender, EventArgs e)
        {
            List<IDbTable> subtables = tables.FindAll(delegate(IDbTable table) { return table.TableName.ToUpper().IndexOf(txt_TableName.Text.ToUpper()) != -1; });
            BindGrid(subtables);
        }

        /// <summary>
        /// 绑定表格选择列表
        /// </summary>
        /// <param name="tbs"></param>
        public void BindGrid(List<IDbTable> tbs)
        {
            gv_SubTable.Rows.Clear();
            foreach (IDbTable tb in tbs)
            {
                gv_SubTable.Rows.Add(new object[] { false,tb.TableName,tb.TableDescription });
            }
        }
    }
}
