using System;
using Esint.CodeSite.Model;
using Esint.CodeSite.Factory;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;

namespace Esint.CodeSite.BLL
{
    /// <summary>
    /// 文件说明: 代码表 业务逻辑层
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月09日
    /// 模板版本: Esint.Template.BLL.BLL_11 版，适用于反射工厂模式开发!
    /// 特别说明: 本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Sys_CodeService
    {
        private ISys_CodeData dataAccess = Factory.Factory.CreateSys_CodeData();
        /// <summary>
        /// 插入Sys_CodeInfo 实体
        /// <summary>
        /// <param name="sys_Code"></param>
        public void Insert(Sys_CodeInfo sys_Code)
        {
            dataAccess.Insert(sys_Code);
        }

        /// <summary>
        /// 根据主键更新Sys_CodeInfo 实体
        /// <summary>
        /// <param name="sys_Code"></param>
        public void Update(Sys_CodeInfo sys_Code)
        {
            dataAccess.Update(sys_Code);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        public void Delete(string flag,string code)
        {
            dataAccess.Delete(flag,code);
        }

        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Sys_CodeInfo GetSys_CodeInfo(string flag,string code)
        {
            return dataAccess.GetSys_CodeInfo(flag,code);
        }

    }
}
