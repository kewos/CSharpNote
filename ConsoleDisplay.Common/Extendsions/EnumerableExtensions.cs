using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ConsoleDisplay
{
    public static class EnumerableExtensions
    {
        public static void Dump<T>(this IEnumerable<T> elements, int index = 0)
        {
            elements.ForEach(element => Console.WriteLine("{0}.{1}", index++, element));
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

        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action)
        {
            foreach (T element in elements)
            {
                action(element);
            }
        }

        public static void SelectAndShowOnConsole<T>(this IEnumerable<T> items, Action<int> AfterTypeIndex)
        {
            while (true)
            {
                try
                {
                    items.ShowOnConsole<T>();
                    var input = GetIndexOfMethod();
                    if (input == -1) break;
                    AfterTypeIndex(input);
                    Console.ReadLine();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("some exception!!");
                }
            }
        }

        private static void ShowOnConsole<T>(this IEnumerable<T> items)
        {
            Console.Clear();
            items.Dump();
            Console.WriteLine("-1.Exit");
            Console.Write("<Console>:");
        }

        private static int GetIndexOfMethod()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
