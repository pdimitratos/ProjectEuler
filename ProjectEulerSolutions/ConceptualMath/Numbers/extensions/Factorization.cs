using ConceptualMath.Numbers.Prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Numerics
{
    public static class Factorization
    {
        public static IEnumerable<BigInteger> GetDivisors(this BigInteger toDivide)
        {
            yield return 1;
            yield return toDivide;

            var currentCandidate = 2;

            while (currentCandidate * currentCandidate < toDivide)
            {
                if (toDivide % currentCandidate == 0)
                {
                    yield return currentCandidate;
                    yield return toDivide / currentCandidate;
                }
                currentCandidate++;
            }
            if (currentCandidate * currentCandidate == toDivide) yield return currentCandidate;
        }

        public static IList<BigInteger> GetPrimeFactors(this BigInteger toFactorize)
        {
            var primeService = new PrimeService();
            var factors = new List<BigInteger>();
            var workingValue = toFactorize;

            while (primeService.LargestIdentifiedPrime * primeService.LargestIdentifiedPrime < workingValue)
            {
                while (workingValue % primeService.LargestIdentifiedPrime == 0)
                {
                    workingValue = workingValue / primeService.LargestIdentifiedPrime;
                    factors.Add(primeService.LargestIdentifiedPrime);
                }
                primeService.FindNextPrime();
            }
            factors.Add(workingValue);
            return factors;
        }

        public static BigInteger SumOfProperDivisors(this BigInteger input)
            => input
            .GetDivisors()
            .Where(factor => factor < input)
            .Sum();
    }
}
