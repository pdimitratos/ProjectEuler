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
    public class Problem0035
    {
        [TestMethod]
        public void RotationsOf197_AreAllPrime()
        {
            var result = new BigInteger(197)
                .ToDigitRotations();

            var result2 = result
                .AllPrime();

            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void NumberOfPrimeRoationsBelow100_Is13()
        {
            var result = Sequences.NumbersBetween(2, 100)
                .Where(num => num.ToDigitRotations().AllPrime());

            Assert.AreEqual(13, result);
        }

        [TestMethod]
        public void NumberOfPrimeRotationsBelow1_000_000_IsSomething()
        {

        }
    }
}
