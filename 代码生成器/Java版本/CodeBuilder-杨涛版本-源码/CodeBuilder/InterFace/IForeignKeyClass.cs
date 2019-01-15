using System;
namespace Esint.CodeBuilder.InterFace
{
    /// <summary>
    /// 外键 接口
    /// </summary>
    public interface IForeignKeyClass
    {
        /// <summary>
        /// 外键 列集合
        /// </summary>
        System.Collections.Generic.List<IForeignKeyColumn> FKColumns { get; set; }

        /// <summary>
        /// 外键 名
        /// </summary>
        string ForeignKeyName { get; set; }

        /// <summary>
        /// 外键关联的表名
        /// </summary>
        string TableName { get; set; }
    }
}
