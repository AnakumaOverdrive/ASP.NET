using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IDAL;
using Model;

namespace DAL
{
    /// <summary>
    /// 这个类用于示意ORM Dapper的使用.应该写好所有的实例代码,但是我没有写,来咬我啊.
    /// </summary>
    public class MenuListInfoDal : IMenuListInfoDal
    {
        public List<ITSS_MenuListInfo> GetAllMenuList(string name)
        {
            const string strSql = "select * from T_ITSS_MenuList where MenuName like @MenuName";
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                //这句查询使用Dapper技术
                var menulist = conn.Query<ITSS_MenuListInfo>(strSql, new { MenuName = "%" + name + "%" }).ToList();
                return menulist;
            }
        }

        public bool InsertMenuListInfo(ITSS_MenuListInfo menuListInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Ope_Drug(");
            strSql.Append("MenuId,ParentId,ObjType,UrlPath,IsEnabled,Describe,MenuName,SortNum,IconUrl,ModuleMenuID,MenuCode,CreateDate,CreateUserId,ModifyDate,ModifyUserId)");
            strSql.Append(" values (");
            strSql.Append("@MenuId,@ParentId,@ObjType,@UrlPath,@IsEnabled,@Describe,@MenuName,@SortNum,@IconUrl,@ModuleMenuID,@MenuCode,@CreateDate,@CreateUserId,@ModifyDate,@ModifyUserId)");
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                int i = 1;
                //int i = conn.Execute(strSql.ToString(), menuListInfo);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
