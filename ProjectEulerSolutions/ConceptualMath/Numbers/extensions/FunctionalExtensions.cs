using ConceptualMath.Numbers.Generation;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    public static class FunctionalExtensions
    {
        public static IEnumerable<TOut> Map<TIn, TOut>(
            this IEnumerable<TIn> inArray, 
            Func<TIn, TOut> callback)
        {
            foreach (var input in inArray)
            {
                yield return callback(input);
            }
        }

        public static TOut Reduce<TIn, TOut>(
            this IEnumerable<TIn> inArray,
            Func<TOut, TIn, TOut> callback)
            where TOut: new()
        {
            var toReturn = new TOut();
            foreach (var value in inArray)
            {
                toReturn = callback(toReturn, value);
            }
            return toReturn;
        }

        public static IEnumerator<TOut> Graph<TIn, TOut>(
            this IEnumerator<TIn> inEnumerator,
            Func<TIn, TOut> graph)
            => new Range<TIn, TOut>(inEnumerator, graph);
    }
}
