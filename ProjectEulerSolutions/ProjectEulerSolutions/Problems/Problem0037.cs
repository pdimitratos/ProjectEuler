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
    /*
     * The number 3797 has an interesting property. 
     * Being prime itself, it is possible to continuously remove digits 
     * from left to right, and remain prime at each stage: 3797, 797, 97, 
     * and 7. Similarly we can work from right to left: 3797, 379, 37,
     * and 3.

    Find the sum of the only eleven primes that are both truncatable
    from left to right and right to left.

    NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
    */
    [TestClass]
    public class Problem0037
    {
        
        [TestMethod]
        public void Prime3797_IsTruncatable()
        {
            Assert.IsTrue(new BigInteger(3797).IsTruncatable(new PrimeService()));
        }

        [TestMethod]
        public void SumOfTruncatablePrimes_Is748317()
        {
            var primeService = new PrimeService();
            Assert.AreEqual(
                748317,
                Sequences.Primes(primeService)
                    .Where(prime => prime > 7) // Trivial
                    .Where(prime => prime.IsTruncatable(primeService))
                    .Take(11)
                    .Sum()
            );
        }
    }

}

namespace System.Numerics
{
    public static class TruncatableExtensions
    {
        public static bool IsTruncatable(this BigInteger prime, PrimeService primeService)
        => prime.ToDigits()
            .ToArray()
            .All(
                ((BigInteger[] digitArray, int index) i)
                => i.digitArray.Take(i.index + 1).FromDigits().IsPrime(primeService)
                && i.digitArray.TakeLast(i.index + 1).FromDigits().IsPrime(primeService)
            );
    }
}