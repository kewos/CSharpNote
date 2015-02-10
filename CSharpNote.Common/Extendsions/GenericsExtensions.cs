using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpNote.Common.Extendsions
{
    public static class GenericsExtensions
    {
        public static T DeepClone<T>(this T obj)
            where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                return formatter.Deserialize(stream) as dynamic;
            }
        }
    }
}