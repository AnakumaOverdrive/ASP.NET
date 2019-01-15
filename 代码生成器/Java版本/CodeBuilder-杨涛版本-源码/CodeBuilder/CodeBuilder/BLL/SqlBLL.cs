using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder..DAL;
using System.Data;
using Esint.CodeBuilder.Model;
using Esint.CodeBuilder.InterFace;
using System.Data.SqlClient;
using Esint.CodeBuilder.Public;

namespace Esint.CodeBuilder.BLL
{
    public class SqlBLL : ICodeBuilder
    {
        /// <summary>
        /// 测试SQL数据库连接
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="connectString">连接字符串</param>
        /// <returns>是否可以连接</returns>
        public bool TestConnect(string connectString)
        {
            SqlDataAccess.ConnectString = connectString;
            SqlDataAccess access = new SqlDataAccess();
            bool isConnect = false;
            IDbConnection conn = null;
            try
            {
                conn = access.GetConnection();
                isConnect = true;
            }
            catch (System.Exception ex)
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
            string sql = "select * from sysobjects where xtype='U' order by name asc";
            List<IDbTable> tblist = new List<IDbTable>();
            SqlDataAccess access = new SqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (SqlDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        IDbTable tb = new DbTable();
                        tb.TableName = Convert.ToString(dr["name"]);
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
            string sql = "select * from sysobjects where xtype='V' order by name asc";
            List<IDbTable> tblist = new List<IDbTable>();
            SqlDataAccess access = new SqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (SqlDataReader dr = access.ExecuteReader((SqlConnection)conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        IDbTable tb = new DbTable();
                        tb.TableName = Convert.ToString(dr["name"]);
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
        public IDbTable GetTableByTableName(string connectString,string tableName)
        {
            return GetTableByTableName(connectString, tableName, true);
        }

        /// <summary>
        /// 根据表名,构建表对象
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static IDbTable GetTableByTableName(string connectString, string tableName, bool IsSubTable)
        {
            DbTable returnTable = new DbTable();
            string sql = @"SELECT so.id as TABLE_ID,so.[Name] as TABLE_NAME,sp.value as TABLE_COMMENTS  FROM   sys.sysobjects so  
                         LEFT JOIN sys.extended_properties sp  ON so.id = sp.major_id  AND sp.minor_id = '0' 
                          WHERE   xtype = 'U' AND so.[Name]='" + tableName + "'";
            SqlDataAccess access = new SqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        returnTable.TableID = Convert.ToInt32(dr["TABLE_ID"]);
                        returnTable.TableName = Convert.ToString(dr["TABLE_NAME"]);
                        if (dr["TABLE_COMMENTS"] != DBNull.Value)
                            returnTable.TableDescription = Convert.ToString(dr["TABLE_COMMENTS"]);
                        else
                            returnTable.TableDescription = "";
                    }
                }
                // 添加列
                AddColumns(returnTable, connectString);
                // 添加主键 
                AddPrimaryKey(returnTable, connectString);

                // 添加子表
                if (IsSubTable)
                {
                    AddSubTables(returnTable, connectString);
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
            return returnTable;
        }
        /// <summary>
        /// 向表中添加列
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        private static void AddColumns(DbTable returnTable, string connectString)
        {
            string sql = @"SELECT  sys.syscolumns.colid as COLUMN_ID,sys.syscolumns.name AS COLUMN_NAME, sys.sysobjects.name AS TABLE_NAME, sys.systypes.name AS DATA_TYPE, sys.syscolumns.length as DATA_LENGTH, 
                      ISNULL(COLUMNPROPERTY(sys.syscolumns.id, sys.syscolumns.name, 'Scale'), 0) AS Scale,  sys.syscolumns.isnullable as NULLABLE, 
                      CASE WHEN syscomments.text IS NULL THEN '' ELSE syscomments.text END AS DATA_DEFAULT, COLUMNPROPERTY(sys.syscolumns.id, 
                      sys.syscolumns.name, 'IsIdentity') AS IS_Identity, CASE WHEN sysforeignkeys.constid IS NULL THEN 0 ELSE 1 END AS ForeignKey, 
                      CASE WHEN EXISTS
                          (SELECT     1
                            FROM          sysobjects
                            WHERE      xtype = 'PK' AND name IN
                                                       (SELECT     name
                                                         FROM          sysindexes
                                                         WHERE      indid IN
                                                                                    (SELECT     indid
                                                                                      FROM          sysindexkeys
                                                                                      WHERE      id = syscolumns.id AND colid = syscolumns.colid))) THEN 1 ELSE 0 END AS PRIMARY_KEY, 
                      sys.extended_properties.value AS COLUMN_COMMENTS
                    FROM   sys.syscolumns INNER JOIN
                                          sys.sysobjects ON sys.syscolumns.id = sys.sysobjects.id LEFT OUTER JOIN
                                          sys.systypes ON sys.systypes.xtype = sys.syscolumns.xtype LEFT OUTER JOIN
                                          sys.syscomments ON sys.syscolumns.cdefault = sys.syscomments.id LEFT OUTER JOIN
                                          sys.sysforeignkeys ON sys.sysforeignkeys.fkeyid = sys.syscolumns.id AND sys.sysforeignkeys.fkey = sys.syscolumns.colid LEFT OUTER JOIN
                                          sys.extended_properties ON sys.syscolumns.id = sys.extended_properties.major_id AND 
                                          sys.syscolumns.colid = sys.extended_properties.minor_id
                    WHERE     (sys.syscolumns.id = '" + returnTable.TableID.ToString() + @"' and sys.systypes.status ='0')  ORDER BY sys.syscolumns.colorder"; 

            SqlDataAccess access = new SqlDataAccess();
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
            string sql = @"select [name] AS PRIMARYKEY_NAME from sysobjects where xtype='PK' and parent_obj= '" + returnTable.TableID.ToString() + "'";
            PrimaryKeyClass primaryKey = new PrimaryKeyClass();

            SqlDataAccess access = new SqlDataAccess();
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
                    string primary_sql = @"select syscolumns.colid AS COLUMN_ID,syscolumns.[name] as COLUMN_NAME,'" + returnTable.TableName + @"' as TABLE_NAME, sys.extended_properties.value AS COLUMN_COMMENTS ,
                    sys.systypes.name AS DATA_TYPE,syscolumns.Length  AS DATA_LENGTH,syscolumns.Scale,syscolumns.isNullable AS NULLABLE ,
                    '' as DATA_DEFAULT, COLUMNPROPERTY(sys.syscolumns.id,sys.syscolumns.name, 'IsIdentity') AS IS_Identity,
                    0 AS ForeignKey, 
                    1 as PRIMARY_KEY  from syscolumns  
                   left join sysindexKeys on syscolumns.colid = sysindexKeys.colid  and syscolumns.id =sysindexKeys.id
                   left join sysindexes   on sysindexes.indid = sysindexKeys.indid and sysindexes.id = sysindexKeys.id
                   left join sysobjects   on sysobjects.name = sysindexes.name
                   left JOIN sys.extended_properties ON sys.syscolumns.id = sys.extended_properties.major_id AND sys.syscolumns.colid = sys.extended_properties.minor_id
                   left JOIN sys.systypes ON sys.systypes.xtype = sys.syscolumns.xtype and sys.systypes.status <>'1'
                   where     sysobjects.xtype='PK' and  syscolumns.id ='" + returnTable.TableID + @"' ";

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
        /// 添加子表
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        private static void AddSubTables(DbTable returnTable, string connectString)
        {
            ///返回主键名称 (Get primary Name)
            string sql = @"select o1.name,o1.id,ep.value from  sysforeignkeys 
                            join sysobjects o1 on o1.id = sysforeignkeys.fkeyid
                            left join sys.extended_properties ep on ep.major_id = o1.id and ep.minor_id='0'
                            where sysforeignkeys.rkeyid='" + returnTable.TableID.ToString() + "'";

            IDbTable subTable = new DbTable();
            SqlDataAccess access = new SqlDataAccess();
            IDbConnection conn = access.GetConnection(connectString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    returnTable.SubTables = new List<IDbTable>();
                    while (dr.Read())
                    {
                      subTable = GetTableByTableName(connectString, Convert.ToString(dr["name"]),false);
                      returnTable.SubTables.Add(subTable);
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

            if (!Convert.IsDBNull(dr["DATA_LENGTH"]))
                col.ColumnLength = Convert.ToInt32(dr["DATA_LENGTH"].ToString());

            if (!Convert.IsDBNull(dr["DATA_DEFAULT"]))
                col.DefaultValue = dr["DATA_DEFAULT"];
            else
                col.DefaultValue = "";

            col.IsPrimaryKey = dr["PRIMARY_KEY"].ToString().Trim() == "1";

            col.IsNull = dr["NULLABLE"].ToString().Trim() == "1";

            if (!Convert.IsDBNull(dr["TABLE_NAME"]))
                col.TableName = Convert.ToString(dr["TABLE_NAME"]);
            else
                col.TableName = "";

            col.IsIndentity = dr["IS_Identity"].ToString() == "1";
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

        public DataTable GetCodeTypeList(string connectString)
        {
            return new DataTable();
        }
    }
}
