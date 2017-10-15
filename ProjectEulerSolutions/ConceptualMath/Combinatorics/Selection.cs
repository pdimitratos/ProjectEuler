using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Combinatorics
{
    public static class Selection
    {
        public static BigInteger BinomialCoefficient(BigInteger n, BigInteger k)
            => (n.Factorial() / (k.Factorial() * (n - k).Factorial()));

    }
}
