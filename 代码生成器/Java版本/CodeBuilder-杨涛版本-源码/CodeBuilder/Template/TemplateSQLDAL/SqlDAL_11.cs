using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;


namespace Esint.Template.SqlDAL
{
    public class SqlDAL_11 : ITemplate
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
            sb.AppendLine("using Esint." + DataAccess.AppName + ".IDAL;");
            sb.AppendLine("using Esint." + DataAccess.AppName + ".Model;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine();
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称：" + Tbl.TableDescription + " 数据访问层");
            sb.AppendLine("    /// 作    者：" + OperName);
            sb.AppendLine("    /// 生成日期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版");
            sb.AppendLine("    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + Tbl.PascalName + "Data  : BaseData, I" + Tbl.PascalName + "Data");
            sb.AppendLine("    {");

            #region 插入数据方法模板

            sb.AppendLine("        #region 插入数据 ");
            sb.AppendLine();

            //插入数据非事务版
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入数据");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateInsertObject(" + Tbl.CamelName + ");");
            if (IsIndentityPrimary(Tbl))
            {
                sb.AppendLine("        object indent = base.ExecuteScalar(operateObject);");
                sb.AppendLine("        " + Tbl.CamelName + "." + Tbl.PrimaryKey.Columns[0].PascalName + " = Convert.ToInt32(indent);");
            }
            else
            {
                sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            }
            //如果主键是标识列,则查询标识,并返回

            sb.AppendLine("        }");
            sb.AppendLine();


            //插入数据非事务版
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入数据(事务版)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Insert(" + Tbl.PascalName + "Info " + Tbl.CamelName + ",IDbTransaction trans)");
            sb.AppendLine("        {");
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateInsertObject(" + Tbl.CamelName + ");");


            if (IsIndentityPrimary(Tbl))
            {
                sb.AppendLine("        object indent = base.ExecuteScalar(operateObject,trans);");
                sb.AppendLine("        " + Tbl.CamelName + "." + Tbl.PrimaryKey.Columns[0].PascalName + " = Convert.ToInt32(indent);");
            }
            else
            {
                sb.AppendLine("            base.ExecuteNonQuery(operateObject,trans);");
            }
            sb.AppendLine("        }");
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
            sb.AppendLine("            SqlParameter para;");
            sb.AppendLine("            strSql.Append(\"INSERT INTO " + Tbl.TableName + " (\");");
            for (int column = 0; column < Tbl.Columns.Count; column++)
            {
                IColumn col = Tbl.Columns[column];
                if (col.IsIndentity) continue;

                if (col.IsPrimaryKey)  //如果不是标识列主键 
                {
                    if (col.DataType.CSharpType == "Guid")
                    {
                        sb.AppendLine("            if(" + Tbl.CamelName + "." + col.PascalName + " ==Guid.Empty)");
                        sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = Guid.NewGuid();");
                    }
                }
                sb.AppendLine();

                if (col.DataType.CSharpType == "Guid")
                    sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " != Guid.Empty)");
                else
                    sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " != null)");

                sb.AppendLine("            {");
                sb.AppendLine("                //" + col.Description + "");

                if (col.DataType.AutoWidth)
                    sb.AppendLine("                para = new SqlParameter(\"@" + col.PascalName + "\",SqlDbType." + col.DataType.DbType + ");");
                else
                    sb.AppendLine("                para = new SqlParameter(\"@" + col.PascalName + "\",SqlDbType." + col.DataType.DbType + "," + col.ColumnLength.Value.ToString() + ");");

                sb.AppendLine("                para.Value = " + Tbl.CamelName + "." + col.PascalName + ";");
                sb.AppendLine("                parameters.Add(para);");
                sb.AppendLine("                strSql.Append(\"" + col.ColumnName + ",\");");
                sb.AppendLine("            }");
            }
            sb.AppendLine("             if (strSql.ToString().Substring(strSql.Length - 1, 1) == \",\")");
            sb.AppendLine("                 strSql.Remove(strSql.Length - 1,1);");

            sb.AppendLine();
            sb.AppendLine("            strSql.Append(\") values (\");");
            for (int column = 0; column < Tbl.Columns.Count; column++)
            {
                IColumn col = Tbl.Columns[column];
                if (col.DataType.CSharpType == "Guid")
                    sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " != Guid.Empty)");
                else
                    sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                strSql.Append(\"@" + col.PascalName + ",\");");
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

            if (this.IsIndentityPrimary(Tbl))
            {
                sb.AppendLine("             operObj.SqlText += \" select @@identity \";");
            }

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
            sb.AppendLine("            List<IWhereParameter> whereParaList = new List<IWhereParameter>();");
            sb.AppendLine("");
            if (Tbl.PrimaryKey != null)
            {
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " == null)");
                    sb.AppendLine("                throw new ArgumentException(\"根据主键更新表(" + Tbl.TableName + "),主键(" + col.PascalName + ")不能为空!\");");
                    sb.AppendLine("");

                }

                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    sb.AppendLine("            whereParaList.Add(new WhereParameter(\"And " + col.ColumnName + " = @" + col.PascalName + "\", \"@" + col.PascalName + "\", " + Tbl.CamelName + "." + col.PascalName + "));");
                }
            }
            sb.AppendLine();
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateUpdateObject(" + Tbl.CamelName + ", whereParaList);");
            sb.AppendLine();
            sb.AppendLine("                base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine();

            //修改方法;(根据主键事务版)
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 修改数据，根据主键修改数据(事务版)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ",IDbTransaction trans)");
            sb.AppendLine("        {");
            sb.AppendLine("            List<IWhereParameter> whereParaList = new List<IWhereParameter>();");
            sb.AppendLine("");
            if (Tbl.PrimaryKey != null)
            {
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    sb.AppendLine("            if (" + Tbl.CamelName + "." + col.PascalName + " == null)");
                    sb.AppendLine("                throw new ArgumentException(\"根据主键更新表(" + Tbl.TableName + "),主键(" + col.PascalName + ")不能为空!\");");
                    sb.AppendLine("");
                }

                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    sb.AppendLine("            whereParaList.Add(new WhereParameter(\"And " + col.ColumnName + " = @" + col.PascalName + "\", \"@" + col.PascalName + "\", " + Tbl.CamelName + "." + col.PascalName + "));");
                }
            }
            sb.AppendLine();
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateUpdateObject(" + Tbl.CamelName + ", whereParaList);");
            sb.AppendLine();
            sb.AppendLine("            base.ExecuteNonQuery(operateObject,trans);");
            sb.AppendLine("        }");
            sb.AppendLine();


            //修改方法;(根据条件 非事务版)
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 修改数据，根据条件修改数据(非事务版)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<IWhereParameter> whereParaList)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (whereParaList == null || whereParaList.Count == 0)");
            sb.AppendLine("                throw new ArgumentException(\"根据条件更新,条件列表不能为空!\");");
            sb.AppendLine();
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateUpdateObject(" + Tbl.CamelName + ", whereParaList);");
            sb.AppendLine();
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine();
            //修改方法;(根据条件 事务版)
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 修改数据，根据条件修改数据(事务版)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Update(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<IWhereParameter> whereParaList,IDbTransaction trans)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (whereParaList == null || whereParaList.Count == 0)");
            sb.AppendLine("                throw new ArgumentException(\"根据条件更新,条件列表不能为空!\");");
            sb.AppendLine();
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateUpdateObject(" + Tbl.CamelName + ", whereParaList);");
            sb.AppendLine();
            sb.AppendLine("                base.ExecuteNonQuery(operateObject,trans);");
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
            sb.AppendLine("        private OperateObject CreateUpdateObject(" + Tbl.PascalName + "Info " + Tbl.CamelName + ", List<IWhereParameter> whereList)");
            sb.AppendLine("        {");
            sb.AppendLine("            StringBuilder strSql = new StringBuilder();");
            sb.AppendLine("            List<IDataParameter> parameters = new  List<IDataParameter>();");
            sb.AppendLine("            SqlParameter para;");

            sb.AppendLine("            strSql.Append(\"update " + Tbl.TableName + " set \");");

            tempStr = "";
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.DataType.CSharpType == "Guid")
                        tempStr += "\r\n            if(" + Tbl.CamelName + "." + col.PascalName + "!=Guid.Empty)";
                    else
                        tempStr += "\r\n            if(" + Tbl.CamelName + "." + col.PascalName + "!=null)";
                    tempStr += "\r\n            {";
                    tempStr += "\r\n                //" + col.Description + "\r\n";
                    if (col.DataType.AutoWidth)
                        tempStr += "\r\n                para =  new SqlParameter(\"@" + col.PascalName + "\",SqlDbType." + col.DataType.DbType + ");";
                    else
                        tempStr += "\r\n                para =  new SqlParameter(\"@" + col.PascalName + "\",SqlDbType." + col.DataType.DbType + "," + col.ColumnLength.Value.ToString() + ");";

                    tempStr += "\r\n                para.Value = " + Tbl.CamelName + "." + col.PascalName + ";";
                    tempStr += "\r\n                parameters.Add(para);";
                    tempStr += "\r\n                strSql.Append(\"" + col.ColumnName + "=@" + col.PascalName + ",\");";
                    tempStr += "\r\n            }";
                }
            }
            sb.AppendLine("             if (!string.IsNullOrEmpty(" + Tbl.CamelName + ".UpdateNullFields))");
            sb.AppendLine("             {");
            sb.AppendLine("                 foreach (string fieldsName in " + Tbl.CamelName + ".UpdateNullFields.Split(','))");
            sb.AppendLine("                 {");
            sb.AppendLine("                     strSql.Append(fieldsName + \"=NULL,\");");
            sb.AppendLine("                 }");
            sb.AppendLine("             }");

            tempStr += "\r\n            if (strSql.ToString().Substring(strSql.Length - 1) == \",\")";
            tempStr += "\r\n                strSql.Remove(strSql.Length - 1, 1); ";
            tempStr += "\r\n ";
            //tempStr = tempStr.Substring(0, tempStr.Length - 4) + "\");";
            sb.AppendLine(tempStr);

            sb.AppendLine("             strSql.Append(\" Where 1=1  \");");
            sb.AppendLine("             ");
            sb.AppendLine("             // 如果条件不为空,则根据条件进行更新");
            sb.AppendLine("             foreach (IWhereParameter wherePara in whereList)");
            sb.AppendLine("             {");
            sb.AppendLine("                 strSql.Append(\" \" + wherePara.WhereExpression);");
            sb.AppendLine("                 parameters.Add(new SqlParameter(wherePara.ParameterName, wherePara.Value));");
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

            #region 根据条件删除数据
            sb.AppendLine("        #region 删除方法集");
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键删除");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"flag\"></param>");
            sb.AppendLine("        /// <param name=\"code\"></param>");
            sb.AppendLine("        public void Delete(" + GetPrimaryParaList() + ")");
            sb.AppendLine("        {");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            if (" + col.CamelName + " == null)");
                sb.AppendLine("                throw new ArgumentException(\"根据主键,删除表(" + Tbl.TableName + ")中记录,主键(" + col.PascalName + ")不能为空!\");");
            }

            sb.AppendLine("            List<IWhereParameter> whereParaList = new List<IWhereParameter>();");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            whereParaList.Add(new WhereParameter(\" And " + col.ColumnName + " = @" + col.PascalName + " \", \"@" + col.PascalName + "\", " + col.CamelName + "));");
            }
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateDeleteObject(whereParaList);");
            sb.AppendLine();
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键删除(事务版)");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"flag\"></param>");
            sb.AppendLine("        /// <param name=\"code\"></param>");
            sb.AppendLine("        public void Delete(" + GetPrimaryParaList() + ",IDbTransaction trans)");
            sb.AppendLine("        {");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            if (" + col.CamelName + " == null)");
                sb.AppendLine("                throw new ArgumentException(\"根据主键,删除表(" + Tbl.TableName + ")中记录,主键(" + col.PascalName + ")不能为空!\");");
            }

            sb.AppendLine("            List<IWhereParameter> whereParaList = new List<IWhereParameter>();");
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("            whereParaList.Add(new WhereParameter(\" And " + col.ColumnName + " = @" + col.PascalName + " \", \"@" + col.PascalName + "\", " + col.CamelName + "));");
            }
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateDeleteObject(whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject,trans);");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据条件删除数据，");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Delete(List<IWhereParameter> whereParaList)");
            sb.AppendLine("        {");
            sb.AppendLine("            //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateDeleteObject(whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject);");
            sb.AppendLine("        }");

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据条件删除数据，");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public void Delete(List<IWhereParameter> whereParaList,IDbTransaction trans)");
            sb.AppendLine("        {");
            sb.AppendLine("           //建立SQL语句对象");
            sb.AppendLine("            OperateObject operateObject = CreateDeleteObject(whereParaList);");
            sb.AppendLine("            base.ExecuteNonQuery(operateObject,trans);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("        #region 建立删除SQL对象 ");
            sb.AppendLine("        ");
            sb.AppendLine("        /// <summary>  ");
            sb.AppendLine("        /// 建立删除SQL对象  ");
            sb.AppendLine("        /// </summary>  ");
            sb.AppendLine("        /// <param name=\"whereParaList\"></param>  ");
            sb.AppendLine("        /// <param name=\"config\"></param>  ");
            sb.AppendLine("        /// <returns></returns>  ");
            sb.AppendLine("        private OperateObject CreateDeleteObject(List<IWhereParameter> whereParaList) ");
            sb.AppendLine("        { ");
            sb.AppendLine("            StringBuilder strSql = new StringBuilder(); ");
            sb.AppendLine("            List<IDataParameter> parameters = new List<IDataParameter>(); ");
            sb.AppendLine();
            sb.AppendLine("            strSql.Append(\"DELETE FROM " + Tbl.TableName + " \"); ");
            sb.AppendLine("            strSql.Append(\" Where 1=1 \"); ");
            sb.AppendLine();
            sb.AppendLine("            foreach (WhereParameter wherepara in whereParaList) ");
            sb.AppendLine("            { ");
            sb.AppendLine("                parameters.Add(new SqlParameter(wherepara.ParameterName, wherepara.Value)); ");
            sb.AppendLine("                strSql.Append(wherepara.WhereExpression); ");
            sb.AppendLine("            } ");
            sb.AppendLine();
            sb.AppendLine("            //构建日志对象  ");
            sb.AppendLine("            OperateObject opereObj = new OperateObject(); ");
            sb.AppendLine("            opereObj.SqlText = strSql.ToString(); ");
            sb.AppendLine("            opereObj.Parameters = parameters; ");
            sb.AppendLine();
            sb.AppendLine("            //构建返回对象  ");
            sb.AppendLine("            return opereObj; ");
            sb.AppendLine("        } ");
            sb.AppendLine();
            sb.AppendLine("        #endregion ");
            sb.AppendLine();
            sb.AppendLine("        #endregion");
            #endregion

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
                    sb.AppendLine("            strSql.Append(\" And " + col.ColumnName + " = @" + col.PascalName + "\");");
                }

                sb.AppendLine("            SqlParameter[] parameters = {");
                tempStr = "";
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    string colLength = "";
                    if (IsAllowColLength(col.DataType.CSharpType))
                    {
                        colLength = "," + col.ColumnLength.ToString();
                    }
                    tempStr += "\r\n                                              //" + col.Description + "\r\n";
                    tempStr += "                                                new SqlParameter(\"@" + col.PascalName + "\",SqlDbType." + col.DataType.DbType + colLength + "),";
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
            sb.AppendLine();
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据主键得到一个实体");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns></returns>");
            sb.AppendLine("        public " + Tbl.PascalName + "Info Get" + Tbl.PascalName + "Info(" + GetPrimaryParaList() + ",IDbTransaction trans)");
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
                    sb.AppendLine("            strSql.Append(\" And " + col.PascalName + " = @" + col.PascalName + "\");");
                }

                sb.AppendLine("            SqlParameter[] parameters = {");
                tempStr = "";
                foreach (IColumn col in Tbl.PrimaryKey.Columns)
                {
                    string colLength = "";
                    if (IsAllowColLength(col.DataType.CSharpType))
                    {
                        colLength = "," + col.ColumnLength.ToString();
                    }
                    tempStr += "\r\n                                              //" + col.Description + "\r\n";
                    tempStr += "                                                new SqlParameter(\"@" + col.PascalName + "\",SqlDbType." + col.DataType.DbType + colLength + "),";
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

            sb.AppendLine("            using (IDataReader dr = basicDataAccess.ExecuteReader(trans, CommandType.Text, strSql.ToString(), parameters))");
            sb.AppendLine("            {");
            sb.AppendLine("                if (dr.Read())");
            sb.AppendLine("                {");
            sb.AppendLine("                    " + Tbl.CamelName + " = Create" + Tbl.PascalName + "InfoByReader(dr);");
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
            sb.AppendLine("        /// 根据查询参数，得到" + Tbl.TableDescription + " LIST对象列表");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"DataQuery\">查询参数</param>");
            sb.AppendLine("        /// <returns>List<></returns>");
            sb.AppendLine("        public List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "List(IDataQuery dataQuery)");
            sb.AppendLine("        {");
            //  sb.AppendLine("            if (dataQuery.JoinTables.Count > 0)");
            //  sb.AppendLine("                throw new ArgumentException(\"得到对象列表方法,只能执行单表查询!\");");
            sb.AppendLine();
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
            sb.AppendLine("                if (dataQuery.PageView.IsPageView)");
            sb.AppendLine("                {");
            sb.AppendLine("                    dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(connection,CommandType.Text, dataQuery, dataQuery.WhereParameters);");
            sb.AppendLine("                    dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return returnList;");
            sb.AppendLine("        }");
            sb.AppendLine();
            //根据参数实体获取LIST对象列表
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 根据查询参数，得到" + Tbl.TableDescription + " LIST对象列表");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"DataQuery\">查询参数</param>");
            sb.AppendLine("        /// <returns>List<></returns>");
            sb.AppendLine("        public List<" + Tbl.PascalName + "Info> Get" + Tbl.PascalName + "List(IDataQuery dataQuery,IDbTransaction trans)");
            sb.AppendLine("        {");
            // sb.AppendLine("            if (dataQuery.JoinTables.Count > 0)");
            // sb.AppendLine("                throw new ArgumentException(\"得到对象列表方法,只能执行单表查询!\");");
            sb.AppendLine();
            sb.AppendLine("            List<" + Tbl.PascalName + "Info" + "> returnList = new List<" + Tbl.PascalName + "Info" + ">();");
            sb.AppendLine("            dataQuery.TableName = \"" + Tbl.TableName + "\";");

            sb.AppendLine("            using (IDataReader dr = basicDataAccess.ExecuteReader(trans,CommandType.Text,dataQuery, dataQuery.WhereParameters))");
            sb.AppendLine("            {");
            sb.AppendLine("                while (dr.Read())");
            sb.AppendLine("                {");
            sb.AppendLine("                    returnList.Add(Create" + Tbl.PascalName + "InfoByReader(dr));");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            //读取记录数(Reading RecordCount)");
            sb.AppendLine("            if (dataQuery.PageView.IsPageView)");
            sb.AppendLine("            {");
            sb.AppendLine("                dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(trans,CommandType.Text, dataQuery, dataQuery.WhereParameters);");
            sb.AppendLine("                dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;");
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
                sb.AppendLine("            if (!Convert.IsDBNull(dr[\"" + col.ColumnName + "\"]))");

                if (col.DataType.CSharpType.ToUpper() == "BYTE[]")
                    sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = (byte[])(dr[\"" + col.ColumnName + "\"]);");
                else
                    sb.AppendLine("                " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(dr[\"" + col.ColumnName + "\"]);");

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

            #region 是否存在
            sb.AppendLine();
            sb.AppendLine("        #region 判断是否己存在");
            sb.AppendLine("        ");
            sb.AppendLine("        /// <summary> ");
            sb.AppendLine("        /// 根据主键，判断对象是否己存在 ");
            sb.AppendLine("        /// </summary> ");
            sb.AppendLine("        /// <returns></returns> ");
            sb.AppendLine("        public bool IsExist(" + GetPrimaryParaList() + ")");
            sb.AppendLine("        {");
            sb.AppendLine("            " + Tbl.PascalName + "Info " + Tbl.CamelName + "Info = Get" + Tbl.PascalName + "Info(" + GetPrimaryValueList() + ");");
            sb.AppendLine("            if (" + Tbl.CamelName + "Info == null)");
            sb.AppendLine("                return false;");
            sb.AppendLine("            else");
            sb.AppendLine("                return true;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        #endregion ");
            sb.AppendLine();
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
            sb.AppendLine("using Esint." + DataAccess.AppName + ".Model;");
            sb.AppendLine("using Esint." + DataAccess.AppName + ".IDAL;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine();
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 模块名称：" + Tbl.TableDescription + " 数据访问层");
            sb.AppendLine("    /// 作    者：" + OperName);
            sb.AppendLine("    /// 生成日期：" + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版");
            sb.AppendLine("    ///           适用于工厂模式架构");
            sb.AppendLine("    /// 修改说明：");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + Tbl.PascalName + "Data  : BaseData, I" + Tbl.PascalName + "Data");
            sb.AppendLine("    {");
            sb.AppendLine("     ");

            sb.AppendLine("    }");
            sb.AppendLine("} ");


            return sb;
        }

        private string GetColumnsListString()
        {
            string colStr = "";
            foreach (IColumn col in Tbl.Columns)
            {
                colStr += col.ColumnName + ",";
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

        private string GetPrimaryValueList()
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

        /// <summary>
        /// 判断是否含有序列主键
        /// </summary>
        /// <returns></returns>
        private bool IsIndentityPrimary(IDbTable tbl)
        {
            bool isIndent = false;
            if (tbl.PrimaryKey != null)
            {
                foreach (IColumn col in tbl.PrimaryKey.Columns)
                {
                    if (col.IsIndentity)
                    {
                        isIndent = true;
                        break;
                    }
                }
            }
            return isIndent;
        }
    }
}
 
