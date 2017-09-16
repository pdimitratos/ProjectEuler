using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Ordering
{
    public interface IBidirectionallyOrdered<TNumber> : 
        IForwardOrdered<TNumber>,
        IReverseOrdered<TNumber>
        where TNumber : INumber, IForwardOrdered<TNumber>, IReverseOrdered<TNumber>
    {

    }
}
