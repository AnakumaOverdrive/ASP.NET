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
    /// 模块名称：人员基本信息 数据访问层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月14日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    ///           适用于工厂模式架构
    /// 修改说明：
    /// </summary>
    public partial class Sys_UsersData  : BaseData, ISys_UsersData
    {
        public Sys_UsersInfo UserLogin(string loginName, string LoginPwd, string IpStr)
        {

            DataQuery query = new DataQuery();
            query.SQLText = @"select * from T_Sys_Users WHERE 1=1 And IsEffective='1'";

            if (!string.IsNullOrEmpty(loginName))
            {
                query.SQLText += " And UserName= @UserName";
                query.WhereParameters.Add(new WhereParameter("@UserName", loginName));
            }
            if (!string.IsNullOrEmpty(LoginPwd))
            {
                query.SQLText += " And PassWord= @PassWord";
                query.WhereParameters.Add(new WhereParameter("@PassWord", LoginPwd));
            }

            List<Sys_UsersInfo> userList = GetSys_UsersList(query);

            if (userList.Count > 0)
            {
                Sys_UsersInfo user = new Sys_UsersInfo();
                user.UserID = userList[0].UserID;
                user.LastLoginIP = IpStr;
                user.LastLoginTime = DateTime.Now;
                user.LoginTimes = userList[0].LoginTimes + 1;
                Update(user);

                return userList[0];
            }
            else
            {
                return null;
            }
        }
    }
} 
