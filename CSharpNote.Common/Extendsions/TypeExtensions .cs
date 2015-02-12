using System;
using System.Linq;
using System.Reflection;

namespace CSharpNote.Common.Extendsions
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

        public static ConstructorInfo GetMatchConstructor(this Type @type)
        {
            var constructorInfo = @type.GetConstructors()
                .Where(constructor =>
                    constructor.GetParameters()
                    .All(p => p.ParameterType.IsInterface 
                        && p.ParameterType.Name.StartsWith("I")))
                .FirstOrDefault();

            if (constructorInfo == null)
            {
                throw new NullReferenceException("NoMatchConstructor");
            }

            return constructorInfo;
        }
    }
}
