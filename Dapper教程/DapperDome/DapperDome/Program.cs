using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DapperDome
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuListInfoBll bll = new MenuListInfoBll();
            var list = bll.GetAllMenuList("事件");
            foreach (var itssMenuListInfo in list)
            {
                Console.WriteLine(itssMenuListInfo.MenuName);
            }
            Console.Read();
        }
    }
}
