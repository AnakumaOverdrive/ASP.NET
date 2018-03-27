using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL;
using DAL;
using IDAL;

namespace AutoFac_Dapper
{
    /// <summary>
    /// 注册依赖
    /// </summary>
    public class DependencyRegistrar
    {
        /// <summary>
        /// AutoFac依赖注册
        /// 所有的注册都放在这里
        /// </summary>
        /// <param name="builder"></param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<MenuListInfoBll>().InstancePerDependency();
            builder.RegisterType<MenuListInfoDal>().As<IMenuListInfoDal>().InstancePerDependency();
        }
    }
}
