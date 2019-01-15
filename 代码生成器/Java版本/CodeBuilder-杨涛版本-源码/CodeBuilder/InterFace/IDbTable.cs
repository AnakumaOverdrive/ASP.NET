using System;
using System.Collections.Generic;
namespace Esint.CodeBuilder.InterFace
{
    /// <summary>
    /// 用于生成模板的数据表
    /// </summary>
    public interface IDbTable
    {
        /// <summary>
        /// 表名
        /// </summary>
        string TableName { get; set; }

        /// <summary>
        /// 所有者
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        /// 表含义
        /// </summary>
        string TableDescription { get; set; }

        /// <summary>
        /// 表短名称(去配置项的表头)
        /// </summary>
        string ShortTableName { get; }

        /// <summary>
        /// 表类型(表还是视图 Table 为表,View 为视图)
        /// </summary>
        string TableType { get; set; }

        /// <summary>
        /// 完整的表名称
        /// </summary>
        string FullTablename { get; set; }

        /// <summary>
        /// 表ID
        /// </summary>
        int TableID { get; set; }

        /// <summary>
        /// 表的列集合
        /// </summary>
        List<IColumn> Columns { get; set; }

        /// <summary>
        /// 表的主键 
        /// </summary>
        IPrimaryKeyClass PrimaryKey { get; set; }

        /// <summary>
        /// 表的外键集合
        /// </summary>
        List<IForeignKeyClass> ForeignKeys { get; set; }

        /// <summary>
        /// 表的Pascal格式表名(短名称)
        /// </summary>
        string PascalName { get; }

        /// <summary>
        /// 表的Camel格式表名称(短名称)
        /// </summary>
        string CamelName { get; }

        List<IDbTable> SubTables { get; set; }



    }
}
