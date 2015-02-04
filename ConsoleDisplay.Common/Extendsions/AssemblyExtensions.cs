using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleDisplay.Common.Extendsions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// 取得 assembly底下有實作interface的type
        /// </summary>
        public static IEnumerable<Type> GetImplementInterfaceClassType<TInterface>
            (this Assembly assembly)
        {
            return assembly.GetClassType().Where(@type =>
            {
                return @type.GetInterfaces().Any(@interface => @interface == typeof(TInterface));
            });
        }

        /// <summary>
        /// 取得assembly底下的全部class type
        /// </summary>
        public static IEnumerable<Type> GetClassType(this Assembly assembly)
        {
            return assembly.GetTypes().Where(@type => 
            {
                return (@type.IsClass && !@type.IsAbstract && !@type.IsInterface);
            });
        }
    }
}
