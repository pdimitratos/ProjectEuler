using ConceptualMath.Numbers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Series
{
    public abstract class Series<TNumber> : ISeries<TNumber>
        where TNumber : IOrdered<TNumber>, INumber
    {
        public abstract IEnumerator<TNumber> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
