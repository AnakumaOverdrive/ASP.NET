using System;
using Esint.CodeSite.Model;
using Esint.CodeSite.Factory;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;

namespace Esint.CodeSite.BLL
{
    /// <summary>
    /// 文件说明:  业务逻辑层
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月17日
    /// 模板版本: Esint.Template.BLL.BLL_11 版，适用于反射工厂模式开发!
    /// 特别说明: 本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Info_CategoryService
    {
        private IInfo_CategoryData dataAccess = Factory.Factory.CreateInfo_CategoryData();
        /// <summary>
        /// 插入Info_CategoryInfo 实体
        /// <summary>
        /// <param name="info_Category"></param>
        public void Insert(Info_CategoryInfo info_Category)
        {
            dataAccess.Insert(info_Category);
        }

        /// <summary>
        /// 根据主键更新Info_CategoryInfo 实体
        /// <summary>
        /// <param name="info_Category"></param>
        public void Update(Info_CategoryInfo info_Category)
        {
            dataAccess.Update(info_Category);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        public void Delete(Guid categoryID)
        {
            dataAccess.Delete(categoryID);
        }

        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Info_CategoryInfo GetInfo_CategoryInfo(Guid categoryID)
        {
            return dataAccess.GetInfo_CategoryInfo(categoryID);
        }

    }
}
