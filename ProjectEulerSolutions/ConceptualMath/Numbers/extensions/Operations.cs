using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Numerics
{
    public static class Operations
    {
        public static BigInteger Sum(this IEnumerable<BigInteger> sequence)
            => sequence.Any() ? sequence.Aggregate(BigInteger.Add) : 0;

        public static BigInteger Product(this IEnumerable<BigInteger> sequence)
            => sequence.Aggregate(BigInteger.Multiply);

        public static BigInteger Square(BigInteger value)
            => BigInteger.Pow(value, 2);

        public static BigInteger Factorial(this BigInteger input)
        {
            if (input <= 1) return 1;
            BigInteger runningProduct = 1;
            for (int i = 2; i <= input; i++)
            {
                runningProduct = runningProduct * i;
            }
            return runningProduct;
        }

        public static IEnumerable<(BigInteger digit, BigInteger remainder)> DecimalRemainder(BigInteger numerator, BigInteger denominator, int numericBase = 10)
        {
            var remainder = numericBase * (numerator % denominator);
            while(remainder != 0)
            {
                yield return (remainder / denominator, remainder);
                remainder = numericBase * (remainder % denominator);
            }
        }

        public static BigInteger RecurringCycleLength(this IEnumerable<(BigInteger digit, BigInteger remainder)> divisionStream)
        {
            var digits = new List<(BigInteger digit, BigInteger remainder)>();
            bool addDigit((BigInteger digit, BigInteger remainder) digit) { digits.Add(digit); return true; }
            var repeatStartIndex = divisionStream
                .Select(digit => (index: digits.IndexOf(digit), digit))
                .SkipWhile(t =>  t.index == -1 && addDigit(t.digit))
                .Select(t => t.index)
                .FirstOrDefault();                
            return digits.Count - repeatStartIndex - 1;
        }
    }
}
