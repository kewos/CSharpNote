using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpNote.Common.Extensions
{
    public static class GenericsExtensions
    {
        /// <summary>
        ///     深層複製
        /// </summary>
        public static TType DeepClone<TType>(this TType source)
            where TType : class
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Position = 0;
                return formatter.Deserialize(stream) as dynamic;
            }
        }

        /// <summary>
        ///     While迴圈
        /// </summary>
        public static void While<TType>(this TType source, Predicate<TType> predicate, params Action<TType>[] actions)
            where TType : class
        {
            while (predicate(source))
            {
                foreach (var action in actions)
                {
                    action(source);
                }
            }
        }

        /// <summary>
        ///     是否包含
        /// </summary>
        public static bool In<TType>(this TType source, params TType[] items)
        {
            return items.Any(item => source.Equals(item));
        }

        /// <summary>
        ///     If判斷
        /// </summary>
        public static TType If<TType>(this TType source, Predicate<TType> predicate, Action<TType> action)
            where TType : class
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate(source))
            {
                action(source);
            }

            return source;
        }

        /// <summary>
        ///     If判斷
        /// </summary>
        public static TType If<TType>(this TType source, Predicate<TType> predicate, Func<TType, TType> func)
        {
            return predicate(source)
                ? func(source)
                : source;
        }
    }
}