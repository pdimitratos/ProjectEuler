using ConceptualMath.Numbers;
using ConceptualMath.Numbers.Ordering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Sequence
{
    public abstract class Sequence<TNumber> : ISequence<TNumber>
        where TNumber : IForwardOrdered<TNumber>, INumber, new()
    {
        public IEnumerator<TNumber> GetEnumerator()
        {
            return new OrderedEnumerator<TNumber>(new TNumber());
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
