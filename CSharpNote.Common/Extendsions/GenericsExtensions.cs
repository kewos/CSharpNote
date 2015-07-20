using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpNote.Common.Extendsions
{
    public static class GenericsExtensions
    {
        public static T DeepClone<T>(this T obj)
            where T : class
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                return formatter.Deserialize(stream) as dynamic;
            }
        }

        public static void While<TItem>(this TItem item, Predicate<TItem> predicate, params Action<TItem>[] actions)
            where TItem : class
        {
            while (predicate(item))
            {
                foreach (var action in actions)
                {
                    action(item);
                }
            }
        }

        public static bool In<TType>(this TType source, params TType[] items)
        {
            foreach(var item in items)
            {
                if (source.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}