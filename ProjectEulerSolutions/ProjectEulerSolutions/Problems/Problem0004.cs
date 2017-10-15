using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0004
    {
        /*
        A palindromic number reads the same both ways.
        The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

        Find the largest palindrome made from the product of two 3-digit numbers.
        */
        [TestMethod]
        public void LargestPalindromeFromTheProductOfTwo2DigitNumbers_Is9009()
        {
            var value = Sequences.ProductsBetween(10, 100)
                .ToHashSet()
                .Where(bigInt => bigInt.IsPalindrome())
                .Max();

            Assert.AreEqual(9009, value);
        }

        [TestMethod]
        public void LargestPalindromeFromTheProductOfTwo3DigitNumbers_Is906609()
        {
            var value = Sequences.NumbersBetween(100, 1000)
                .ToHashSet()
                .Where(bigInt => bigInt.IsPalindrome())
                .Max();

            Assert.AreEqual(906609, value);
        }
    }
}
