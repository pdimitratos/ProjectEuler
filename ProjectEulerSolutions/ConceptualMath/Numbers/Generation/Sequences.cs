using System;
using System.Collections.Generic;
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
    }
}
