using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IMenuListInfoDal
    {
        List<ITSS_MenuListInfo> GetAllMenuList(string name);

        bool InsertMenuListInfo(ITSS_MenuListInfo menuListInfo);
    }
}
