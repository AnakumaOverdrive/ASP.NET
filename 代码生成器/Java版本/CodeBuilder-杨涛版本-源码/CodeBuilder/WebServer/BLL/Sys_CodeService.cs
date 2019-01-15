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
    /// 文件说明: 代码表 业务逻辑层
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月09日
    /// 模板版本: Esint.Template.BLL.BLL_01 版，适用于简单三层开发!
    /// 功能说明：
    /// </summary>
    public partial class Sys_CodeService
    {
        /// <summary>
        /// 功    能: 保存代码表对象
        /// 说    明: 当主键为空时，新增操作
        ///           当主键不为空，根据主键进行修改
        /// <summary>
        public void Save(Sys_CodeInfo sys_Code)
        {
            if (String.IsNullOrEmpty(sys_Code.Flag) || String.IsNullOrEmpty(sys_Code.Code) )
            {
                 dataAccess.Insert(sys_Code);
            }
            else
            {
                 dataAccess.Update(sys_Code);
            }
        }

        public List<Sys_CodeInfo> GetCodeListByFlag(string flag)
        { 
            return dataAccess.GetCodeListByFlag(flag);
        }
    }
}
