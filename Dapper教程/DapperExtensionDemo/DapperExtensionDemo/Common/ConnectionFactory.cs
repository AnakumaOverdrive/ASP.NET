using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.Common
{
    public class ConnectionFactory
    {
        /// <summary>
        /// 创建默认链接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection Creator()
        {
            IDbConnection conn =  conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString(ConnectionType.ChaiQianMap));
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection Creator(ConnectionType connectionType)
        {
            IDbConnection conn = null;
            //conn = new SqlConnection(ConnectionString(connectionType));
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString(connectionType));

            conn.Open();
            return conn;
        }


        /// <summary>
        /// 获取连接字符串
        /// </summary>
        private static string ConnectionString(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.ChaiQian:
                    return System.Configuration.ConfigurationManager.ConnectionStrings["ChaiQianConnection"].ConnectionString;
                case ConnectionType.ChaiQianMap:
                    return System.Configuration.ConfigurationManager.ConnectionStrings["ChaiQianMapConnection"].ConnectionString;
                default:
                    return System.Configuration.ConfigurationManager.ConnectionStrings["ChaiQianMapConnection"].ConnectionString;
            }
        }
    }

    public enum ConnectionType
    {
        /// <summary>
        /// 连接数据库枚举
        /// </summary>
        ChaiQian,
        ChaiQianMap

    }
}
