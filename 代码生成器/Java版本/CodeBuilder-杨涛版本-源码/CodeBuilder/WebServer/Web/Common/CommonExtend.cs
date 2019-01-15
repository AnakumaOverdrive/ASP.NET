using System;
using System.Collections.Generic;
using System.Web;
using Esint.CodeSite.Model;
using Esint.CodeSite.BLL;
using System.Data;
using System.Text;

namespace Esint.CodeSite.Web
{
    public static class CommonExtend
    {
        /// <summary>
        /// 绑定列表框代码项
        /// 作者：刘伟通
        /// 日期：2010年4月
        /// </summary>
        /// <param name="DropDownListControl"></param>
        /// <param name="CodeType"></param>
        public static void CodeBinding(this System.Web.UI.WebControls.DropDownList DropDownListControl, string CodeType)
        {
            CodeBinding(DropDownListControl, CodeType, true);
        }

        public static void CodeBinding(this System.Web.UI.WebControls.DropDownList DropDownListControl, string CodeType,bool isAll)
        {
            Sys_CodeService codeService = new Sys_CodeService();
            if (HttpContext.Current.Cache["code_" + CodeType] == null)
            {
                List<Sys_CodeInfo> allCode = codeService.GetCodeListByFlag(CodeType);
                HttpContext.Current.Cache.Add("code_" + CodeType, allCode, null, DateTime.MaxValue, new TimeSpan(0, 10, 0), System.Web.Caching.CacheItemPriority.Default, null);
            }
            DropDownListControl.DataSource = ((List<Sys_CodeInfo>)HttpContext.Current.Cache["code_" + CodeType]);// codeService.GetCodeListByFlag(CodeType);
            DropDownListControl.DataTextField = "Meaning";
            DropDownListControl.DataValueField = "Code";
            DropDownListControl.DataBind();
            if (isAll)
            DropDownListControl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("请选择", ""));
        }



        /// <summary>
        /// 绑定列表框代码项（支持过滤条件）
        /// 作者：刘伟通
        /// 日期：2010年5月
        /// </summary>
        /// <param name="DropDownListControl"></param>
        /// <param name="CodeType"></param>
        /// <param name="filter"></param>
        public static void CodeBinding(this System.Web.UI.WebControls.DropDownList DropDownListControl, string CodeType, System.Predicate<Sys_CodeInfo> filter)
        {
            Sys_CodeService codeService = new Sys_CodeService();
            DropDownListControl.DataSource = codeService.GetCodeListByFlag(CodeType);
            DropDownListControl.DataTextField = "Meaning";
            DropDownListControl.DataValueField = "Code";
            DropDownListControl.DataBind();
            DropDownListControl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("请选择", ""));
        }

        /// <summary>
        /// 将超过长度的字符替换为（.....）
        /// 王超
        /// </summary>
        /// <param name="Cell">列</param>
        /// <param name="L">长度</param>
        public static void CellLength(this System.Web.UI.WebControls.TableCell Cell, int L)
        {
            if (Cell.Text.Length > L)
            {
                Cell.ToolTip = Cell.Text;
                Cell.Text = Cell.Text.Substring(0, L) + "....";
            }
        }

        /// <summary>
        /// 将HTML标记替换为(br)
        /// 王超
        /// </summary>
        /// <param name="Cell">列</param>
        /// <param name="L">长度</param>
        public static void LabelReplace(this System.Web.UI.WebControls.Label Label)
        {
            Label.Text = Label.Text.Replace("\r\n", "<br />");
        }
        public static System.Text.StringBuilder ExportExcel(this System.Data.DataTable dt,  int expRows)
        {

            //这里定义下载文件的名称
            string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString() + ".xls";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<?xml  version=\"1.0\"?>");
            sb.AppendLine("<?mso-application  progid=\"Excel.Sheet\"?>");
            sb.AppendLine("<Workbook  xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            sb.AppendLine("  xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            sb.AppendLine("  xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            sb.AppendLine("  xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            sb.AppendLine("  xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
            sb.AppendLine("  <DocumentProperties  xmlns=\"urn:schemas-microsoft-com:office:office\">");
            sb.AppendLine("    <Author>liuweitong</Author>");
            sb.AppendLine(string.Format("    <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
            sb.AppendLine("    <Company></Company>");
            sb.AppendLine("    <Version>11.5606</Version>");
            sb.AppendLine("  </DocumentProperties>");
            sb.AppendLine("  <ExcelWorkbook  xmlns=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("    <WindowHeight>8955</WindowHeight>");
            sb.AppendLine("    <WindowWidth>11355</WindowWidth>");
            sb.AppendLine("    <WindowTopX>480</WindowTopX>");
            sb.AppendLine("    <WindowTopY>15</WindowTopY>");
            sb.AppendLine("    <ProtectStructure>False</ProtectStructure>");
            sb.AppendLine("    <ProtectWindows>False</ProtectWindows>");
            sb.AppendLine("  </ExcelWorkbook>");
            sb.AppendLine("  <Styles>");
            sb.AppendLine("    <Style  ss:ID=\"Default\"  ss:Name=\"Normal\">");
            sb.AppendLine("      <Alignment  ss:Vertical=\"Center\"/>");
            sb.AppendLine("      <Borders/>");
            sb.AppendLine("      <Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"12\"/>");
            sb.AppendLine("      <Interior/>");
            sb.AppendLine("      <NumberFormat/>");
            sb.AppendLine("      <Protection/>");
            sb.AppendLine("    </Style>");
            sb.AppendLine("  <Style ss:ID=\"s21\">");
            sb.AppendLine("   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\" ss:WrapText=\"1\"/>");
            sb.AppendLine("   <Borders>");
            sb.AppendLine("    <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("   </Borders>");
            sb.AppendLine("   <Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Bold=\"1\"/>");
            sb.AppendLine("   <Interior ss:Color=\"#CCCCCC\" ss:Pattern=\"Solid\"/>");
            sb.AppendLine("   <NumberFormat/>");
            sb.AppendLine("   <Protection/>");
            sb.AppendLine("  </Style>");
            sb.AppendLine("  <Style ss:ID=\"s22\">");
            sb.AppendLine("   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\" ss:WrapText=\"1\"/>");
            sb.AppendLine("   <Borders>");
            sb.AppendLine("    <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("   </Borders>");
            sb.AppendLine("   <Font ss:FontName=\"宋体\" x:CharSet=\"134\"/>");
            sb.AppendLine("   <Interior/>");
            sb.AppendLine("   <NumberFormat/>");
            sb.AppendLine("   <Protection/>");
            sb.AppendLine("  </Style>");
            sb.AppendLine("  </Styles>");
            sb.AppendLine("   <Worksheet ss:Name=\"导出结果\">");
            sb.AppendLine("  <Table ss:ExpandedColumnCount=\"256\" ss:ExpandedRowCount=\"" + (dt.Rows.Count + 1).ToString() + "\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultColumnWidth=\"40\" ss:DefaultRowHeight=\"20\">");
            sb.AppendLine("   <Column ss:AutoFitWidth=\"0\" ss:Width=\"108\" ss:Span=\"255\"/>");
            sb.AppendLine("         <Row ss:AutoFitHeight=\"0\">");

            foreach (DataColumn df in dt.Columns)
            {
            
                    sb.AppendLine("    <Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">" + df.ColumnName + "</Data></Cell>");
            }

            sb.AppendLine("   </Row>");

            //这里使用DataTable循环读取数据 
            int rowCount = 0;
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("<Row ss:AutoFitHeight=\"0\">");
                int i = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.AppendLine("    <Cell ss:StyleID=\"s22\"><Data ss:Type=\"String\">" + row[i].ToString().Replace("<", "").Replace(">", "") + "</Data></Cell>");
                    i++;
                }

                sb.AppendLine("</Row>");
                rowCount++;
                if (rowCount > expRows)
                    break;
            }
            sb.AppendLine("    </Table>");
            sb.AppendLine("      <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("       <Unsynced/>");
            sb.AppendLine("       <Selected/>");
            sb.AppendLine("       <LeftColumnVisible>2</LeftColumnVisible>");
            sb.AppendLine("       <ProtectObjects>False</ProtectObjects>");
            sb.AppendLine("       <ProtectScenarios>False</ProtectScenarios>");
            sb.AppendLine("      </WorksheetOptions>");
            sb.AppendLine("  </Worksheet>");
            sb.AppendLine("</Workbook>");


            //System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;
            //string filePath = page.Server.MapPath("..//Excel//"+fileName);
            //System.IO.StreamWriter sw = System.IO.File.CreateText(filePath);
            //sw.Write(tw.ToString());
            ////tw.Flush();
            //tw.Close();
            //sw.Flush();
            //sw.Close();
            return sb;
        }


        public static System.Text.StringBuilder ExportExcel(this System.Data.DataTable dt, System.Web.UI.WebControls.GridView gv2, int expRows)
        {

            //这里定义下载文件的名称
            string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString() + ".xls";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<?xml  version=\"1.0\"?>");
            sb.AppendLine("<?mso-application  progid=\"Excel.Sheet\"?>");
            sb.AppendLine("<Workbook  xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            sb.AppendLine("  xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            sb.AppendLine("  xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            sb.AppendLine("  xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            sb.AppendLine("  xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
            sb.AppendLine("  <DocumentProperties  xmlns=\"urn:schemas-microsoft-com:office:office\">");
            sb.AppendLine("    <Author>liuweitong</Author>");
            sb.AppendLine(string.Format("    <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
            sb.AppendLine("    <Company></Company>");
            sb.AppendLine("    <Version>11.5606</Version>");
            sb.AppendLine("  </DocumentProperties>");
            sb.AppendLine("  <ExcelWorkbook  xmlns=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("    <WindowHeight>8955</WindowHeight>");
            sb.AppendLine("    <WindowWidth>11355</WindowWidth>");
            sb.AppendLine("    <WindowTopX>480</WindowTopX>");
            sb.AppendLine("    <WindowTopY>15</WindowTopY>");
            sb.AppendLine("    <ProtectStructure>False</ProtectStructure>");
            sb.AppendLine("    <ProtectWindows>False</ProtectWindows>");
            sb.AppendLine("  </ExcelWorkbook>");
            sb.AppendLine("  <Styles>");
            sb.AppendLine("    <Style  ss:ID=\"Default\"  ss:Name=\"Normal\">");
            sb.AppendLine("      <Alignment  ss:Vertical=\"Center\"/>");
            sb.AppendLine("      <Borders/>");
            sb.AppendLine("      <Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Size=\"12\"/>");
            sb.AppendLine("      <Interior/>");
            sb.AppendLine("      <NumberFormat/>");
            sb.AppendLine("      <Protection/>");
            sb.AppendLine("    </Style>");
            sb.AppendLine("  <Style ss:ID=\"s21\">");
            sb.AppendLine("   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\" ss:WrapText=\"1\"/>");
            sb.AppendLine("   <Borders>");
            sb.AppendLine("    <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("   </Borders>");
            sb.AppendLine("   <Font ss:FontName=\"宋体\" x:CharSet=\"134\" ss:Bold=\"1\"/>");
            sb.AppendLine("   <Interior ss:Color=\"#CCCCCC\" ss:Pattern=\"Solid\"/>");
            sb.AppendLine("   <NumberFormat/>");
            sb.AppendLine("   <Protection/>");
            sb.AppendLine("  </Style>");
            sb.AppendLine("  <Style ss:ID=\"s22\">");
            sb.AppendLine("   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\" ss:WrapText=\"1\"/>");
            sb.AppendLine("   <Borders>");
            sb.AppendLine("    <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("    <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
            sb.AppendLine("   </Borders>");
            sb.AppendLine("   <Font ss:FontName=\"宋体\" x:CharSet=\"134\"/>");
            sb.AppendLine("   <Interior/>");
            sb.AppendLine("   <NumberFormat/>");
            sb.AppendLine("   <Protection/>");
            sb.AppendLine("  </Style>");
            sb.AppendLine("  </Styles>");
            sb.AppendLine("   <Worksheet ss:Name=\"导出结果\">");
            sb.AppendLine("  <Table ss:ExpandedColumnCount=\"256\" ss:ExpandedRowCount=\"" + (dt.Rows.Count + 1).ToString() + "\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultColumnWidth=\"40\" ss:DefaultRowHeight=\"20\">");
            sb.AppendLine("   <Column ss:AutoFitWidth=\"0\" ss:Width=\"108\" ss:Span=\"255\"/>");
            sb.AppendLine("         <Row ss:AutoFitHeight=\"0\">");

            foreach (DataColumn df in dt.Columns)
            {
       
                    sb.AppendLine("    <Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">" + df.ColumnName + "</Data></Cell>");
            }

            sb.AppendLine("   </Row>");

            //这里使用DataTable循环读取数据 
            int rowCount = 0;
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("<Row ss:AutoFitHeight=\"0\">");
                int i = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.AppendLine("    <Cell ss:StyleID=\"s22\"><Data ss:Type=\"String\">" + row[i].ToString().Replace("<", "").Replace(">", "") + "</Data></Cell>");
                    i++;
                }

                sb.AppendLine("</Row>");
                rowCount++;
                if (rowCount > expRows)
                    break;
            }
            sb.AppendLine("    </Table>");
            sb.AppendLine("      <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("       <Unsynced/>");
            sb.AppendLine("       <Selected/>");
            sb.AppendLine("       <LeftColumnVisible>2</LeftColumnVisible>");
            sb.AppendLine("       <ProtectObjects>False</ProtectObjects>");
            sb.AppendLine("       <ProtectScenarios>False</ProtectScenarios>");
            sb.AppendLine("      </WorksheetOptions>");
            sb.AppendLine("  </Worksheet>");
            sb.AppendLine("</Workbook>");


            //System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;
            //string filePath = page.Server.MapPath("..//Excel//"+fileName);
            //System.IO.StreamWriter sw = System.IO.File.CreateText(filePath);
            //sw.Write(tw.ToString());
            ////tw.Flush();
            //tw.Close();
            //sw.Flush();
            //sw.Close();
            return sb;
        }





    }
}
