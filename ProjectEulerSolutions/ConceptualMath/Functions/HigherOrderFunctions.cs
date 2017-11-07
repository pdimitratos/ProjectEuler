using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class HigherOrderFunctions
    {
        public static T Apply<T>(this T input, Func<T, T> function, int iterations)
        {
            var temp = input;
            for (int i = 0; i < iterations; i++)
            {
                temp = function(temp);
            }
            return temp;
        }

        public static IEnumerable<T> Map<T>(this IEnumerable<T> input, Action<T> function)
        {
            foreach (var item in input)
            {
                function(item);
                yield return item;
            }
        }
    }
}
