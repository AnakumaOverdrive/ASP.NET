using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;

namespace Esint.CodeBuilder.Model
{
    public class ForeignKeyClass : IForeignKeyClass
    {
        public ForeignKeyClass()
        {
            FKColumns = new List<IForeignKeyColumn>();
        }

        /// <summary>
        /// 外键 名称
        /// </summary>
        public string ForeignKeyName { get; set; }

        /// <summary>
        /// 所属表表名称
        /// </summary>
        public string TableName { get; set; }

        //外键列集合
        public List<IForeignKeyColumn> FKColumns { get; set; }
    }
}
