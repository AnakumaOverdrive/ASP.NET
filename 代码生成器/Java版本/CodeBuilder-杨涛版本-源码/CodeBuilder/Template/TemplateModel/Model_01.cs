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
using System.Reflection;

namespace Esint.Template.Model
{
    /// <summary>
    /// 模板生成页
    /// </summary>
    public partial class Model_01 : Form, ITemplate
    {
        const string Ver = "1.0";                  // 模板版本号

        public IDbTable Tbl { get; set; }          //要生成的主表
        public string NameSpace { get; set; }      //命名空间
        public string FileName { get; set; }       //文件名
        public bool IsPackage { get; set; }        //是否批量生成
        public string OperName { get; set; }       //操作人姓名
        public string ConnectString { get; set; }  //数据库连接字串
        public ICodeBuilder DataAccess { get; set; }//数据库访问对象
        public List<IDbTable> Tbls { get; set; }    //需要多表时，表列表
  
        public Model_01()
        {
            InitializeComponent();
            gv_SubTable.AutoGenerateColumns = false;
         
        }

        public IReturnCode[] GetCode()
        {
            // 如果是批量生成，则不显示对话框，只生成
            if (!IsPackage)
            {
                Initi();
                this.ShowDialog();
            }

            IReturnCode[] returnCode = new IReturnCode[2];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".Designer.cs", Tbl.PascalName);
            returnCode[0].CodeText = CreateModelDesigner();
            returnCode[0].CodeType = "C#";

            returnCode[1] = new ReturnCode();
            returnCode[1].FileName = String.Format(FileName + ".cs", Tbl.PascalName);
            returnCode[1].CodeText = CreateModel();
            returnCode[1].CodeType = "C#";
            return returnCode;
        }

        public void Initi()
        {
            if (DataAccess == null) MessageBox.Show("error");
            Tbls =  DataAccess.GetSubTables(Tbl,ConnectString);
            foreach (IDbTable dbtable in Tbls)
            {
               gv_SubTable.Rows.Add(new object[] {false, dbtable.TableName, dbtable.TableDescription });
            }

            List<IDbTable> tbList = DataAccess.GetTableList(ConnectString);
            cbx_BaseModel.Items.Add("BaseModel");
            foreach (IDbTable db in tbList)
            {
                cbx_BaseModel.Items.Add(db.PascalName+"Info");
            }
            cbx_BaseModel.Text = "BaseModel";
        }

        public StringBuilder GetAspxCode()
        {
            return new StringBuilder();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private StringBuilder CreateModelDesigner()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Esint.Common;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 文件说明: " + Tbl.TableDescription + "信息实体");
            sb.AppendLine("    /// 作    者: " + this.OperName);
            sb.AppendLine("    /// 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 生成模板: Esint.Template.Model.Model_01 版");
            sb.AppendLine("    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！");
            sb.AppendLine("    /// </summary>");
            if(cbx_BaseModel.Text.Trim()=="")
            sb.AppendLine("    public partial class " + Tbl.PascalName + "Info : BaseModel");
            else
                sb.AppendLine("    public partial class " + Tbl.PascalName + "Info : " + cbx_BaseModel.Text);
           
            sb.AppendLine("    {");
            foreach (IColumn col in Tbl.Columns)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine("        /// " + col.Description);
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName + " { get; set; }");
                sb.AppendLine(" ");
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }

        private StringBuilder CreateModel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Esint.Common;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 文件说明: " + Tbl.TableDescription + "信息实体");
            sb.AppendLine("    /// 作    者: " + this.OperName);
            sb.AppendLine("    /// 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 生成模板: Esint.Template.Model.Model_01 版");
            sb.AppendLine("    /// 修改说明：");
            sb.AppendLine("    /// </summary>");
            if (cbx_BaseModel.Text.Trim() == "")
            sb.AppendLine("    public partial class " + Tbl.PascalName + "Info : BaseModel");
            else
   sb.AppendLine("    public partial class " + Tbl.PascalName + "Info : " + cbx_BaseModel.Text);
         
            
            sb.AppendLine("    {");

            // 如果不是批量生成，则根据选择生成相关属性
            if (!IsPackage)
            {
                foreach (DataGridViewRow row in gv_SubTable.Rows)
                {
                    if (row.Cells[0].EditedFormattedValue.ToString() == "True")
                    {
                        IDbTable subTable = Tbls.Find(delegate(IDbTable s) { return s.TableName == row.Cells[1].EditedFormattedValue.ToString(); });

                        sb.AppendLine("        // <summary>");
                        sb.AppendLine("        // " + subTable.TableDescription);
                        sb.AppendLine("        // </summary>");
                        sb.AppendLine("        private List<" + subTable.PascalName + "Info> _" + subTable.CamelName + ";");
                        sb.AppendLine("        public List<" + subTable.PascalName + "Info> " + subTable.PascalName + "List");
                        sb.AppendLine("        {");
                        sb.AppendLine("            get");
                        sb.AppendLine("            {");
                        sb.AppendLine("                if (_" + subTable.CamelName + " == null)");
                        sb.AppendLine("                   _" + subTable.CamelName + " = new List<" + subTable.PascalName + "Info>();");
                        sb.AppendLine("                return _" + subTable.CamelName + ";");
                        sb.AppendLine("            }");
                        sb.AppendLine("            set");
                        sb.AppendLine("            {");
                        sb.AppendLine("                _" + subTable.CamelName + " = value;");
                        sb.AppendLine("            }");
                        sb.AppendLine("        }");
                        sb.AppendLine();

                    }
                }
            }
            sb.AppendLine("    ");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }

        private void btn_AddTable_Click(object sender, EventArgs e)
        {

            Esint.TemplateCommon.SelectTable select_Table_Form = new Esint.TemplateCommon.SelectTable(DataAccess,ConnectString);
         
            select_Table_Form.ShowDialog();

            foreach (IDbTable dbtable in select_Table_Form.Tables)
            {
                Tbls.Add(dbtable);
                gv_SubTable.Rows.Add(new object[] { true,dbtable.TableName,dbtable.TableDescription });
            }
           
        }
    }
}
