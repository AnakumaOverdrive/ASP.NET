using DapperExtensionDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.Model
{
    /// <summary>
    /// 文件说明:  t_code信息实体
    /// 作    者: Esint
    /// 生成日期: 2018年05月23日
    /// 修改说明：
    /// </summary>
    public partial class CodeInfo : BaseModel
    {

        /// <summary>
        /// 代码项表编号
        /// </summary>
        public int Col_CodeID { get; set; }

        /// <summary>
        /// 代码编号
        /// </summary>
        public string Col_Flag { get; set; }

        /// <summary>
        /// 代码项排序
        /// </summary>
        public int? Col_CodeOrder { get; set; }

        /// <summary>
        /// 代码项值
        /// </summary>
        public string Col_Code { get; set; }

        /// <summary>
        /// 代码项名称
        /// </summary>
        public string Col_Meaning { get; set; }

        /// <summary>
        /// 是否有效（0;否;1:是）
        /// </summary>
        public int? Col_IsEnable { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Col_Remark { get; set; }

    }
}
