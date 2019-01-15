using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Esint.Common;
using Esint.Common.Model;

namespace Esint.CodeSite.Model
{
    /// <summary>
    /// 文件说明: 人员基本信息信息实体
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月14日
    /// 生成模板: Esint.Template.Model.Model_01 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Sys_UsersInfo : BaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserID { get; set; }
 
        /// <summary>
        /// 部门编号
        /// </summary>
        public Guid DepartmentID { get; set; }
 
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
 
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
 
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { get; set; }
 
        /// <summary>
        /// 是否有效(0:有效,1:禁用)
        /// </summary>
        public string IsEffective { get; set; }
 
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
 
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }
 
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
 
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
 
        /// <summary>
        /// 登录资数
        /// </summary>
        public int? LoginTimes { get; set; }
 
        /// <summary>
        /// 添加人
        /// </summary>
        public string OpName { get; set; }
 
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? OpTime { get; set; }
 
    }
}
