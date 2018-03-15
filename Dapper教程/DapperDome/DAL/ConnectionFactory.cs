using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionFactory
    {
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection Creator()
        {
            IDbConnection conn = null;
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                string connectionName = ConfigurationManager.AppSettings["ConnectionName"];
                string connectionString = string.Empty;
                switch (connectionName)
                {
                    case "SQLServer":
                        connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                        break;
                    case "Access":
                        connectionString = ConfigurationManager.AppSettings["AccessConnectionString"];
                        break;
                    default:
                        connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                        break;
                }

                return connectionString;
            }
        }
    }
}
