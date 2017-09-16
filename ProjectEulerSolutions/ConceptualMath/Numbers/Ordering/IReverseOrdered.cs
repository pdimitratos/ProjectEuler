using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Ordering
{
    public interface IReverseOrdered<TNumber>
        where TNumber : IReverseOrdered<TNumber>, INumber
    {
        TNumber Previous { get; }
    }
}
