using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Generation
{
    public class DelegatedEnumerable<TOut> : IEnumerable<TOut>
    {
        private readonly Func<IEnumerator<TOut>> _enumDelegate;

        public DelegatedEnumerable(Func<IEnumerator<TOut>> enumDegegate)
        {
            _enumDelegate = enumDegegate;
        }
        public IEnumerator<TOut> GetEnumerator() => _enumDelegate();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
