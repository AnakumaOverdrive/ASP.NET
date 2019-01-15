using System;
using System.Collections.Generic;
using System.Data;
using Esint.CodeSite.Model;

namespace Esint.CodeSite.IDAL
{
    /// <summary>
    /// 模块名称： 数据访问接口层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月18日
    /// 生成模板: Esint.Template.IDAL.IDAL_01 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial interface IInfo_ArticleData:IBaseData
    {

        /// <summary>
        /// 将实体插入Info_Article表中
        /// </summary>
        /// <param name="info_Article">实体</param>
        void Insert(Info_ArticleInfo info_Article);

        /// <summary>
        /// 根据主键,更新实体(Info_Article)
        /// </summary>
        /// <param name="info_Article">实体</param>
        void Update(Info_ArticleInfo info_Article);

        /// <summary>
        /// 根据主键,删除实体对象 
        /// </summary>
        /// <param name="aritcleID">文章编号</param>
        void Delete(Guid aritcleID);

        /// <summary>
        /// 根据主键查询 对象
        /// </summary>
        /// <param name="aritcleID">文章编号</param>
        /// <returns> 对象</returns>
        Info_ArticleInfo GetInfo_ArticleInfo(Guid aritcleID);

        /// <summary>
        /// 根据主键,查询 对象是否存在
        /// </summary>
        /// <param name="aritcleID">文章编号</param>
        /// <returns>true 存在,false 不存在</returns>
        bool IsExist(Guid aritcleID);

    }
}
