﻿using ConceptualMath.Numbers.Prime;
using ConceptualMath.Sequence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Numbers.Generation
{
    public static class Sequences
    {

        public static IEnumerable<BigInteger> ProductsBetween(BigInteger lowInclusive, BigInteger highExclusive)
        {
            if (lowInclusive > highExclusive) throw new ArgumentException($"low ({lowInclusive}) must be less than high ({highExclusive})");

            for (BigInteger i = lowInclusive; i < highExclusive; i++)
            {
                for (BigInteger j = lowInclusive; j <= i; j++)
                {
                    yield return (i * j);
                }
            }
        }

        public static IEnumerable<BigInteger> NumbersBetween(BigInteger lowInclusive, BigInteger highExclusive)
            => new NaturalNumbers()
                .Skip((int)lowInclusive)
                .Take((int)(highExclusive - lowInclusive))
                .Select(natural => natural.Value);

        public static IEnumerable<BigInteger> Primes()
        {
            var primeService = new PrimeService();
            yield return primeService.LargestIdentifiedPrime;
            while (true)
            {
                var prime = primeService.FindNextPrime();
                yield return prime;
            }
        }

        public static IEnumerable<BigInteger> WherePrime(this IEnumerable<BigInteger> sequence)
        {
            var primeService = new PrimeService();
            var enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (primeService.IsPrime(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
