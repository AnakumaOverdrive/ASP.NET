using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Esint.CodeSite.Model;
using Esint.CodeSite.Factory;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;
using Esint.Common;

namespace Esint.CodeSite.BLL
{
    /// <summary>
    /// 文件说明:  业务逻辑层
    /// 作    者: 刘伟通
    /// 生成日期: 2012年09月17日
    /// 模板版本: Esint.Template.BLL.BLL_01 版，适用于简单三层开发!
    /// 功能说明：
    /// </summary>
    public partial class Info_CategoryService
    {
        /// <summary>
        /// 功    能: 保存对象
        /// 说    明: 当主键为空时，新增操作
        ///           当主键不为空，根据主键进行修改
        /// <summary>
        public void Save(Info_CategoryInfo info_Category)
        {
            if (info_Category.CategoryID==Guid.Empty)
            {
                 dataAccess.Insert(info_Category);
            }
            else
            {
                 dataAccess.Update(info_Category);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryType"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Info_CategoryInfo> GetCategoryList(string categoryType, Guid userID)
        {
            return dataAccess.GetCategoryList(categoryType, userID);
        }

        #region 得到Json格式的数型结构
        /// <summary>
        /// 得到Json格式的数型结构
        /// 作者：刘伟通
        /// </summary>
        /// <returns></returns>
       public string CreateJsonTree(string categoryType, Guid userId)
        {
            List<Info_CategoryInfo> allCategory = dataAccess.GetCategoryList(categoryType,userId);

            StringBuilder treeStr = new StringBuilder();
            Info_CategoryInfo rootCategory = allCategory.Find(c=>c.ParentCategory==Guid.Empty);

            treeStr.Append(" root = {'id':'" + rootCategory.CategoryID + "','text':'" + rootCategory.CategoryName.ToUnicode() + "'");
            AddNode(allCategory, rootCategory, ref treeStr);
            return treeStr.ToString() + "}";
        }
        #endregion

        #region 添加代码树结点

        /// <summary>
        /// 添加代码树结点
        /// 作者：刘伟通
        /// </summary>
        /// <param name="departmentList"></param>
        /// <param name="parentDep"></param>
        /// <param name="nodeStr"></param>
       private void AddNode(List<Info_CategoryInfo> categoryList, Info_CategoryInfo parentNode, ref StringBuilder nodeStr)
        {
            List<Info_CategoryInfo> subCategory;
            if (parentNode == null)
            {
                subCategory = categoryList.FindAll(delegate(Info_CategoryInfo category) { return category.ParentCategory == null; });
            }
            else
            {
                subCategory = categoryList.FindAll(delegate(Info_CategoryInfo category) { return category.ParentCategory == parentNode.CategoryID; });
            }
            if (subCategory.Count > 0)
            {
                if (parentNode != null)
                    nodeStr.Append(",children:[");
            }
            foreach (Info_CategoryInfo category in subCategory)
            {
                nodeStr.Append("{'id':'"); nodeStr.Append(category.CategoryID); nodeStr.Append("','text':'"); nodeStr.Append(category.CategoryName.ToUnicode()); nodeStr.Append("','pid':'"); nodeStr.Append(category.ParentCategory); nodeStr.Append("'");
                AddNode(categoryList, category, ref  nodeStr);
                nodeStr.Append("},");
            }
            if (subCategory.Count > 0)
            {
                nodeStr.Remove(nodeStr.Length - 1, 1); nodeStr.Append("]");
            }


        }

        #endregion
    }
}
