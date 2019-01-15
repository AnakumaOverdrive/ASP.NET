using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;

namespace Esint.Template.BLL
{
    public class BLL_01 : ITemplate
    {
        public IDbTable Tbl { get; set; }
        public string NameSpace { get; set; }
        public string FileName { get; set; }
        public string OperName { get; set; }
        public string ConnectString { get; set; }
        public ICodeBuilder DataAccess { get; set; }
        public List<IDbTable> Tbls { get; set; }
        public bool IsPackage { get; set; }


        public IReturnCode[] GetCode()
        {

            //============================================第一部分BLL.designer.cs(the first part)=================================
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using Esint." + DataAccess.AppName + ".Model;");

            if (DataAccess.DataBaseType.ToUpper() == "SQLSERVER")
                sb.AppendLine("using Esint." + DataAccess.AppName + ".SqlDAL;");

            if (DataAccess.DataBaseType.ToUpper() == "ORACLE")
                sb.AppendLine("using Esint." + DataAccess.AppName + ".OracleDAL;");
                sb.AppendLine("using Esint.Common.Model;");
                sb.AppendLine("using Esint.Common.Data;");
            //
            sb.AppendLine("");
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 文件说明: " + Tbl.TableDescription + " 业务逻辑层");
            sb.AppendLine("    /// 作    者: "+OperName);
            sb.AppendLine("    /// 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 模板版本: Esint.Template.BLL.BLL_01 版，适用于简单三层开发!");
            sb.AppendLine("    /// 特别说明: 本文件由代码生成工具自动生成，请勿轻易修改！" );
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + Tbl.PascalName + "Service");
            //Tbl.PascalName + "Info "
            sb.AppendLine("    {");

            sb.AppendLine("        private " + Tbl.PascalName + "Data dataAccess = new " + Tbl.PascalName + "Data();");

            //插入方法BLL
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入" + Tbl.PascalName + "Info 实体");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("        public void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            dataAccess.Insert(" + Tbl.CamelName + ");");
            sb.AppendLine("        }");
            sb.AppendLine();

            //更新方法BLL
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键更新" + Tbl.PascalName + "Info 实体");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("        public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            dataAccess.Update(" + Tbl.CamelName + ");");
            sb.AppendLine("        }");
            sb.AppendLine();

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键删除");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Delete(" + GetPrimaryParaList().Replace("?", "") + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            dataAccess.Delete(" + GetPrimaryParaListNoCsType() + ");");
            sb.AppendLine("        }");
            sb.AppendLine();

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键得到一个实体");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            return dataAccess.Get" + Tbl.PascalName + "Info(" + GetPrimaryParaListNoCsType() + ");");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("    }");
            sb.AppendLine("}");

            //==================================================End===========================================================

            //========================================第二部分BLL.cs开始(The second part)=============================
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("using System;");
            sb1.AppendLine("using System.Text;");
            sb1.AppendLine("using System.Collections;");
            sb1.AppendLine("using System.Collections.Generic;");
            sb1.AppendLine("using System.Data;");
            sb1.AppendLine("using Esint." + DataAccess.AppName + ".Model;");

            if (DataAccess.DataBaseType.ToUpper() == "SQLSERVER")
                sb1.AppendLine("using Esint." + DataAccess.AppName + ".SqlDAL;");

            if (DataAccess.DataBaseType.ToUpper() == "ORACLE")
                sb1.AppendLine("using Esint." + DataAccess.AppName + ".OracleDAL;");
            sb1.AppendLine("using Esint.Common.Model;");
            sb1.AppendLine("using Esint.Common.Data;");
            sb1.AppendLine("");
            sb1.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb1.AppendLine("{");
            sb1.AppendLine("    /// <summary>");
            sb1.AppendLine("    /// 文件说明: " + Tbl.TableDescription + " 业务逻辑层");
            sb1.AppendLine("    /// 作    者: " + OperName);
            sb1.AppendLine("    /// 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb1.AppendLine("    /// 模板版本: Esint.Template.BLL.BLL_01 版，适用于简单三层开发!");
            sb1.AppendLine("    /// 功能说明：");
            sb1.AppendLine("    /// </summary>");
            sb1.AppendLine("    public partial class " + Tbl.PascalName + "Service");
            sb1.AppendLine("    {");
            sb1.AppendLine("        /// <summary>");
            sb1.AppendLine("        /// 功    能: 保存"+Tbl.TableDescription +"对象");
            sb1.AppendLine("        /// 说    明: 当主键为空时，新增操作");
            sb1.AppendLine("        ///           当主键不为空，根据主键进行修改");
            sb1.AppendLine("        /// <summary>");
            sb1.AppendLine("        public void Save(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb1.AppendLine("        {");
            sb1.AppendLine("            if (" + GetCheckIsNullPrimaryList() + ")");
            sb1.AppendLine("            {");
            sb1.AppendLine("                 dataAccess.Insert(" + Tbl.CamelName + ");");
            sb1.AppendLine("            }");
            sb1.AppendLine("            else");
            sb1.AppendLine("            {");
            sb1.AppendLine("                 dataAccess.Update(" + Tbl.CamelName + ");");
            sb1.AppendLine("            }");
            sb1.AppendLine("        }");
            sb1.AppendLine("    }");
            sb1.AppendLine("}");
            //
            //===========================================End =========================================================

            ReturnCode[] returnCode = new ReturnCode[2];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".designer.cs", Tbl.PascalName);
            returnCode[0].CodeType = "C#";
            returnCode[0].CodeText = sb;
            returnCode[1] = new ReturnCode();
            returnCode[1].FileName = String.Format(FileName + ".cs", Tbl.PascalName);
            returnCode[1].CodeType = "C#";
            returnCode[1].CodeText = sb1;
            return returnCode;
        }

       /// <summary>
       ///获取主键列方法
       /// </summary>
       /// <returns></returns>
        private string GetPrimaryParaList()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                returnstr += col.DataType.CSharpType + " " + col.CamelName + ",";
            }
            returnstr = returnstr.Substring(0, returnstr.Length - 1);
            return returnstr;
        }

       /// <summary>
       /// 返回判断实体主键为空字符串
       /// </summary>
       /// <returns></returns>
        private string GetCheckIsNullPrimaryList()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = null;
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                if (col.DataType.CSharpType == "string")
                    returnstr += "String.IsNullOrEmpty(" + Tbl.CamelName + "." + col.PascalName + ") || ";
                else if (col.DataType.CSharpType.IndexOf('?') != -1)
                {
                    returnstr += "!" + Tbl.CamelName + "." + col.PascalName + ".HasValue || ";
                }
                else if (col.DataType.CSharpType=="Guid")
                {
                    returnstr += Tbl.CamelName + "." + col.PascalName + "==Guid.Empty";
                }
                else
                {
                    returnstr += "String.IsNullOrEmpty(Convert.ToString(" + Tbl.CamelName + "." + col.PascalName + ")) || ";
                }
            }
            if (returnstr.Substring(returnstr.Length - 3, 3) == "|| ")
                returnstr = returnstr.Substring(0, returnstr.Length - 3);
            return returnstr;
        }

       /// <summary>
       /// 返回不带类型的主键集合串
       /// </summary>
       /// <returns></returns>
        private string GetPrimaryParaListNoCsType()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                returnstr += col.CamelName + ",";
            }

            returnstr = returnstr.Substring(0, returnstr.Length - 1);
            return returnstr;
        }
    }
}
