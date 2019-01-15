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
 

namespace Esint.TemplateCommon
{
    public partial class SelectLinkTable : Form
    {  
        private string ConnectString { get; set; }
        private ICodeBuilder DataAccess { get; set; }

        public string JoinType { get; set; }
        public string SubTableName { get; set; }
        public string FilterStr { get; set; }
        public string SubAlias { get; set; }
        public string OnWhere { get; set; }
        List<IDbTable> tbs;

        public Dictionary<string,string> Tables{
         
            set
            {
                foreach (string key in value.Keys)
                {
                    cbx_MasterTable.Items.Add(value[key] + "|" + key);
                }
            }
        }


        public SelectLinkTable(ICodeBuilder dataAccess, string connectString)
        {
            DataAccess = dataAccess;
            ConnectString = connectString;

            InitializeComponent();

            tbs = DataAccess.GetTableList(ConnectString);
            foreach (IDbTable tb in tbs)
            {
                gv_SubTable.Rows.Add(new object[] { tb.TableName,tb.TableDescription });
            }
            cbx_MasterTable.Items.Clear();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string errText = "";
            if (txt_BM.Text.Trim() == "")
            {
                errText += "子表别名不能为空!\r\n";
            }
            if (cbx_MasterTable.Text.Trim() == "")
            {
                errText += "关联主表不能为空!";
            }
            if (cbx_MasterCols.Text.Trim() == "")
            {
                errText += "主表字段不能为空!";
            }
            if (cbx_SubCols.Text.Trim() == "")
            {
                errText += "子表字段不能为空!";
            }
            if (comboBox2.Text.Trim() == "")
            {
                errText += "连接方式不能为空!";
            }
            if (errText.Trim() != "")
            {
                MessageBox.Show(errText);
                return;
            }

            OnWhere = "ON " + cbx_MasterTable.Text.Split('|')[1] + "." + cbx_MasterCols.Text + "= " + txt_BM.Text + "." + cbx_SubCols.Text;
            JoinType = comboBox2.Text.ToString();
            SubAlias = txt_BM.Text;
            if (!string.IsNullOrEmpty(txt_Filter.Text.Trim()))
                FilterStr = "(SELECT * FROM " + gv_SubTable.Rows[gv_SubTable.SelectedCells[0].RowIndex].Cells[0].EditedFormattedValue.ToString() + " Where " + txt_Filter.Text + ")";
            else
                FilterStr = "";
            this.Close();
        }

        private void cbx_MasterTable_SelectedIndexChanged(object sender, EventArgs e)
        {
           string selectValue = Convert.ToString(cbx_MasterTable.SelectedItem);
           string tableName = selectValue.Split('|')[0];
           IDbTable db = DataAccess.GetTableByTableName(ConnectString, tableName);
           cbx_MasterCols.DataSource = db.Columns;
           cbx_MasterCols.DisplayMember = "ColumnName";

        }

        private void gv_SubTable_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_SubTable.SelectedCells.Count>0)
            {
                SubTableName = gv_SubTable.Rows[gv_SubTable.SelectedCells[0].RowIndex].Cells[0].EditedFormattedValue.ToString();
                txt_BM.Text = SubTableName;
                IDbTable db = DataAccess.GetTableByTableName(ConnectString, SubTableName);
                cbx_SubCols.DataSource = db.Columns;
                cbx_SubCols.DisplayMember = "ColumnName";
            }
          
        }

       
        private void txt_TableName_TextChanged(object sender, EventArgs e)
        {
            List<IDbTable> ts = tbs.FindAll(delegate(IDbTable t) { return t.TableName.ToUpper().IndexOf(txt_TableName.Text.ToUpper()) != -1; });
            gv_SubTable.Rows.Clear();
            foreach (IDbTable tb in ts)
            {
                gv_SubTable.Rows.Add(new object[] { tb.TableName, tb.TableDescription });
            }
        }

        
    }
}
