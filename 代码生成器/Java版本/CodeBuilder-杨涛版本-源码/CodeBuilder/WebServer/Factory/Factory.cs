using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Esint.CodeSite.IDAL;
using System.Configuration;

namespace Esint.CodeSite.Factory
{
    public partial class Factory
    {
        private static readonly string profilePath = ConfigurationSettings.AppSettings["profilePath"];
    
        /// <summary>
        /// 创建基础数据表访问对象
        /// </summary>
        /// <returns></returns>
        public static IBaseData CreateBaseData()
        {
            string className = profilePath + ".BaseData";
            return (IBaseData)Assembly.Load(profilePath).CreateInstance(className);
        }


        /// <summary>
        /// 创建代码表[T_Sys_Code] 数据表访问对象
        /// </summary>
        /// <returns></returns>
        public static ISys_CodeData CreateSys_CodeData()
        {
            string className = profilePath + ".Sys_CodeData";
            return (ISys_CodeData)Assembly.Load(profilePath).CreateInstance(className);
        }

        /// <summary>
        /// 创建人员基本信息[T_Sys_Users] 数据表访问对象
        /// </summary>
        /// <returns></returns>
        public static ISys_UsersData CreateSys_UsersData()
        {
            string className = profilePath + ".Sys_UsersData";
            return (ISys_UsersData)Assembly.Load(profilePath).CreateInstance(className);
        }


        /// <summary>
        /// 创建[T_Info_Category] 数据表访问对象
        /// </summary>
        /// <returns></returns>
        public static IInfo_CategoryData CreateInfo_CategoryData()
        {
            string className = profilePath + ".Info_CategoryData";
            return (IInfo_CategoryData)Assembly.Load(profilePath).CreateInstance(className);
        }

        /// <summary>
        /// 创建[T_Info_Article] 数据表访问对象
        /// </summary>
        /// <returns></returns>
        public static IInfo_ArticleData CreateInfo_ArticleData()
        {
            string className = profilePath + ".Info_ArticleData";
            return (IInfo_ArticleData)Assembly.Load(profilePath).CreateInstance(className);
        }
    }
}
