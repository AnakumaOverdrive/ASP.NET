using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.Common.Data
{  
    /// <summary>
    /// 联合查询参数Entity
    /// </summary>
    public class RootJoinTable : BasicQueryObject
    {
      //  public TableJoinType JoinType { get; set; }
        public string JoinExpression { get; set; }
    }
}
