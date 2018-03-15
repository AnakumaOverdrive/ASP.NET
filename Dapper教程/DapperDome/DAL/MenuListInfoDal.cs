using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DAL
{
    public class MenuListInfoDal
    {
        public List<ITSS_MenuListInfo> GetAllMenuList(string name)
        {
            const string strSql = "select * from T_ITSS_MenuList where MenuName like @MenuName";
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                var menulist = conn.Query<ITSS_MenuListInfo>(strSql, new {MenuName = "%" + name + "%"}).ToList();
                return menulist;
            }
        }
    }
}
