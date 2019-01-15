using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Esint.CodeBuilder.InterFace;
using Esint.Template;


namespace Esint.CodeBuilder.Template 
{
    public partial class Web : Form, ITemplate
    {
        public IDbTable Tbl { get; set; }
        public string NameSpace { get; set; }
        public string FileName { get; set; }
        public DataTable CodeTypeList { get; set; }
        private int WebCols { get; set; }
        public string OperName { get; set; }
        public string ConnectString { get; set; }
        public ICodeBuilder DataAccess { get; set; }

        public List<IDbTable> Tbls { get; set; }


        //程序名称(为名称空间指定名称时使用，因为bll和dal层是不能全称的。)
        public string AppName { get; set; }

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

        public void SetUIArgs()
        {
            foreach (IColumn col in Tbl.Columns)
            {
                col.ControlProperty.IsVisible = true;
            }


            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType().FullName == "System.Windows.Forms.CheckBox")
                {
                    CheckBox cb = (CheckBox)ctrl;
                    //如果“是否选择”控件没选中则 列为不可见。


                    if (cb.Name.Substring(4, 1) == "E" && !cb.Checked)
                    {
                        foreach (IColumn col in Tbl.Columns)
                        {
                            if (col.ColumnName == cb.Name.Substring(6))
                            {
                                col.ControlProperty.IsVisible = false;
                                break;
                            }

                        }
                        continue;
                    }

                    //可以空
                    if (cb.Name.Substring(4, 1) == "N")
                    {
                        foreach (IColumn col in Tbl.Columns)
                        {
                            if (col.ColumnName == cb.Name.Substring(6))
                            {
                                col.ControlProperty.IsEnabledNull = cb.Checked;
                                break;
                            }
                        }
                    }
                }

                //选择控件
                if (ctrl.GetType().FullName == "System.Windows.Forms.ComboBox")
                {
                    ComboBox cob = (ComboBox)ctrl;
                    foreach (IColumn col in Tbl.Columns)
                    {
                        if (cob.Name.Substring(4, 1) == "T" && col.ColumnName == cob.Name.Substring(6))
                        {

                            col.ControlProperty.ControlType = cob.SelectedItem.ToString();
                            //设置每个页面上drp控件的参数字典Code

                            if (cob.SelectedItem.ToString() == "下拉框")
                            {
                                Control[] cobs = panel1.Controls.Find("cbx_P_" + col.ColumnName, true);
                                if (cobs.Length > 0)
                                {
                                    ComboBox cob_p = (ComboBox)cobs[0];
                                    col.ControlProperty.Tag = cob_p.Text.ToString();
                                }
                            }

                            //
                            break;
                        }


                    }
                }
                if (ctrl.GetType().FullName == "System.Windows.Forms.TextBox")
                {
                    TextBox txt = (TextBox)ctrl;
                    foreach (IColumn col in Tbl.Columns)
                    {
                        if (col.ColumnName == txt.Name.Substring(6))
                        {
                            col.ControlProperty.Tag = txt.Text;
                            break;
                        }
                    }

                    //获取web页面设置的列数
                    if (ctrl.Name == "txt_Column")
                        WebCols = Convert.ToInt32(ctrl.Text);
                }

            }

        }

        public static bool HasControl(IDbTable db, string ControlName)
        {
            bool has = false;
            foreach (IColumn col in db.Columns)
            {
                if (col.ControlProperty.ControlType == ControlName)
                {
                    has = true;
                    break;
                }
            }
            return has;
        }

        public void Initi()
        {
            if (Tbl == null)
            {
                MessageBox.Show("没有获取到数据表！", "错误");
                return;
            }
            int ix = 10, iy = 10 ;
            foreach (IColumn col in Tbl.Columns)
            {
                if (!col.IsPrimaryKey)
                {
                    CheckBox chx = new CheckBox();
                    chx.Checked = true;
                    chx.Name = "chx_E_" + col.ColumnName;
                    chx.Location = new Point(ix, iy);
                    chx.Tag = "";
                    chx.Text = col.Description;
                    chx.AutoSize = false;
                    chx.Size = new System.Drawing.Size(150, 20);
                    panel1.Controls.Add(chx);


                    CheckBox chxnull = new CheckBox();
                    if (col.IsNull)
                        chxnull.Checked = false;
                    else
                        chxnull.Checked = true;
                    chxnull.Name = "chx_N_" + col.ColumnName;
                    chxnull.Tag = "";
                    chxnull.Text = "必填";
                    chxnull.Location = new Point(ix + 250, iy);
                    chxnull.Size = new System.Drawing.Size(50, 20);
                    panel1.Controls.Add(chxnull);

                    ComboBox cbx = new ComboBox();
                    cbx.Items.Add("文本框");
                    cbx.Items.Add("下拉框");
                    cbx.Items.Add("日期框");
                    cbx.Items.Add("复选框");
                    cbx.Items.Add("隐藏域");
                    //keliang.huang added 2010-04-27
                    cbx.Items.Add("标签");
                    //
                    cbx.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (col.DataType.CSharpType == "DateTime")
                        cbx.SelectedIndex = 2;
                    else if (col.DataType.CSharpType == "bool")
                        cbx.SelectedIndex = 3;
                    else
                        cbx.SelectedIndex = 0;
                    cbx.Name = "cbx_T_" + col.ColumnName;
                    cbx.Tag = col.ColumnName;
                    cbx.Size = new System.Drawing.Size(80, 20);
                    cbx.Location = new Point(ix + 150, iy);
                    cbx.SelectedValueChanged += new EventHandler(cbx_SelectedValueChanged);
                    this.panel1.Controls.Add(cbx);

                    //

                    iy = iy + 30;
                }
            }

            //choose column number
            Label lb_column = new Label();
            lb_column.Name = "lb_Column";
            lb_column.Width = 140;
            lb_column.Location = new Point(ix, iy);
            lb_column.Text = "请选择表格的列数：";
            this.panel1.Controls.Add(lb_column);


            TextBox tb_column = new TextBox();
            tb_column.Name = "txt_Column";
            tb_column.Text = "2";
            tb_column.Location = new Point(ix + 150, iy);
            this.panel1.Controls.Add(tb_column);
            //End;


        }

        void cbx_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem.ToString() == "下拉框" && cb.Name.Substring(4, 1) == "T")
            {
                //TextBox tb = new TextBox();
                //tb.Name = "txt_C_" + cb.Tag;
                ////  tb.Text = cb.Tag.ToString();
                //加入下拉框参数选择
                //
                ComboBox cb_dic = new ComboBox();
                cb_dic.Name = "cbx_P_" + cb.Tag;
                cb_dic.Tag = "cbx_P_" + cb.Tag;
                cb_dic.DropDownStyle = ComboBoxStyle.DropDownList;
                cb_dic.Location = new System.Drawing.Point(cb.Location.X + 150, cb.Location.Y);
                panel1.Controls.Add(cb_dic);
                //开始绑定



                foreach (DataRow dr in CodeTypeList.Rows)
                {
                    cb_dic.Items.Add(dr[0].ToString());

                }

                //结束绑定

            }
            else
            {

                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl.GetType().FullName == "System.Windows.Forms.ComboBox")
                    {

                        if (((ComboBox)ctrl).Name == "cbx_P_" + cb.Tag)
                        {
                            panel1.Controls.Remove(ctrl);
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        public IReturnCode[] GetCode()
        {
            IReturnCode[] returnCode = new IReturnCode[3];
            Initi();
            this.ShowDialog();
            //insert & update webpage
            returnCode[0] = GetAspxCode();
            returnCode[1] = GetAspxcsCode();
            returnCode[2] = GetAspxDesignerCode();

            return returnCode;
        }

        #region 生成前台页面
        // Create insert & update webpage
        public IReturnCode GetAspxCode()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"UC_" + Tbl.PascalName + ".ascx.cs\" Inherits=\"" + NameSpace + ".UC_" + Tbl.PascalName + "\" %>");
            sb.AppendLine();
            sb.AppendLine("<!-- 样式引用 -->");
            sb.AppendLine("<link href=\"../Css/Common.css\" rel=\"stylesheet\" type=\"text/css\" />");
            sb.AppendLine("<link href=\"../Css/ControlCss.css\" rel=\"stylesheet\" type=\"text/css\" />");
            sb.AppendLine();
            sb.AppendLine("<!-- 脚本引用 -->");

            sb.AppendLine("<script src=\"../Js/validate.js\" type=\"text/javascript\"></script>");
            if (HasControl(Tbl, "日期框"))
            {
                sb.AppendLine("<script src=\"../Js/calendar.js\" type=\"text/javascript\"></script>");
            }
            sb.AppendLine();
            sb.AppendLine("<!-- 验证脚本开始 -->");
            sb.AppendLine("<script language=\"javascript\" type=\"text/javascript\">");
            sb.AppendLine("    function chkform_" + Tbl.CamelName + "(){");
            sb.AppendLine("        var alert_msg=\"\";");
            sb.AppendLine("        var istrue=true;");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.IsVisible && (col.ControlProperty.ControlType == "文本框" || col.ControlProperty.ControlType == "下拉框" || col.ControlProperty.ControlType == "日期框") && col.ControlProperty.IsEnabledNull)
                {
                    sb.AppendLine("        if(Require(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\"))");
                    sb.AppendLine("        {");
                    sb.AppendLine("            alert_msg += \"" + col.Description + "不能为空。\";");
                    sb.AppendLine("            istrue = false;");
                    sb.AppendLine("        }");

                }
                if (col.ControlProperty.IsVisible && col.ControlProperty.ControlType == "日期框")
                {
                    sb.AppendLine("        if(IsDate(\"<%=this.ID %>_" + col.ControlProperty.ControlName + "" + col.PascalName + "\"))");
                    sb.AppendLine("        {");
                    sb.AppendLine("            alert_msg += \"" + col.Description + "应输入正确的日期。\";");
                    sb.AppendLine("            istrue = false;");
                    sb.AppendLine("        }");
                }
                if (col.ControlProperty.IsVisible && col.DataType.CSharpType.ToUpper().Replace("?","") == "INT")
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
            //sb.AppendLine("</head>");
            //head结束
            //body开始


            //sb.AppendLine("<body>");
            //sb.AppendLine("<form id=\""+Tbl.PascalName+"Form\" runat=\"server\">");
            sb.AppendLine("<div>");
            //表格开始table
            sb.AppendLine("    <table class=\"tb_form\">");

            List<IColumn> selectedcols = new List<IColumn>();
            foreach (IColumn scol in Tbl.Columns)
            {
                if (scol.ControlProperty.IsVisible &&!scol.IsPrimaryKey)
                    selectedcols.Add(scol);
            }

            int i = 1, j = 1;
            foreach (IColumn col in selectedcols)
            {
                if (i == 1)
                    sb.AppendLine("          <tr>");
                sb.AppendLine("            <td class=\"td_label\">" + col.Description + "：</td>");
                sb.Append("            <td class=\"td_input\">");
                //判断控件;
                if (col.ControlProperty.ControlType == "文本框")
                {
                    string maxlenSTr = null;
                    if (col.ColumnLength != null)
                    {
                        maxlenSTr = string.Format("MaxLength=\"" + col.ColumnLength + "\"");
                    }
                    sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" " + maxlenSTr + " CssClass=\"textBoxCss\" runat=\"server\"></asp:TextBox>");
                }
                if (col.ControlProperty.ControlType == "日期框")
                    sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" MaxLength=\"8\" CssClass=\"textBoxCss\"  onFocus=\"calendar()\" runat=\"server\"></asp:TextBox>");
                if (col.ControlProperty.ControlType == "下拉框")
                    sb.Append("<asp:DropDownList ID=\"drp_" + col.PascalName + "\" runat=\"server\" CssClass=\"dropDownListCss\" ></asp:DropDownList>");
                if (col.ControlProperty.ControlType == "复选框")
                    sb.Append("<asp:CheckBox ID=\"cbx_" + col.PascalName + "\" Text=\"" + col.Description + "\" CssClass=\"checkBoxCss\" runat=\"server\" />");
                //控件为标签
                if (col.ControlProperty.ControlType == "标签")
                    sb.Append("<asp:Label ID=\"lbl_"+col.PascalName+"\" runat=\"server\"></asp:Label>");
                ///
                if (col.ControlProperty.ControlType != "标签")
                {                    if (col.ControlProperty.IsEnabledNull)
                        sb.Append("<span class=\"requestCss\"></span>");
                }
                sb.AppendLine("</td>");
                if (i == WebCols || j == selectedcols.Count)
                {
                    sb.AppendLine("          </tr>");
                    i = 1;
                }
                else

                    i++;
                j++;

            }

            #region 注释







            //int i = 0;
            //while (i < Tbl.Columns.Count)
            //{

            //    sb.AppendLine("          <tr>");
            //    int cl = 0;
            //    for (cl = 1; cl <= int.Parse(PublicClass.WebColumnCount); cl++)
            //    {
            //        if (i == Tbl.Columns.Count)
            //        { break; }
            //        Column col = Tbl.Columns[i];
            //        if (col.ControlProperty.IsVisible)
            //        {
            //            if (!col.IsPrimaryKey)
            //            {
            //                sb.AppendLine("            <td class=\"td_label\">" + col.Description + "：</td>");
            //                sb.Append("            <td class=\"td_input\">");
            //                //判断控件;
            //                if (col.ControlProperty.ControlType == "文本框")
            //                {
            //                    string maxlenSTr = null;
            //                    if (col.ColumnLength != null)
            //                    {
            //                        maxlenSTr = string.Format("MaxLength=\"" + col.ColumnLength + "\"");
            //                    }
            //                    sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" " + maxlenSTr + " CssClass=\"textBoxCss\" runat=\"server\"></asp:TextBox>");
            //                }
            //                if (col.ControlProperty.ControlType == "日期框")
            //                    sb.Append("<asp:TextBox ID=\"txt_" + col.PascalName + "\" MaxLength=\"8\" CssClass=\"textBoxCss\"  onFocus=\"calendar()\" runat=\"server\"></asp:TextBox>");
            //                if (col.ControlProperty.ControlType == "下拉框")
            //                    sb.Append("<asp:DropDownList ID=\"drp_" + col.PascalName + "\" runat=\"server\" CssClass=\"dropDownListCss\" ></asp:DropDownList>");
            //                if (col.ControlProperty.ControlType == "复选框")
            //                    sb.Append("<asp:CheckBox ID=\"cbx_" + col.PascalName + "\" Text=\"" + col.Description + "\" CssClass=\"checkBoxCss\" runat=\"server\" />");
            //                ///
            //                if (col.ControlProperty.IsEnabledNull)
            //                    sb.Append("<span class=\"requestCss\"></span>");
            //                sb.AppendLine("</td>");
            //            }
            //        }
            //        i++;
            //    }
            //    for (int lastcolumn = cl; lastcolumn <= int.Parse(PublicClass.WebColumnCount); lastcolumn++)
            //        sb.AppendLine("<td>           </td><td>           </td>");
            //    sb.AppendLine("          </tr>");
            //}

            #endregion


            sb.AppendLine("          <tr>");
            sb.AppendLine("            <td colspan=\"" + WebCols * 2 + "\">");
            //add primary key controls
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("                <asp:HiddenField ID=\"hd_" + col.PascalName + "\" runat=\"server\" />");
            }
            sb.AppendLine("                <asp:Label ID=\"lbl_errMsg\" CssClass=\"errorMsgCss\" runat=\"server\"></asp:Label></td>");
            sb.AppendLine("          </tr>");
            sb.AppendLine("          <tr>");
            sb.AppendLine("              <td colspan=\"" + WebCols * 2 + "\" align=\"center\" class=\"td_operate\"> <asp:Button ID=\"btn_Submit\" runat=\"server\" onclick=\"btn_Submit_Click\" OnClientClick=\"return chkform_" + Tbl.CamelName + "();\" Text=\"保存\" CssClass=\"buttonCss\" /></td>");
            sb.AppendLine("          </tr>");
            sb.AppendLine("        </table>");
            sb.AppendLine("      </div>");
    

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format("UC_" + Tbl.PascalName + ".ascx");
            returnCode.CodeType = "HTML";
            return returnCode;

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
            sb.AppendLine("namespace " + NameSpace);
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称：化学品管理表单控件");
            sb.AppendLine("    /// 作    者：");
            sb.AppendLine("    /// 日    期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 修改日期：");
            sb.AppendLine("    /// 修 改 人：");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class UC_" + Tbl.PascalName + ": BaseUserControl");
            sb.AppendLine("    {");
            sb.AppendLine("        #region 用户变量定义区");
            sb.AppendLine("");
            sb.AppendLine("        //" + Tbl.TableDescription + "业务处理对象");
            sb.AppendLine("        " + Tbl.PascalName + "Service " + Tbl.CamelName + "Service = new " + Tbl.PascalName + "Service();");

            //if (CodeBuilderForOracle.Common.HasControl(Tbl, "下拉框"))
            //{
            //    sb.AppendLine();
            //    sb.AppendLine("        //参数列表业务处理对象");
            //    sb.AppendLine("        Sys_codeService sys_codeBLL = new Sys_codeService();");
            //}

            //开始控制按钮可视化属性


            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            
            sb.AppendLine("        #region 事件区");
            sb.AppendLine();
            sb.AppendLine("        //定义保存成功后的委托，参数返回保存后的"+Tbl.TableDescription);
            sb.AppendLine("        public delegate void SavedDelegate("+Tbl.PascalName+"Info "+Tbl.CamelName+");");
            sb.AppendLine();
            sb.AppendLine("        //保存后事件，保存后触发");
            sb.AppendLine("        public event SavedDelegate OnSaved;");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 控件属性区");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 是否显示用户控件按钮");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public bool IsShow_Uc_btn");
            sb.AppendLine("        {");
            sb.AppendLine("            get { return  btn_Submit.Visible; }");
            sb.AppendLine("            set { btn_Submit.Visible = value; }");
            sb.AppendLine("        }");
         
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine();
                sb.AppendLine("        ///<summary>");
                sb.AppendLine("        ///" + col.Description);
                sb.AppendLine("        ///<summary>");
                sb.AppendLine("        public string " + col.PascalName);
                sb.AppendLine("        {");
                sb.AppendLine("            get { return  hd_"+col.PascalName+".Value;} ");
                sb.AppendLine("            set { hd_" + col.PascalName + ".Value = value;} ");
                sb.AppendLine("        }");
            }
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 页面加载");
            sb.AppendLine();
            sb.AppendLine("        protected void Page_Load(object sender, EventArgs e)");
            sb.AppendLine("        { ");
            sb.AppendLine("            btn_Submit.Visible = IsShow_Uc_btn;");
            sb.AppendLine("            if (!Page.IsPostBack)");

            sb.AppendLine("            {");
            //sb.AppendLine("                Uc_btn_Submit");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.ControlType == "下拉框")
                {
                    //判断字典值是否为加"|"过程
                    string[] dics = null;
                    string flag = null;

                    if (col.ControlProperty.Tag.IndexOf("|") >= 0)
                    {
                        dics = col.ControlProperty.Tag.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                        flag = dics[0];//这个表示flag部分
                    }
                    //

                    sb.AppendLine("                #region " + col.Description + " drp绑定字典表");
                    sb.AppendLine();
                    sb.AppendLine("                //" + col.Description + " drp绑定字典表");
                    sb.AppendLine("                drp_" + col.PascalName + ".CodeBinding(\"" + flag + "\");");
                    //sb.AppendLine("                drp_" + col.PascalName + ".DataTextField = \"CodeMeaning\";");
                    //sb.AppendLine("                drp_" + col.PascalName + ".DataValueField = \"Code\";");
                    //sb.AppendLine("                drp_" + col.PascalName + ".DataBind();");
                    //sb.AppendLine("                drp_" + col.PascalName + ".Items.Insert(0, new ListItem(\"请选择\", \"\"));");
                    sb.AppendLine();
                    sb.AppendLine("                #endregion");
                    sb.AppendLine();
                }
            }
            sb.AppendLine("                if (" + GetPrimaryKeyNoNullString() + ")");
            sb.AppendLine("                {");
        //    foreach (IColumn col in Tbl.PrimaryKey.Columns)
         //   {
          //      sb.AppendLine("                " + col.PascalName + " = " + col.DataType.ConvertString + "(Request.QueryString[\"" + col.PascalName + "\"]);");
           // }

            sb.AppendLine("                    " + Tbl.PascalName + "Info " + Tbl.CamelName + " = " + Tbl.CamelName + "Service.Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ");");
            sb.AppendLine("                    SetPageDataBy" + Tbl.PascalName + "(" + Tbl.CamelName + ");");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 控件事件区");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        ///" + Tbl.TableDescription + " 数据绑定");
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        public void " + Tbl.PascalName + "DataBinding()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (" + GetPrimaryKeyNoNullString() + ")");
            sb.AppendLine("            {");
            sb.AppendLine("                " + Tbl.PascalName + "Info " + Tbl.CamelName + " = " + Tbl.CamelName + "Service.Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ");");
            sb.AppendLine("                SetPageDataBy" + Tbl.PascalName + "(" + Tbl.CamelName + ");");
            sb.AppendLine("                this.lbl_errMsg.Text = \"\";");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        ///" + Tbl.TableDescription + "数据提交");
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        protected void btn_Submit_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (ValidateData())");
            sb.AppendLine("            {");
            sb.AppendLine("                " + Tbl.PascalName + "Info " + Tbl.CamelName + " = GetPageDataFor" + Tbl.PascalName + "();");
            sb.AppendLine("                //创建日志对象");
            sb.AppendLine("                " + Tbl.CamelName + ".configrationinfo = base.CurrentUser.configrationinfo;");
            sb.AppendLine("                //保存");
                
            sb.AppendLine("                " + Tbl.CamelName + "Service.Save(" + Tbl.CamelName + ");");
            sb.AppendLine("               base.ShowMessage(\"保存成功！\");");
            sb.AppendLine("               //触发保存后事件");
            sb.AppendLine("               if (OnSaved != null)");
            sb.AppendLine("                   OnSaved("+Tbl.CamelName+");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("          /// <summary>");
            sb.AppendLine("          /// 初始化控件值");
            sb.AppendLine("          /// </summary>");
            sb.AppendLine("          public void InitializeUserControl()");
            sb.AppendLine("          {");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            hd_" + col.PascalName + ".Value = \"\";//" + col.Description + "");
            }

            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {
                        sb.AppendLine("            //"+col.Description);
                        sb.AppendLine("            " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + " = \"\";");
                    }
                }
            }
            sb.AppendLine("          }");
            //sb.AppendLine("         protected void btn_Cancel_Click(object sender, EventArgs e)");
            //sb.AppendLine("         {");
            //sb.AppendLine("             //取消返回按钮");
            //sb.AppendLine("         }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 实体--控件值转换区");
            sb.AppendLine();
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        ///从页面控件得到数据产生对象");
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        protected " + Tbl.PascalName + "Info GetPageDataFor" + Tbl.PascalName + "()");
            sb.AppendLine("        {  ");
            sb.AppendLine("            //定义" + Tbl.TableDescription + "对象实体");
            sb.AppendLine("            " + Tbl.PascalName + "Info  " + Tbl.CamelName + " = new  " + Tbl.PascalName + "Info();");
            sb.AppendLine();
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                //检测是否可以为空如果可以则不加载此验证程序(Check is control can be null,if true,don't loading this program...)
                if (!col.ControlProperty.IsEnabledNull)
                {
                    sb.AppendLine("            //如果主键不为空，给主键赋值");
                    sb.AppendLine("            if (!String.IsNullOrEmpty(hd_" + col.PascalName + ".Value))");
                    sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(hd_" + col.PascalName + ".Value);");
                    sb.AppendLine();
                }
            }

            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {
                        sb.AppendLine();
                        sb.AppendLine("            // " + col.Description);
                        sb.AppendLine("            " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + ".Trim());");
                    }
                }
            }
            sb.AppendLine();
            sb.AppendLine("            return " + Tbl.CamelName + ";");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        ///将实体对象值赋给页面控件");
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        /// <param name=" + Tbl.CamelName + ">" + Tbl.TableDescription + "实体</param>");
            sb.AppendLine("        protected void SetPageDataBy" + Tbl.PascalName + "(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");

            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            hd_" + col.PascalName + ".Value = " + Tbl.CamelName + "." + col.PascalName + ".ToString();//" + col.Description + "");
            }

            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {
                        sb.AppendLine();
                        sb.AppendLine("            // " + col.Description);
                      //  sb.AppendLine("            if(!String.IsNullOrEmpty(" + Tbl.CamelName + "." + col.PascalName + "))");
                     //   sb.AppendLine("            {");
                        sb.AppendLine("            " + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + " = WebComm.ConvertToDisplayValue(" + Tbl.CamelName + "." + col.PascalName + ");");
                        sb.AppendLine();
                    }
                }
            }
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 验证区");
            sb.AppendLine();
            sb.AppendLine("");
            sb.AppendLine("        protected bool ValidateData()");
            sb.AppendLine("        {");
            sb.AppendLine("            string errMessage = \"数据提交失败:<br>\";");
            sb.AppendLine("            bool isValidate = true;");


            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                    {

                        if ((col.ControlProperty.ControlType == "文本框" || col.ControlProperty.ControlType == "下拉框" || col.ControlProperty.ControlType == "日期框") && col.ControlProperty.IsEnabledNull)
                        {
                            sb.AppendLine();
                            sb.AppendLine("            if (!Validator.Required(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "))");
                            sb.AppendLine("            {");
                            sb.AppendLine("                isValidate = false;");
                            sb.AppendLine("                errMessage += \"" + col.Description + "不能为空<br>\";");
                            sb.AppendLine("            }");

                        }


                        if (col.DataType.CSharpType.ToUpper() != "STRING")
                        {
                            sb.AppendLine();
                            sb.AppendLine("            if  (!Validator.Is" + col.DataType.CSharpType.Substring(0, 1).ToUpper() + col.DataType.CSharpType.Substring(1).Replace("?", "") + "(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + "))");
                            sb.AppendLine("            {");
                            sb.AppendLine("                isValidate = false;");
                            sb.AppendLine("                errMessage += \"" + col.Description + "不是正确的格式<br>\";");
                            sb.AppendLine("            }");
                        }
                    }
                }

            }
            sb.AppendLine("            if (!isValidate)");
            sb.AppendLine("            {");
            sb.AppendLine("                lbl_errMsg.Text = errMessage;");
            sb.AppendLine("            }");
            sb.AppendLine();
            sb.AppendLine("            return isValidate;");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine("    }");
            sb.AppendLine("}");


            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format("UC_" + Tbl.PascalName + ".ascx.cs");
            returnCode.CodeType = "C#";
            return returnCode;
        }

        #endregion

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
            sb.AppendLine("namespace " + NameSpace + "{");
            sb.AppendLine("    ");
            sb.AppendLine("    ");
            sb.AppendLine("    public partial class UC_" + Tbl.PascalName + " {");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.IsVisible && (!col.IsPrimaryKey))
                {
                    string controlName = "";
                    if (col.ControlProperty.ControlType == "文本框")
                        controlName = "TextBox";
                    else if (col.ControlProperty.ControlType == "下拉框")
                        controlName = "DropDownList";
                    else if (col.ControlProperty.ControlType == "日期框")
                        controlName = "TextBox";
                    else if (col.ControlProperty.ControlType == "复选框")
                        controlName = "CheckBox";
                    else if (col.ControlProperty.ControlType == "标签")
                        controlName = "Label";


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

                if (col.IsPrimaryKey)
                {

                    sb.AppendLine("        ");
                    sb.AppendLine("        /// <summary>");
                    sb.AppendLine("        /// " + col.ControlProperty.ControlName + col.PascalName + " 控件。");
                    sb.AppendLine("        /// </summary>");
                    sb.AppendLine("        /// <remarks>");
                    sb.AppendLine("        /// 自动生成的字段。");
                    sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
                    sb.AppendLine("        /// </remarks>");
                    sb.AppendLine("        protected global::System.Web.UI.WebControls.HiddenField hd_" + col.PascalName + ";");

                }
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// btn_Submit 控件。");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <remarks>");
            sb.AppendLine("        /// 自动生成的字段。");
            sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
            sb.AppendLine("        /// </remarks>");
            sb.AppendLine("        protected global::System.Web.UI.WebControls.Button btn_Submit;");
            sb.AppendLine();
            sb.AppendLine();
            //sb.AppendLine("        /// <summary>");
            //sb.AppendLine("        /// btn_Cancel 控件。");
            //sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        /// <remarks>");
            //sb.AppendLine("        /// 自动生成的字段。");
            //sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
            //sb.AppendLine("        /// </remarks>");
            //sb.AppendLine("        protected global::System.Web.UI.WebControls.Button btn_Cancel;");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// lbl_errMsg 控件。");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <remarks>");
            sb.AppendLine("        /// 自动生成的字段。");
            sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
            sb.AppendLine("        /// </remarks>");
            sb.AppendLine("        protected global::System.Web.UI.WebControls.Label lbl_errMsg;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format("UC_" + Tbl.PascalName + ".ascx.designer.cs");
            returnCode.CodeType = "C#";
            return returnCode;

        }

        #region 辅助方法
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
                str += "!String.IsNullOrEmpty(" + col.PascalName + ")&&";
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



    }
}
