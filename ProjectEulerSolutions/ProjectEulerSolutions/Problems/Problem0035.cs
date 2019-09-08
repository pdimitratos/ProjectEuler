using ConceptualMath.Numbers.Generation;
using ConceptualMath.Numbers.Prime;
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
            var primeService = new PrimeService();
            var result = new BigInteger(197)
                .ToDigitRotations();

            var result2 = result
                .AllPrime(primeService);

            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void NumberOfPrimeRoationsBelow100_Is13()
        {
            var primeService = new PrimeService();
            var result = Sequences.NumbersBetween(2, 100)
                .Where(num => num.ToDigitRotations().AllPrime(primeService))
                .Count();

            Assert.AreEqual(13, result);
        }

        [TestMethod]
        public void NumberOfPrimeRotationsBelow1_000_000_Is55()
        {
            var primeService = new PrimeService();
            var result = Sequences.NumbersBetween(2, 1_000_000)
                .Where(num => primeService.IsPrime(num))
                .Where(num => num.ToDigitRotations().AllPrime(primeService))
                .Count();

            Assert.AreEqual(55, result);
        }
    }
}
