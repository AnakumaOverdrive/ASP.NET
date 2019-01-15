using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.CodeBuilder.Public;

namespace Esint.CodeBuilder.Model
{
    /// <summary>
    /// 生成代码的数据表
    /// 作者:刘伟通
    /// 日期:2010年8月1日
    /// </summary>
    public class DbTable : IDbTable
    {
        /// <summary>
        /// 生成代码数据表
        /// </summary>
        public DbTable()
        {
            // 数据表列集合
            this.Columns = new List<IColumn>();

            //数据表外键集合
            this.ForeignKeys = new List<IForeignKeyClass>();
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表所有者
        /// </summary>
        public string Owner { get; set; }
        
        /// <summary>
        /// 表含义
        /// </summary>
        private string _tabledescription;
        public string TableDescription
        {
            get
            {
                if (!string.IsNullOrEmpty(_tabledescription))
                    return _tabledescription.Replace("\r\n", "");
                else return "";
            }
            set
            {
                _tabledescription = value;
            }
        }

        /// <summary>
        /// 表短名称(去配置项的表头)
        /// </summary>
        public string ShortTableName
        {
            get
            {
                //if (TableName.ToUpper().IndexOf(PublicClass.TableHeaderString.ToUpper()) == 0)
                //    return TableName.Substring(PublicClass.TableHeaderString.Length);
                //else
                    return TableName;
            }
        }

        /// <summary>
        /// 表类型(表还是视图 Table 为表,View 为视图)
        /// </summary>
        public string TableType { get; set; }

        /// <summary>
        /// 完整的表名称
        /// </summary>
        public string FullTablename { get; set; }

        /// <summary>
        /// 表ID
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// 表的列集合
        /// </summary>
        public List<IColumn> Columns { get; set; }

        /// <summary>
        /// 表的主键 
        /// </summary>
        public IPrimaryKeyClass PrimaryKey { get; set; }

        /// <summary>
        /// 表的外键集合
        /// </summary>
        public List<IForeignKeyClass> ForeignKeys { get; set; }

        /// <summary>
        /// 表的Pascal格式表名(短名称)
        /// </summary>
        public string PascalName { get { return Uitility.ConvertToPascal(ShortTableName); } }

        /// <summary>
        /// 表的Camel格式表名称(短名称)
        /// </summary>
        public string CamelName { get { return Uitility.ConvertToCamel(ShortTableName); } }

        /// <summary>
        /// 关联子表列表
        /// </summary>
        public List<IDbTable> SubTables { get; set; }

    }
}
