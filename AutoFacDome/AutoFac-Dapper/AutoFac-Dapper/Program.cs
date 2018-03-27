using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL;
using DAL;
using IDAL;
using Model;

namespace AutoFac_Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new ContainerBuilder();
            
            //using (var container = builder.Build())
            //{
            //    var manager = container.Resolve<MenuListInfoBll>();
            //    var list = manager.GetAllMenuList("事件");
            //    foreach (var itssMenuListInfo in list)
            //    {
            //        Console.WriteLine(itssMenuListInfo.MenuName);
            //    }
            //}

            //查询
            var manager = EngineContext.Current.ContainerManager.Resolve<MenuListInfoBll>();
            var list = manager.GetAllMenuList("事件");
            foreach (var itssMenuListInfo in list)
            {
                Console.WriteLine(itssMenuListInfo.MenuName);
            }

            //添加
            var menuListInfo = new ITSS_MenuListInfo() { MenuId = new Guid().ToString(), MenuName = "leepy" };
            manager.AddMenuList(menuListInfo);

            Console.Read();
        }
    }
}
