using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.Common
{
    /// <summary>
    /// 分页对象
    /// </summary>
    public class PageView
    {
        /// <summary>
        /// 当前索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPageView { get; set; }
    }
}
