using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Esint.Common.Data 
{
    public class OperateObject
    {
        /// <summary>
        /// 执行的SQL语句
        /// </summary>
        public string SqlText { get; set; }

        /// <summary>
        /// SQL语句对应的参数列表
        /// </summary>
        private List<IDataParameter> paras;
        public List<IDataParameter> Parameters
        {
            get
            {
                if (paras == null)
                    paras = new List<IDataParameter>();
                return paras;
            }
            set
            {
                paras = value;
            }
        }

        
    }
}
