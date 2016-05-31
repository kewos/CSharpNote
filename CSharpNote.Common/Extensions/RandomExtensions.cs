using System;
using System.Linq;

namespace CSharpNote.Common.Extensions
{
    public static class RandomExtensions
    {
        /// <summary>
        ///     隨機布林
        /// </summary>
        public static bool NextBoolean(this Random random)
        {
            return random.NextDouble() > 0.5;
        }

        /// <summary>
        ///     隨機Enum
        /// </summary>
        public static TEnum NextEnum<TEnum>(this Random random)
            where TEnum : struct
        {
            var type = typeof (TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException("Invalid Enum Type");
            }

            return Enum.GetValues(type)
                .Cast<TEnum>()
                .OrderBy(e => random.Next())
                .FirstOrDefault();
        }

        /// <summary>
        ///     隨機Items
        /// </summary>
        /// <returns></returns>
        public static TType RandomOne<TType>(this Random random, params TType[] items)
        {
            var index = random.Next(items.Length);
            return items[index];
        }
    }
}