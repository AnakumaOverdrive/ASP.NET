using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Server;

namespace Dome1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //登记类型
            builder.RegisterType<DBBase>();
            builder.RegisterType<SqlRepository>().As<IRepository>();
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DBBase>();
                manager.Search("SELECT * FORM USER");
                //Console.ReadKey();
            }

            builder.RegisterType<RedisRepository>().As<IRepository>();
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DBBase>();
                manager.Search("SELECT * FORM USER");
                Console.ReadKey();
            }
          
        }
    }
}
