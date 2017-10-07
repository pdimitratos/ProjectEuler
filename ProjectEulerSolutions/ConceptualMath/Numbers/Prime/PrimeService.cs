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

        private long _largestIdentifiedPrime { get; set; }
            = 2;

        public bool IsPrime(long toTest)
        {
            if (toTest < _largestIdentifiedPrime
                && !_confirmedPrimes.Contains(toTest)) return false;

            while (toTest > (_largestIdentifiedPrime ^ 2))
            {
                FindNextPrime();
            }

            return _confirmedPrimes.Any(prime => toTest % prime == 0);
        }

        private void FindNextPrime()
        {
            long primeCandidate = _largestIdentifiedPrime + 2;
            while(true)
            {
                if(IsPrime(primeCandidate))
                {
                    _largestIdentifiedPrime = primeCandidate;
                    return;
                }
                primeCandidate = primeCandidate + 2;
            }
        }
    }
}
