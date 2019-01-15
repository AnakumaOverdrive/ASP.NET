using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace Esint.CodeBuilder.MySqlData.DAL
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
            MySqlDataAccess.ConnectString = connectString;
            MySqlDataAccess sda = new MySqlDataAccess();
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
