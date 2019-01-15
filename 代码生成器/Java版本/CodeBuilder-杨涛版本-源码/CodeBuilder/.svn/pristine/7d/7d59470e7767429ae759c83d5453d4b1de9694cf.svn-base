using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.Template;



namespace Esint.CodeBuilder.Template
{
    public class Model : ITemplate
    {
        public IDbTable Tbl { get; set; }
        public string NameSpace { get; set; }
        public string FileName { get; set; }
        public string OperName { get; set; }
        public string ConnectString { get; set; }
        public ICodeBuilder DataAccess { get; set; }
        public List<IDbTable> Tbls { get; set; }


        public IReturnCode[] GetCode()
        {
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
            sb.AppendLine("namespace Esint." + NameSpace + ".Model");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// " + Tbl.TableDescription + "信息实体");
            sb.AppendLine("    /// 作    者:" + this.OperName);
            sb.AppendLine("    /// 生成日期:" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("   public partial class " + Tbl.PascalName + "Info : BaseModel");
            sb.AppendLine("   {");
            foreach (IColumn col in Tbl.Columns)
            {
                sb.AppendLine("     /// <summary>");
                sb.AppendLine("     /// " + col.Description);
                sb.AppendLine("     /// </summary>");
                sb.AppendLine("     public " + col.DataType.CSharpType + " " + col.PascalName + " { get; set; }");
                sb.AppendLine(" ");
            }
            sb.AppendLine("   }");
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
            sb.AppendLine("namespace Esint." + NameSpace + ".Model");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// " + Tbl.TableDescription + "信息实体");
            sb.AppendLine("    /// 作    者:" + this.OperName);
            sb.AppendLine("    /// 生成日期:" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("   public partial class " + Tbl.PascalName + "Info : BaseModel");
            sb.AppendLine("   {");
            sb.AppendLine("   ");
            sb.AppendLine("   }");
            sb.AppendLine("}");

            return sb;
        }


 
    }
}
