using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.Common
{
    /// <summary>
    /// 数据查询
    /// </summary>
    public class DataQuery
    {
        /// <summary>
        /// SQL文本串，非必要时，禁用，使用时，应参数化传递
        /// </summary>
        public string SqlText { get; set; }

        private string _alias = "a";
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias
        {
            get
            {
                return _alias;
            }

            set
            {
                _alias = value;
            }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        //public string OrderByString { get; set; }


        private PageView _pageView;

        /// <summary>
        /// 分页对象
        /// </summary>
        public PageView PageView
        {
            get
            {
                if (_pageView == null)
                    _pageView = new PageView();
                return _pageView;
            }
            set
            {
                _pageView = value;
            }
        }

        private DynamicParameters _whereParameters;

        /// <summary>
        /// 查询参数
        /// param.Add("StartDate1", starttime, DbType.String, null, 10);
        /// new { Type = type, Year = year }
        /// </summary>
        public DynamicParameters WhereParameters
        {
            get
            {
                if (_whereParameters == null)
                    _whereParameters = new DynamicParameters();
                return _whereParameters;
            }
            set
            {
                _whereParameters = value;
            }
        }
    }
}
