using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Data.Project.Implement.ORM.TypeConvert;

namespace CSharpNote.Data.Project.Implement.ORM
{
    /// <summary>
    /// 轉型幫手
    /// </summary>
    public class ConvertHelper
    {
        private readonly ConvertFactory factory;

        public ConvertHelper()
            : this(new ConvertFactory())
        {
        }

        public ConvertHelper(ConvertFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Convert to TType
        /// </summary>
        public IEnumerable<TType> Convert<TType>(IEnumerable<Dictionary<string, string>> source)
            where TType : IMappingModel, new()
        {
            var properties = ToPropertyDictionary<TType>();
            return source.Select(row =>
            {
                var instance = new TType();
                foreach (var column in row.Where(column => properties.ContainsKey(column.Key)))
                {
                    var type = properties[column.Key].PropertyType;
                    var value = !type.IsEnum
                        ? factory.Create(type).Convert(column.Value)
                        : typeof(StringToEnum).GetMethod("Convert")
                            .MakeGenericMethod(type)
                            .Invoke(factory.Create(type), new object[] { column.Value });

                    properties[column.Key].SetValue(instance, value);
                }
                return instance;
            });
        }

        private static Dictionary<string, PropertyInfo> ToPropertyDictionary<TType>() 
            where TType : IMappingModel, new()
        {
            var target = new TType();
            return typeof(TType).GetProperties().ToDictionary
            (
                property => target.Mapping(property.Name),
                property => property
            );
        }
    }
}





        