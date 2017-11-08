using ConceptualMath.Numbers.Generation;
using ConceptualMath.Numbers.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0027
    {
        /*
         * Euler discovered the remarkable quadratic formula:

            n2+n+41n2+n+41
            It turns out that the formula will produce 40 primes 
            for the consecutive integer values 0≤n≤390≤n≤39. 
            However, when n=40,40^2+40+41=40(40+1)+41 is divisible by 41, 
            and certainly when n=41,412+41+41 is clearly divisible by 41.

            The incredible formula n^2−79n+1601 was discovered,
            which produces 80 primes for the consecutive values 0≤n≤79. 
            The product of the coefficients, −79 and 1601, is −126479.

            Considering quadratics of the form:

            n^2+an+b, where |a|<1000 and |b|≤1000

            where |n| is the modulus/absolute value of n
            e.g. |11|=11 and |−4|=4
            Find the product of the coefficients, aa and bb, for the
            quadratic expression that produces the maximum number of 
            primes for consecutive values of nn, starting with n=0n=0.
            */

        [TestMethod]
        public void IncrediblePrimeGeneratingQuadratic_Generates80Primes()
        {
            var primeService = new PrimeService();
            var result = Sequences
                .NaturalNumbers()
                .Select(Operations.QuadraticFunction(-79, 1601))
                .TakeWhile(primeService.IsPrime)
                .Count();

            Assert.AreEqual(80, result);
        }
        
        [TestMethod]
        public void ProductOfAAndBInQuadradicThatGeneratesMostPrimes_IsNegative59231()
        {
            var primeService = new PrimeService();
            var result = Sequences
                .NaturalNumbers()
                .Select(n => n - 1000)
                .Take(2001)
                .FullJoin(
                    Sequences
                    .NaturalNumbers()
                    .Select(n => n - 1000)
                    .Take(2001),
                    (a, b) => (a: a, b: b))
                .Select(quadratic => (
                    quadratic: quadratic,
                    primeCount: Sequences
                        .NaturalNumbers()
                        .Select(Operations.QuadraticFunction(quadratic.a, quadratic.b))
                        .TakeWhile(primeService.IsPrime)
                        .Count()))
                .OrderByDescending(quadResult => quadResult.primeCount)
                .Select(quadResult => quadResult.quadratic.a * quadResult.quadratic.b)
                .First();

            Assert.AreEqual(-59231, result);
        }
    }
}
