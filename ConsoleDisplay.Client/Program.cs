using System;
using ConsoleDisplay.Data;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;

namespace ConsoleDisplay.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IocContainer.GetInstance().Resovle<IProjectManager>().Display();
        }
    }

    public class IocContainer
    {
        private static IocContainer iocContainer;
        private IUnityContainer container;
        private IocContainer()
        {
            container = new UnityContainer();
            ConfigSetting();
        }

        private void ConfigSetting()
        {
            //var dic = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(@type => @type.IsClass
            //        && !@type.IsAbstract
            //        && !@type.IsInterface
            //        && @type.GetInterfaces()
            //            .Any(@interface =>
            //                @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name))
            //    .ToDictionary(
            //        @type => @type.GetInterfaces()
            //            .Where(@interface =>
            //                @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name)
            //            .FirstOrDefault(),
            //        @type => @type);
            //foreach (var pairs in dic)
            //{
            //    container.RegisterType(pairs.Key, pairs.Value);
            //}
            container.RegisterType<IMethodRepositoryFactory, MethodRepositoryFactory>();
            container.RegisterType<IProjectManager, ProjectManager>();
            container.RegisterType<IConsoleDisplayer, ConsoleDisplayer>();
            container.RegisterType<IMethodManager, MethodManager>();
        }

        public static IocContainer GetInstance()
        {
            if (iocContainer == (IUnityContainer)null)
            {
                iocContainer = new IocContainer();
            }
            return iocContainer;
        }

        public TType Resovle<TType>()
        {
            return container.Resolve<TType>();
        }
    }
}

