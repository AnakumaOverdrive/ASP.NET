using System.Collections.Generic;
using System.Data;
using Esint.Common.Model;
using Esint.CodeSite.Model;

namespace Esint.CodeSite.IDAL
{
    /// <summary>
    /// 模块名称：人员基本信息 数据访问接口层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月14日
    /// 生成模板: Esint.Template.IDAL.IDAL_01 版
    /// 修改说明：
    /// </summary>
    public partial interface ISys_UsersData:IBaseData
    {
        Sys_UsersInfo UserLogin(string loginName, string LoginPwd, string IpStr);
    }
}
