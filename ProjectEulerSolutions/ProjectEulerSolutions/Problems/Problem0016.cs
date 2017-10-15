using ConceptualMath.Combinatorics;
using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0016
    {
        /*
         * 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

           What is the sum of the digits of the number 2^1000?
        */
        [TestMethod]
        public void SumOfDigitsOf2RaisedToThe15thPower_Is26()
        {
            var answer = BigInteger.Pow(2, 15).ToDigits().Sum();

            Assert.AreEqual(26, answer);
        }

        [TestMethod]
        public void SumOfDigitsOf2RaisedToThe1000thPower_Is1366()
        {
            var answer = BigInteger.Pow(2, 1000).ToDigits().Sum();

            Assert.AreEqual(1366, answer);
        }
    }
}
