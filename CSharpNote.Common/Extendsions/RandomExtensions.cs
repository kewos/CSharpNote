using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Common.Extendsions
{
    public static class RandomExtensions
    {
        public static bool NextBoolean(this Random random)
        {
            return random.NextDouble() > 0.5;
        }

        public static TEnum NextEnum<TEnum>(this Random random)
            where TEnum : struct
        { 
            var type = typeof(TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException("Invalid Enum Type");
            }

            return Enum.GetValues(type)
                .Cast<TEnum>()
                .OrderBy(e => random.Next())
                .FirstOrDefault();
        }

        public static TType RandomOne<TType>(this Random random, params TType[] items)
        {
            var index = random.Next(items.Length);
            return items[index];
        }
    }
}
