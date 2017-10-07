using ConceptualMath.Numbers.Prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Numerics
{
    public static class BigIntegerExtensions
    {
        public static BigInteger Sum(this IEnumerable<BigInteger> sequence)
            => sequence.Reduce<BigInteger, BigInteger>(BigInteger.Add);

        public static IList<BigInteger> GetPrimeFactors(this BigInteger toFactorize)
        {
            var primeService = new PrimeService();
            var factors = new List<BigInteger>();
            var workingValue = toFactorize;

            while(primeService.LargestIdentifiedPrime * primeService.LargestIdentifiedPrime < workingValue)
            {
                while(workingValue % primeService.LargestIdentifiedPrime == 0)
                {
                    workingValue = workingValue / primeService.LargestIdentifiedPrime;
                    factors.Add(primeService.LargestIdentifiedPrime);
                }
                primeService.FindNextPrime();
            }
            factors.Add(workingValue);
            return factors;
        }

        public static BigInteger FromDigits(this IEnumerable<BigInteger> digits, int baseToUse=10)
        {
            BigInteger placeValue = 1;
            return digits.Reduce<BigInteger, BigInteger>((sum, digit) =>
            {
                var currentValue = digit * placeValue;
                placeValue = placeValue * baseToUse;
                return sum + currentValue;
            });
        }

        public static IEnumerable<BigInteger> ToDigits(this BigInteger value, int baseToUse=10)
        {
            var workingValue = value;
            while(workingValue > 0)
            {
                yield return workingValue % baseToUse;
                workingValue = workingValue / baseToUse;
            }
        }

        public static BigInteger ReverseDigits(this BigInteger input)
            => input.ToDigits().Reverse().FromDigits();


        public static bool IsPalindrome(this BigInteger value)
            => value == value.ReverseDigits();
    }
}
