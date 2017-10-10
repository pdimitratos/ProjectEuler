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
    }
}
