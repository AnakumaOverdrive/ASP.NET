using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;

namespace Esint.CodeBuilder.Model
{
    public class PrimaryKeyClass : IPrimaryKeyClass
    {
        public PrimaryKeyClass()
        {
            this.Columns = new List<IColumn>();
        }
        /// <summary>
        /// 主键 名称
        /// </summary>
        public string PrimaryKeyName { get; set; }

        /// <summary>
        /// 所属表表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 主键所包含的列
        /// </summary>
        public List<IColumn> Columns { get; set; }

    }
}
