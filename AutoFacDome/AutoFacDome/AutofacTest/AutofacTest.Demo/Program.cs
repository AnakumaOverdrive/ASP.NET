using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autofac;
using Autofac.Configuration;

using AutofacTest.Lib;
using AutofacTest.DB;
namespace AutofacTest.Demo
{

    class Program
    {
        static void Main(string[] args)
        {


            Call_4();


            Console.ReadKey();

        }

        static void Call_1()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseManager>();
            //builder.RegisterType<SqlDatabase>().As<IDatabase>();
            builder.RegisterType<AutofacTest.DB.Oracle.OracleDatabase>().As<IDatabase>();
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                manager.Search("SELECT * FORM USER");
            }
        }

        static void Call_2()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseManager>();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                manager.Search("SELECT * FORM USER");
            }
        }

        static void Call_3()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<DatabaseManager>();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.Register(c => new DatabaseManager(c.Resolve<IDatabase>()));
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                manager.Search("SELECT * FORM USER");
            }
        }

        static void Call_4()
        {
            User user = new User { Id = 1, Name = "leepy" };
            //User user = new User { Id = 2, Name = "zhangsan" };
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.RegisterInstance(user).As<User>();
            builder.Register(c => new DatabaseManager(c.Resolve<IDatabase>(), c.Resolve<User>()));

            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                manager.Add("INSERT INTO USER ...");
            }

        }
    }
}