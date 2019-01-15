using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.CodeBuilder.Model
{
    /// <summary>
    /// 模板配置对象
    /// 作者:刘伟通
    /// 日期:2010年7月30日
    /// </summary>
    public class TemplateConfig
    {
        /// <summary>
        /// 键值
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 模板DLL,
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 模板类名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 模板标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 生成文件名模板
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 生成文件保存路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 命名空间名称
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// 生成的代码类型
        /// </summary>
        public string CodeType { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsMBuilder { get; set; }

        /// <summary>
        /// 是否Web层
        /// </summary>
        public bool IsWeb { get; set; }

        /// <summary>
        /// 是否生成一个文件
        /// </summary>
        public bool IsSignFile{get;set;}
    }
    
}
