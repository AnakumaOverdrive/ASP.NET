using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.CodeBuilder.InterFace
{
    /// <summary>
    /// 模板接口
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// 文件名
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        string NameSpace { get; set; }

        /// <summary>
        /// 当前操作人
        /// </summary>
        string OperName { get; set; }

        /// <summary>
        /// 数据表
        /// </summary>
        IDbTable Tbl { get; set; }

        /// <summary>
        /// 数据表列表
        /// </summary>
        string ConnectString { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        ICodeBuilder DataAccess { get; set; }

        /// <summary>
        /// 表列表
        /// </summary>
        List<IDbTable> Tbls { get; set; }

        /// <summary>
        /// 是否批量生成
        /// </summary>
        bool IsPackage { get; set; }
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        IReturnCode[] GetCode();
    }
}