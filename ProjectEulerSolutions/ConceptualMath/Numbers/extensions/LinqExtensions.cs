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

        public static IEnumerable<Tuple<T1, T2>> ZipToTuple<T1, T2>(
            this IEnumerable<T1> item1Stream,
            IEnumerable<T2> item2Stream)
            => item1Stream.Zip(item2Stream, (item1, item2) => new Tuple<T1, T2>(item1, item2));

        public static IEnumerable<Tuple<T1, T2, T3>> ZipToTuple<T1, T2, T3>(
            this IEnumerable<Tuple<T1, T2>> tupleStream,
            IEnumerable<T3> additionalItemStream)
            => tupleStream.Zip(additionalItemStream, (tuple, newItem) => new Tuple<T1, T2, T3>(tuple.Item1, tuple.Item2, newItem));
    }
}
