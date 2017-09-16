using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers
{
    public interface IOrdered<TNumber>
        where TNumber : INumber
    {
        TNumber Current { get; }
        IOrdered<TNumber> First { get; }
        IOrdered<TNumber> Next { get; }
    }
}
