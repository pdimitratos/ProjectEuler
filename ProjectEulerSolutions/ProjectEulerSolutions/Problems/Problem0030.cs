using ConceptualMath.Numbers.Generation;
using ConceptualMath.Numbers.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static ConceptualMath.Numbers.Generation.Sequences;

namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0030
    {
        /*
         * Surprisingly there are only three numbers that can be written as the 
         * sum of fourth powers of their digits:

            1634 = 1^4 + 6^4 + 3^4 + 4^4
            8208 = 8^4 + 2^4 + 0^4 + 8^4
            9474 = 9^4 + 4^4 + 7^4 + 4^4
            As 1 = 1^4 is not a sum it is not included.

            The sum of these numbers is 1634 + 8208 + 9474 = 19316.

            Find the sum of all the numbers that can be written as the 
            sum of fifth powers of their digits.
        */
        /* notes
         * What is the max input worth evaluating?
         * 1000a + 100b + 10c + d = a^4 + b^4 + c^4 + d^4
         * Number of digits times 9 to the power is the max?
         * 
        */ 

        [TestMethod]
        public void SumOfNumbersThatCanBeWrittenAsTheSumOf4thPowersOfTheirDigits_Is19316()
        {
            var n = 4;
            var maxToEval = BigInteger.Pow(10, n);
            var result = NaturalNumbers()
                .SkipWhile(x => x <= 1) //trivial
                .TakeWhile(x => x < maxToEval)
                .Select(x => (value: x, result: x.ToDigits()
                    .Select(y => BigInteger.Pow(y, n))
                    .Sum()))
                .Where(test => test.value == test.result)
                .Select(test => test.value)
                .Sum();

            Assert.AreEqual(19316, result);
        }

        [TestMethod]
        public void SumOfNumbersThatCanBeWrittenAsTheSumOf5thPowersOfTheirDigits_IssOMETHING()
        {
            var n = 5;
            var maxToEval = BigInteger.Pow(10, n + 1);
            var result = NaturalNumbers()
                .SkipWhile(x => x <= 1) //trivial
                .TakeWhile(x => x < maxToEval)
                .Select(x => (value: x, result: x.ToDigits()
                    .Select(y => BigInteger.Pow(y, n))
                    .Sum()))
                .Where(test => test.value == test.result)
                .Select(test => test.value)
                .Sum();

            Assert.AreEqual(19316, result);
        }
    }
}
