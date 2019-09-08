using ConceptualMath.Numbers.Prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Numerics
{
    public static class Digits
    {
        public static BigInteger FromDigits(this IEnumerable<BigInteger> digits, int baseToUse = 10)
        {
            BigInteger placeValue = 1;
            return digits.Aggregate(new BigInteger(0), (sum, digit) =>
            {
                var currentValue = digit * placeValue;
                placeValue = placeValue * baseToUse;
                return sum + currentValue;
            });
        }

        public static IEnumerable<BigInteger> ToDigits(this BigInteger value, int baseToUse = 10)
        {
            var workingValue = value;
            while (workingValue > 0)
            {
                yield return workingValue % baseToUse;
                workingValue = workingValue / baseToUse;
            }
        }

        public static BigInteger ReverseDigits(this BigInteger input)
            => input.ToDigits().Reverse().FromDigits();

        public static IEnumerable<BigInteger> ToDigitRotations(this BigInteger input)
        {
            var digits = input.ToDigits().ToList();

            var result = digits
                .Concat(digits);
            
            var movingWindow = result
                .ToMovingWindow(digits.Count)
                .Take(digits.Count);

            return movingWindow
                .Select(rotation => rotation.FromDigits());
        }

    }
}
