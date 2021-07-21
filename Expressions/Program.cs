using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressions
{
    public static class Program
    {
        static void Main(string[] args)
        {
            new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                .Filter(i => i % 2 == 0)
                .Map(i => i + 10)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static IEnumerable<TR> Map<T, TR>(this IEnumerable<T> collection, Func<T, TR> tranform)
        {
            foreach (T t in collection)
            {
                yield return tranform(t);
            }
        }

        private static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Func<T, bool> keep)
        {
            foreach (T t in enumerable)
            {
                if (keep(t)) yield return t;
            }
        }
    }
}
