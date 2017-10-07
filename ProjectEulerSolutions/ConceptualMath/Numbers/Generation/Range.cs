using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers.Generation
{
    public class Range<TIn, TOut> : IEnumerator<TOut>
    {
        private readonly Func<TIn, TOut> _graph;
        private readonly IEnumerator<TIn> _domain;

        public Range(IEnumerator<TIn> domain, Func<TIn, TOut> graph)
        {
            _graph = graph;
            _domain = domain;
        }

        public TOut Current => _graph(_domain.Current);

        object IEnumerator.Current => Current;

        public void Dispose() => _domain.Dispose();


        public bool MoveNext() => _domain.MoveNext();

        public void Reset() => _domain.Reset();
    }
}
