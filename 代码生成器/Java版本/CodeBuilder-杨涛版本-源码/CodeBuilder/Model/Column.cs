using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.CodeBuilder.Public;

namespace Esint.CodeBuilder.Model
{
    /// <summary>
    /// 数据列
    /// 作者:刘伟通
    /// 日期:2010年7月30日
    /// </summary>
    public class Column : IColumn
    {
        public Column()
        {
            this.ControlProperty = new ControlProperty();
        }

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 字段编号
        /// </summary>
        public int ColumnID { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public int? ColumnLength { get; set; }

        /// <summary>
        /// 小数位
        /// </summary>
        public int ColumnScale { get; set; }

        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsNull { get; set; }

        /// <summary>
        /// 缺省值
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// 是否自增字段
        /// </summary>
        public bool IsIndentity { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 是否外键
        /// </summary>
        public bool IsForeignKey { get; set; }

        /// <summary>
        /// 字段说明
        /// </summary>
        private string _description;
        public string Description
        {
            get
            {
                if (!string.IsNullOrEmpty(_description))
                    return _description.Replace("\r\n", "").Replace("\n", "");
                else return "";
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// 控件属性
        /// </summary>
        public IControlProperty ControlProperty { get; set; }

        /// <summary>
        /// Camal格式名称(首字母小写)
        /// </summary>
        public string CamelName
        {
            get
            {
                return Uitility.ConvertToCamel(ColumnName);
            }
        }

        /// <summary>
        /// Pascal格式名称(首字母大写)
        /// </summary>
        public string PascalName
        {
            get
            {
                return Uitility.ConvertToPascal(ColumnName);
            }
        }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        private IColDataType _dataType;
        public IColDataType DataType 
        { 
            get
            {
                if (_dataType == null)
                    _dataType = new ColDataType();
                return _dataType;
            }
            set
            { 
                _dataType = value;
            } 
        }
    }
}
