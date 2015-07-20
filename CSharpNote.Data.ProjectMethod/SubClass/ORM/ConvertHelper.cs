using System.Collections.Generic;
using System.Linq;
using CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert;

namespace CSharpNote.Data.ProjectMethod.SubClass.ORM
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
            where TType : new()
        {
            var properties = typeof (TType).GetProperties().ToDictionary(p => p.Name, p => p);
            return source.Select(row =>
            {
                var instance = new TType();
                foreach (var column in row.Where(column => properties.ContainsKey(column.Key)))
                {
                    var type = properties[column.Key].PropertyType;
                    var value = !type.IsEnum
                        ? factory.Create(type).Convert(column.Value)
                        : typeof(StringToEnum<>).GetMethod("Convert")
                            .MakeGenericMethod(type)
                            .Invoke(factory.Create(type), new [] { column.Value });

                    properties[column.Key].SetValue(instance, value);
                }
                return instance;
            });
        }
    }
}





        