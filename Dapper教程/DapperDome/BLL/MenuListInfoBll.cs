using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class MenuListInfoBll
    {
        private MenuListInfoDal _menuListInfoDal = new MenuListInfoDal();

        public List<ITSS_MenuListInfo> GetAllMenuList(string name)
        {
            return _menuListInfoDal.GetAllMenuList(name);
        }
    }
}
