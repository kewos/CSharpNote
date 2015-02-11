using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpNote.Common.Extendsions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> elements, Func<T, T> func)
        {
            if (func == null) throw new ArgumentException("FuncIsNull");
            foreach (var element in elements)
                yield return func(element);
        }

        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action)
        {
            if (action == null) throw new ArgumentException("ActionIsNull");
            foreach (var element in elements)
                action(element);
        }

        public static void ForEach<T>(this IEnumerable<T> elements, Action<int, T> action)
        {
            if (action == null) throw new ArgumentException("ActionIsNull");
            var index = 0;
            foreach (var element in elements)
                action(index++, element);
        }

        public static bool All<T>(this IEnumerable<T> elements, Func<int, T, bool> func)
        {
            if (func == null) throw new ArgumentException("FuncIsNull");
            var index = 0;
            foreach(var element in elements)
                if (!func(index++, element))
                    return false;
            return true;
        }

        public static void Dump<T>(this IEnumerable<T> elements, int index = 0)
        {
            elements.ForEach(element => Console.WriteLine("{0}.{1}", index++, element));
        }

        public static IEnumerable DumpMany(this IEnumerable enumerable, int dumpLevel = 0
        )
        {
            var index = 0;
            foreach (var element in enumerable)
            {
                Console.WriteLine("{0}{1}.{2}", new string('-', dumpLevel * 3), index++, element);
                if (element is IEnumerable)
                {
                    (element as IEnumerable).DumpMany(dumpLevel + 1);
                }
            }
            return enumerable;
        }

        public static void SelectAndShowOnConsole<T>(this IEnumerable<T> items, Action<int> AfterTypeIndex)
        {
            while (true)
            {
                try
                {
                    items.ShowOnConsole();
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
