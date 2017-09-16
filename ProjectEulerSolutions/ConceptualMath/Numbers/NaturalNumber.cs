using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers
{
    public class NaturalNumber : INaturalNumber
    {
        private readonly int _value;

        public NaturalNumber(int value)
        {
            _value = value;
        }
        public IOrdered<INaturalNumber> First => new NaturalNumber(0);

        public IOrdered<INaturalNumber> Next => new NaturalNumber(_value + 1);

        public int Value => _value;

        public INaturalNumber Current => this;
    }
}
