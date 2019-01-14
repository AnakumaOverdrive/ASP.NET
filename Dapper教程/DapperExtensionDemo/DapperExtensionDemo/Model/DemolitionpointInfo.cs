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
    /// 文件说明:  t_demolitionpoint信息实体
    /// 作    者: Esint
    /// 生成日期: 2018年05月24日
    /// * [Table("dbTable")] - 使用另一个表名而不是类的名称
    /// * [Key] - 此属性表示数据库生成的标识/密钥。 如自动增长主键
    /// * [ExplicitKey] - 此属性表示不由数据库自动生成的显式标识/密钥。 如GUID等.
    /// * [Write(true/false)] - 此属性是（不是）可写的。
    /// * [Computed] - 此属性被计算，不应成为更新的一部分。
    /// 修改说明：
    /// </summary>
    [Table("t_demolitionpoint")]
    public partial class DemolitionpointInfo : BaseModel
    {

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int col_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? col_AreaID { get; set; }

        /// <summary>
        /// 棚户区改造名称
        /// </summary>
        public string col_Name { get; set; }

        /// <summary>
        /// 四至范围
        /// </summary>
        public string col_Range { get; set; }

        /// <summary>
        /// 多棚户区改造片总称
        /// </summary>
        public string col_TotalName { get; set; }

        /// <summary>
        /// 父片唯一标识
        /// </summary>
        public string col_ParentKey { get; set; }

        /// <summary>
        /// 棚户区改造片唯一标识
        /// </summary>
        public string col_Key { get; set; }

        /// <summary>
        /// 1 包含多个棚户区改造片  2  实际棚户区改造片
        /// </summary>
        public int? col_flag { get; set; }

        /// <summary>
        /// 1 正常 2 归档
        /// </summary>
        public int? col_Archive { get; set; }

        /// <summary>
        /// 该棚户区改造片状态  1 正常  2 删除
        /// </summary>
        public int? col_state { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? col_CreateDate { get; set; }

        /// <summary>
        /// 责任单位
        /// </summary>
        public string col_Cliability { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public string col_Pliability { get; set; }

        /// <summary>
        /// 1 成片棚户区  2  散点棚户区  3危房棚户区
        /// </summary>
        public int? col_DemoType { get; set; }

        /// <summary>
        /// 投资责任主体
        /// </summary>
        public string col_investment { get; set; }

        /// <summary>
        /// 1 原 2 新增
        /// </summary>
        public int? col_sourcetype { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        public int? col_index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? col_Point { get; set; }

        /// <summary>
        /// 启动状态 1启动 2未启动 3暂停 4完成
        /// </summary>
        public int? col_StartState { get; set; }

    }
}
