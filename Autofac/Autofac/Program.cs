using System;
using Autofac;
using Autofac.Configuration;
using AutofacDemo.Interfaces;
using AutofacDemo.Modules;
using AutofacDemo.Modules.DatabaseInfo;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.Register(c => new DatabaseManager(c.Resolve<IDatabase>()));
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                manager.Search("SELECT * FORM USER");
            }

            Console.ReadKey();
        }

        private static IIdentity GetIdentity()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader(""));
            //builder.Register(c=>new )
        }
    }
}
