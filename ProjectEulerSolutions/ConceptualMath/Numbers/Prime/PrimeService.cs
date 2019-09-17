using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Numbers.Prime
{
    public static class PrimeExtensions
    {
        public static bool IsPrime(this BigInteger input, PrimeService primeService)
            => primeService.IsPrime(input);
    }
    public class PrimeService
    {
        private List<BigInteger> _confirmedPrimes { get; } 
            = new List<BigInteger>()
            {
                2
            };

        public BigInteger LargestIdentifiedPrime { get; set; }
            = 2;

        public bool IsPrime(BigInteger toTest)
        {
            while (toTest > LargestIdentifiedPrime)
            {
                FindNextPrime();
            }

            return _confirmedPrimes.BinarySearch(toTest) >= 0;
        }

        public BigInteger FindNextPrime()
        {
            BigInteger primeCandidate = LargestIdentifiedPrime + 1;
            while(true)
            {
                bool primeFound = !_confirmedPrimes.Any(prime => primeCandidate % prime == 0);
                if (primeFound)
                {
                    _confirmedPrimes.Add(primeCandidate);
                    LargestIdentifiedPrime = primeCandidate;
                    return LargestIdentifiedPrime;
                }
                primeCandidate = primeCandidate + 1;
            }
        }
    }
}
