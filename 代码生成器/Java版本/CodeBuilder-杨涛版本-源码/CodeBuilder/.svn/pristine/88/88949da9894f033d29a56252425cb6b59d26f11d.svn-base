using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.MySqlData.DAL;
using System.Data;
using Esint.CodeBuilder.Model;
using Esint.CodeBuilder.InterFace;
using MySql.Data.MySqlClient;
using Esint.CodeBuilder.Public;

namespace Esint.CodeBuilder.MySqlData.BLL
{
    public class MySqlBLL : ICodeBuilder
    {
        //数据库类型
        public string DataBaseType { get { return "MYSQL"; } }

        //应用程序名称
        public string AppName { get; set; }


        // 查询代码的SQL语句
        public string CodeSQL { get; set; }


        /// <summary>
        /// 测试SQL数据库连接
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="connectString">连接字符串</param>
        /// <returns>是否可以连接</returns>
        public bool TestConnect(string connectString)
        {
            MySqlDataAccess.ConnectString = connectString;
            MySqlDataAccess access = new MySqlDataAccess();
            bool isConnect = false;
            IDbConnection conn = null;
            try
            {
                conn = access.GetConnection();
                isConnect = true;
            }
            catch
            {
                isConnect = false;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return isConnect;
        }

        /// <summary>
        /// 得到数据表列表
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public List<IDbTable> GetTableList(string connectString)
        {
            string tempStr = connectString.Split(';')[1];

            string sql = @"select TABLE_NAME,TABLE_COMMENT from information_schema.tables where table_type='base table' and table_schema='" + tempStr.Split('=')[1] + "' order by TABLE_NAME";

            List<IDbTable> tblist = new List<IDbTable>();
            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (MySqlDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        IDbTable tb = new DbTable();
                        tb.TableName = Convert.ToString(dr["TABLE_NAME"]);
                        tb.TableDescription = Convert.ToString(dr["TABLE_COMMENT"]);
                        tblist.Add(tb);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return tblist;
        }

        /// <summary>
        /// 得到视图列表
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public List<IDbTable> GetViewList(string connectString)
        {
            string tempStr = connectString.Split(';')[1];
            string sql = @"select TABLE_NAME,TABLE_COMMENT from information_schema.tables where table_type='view' and table_schema='" + tempStr.Split('=')[1] + "' order by TABLE_NAME";
            List<IDbTable> tblist = new List<IDbTable>();
            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (MySqlDataReader dr = access.ExecuteReader((MySqlConnection)conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        IDbTable tb = new DbTable();
                        tb.TableName = Convert.ToString(dr["TABLE_NAME"]);
                        tblist.Add(tb);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return tblist;
        }

        /// <summary>
        /// 根据表名,构建表对象
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IDbTable GetTableByTableName(string connectString, string tableName)
        {
            string tempStr = connectString.Split(';')[1];
            DbTable returnTable = new DbTable();
            string sql = @"select TABLE_SCHEMA,TABLE_NAME,TABLE_COMMENT from information_schema.tables where table_type='base table' and TABLE_SCHEMA='" + tempStr.Split('=')[1] + "' and TABLE_NAME='" + tableName + "'";

            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        returnTable.Owner = Convert.ToString(dr["TABLE_SCHEMA"]);
                        returnTable.TableName = Convert.ToString(dr["TABLE_NAME"]);
                        if (dr["TABLE_COMMENT"] != DBNull.Value)
                            returnTable.TableDescription = Convert.ToString(dr["TABLE_COMMENT"]);
                        else
                            returnTable.TableDescription = "";
                    }
                }
                // 添加列
                AddColumns(returnTable, connectString);
                // 添加主键 
                AddPrimaryKey(returnTable, connectString);

                //添加外键
                AddForeignKey(returnTable, connectString);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return returnTable;
        }


        /// <summary>
        /// 向表中添加列
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        private static void AddColumns(DbTable returnTable, string connectString)
        {
            string sql = @"select
	ORDINAL_POSITION as COLUMN_ID,
	COLUMN_NAME,
	TABLE_NAME,
	DATA_TYPE,
	CHARACTER_MAXIMUM_LENGTH as DATA_LENGTH,
	IS_NULLABLE as NULLABLE,
	COLUMN_DEFAULT as DATA_DEFAULT,
	COLUMN_KEY as PRIMARY_KEY,
	COLUMN_COMMENT as COLUMN_COMMENTS
from
	information_schema.columns
where table_name = '" + returnTable.TableName.ToString() + "' and table_schema='" + returnTable.Owner.ToString() + "'";

            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        returnTable.Columns.Add(BuilderRoleByReader(dr));
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
        }


        /// <summary>
        /// 根据表获取主键
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        private static void AddPrimaryKey(DbTable returnTable, string connectString)
        {
            ///返回主键名称 (Get primary Name)
            string sql = @"select
	COLUMN_NAME AS PRIMARYKEY_NAME
from
	information_schema.columns
where
COLUMN_KEY='PRI' and
table_name = '" + returnTable.TableName.ToString() + "' and table_schema = '" + returnTable.Owner.ToString() + "'";
            PrimaryKeyClass primaryKey = new PrimaryKeyClass();

            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        primaryKey.PrimaryKeyName = Convert.ToString(dr["PRIMARYKEY_NAME"]);
                        primaryKey.TableName = returnTable.TableName;
                    }
                }

                if (string.IsNullOrEmpty(primaryKey.PrimaryKeyName))
                {
                    returnTable.PrimaryKey = null;
                }
                else
                {
                    string primary_sql = @"select
	ORDINAL_POSITION as COLUMN_ID,
	COLUMN_NAME,
	TABLE_NAME,
	DATA_TYPE,
	CHARACTER_MAXIMUM_LENGTH as DATA_LENGTH,
	IS_NULLABLE as NULLABLE,
	COLUMN_DEFAULT as DATA_DEFAULT,
	COLUMN_KEY as PRIMARY_KEY,
	COLUMN_COMMENT as COLUMN_COMMENTS
from
	information_schema.columns
where
COLUMN_KEY='PRI'
and table_name = '" + returnTable.TableName.ToString() + "' and table_schema = '" + returnTable.Owner.ToString() + "'";
                    using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, primary_sql))
                    {
                        while (dr.Read())
                        {
                            primaryKey.Columns.Add(BuilderRoleByReader(dr));
                        }
                    }
                    returnTable.PrimaryKey = primaryKey;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
        }

        /// <summary>
        /// 根据表获取外键
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        private static void AddForeignKey(DbTable returnTable, string connectString)
        {
            string sql = @"select
COLUMN_NAME as fk_Name
from
	information_schema.key_column_usage
where
	table_schema = '" + returnTable.Owner.ToString() + "' and table_name = '" + returnTable.TableName.ToString() + "' and referenced_table_name is not null";

            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                returnTable.ForeignKeys = new List<IForeignKeyClass>();
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        IForeignKeyClass foreignKey = new ForeignKeyClass();
                        foreignKey.ForeignKeyName = Convert.ToString(dr["fk_Name"]);
                        string sql1 = @"select
COLUMN_NAME as c1,
TABLE_NAME as c2,
REFERENCED_COLUMN_NAME as c3,
REFERENCED_TABLE_NAME as c4
from
	information_schema.key_column_usage
where
	table_schema = '" + returnTable.Owner.ToString() + "' and COLUMN_NAME='" + Convert.ToString(dr["fk_Name"]) + "'";

                        IDbConnection conn1 = access.GetConnection(connectString);
                        using (IDataReader dr1 = access.ExecuteReader(conn1, CommandType.Text, sql1))
                        {
                            foreignKey.FKColumns = new List<IForeignKeyColumn>();
                            while (dr1.Read())
                            {
                                IForeignKeyColumn fkcol = new ForeignKeyColumn();
                                fkcol.FKColumnName = Convert.ToString(dr1["c1"]);
                                fkcol.FKTableName = Convert.ToString(dr1["c2"]);
                                fkcol.PKColumnName = Convert.ToString(dr1["c3"]);
                                fkcol.PKTableName = Convert.ToString(dr1["c4"]);
                                foreignKey.FKColumns.Add(fkcol);
                            }
                        }
                        returnTable.ForeignKeys.Add(foreignKey);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
        }

        /// <summary>
        /// 添加子表
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        public List<IDbTable> GetSubTables(IDbTable returnTable, string connectString)
        {
            ///返回主键名称 (Get primary Name)
            string sql = @"select
REFERENCED_TABLE_NAME
from
	information_schema.key_column_usage 
where
	table_schema = '" + returnTable.Owner.ToString() + "' and CONSTRAINT_NAME='PRIMARY' and TABLE_NAME='" + returnTable.TableName.ToString() + "'";

            List<IDbTable> subTables = new List<IDbTable>();
            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {

                    while (dr.Read())
                    {
                        subTables.Add(GetTableByTableName(connectString, Convert.ToString(dr["name"])));
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return subTables;
        }


        /// <summary>
        /// 根据DataReader建立列对象
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static Column BuilderRoleByReader(IDataReader dr)
        {
            Column col = new Column();
            if (!Convert.IsDBNull(dr["COLUMN_ID"]))
                col.ColumnID = Convert.ToInt32(dr["COLUMN_ID"]);

            if (!Convert.IsDBNull(dr["COLUMN_NAME"]))
                col.ColumnName = Convert.ToString(dr["COLUMN_NAME"]);
            else
                col.ColumnName = "";

            if (!Convert.IsDBNull(dr["COLUMN_COMMENTS"]))
                col.Description = Convert.ToString(dr["COLUMN_COMMENTS"]);
            else
                col.Description = "";

            if (!Convert.IsDBNull(dr["DATA_TYPE"]))
                col.DataType.DbDataType = Convert.ToString(dr["DATA_TYPE"]);
            else
                col.DataType.DbDataType = "";

            if (!Convert.IsDBNull(dr["DATA_LENGTH"]) && dr["DATA_LENGTH"].ToString().Trim().IndexOf("(") != 0)
                col.ColumnLength = Convert.ToInt32(dr["DATA_LENGTH"].ToString());

            if (!Convert.IsDBNull(dr["DATA_DEFAULT"]))
                col.DefaultValue = dr["DATA_DEFAULT"];
            else
                col.DefaultValue = "";

            col.IsPrimaryKey = dr["PRIMARY_KEY"].ToString().Trim() == "PRI";

            col.IsNull = dr["NULLABLE"].ToString().Trim() == "NO";

            if (!Convert.IsDBNull(dr["TABLE_NAME"]))
                col.TableName = Convert.ToString(dr["TABLE_NAME"]);
            else
                col.TableName = "";
            return col;
        }
        /// <summary>
        ///根据类型判断数据字段长度
        /// </summary>
        /// <param name="DataType"></param>
        /// <param name="DataLength"></param>
        /// <returns></returns>
        public static int? ConvertDataLength(string DataType, string DataLength)
        {
            switch (DataType.ToUpper())
            {
                case "NUMBER":
                case "LONG":
                    return null;
                default:
                    return Convert.ToInt32(DataLength);
            }
        }

        public List<ICodeType> GetCodeTypeList(string connectString)
        {
            List<ICodeType> codeList = new List<ICodeType>();

            MySqlDataAccess access = new MySqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                string SQL = PublicClass.CodeSelectSQL;//读取代码表

                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, SQL))
                {

                    while (dr.Read())
                    {
                        ICodeType codeType = new CodeType();
                        codeType.Flag = Convert.ToString(dr["flag"]);
                        codeType.Meaning = Convert.ToString(dr["meaning"]);
                        codeList.Add(codeType);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return codeList;
        }
    }
}
