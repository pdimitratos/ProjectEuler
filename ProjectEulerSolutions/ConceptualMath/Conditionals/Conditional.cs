using ConceptualMath.Numbers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Conditionals
{
    public static class Conditional
    {
        public static Func<BigInteger, Func<BigInteger, bool>> HasRemainderWhenDividing 
            = (number) => (divisor) => number % divisor != 0;
    }
}
