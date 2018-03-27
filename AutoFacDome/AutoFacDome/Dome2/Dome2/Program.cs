using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Dome2
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            
            //builder.RegisterType<DatabaseManager>();
            //builder.RegisterType<SqlDatabase>().As<IDatabase>();
            //using (var container = builder.Build())
            //{
            //    var manager = container.Resolve<DatabaseManager>();
            //    manager.Search("SELECT * FORM USER");
            //}

            //builder.RegisterType<DatabaseManager>();
            //builder.RegisterModule(new ConfigurationSettingsReader("autofac"));//异常
            //using (var container = builder.Build())
            //{
            //    var manager = container.Resolve<DatabaseManager>();
            //    manager.Search("SELECT * FORM USER");
            //}   

            //builder.RegisterType<OracleDatabase>().As<IDatabase>();
            //builder.Register(c => new DatabaseManager(c.Resolve<IDatabase>()));
            //using (var container = builder.Build())
            //{
            //    var manager = container.Resolve<DatabaseManager>();
            //    manager.Search("SELECT * FORM USER");
            //}   

            User user = new User { Id = 1, Name = "leepy" };
            builder.RegisterType<OracleDatabase>().As<IDatabase>();
            builder.RegisterInstance(user).As<User>();
            builder.Register(c => new DatabaseManager(c.Resolve<IDatabase>(), c.Resolve<User>()));

            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();

                manager.Add("INSERT INTO USER ...");
            }  
            Console.ReadLine();
        }
    }
}
