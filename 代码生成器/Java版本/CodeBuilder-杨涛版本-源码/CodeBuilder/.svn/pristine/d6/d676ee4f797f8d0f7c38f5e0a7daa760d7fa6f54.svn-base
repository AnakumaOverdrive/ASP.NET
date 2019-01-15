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
    /// 生成日期：2012年09月17日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    ///           适用于工厂模式架构
    /// 修改说明：
    /// </summary>
    public partial class Info_CategoryData  : BaseData, IInfo_CategoryData
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cateType"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Info_CategoryInfo> GetCategoryList(string cateType, Guid UserId)
        {
            DataQuery query = new DataQuery();
            query.SQLText = "Select * from T_Info_Category Where 1=1 ";
            if (!string.IsNullOrEmpty(cateType))
            {
                query.SQLText += " And CategoryType=@CategoryType ";
                query.WhereParameters.Add(new WhereParameter("@CategoryType", cateType));
            }

            if (UserId != Guid.Empty)
            {
                query.SQLText += " And UserId=@UserId ";
                query.WhereParameters.Add(new WhereParameter("@UserId", UserId));
            }
            return GetInfo_CategoryList(query);
        }
    }
} 
