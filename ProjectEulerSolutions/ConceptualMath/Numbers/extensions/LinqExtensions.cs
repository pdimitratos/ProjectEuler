using ConceptualMath.Numbers.Processing;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<IList<T>> ToMovingWindow<T>(
            this IEnumerable<T> input,
            int size,
            bool fullWindowsOnly = true)
            where T : IEquatable<T>, new()
        {
            var backingBuffer = new CircularBuffer<T>(size);
            foreach (var item in input)
            {
                backingBuffer.Add(item);
                if (!fullWindowsOnly || backingBuffer.IsFull)
                {
                    yield return backingBuffer.CurrentElements().ToList();
                }
            }
        }

        public static IEnumerable<TOut> FullJoin<TIn1, TIn2, TOut>(this IEnumerable<TIn1> stream1, IEnumerable<TIn2> stream2, Func<TIn1, TIn2, TOut> selector)
            => stream1.Join(stream2, (item) => true, (item) => true, (item1, item2) => selector(item1, item2));
        //Alternative implementation
        //Todo: test performance
        /*{
            foreach (var item1 in stream1)
            {
                foreach(var item2 in stream2)
                {
                    yield return selector(item1, item2);
                }
            }
        }*/

        public static IEnumerable<TOut> Difference<TOut>(this IEnumerable<TOut> stream1, IEnumerable<TOut> stream2)
            => stream1.Complement(stream2)
                    .Union(stream2.Complement(stream1));
        public static IEnumerable<TOut> Complement<TOut>(this IEnumerable<TOut> stream1, IEnumerable<TOut> stream2)
        {
            var stream1Lookup = stream1.ToList();
            return stream2.Where(element => !stream1Lookup.Contains(element));
        }

        public static Func<T1, T2, Tuple<T1, T2>> JoinToTuple<T1, T2>() => (item1, item2) => new Tuple<T1, T2>(item1, item2);

        public static Func<Tuple<T1, T2>, T3, Tuple<T1, T2, T3>> JoinToTuple<T1, T2, T3>() => (tuple, newItem) => new Tuple<T1, T2, T3>(tuple.Item1, tuple.Item2, newItem);
    }
}
