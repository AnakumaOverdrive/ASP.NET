using System.Collections.Generic;
using System.Data;
using Esint.Common.Model;
using Esint.CodeSite.Model;
using System;

namespace Esint.CodeSite.IDAL
{
    /// <summary>
    /// 模块名称： 数据访问接口层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月18日
    /// 生成模板: Esint.Template.IDAL.IDAL_01 版
    /// 修改说明：
    /// </summary>
    public partial interface IInfo_ArticleData:IBaseData
    {
        /// <summary>
        /// 功能说明: 根据条件查询  列表，返回DataTable
        /// 作    者: 刘伟通
        /// 日    期: 2012年09月18日
        /// </summary>
        /// <param name="pageView">分页对象</param>
        /// <param name="orderStr">排序字段</param>
        /// <param name="title">标题</param>
        /// <param name="category">类别编号</param>
        /// <returns>  DataTable结果集</returns>
        ReturnTable GetInfo_ArticleTable(PageSplit pageView, string orderStr, string title, Guid category);

    }
}
