using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.CodeBuilder.Model
{
    /// <summary>
    /// 数据类型配置类
    /// 作者:刘伟通
    /// 日期:2010年7月30日
    /// </summary>
    public class DataType
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        /// <param name="csharpType">C#数据类型</param>
        /// <param name="dbType">C#中DB数据类型</param>
        /// <param name="dbDataType">数据库数据类型</param>
        /// <param name="convertString">数据类型转换方法</param>
        public DataType(string csharpType, string dbType, string dbDataType, string convertString,bool autoWidth)
        {
            this.CSharpType = csharpType;
            this.DbType = dbType;
            this.DbDataType = dbDataType;
            this.ConvertString = convertString;
            this.AutoWidth = autoWidth;
        }
        /// <summary>
        /// C#数据类型
        /// </summary>
        public string CSharpType { get; set; }

        /// <summary>
        /// C#中DB数据类型
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// 数据库数据类型
        /// </summary>
        public string DbDataType { get; set; }

        /// <summary>
        /// 数据类型转换方法
        /// </summary>
        public string ConvertString { get; set; }

        public bool AutoWidth { get; set; }
    }
}
