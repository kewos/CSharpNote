using System;
using ConsoleDisplay.Data;
//using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using ConsoleDisplay.Data.Contracts;
using ConsoleDisplay.Data.Implements;
using ConsoleDisplay.Client.Contrasts;

namespace ConsoleDisplay.Client
{
    class Program
    {
        private static Container container = new Container();
        static void Main(string[] args)
        {
            Config();
            container.GetInstance<IProjectManager>().Display();
        }

        private static void Config()
        {
            ConfigManager();
            ConfigMethodRepository();
        }

        /// <summary>
        /// 自動註冊有對應的Interface及Type
        /// </summary>
        private static void ConfigManager()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(@type => @type.IsClass
                    && !@type.IsAbstract
                    && !@type.IsInterface)
                .ForEach(@type =>
                    {
                        var interfaceType = @type.GetInterfaces()
                            .Where(@interface =>
                                @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name)
                            .FirstOrDefault();
                        if (interfaceType != null)
                        {
                            container.RegisterSingle(interfaceType, @type);
                        }
                    });
        }

        /// <summary>
        /// RegistAll class of inherit IMethodRepository
        /// </summary>
        private static void ConfigMethodRepository()
        {
            container.RegisterAll<IMethodRepository>(
                AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(assembly => assembly.GetName().Name == "ConsoleDisplay.Data")
                .GetTypes()
                .Where(@type => @type.IsClass
                    && !@type.IsAbstract
                    && !@type.IsInterface
                    && @type.GetInterfaces()
                        .Any(@interface => @interface == typeof(IMethodRepository)))
            );
        }
    }
}

