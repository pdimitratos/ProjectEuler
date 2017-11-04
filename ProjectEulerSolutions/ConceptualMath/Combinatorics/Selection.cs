using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace System.Numerics
{
    public static class Selection
    {
        public static BigInteger BinomialCoefficient(BigInteger n, BigInteger k)
            => (n.Factorial() / (k.Factorial() * (n - k).Factorial()));

        public static List<List<T>> Permutations<T>(this List<T> inputSet, Func<T, T, bool> isEqual)
            => inputSet.Count <= 0
                ? new List<List<T>>() :
            inputSet.Count == 1
                ? new List<List<T>>() { inputSet } :
            inputSet.FullJoin(
                    inputSet,
                    (in1, in2) => new List<T>() { in1, in2 }
                ).Where(list => !isEqual(list[0], list[1]))
                .Apply(
                    This => This.FullJoin
                    (
                        inputSet,
                        (list, newItem) => list
                            .Select(item => isEqual(item, newItem))
                            .Any(t => t)
                            ? null
                            : new List<T>(list.Append(newItem))
                    ).Where(list => !(list is null)),
                    inputSet.Count - 2
                ).ToList();
    }
}
