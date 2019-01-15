using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.CodeBuilder.Public;

namespace Esint.CodeBuilder.Model
{
    public class ColDataType : IColDataType
    {
        public string DbDataType { get; set; }
        /// <summary>
        /// 是否自动宽度
        /// </summary>
        public bool AutoWidth { get { return Uitility.GetIsAutoWidth(DbDataType); } }

        public string CSharpType { get { return Uitility.ConvertToCSharp(DbDataType); } }

        public string ConvertString { get { return Uitility.GetConvertString(DbDataType); } }

        public string DbType { get { return Uitility.ConvertToDbType(DbDataType); } }
    }
}
