using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> elements, Func<T, T> func)
        {
            func.ValidationNotNull();

            foreach (var element in elements)
            {
                yield return func(element);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action)
        {
            action.ValidationNotNull();

            foreach (var element in elements)
            {
                action(element);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> elements, Action<int, T> action)
        {
            action.ValidationNotNull();

            var index = 0;
            foreach (var element in elements)
            {
                action(index++, element);
            }
        }

        public static bool All<T>(this IEnumerable<T> elements, Func<int, T, bool> func)
        {
            func.ValidationNotNull();

            var index = 0;
            foreach (var element in elements)
            {
                if (!func(index++, element))
                {
                    return false;
                }
            }

            return true;
        }

        public static void Dump<T>(this IEnumerable<T> elements, int index = 0)
        {
            elements.ForEach(element => Console.WriteLine("{0}.{1}", index++, element));
        }

        public static IEnumerable DumpMany(this IEnumerable enumerable, int dumpLevel = 0)
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

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> elements)
        {
            var random = new Random();

            return elements.OrderBy(element => random.Next() % 100);
        }

        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            // Ensure that the source IEnumerable is evaluated only once
            return permutations(source.ToArray());
        }

        private static IEnumerable<IEnumerable<T>> permutations<T>(IEnumerable<T> source)
        {
            var c = source.Count();
            if (c == 1)
            {
                yield return source;
            }
            for (int i = 0; i < c; i++)
            {
                foreach (var p in permutations(source.Take(i).Concat(source.Skip(i + 1))))
                {
                    yield return source.Skip(i).Take(1).Concat(p);
                }
            }
        }
    }
}
