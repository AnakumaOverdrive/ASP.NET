using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Esint.CodeSite.Model;
using Esint.CodeSite.Factory;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;

namespace Esint.CodeSite.BLL
{
    /// <summary>
    /// 文件说明:  业务逻辑层
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月18日
    /// 模板版本: Esint.Template.BLL.BLL_01 版，适用于简单三层开发!
    /// 功能说明：
    /// </summary>
    public partial class Info_ArticleService
    {
        /// <summary>
        /// 功    能: 保存对象
        /// 说    明: 当主键为空时，新增操作
        ///           当主键不为空，根据主键进行修改
        /// <summary>
        public void Save(Info_ArticleInfo info_Article)
        {
            if (info_Article.AritcleID==Guid.Empty)
            {
                 dataAccess.Insert(info_Article);
            }
            else
            {
                 dataAccess.Update(info_Article);
            }
        }

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
        public ReturnTable GetInfo_ArticleTable(PageSplit pageView, string orderStr, string title, Guid category)
        {
            return dataAccess.GetInfo_ArticleTable(pageView, orderStr, title, category);
        }
    }
}
