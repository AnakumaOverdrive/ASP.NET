using Dapper.Contrib.Extensions;
using DapperExtensionDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.Model
{
    /// <summary>
    /// 文件说明: 测试用, 与程序,业务,逻辑无关. t_test信息实体
    /// 作    者: Esint
    /// 生成日期: 2018年05月23日
    /// 修改说明：
    /// </summary>
    [Table("t_test")]
    public class TestInfo : BaseModel
    {
        /*
         * [Table("dbTable")] - 使用另一个表名而不是类的名称
         * [Key] - 此属性表示数据库生成的标识/密钥。 如自动增长主键
         * [ExplicitKey] - 此属性表示不由数据库自动生成的显式标识/密钥。 如GUID等.
         * [Write(true/false)] - 此属性是（不是）可写的。
         * [Computed] - 此属性被计算，不应成为更新的一部分。
         */
        /// <summary>
        /// ID
        /// </summary>
        [ExplicitKey]
        public int col_Id { get; set; }

        /// <summary>
        /// 从ID
        /// </summary>
        public string col_did { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string col_name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? col_age { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? col_date { get; set; }

        /// <summary>
        /// 浮点型
        /// </summary>
        public double? col_double { get; set; }

    }
    
}
