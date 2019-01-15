using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;

namespace Esint.Template.Factory
{
    public class Factory_001 : ITemplate
    {
        #region ITemplate 成员

        public string FileName { get; set; }

        public string NameSpace { get; set; }

        public IDbTable Tbl { get; set; }

        public string OperName { get; set; }

        public ICodeBuilder DataAccess { get; set; }

        public List<IDbTable> Tbls { get; set; }

        public bool IsPackage { get; set; }

        public IReturnCode[] GetCode()
        {
            IReturnCode[] returnCode = new IReturnCode[1];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".cs", Tbl.PascalName);

            if (Tbls == null || Tbls.Count == 0)
            {
                StringBuilder sb = new StringBuilder();
                GetBuilderCode(Tbl, sb);
                returnCode[0].CodeText = sb;
            }
            else
            {
                returnCode[0].CodeText = GetCsCode();
            }

            returnCode[0].CodeType = "C#";

            return returnCode;

        }
        #endregion

        private StringBuilder GetCsCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using Esint.Demo.IDAL;");
            sb.AppendLine("using System.Reflection;");
            sb.AppendLine();
            sb.AppendLine("namespace Esint.Demo.FactoryDAL");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称：DAL工厂类");
            sb.AppendLine("    /// 作    者：");
            sb.AppendLine("    /// 生成日期：");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public class Factory");
            sb.AppendLine("    {");
            sb.AppendLine("        private static readonly string profilePath = System.Configuration.ConfigurationSettings.AppSettings[\"DbAccess\"];");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 创建基础数据表访问对象");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public static IBaseData CreateBaseData()");
            sb.AppendLine("        {");
            sb.AppendLine("           string className = profilePath + \".BaseData\";");
            sb.AppendLine("           return (IBaseData)Assembly.Load(profilePath).CreateInstance(className);");
            sb.AppendLine("        }");
            foreach (IDbTable tbl in Tbls)
            {
                GetBuilderCode(tbl, sb);
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }

        

        private void GetBuilderCode(IDbTable tbl,StringBuilder sb)
        {
           // StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 创建" + tbl.TableDescription + "[" + tbl.TableName + "] 数据表访问对象");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public static I" + tbl.PascalName + "Data Create" + tbl.PascalName + "Data()");
            sb.AppendLine("        {");
            sb.AppendLine("            string className = profilePath + \"." + Tbl.PascalName + "Data\";");
            sb.AppendLine("            return (I" + tbl.PascalName + "Data)Assembly.Load(profilePath).CreateInstance(className);");
            sb.AppendLine("        }");
        }

        #region ITemplate 成员

        public string ConnectString
        {
            get;
            set;
        }

        public string DataBaseType
        {
            get;
            set;
        }

        #endregion
    }
}
