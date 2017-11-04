using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0024
    {
        /*A permutation is an ordered arrangement of objects. 
         * For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
         * If all of the permutations are listed numerically or alphabetically, 
         * we call it lexicographic order. 
         * The lexicographic permutations of 0, 1 and 2 are:

                012   021   102   120   201   210

            What is the millionth lexicographic permutation of the digits
            
                0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
        */
        [TestMethod]
        public void Sixth_LexographicPermutationOf0To2Inclusive_Is210()
        {
            var expected = new List<BigInteger>() { 2, 1, 0 };
            var digitsToUse = 3;
            IEnumerable<BigInteger> firstNDigits(int n) => Sequences
                .NaturalNumbers().Take(n);
            var digits = firstNDigits(digitsToUse).ToList();


            var result = digits
                .Permutations((a,b) => a.Equals(b))
                .Skip(5)
                .First();


            Assert.AreEqual(expected.AsEnumerable().Reverse().FromDigits(), result.AsEnumerable().Reverse().FromDigits());
        }

        [TestMethod]
        public void Millionth_LexographicPermutationOf0To9Inclusive_Is2783915460()
        {
            var expected = new BigInteger(2783915460);
            var digitsToUse = 10;
            IEnumerable<BigInteger> firstNDigits(int n) => Sequences
                .NaturalNumbers().Take(n);
            var digits = firstNDigits(digitsToUse).ToList();


            var result = digits
                .Permutations((a, b) => a.Equals(b))
                .Skip(999_999)
                .First();


            Assert.AreEqual(expected, result.AsEnumerable().Reverse().FromDigits());
        }
    }
}
