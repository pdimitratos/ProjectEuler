using ConceptualMath.Series;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
        private const int answer = 233168;


        [TestMethod]
        public void SumOfNaturalNumbersBelow10ThatAreMultiplesOf3Or5_Is23()
        {
            int value = SumOrNaturalNumbersThatAreMultiplesOf3Or5(10);

            Assert.AreEqual(23, value);
        }

        [TestMethod]
        public void SumOfNaturalNumbersBelow1000ThatAreMultiplesOf3Or5_Is233168()
        {
            int value = SumOrNaturalNumbersThatAreMultiplesOf3Or5(1000);

            Assert.AreEqual(answer, value);
        }

        private static int SumOrNaturalNumbersThatAreMultiplesOf3Or5(int below)
        {
            if (below < 1) throw new ArgumentException("must be 1 or greater", nameof(below));

            return new NaturalNumbers()
                .Take(below)
                .Select(n => n.Value)
                .Where(v => v % 3 == 0 || v % 5 == 0)
                .Sum();
        }
    }
}
