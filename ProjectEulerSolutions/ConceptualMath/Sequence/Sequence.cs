using ConceptualMath.Numbers;
using ConceptualMath.Numbers.Ordering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using ConceptualMath.Numbers.Generation;

namespace ConceptualMath.Sequence
{
    public abstract class Sequence<TNumber> : ISequence<TNumber>
        where TNumber : IForwardOrdered<TNumber>, INumber, new()
    {
        public IEnumerator<TNumber> GetEnumerator() 
            => new OrderedEnumerator<TNumber>(new TNumber());

        public IEnumerable<BigInteger> Values()
            => this.Select(number => number.Value);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
