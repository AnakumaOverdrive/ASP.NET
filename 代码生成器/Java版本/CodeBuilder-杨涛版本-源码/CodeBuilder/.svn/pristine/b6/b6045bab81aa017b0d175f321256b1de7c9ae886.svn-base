using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Esint.CodeBuilder.Model
{
    public static class EnumExtend
    {
        /// <summary>
        /// 数据库类型扩展类
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        public static string ToCode(this DataBaseType dataBaseType)
        {
            string returnValue = "";

            switch(dataBaseType)
            {
                case DataBaseType.Oracle:
                    returnValue = "Oracle";
                    break;
                case DataBaseType.SqlServer:
                    returnValue = "SqlServer";
                    break;
                case DataBaseType.MySql:
                    returnValue = "MySql";
                    break;
                default:
                    returnValue = "";
                    break;
            }
            return returnValue;
        }

        public static DataBaseType ToDataBaseType(string dataBaseTypeStr)
        {
            DataBaseType returnValue;
            switch (dataBaseTypeStr)
            {
                case "Oracle":
                    returnValue =DataBaseType.Oracle;
                    break;
                case "SqlServer":
                    returnValue = DataBaseType.SqlServer;
                    break;
                case "MySql":
                    returnValue = DataBaseType.MySql;
                    break;
                default:
                    returnValue = DataBaseType.NULL;
                    break;
            }
            return returnValue;
        }
    }
}
