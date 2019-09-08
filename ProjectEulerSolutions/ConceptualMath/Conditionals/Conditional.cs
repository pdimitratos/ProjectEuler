using ConceptualMath.Numbers;
using ConceptualMath.Numbers.Generation;
using ConceptualMath.Numbers.Prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace System.Numerics
{
    public static class Conditional
    {
        public static Func<BigInteger, Func<BigInteger, bool>> HasRemainderWhenDividing 
            = (number) => (divisor) => number % divisor != 0;

        public static bool IsAmicable(this BigInteger input)
            => input != input.SumOfProperDivisors()
            && input == input
                        .SumOfProperDivisors()
                        .SumOfProperDivisors();

        public static bool IsAbundant(this BigInteger input)
            => input.SumOfProperDivisors() > input;

        public static bool IsPythagoreanTriplet(this Tuple<BigInteger, BigInteger, BigInteger> triplet)
        {
            var squares = triplet.Map(Operations.Square);
            bool isTriplet = (squares.Item1 + squares.Item2).Equals(squares.Item3);
            return isTriplet;
        }

        public static bool IsPalindrome(this BigInteger value)
            => value == value.ReverseDigits();

        public static bool IsPandigitalSet(this IEnumerable<BigInteger> set, long startDigit = 1, long endDigit = 9)
            => set
                .SelectMany(term => term.ToDigits())
                .Count() == endDigit - startDigit + 1
            && set
                .SelectMany(term => term.ToDigits())
                .GroupBy(term => term)
                .Where(group => group.Count() == 1)
                .Join(
                    Sequences.NumbersBetween(startDigit, endDigit + 1),
                    group => group.Key,
                    digit => digit,
                    (group, digit) => digit
                ).Count() == endDigit - startDigit + 1;

        public static bool HasRepeatedDigits(this IEnumerable<BigInteger> set)
            => set
                .SelectMany(term => term.ToDigits())
                .GroupBy(term => term)
                .Any(group => group.Count() > 1);
        public static bool HasRepeatedDigits(this BigInteger num)
            => num
                .ToDigits()
                .GroupBy(term => term)
                .Any(group => group.Count() > 1);

        public static IEnumerable<BigInteger> WherePrime(this IEnumerable<BigInteger> sequence)
        {
            var primeService = new PrimeService();
            var enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (primeService.IsPrime(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static bool AllPrime(
            this IEnumerable<BigInteger> sequence,
            PrimeService primeService)
        => sequence
            .All(value => primeService.IsPrime(value));

    }
}
