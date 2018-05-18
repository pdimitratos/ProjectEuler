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

        public static T ApplyWhile<T>(this T input, Func<T, T> function, Func<T, bool> continueApply)
        {
            var temp = input;
            while(continueApply(temp))
            {
                temp = function(temp);
            }
            return temp;
        }

        public static void ForEach<T>(this IEnumerable<T> input, Action<T> function)
        {
            foreach (var item in input)
            {
                function(item);
            }
        }
    }
}
