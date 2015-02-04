using System;
using System.Linq;

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
                 @interface.Name.Substring(1, @interface.Name.Length - 1) == @type.Name);
        }
    }
}
