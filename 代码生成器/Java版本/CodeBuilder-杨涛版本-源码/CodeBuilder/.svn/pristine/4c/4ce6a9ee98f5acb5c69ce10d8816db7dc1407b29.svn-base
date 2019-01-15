using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace Esint.CodeBuilder.SqlData.DAL
{
    public class SqlDataAccess 
    {
   
        static string _connectString;
        public SqlDataAccess()
        {
        }

        IDbConnection _sqlConn;
        IDbTransaction _sqlTrans;

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SqlDataAccess()
        {
            //关闭事务
            if (_sqlTrans != null)
            {
                IDbConnection conn = _sqlTrans.Connection;
                _sqlTrans.Dispose();

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
            if (_sqlConn != null)
            {
                if (_sqlConn.State != ConnectionState.Closed)
                {
                    _sqlConn.Close();

                }
                _sqlConn.Dispose();
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
            _sqlConn = new SqlConnection(ConnectString);
            try
            {
                _sqlConn.Open();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return _sqlConn;
        }

        /// <summary>
        /// 打开数据库链接操作
        /// </summary>
        /// <returns>OracleConnection</returns>
        public IDbConnection GetConnection(string connectString)
        {
            _sqlConn = new SqlConnection(ConnectString);
            try
            {
                _sqlConn.Open();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return _sqlConn;
        }

        /// <summary>
        /// 建立数据库事务
        /// </summary>
        /// <returns></returns>
        public IDbTransaction GetTransaction()
        {
            _sqlConn = new SqlConnection(ConnectString);
            _sqlConn.Open();
            _sqlTrans = _sqlConn.BeginTransaction();
            return _sqlTrans;
        }

        /// <summary>
        /// 关闭数据库链接 
        /// </summary>
        /// <param name="_oracleconn"></param>
        public void CloseConn(IDbConnection connect)
        {
            _sqlConn = connect;
            if (_sqlConn != null)
            {
                if (_sqlConn.State != ConnectionState.Closed)
                {
                    _sqlConn.Close();

                }
                _sqlConn.Dispose();
            }
        }

        /// <summary>
        /// 关闭事务
        /// </summary>
        /// <param name="trans"></param>
        public void CloseTrans(IDbTransaction trans)
        {
            _sqlTrans = trans;
            if (_sqlTrans != null)
            {
                IDbConnection conn = _sqlTrans.Connection;
                _sqlTrans.Dispose();

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
        /// 获得系统日期
        /// </summary>
        /// <param name="dateLength">需要得到的系统时间字符串的长度，8位或14位，8位格式为YYYYMMDD，14位格式为YYYYMMDDHHMMSS</param>
        /// <param name="dateType">时间格式，"0" YYYYMMDDhhmmss; "1" YYYY年MM月DD日hh:mm:ss</param>
        /// <returns></returns>
        public string GetSysDate()
        {
            IDbConnection conn = GetConnection();
            string dbDate = "";
            try
            {

                string strSql = "Select GETDATE() AS DBDATE";

                using (IDataReader dr = SqlHelper.ExecuteReader((SqlConnection)conn, CommandType.Text, strSql.ToString()))
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

        public SqlDataReader ExecuteReader(IDbConnection conn, CommandType commandType, string SQL)
        {
            return SqlHelper.ExecuteReader((SqlConnection)conn, commandType, SQL);
        }
    }
}
