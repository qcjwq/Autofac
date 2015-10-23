using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Features.Indexed;

namespace AutofacDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Compoment();
            //Service();
            Config();

            Console.ReadKey();
        }

        /// <summary>
        /// 组件
        /// </summary>
        private static void Compoment()
        {
            var builder = new ContainerBuilder();

            //1 类型创建RegisterType，Register顺序无所谓
            //builder.RegisterType<Worker>().As<IPerson>();
            //builder.RegisterType<Student>().As<IPerson>().PreserveExistingDefaults();
            //builder.RegisterType<LogConsole>().As<ILog>();
            //builder.RegisterType<Manager>();

            //2 实例创建
            //builder.RegisterInstance<Manager>(new Manager(new Student(), new LogConsole()));

            //3 Lambda表达式创建
            //builder.Register(a => new Manager(a.Resolve<IPerson>(), a.Resolve<ILog>()));
            //builder.RegisterType<Student>().As<IPerson>();
            //builder.RegisterType<LogConsole>().As<ILog>();

            //4 程序集创建
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builder.RegisterType<Worker>().As<IPerson>();
            builder.RegisterType<LogConsole>().As<ILog>();

            //5 泛型注册
            //builder.RegisterGeneric(typeof (List<>)).As(typeof (IList<>)).InstancePerLifetimeScope();

            var container = builder.Build();
            var manager = container.Resolve<Manager>();
            manager.Say();
        }

        /// <summary>
        /// 服务
        /// </summary>
        public static void Service()
        {
            var builder = new ContainerBuilder();

            //名字
            //builder.RegisterType<Worker>().Named<IPerson>("worker");
            //var container = builder.Build();
            //var person = container.ResolveNamed<IPerson>("worker");
            //person.Say();

            //键
            builder.RegisterType<Student>().Keyed<IPerson>(DeviceState.Student);
            var container = builder.Build();
            var index = container.Resolve<IIndex<DeviceState, IPerson>>();
            var person = index[DeviceState.Student];
            person.Say();

        }

        /// <summary>
        /// 配置
        /// </summary>
        private static void Config()
        {
            var builder = new ContainerBuilder();

            //通过RegisterModule方式使用配置文件中的信息
            //builder.RegisterType<Manager>();
            //builder.RegisterModule(new ConfigurationSettingsReader("autofac"));

            //通过Register的方式
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.Register(a => new Manager(a.Resolve<IPerson>(), a.Resolve<ILog>()));

            var container = builder.Build();
            var manager = container.Resolve<Manager>();
            manager.Say();
        }
    }

    public enum DeviceState
    {
        Worker, Student
    }
}
