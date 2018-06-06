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
    public class Problem0034
    {
        public Dictionary<BigInteger, BigInteger> FactorialLookup = new Dictionary<BigInteger, BigInteger>()
        {
            { 0, 1 },
            { 1, 1 },
            { 2, 2 },
            { 3, new BigInteger(3).Factorial() },
            { 4, new BigInteger(4).Factorial() },
            { 5, new BigInteger(5).Factorial() },
            { 6, new BigInteger(6).Factorial() },
            { 7, new BigInteger(7).Factorial() },
            { 8, new BigInteger(8).Factorial() },
            { 9, new BigInteger(9).Factorial() }
        };

        public BigInteger SumOfFactorialDigits(BigInteger input)
            => input.ToDigits()
                .Select(digit => FactorialLookup[digit])
                .Sum();

        [TestMethod]
        public void SumOfFactorialOfDigitsOf145_Is145()
        {
            var result = SumOfFactorialDigits(new BigInteger(145));

            Assert.AreEqual(new BigInteger(145), result);
        }

        [TestMethod]
        public void SumOfNaturalsEqualToTheSumOfTheFactorialsOfTheirDigits_Is40730()
        {
            var result = Sequences.NaturalNumbers()
                .Skip(10)
                .Take(10_000_000)
                .Where(num => SumOfFactorialDigits(num) == num)
                .Sum();

            Assert.AreEqual(40730, result);
        }
    }
}
