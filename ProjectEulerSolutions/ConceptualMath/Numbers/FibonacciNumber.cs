using ConceptualMath.Numbers.Ordering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Numbers
{
    public class FibonacciNumber : IBidirectionallyOrdered<FibonacciNumber>, INumber
    {
        public FibonacciNumber() : this(1, 1, null) { }
        public FibonacciNumber(int value, int index, FibonacciNumber previous)
        {
            Value = value;
            Index = index;
            _previous = previous;
        }
        
        FibonacciNumber _next { get; set; }
        FibonacciNumber _previous { get; set; }

        public FibonacciNumber Next
        {
            get
            {
                if(_next == null)
                {
                    _next = new FibonacciNumber(Previous.Value + Value, Index + 1, this);
                }
                return _next;
            }
        }

        public FibonacciNumber Current => this;

        public FibonacciNumber First => new FibonacciNumber();

        public FibonacciNumber Previous
        {
            get
            {
                if (_previous == null) return new FibonacciNumber();
                return _previous;
            }
        }

        public int Value { get; set; }
        public int Index { get; set; }
    }
}
