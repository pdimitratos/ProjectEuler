using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Ordering
{
    public abstract class BidirectionallyOrdered<TNumber>
        : Ordered<TNumber>
        where TNumber : IBidirectionallyOrdered<TNumber>, INumber
    {
        public BidirectionallyOrdered(TNumber value) : base(value)
        {
        }
    }
}
