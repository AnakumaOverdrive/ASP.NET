using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ITSS_MenuListInfo
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 类型（1-一级；2-二级；0-按钮）
        /// </summary>
        public string ObjType { get; set; }

        /// <summary>
        /// 对应页面路径
        /// </summary>
        public string UrlPath { get; set; }

        /// <summary>
        /// 是否启用（0：不启用；1：启用）
        /// </summary>
        public string IsEnabled { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? SortNum { get; set; }

        /// <summary>
        /// 图标路径
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModuleMenuID { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        public string ModifyUserId { get; set; }
 
    }
}
