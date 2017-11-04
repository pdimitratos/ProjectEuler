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
    }
}
