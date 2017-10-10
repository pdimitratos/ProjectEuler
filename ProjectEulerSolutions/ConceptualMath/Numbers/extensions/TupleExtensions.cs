using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class TupleExtensions
    {
        public static Tuple<T,T,T> Map<T>(this Tuple<T,T,T> input, Func<T,T> func)
        {
            return new Tuple<T, T, T>(func(input.Item1), func(input.Item2), func(input.Item3));
        }
    }
}
