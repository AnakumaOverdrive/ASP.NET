using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Esint.Common.Data;
using Esint.CodeSite.Model;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;
using System.Data.SqlClient;

namespace Esint.CodeSite.SqlDAL
{
    /// <summary>
    /// 模块名称： 数据访问层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月18日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    ///           适用于工厂模式架构
    /// 修改说明：
    /// </summary>
    public partial class Info_ArticleData  : BaseData, IInfo_ArticleData
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
        public ReturnTable GetInfo_ArticleTable(PageSplit pageView, string orderStr, string title, Guid category)
        {
            ReturnTable returnTable = new ReturnTable();
            DataQuery query = new DataQuery();

            query.SQLText = @"SELECT T_Info_Article.AritcleID,T_Info_Article.Title As Title,T_Info_Article.OpName As OpName,T_Info_Article.OPTime As OPTime FROM T_Info_Article T_Info_Article 
                            WHERE 1=1 ";

            if (!string.IsNullOrEmpty(title))
            {
                query.SQLText += " And T_Info_Article.TITLE= @Title";
                query.WhereParameters.Add(new WhereParameter("@Title", title));
            }

            if (category!=Guid.Empty)
            {
                query.SQLText += " And T_Info_Article.CATEGORY= @Category";
                query.WhereParameters.Add(new WhereParameter("@Category", category));
            }
            query.OrderByString = orderStr;

            query.PageView = pageView;      //分页
            // 排序

            returnTable.Table = BaseData.ExecuteDataTable(query);
            returnTable.PageInfo = query.PageView;
            return returnTable;
        }

    }
} 
