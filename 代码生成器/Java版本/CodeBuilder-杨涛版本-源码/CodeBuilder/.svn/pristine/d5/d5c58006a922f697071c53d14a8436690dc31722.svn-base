using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.Model;
using System.Data; 
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

namespace Esint.Common.Data.OracleDAL
{
    public class RootOracleDataAccess : Oracle
    {
        const string ORACLE_HELP_ASSEMBLY = "Esint.Common.Data";
        const string ORACLE_HELP_TYPE = "Esint.Common.Data.OracleDAL.Oracle";
        static string _connectString;
        public RootOracleDataAccess() {
        }

        IDbConnection _oracleconn;
        IDbTransaction _oracleTrans;

        /// <summary>
        /// 析构函数
        /// </summary>
        ~RootOracleDataAccess()
        {
            //关闭事务
            if (_oracleTrans != null)
            {
                IDbConnection conn = _oracleTrans.Connection;
                _oracleTrans.Dispose();

                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }

            //关闭连接
            if (_oracleconn != null)
            {
                if (_oracleconn.State != ConnectionState.Closed)
                {
                    _oracleconn.Close();

                }
                _oracleconn.Dispose();
            }
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectString))
                    _connectString = ConfigurationManager.AppSettings["DBConn"];
                return _connectString;
            }
            set
            {
                _connectString = value;
            }
        }

        /// <summary>
        /// 打开数据库链接操作
        /// </summary>
        /// <returns>OracleConnection</returns>
        public IDbConnection GetConnection()
        {
           _oracleconn = new OracleConnection(ConnectString);
            try
            {
                _oracleconn.Open();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return _oracleconn;
        }

        /// <summary>
        /// 建立数据库事务
        /// </summary>
        /// <returns></returns>
        public  IDbTransaction GetTransaction()
        {
            _oracleconn = new OracleConnection(ConnectString);
            _oracleconn.Open();
            _oracleTrans = _oracleconn.BeginTransaction();
            return _oracleTrans;
        }

        /// <summary>
        /// 关闭数据库链接 
        /// </summary>
        /// <param name="_oracleconn"></param>
        public  void CloseConn(IDbConnection connect)
        {
            _oracleconn = connect;
            if (_oracleconn != null)
            {
                if (_oracleconn.State != ConnectionState.Closed)
                {
                    _oracleconn.Close();

                }
                _oracleconn.Dispose();
            }
        }

        /// <summary>
        /// 关闭事务
        /// </summary>
        /// <param name="trans"></param>
        public  void CloseTrans(IDbTransaction trans)
        {
            _oracleTrans = trans;
            if (_oracleTrans != null)
            {
                IDbConnection conn = _oracleTrans.Connection;
                _oracleTrans.Dispose();

                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }
        }
        /// <summary>
        /// 创建Adohelper
        /// </summary>
        /// <returns></returns>
        internal static AdoHelper GetAdoHelper()
        {
            return AdoHelper.CreateHelper(ORACLE_HELP_ASSEMBLY, ORACLE_HELP_TYPE);
        }

        public int ExecuteSQL(System.Data.IDbTransaction transaction, string SQL, List<IDataParameter> paras)
        {
            try
            {
                AdoHelper OracleHelper = GetAdoHelper();
                OracleParameter[] OracleParameters = new OracleParameter[paras.Count];
                int i = 0;
                foreach (OracleParameter para in paras)
                {
                    OracleParameters[i] = para;
                    i++;
                }
                return OracleHelper.ExecuteNonQuery(transaction, CommandType.Text, SQL, OracleParameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 执行sql语句做更新操作( Execute sql to update)
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="SQL">sql语句</param>
        /// <param name="paras">IDbParameters 参数</param>
        /// <returns></returns>
        public int ExecuteSQL(System.Data.IDbConnection conn, string SQL, List<IDataParameter> paras)
        {
            try
            {
                AdoHelper OracleHelper = GetAdoHelper();

                OracleParameter[] OracleParameters = new OracleParameter[paras.Count];
                int i = 0;
                foreach (OracleParameter para in paras)
                {
                    OracleParameters[i] = para;
                    i++;
                }

                return OracleHelper.ExecuteNonQuery(conn, CommandType.Text, SQL, OracleParameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IDataReader ExecuteReader(IDbTransaction trans, CommandType commandType,RootQueryObject queryObject, List<WhereParameter> paras)
        {
            return base.ExecuteReader(trans, commandType, GetSqlTextByQueryObject(queryObject), GetDataParameters(paras));
        }

        public DataSet ExecuteDataset(IDbTransaction trans, CommandType commandType, RootQueryObject queryObject, List<WhereParameter> paras)
        {
            return base.ExecuteDataset(trans, commandType, GetSqlTextByQueryObject(queryObject), GetDataParameters(paras));
        }

        public IDataReader ExecuteReader(IDbConnection conn, CommandType commandType, RootQueryObject queryObject, List<WhereParameter> paras)
        {
            return base.ExecuteReader(conn, commandType, GetSqlTextByQueryObject(queryObject), GetDataParameters(paras));
        }

        public DataSet ExecuteDataset(IDbConnection conn, CommandType commandType, RootQueryObject queryObject, List<WhereParameter> paras)
        {
            return base.ExecuteDataset(conn, commandType, GetSqlTextByQueryObject(queryObject), GetDataParameters(paras));
        }


        public long GetRecordCount(IDbTransaction trans, CommandType commandType, RootQueryObject queryObject, List<WhereParameter> paras)
        {
            long recordNum = 0;
            queryObject.IsPageView = false;
            string sql = "select count(*) As Ora_RecordCount from (" + GetSqlTextByQueryObject(queryObject) + ")";

            IDataReader dr = base.ExecuteReader(trans,commandType, sql, GetDataParameters(paras));
            if (dr.Read())
            {
                if (!Convert.IsDBNull(dr["Isenabled"]))
                    recordNum = (long)dr["Ora_RecordCount"];
            }
            return recordNum;
        }

        public long GetRecordCount(IDbConnection conn, CommandType commandType, RootQueryObject queryObject, List<WhereParameter> paras)
        {
            long recordNum = 0;
            queryObject.IsPageView = false;
            string sql = "select count(*) As Ora_RecordCount from (" + GetSqlTextByQueryObject(queryObject) + ")";

            IDataReader dr = base.ExecuteReader(conn,commandType, sql, GetDataParameters(paras));
            if (dr.Read())
            {
                if (!Convert.IsDBNull(dr["Isenabled"]))
                    recordNum = (long)dr["Ora_RecordCount"];
            }
            return recordNum;
        }

        internal IDataParameter[] GetDataParameters(List<WhereParameter> paras)
        {
            IDataParameter[] parameters = new IDataParameter[paras.Count];
            int i = 0;
            foreach (WhereParameter para in paras)
            {
                OracleParameter oraPara = new OracleParameter();
                oraPara.ParameterName = para.ParameterName;
                oraPara.Value = para.Value;
                parameters[i] = oraPara;
                i++;
            }
            return parameters;
        }

        internal string GetSqlTextByQueryObject(RootQueryObject queryObject)
        {
            string sqlText = "";

            //如果是组合语句;
            if (!String.IsNullOrEmpty(queryObject.SQLText))
            {
                return queryObject.SQLText;
            }

            if (queryObject.JoinTables.Count > 0 && string.IsNullOrEmpty(queryObject.Alias))
                throw new ArgumentException("多表关联查询时,表" + queryObject.TableName + "的别名不能为空!");


            if (queryObject.IsPageView && string.IsNullOrEmpty(queryObject.Alias))
                throw new ArgumentException("分页查询时,表" + queryObject.TableName + "的别名不能为空!");

            //
            // 拼接关联表查询元素 
            // 
            if (string.IsNullOrEmpty(queryObject.FieldString))
                queryObject.FieldString = string.IsNullOrEmpty(queryObject.Alias) ? "*" : queryObject.Alias + ".*";

            string fieldList = queryObject.FieldString;

            string joinTableSql = "";

            foreach (RootJoinTable joinTable in queryObject.JoinTables)
            {
                if (string.IsNullOrEmpty(joinTable.Alias))
                    throw new ArgumentException("多表关联查询时,表" + joinTable.TableName + "的别名不能为空!");

                if (string.IsNullOrEmpty(joinTable.JoinExpression))
                    throw new ArgumentException("多表关联时,表" + joinTable.TableName + "的关联表达式不能为空!");

                fieldList += joinTable.FieldString;   //拼接查询字段

                // 拼接Join 语句 
                if (joinTable.WhereParameters.Count == 0)
                {
                    joinTableSql += string.Format(" JOIN {0} {1} ON {2} ", joinTable.TableName, joinTable.Alias, joinTable.JoinExpression);
                }
                else
                {
                    string whereExp = "";
                    foreach (WhereParameter where in joinTable.WhereParameters)
                    {
                        whereExp += where.WhereExpression + " ";
                    }
                    joinTableSql += string.Format(" JOIN (SELECT * FROM {0} WHERE 1=1 {1}) {2} ON {3} ", joinTable.TableName, whereExp, joinTable.Alias, joinTable.JoinExpression);
                }
            }

            string whereSql = "";
            foreach (WhereParameter where in queryObject.WhereParameters)
            {
                whereSql += where.WhereExpression + " ";
            }

            sqlText = "SELECT {0} FROM {1} {2} {3} WHERE 1=1 {4} ";

            if (!string.IsNullOrEmpty(queryObject.GroupByString))
                sqlText += " GROUP BY " + queryObject.GroupByString;

            if (!string.IsNullOrEmpty(queryObject.OrderByString))
                sqlText += " GROUP BY " + queryObject.OrderByString;

            //分页,添加分页代码
            if (queryObject.IsPageView)
            {
                int start_row_num = (queryObject.PageIndex - 1) * queryObject.PageSize + 1;

                fieldList = "  rownum as ORA_RowNum, " + fieldList;
                whereSql = "And rownum<= " + start_row_num + " " + whereSql + " ";
                sqlText = "SELECT * FROM (" + sqlText + ") WHERE ORA_RowNum>=" + Convert.ToString(start_row_num + queryObject.PageSize - 1);

            }
            sqlText = string.Format(sqlText, fieldList, queryObject.TableName, queryObject.Alias, joinTableSql, whereSql);

            return sqlText;
        }


        /// <summary>
        /// 获取登陆数据库用户名
        /// </summary>
        /// <returns></returns>
        internal static string GetOwer()
        {
            try
            {
                string strConn = ConnectString;
                int iLocation = strConn.ToUpper().IndexOf("USER ID=") + 8;//起始位置
                int jLocation = strConn.ToUpper().IndexOf(";", iLocation);//截止位置
                int lengh;//数据库用户字符的长度
                if (jLocation > -1)
                    lengh = jLocation - iLocation;
                else
                    lengh = strConn.Length - iLocation;
                return strConn.ToUpper().Substring(iLocation, lengh);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        ///取序列方法
        /// </summary>
        /// <param name="tableName">tableName序列表名</param>
        /// <param name="sequencesLength">序列总长度</param>
        /// <param name="format">序列前缀</param>
        /// <returns>返回满足条件的序列值，若无序列则创建当年的新的序列</returns>
        public  string GetSequences(string tableName, int sequencesLength, string format)
        {
            string dbUser = GetOwer();           //得到当前用户
            string sysDate = GetSysDate();       //得到当前时间
            string sequencesName = null;         //返回的序列号

            sequencesLength = sequencesLength - format.Length;     //需生成的序列长度 

            IDbTransaction trans = GetTransaction();
            IDbConnection conn = trans.Connection;
            try
            {
                if (tableName.IndexOf("T_") > -1 || tableName.IndexOf("R_") > -1)                 //如果表名以T_,R_开头,取去字头;
                    tableName = tableName.Substring(2);

                string year = sysDate.Substring(0,4);               //取当前年份

                sequencesName = "SEQ_" + tableName.ToUpper() + "_" + year;//以 SEQ_表名_年份为序列名

                AdoHelper OracleHelper = GetAdoHelper();

                string strSql = "select * from ALL_SEQUENCES where SEQUENCE_OWNER='" + dbUser + "' And  Sequence_Name like '" + sequencesName.Substring(0, sequencesName.Length - 4) + "____' and sequence_name !='" + sequencesName + "'";
                using (DataSet Ds = OracleHelper.ExecuteDataset(trans, CommandType.Text, strSql))
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dl in Ds.Tables[0].Rows)
                        {
                            //判断是否存在不是当年日期的序列，若有则删除旧序列
                            string dropSql = "drop sequence  " + dl["SEQUENCE_name"].ToString();
                            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, dropSql);
                        }
                    }
                }

                //查找是否存在当前日期的序列，若无，则创建新的当年日期的序列；
                //若有，则取得序列值
                string strql = "select * from ALL_SEQUENCES where SEQUENCE_OWNER='" + dbUser + "' and SEQUENCE_name='" + sequencesName + "'";
                using (DataSet Ds = OracleHelper.ExecuteDataset(trans, CommandType.Text, strql))
                {
                    string sql = "select " + sequencesName + ".nextval from dual";
                    if (Ds.Tables[0].Rows.Count == 0)
                    {
                        string leng = "";
                        for (int i = 0; i < sequencesLength; i++)
                        {
                            leng = leng + "9";
                        }
                        string strcreat = "create sequence " + sequencesName + " minvalue 1 maxvalue  " + leng;

                        OracleHelper.ExecuteNonQuery(trans, CommandType.Text, strcreat);
                    }
                    using (DataSet Dq = OracleHelper.ExecuteDataset(trans, CommandType.Text, sql))
                    {
                        if (Dq.Tables[0].Rows.Count > 0)
                        {
                            sequencesName = Dq.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }

                //根据序列的格式，替换当前格式中的值
                format = format.Replace("YY", sysDate.Substring(2,2));//替换YY为2位年份，如2005年中的05

                sequencesName = format + sequencesName.PadLeft(sequencesLength, '0');
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                CloseTrans(trans);
                CloseConn(conn);
            }

            return sequencesName;
        }

        /// <summary>
        /// 获得系统日期
        /// </summary>
        /// <param name="dateLength">需要得到的系统时间字符串的长度，8位或14位，8位格式为YYYYMMDD，14位格式为YYYYMMDDHHMMSS</param>
        /// <param name="dateType">时间格式，"0" YYYYMMDDhhmmss; "1" YYYY年MM月DD日hh:mm:ss</param>
        /// <returns></returns>
        public  string GetSysDate()
        {
            IDbConnection conn = GetConnection();
            string dbDate = "";
            try
            {
                AdoHelper OracleHelper = GetAdoHelper();
                string strSql = "Select TO_CHAR(SYSDATE, 'YYYY-MM-DD HH24:MI:SS') AS DBDATE from dual";

                using (IDataReader dr = OracleHelper.ExecuteReader(conn, CommandType.Text, strSql.ToString()))
                {
                    if (dr.Read())
                    {
                        dbDate = dr["DBDATE"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
            return dbDate;
        }
    }
}
