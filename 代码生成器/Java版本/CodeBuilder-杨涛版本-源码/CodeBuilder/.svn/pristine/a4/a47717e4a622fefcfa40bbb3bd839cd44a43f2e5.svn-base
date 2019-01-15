using System;
namespace Esint.CodeBuilder.InterFace
{
    public interface IColumn
    {
        /// <summary>
        /// Camel格式字段名(首字母小写)
        /// </summary>
        string CamelName { get; }

        /// <summary>
        /// 字段编号
        /// </summary>
        int ColumnID { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        int? ColumnLength { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        string ColumnName { get; set; }

        /// <summary>
        /// 小数位
        /// </summary>
        int ColumnScale { get; set; }

        /// <summary>
        /// 控件属性
        /// </summary>
        IControlProperty ControlProperty { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        IColDataType DataType { get;set; }

        /// <summary>
        /// 缺省值
        /// </summary>
        object DefaultValue { get; set; }

        /// <summary>
        /// 字段含义
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 是否外键 
        /// </summary>
        bool IsForeignKey { get; set; }

        /// <summary>
        /// 是否自增序列
        /// </summary>
        bool IsIndentity { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>
        bool IsNull { get; set; }

        /// <summary>
        /// 是否主键 
        /// </summary>
        bool IsPrimaryKey { get; set; }

        /// <summary>
        /// Pascal格式字段名称(首字母大写)
        /// </summary>
        string PascalName { get; }

        /// <summary>
        /// 表名
        /// </summary>
        string TableName { get; set; }

    }
}
