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


        [TestMethod]
        public void PythagoreanTripletWhereSumOfValuesIs1000_HasProduct31875000()
        {
            var upperBound = 1000;
            var sumOfTriplet = new BigInteger(1000);
            var answer = Sequences.NumbersBetween(1, upperBound + 1)
                .FullJoin(Sequences.NumbersBetween(1, upperBound + 1), LinqExtensions.JoinToTuple<BigInteger, BigInteger>())
                .FullJoin(Sequences.NumbersBetween(1, upperBound + 1), LinqExtensions.JoinToTuple<BigInteger, BigInteger, BigInteger>())
                .Where((tuple) => (tuple.Item1 + tuple.Item2 + tuple.Item3).Equals(sumOfTriplet))
                .Where(BigIntegerExtensions.IsPythagoreanTriplet)
                .Select((tuple) => BigInteger.Multiply(BigInteger.Multiply(tuple.Item1, tuple.Item2), tuple.Item3))
                .First();


            Assert.AreEqual(31875000, answer);
        }
    }
}
