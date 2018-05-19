using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEulerSolutions.Problems
{
    [TestClass]
    public class Problem0033
    {
        //https://projecteuler.net/problem=33

        // 'Broken Clock' refers to getting correct results despite using a method
        // that produces incorrect result for most inputs.
        public bool IsBrokenClockPair((BigInteger numerator, BigInteger denominator) input)
        {
            var numDigits = input.numerator.ToDigits().ToList();
            var denomDigits = input.denominator.ToDigits().ToList();

            if (numDigits[0] == 0 && denomDigits[0] == 0)
                return false; // Trivial

            var toRemoveFromNumerator = new List<BigInteger>();
            foreach (var digit in numDigits)
            {
                if(denomDigits.Contains(digit))
                {
                    denomDigits.Remove(digit);
                    toRemoveFromNumerator.Add(digit);
                }
            }

            if (toRemoveFromNumerator.Count == 0)
                return false; // No cancellation

            foreach(var digit in toRemoveFromNumerator)
            {
                numDigits.Remove(digit);
            }
            var integerDivisionFuzzing = 1000000000;

            if (denomDigits.FromDigits() == 0
                || input.denominator == 0)
                return false; // divide by zero

            return numDigits.FromDigits() != 0 
                && (integerDivisionFuzzing * numDigits.FromDigits()) / denomDigits.FromDigits()
                == (integerDivisionFuzzing * input.numerator) / input.denominator;
        }

        [TestMethod]
        public void Fraction49Over98_ExhibitsBrokenClockCancellation()
        {
            var gcdResult = new BigInteger(48).GreatestCommonDenominator(18);
            Assert.IsTrue(IsBrokenClockPair((49, 98)));
        }

        [TestMethod]
        public void ValueOfDenominatorOfProductOfNonTrivialBrokenClockFractions_Is100()
        {
            var brokenClockFractions = Sequences.NumbersBetween(10, 100)
                .FullJoinWhere(
                    Sequences.NumbersBetween(10, 100),
                    (num, denom) => num < denom,
                    (num, denom) => (numerator: num, denominator: denom)
                ).Where(fraction => IsBrokenClockPair(fraction))
                .ToList();
            var fractionProduct = brokenClockFractions
                .Aggregate(
                    (numerator: new BigInteger(1), denominator: new BigInteger(1)),
                    (a, b) => (a.numerator * b.numerator, a.denominator * b.denominator)
                );
            var result = fractionProduct.denominator / fractionProduct.numerator.GreatestCommonDenominator(fractionProduct.denominator);

            Assert.AreEqual(100, result);
        }
    }
}
