using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace Esint.CodeBuilder.SqlData.DAL
{
    public class DataBaseInfo
    {
        /// <summary>
        /// 测试是否可以连接SQL数据库
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static bool TestSqlConnect(string connectString)
        {
            SqlDataAccess.ConnectString = connectString;
            SqlDataAccess sda = new SqlDataAccess();
            bool isConnect = false;
            IDbConnection conn = null;
            try
            {
                conn = sda.GetConnection();
                isConnect = true;
            }
            catch  
            {
                isConnect = false;
            }
            finally
            {
                sda.CloseConn(conn);
            }
            return isConnect;
        }
    }
}
