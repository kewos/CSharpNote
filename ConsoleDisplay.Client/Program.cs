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
            RegisterMappingType();
            RegistAssemblyAllInterface<IMethodRepository>("ConsoleDisplay.Data");
        }

        /// <summary>
        /// Auto Register Mapping Interface and Type
        /// </summary>
        private static void RegisterMappingType()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(@type => @type.IsClass
                    && !@type.IsAbstract
                    && !@type.IsInterface)
                .ForEach(@type =>
                    {
                        var interfaceType = @type.GetInterfaces()
                            .FirstOrDefault(@interface => 
                                @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name);
                        if (interfaceType != null)
                        {
                            container.RegisterSingle(interfaceType, @type);
                        }
                    });
        }

        /// <summary>
        /// RegistAll class of inherit IMethodRepository
        /// </summary>
        private static void RegistAssemblyAllInterface<TInterface>(string assembleName)
        {
            container.RegisterAll<TInterface>(
                AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(assembly => assembly.GetName().Name == assembleName)
                .GetTypes()
                .Where(@type => @type.IsClass
                    && !@type.IsAbstract
                    && !@type.IsInterface
                    && @type.GetInterfaces()
                        .Any(@interface => @interface == typeof(TInterface)))
            );
        }
    }
}

