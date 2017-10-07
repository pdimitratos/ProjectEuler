using ConceptualMath.Numbers.Ordering;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Numbers
{
    public class NaturalNumber : IForwardOrdered<NaturalNumber>, INumber
    {
        private readonly BigInteger _value;
        public NaturalNumber() : this(0) { }
        public NaturalNumber(BigInteger value)
        {
            _value = value;
        }
        public NaturalNumber First => new NaturalNumber(0);

        public NaturalNumber Next => new NaturalNumber(_value + 1);

        public BigInteger Value => _value;

        public NaturalNumber Current => this;
    }
}
