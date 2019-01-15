using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.Common.Data
{
   public  class BasicQueryObject
    { /// <summary>
        /// 查询字段列表,多字段之间用","连接。
        /// </summary>
        public string FieldString { get; set; }

        /// <summary>
        /// 数据表列表
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 数据表别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// SQL文本串，非必要时，禁用，使用时，应参数化传递
        /// </summary>
        public string SQLText { get; set; }

        /// <summary>
        /// 条件参数列表
        /// </summary>
        private List<WhereParameter> _whereParameters = null;
        public List<WhereParameter> WhereParameters
        {
            get
            {
                if (_whereParameters == null)
                    _whereParameters = new List<WhereParameter>();
                return _whereParameters;
            }
            set
            {
                _whereParameters = value;
            }
        }

    }
}
