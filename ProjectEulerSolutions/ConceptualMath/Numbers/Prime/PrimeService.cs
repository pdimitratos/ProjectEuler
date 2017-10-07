using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Numbers.Prime
{
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
            if (_confirmedPrimes.Contains(toTest)) return true;
            if (toTest < LargestIdentifiedPrime) return false;

            while (toTest > (LargestIdentifiedPrime * LargestIdentifiedPrime))
            {
                FindNextPrime();
            }

            bool primeFound = !_confirmedPrimes.Any(prime => toTest % prime == 0);
            if (primeFound) _confirmedPrimes.Add(toTest);
            return primeFound;
        }

        public BigInteger FindNextPrime()
        {
            BigInteger primeCandidate = LargestIdentifiedPrime + 1;
            while(true)
            {
                if(IsPrime(primeCandidate))
                {
                    LargestIdentifiedPrime = primeCandidate;
                    return LargestIdentifiedPrime;
                }
                primeCandidate = primeCandidate + 1;
            }
        }
    }
}
