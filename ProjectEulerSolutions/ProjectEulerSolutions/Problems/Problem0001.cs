using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0001
    {
        //https://projecteuler.net/problem=1
        /*
            If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

            Find the sum of all the multiples of 3 or 5 below 1000.
        */
        private BigInteger Answer => 233168;


        [TestMethod]
        public void SumOfNaturalNumbersBelow10ThatAreMultiplesOf3Or5_Is23()
        {
            BigInteger value = SumOrNaturalNumbersThatAreMultiplesOf3Or5(10);

            Assert.AreEqual(23, value);
        }

        [TestMethod]
        public void SumOfNaturalNumbersBelow1000ThatAreMultiplesOf3Or5_Is233168()
        {
            BigInteger value = SumOrNaturalNumbersThatAreMultiplesOf3Or5(1000);

            Assert.AreEqual(Answer, value);
        }

        private static BigInteger SumOrNaturalNumbersThatAreMultiplesOf3Or5(int below)
        {
            if (below < 1) throw new ArgumentException("must be 1 or greater", nameof(below));

            return Sequences.NaturalNumbers()
                .Take(below)
                .Where(v => v % 3 == 0 || v % 5 == 0)
                .Sum();
        }
      
    }
}
