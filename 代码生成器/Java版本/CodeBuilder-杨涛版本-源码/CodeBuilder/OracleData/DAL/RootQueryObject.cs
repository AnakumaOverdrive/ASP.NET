using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Esint.Common.Data
{

    /// <summary>
    /// 
    /// </summary>
    public partial class RootQueryObject:BasicQueryObject
    {
       
        /// <summary>
        /// 排序字段列表
        /// </summary>
        public string OrderByString { get; set; }

        /// <summary>
        /// 主键列
        /// </summary>
        public string PrimaryKeyField { get; set; }

        /// <summary>
        /// 聚组字符串
        /// </summary>
        public string GroupByString { get; set; }

        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPageView { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary> 
        public int _pageIndex = 1;
        public int PageIndex { get { return _pageIndex; } set { _pageIndex = value; } }

        /// <summary>
        /// 分页大小
        /// </summary> 
        public int _pagesize = 10;
        public int PageSize { get { return _pagesize; } set { _pagesize = value; } }

        /// <summary>
        /// 总页数
        /// </summary>
        public long PageCount { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long RecordCount { get; set; }

     
        private List<IDataParameter> _dataParameters;
        internal  List<IDataParameter> DbParameters
        {
            get
            {
                if (_dataParameters == null)
                    _dataParameters = new List<IDataParameter>();
                return _dataParameters;
            }
            set
            {
                _dataParameters = value;
            }
         }

        private List<RootJoinTable> _joinTables;
        public List<RootJoinTable> JoinTables
        {
            get
            {
                if (_joinTables == null)
                    _joinTables = new List<RootJoinTable>();
                return _joinTables;
            }
            set
            {
                _joinTables = value;
            }
        }

    }
}
