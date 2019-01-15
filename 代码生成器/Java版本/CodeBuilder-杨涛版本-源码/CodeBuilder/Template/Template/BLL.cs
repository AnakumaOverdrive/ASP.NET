using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.Template;

namespace Esint.CodeBuilder.Template
{
    public class BLL : ITemplate
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
            
            //============================================第一部分BLL.designer.cs(the first part)=================================
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using Esint.Common.OracleDAL;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("using Esint."+NameSpace+".Model;");
            sb.AppendLine("using Esint."+NameSpace+".DAL;");
           //
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("namespace Esint." + NameSpace + ".BLL");
            sb.AppendLine("{");
            sb.AppendLine("");
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// " + Tbl.TableDescription);
            sb.AppendLine("/// </summary>");
            sb.AppendLine(" public partial class " + Tbl.PascalName + "Service");
             //Tbl.PascalName + "Info "
            sb.AppendLine(" {");

            sb.AppendLine("    private " + Tbl.PascalName + "Data dataAccess = new " + Tbl.PascalName + "Data();");


            //插入方法BLL
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// 插入"+Tbl.PascalName+"Info 实体方法(Insert "+Tbl.PascalName+"Info method)。");
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("    public void Insert("+Tbl.PascalName+"Info "+Tbl.CamelName +")");
            sb.AppendLine("    {");
            sb.AppendLine("       dataAccess.Insert(" + Tbl.CamelName + ");");
            sb.AppendLine("    }");

            //插入方法BLL,带事务版
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// 插入" + Tbl.PascalName + "Info 实体方法,带事务版(Insert " + Tbl.PascalName + "Info method)。");
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("    public void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ",IDbTransaction trans)");
            sb.AppendLine("    {");
            sb.AppendLine("       dataAccess.Insert(" + Tbl.CamelName + ", trans);");
            sb.AppendLine("    }");


            //更新方法BLL
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// 更新" + Tbl.PascalName + "Info 实体方法(Update " + Tbl.PascalName + "Info method)。");
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("    public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("    {");
            sb.AppendLine("       dataAccess.Update(" + Tbl.CamelName + ");");
            sb.AppendLine("    }");

            //更新方法BLL ,带事务版
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// 更新" + Tbl.PascalName + "Info 实体方法,带事务版(Update " + Tbl.PascalName + "Info method)。");
            sb.AppendLine("/// <summary>");
            sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("    public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ",IDbTransaction trans)");
            sb.AppendLine("    {");
            sb.AppendLine("       dataAccess.Update(" + Tbl.CamelName + ",trans);");
            sb.AppendLine("    }");


            


            ////根据主键删除方法BLL
            //sb.AppendLine("/// <summary>");
            //sb.AppendLine("/// 根据主键删除" + Tbl.PascalName + "Info 实体方法(Delete " + Tbl.PascalName + "Info by Primary key method)。");
            //sb.AppendLine("/// <summary>");
            //sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            //sb.AppendLine("    public void Delete(" + GetPrimaryParaList()+")");
            //sb.AppendLine("    {");
            //sb.AppendLine("       dataAccess.Delete(" + GetPrimaryParaListNoDataType.CSharpType() + ");");
            //sb.AppendLine("    }");

            ////根据主键删除方法BLL,带事务版
            //sb.AppendLine("/// <summary>");
            //sb.AppendLine("/// 根据list whereparas删除" + Tbl.PascalName + "Info 实体方法,带事务,日志版(Delete " + Tbl.PascalName + "Info by list method)。");
            //sb.AppendLine("/// <summary>");
            //sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            //sb.AppendLine("    public void Delete(List<WhereParameter> whereparaList,ConfigrationInfo configinfo, IDbTransaction trans)");
            //sb.AppendLine("    {");
            //sb.AppendLine("       dataAccess.Delete(whereparaList,configinfo, trans);");
            //sb.AppendLine("    }");

            ////根据实体包含主键删除方法BLL,带事务版
            //sb.AppendLine("/// <summary>");
            //sb.AppendLine("/// 根据list whereparas实体列表删除" + Tbl.PascalName + "Info 实体方法，日志版(Delete " + Tbl.PascalName + "Info by Primary list method)。");
            //sb.AppendLine("/// <summary>");
            //sb.AppendLine("/// <param name=\"" + Tbl.CamelName + "\"></param>");
            //sb.AppendLine("    public void Delete(List<WhereParameter> whereparaList, ConfigrationInfo configinfo)");
            //sb.AppendLine("    {");
            //sb.AppendLine("       dataAccess.Delete(whereparaList, configinfo);");
            //sb.AppendLine("    }");


            sb.AppendLine("   /// <summary>");
            sb.AppendLine("   /// 根据主键删除实体");
            sb.AppendLine("   /// </summary>");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("   /// <param name=\"" + col.CamelName + "\">" + col.Description + "</param>");
            }
            sb.AppendLine("   /// <param name=\"configInfo\"></param>");
            sb.AppendLine("   public void Delete(" + GetPrimaryParaList() + ",ConfigrationInfo configInfo)");
            sb.AppendLine("   {");
            sb.AppendLine("       List<WhereParameter> whereList = new List<WhereParameter>();");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("       whereList.Add(new WhereParameter(\" and " + col.PascalName + "=:" + col.PascalName + "\", \":" + col.PascalName + "\", " + col.CamelName + "));");
            }
            sb.AppendLine("       dataAccess.Delete(whereList, configInfo);");
            sb.AppendLine("   }");







            //得到一个实体方法BLL
            sb.AppendLine("   /// <summary>");
            sb.AppendLine("   /// 根据主键得到一个实体");
            sb.AppendLine("   /// </summary>");
            sb.AppendLine("   /// <returns></returns>");
            sb.AppendLine("   public " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ")");
            sb.AppendLine("   {");
            sb.AppendLine("      return dataAccess.Get" + Tbl.PascalName + "Info(" + GetPrimaryParaListNoCsType() + ");");
            sb.AppendLine("   }");

            //根据主键获取List
            sb.AppendLine("   /// <summary>");
            sb.AppendLine("   /// 根据OracleQuery获取List<"+Tbl.PascalName + "Info>列表");
            sb.AppendLine("   /// </summary>");
            sb.AppendLine("   /// <returns></returns>");
            sb.AppendLine("   public List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "Info()");
            sb.AppendLine("   {");
            sb.AppendLine("       OracleQuery oracleQuery = new OracleQuery();");
            sb.AppendLine("       return dataAccess.Get" + Tbl.PascalName + "InfoList(oracleQuery);");
            sb.AppendLine("   }");
           


            //根据主键获取List
            sb.AppendLine("   /// <summary>");
            sb.AppendLine("   /// 根据OracleQuery实体获取查询列表");
            sb.AppendLine("   /// </summary>");
            sb.AppendLine("   /// <returns>DataTable</returns>");
            sb.AppendLine("   public DataTable Get" + Tbl.PascalName + "InfoTable()");
            sb.AppendLine("   {");
         

            sb.AppendLine("       OracleQuery oracleQuery = new OracleQuery();");
          //  sb.AppendLine("       oracleQuery.TableName = \"" + Tbl.TableName + "\";//表名");
            sb.AppendLine("       return dataAccess.Get" + Tbl.PascalName + "InfoTable(oracleQuery);");
            sb.AppendLine("   }");
              
            sb.AppendLine("        #region 联合查询使用demo ");
            sb.AppendLine("        ////OracleQuery使用 demo======================================================");
            sb.AppendLine("       //OracleQuery oracleQuery = new OracleQuery();");
            sb.AppendLine("        //oracleQuery.TableName = \"Table1\";//表名");
            sb.AppendLine("        //oracleQuery.TableAsName = \"A\";//表别名");
            sb.AppendLine("        //oracleQuery.FieldString = \" * \";//需要字段如果不是*每个字段间用\", \"连");
            sb.AppendLine("        //oracleQuery.IsPageView = true;//是否分页 ");
            sb.AppendLine("        //oracleQuery.PageSize = 10;//每页条数");
            sb.AppendLine("        //oracleQuery.PageIndex = 2;//当前页码");
            sb.AppendLine("        //oracleQuery.joinObjectlist = new JoinObjectList();//如果多表关联时,这里为另外表的控制类");
            sb.AppendLine("        //oracleQuery.WhereParameters = new WhereParameter[] { ");
            sb.AppendLine("        //                             new WhereParameter(\" and UserId=:UserId\",\":UserID\",UserId)};//按参数传递时参数数组集合，这是\":\"表示而不用\"@\"");
            sb.AppendLine("        //oracleQuery.WhereString = \"and UserId=\"+UserId;//用一般字符串传值;");
            sb.AppendLine("        ////=========================================================================");
            sb.AppendLine("        #endregion ");
            sb.AppendLine("  }");
            sb.AppendLine(" }");

            //==================================================End===========================================================

            //========================================第二部分BLL.cs开始(The second part)=============================
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("using System;");
            sb1.AppendLine("using System.Text;");
            sb1.AppendLine("using System.Collections;");
            sb1.AppendLine("using System.Collections.Generic;");
            sb1.AppendLine("using System.Data;");
            sb1.AppendLine("using Esint.Common.OracleDAL;");
            sb1.AppendLine("using Esint.Common.Model;");
            sb1.AppendLine("using Esint." + NameSpace + ".Model;");
            sb1.AppendLine("using Esint." + NameSpace + ".DAL;");
            sb1.AppendLine("");
            sb1.AppendLine("");
            sb1.AppendLine("namespace Esint." + NameSpace + ".BLL");
            sb1.AppendLine("{");
            sb1.AppendLine("");
            sb1.AppendLine("/// <summary>");
            sb1.AppendLine("/// " + Tbl.TableDescription);
            sb1.AppendLine("/// </summary>");
            sb1.AppendLine("    public partial class " + Tbl.PascalName + "Service");
            sb1.AppendLine("    {");
            sb1.AppendLine("       public void Save(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb1.AppendLine("       {");

            sb1.AppendLine("           if ("+GetCheckIsNullPrimaryList()+")");
            sb1.AppendLine("           {");
            sb1.AppendLine("                dataAccess.Insert(" + Tbl.CamelName + ");");
            sb1.AppendLine("           }");
            sb1.AppendLine("           else");
            sb1.AppendLine("           {");
            sb1.AppendLine("                dataAccess.Update(" + Tbl.CamelName + ");");
            sb1.AppendLine("           }");
            sb1.AppendLine("       }");
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
                returnstr += "String.IsNullOrEmpty(" + Tbl.CamelName + "." + col.PascalName + ") || ";
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
