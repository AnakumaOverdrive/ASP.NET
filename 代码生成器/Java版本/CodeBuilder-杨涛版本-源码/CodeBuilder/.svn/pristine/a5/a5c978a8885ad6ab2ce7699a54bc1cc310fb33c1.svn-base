using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
//using Esint.Common.Data.OracleDAL;
using Esint.CodeBuilder.Model;
using Esint.CodeBuilder.InterFace;

using Esint.CodeBuilder.Public;

namespace Esint.CodeBuilder.BLL
{
    public class OracleBLL:ICodeBuilder
    {
        /// <summary>
        /// 测试ORACLE数据库连接
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="oracleConnString"></param>
        /// <returns></returns>
        public bool TestConnect(string oracleConnString)
        {
            bool IsConnect = false;
            OracleConnection oracleconn = new OracleConnection(oracleConnString);
            try
            {
                oracleconn.Open();
                IsConnect = true;
            }
            catch (System.Exception ex)
            {
                IsConnect = false;
            }
            finally
            {
                if (oracleconn != null)
                {
                    if (oracleconn.State != ConnectionState.Closed)
                    {
                        oracleconn.Close();
                    }
                    oracleconn.Dispose();
                }
            }
            return IsConnect;
        }

        /// <summary>
        /// 得到Oracle数据库的表列表
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="oracleConnString"></param>
        /// <returns></returns>
        public List<IDbTable> GetTableList(string oracleConnString)
        {
            string sql = "select TABLE_NAME from user_tables order by TABLE_NAME asc";
            List<IDbTable> tblist = new List<IDbTable>();
            RootOracleDataAccess access = new RootOracleDataAccess();
            IDbConnection conn = access.GetConnection(oracleConnString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
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
       /// 得到Oracle视图列表
       /// 作者:刘伟通
       /// 日期:2010年7月30日
       /// </summary>
       /// <param name="oracleConnString"></param>
       /// <returns></returns>
        public List<IDbTable> GetViewList(string oracleConnString)
        {
            string sql = "select VIEW_NAME from user_views";
            List<IDbTable> tblist = new List<IDbTable>();
            RootOracleDataAccess access = new RootOracleDataAccess();
            IDbConnection conn = access.GetConnection(oracleConnString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        DbTable tb = new DbTable();
                        tb.TableName = Convert.ToString(dr["View_Name"]);
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
        /// 根据表名,得到表信息
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="sqlConnStr"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IDbTable GetTableByTableName(string oracleConnString, string tableName)
        {
            DbTable returnTable = new DbTable();
            string sql = @"SELECT USER_TAB_COLS.TABLE_NAME as TABLE_NAME, USER_TAB_COLS.COLUMN_NAME as COLUMN_NAME , USER_TAB_COLS.DATA_TYPE as DATA_TYPE, USER_TAB_COLS.DATA_LENGTH as DATA_LENGTH, USER_TAB_COLS.NULLABLE as NULLABLE,USER_TAB_COLS.COLUMN_ID as COLUMN_ID, user_col_comments.comments as comments,USER_TAB_COMMENTS.comments as TABLE_COMMENTS FROM USER_TAB_COLS inner join user_col_comments on user_col_comments.TABLE_NAME=USER_TAB_COLS.TABLE_NAME and user_col_comments.COLUMN_NAME=USER_TAB_COLS.COLUMN_NAME inner join USER_TAB_COMMENTS on USER_TAB_COMMENTS.TABLE_NAME=user_col_comments.TABLE_NAME where USER_TAB_COLS.TABLE_NAME='" + tableName + "'";
            RootOracleDataAccess access = new RootOracleDataAccess();
            IDbConnection conn = access.GetConnection(oracleConnString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        returnTable.TableName = Convert.ToString(dr["TABLE_NAME"]);
                        if (dr["TABLE_COMMENTS"] != DBNull.Value)
                            returnTable.TableDescription = Convert.ToString(dr["TABLE_COMMENTS"]);
                        else
                            returnTable.TableDescription = "";
                    }
                }
                AddColumns(returnTable, oracleConnString);
                AddPrimaryKey(returnTable, oracleConnString);
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
        private void AddColumns(DbTable returnTable, string oracleConnString)
        {
            string sql = "select tab1.table_name," +
                           "  tab1.comments, " +
                    " COLUMN_ID, " +
                    " tab1.COLUMN_NAME," +
                    " DATA_TYPE," +
                    " DATA_LENGTH," +
                    " NULLABLE," +
                    " COLUMN_COMMENTS," +
                    " DATA_DEFAULT," +
                    " PRIMARY_KEY " +
                "from (select comm.comments," +
                           "  t1.table_name," +
                           "  t1.DATA_DEFAULT," +
                            " to_char(T1.COLUMN_ID) AS COLUMN_ID," +
                            " t1.column_name as COLUMN_NAME," +
                           "  t1.data_type as DATA_TYPE," +
                           "  decode(t1.data_type," +
                              "      'FLOAT'," +
                               "     ''," +
                                "    'NUMBER'," +
                                "    '(' || t1.data_precision || ',' || t1.data_scale || ')'," +
                                 "   'CHAR'," +
                                "    t1.data_length," +
                                 "   'DATE'," +
                                 "   ''," +
                                "    'VARCHAR2'," +
                                "    t1.data_length) as DATA_LENGTH," +
                           "  t1.nullable AS NULLABLE," +
                         "   replace(t2.comments, '\"', '\\\"') as COLUMN_comments" +
                     "   from all_tab_cols t1, user_col_comments t2, USER_TAB_COMMENTS comm" +
                     "  where 1=1" +
                       "  and t1.table_name = UPPER('" + returnTable.TableName + "')  and t1.owner=UPPER('"+PublicClass.DbUserID+"') " +
                        " and t1.table_name = t2.table_name(+)" +
                        " and t1.column_name = t2.column_name(+)" +
                       "  and t1.table_name = comm.table_name(+)) tab1," +
                    " (select t3.table_name, t3.column_name, 'P' PRIMARY_KEY" +
                     "   from user_ind_columns t3, user_indexes t4" +
                     "  where 1=1" +
                      "   and t3.table_name = UPPER('" + returnTable.TableName + "') and t4.table_owner=UPPER('"+PublicClass.DbUserID+"') " +
                      "   and t3.table_name = t4.table_name" +
                      "   and t3.index_name = t4.index_name" +
                      "   and t4.uniqueness = 'UNIQUE') tab2" +
                " where tab1.table_name = tab2.table_name(+)" +
                "  and tab1.COLUMN_NAME = tab2.column_name(+)" +
                " order by decode(COLUMN_ID, 'COLUMN_ID', -1, To_number(COLUMN_ID))";

            RootOracleDataAccess access = new RootOracleDataAccess();
            IDbConnection conn = access.GetConnection(oracleConnString);
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
        /// 根据表获取主键(GEt Primary key from table)
        /// </summary>
        /// <param name="returnTable"></param>
        /// <param name="sqlConnStr"></param>
        private static void AddPrimaryKey(DbTable returnTable, string oracleConnString)
        {
            ///返回主键名称 (Get primary Name)
            string sql = @"select con.constraint_name,col.column_name
                            from user_constraints con,  user_cons_columns col 
                            where con.constraint_name = col.constraint_name 
                            and con.constraint_type='P' 
                            and col.table_name = '" + returnTable.TableName + "'";


            PrimaryKeyClass primaryKey = new PrimaryKeyClass();

            RootOracleDataAccess access = new RootOracleDataAccess();
            IDbConnection conn = access.GetConnection(oracleConnString);
            try
            {
                using (IDataReader dr = access.ExecuteReader(conn, CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["CONSTRAINT_NAME"]))
                        {
                            primaryKey.PrimaryKeyName = Convert.ToString(dr["CONSTRAINT_NAME"]);
                            primaryKey.TableName = returnTable.TableName;
                        }

                    }
                }

                if (string.IsNullOrEmpty(primaryKey.PrimaryKeyName))
                {
                    returnTable.PrimaryKey = null;
                }
                else
                {
                    string primary_sql = "select tab1.table_name," +
                                           "  tab1.comments, " +
                                    " COLUMN_ID, " +
                                    " tab1.COLUMN_NAME," +
                                    " DATA_TYPE," +
                                    " DATA_LENGTH," +
                                    " NULLABLE," +
                                    " COLUMN_COMMENTS," +
                                    " DATA_DEFAULT," +
                                    " PRIMARY_KEY " +
                                "from (select comm.comments," +
                                           "  t1.table_name," +
                                           "  t1.DATA_DEFAULT," +
                                            " to_char(T1.COLUMN_ID) AS COLUMN_ID," +
                                            " t1.column_name as COLUMN_NAME," +
                                           "  t1.data_type as DATA_TYPE," +
                                           "  decode(t1.data_type," +
                                              "      'FLOAT'," +
                                               "     ''," +
                                                "    'NUMBER'," +
                                                "    '(' || t1.data_precision || ',' || t1.data_scale || ')'," +
                                                 "   'CHAR'," +
                                                "    t1.data_length," +
                                                 "   'DATE'," +
                                                 "   ''," +
                                                "    'VARCHAR2'," +
                                                "    t1.data_length) as DATA_LENGTH," +
                                           "  t1.nullable AS NULLABLE," +
                                         "   replace(t2.comments, '\"', '\\\"') as COLUMN_comments" +
                                     "   from all_tab_cols t1, user_col_comments t2, USER_TAB_COMMENTS comm" +
                                     "  where 1=1" +
                                       "  and t1.table_name = UPPER('" + returnTable.TableName + "')" +
                                        " and t1.table_name = t2.table_name(+)" +
                                        " and t1.column_name = t2.column_name(+)" +
                                       "  and t1.table_name = comm.table_name(+)) tab1," +
                                    " (select t3.table_name, t3.column_name, 'P' PRIMARY_KEY" +
                                     "   from user_ind_columns t3, user_indexes t4" +
                                     "  where 1=1" +
                                      "   and t3.table_name = UPPER('" + returnTable.TableName + "')" +
                                      "   and t3.table_name = t4.table_name" +
                                      "   and t3.index_name = t4.index_name  " +
                                    "   and t4.uniqueness = 'UNIQUE' ) tab2" +

                                " where tab1.table_name = tab2.table_name(+)" +
                                "  and tab1.COLUMN_NAME = tab2.column_name(+)" +
                                " and primary_key='P'" +
                                " order by decode(COLUMN_ID, 'COLUMN_ID', -1, To_number(COLUMN_ID))";

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

            if (!Convert.IsDBNull(dr["DATA_LENGTH"]) && dr["DATA_LENGTH"].ToString().Trim().IndexOf("(")!=0)
                col.ColumnLength = Convert.ToInt32(dr["DATA_LENGTH"].ToString());

            if (!Convert.IsDBNull(dr["DATA_DEFAULT"]))
                col.DefaultValue = dr["DATA_DEFAULT"];
            else
                col.DefaultValue = "";

            col.IsPrimaryKey = dr["PRIMARY_KEY"].ToString().Trim() == "P";

            col.IsNull = dr["NULLABLE"].ToString().Trim() == "N";

            if (!Convert.IsDBNull(dr["TABLE_NAME"]))
                col.TableName = Convert.ToString(dr["TABLE_NAME"]);
            else
                col.TableName = "";
     
            return col;
        }

        /// <summary>
        /// 得到代码列表
        /// </summary>
        /// <param name="oracleConnString"></param>
        /// <returns></returns>
        public DataTable GetCodeTypeList(string oracleConnString)
        {
            DataTable codetable = new DataTable();
            RootOracleDataAccess access = new RootOracleDataAccess();
            IDbConnection conn = access.GetConnection(oracleConnString);
            try
            {
                string SQL = PublicClass.CodeSelectSQL;//读取代码表
                RootOracleDataAccess bm = new RootOracleDataAccess();
                codetable = bm.ExecuteDataset(conn, CommandType.Text, SQL).Tables[0];
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CloseConn(conn);
            }
            return codetable;
        }

    
    }
}
