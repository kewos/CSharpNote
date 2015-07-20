using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert;

namespace CSharpNote.Data.ProjectMethod.SubClass.ORM
{
    /// <summary>
    /// 轉型工廠
    /// </summary>
    public class ConvertFactory
    {
        private readonly Dictionary<Type, dynamic> converterDictionary;

        public ConvertFactory()
        {
            converterDictionary = Assembly.GetAssembly(typeof(IStringConvert<>))
                .GetTypes()
                .Where(
                    @type =>
                        @type.IsClass 
                        && @type.GetInterfaces().Any(@interface => @interface.IsGenericType))
                .ToDictionary(
                    @type => @type.GetInterfaces().First().GenericTypeArguments[0], 
                    @type => Activator.CreateInstance(@type));
            //Enum壞壞先寫死
            converterDictionary.Add(typeof(Enum), new StringToEnum());
        }

        /// <summary>
        /// 創造轉型器
        /// </summary>
        public dynamic Create(Type type)
        {
            if (converterDictionary.ContainsKey(type))
            {
                return converterDictionary[type];
            }
            if (type.IsEnum)
            {
                return converterDictionary[typeof(Enum)];
            }
            throw new ArgumentException("Convert is not exist");
        }
    }
}