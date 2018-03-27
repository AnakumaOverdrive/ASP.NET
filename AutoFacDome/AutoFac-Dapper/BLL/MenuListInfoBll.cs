using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace BLL
{
    /// <summary>
    /// 业务实体
    /// </summary>
    public class MenuListInfoBll
    {
        /// <summary>
        /// 数据访问层的接口,通过IOC技术反向注册
        /// </summary>
        private IMenuListInfoDal _menuListInfoDal;

       // private ITSS_MenuListInfo _menuListInfo;


        public MenuListInfoBll(IMenuListInfoDal imenuListInfoDal)//:this(imenuListInfoDal,null)
        {
            _menuListInfoDal = imenuListInfoDal;
        }

        //public MenuListInfoBll(IMenuListInfoDal imenuListInfoDal, ITSS_MenuListInfo menuListInfo)
        //{
        //    _menuListInfoDal = imenuListInfoDal;
        //    _menuListInfo = menuListInfo;
        //}

        public List<ITSS_MenuListInfo> GetAllMenuList(string name)
        {
            return _menuListInfoDal.GetAllMenuList(name);
        }


        public void AddMenuList(ITSS_MenuListInfo menuListInfo)
        {
            if (IsAuthority(menuListInfo))
            {
                Console.WriteLine(_menuListInfoDal.InsertMenuListInfo(menuListInfo));
            }
        }

        //示例验证
        private bool IsAuthority(ITSS_MenuListInfo menuListInfo)
        {
            bool result = menuListInfo != null
                          && menuListInfo.MenuId == new Guid().ToString()
                          && menuListInfo.MenuName == "leepy";
            if (!result)
                Console.WriteLine("Not authority!");

            return result;
        }
    }
}
