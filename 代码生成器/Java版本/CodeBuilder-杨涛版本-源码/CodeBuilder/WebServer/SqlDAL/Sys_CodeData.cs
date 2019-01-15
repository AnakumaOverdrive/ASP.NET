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
    /// 模块名称：代码表 数据访问层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月09日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    ///           适用于工厂模式架构
    /// 修改说明：
    /// </summary>
    public partial class Sys_CodeData  : BaseData, ISys_CodeData
    {
        public List<Sys_CodeInfo> GetCodeListByFlag(string flag)
        {
            DataQuery query = new DataQuery();
            if (!string.IsNullOrEmpty(flag))
                query.WhereParameters.Add(new WhereParameter("And IS_ENABLE=1 And Flag = @Flag", "@Flag", flag));
            return GetSys_CodeList(query);
        }

    }
} 
