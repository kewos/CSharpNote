using System;
using ConsoleDisplay.Data;
//using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Client.Contrasts;
using ConsoleDisplay.Data.AlgorithmMethod;
using ConsoleDisplay.Data.CSharpPracticeMethod;
using ConsoleDisplay.Data.DesignPattern;

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
            RegistAssemblyAllInterface<IMethodRepository>();
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
        private static void RegistAssemblyAllInterface<TInterface>()
        {
            var matchFileName = "*Method.DLL";
            var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var matchType = GetTypeMatchDLL<TInterface>(path, matchFileName);
            container.RegisterAll<TInterface>(matchType);
        }

        /// <summary>
        /// 透過指定的參考的Dll取得特定Type
        /// </summary>
        private static IEnumerable<Type> GetTypeMatchDLL<TInterface>(string path, string matchFileName)
        {
            return System.IO.Directory.GetFiles(path, matchFileName)
                   .Select(dll => Assembly.LoadFile(dll).GetTypes()
                        .Where(@type => @type.IsClass
                            && !@type.IsAbstract
                            && !@type.IsInterface
                            && @type.GetInterfaces()
                                .Any(@interface => @interface == typeof(TInterface)))
                        .FirstOrDefault()
                   );
        }
    }
}

