using ConceptualMath.Numbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Series
{
    public class NaturalNumbers : Series<INaturalNumber>
    {
        public override IEnumerator<INaturalNumber> GetEnumerator()
        {
            return new OrderedEnumerator<INaturalNumber>(new NaturalNumber(0));
        }
    }
}
