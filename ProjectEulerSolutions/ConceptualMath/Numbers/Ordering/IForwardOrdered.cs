using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Ordering
{
    public interface IForwardOrdered<TNumber> : IOrdered<TNumber>
        where TNumber : IForwardOrdered<TNumber>, INumber
    {
        TNumber Next { get; }
    }
}
