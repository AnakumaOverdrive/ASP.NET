using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutoFac_Dapper
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="builder"></param>
        void Register(ContainerBuilder builder);
    }
}
