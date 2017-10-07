using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        }

        [TestMethod]
        public void LargestPrimeFactorOf13195_IsSomething()
        {
            BigInteger toFactor = 600851475143;
        }
    }
}
