using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpNote.Common.Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        ///     取得 assembly底下有實作interface的type
        /// </summary>
        public static IEnumerable<Type> GetImplementInterfaceClassType<TInterface>(this Assembly assembly)
        {
            return
                assembly.GetClassType()
                    .Where(
                        @type =>
                            @type.GetInterfaces().Any(@interface => @interface.IsAssignableFrom(typeof (TInterface))));
        }

        /// <summary>
        ///     取得assembly底下的全部class type
        /// </summary>
        public static IEnumerable<Type> GetClassType(this Assembly assembly)
        {
            return assembly.GetTypes().Where(@type => @type.IsClass && !@type.IsAbstract && !@type.IsInterface);
        }
    }
}