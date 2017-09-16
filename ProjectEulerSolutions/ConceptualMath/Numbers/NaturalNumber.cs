using ConceptualMath.Numbers.Ordering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers
{
    public class NaturalNumber : IForwardOrdered<NaturalNumber>, INumber
    {
        private readonly int _value;
        public NaturalNumber() : this(0) { }
        public NaturalNumber(int value)
        {
            _value = value;
        }
        public NaturalNumber First => new NaturalNumber(0);

        public NaturalNumber Next => new NaturalNumber(_value + 1);

        public int Value => _value;

        public NaturalNumber Current => this;
    }
}
