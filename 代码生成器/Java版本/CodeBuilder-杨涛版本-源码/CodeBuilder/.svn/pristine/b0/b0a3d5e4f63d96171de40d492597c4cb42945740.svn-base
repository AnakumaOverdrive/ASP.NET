using System;
using System.Collections.Generic;
using System.Data;
using Esint.CodeSite.Model;

namespace Esint.CodeSite.IDAL
{
    /// <summary>
    /// 模块名称：代码表 数据访问接口层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月09日
    /// 生成模板: Esint.Template.IDAL.IDAL_01 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial interface ISys_CodeData:IBaseData
    {

        /// <summary>
        /// 将实体代码表插入Sys_Code表中
        /// </summary>
        /// <param name="sys_Code">代码表实体</param>
        void Insert(Sys_CodeInfo sys_Code);

        /// <summary>
        /// 根据主键,更新实体代码表(Sys_Code)
        /// </summary>
        /// <param name="sys_Code">代码表实体</param>
        void Update(Sys_CodeInfo sys_Code);

        /// <summary>
        /// 根据主键,删除实体对象 
        /// </summary>
        /// <param name="flag">代码类别</param>
        /// <param name="code">代码</param>
        void Delete(string flag,string code);

        /// <summary>
        /// 根据主键查询 代码表对象
        /// </summary>
        /// <param name="flag">代码类别</param>
        /// <param name="code">代码</param>
        /// <returns> 代码表对象</returns>
        Sys_CodeInfo GetSys_CodeInfo(string flag,string code);

        /// <summary>
        /// 根据主键,查询 代码表对象是否存在
        /// </summary>
        /// <param name="flag">代码类别</param>
        /// <param name="code">代码</param>
        /// <returns>true 存在,false 不存在</returns>
        bool IsExist(string flag,string code);

    }
}
