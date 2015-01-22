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

        private static void ConfigManager()
        {
            container.RegisterSingle<IProjectManager, ProjectManager>();
            container.RegisterSingle<IMethodManager, MethodManager>();
        }

        private static void ConfigMethodRepository()
        {
            container.RegisterAll<IMethodRepository>(
                AppDomain.CurrentDomain
                .GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "ConsoleDisplay.Data")
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

