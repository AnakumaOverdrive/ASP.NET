using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.Template;

namespace Esint.CodeBuilder.Template
{
    public class IDAL : ITemplate
    {

        #region ITemplate 成员

        public string FileName { get; set; }

        public string NameSpace { get; set; }

        public IDbTable Tbl { get; set; }

        public string OperName { get; set; }

        public string ConnectString { get; set; }

        public ICodeBuilder DataAccess { get; set; }

        public List<IDbTable> Tbls { get; set; }

        public IReturnCode[] GetCode()
        {
            StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using System.Data;");
        sb.AppendLine("using Esint.Common.Data;");
        sb.AppendLine("using Esint." + NameSpace + ".Model;");
        sb.AppendLine("");
        sb.AppendLine("namespace Esint."+NameSpace+".IDAL");
        sb.AppendLine("{");
        sb.AppendLine("    public interface I"+Tbl.PascalName+"Data");
        sb.AppendLine("    {");
        sb.AppendLine("        void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", IDbTransaction trans);");
        sb.AppendLine("        void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ");");
        sb.AppendLine("        void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<WhereParameter> whereParaList, IDbTransaction trans);");
        sb.AppendLine("        void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", IDbTransaction trans);");
        sb.AppendLine("        void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<WhereParameter> whereParaList);");
        sb.AppendLine("        void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ");");
        sb.AppendLine("        void Delete(" + GetPrimaryParaList() + ");");
        sb.AppendLine("        void Delete(List<WhereParameter> whereParaList);");
        sb.AppendLine("        void Delete(List<WhereParameter> whereParaList, IDbTransaction trans);");
        sb.AppendLine("        void Delete(" + GetPrimaryParaList() + ", IDbTransaction trans);");
        sb.AppendLine("        " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ", IDbTransaction trans);");
        sb.AppendLine("        " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ");");
        sb.AppendLine("        List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "List(DataQuery dataQuery);");
        sb.AppendLine("        List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "List(DataQuery dataQuery, IDbTransaction trans);");
        sb.AppendLine("        bool IsExist(" + GetPrimaryParaList() + ");");
        sb.AppendLine("        bool IsExist(" + GetPrimaryParaList() + ", IDbTransaction trans);");
        sb.AppendLine("    }");
        sb.AppendLine("}");


            IReturnCode[] returnCode = new IReturnCode[1];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".cs", Tbl.PascalName);
            returnCode[0].CodeText = sb;
            returnCode[0].CodeType = "C#";
            return returnCode;

        }
        #endregion

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
