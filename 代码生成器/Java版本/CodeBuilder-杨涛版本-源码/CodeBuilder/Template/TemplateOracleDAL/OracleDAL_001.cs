using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;

namespace Esint.Template.OracleDAL
{
    public  class OracleDAL_001:ITemplate
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
            ReturnCode[] returnCode = new ReturnCode[2];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".Designer.cs", Tbl.PascalName);
            returnCode[0].CodeType = "C#";
            returnCode[0].CodeText = BuilderDesignerCode();
            returnCode[1] = new ReturnCode();
            returnCode[1].FileName = String.Format(FileName + ".cs", Tbl.PascalName);
            returnCode[1].CodeType = "C#";
            returnCode[1].CodeText = BuilderCode();
            return returnCode;
        }

        public StringBuilder BuilderDesignerCode()
        {
            string tempStr = "";
            int i = 0;//初始化变量

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using Esint.Common.Data;");
            sb.AppendLine("using Esint." + NameSpace + ".Model;");
            sb.AppendLine("using Oracle.DataAccess.Client;");
            sb.AppendLine();
            //
            sb.AppendLine("namespace Esint." + NameSpace + ".OracleDAL");
            sb.AppendLine("{");
            sb.AppendLine("");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称：" + Tbl.TableDescription + " 数据访问层");
            sb.AppendLine("    /// 作    者：" + OperName);
            sb.AppendLine("    /// 生成日期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + Tbl.PascalName + "Data  : BaseData");
            sb.AppendLine("    {");

            #region 插入数据方法模板


            sb.AppendLine("        #region 插入数据 ");
            sb.AppendLine();
            sb.AppendLine("        #region 插入数据方法集 ");
            sb.AppendLine();

            //插入数据非事务版
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入数据");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateInsertObject(" + Tbl.CamelName + ");");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();


            #region 构建插入SQL语句方法
            sb.AppendLine("        #region 构建插入SQL语句 ");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 构建插入SQL语句");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        private OperateObject CreateInsertObject(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("             BasicDataAccess basicDataAccess = new BasicDataAccess();");
            sb.AppendLine("            //建立插入的SQL语句,判断是否为空拼串");
            sb.AppendLine("            StringBuilder         strSql     = new StringBuilder();");
            sb.AppendLine("            List<IDataParameter> parameters = new List<IDataParameter>();");
            sb.AppendLine("            OracleParameter       para;");
            sb.AppendLine("            strSql.Append(\"INSERT INTO " + Tbl.TableName + " (\");");
            for (int column = 0; column < Tbl.Columns.Count; column++)
            {
                IColumn col = Tbl.Columns[column];
                if (col.IsPrimaryKey)
                {
                    sb.AppendLine("            if(" + Tbl.CamelName + "." + col.PascalName + " ==null)");
                    sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " =basicDataAccess.GetSequences(\"" + Tbl.TableName + "\", 15, \"YY\");");
                }
                sb.AppendLine();
                sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                //" + col.Description + "");
                string colLength = "";
                if (IsAllowColLength(col.DataType.CSharpType))
                {
                    colLength = "," + col.ColumnLength.ToString();
                }
                sb.AppendLine("                para = new OracleParameter(\":" + col.PascalName + "\",OracleDbType." + col.DataType.DbType + colLength + ");");
                sb.AppendLine("                para.Value = " + Tbl.CamelName + "." + col.PascalName + ";");
                sb.AppendLine("                parameters.Add(para);");
                sb.AppendLine("                strSql.Append(\"" + col.PascalName + ",\");");
                sb.AppendLine("            }");
            }
            sb.AppendLine("             if (strSql.ToString().Substring(strSql.Length - 1, 1) == \",\")");
            sb.AppendLine("                 strSql.Remove(strSql.Length - 1,1);");

            sb.AppendLine();
            sb.AppendLine("            strSql.Append(\") values (\");");
            for (int column = 0; column < Tbl.Columns.Count; column++)
            {
                IColumn col = Tbl.Columns[column];
                sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                strSql.Append(\":" + col.PascalName + ",\");");
                sb.AppendLine("            }");

            }
            sb.AppendLine("             if (strSql.ToString().Substring(strSql.Length - 1, 1) == \",\")");
            sb.AppendLine("                 strSql.Remove(strSql.Length - 1,1);");
            sb.AppendLine("            strSql.Append(\")\");");
            sb.AppendLine();
            sb.AppendLine("             //构建日志对象");
            sb.AppendLine("             OperateObject operObj = new OperateObject();");
            sb.AppendLine("             operObj.Parameters = parameters;");
            sb.AppendLine("             operObj.SqlText = strSql.ToString();");
            sb.AppendLine("             ");
            sb.AppendLine("             return operObj;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #endregion");

            sb.AppendLine();
            sb.AppendLine("        #endregion");
            #endregion

            #endregion

            #region 修改数据方法模板

            sb.AppendLine();
            sb.AppendLine("        #region 修改数据方法集");
            sb.AppendLine();
            //修改方法;(根据主键非事务版)
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 修改数据，根据主键修改数据");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            List<WhereParameter> whereParaList = new List<WhereParameter>();");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            whereParaList.Add(new WhereParameter(\"And " + col.PascalName + " = :" + col.PascalName + "\", \":" + col.PascalName + "\", " + Tbl.CamelName + "." + col.PascalName + "));");
            }
            sb.AppendLine("            ");
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateUpdateObject(" + Tbl.CamelName + ", whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine();
            //修改方法;(根据条件 非事务版)
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 修改数据，根据条件修改数据");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<WhereParameter> whereParaList)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (whereParaList == null || whereParaList.Count == 0)");
            sb.AppendLine("                throw new ArgumentException(\"根据条件更新,条件列表不能为空!\");");
            sb.AppendLine();
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateUpdateObject(" + Tbl.CamelName + ", whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine();

            #region  构建修改数据SQL方法


            sb.AppendLine("        #region 构建更新SQL语句 ");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 构建更新SQL语句");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"" + Tbl.CamelName + "\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        private OperateObject CreateUpdateObject(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<WhereParameter> whereList)");
            sb.AppendLine("        {");
            sb.AppendLine("            StringBuilder strSql = new StringBuilder();");
            sb.AppendLine("            List<IDataParameter> parameters = new  List<IDataParameter>();");
            sb.AppendLine("            OracleParameter para;");

            sb.AppendLine("            strSql.Append(\"update " + Tbl.TableName + " set \");");

            tempStr = "";
            foreach (IColumn col in Tbl.Columns)
            {
                string colLength = "";
                if (IsAllowColLength(col.DataType.CSharpType))
                {
                    colLength = "," + col.ColumnLength.ToString();
                }

                if (col.IsPrimaryKey == false)
                {
                    tempStr += "\r\n            if(" + Tbl.CamelName + "." + col.PascalName + "!=null)";
                    tempStr += "\r\n            {";
                    tempStr += "\r\n                //" + col.Description + "\r\n";
                    tempStr += "\r\n                para =  new OracleParameter(\":" + col.PascalName + "\",OracleDbType." + col.DataType.DbType + colLength + ");";
                    tempStr += "\r\n                para.Value = " + Tbl.CamelName + "." + col.PascalName + ";";
                    tempStr += "\r\n                parameters.Add(para);";
                    tempStr += "\r\n                strSql.Append(\"" + col.PascalName + "=:" + col.PascalName + ",\");";
                    tempStr += "\r\n            }";
                }
            }
            tempStr += "\r\n            if (strSql.ToString().Substring(strSql.Length - 1) == \",\")";
            tempStr += "\r\n                strSql.Remove(strSql.Length - 1, 1); ";
            tempStr += "\r\n ";
            //tempStr = tempStr.Substring(0, tempStr.Length - 4) + "\");";
            sb.AppendLine(tempStr);

            sb.AppendLine("             strSql.Append(\" Where 1=1  \");");
            sb.AppendLine("             ");
            sb.AppendLine("             // 如果条件不为空,则根据条件进行更新");
            sb.AppendLine("             foreach (WhereParameter wherePara in whereList)");
            sb.AppendLine("             {");
            sb.AppendLine("                 strSql.Append(\" \" + wherePara.WhereExpression);");
            sb.AppendLine("                 parameters.Add(new OracleParameter(wherePara.ParameterName, wherePara.Value));");
            sb.AppendLine("             }");
            sb.AppendLine("             ");
            sb.AppendLine("             //构建日志对象");
            sb.AppendLine("              OperateObject operObj = new OperateObject();");
            sb.AppendLine("             operObj.Parameters = parameters;");
            sb.AppendLine("             operObj.SqlText = strSql.ToString();");
            sb.AppendLine("              //构建返回对象");
            sb.AppendLine("             return operObj;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            #endregion

            #endregion

            #region 删除数据方法集

            #region 根据条件删除数据
            sb.AppendLine("        #region 删除方法集");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键删除非事务版");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"flag\"></param>");
            sb.AppendLine("        /// <param name=\"code\"></param>");
            sb.AppendLine("        public void Delete(" + GetPrimaryParaList() + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            List<WhereParameter> whereParaList = new List<WhereParameter>();");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            whereParaList.Add(new WhereParameter(\"And " + col.PascalName + " = :" + col.PascalName + "\", \":" + col.PascalName + "\", " + col.CamelName + "));");
            }
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateDeleteObject(whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据条件删除数据，");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Delete(List<WhereParameter> whereParaList)");
            sb.AppendLine("       {");
            sb.AppendLine("           //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateDeleteObject(whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #region 建立删除SQL对象 ");
            sb.AppendLine("        ");
            sb.AppendLine("        /// <summary>  ");
            sb.AppendLine("        /// 建立删除SQL对象  ");
            sb.AppendLine("        /// </summary>  ");
            sb.AppendLine("        /// <param name=\"whereParaList\"></param>  ");
            sb.AppendLine("        /// <param name=\"config\"></param>  ");
            sb.AppendLine("        /// <returns></returns>  ");
            sb.AppendLine("        private OperateObject CreateDeleteObject(List<WhereParameter> whereParaList) ");
            sb.AppendLine("        { ");
            sb.AppendLine("            StringBuilder strSql = new StringBuilder(); ");
            sb.AppendLine("            List<IDataParameter> parameters = new List<IDataParameter>(); ");
            sb.AppendLine(" ");
            sb.AppendLine("            strSql.Append(\"DELETE FROM " + Tbl.PascalName + " \"); ");
            sb.AppendLine("            strSql.Append(\" Where 1=1 \"); ");
            sb.AppendLine(" ");
            sb.AppendLine("            foreach (WhereParameter wherepara in whereParaList) ");
            sb.AppendLine("            { ");
            sb.AppendLine("                parameters.Add(new OracleParameter(wherepara.ParameterName, wherepara.Value)); ");
            sb.AppendLine("                strSql.Append(wherepara.WhereExpression); ");
            sb.AppendLine("            } ");
            sb.AppendLine(" ");
            sb.AppendLine("            //构建日志对象  ");
            sb.AppendLine("            OperateObject opereObj = new OperateObject(); ");
            sb.AppendLine("            opereObj.SqlText = strSql.ToString(); ");
            sb.AppendLine("            opereObj.Parameters = parameters; ");
            sb.AppendLine("            //构建返回对象  ");
            sb.AppendLine("           return opereObj; ");
            sb.AppendLine("        } ");
            sb.AppendLine("");
            sb.AppendLine("        #endregion ");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            #endregion
            #endregion

            sb.AppendLine();

            #region 查询方法集


            #region 根据主键查询得到实体(非事务版)
            sb.AppendLine();
            sb.AppendLine("        #region 根据主键查询得到实体");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键得到一个实体");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            StringBuilder strSql = new StringBuilder();");
            sb.AppendLine("            strSql.Append(\"select " + GetColumnsListString() + " from " + Tbl.TableName + "\");");
            sb.AppendLine("            strSql.Append(\" Where 1=1  \");");
            if (Tbl.PrimaryKey == null)
                sb.AppendLine("            throw new Exception(\"该表没有主键，不能调用该方法\");");
            else
            {
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    sb.AppendLine("            strSql.Append(\" And " + col.PascalName + " = :" + col.PascalName + "\");");
                }

                sb.AppendLine("            OracleParameter[] parameters = {");
                tempStr = "";
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    string colLength = "";
                    if (IsAllowColLength(col.DataType.CSharpType))
                    {
                        colLength = "," + col.ColumnLength.ToString();
                    }
                    tempStr += "\r\n                                              //" + col.Description + "\r\n";
                    tempStr += "                                                new OracleParameter(\":" + col.PascalName + "\",OracleDbType." + col.DataType.DbType + colLength + "),";
                }
                tempStr = tempStr.Substring(0, tempStr.Length - 1);
                sb.AppendLine(tempStr);
                sb.AppendLine("                                             };");
                i = 0;
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    sb.AppendLine("            parameters[" + i++ + "].Value = " + col.CamelName + ";//" + col.Description);
                }
            }

            sb.AppendLine("            " + Tbl.PascalName + "Info " + Tbl.CamelName + "=null;");
            sb.AppendLine("            using (IDbConnection connect = GetConnection())");
            sb.AppendLine("            {");
            sb.AppendLine("                using (IDataReader dr = basicDataAccess.ExecuteReader(connect, CommandType.Text, strSql.ToString(), parameters))");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (dr.Read())");
            sb.AppendLine("                    {");
            sb.AppendLine("                        " + Tbl.CamelName + " = Create" + Tbl.PascalName + "InfoByReader(dr);");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return " + Tbl.CamelName + ";");
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        #endregion");
            #endregion

            #region 根据查询参数，得到LIST对象列表

            sb.AppendLine();
            sb.AppendLine("        #region  根据查询参数，得到LIST对象列表");
            sb.AppendLine();
            //根据参数实体获取LIST对象列表
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据查询参数，得到LIST对象列表");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"OracleQuery\">查询参数</param>");
            sb.AppendLine("        /// <returns>List<></returns>");
            sb.AppendLine("        public List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "List(DataQuery dataQuery)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (dataQuery.JoinTables.Count > 0)");
            sb.AppendLine("                throw new ArgumentException(\"得到对象列表方法,只能执行单表查询!\");");

            sb.AppendLine("            List<" + Tbl.PascalName + "Info" + "> returnList = new List<" + Tbl.PascalName + "Info" + ">();");
            sb.AppendLine("            dataQuery.TableName = \"" + Tbl.TableName + "\";");
            sb.AppendLine("            using (IDbConnection connection = GetConnection())");
            sb.AppendLine("            {");
            sb.AppendLine("                using (IDataReader dr = basicDataAccess.ExecuteReader(connection,CommandType.Text,dataQuery, dataQuery.WhereParameters))");
            sb.AppendLine("                {");
            sb.AppendLine("                    while (dr.Read())");
            sb.AppendLine("                    {");
            sb.AppendLine("                        returnList.Add(Create" + Tbl.PascalName + "InfoByReader(dr));");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("                //读取记录数(Reading RecordCount)");
            sb.AppendLine("                if (dataQuery.IsPageView)");
            sb.AppendLine("                {");
            sb.AppendLine("                    dataQuery.RecordCount = basicDataAccess.GetRecordCount(connect,CommandType.Text, dataQuery, dataQuery.WhereParameters);");
            sb.AppendLine("                    dataQuery.PageCount = Convert.ToInt32(dataQuery.RecordCount / dataQuery.PageSize) + 1;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return returnList;");
            sb.AppendLine("        }");
            sb.AppendLine();


            //建立对象实体

            #region 建立对象实体
            sb.AppendLine();
            sb.AppendLine("        #region 建立对象实体");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 建立对象实体");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"dr\"></param>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        private " + Tbl.PascalName + "Info Create" + Tbl.PascalName + "InfoByReader(IDataReader dr)");
            sb.AppendLine("        {");
            sb.AppendLine("            " + Tbl.PascalName + "Info " + Tbl.CamelName + " = new " + Tbl.PascalName + "Info();");
            foreach (IColumn col in Tbl.Columns)
            {
                sb.AppendLine("            //" + col.Description);
                sb.AppendLine("            if (!Convert.IsDBNull(dr[\"" + col.PascalName + "\"]))");

                if (col.DataType.CSharpType.ToUpper() == "BYTE[]")
                    sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = (byte[])(dr[\"" + col.PascalName + "\"]);");
                else
                    sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(dr[\"" + col.PascalName + "\"]);");

                sb.AppendLine(" ");
            }


            sb.AppendLine("            return " + Tbl.CamelName + ";");
            sb.AppendLine("        }");


            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();
            sb.AppendLine("        #endregion");

            #endregion

            #endregion
            #endregion

            sb.AppendLine("    }");
            sb.AppendLine("} ");

            return sb;
        }

          public StringBuilder BuilderCode()
          {

              StringBuilder sb = new StringBuilder();
              sb.AppendLine("using System;");
              sb.AppendLine("using System.Collections.Generic;");
              sb.AppendLine("using System.Data;");
              sb.AppendLine("using System.Text;");
              sb.AppendLine("using Esint.Common.Data;");
              sb.AppendLine("using Esint." + NameSpace + ".Model;");
              sb.AppendLine("using Oracle.DataAccess.Client;");
              sb.AppendLine();
              //
              sb.AppendLine("namespace Esint." + NameSpace + ".OracleDAL");
              sb.AppendLine("{");
              sb.AppendLine("");
              sb.AppendLine("    /// <summary>");
              sb.AppendLine("    /// 模块名称：" + Tbl.TableDescription + " 数据访问层");
              sb.AppendLine("    /// 作    者：" + OperName);
              sb.AppendLine("    /// 生成日期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
              sb.AppendLine("    /// </summary>");
              sb.AppendLine("    public class " + Tbl.PascalName + "Data  : BaseData");
              sb.AppendLine("    {");
              
            sb.AppendLine("    }");
            sb.AppendLine("} ");

            return sb;
        }
        

        private string GetColumnsListString()
        {
            string colStr = "";
            foreach (IColumn col in Tbl.Columns)
            {
                colStr += col.PascalName + ",";
            }
            return colStr.Substring(0, colStr.Length - 1);
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

        private string GetPrimaryKeyType()
        {
            if (Tbl.PrimaryKey == null)
                return "void";
            else if (Tbl.PrimaryKey.Columns.Count == 1)
                return Tbl.PrimaryKey.Columns[0].DataType.CSharpType;
            else
                return "Dictionary<string, object> ";
        }

        /// <summary>
        /// 是否允许添加字段长度
        /// </summary>
        /// <param name="colType"></param>
        /// <returns></returns>
        private bool IsAllowColLength(string colType)
        {
            bool allowcolLength = true;//允许给定字段长度
            string[] types = new string[]{
                "DateTime","byte[]","int","int?","long","double","double?"
            };
            foreach (string coltypes in types)
            {
                if (colType == coltypes)
                {
                    allowcolLength = false;
                    break;
                }
            }
            return allowcolLength;
        }
    }
}
