using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;

namespace Esint.Template.IDAL
{
    public class IDAL_001:ITemplate
    {
        #region ITemplate 成员

        public string FileName { get; set; }

        public string NameSpace { get; set; }

        public IDbTable Tbl { get; set; }

        public string OperName { get; set; }
        public string ConnectString { get; set; }

        public ICodeBuilder DataAccess { get; set; }

        public List<IDbTable> Tbls { get; set; }

        public bool IsPackage { get; set; }

        public IReturnCode[] GetCode()
        {
            IReturnCode[] returnCode = new IReturnCode[2];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".Designer.cs", Tbl.PascalName);
            returnCode[0].CodeText = GetDesignerCode();
            returnCode[0].CodeType = "C#";

            returnCode[1] = new ReturnCode();
            returnCode[1].FileName = String.Format(FileName + ".cs", Tbl.PascalName);
            returnCode[1].CodeText = GetCsCode();
            returnCode[1].CodeType = "C#";

            return returnCode;

        }
        #endregion

        private StringBuilder GetDesignerCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using Esint.Common.Data;");
            sb.AppendLine("using Esint." + NameSpace + ".Model;");
            sb.AppendLine("");
            sb.AppendLine("namespace Esint." + NameSpace + ".IDAL");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 接口说明: " + Tbl.TableDescription + " 表(" + Tbl.TableName + ") 数据访问层接口");
            sb.AppendLine("    /// 作    者:" + OperName);
            sb.AppendLine("    /// 日    期:" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 说    明: 本代码由系统自动生成,请勿随意修改其内容!");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial interface I" + Tbl.PascalName + "Data:IBaseData");
            sb.AppendLine("    {");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 将实体" + Tbl.TableDescription + "插入" + Tbl.PascalName + "表中");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\">" + Tbl.TableDescription + "实体</param>");
            sb.AppendLine("        void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ");");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键,更新实体" + Tbl.TableDescription + "(" + Tbl.PascalName + ")");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\">" + Tbl.TableDescription + "实体</param>");
            sb.AppendLine("        void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ");");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据Where参数列表,更新实体对象 非事务版");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\">" + Tbl.TableDescription + "实体</param>");
            sb.AppendLine("        /// <param name=\"whereParaList\">Where参数列表</param>");
            sb.AppendLine("        void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<IWhereParameter> whereParaList);");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键,删除实体对象 非事务版");
            sb.AppendLine("        /// </summary>");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("        /// <param name=\"" + col.CamelName + "\">" + col.Description + "</param>");
            }
            sb.AppendLine("        void Delete(" + GetPrimaryParaList() + ");");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据Where参数列表,删除实体对象 非事务版");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\">" + Tbl.TableDescription + "实体</param>");
            sb.AppendLine("        /// <param name=\"whereParaList\">Where参数列表</param>");
            sb.AppendLine("        void Delete(List<IWhereParameter> whereParaList);");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键查询 " + Tbl.TableDescription + "对象");
            sb.AppendLine("        /// </summary>");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("        /// <param name=\"" + col.CamelName + "\">" + col.Description + "</param>");
            }
            sb.AppendLine("        /// <returns> " + Tbl.TableDescription + "对象</returns>");
            sb.AppendLine("        " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ");");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据查询对象,查询 " + Tbl.TableDescription + "对象列表");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"dataQuery\">查询对象</param>");
            sb.AppendLine("        /// <returns> " + Tbl.TableDescription + "对象列表</returns>");
            sb.AppendLine("        List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "List(IDataQuery dataQuery);");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键,查询 " + Tbl.TableDescription + "对象是否存在");
            sb.AppendLine("        /// </summary>");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("        /// <param name=\"" + col.CamelName + "\">" + col.Description + "</param>");
            }
            sb.AppendLine("        /// <returns>true 存在,false 不存在</returns>");
            sb.AppendLine("        bool IsExist(" + GetPrimaryParaList() + ");");
            sb.AppendLine();
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }

        private StringBuilder GetCsCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using Esint.Common.Data;");
            sb.AppendLine("using Esint." + NameSpace + ".Model;");
            sb.AppendLine("");
            sb.AppendLine("namespace Esint." + NameSpace + ".IDAL");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 接口说明: " + Tbl.TableDescription + " 表(" + Tbl.TableName + ") 数据访问层接口");
            sb.AppendLine("    /// 作    者:" + OperName);
            sb.AppendLine("    /// 日    期:" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 说    明: 如需扩展,请在本文件中扩展");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial interface I" + Tbl.PascalName + "Data:IBaseData");
            sb.AppendLine("    {");
            sb.AppendLine("      ");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }
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
    }
}
