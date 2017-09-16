using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers
{
    public abstract class Ordered<TNumber> : IOrdered<TNumber>
        where TNumber : INumber
    {
        private readonly TNumber _value;

        public Ordered(TNumber value)
        {
            _value = value;
        }
        public abstract IOrdered<TNumber> First { get; }

        public abstract IOrdered<TNumber> Next { get; }

        public TNumber Current => _value;

    }
}
