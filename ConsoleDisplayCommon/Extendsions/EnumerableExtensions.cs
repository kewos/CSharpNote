using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplayCommon
{
    public static class EnumerableExtensions
    {
        public static void Dump(this System.Collections.IEnumerable elements)
        {
            var index = 0;
            foreach (var element in elements)
            {
                Console.WriteLine("{0}.{1}", index++, element);
            }
        }

        public static void Dump<T>(this IEnumerable<T> elements)
        {
            var index = 0;
            foreach (T element in elements)
            {
                Console.WriteLine("{0}.{1}", index++, element);
            }
        }

        public static System.Collections.IEnumerable DumpMany(
            this System.Collections.IEnumerable enumerable, 
            int dumpLevel = 0
        )
        {
            var index = 0;
            foreach (var element in enumerable)
            {
                Console.WriteLine(string.Format("{0}{1}.{2}", new string('-', dumpLevel * 3), index++, element));
                if (element is System.Collections.IEnumerable)
                {
                    (element as System.Collections.IEnumerable).DumpMany(dumpLevel + 1);
                }
            }
            return enumerable;
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T element in enumerable)
            {
                action(element);
            }
        }
    }
}
