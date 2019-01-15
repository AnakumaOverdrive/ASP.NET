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
    public partial class WebList : Form,  ITemplate
    {
        public IDbTable Tbl { get; set; }
        public string NameSpace { get; set; }
        public string FileName { get; set; }
        public DataTable CodeTypeList { get; set; }
        public string OperName { get; set; }
         
        public string ConnectString { get; set; }

        public ICodeBuilder DataAccess { get; set; }

        public List<IDbTable> Tbls { get; set; }

        //程序名称(为名称空间指定名称时使用，因为bll和dal层是不能全称的。)
        public string AppName { get; set; }
  
        #region 窗口控制
        public WebList()
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
            IDbTable db = Tbl;
            foreach (IColumn col in db.Columns)
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
                        foreach (IColumn col in db.Columns)
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
                        foreach (IColumn col in db.Columns)
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
                    foreach (IColumn col in db.Columns)
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
                    foreach (IColumn col in db.Columns)
                    {
                        if (col.ColumnName == txt.Name.Substring(6))
                        {
                            col.ControlProperty.Tag = txt.Text;
                            break;
                        }
                    }

                }

            }
         
        }

        public void Initi()
        {
            int ix = 10, iy = 10;
            foreach (IColumn col in Tbl.Columns)
            {
                //if (!col.IsPrimaryKey)
                //{
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
                //}
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
              //list webpate
            returnCode[0] = GetListAspxCode();
            returnCode[1] = GetListAspxcsCode();
            returnCode[2] = GetListAspxDesignerCode();
            return returnCode;
        }

        #region 生成前台页面


        /// <summary>
        /// Create entitylist webpage
        /// </summary>
        /// <returns></returns>
        public IReturnCode GetListAspxCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"UC_" + Tbl.PascalName + "_List.ascx.cs\" Inherits=\"" + NameSpace + ".UC_" + Tbl.PascalName + "_List\" %>");
            
            sb.Append("<asp:GridView CssClass=\"GridViewCss\" ID=\"grd_"+Tbl.PascalName+"\" runat=\"server\" AllowPaging=\"True\" ");
            sb.Append(" AllowSorting=\"True\" AutoGenerateColumns=\"False\" OnSorting=\"grd_" + Tbl.PascalName + "_Sorting\" ");
            sb.Append(" OnPageIndexChanging=\"grd_" + Tbl.PascalName + "_PageIndexChanging\" PageSize=\"10\"  DataKeyNames=\"" + GetPrimaryParaList() + "\"");
            sb.AppendLine(" OnRowCommand=\"grd_" + Tbl.PascalName + "_RowCommand\" GridLines=\"None\" onrowdatabound=\"grd_"+Tbl.PascalName+"_RowDataBound\" >");
            sb.AppendLine("    <EmptyDataRowStyle CssClass = \"EmptyRowCss\" />");
            sb.AppendLine("    <EditRowStyle CssClass=\"EditRowCss\" />");
            sb.AppendLine("    <RowStyle CssClass=\"RowCss\" />");
            sb.AppendLine("    <AlternatingRowStyle CssClass=\"AlterRowCss\" />");
            sb.AppendLine("    <PagerStyle CssClass=\"GridViewPagerCss\" />");
            sb.AppendLine("    <HeaderStyle CssClass = \"HeaderRowCss\" />");
            sb.AppendLine("    <SelectedRowStyle CssClass = \"SelectRowCss\" />");
            sb.AppendLine("    <Columns>");
            sb.AppendLine("        <asp:TemplateField HeaderText=\"序号\">");
            sb.AppendLine("            <HeaderStyle Width=\"40px\"></HeaderStyle>");
            sb.AppendLine("            <ItemStyle HorizontalAlign=\"Center\"></ItemStyle>");
            sb.AppendLine("            <ItemTemplate><asp:Label ID=\"lblIndex\" runat=\"server\"><%#Container.DataItemIndex + 1%></asp:Label></ItemTemplate>");
            sb.AppendLine("        </asp:TemplateField>");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.IsVisible)
                {
                    sb.AppendLine("        <asp:BoundField DataField=\"" + col.PascalName + "\" HeaderText=\"" + col.Description + "\" SortExpression=\"" + col.PascalName + "\" />");
                }
            }

            sb.AppendLine("        <asp:TemplateField HeaderText=\"操作\">");
            sb.AppendLine("        <ItemStyle  CssClass = \"GridViewOperate\"/>");
            sb.AppendLine("            <ItemTemplate>");
            sb.AppendLine("                <asp:LinkButton ID=\"lb_edit\" runat=\"server\" CommandArgument='<%#" + GetArgumentsPrimaryList() + "%>' CommandName=\"RowEdit\">编辑</asp:LinkButton>");
            sb.AppendLine("                <asp:LinkButton ID=\"lb_delete\" runat=\"server\" CommandArgument='<%#" + GetArgumentsPrimaryList() + "%>' CommandName=\"RowDelete\">删除</asp:LinkButton>");
            sb.AppendLine("            </ItemTemplate>");
            sb.AppendLine("        </asp:TemplateField>");
            sb.AppendLine("    </Columns>");
            sb.AppendLine("    <PagerTemplate>");
            sb.AppendLine("        <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"font-size: small\">");
            sb.AppendLine("            <tr>");
            sb.AppendLine("                <td style=\"width: 15%; vertical-align: bottom\">记录数&nbsp;<asp:Label ID=\"wlbl_RecordCount\" runat=\"server\" CssClass=\"CountRecordCss\"><%# ((System.Data.DataTable)((GridView)Container.NamingContainer).DataSource).Rows.Count%></asp:Label>&nbsp;条</td>");
            sb.AppendLine("                <td style=\"width: 10%; vertical-align: bottom\">第&nbsp;<asp:Label ID=\"wlbl_CurrPage\" runat=\"server\"  CssClass=\"PageIndexCss\"><%# ((GridView)Container.NamingContainer).PageIndex + 1%></asp:Label>&nbsp;页</td>");
            sb.AppendLine("                <td style=\"width: 10%; vertical-align: bottom\">共&nbsp;<asp:Label ID=\"wlbl_TotalPage\" runat=\"server\" CssClass=\"PageCountCss\"><%# ((GridView)Container.NamingContainer).PageCount%></asp:Label>&nbsp;页</td>");
            sb.AppendLine("                <td style=\"width: 18%; vertical-align: bottom\"></td>");
            sb.AppendLine("                <td style=\"width: 8%; vertical-align: bottom\"><asp:LinkButton ID=\"lbtnF\" runat=\"server\" CommandName=\"Page\" CommandArgument=\"First\" CssClass=\"FirstPageCss\" Enabled=\"<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>\">首页</asp:LinkButton></td>");
            sb.AppendLine("                <td style=\"width: 8%; vertical-align: bottom\"><asp:LinkButton ID=\"lbtnP\" runat=\"server\" CommandName=\"Page\" CommandArgument=\"Prev\"  CssClass=\"PrevPageCss\" Enabled=\"<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>\">上一页</asp:LinkButton></td>");
            sb.AppendLine("                <td style=\"width: 8%; vertical-align: bottom\"><asp:LinkButton ID=\"lbtnN\" runat=\"server\" CommandName=\"Page\" CommandArgument=\"Next\" CssClass=\"NextPageCss\" Enabled=\"<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>\">下一页</asp:LinkButton></td>");
            sb.AppendLine("                <td style=\"width: 8%; vertical-align: bottom\"><asp:LinkButton ID=\"lbtnL\" runat=\"server\" CommandName=\"Page\" CommandArgument=\"Last\" CssClass=\"LastPageCss\" Enabled=\"<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>\">尾页</asp:LinkButton></td>");
            sb.AppendLine("                <td style=\"width: 15%; vertical-align: bottom\">到&nbsp;<asp:TextBox ID=\"wtxt_GoToPage\" CssClass=\"GoToPageCss\" runat=\"server\" />&nbsp;页&nbsp;<asp:LinkButton ID=\"LinkButton5\" runat=\"server\" CausesValidation=\"false\" CssClass = \"GoPageBtnCss\" OnClick=\"goPage_Click\">Go</asp:LinkButton></td>");
            sb.AppendLine("            </tr>");
            sb.AppendLine("        </table>");
            sb.AppendLine("    </PagerTemplate>");
            sb.AppendLine("    <PagerSettings Position=\"Bottom\" />");
            sb.AppendLine("</asp:GridView>");

            sb.AppendLine("<div style=\"text-align:right;height:35px;\"><asp:Button ID=\"btn_Add\" CssClass=\"ButtonCss\" runat=\"server\" Text=\"新增"+Tbl.TableDescription+"\" />");
            sb.AppendLine("</div>");

            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format("UC_" + Tbl.PascalName + "_List.ascx");
            returnCode.CodeType = "HTML";
            return returnCode;
        }
#endregion

        #region 生成前面页CS代码


        //list cs
        public IReturnCode GetListAspxcsCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Configuration;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Web.Security;");
            sb.AppendLine("using System.Web.UI;");
            sb.AppendLine("using System.Web.UI.HtmlControls;");
            sb.AppendLine("using System.Web.UI.WebControls;");
            sb.AppendLine("using System.Web.UI.WebControls.WebParts;");
            sb.AppendLine("using System.Xml.Linq;");
            sb.AppendLine("using Esint." + AppName + ".BLL;");
            sb.AppendLine("using Esint.Common.OracleDAL;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("namespace " + NameSpace);
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称："+Tbl.TableDescription+"列表 控件");
            sb.AppendLine("    /// 作    者：");
            sb.AppendLine("    /// 日    期："+DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 修改日期：");
            sb.AppendLine("    /// 修 改 人：");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class UC_" + Tbl.PascalName + "_List : BaseUserControl");
            sb.AppendLine("    {");
            sb.AppendLine("        //定义业务处理对象");
            sb.AppendLine("        " + Tbl.PascalName + "Service " + Tbl.CamelName + "Service = new " + Tbl.PascalName + "Service();");
            sb.AppendLine();
            sb.AppendLine("        #region 页面初始化");
            sb.AppendLine();
            sb.AppendLine("        protected void Page_Load(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (!IsPostBack)");
            sb.AppendLine("            {");
            sb.AppendLine("                //开始进行grid排序设置");
            for (int i = 0; i < Tbl.PrimaryKey.Columns.Count; i++)
            {
                IColumn col = Tbl.PrimaryKey.Columns[i];
                sb.AppendLine("                grd_" + Tbl.PascalName + ".Attributes.Add(\"SortExpression\", \"" + col.PascalName+ "\");");
                break;
            }
            sb.AppendLine("                grd_"+Tbl.PascalName+".Attributes.Add(\"SortDirection\", \"ASC\");");
            sb.AppendLine("                BindGridView();");
            sb.AppendLine("            }");
            sb.AppendLine();

            sb.AppendLine("            //设置新增按钮前台打开事件");
            sb.AppendLine("            string url = \"CommonFrame.aspx?url="+Tbl.PascalName+"Info.aspx\";");
            sb.AppendLine("            base.SetBtnOpenModalDialog(btn_Add, url, 600, 500);//打开窗口大小自行调整");  

            sb.AppendLine();
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #region 数据排序");
            sb.AppendLine();
            sb.AppendLine("        ///<summary>");
            sb.AppendLine("        ///grid排序方法");
            sb.AppendLine("        ///</summary>");
            sb.AppendLine("        protected void grd_"+Tbl.PascalName+"_Sorting(object sender, GridViewSortEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            // 从事件参数获取排序数据列");
            sb.AppendLine("            string sortExpression = e.SortExpression.ToString();");
            sb.AppendLine("            // 假定为排序方向为“顺序”");
            sb.AppendLine("            string sortDirection = \"ASC\";");
            sb.AppendLine("            // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改");
            sb.AppendLine("            if (sortExpression == this.grd_"+Tbl.PascalName+".Attributes[\"SortExpression\"])");
            sb.AppendLine("            {");
            sb.AppendLine("                //获得下一次的排序状态");
            sb.AppendLine("                sortDirection = (this.grd_"+Tbl.PascalName+".Attributes[\"SortDirection\"].ToString() == sortDirection ? \"DESC\" : \"ASC\");");
            sb.AppendLine("            }");
            sb.AppendLine("            // 重新设定GridView排序数据列及排序方向");
            sb.AppendLine("            this.grd_"+Tbl.PascalName+".Attributes[\"SortExpression\"] = sortExpression;");
            sb.AppendLine("            this.grd_"+Tbl.PascalName+".Attributes[\"SortDirection\"] = sortDirection;");
            sb.AppendLine("            this.BindGridView();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 数据绑定");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 绑定到GridView");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void BindGridView()");
            sb.AppendLine("        {");
            sb.AppendLine("            //// 获取GridView排序数据列及排序方向");
            sb.AppendLine("            string sortExpression = this.grd_"+Tbl.PascalName+".Attributes[\"SortExpression\"];");
            sb.AppendLine("            string sortDirection = this.grd_" + Tbl.PascalName + ".Attributes[\"SortDirection\"];");
            sb.AppendLine("");
            sb.AppendLine("            ////// 调用业务数据获取方法");
            sb.AppendLine("            DataTable dtBind = "+Tbl.CamelName + "Service.Get"+Tbl.PascalName+"InfoTable();");
            sb.AppendLine("");
            sb.AppendLine("            // 根据GridView排序数据列及排序方向设置显示的默认数据视图");
            sb.AppendLine("            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))");
            sb.AppendLine("            {");
            sb.AppendLine("                dtBind.DefaultView.Sort = string.Format(\"{0} {1}\", sortExpression, sortDirection);");
            sb.AppendLine("            }");
            sb.AppendLine("");
            sb.AppendLine("            // GridView绑定并显示数据");
            sb.AppendLine("            GridViewBinding(grd_" + Tbl.PascalName + ", dtBind);");
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 绑定DataGrid并显示数据");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"gridView\"></param>");
            sb.AppendLine("        /// <param name=\"dt\"></param>");
            sb.AppendLine("        public void GridViewBinding(GridView gridView, DataTable dt)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (dt.Rows.Count == 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                dt.Rows.Add(dt.NewRow());");
            sb.AppendLine("                gridView.DataSource = dt;");
            sb.AppendLine("                gridView.DataBind();");
            sb.AppendLine("                int columnCount = gridView.Rows[0].Cells.Count;");
            sb.AppendLine("                gridView.Rows[0].Cells.Clear();");
            sb.AppendLine("                gridView.Rows[0].Cells.Add(new TableCell());");
            sb.AppendLine("                gridView.Rows[0].Cells[0].ColumnSpan = columnCount;");
            sb.AppendLine("                gridView.Rows[0].Cells[0].Text = \"没有任何记录！\";");
            sb.AppendLine("                gridView.RowStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;");
            sb.AppendLine("                return ;");
            sb.AppendLine("            }");

            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                gridView.DataSource = dt;");
            sb.AppendLine("                gridView.DataBind();");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (gridView.PageIndex > 0)");
            sb.AppendLine("                { ");
            sb.AppendLine("                    gridView.PageIndex -= 1;");
            sb.AppendLine("                    GridViewBinding(gridView, dt);");
            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                    throw ex;");
            sb.AppendLine("             }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        protected void grd_"+Tbl.PascalName+"_RowDataBound(object sender, GridViewRowEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (e.Row.RowType==DataControlRowType.DataRow)");
            sb.AppendLine("            {   ");
            sb.AppendLine("                //设置是否删除提示");
            sb.AppendLine("                base.SetLinkButtonConfirmMsg(e.Row,\"lb_delete\",\"你确认要删除该记录吗？\");");
                
            sb.AppendLine("                //设置打开新窗口，修改");
            if (Tbl.PrimaryKey.Columns.Count==1)
                sb.AppendLine("                string url =\"CommonFrame.aspx?url=" + Tbl.PascalName + "Info.aspx?" + Tbl.PrimaryKey.Columns[0].CamelName + "=\"+Convert.ToString(grd_" + Tbl.PascalName + ".DataKeys[e.Row.RowIndex].Value);");
            else
            {         
                sb.AppendLine("               //在此修改打开窗口需传递的参数");
                sb.AppendLine("                string url =\"CommonFrame.aspx?url=" + Tbl.PascalName + "Info.aspx?" + Tbl.PrimaryKey.Columns[0].CamelName + "=\"+Convert.ToString(grd_" + Tbl.PascalName + ".DataKeys[e.Row.RowIndex].Value);");

            }
            sb.AppendLine("                LinkButton lb_edit = ((LinkButton)e.Row.FindControl(\"lb_edit\"));");
            sb.AppendLine("                base.SetBtnOpenModalDialog(lb_edit, url,600, 500);");
            sb.AppendLine("           }");

            sb.AppendLine("         }");
            sb.AppendLine();



            sb.AppendLine("        #endregion");
            sb.AppendLine("");
            sb.AppendLine("        #region 分页");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 分页事件");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\"></param>");
            sb.AppendLine("        /// <param name=\"e\"></param>");
            sb.AppendLine("        protected void grd_"+Tbl.PascalName+"_PageIndexChanging(object sender, GridViewPageEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            grd_"+Tbl.PascalName+".PageIndex = e.NewPageIndex;");
            sb.AppendLine("            BindGridView();");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        protected void grd_"+Tbl.PascalName+"_RowCommand(object sender, GridViewCommandEventArgs e)");
            sb.AppendLine("        {");
            if (Tbl.PrimaryKey.Columns.Count>1)
                sb.AppendLine("                    string[] cmdArg = e.CommandArgument.ToString().Split(',');");

            sb.AppendLine("            if (e.CommandName == \"RowDelete\")");
            sb.AppendLine("            {");
            //sb.AppendLine("                if (e.CommandName == \"RowDelete\")");
            //sb.AppendLine("                {");
            sb.AppendLine("                    ConfigrationInfo config = base.CurrentUser.configrationinfo;");
           // sb.AppendLine("                    config.OPName = base.CurrentUser.Username;");
            if (Tbl.PrimaryKey.Columns.Count==1)
                sb.AppendLine("                    "+Tbl.CamelName+"Service.Delete(e.CommandArgument.ToString(), config);");
            else
            {
                int x=0; string argstr = "";
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    if (col.DataType.CSharpType.ToUpper() != "STRING")
                        argstr+="(" + col.DataType.CSharpType + ")cmdArg[" + x + "],";
                    else
                        argstr+="cmdArg[" + x + "],";
                    x++;
                }
                sb.AppendLine("                    " + Tbl.CamelName + "Service.Delete("+argstr+"config);");
             
            }
            sb.AppendLine("                    BindGridView();");
            //sb.AppendLine("                 }");
            sb.AppendLine("            }");
            sb.AppendLine("            if (e.CommandName == \"RowEdit\")");
            sb.AppendLine("            {");

            if (Tbl.PrimaryKey.Columns.Count == 1)
                sb.AppendLine("                Response.Redirect(string.Format(\"" + Tbl.PascalName + "Info.aspx?"+Tbl.PrimaryKey.Columns[0].PascalName+"={0}\", e.CommandArgument));");
            else
            {

                int x = 0; string argstr = "";string  argurl = "";
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    argurl += col.PascalName + "={" + x + "}&";

                    if (col.DataType.CSharpType.ToUpper() != "STRING")
                        argstr += "(" + col.DataType.CSharpType + ")cmdArg[" + x + "],";
                    else
                        argstr += "cmdArg[" + x + "],";
                    x++;
                }
                argstr = argstr.Substring(0, argstr.Length - 1);
                argurl = argurl.Substring(0, argurl.Length - 1);
                sb.AppendLine("                Response.Redirect(string.Format(\"" + Tbl.PascalName + ".aspx?"+argurl+"\","+argstr+"));" );
            }
            
            
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 输入页码的翻页");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\"></param>");
            sb.AppendLine("        /// <param name=\"e\"></param>");
            sb.AppendLine("        protected void goPage_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            GridViewRow gvr = ((sender as LinkButton).Parent as TableCell).Parent as GridViewRow;");
            sb.AppendLine("            int PageNum;");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                PageNum = Convert.ToInt32((gvr.FindControl(\"wtxt_GoToPage\") as TextBox).Text);");
            sb.AppendLine("                if (PageNum <= this.grd_" + Tbl.PascalName + ".PageCount)");
            sb.AppendLine("                {");
            sb.AppendLine("                    grd_" + Tbl.PascalName + ".PageIndex = PageNum - 1;");
            sb.AppendLine("                    this.BindGridView();");
            sb.AppendLine("                }");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                return;");
            sb.AppendLine("             }");
            sb.AppendLine("         }");

            sb.AppendLine("         #endregion");

            sb.AppendLine("    }");
            sb.AppendLine("}");
            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format("UC_" + Tbl.PascalName + "_List.ascx.cs");
            returnCode.CodeType = "C#";
            return returnCode;
        }
        #endregion

        public IReturnCode GetListAspxDesignerCode()
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
            sb.AppendLine("namespace Esint." + AppName + ".Web {");
            sb.AppendLine("    ");
            sb.AppendLine("    ");
            sb.AppendLine("    public partial class UC_" + Tbl.PascalName + "_List {");

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// grd_"+Tbl.PascalName+" 控件。");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <remarks>");
            sb.AppendLine("        /// 自动生成的字段。");
            sb.AppendLine("        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。");
            sb.AppendLine("        /// </remarks>");
            sb.AppendLine("        protected global::System.Web.UI.WebControls.GridView grd_"+Tbl.PascalName+";");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            ReturnCode returnCode = new ReturnCode();
            returnCode.CodeText = sb;
            returnCode.FileName = String.Format("UC_" + Tbl.PascalName + "_List.ascx.designer.cs");
            returnCode.CodeType = "C#";
            return returnCode;
        }

        #region 辅助方法
        private string GetPrimaryParaList()
        {
            string str = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                str += col.CamelName + ",";
            }
            return str.Substring(0, str.Length - 1);
        }

        private string RequestQueryString()
        {
            string str = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                str += "!String.IsNullOrEmpty(Request.QueryString[\"" + col.PascalName + "\"])&&";
            }
            return str.Substring(0, str.Length - 2);
        }

        //获取绑定参数列表串

        private string GetArgumentsPrimaryList()
        {
            string str="";
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
