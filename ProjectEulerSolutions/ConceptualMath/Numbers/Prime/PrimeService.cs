using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceptualMath.Numbers.Prime
{
    public class PrimeService
    {
        private List<long> _confirmedPrimes { get; } 
            = new List<long>()
            {
                2
            };

        public long LargestIdentifiedPrime { get; set; }
            = 2;

        public bool IsPrime(long toTest)
        {
            if (toTest < LargestIdentifiedPrime
                && !_confirmedPrimes.Contains(toTest)) return false;

            while (toTest > (LargestIdentifiedPrime * LargestIdentifiedPrime))
            {
                FindNextPrime();
            }

            bool primeFound = !_confirmedPrimes.Any(prime => toTest % prime == 0);
            if (primeFound) _confirmedPrimes.Add(toTest);
            return primeFound;
        }

        public long FindNextPrime()
        {
            long primeCandidate = LargestIdentifiedPrime + 1;
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
