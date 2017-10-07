using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0003
    {
        /*
            The prime factors of 13195 are 5, 7, 13 and 29.

            What is the largest prime factor of the number 600851475143 ?
        */
        [TestMethod]
        public void LargestPrimeFactorOf13195_Is29()
        {
            BigInteger toFactor = 13195;
            var value = toFactor.GetPrimeFactors().Max();

            Assert.AreEqual(29, value);
        }

        [TestMethod]
        public void LargestPrimeFactorOf600851475143_Is6857()
        {
            BigInteger toFactor = 600851475143;
            var value = toFactor.GetPrimeFactors().Max();

            Assert.AreEqual(6857, value);
     
        }
    }
}
