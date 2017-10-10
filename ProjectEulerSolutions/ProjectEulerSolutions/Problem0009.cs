using ConceptualMath.Conditionals;
using ConceptualMath.Numbers;
using ConceptualMath.Numbers.Generation;
using ConceptualMath.Sequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0009
    {
        /*
         * A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

            a2 + b2 = c2
            For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

            There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            Find the product abc.
        */

        public static bool Test(Tuple<BigInteger, BigInteger, BigInteger> tuple)
        {
            var passesTest = (tuple.Item1 + tuple.Item2 + tuple.Item3).Equals(new BigInteger(1000));
            return passesTest;
        }


        [TestMethod]
        public void PythagoreanTripletWhereSumOfValuesIs1000_HasProductSomething()
        {
            var upperBound = 1000;
            var answer = Sequences.NumbersBetween(1, upperBound + 1)
                .Join<BigInteger, BigInteger, bool, Tuple<BigInteger, BigInteger>>(Sequences.NumbersBetween(1, upperBound + 1), () => true, () => true,(left, right) => new Tuple<BigInteger, BigInteger>(left, right))
                .ZipToTuple(Sequences.NumbersBetween(1, upperBound + 1))
                .Where(Problem0009.Test)
                .Where(BigIntegerExtensions.IsPythagoreanTriplet)
                .Select((tuple) => BigInteger.Multiply(BigInteger.Multiply(tuple.Item1, tuple.Item2), tuple.Item3))
                .First();


            Assert.AreEqual(0, answer);
        }
    }
}
