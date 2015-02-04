using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleDisplay.Common.Extendsions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// 取得 class type實作interface type
        /// </summary>
        public static Type GetMatchInterface(this Type @type)
        {
            return @type.GetInterfaces().FirstOrDefault(@interface =>
            {
                return @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name;
            });
        }
    }
}
