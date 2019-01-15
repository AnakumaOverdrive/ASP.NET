using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Esint.Common;
using Esint.Common.Model;

namespace Esint.CodeSite.Model
{
    /// <summary>
    /// 文件说明: 信息实体
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月17日
    /// 生成模板: Esint.Template.Model.Model_01 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Info_CategoryInfo : BaseModel
    {
        /// <summary>
        /// 类别编号
        /// </summary>
        public Guid CategoryID { get; set; }
 
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
 
        /// <summary>
        /// 类型(1公开，2 私有)
        /// </summary>
        public string CategoryType { get; set; }
 
        /// <summary>
        /// 父类别编号
        /// </summary>
        public Guid ParentCategory { get; set; }
 
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserID { get; set; }
 
        /// <summary>
        /// 排序号
        /// </summary>
        public int? OrderNum { get; set; }
 
    }
}
