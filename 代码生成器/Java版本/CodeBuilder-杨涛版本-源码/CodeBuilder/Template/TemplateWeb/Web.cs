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
    public partial class Web : Form, ITemplate
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

        int selectionIdx = 0;

        #region 窗口控制
        public Web()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetUIArgs();
            this.Close();
        }
        private void SetUIArgs()
        {
            foreach (DataGridViewRow row in gv_Setting.Rows)
            {
                if (!row.IsNewRow)
                {
                    IColumn col = Tbl.Columns.Find(delegate(IColumn tcol) { return tcol.ColumnName == row.Cells[0].Value.ToString(); });

                    col.ControlProperty.ControlType = row.Cells[3].Value.ToString();

                    if (Convert.ToBoolean(row.Cells[5].EditedFormattedValue))
                        col.ControlProperty.IsEnabledNull = true;
                    else
                        col.ControlProperty.IsEnabledNull = false;
                    //
                    // 设置列是否可见
                    //
                    if (Convert.ToBoolean(row.Cells[1].EditedFormattedValue))
                        col.ControlProperty.IsVisible = true;
                    else
                        col.ControlProperty.IsVisible = false;

                    col.ControlProperty.Tag = ((DataGridViewComboBoxCell)row.Cells[4]).Value.ToString();
                    col.Description = row.Cells[2].Value.ToString();
                }
            }

            WebCols = cbx_Cols.SelectedIndex + 1;
        }

        /// <summary>
        /// 初始化设置窗口
        /// </summary>
        public void Initi()
        {
            if (Tbl == null)
            {
                MessageBox.Show("没有获取到数据表！", "错误");
                return;
            }
            cbx_Cols.SelectedIndex = 0;
            int i = 0;
            foreach (IColumn col in Tbl.Columns)
            {
                string controlType = "";
                if (col.DataType.CSharpType == "DateTime" || col.DataType.CSharpType == "DateTime?")
                    controlType = "R日期框";
                else if (col.DataType.CSharpType == "bool")
                    controlType = "F复选框";
                else
                    controlType = "W文本框";

                gv_Setting.Rows.Add(new object[] { col.ColumnName, false, col.Description, controlType, "", false });

                if (col.IsPrimaryKey)
                {
                    gv_Setting.Rows[i].Cells[1].Value = false;
                }
                i++;
            }
            txt_ControlName.Text = String.Format(FileName, Tbl.PascalName);
            this.ShowDialog();
        }


        private void gv_Setting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != -1 && !gv_Setting.Rows[e.RowIndex].IsNewRow && gv_Setting.Rows[e.RowIndex].Cells[3].Value.ToString() == "X下拉框")
            {

                ((DataGridViewComboBoxCell)this.gv_Setting.CurrentRow.Cells[4]).DataSource = CodeTypeList;
                ((DataGridViewComboBoxCell)this.gv_Setting.CurrentRow.Cells[4]).DisplayMember = "Meaning";
                ((DataGridViewComboBoxCell)this.gv_Setting.CurrentRow.Cells[4]).ValueMember = "Flag";

            }
            if (e.ColumnIndex == 1)
            {
                gv_Setting.Sort(gv_Setting.Columns[1], ListSortDirection.Descending);
            }
            if (Tbl != null)
            {
                SetUIArgs();
                webBrowser1.DocumentText = GetPrewHtml();
            }
        }

        #endregion

        #region  样式设置

        int WebCols;           //生成的列数

        string textBoxCss = "TextBox"; //W文本框样式

        string mustTextBoxCss = "MustTextBox"; //必填项W文本框样式

        string tb_Form = "tb_form"; //表单样式

        string td_label = "td_Label"; //B标签单元格样式

        string td_input = "td_Input"; //输入域单元格样式

        string td_inputW = "td_InputW"; //输入域单元格样式

        string td_MaxInput = "td_MaxInput"; // 跨列输入域样式

        string dropDownListCss = "DropDownList"; //下拉列表样式

        string MustdropDownList = "MustDropDownList"; //必填下拉列表样式

        string checkBoxCss = "CheckBoxCss"; //F复选框样式

        string mustCheckBoxCss = "MustCheckBoxCss"; // 必填F复选框样式

        string requestCss = "requestCss"; //必填提示符样式

        #endregion

        public IReturnCode[] GetCode()
        {
            IReturnCode[] returnCode = new IReturnCode[4];
            Initi(); //初始化设置窗口
            returnCode[0] = GetAspxCode();
            returnCode[1] = GetAspxcsCode();
            returnCode[2] = GetAspxDesignerCode();
            returnCode[3] = GetAspxPageCsCode();
            return returnCode;
        }

        #region 生成前台页面

        public IReturnCode GetAspxCode()
        {

            StringBuilder sb = new StringBuilder();

            #region 生成引用区
            sb.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + txt_ControlName.Text + ".ascx.cs\" Inherits=\"" + string.Format(NameSpace, DataAccess.AppName) + "." + txt_ControlName.Text + "\" %>");
            sb.AppendLine();
            sb.AppendLine("<!-- 样式引用 -->");
            sb.AppendLine("<link href=\"../Css/Common.css\" rel=\"stylesheet\" type=\"text/css\" />");
            sb.AppendLine();
            sb.AppendLine("<!-- 脚本引用 -->");

            sb.AppendLine("<script src=\"../Js/validate.js\" type=\"text/javascript\"></script>");
            if (HasControl(Tbl, "R日期框"))
            {
                sb.AppendLine("<script src=\"../Js/calendar.js\" type=\"text/javascript\"></script>");
            }
            sb.AppendLine();
            #endregion

            #region 生成前台验证代码

            sb.AppendLine("<!-- 验证脚本开始 -->");
            sb.AppendLine("<script language=\"javascript\" type=\"text/javascript\">");
            sb.AppendLine("    function chkform_" + Tbl.CamelName + "(){");
            sb.AppendLine("        var alert_msg=\"\";");
            sb.AppendLine("        var istrue=true;");
            foreach(DataGridViewRow row in gv_Setting.Rows)
            {
                if (Convert.ToBoolean(row.Cells[1].EditedFormattedValue))
                {
                    IColumn col = Tbl.Columns.Find(delegate(IColumn tcol) { return tcol.ColumnName == row.Cells[0].Value.ToString(); });

                    if ((col.ControlProperty.ControlType == "W文本框" || col.ControlProperty.ControlType == "X下拉框" || col.ControlProperty.ControlType == "R日期框") && col.ControlProperty.IsEnabledNull)
                    {
                        sb.AppendLine("        if(Require(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\"))");
                        sb.AppendLine("        {");
                        sb.AppendLine("            alert_msg += \"" + col.Description + "不能为空。\";");
                        sb.AppendLine("            istrue = false;");
                        sb.AppendLine("        }");

                    }
                    if (col.ControlProperty.IsVisible && col.ControlProperty.ControlType == "D多行文本框")
                    { 
                    
                       sb.AppendLine("        if(MaxLen(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\","+col.ColumnLength+"))");
                        sb.AppendLine("        {");
                        sb.AppendLine("            alert_msg += \"" + col.Description + "只能输入"+col.ColumnLength+"个字符。\";");
                        sb.AppendLine("            istrue = false;");
                        sb.AppendLine("        }");
                    
                    }
                    if (col.ControlProperty.IsVisible && col.ControlProperty.ControlType == "R日期框")
                    {
                        sb.AppendLine("        if(IsDate(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\"))");
                        sb.AppendLine("        {");
                        sb.AppendLine("            alert_msg += \"" + col.Description + "应输入正确的日期。\";");
                        sb.AppendLine("            istrue = false;");
                        sb.AppendLine("        }");
                    }
                    if (col.ControlProperty.IsVisible && col.DataType.CSharpType.ToUpper().Replace("?", "") == "INT")
                    {
                        sb.AppendLine("        if(IsInteger(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\"))");
                        sb.AppendLine("        {");
                        sb.AppendLine("            alert_msg += \"" + col.Description + "应输入整数。\";");
                        sb.AppendLine("            istrue = false;");
                        sb.AppendLine("        }");
                    }
                    if (col.ControlProperty.IsVisible && col.DataType.CSharpType.ToUpper().Replace("?", "") == "DOUBLE")
                    {
                        sb.AppendLine("        if(IsNumber(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\"))");
                        sb.AppendLine("        {");
                        sb.AppendLine("            alert_msg += \"" + col.Description + "应输入正确的数字。\";");
                        sb.AppendLine("            istrue = false;");
                        sb.AppendLine("        }");
                    }
                }
            }

            sb.AppendLine("        if(istrue)");
            sb.AppendLine("        {");
            sb.AppendLine("            return true;");
            sb.AppendLine("        }");
            sb.AppendLine("        else");
            sb.AppendLine("        {");
            sb.AppendLine("            alert(alert_msg);");
            sb.AppendLine("            return false;");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("</script>");
            #endregion

            #region 生成表单区

            sb.AppendLine("<table class=\"" + tb_Form + "\">");

    

            int i = 1, j = 0;
            foreach (DataGridViewRow row in gv_Setting.Rows)
            {
                int x = 0;
                if (Convert.ToBoolean(row.Cells[1].EditedFormattedValue))
                {
                    IColumn col = Tbl.Columns.Find(delegate(IColumn tcol) { return tcol.ColumnName == row.Cells[0].Value.ToString(); });
                    if (i == 1)
                        sb.AppendLine("        <tr>");
                    sb.AppendLine("            <td class=\"" + td_label + "\">" + col.Description + "：</td>");

                    if (row.Cells[6].FormattedValue.ToString() == "一列")
                        x= 1;
                    if (row.Cells[6].FormattedValue.ToString() == "二列")
                        x= 2;
                    if (row.Cells[6].FormattedValue.ToString() == "三列")
                        x= 3;
                    if (x==0)
                        sb.Append("            <td class=\"" + td_input + "\">");
                    else
                        sb.Append("            <td class=\"" + td_input + "\" colspan=\""+(x*2+1)+"\">");
                    //判断控件;
                    if (col.ControlProperty.ControlType == "W文本框")
                    {
                        string maxlenSTr = null;
                        if (col.ColumnLength != null)
                        {
                            maxlenSTr = string.Format("MaxLength=\"" + col.ColumnLength + "\"");
                        }
                        sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" " + maxlenSTr + " CssClass=\"" + (col.ControlProperty.IsEnabledNull ? mustTextBoxCss : textBoxCss) + "\" runat=\"server\"></asp:TextBox>");
                    }
                    if (col.ControlProperty.ControlType == "R日期框")
                        sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" MaxLength=\"10\" CssClass=\"" + (col.ControlProperty.IsEnabledNull ? mustTextBoxCss : textBoxCss) + "\"  onFocus=\"calendar()\" runat=\"server\"></asp:TextBox>");
                    if (col.ControlProperty.ControlType == "X下拉框")
                        sb.Append("<asp:DropDownList ID=\"drp_" + col.PascalName + "\" runat=\"server\" CssClass=\"" + (col.ControlProperty.IsEnabledNull ? MustdropDownList : dropDownListCss) + "\" ></asp:DropDownList>");
                    if (col.ControlProperty.ControlType == "F复选框")
                        sb.Append("<asp:CheckBox ID=\"cbx_" + col.PascalName + "\" Text=\"" + col.Description + "\" CssClass=\"" + (col.ControlProperty.IsEnabledNull ? mustCheckBoxCss : checkBoxCss) + "\" runat=\"server\" />");
                    if (col.ControlProperty.ControlType == "Y隐藏域")
                        sb.Append(" <asp:HiddenField ID=\"hdn_"+col.PascalName+"\" runat=\"server\" />");

                    if (col.ControlProperty.ControlType == "D多行文本框")
                    {
                        sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" runat=\"server\"  CssClass=\"" + (col.ControlProperty.IsEnabledNull ? mustTextBoxCss : textBoxCss) + "\" TextMode=\"MultiLine\" ></asp:TextBox>");
                    }
                    
                    //控件为B标签
                    if (col.ControlProperty.ControlType == "B标签")
                        sb.Append("<asp:Label ID=\"lbl_" + col.PascalName + "\" runat=\"server\"></asp:Label>");
                    ///
                    if (col.ControlProperty.ControlType != "B标签")
                    {
                        if (col.ControlProperty.IsEnabledNull)
                            sb.Append("<span class=\"" + requestCss + "\"></span>");
                    }
                    sb.AppendLine("</td>");

                    i = i + x;

                    if (i >= WebCols)
                    {
                        sb.AppendLine("        </tr>");
                        i = 1;
                    }
                    else
                        i++;

                    j++;

                }
            }

            if (j % WebCols != 0)
            {
                for (int x = 0; x < (WebCols -j % WebCols); x++)
                {
                    sb.AppendLine("            <td class=\"" + td_label + "\"> </td>");
                    sb.AppendLine("            <td class=\"" + td_input + "\"></td>");
                }
                sb.AppendLine("        </tr>");
            }
            sb.AppendLine("</table>");

            #endregion

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format(FileName + ".ascx", Tbl.PascalName);
            returnCode.CodeType = "HTML";
            return returnCode;

        }

      

        private bool HasControl(IDbTable Tbl, string p)
        {
            return true;
        }

        #endregion

        #region 生成前面页CS代码


        public IReturnCode GetAspxcsCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Web.UI;");
            sb.AppendLine("using System.Web.UI.WebControls;");
            sb.AppendLine("using Esint." + AppName + ".BLL;");
            sb.AppendLine("using Esint." + AppName + ".Model;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("using Esint.Common;");
            sb.AppendLine("using Esint.Common.BLL;");
            sb.AppendLine("using Esint.Common.Web;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称： " + Tbl.TableDescription + "表单控件");
            sb.AppendLine("    /// 作    者：" + OperName);
            sb.AppendLine("    /// 日    期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 修改日期：");
            sb.AppendLine("    /// 修 改 人：");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + txt_ControlName.Text + ": BaseUserControl");
            sb.AppendLine("    {");
            sb.AppendLine("");
            sb.AppendLine("       #region 控件属性区");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                if (col.DataType.CSharpType == "Guid")
                {
                    sb.AppendLine("        ///<summary>");
                    sb.AppendLine("        ///" + col.Description + "");
                    sb.AppendLine("        ///<summary>");
                    sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {return ViewState[\"" + col.PascalName + "\"] == null ? Guid.Empty : (Guid)ViewState[\"" + col.PascalName + "\"]; }");
                    sb.AppendLine("            set { ViewState[\"" + col.PascalName + "\"] = value; }");
                    sb.AppendLine("        }");
                }
                else
                {
                    sb.AppendLine("        ///<summary>");
                    sb.AppendLine("        ///" + col.Description + "");
                    sb.AppendLine("        ///<summary>");
                    sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get { return (" + col.DataType.CSharpType + ")ViewState[\"" + col.PascalName + "\"]; }");
                    sb.AppendLine("            set { ViewState[\"" + col.PascalName + "\"] = value; }");
                    sb.AppendLine("        }");
                }
            }

            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 页面加载");
            sb.AppendLine();
            sb.AppendLine("        protected void Page_Init(object sender, EventArgs e)");
            sb.AppendLine("        { ");
            sb.AppendLine("            if (!Page.IsPostBack)");
            sb.AppendLine("            {");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.ControlType == "X下拉框")
                {
                    sb.AppendLine();
                    sb.AppendLine("                //" + col.Description + " drp绑定字典表");
                    sb.AppendLine("                drp_" + col.PascalName + ".CodeBinding(\"" + col.ControlProperty.Tag + "\");");
                }
            }
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 实体--控件值转换区");
            sb.AppendLine();
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        ///" + Tbl.TableDescription);
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        public " + Tbl.PascalName + "Info " + Tbl.PascalName);
            sb.AppendLine("        {  ");
            sb.AppendLine("            get");
            sb.AppendLine("            {");

            #region 生成Get属性

            sb.AppendLine("                //定义学生信息表对象实体");
            sb.AppendLine("                " + Tbl.PascalName + "Info " + Tbl.CamelName + " = new " + Tbl.PascalName + "Info();");
            sb.AppendLine();
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("                //" + col.Description);
                sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = " + col.PascalName + ";");
                sb.AppendLine();
            }

            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {
                        sb.AppendLine();
                        sb.AppendLine("                // " + col.Description);
                        if (col.DataType.CSharpType == "string")
                            sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + ".Trim();");
                        else if (col.DataType.CSharpType.ToUpper() == "GUID")
                            sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = new Guid(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + ".Trim());");

                        else
                        {
                            sb.AppendLine("                if (!string.IsNullOrEmpty(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + ".Trim()))");
                 
                            sb.AppendLine("                    " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + ".Trim());");
                        }
                    }
                }
            }
            sb.AppendLine();
            sb.AppendLine("                return " + Tbl.CamelName + ";");

            #endregion

            sb.AppendLine("            }");
            sb.AppendLine();
            sb.AppendLine("            set");
            sb.AppendLine("            {");
            sb.AppendLine("                if (value == null)");
            sb.AppendLine("                {");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("                    //" + col.Description);
                if (col.DataType.CSharpType == "Guid")
                    sb.Append("                    " + col.PascalName + " = Guid.Empty;");
                else
                    sb.AppendLine("                    " + col.PascalName + " = null;");
                sb.AppendLine();
            }
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {

                        sb.AppendLine("                    // " + col.Description);
                        sb.AppendLine("                    " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "=\"\";");
                        sb.AppendLine();
                    }
                }
            }
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                {");

            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("                    //" + col.Description);
                sb.AppendLine("                    " + col.PascalName + " = value." + col.PascalName + ";");
                sb.AppendLine();
            }
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {
                        sb.AppendLine();
                        sb.AppendLine("                    // " + col.Description);
                        if (col.DataType.CSharpType == "string")
                            sb.AppendLine("                    " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "=value." + col.PascalName + ";");
                        else if (col.DataType.CSharpType == "DateTime" )
                        {

                            sb.AppendLine("                    if (value." + col.PascalName +"!=null)");
                            sb.AppendLine("                        " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "=value." + col.PascalName + ".ToString(\"yyyy-MM-dd\");");
                        }
                        else if (col.DataType.CSharpType == "DateTime?")
                        {
                            sb.AppendLine("                    if (value." + col.PascalName + "!=null)");
                            sb.AppendLine("                        " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "=value." + col.PascalName + ".Value.ToString(\"yyyy-MM-dd\");");
          
                        }
                        else
                        {
                            sb.AppendLine("                    if (value." + col.PascalName + "!=null)");
                            sb.AppendLine("                        " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "=value." + col.PascalName + ".ToString();");
                        }
                    }
                }
            }
            sb.AppendLine("                }");
            sb.AppendLine("            }");

            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 验证区");
            sb.AppendLine();
            sb.AppendLine("");
            sb.AppendLine("        public bool ValidateData(ref string errMessage)");
            sb.AppendLine("        {");
            sb.AppendLine("            bool isValidate = true;");

            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {

                        if ((col.ControlProperty.ControlType == "W文本框" || col.ControlProperty.ControlType == "X下拉框" || col.ControlProperty.ControlType == "R日期框" || col.ControlProperty.ControlType == "D多行文本框") && col.ControlProperty.IsEnabledNull)
                        {
                            sb.AppendLine();
                            sb.AppendLine("            if (!Validator.Required(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "))");
                            sb.AppendLine("            {");
                            sb.AppendLine("                isValidate = false;");
                            sb.AppendLine("                errMessage += \"" + col.Description + "不能为空\\\\r\\\\n\";");
                            sb.AppendLine("            }");

                        }


                        if (col.DataType.CSharpType.ToUpper() != "STRING")
                        {
                            sb.AppendLine();
                            sb.AppendLine("            if  (!Validator.Is" + col.DataType.CSharpType.Substring(0, 1).ToUpper() + col.DataType.CSharpType.Substring(1).Replace("?", "") + "(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "))");
                            sb.AppendLine("            {");
                            sb.AppendLine("                isValidate = false;");
                            sb.AppendLine("                errMessage += \"" + col.Description + "不是正确的格式\\\\r\\\\n\";");
                            sb.AppendLine("            }");
                        }
                    }
                }

            }
            sb.AppendLine();
            sb.AppendLine("            return isValidate;");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("    }");
            sb.AppendLine("}");


            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format(FileName + ".ascx.cs", Tbl.PascalName);
            returnCode.CodeType = "C#";
            return returnCode;
        }

        #endregion

        #region 生成前台 designer 代码
        public IReturnCode GetAspxDesignerCode()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("//------------------------------------------------------------------------------");
            sb.AppendLine("// <auto-generated>");
            sb.AppendLine("//     此代码由工具生成。");
            sb.AppendLine("//     运行时版本:2.0.50727.3053");
            sb.AppendLine("//");
            sb.AppendLine("//     对此文件的更改可能会导致不正确的行为，并且如果");
            sb.AppendLine("//     重新生成代码，这些更改将会丢失。");
            sb.AppendLine("// </auto-generated>");
            sb.AppendLine("//------------------------------------------------------------------------------");
            sb.AppendLine("");
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName) + "{");
            sb.AppendLine("    ");
            sb.AppendLine("    ");
            sb.AppendLine("    public partial class " + txt_ControlName.Text + " {");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.IsVisible && (!col.IsPrimaryKey))
                {
                    string controlName = "";
                    if (col.ControlProperty.ControlType == "W文本框"|| col.ControlProperty.ControlType == "D多行文本框")
                        controlName = "TextBox";
                    else if (col.ControlProperty.ControlType == "X下拉框")
                        controlName = "DropDownList";
                    else if (col.ControlProperty.ControlType == "R日期框")
                        controlName = "TextBox";
                    else if (col.ControlProperty.ControlType == "F复选框")
                        controlName = "CheckBox";
                    else if (col.ControlProperty.ControlType == "B标签")
                        controlName = "Label";
                    else if (col.ControlProperty.ControlType == "Y隐藏域")
                        controlName = "HiddenField";


                    sb.AppendLine("        "); 
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + col.ControlProperty.ControlName + col.PascalName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::System.Web.UI.WebControls." + controlName + " " + col.ControlProperty.ControlName + col.PascalName + ";");
                }
            }

            sb.AppendLine();

            sb.AppendLine("            }");
            sb.AppendLine("        }");

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format(FileName + ".ascx.designer.cs", Tbl.PascalName);
            returnCode.CodeType = "C#";
            return returnCode;

        }

        #endregion

        #region 生成页面后台代码
        /// <summary>
        /// 生成页面后台代码
        /// </summary>
        /// <returns></returns>
        public IReturnCode GetAspxPageCsCode()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 功能说明: "+Tbl.TableDescription+" 添加、修改页面；");
            sb.AppendLine("    /// 作    者: "+this.OperName);
            sb.AppendLine("    /// 日    期: "+DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 参数说明: ");
            foreach (IColumn pk in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("    ///           "+pk.PascalName.PadRight(20)+"    "+pk.Description);
            }
            sb.AppendLine("    /// 修改说明: ");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class "+Tbl.PascalName+"Page : BasePage");
            sb.AppendLine("    {");
            sb.AppendLine("        #region  页面权限点");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 权限点说明: 有此权限点可打开，无权限不能访问");
            sb.AppendLine("        ///             [权限名称]:     权限含义");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        const string PAGE_POWERPOINT = \"\";");
            sb.AppendLine();      
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 页面参数");
            foreach (IColumn pk in Tbl.PrimaryKey.Columns)
            {
                if (pk.DataType.CSharpType == "Guid")
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// 页面参数 " + pk.PascalName + " " + pk.Description);
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        public Guid " + pk.PascalName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get");
                    sb.AppendLine("            {");
                    sb.AppendLine("                return string.IsNullOrEmpty(Request.QueryString[\""+pk.PascalName+"\"]) ? Guid.Empty : new Guid(Request.QueryString[\""+pk.PascalName+"\"]);");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
                else
                {
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// 页面参数 " + pk.PascalName + " " + pk.Description);
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        public string " + pk.PascalName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get");
                    sb.AppendLine("            {");
                    sb.AppendLine("                return Request.QueryString[\"" + pk.PascalName + "\"];");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
            }
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 页面加载");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 页面加载事件");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\"></param>");
            sb.AppendLine("        /// <param name=\"e\"></param>");
            sb.AppendLine("        protected void Page_Load(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            // 设置保存按钮，添加前台Js验证事件");
            sb.AppendLine("            btn_Save.Attributes.Add(\"onclick\", \"return chkform_"+Tbl.CamelName+"()\");");
            sb.AppendLine();
            sb.AppendLine("            if (!Page.IsPostBack)");
            sb.AppendLine("            {");
            sb.AppendLine("                 // 如果首次加载，根据页面参数获取对象");
            string pkIsNull = "";
           
            sb.AppendLine("                 if (" + GetPrimaryKeyNoNullString() + ")");
                sb.AppendLine("                     this.UC_"+Tbl.PascalName+"Info1."+Tbl.PascalName+" = new BLL."+Tbl.PascalName+"Service().Get"+Tbl.PascalName+"Info("+GetPrimaryParaList()+");");
         
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 按钮事件");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 保存按钮事件");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\"></param>");
            sb.AppendLine("        /// <param name=\"e\"></param>");
            sb.AppendLine("        protected void btn_Save_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine();
            sb.AppendLine("            if (IsValidate())");
            sb.AppendLine("            {");
            sb.AppendLine("                // 保存存 "+Tbl.TableDescription+"信息");
            sb.AppendLine("                new BLL."+Tbl.PascalName+"Service().Save(UC_"+Tbl.PascalName+"Info1."+Tbl.PascalName+");");
            sb.AppendLine();
            sb.AppendLine("               // 提示保存成功");
            sb.AppendLine("               JsHelper.Message.ShowMessage(\"保存成功！\");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///  返回按钮单击事件");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\"></param>");
            sb.AppendLine("        /// <param name=\"e\"></param>");
            sb.AppendLine("        protected void btn_Return_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            //sb.AppendLine("            Response.Redirect(\"OrgList.aspx\");");
            //sb.AppendLine("            //JsHelper.Window.CloseSelf();");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 验证方法");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 验证页面方法，验证通过返回 true 验证失败显示提示信息，并返回 false");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        private bool IsValidate()");
            sb.AppendLine("        {");
            sb.AppendLine("            string msg = \"\";");
            sb.AppendLine("            if (UC_"+Tbl.PascalName+"Info1.ValidateData(ref msg))");
            sb.AppendLine("            {");
            sb.AppendLine("                return true;");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                JsHelper.Message.ShowMessage(msg);");
            sb.AppendLine("            }");
            sb.AppendLine("            return false;");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("    }");
 

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format(FileName + "Page.aspx.cs", Tbl.PascalName);
            returnCode.CodeType = "C#";
            return returnCode;

        }

        #endregion


        #region 辅助方法

        /// <summary>
        /// 生成预览HTML代码
        /// </summary>
        /// <returns></returns>
        public string GetPrewHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table class=\"" + tb_Form + "\" width=\"100%\" cellspacing=\"0\" cellpadding=\"4\" border=\"0\">");

            //List<IColumn> selectedcols = new List<IColumn>();
            //foreach (IColumn scol in Tbl.Columns)
            //{
            //    if (scol.ControlProperty.IsVisible && !scol.IsPrimaryKey)
            //        selectedcols.Add(scol);
            //}
            int i = 1, j = 0;
            foreach (DataGridViewRow row in gv_Setting.Rows)
            {
                if (Convert.ToBoolean(row.Cells[1].EditedFormattedValue))
                {
                    IColumn col = Tbl.Columns.Find(delegate(IColumn tcol) { return tcol.ColumnName == row.Cells[0].Value.ToString(); });
                    if (i == 1)
                        sb.AppendLine("        <tr>");
                    sb.AppendLine("            <td class=\"" + td_label + "\">" + col.Description + "：</td>");
                    sb.Append("            <td class=\"" + td_input + "\">");
                    //判断控件;
                    if (col.ControlProperty.ControlType == "W文本框")
                    {
                        string maxlenSTr = null;
                        if (col.ColumnLength != null)
                        {
                            maxlenSTr = string.Format("MaxLength=\"" + col.ColumnLength + "\"");
                        }
                        sb.Append("<input ID=\"txt_" + col.PascalName + "\"  type=\"text\"  class=\"" + (col.ControlProperty.IsEnabledNull ? mustTextBoxCss : textBoxCss) + "\" >");
                    }

                    if (col.ControlProperty.ControlType == "D多行文本框")
                    {
                        sb.Append("<input ID=\"txt_" + col.PascalName + "\"  type=\"text\" TextMode=\"MultiLine\"  class=\"" + (col.ControlProperty.IsEnabledNull ? mustTextBoxCss : textBoxCss) + "\" >");
                    }


                    if (col.ControlProperty.ControlType == "R日期框")
                        sb.Append("<input ID=\"txt_" + col.PascalName + "\" type=\"text\" class=\"" + (col.ControlProperty.IsEnabledNull ? mustTextBoxCss : textBoxCss) + "\" >");
                    if (col.ControlProperty.ControlType == "X下拉框")
                        sb.Append("<select ID=\"drp_" + col.PascalName + "\" type=\"text\" class=\"" + (col.ControlProperty.IsEnabledNull ? MustdropDownList : dropDownListCss) + "\" ><option>请选择</option></select>");
                    if (col.ControlProperty.ControlType == "F复选框")
                        sb.Append("<input ID=\"cbx_" + col.PascalName + "\" type=\"checkbox\" Text=\"" + col.Description + "\" class=\"" + (col.ControlProperty.IsEnabledNull ? mustCheckBoxCss : checkBoxCss) + "\" runat=\"server\" />");
                    //控件为B标签
                    if (col.ControlProperty.ControlType == "B标签")
                        sb.Append("<span ID=\"lbl_" + col.PascalName + "\"  >[" + col.Description + "]</span>");
                    ///
                    if (col.ControlProperty.ControlType != "B标签")
                    {
                        if (col.ControlProperty.IsEnabledNull)
                            sb.Append("<span class=\"" + requestCss + "\">*</span>");
                    }
                    sb.AppendLine("</td>");

                    if (row.Cells[6].FormattedValue.ToString() == "一列")
                        i += 1;
                    if (row.Cells[6].FormattedValue.ToString() == "二列")
                        i += 2;
                    if (row.Cells[6].FormattedValue.ToString() == "三列")
                        i += 3;

                    if (i >= WebCols)
                    {
                        sb.AppendLine("        </tr>");
                        i = 1;
                    }
                    else
                    {
                        i++;
                    }
                    j++;
                }
            }  
            if (j % WebCols != 0)
            {
                for (int x = 0; x < (WebCols - j % WebCols); x++)
                {
                    sb.AppendLine("            <td class=\"" + td_label + "\"> </td>");
                    sb.AppendLine("            <td class=\"" + td_input + "\"> </td>");
                }
                sb.AppendLine("        </tr>");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }

        /// <summary>
        /// 得到主键参数列表
        /// </summary>
        /// <returns></returns>
        private string GetPrimaryParaList()
        {
            string str = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                str += col.PascalName + ",";
            }
            return str.Substring(0, str.Length - 1);
        }



        private string GetPrimaryKeyNoNullString()
        {
            string str = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                if (col.DataType.CSharpType == "Guid")
                {
                    str += "Guid.Empty!=" + col.PascalName + "&&";
                }
                else
                {
                    str += "!String.IsNullOrEmpty(" + col.PascalName + ")&&";
                }
            }
            return str.Substring(0, str.Length - 2);
        }

        //获取绑定参数列表串


        private string GetArgumentsPrimaryList()
        {
            string str = "";
            if (Tbl.PrimaryKey.Columns.Count == 1)
            {
                IColumn col = Tbl.PrimaryKey.Columns[0];
                str += "Eval(\"" + col.PascalName + "\")";
            }
            else
            {
                for (int i = 0; i < Tbl.PrimaryKey.Columns.Count; i++)
                {
                    IColumn col = Tbl.PrimaryKey.Columns[i];
                    if (i == 0)
                    {
                        str += "Eval(\"" + col.PascalName + "\")+\",";
                    }
                    else if (i == Tbl.PrimaryKey.Columns.Count - 1)
                    {
                        str += "\"+Eval(\"" + col.PascalName + "\")";
                    }
                    else
                    {
                        str += "\"+Eval(\"" + col.PascalName + "\")+\",";
                    }
                }
            }
            return str;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }



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
                SetUIArgs();
                webBrowser1.DocumentText = GetPrewHtml();
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

        #region 排序方法

        private void gv_Setting_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectionIdx = e.RowIndex;
        }

        private void gv_Setting_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged(gv_Setting);
        }

        private void gv_Setting_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void gv_Setting_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks < 2) && (e.Button == MouseButtons.Left))
            {
                if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
                    gv_Setting.DoDragDrop(gv_Setting.Rows[e.RowIndex], DragDropEffects.Move);
            }
        }

        private void gv_Setting_DragDrop(object sender, DragEventArgs e)
        {
            MoveRow(gv_Setting, e);
        }
        #endregion

        private void cbx_Cols_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((DataGridViewComboBoxColumn)gv_Setting.Columns[6]).Items.Clear();
            ((DataGridViewComboBoxColumn)gv_Setting.Columns[6]).Items.Add("不跨列");
            foreach (object item in cbx_Cols.Items)
            {
                if (item == cbx_Cols.SelectedItem) break;
                ((DataGridViewComboBoxColumn)gv_Setting.Columns[6]).Items.Add(item);

            }
            SetUIArgs();
            webBrowser1.DocumentText = GetPrewHtml();
        }

        private void gv_Setting_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
            	
            }
        }
    }
}
