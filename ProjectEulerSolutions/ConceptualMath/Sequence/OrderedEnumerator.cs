using ConceptualMath.Numbers;
using ConceptualMath.Numbers.Ordering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Sequence
{
    public class OrderedEnumerator<TNumber> : IEnumerator<TNumber>
        where TNumber : IForwardOrdered<TNumber>, INumber
    {
        protected TNumber _current;
        protected readonly TNumber _initial;

        public OrderedEnumerator(TNumber initial)
        {
            _initial = initial;
        }
        public TNumber Current => _current.Current;

        object IEnumerator.Current => _current;

        public bool MoveNext()
        {
            try
            {
                return TryMoveNext();
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected virtual bool TryMoveNext()
        {
            _current = (_current == null) ? _initial : _current.Next;
            return true;
        }

        public void Reset()
        {
            _current = _current.First;
        }

        bool disposed = false;

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
