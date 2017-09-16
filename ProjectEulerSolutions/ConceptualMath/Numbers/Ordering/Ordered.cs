using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Ordering
{
    public abstract class Ordered<TNumber>
        where TNumber : IForwardOrdered<TNumber>, INumber
    {
        private readonly TNumber _value;

        public Ordered(TNumber value)
        {
            _value = value;
        }
        public abstract TNumber First { get; }

        public abstract TNumber Next { get; }

        public TNumber Current => _value;

    }
}
