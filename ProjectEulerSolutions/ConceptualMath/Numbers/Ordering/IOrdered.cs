using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Ordering
{
    public interface IOrdered<TNumber>
        where TNumber : INumber
    {
        TNumber Current { get; }
        TNumber First { get; }
    }
}
