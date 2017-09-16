using ConceptualMath.Numbers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConceptualMath.Series
{
    public class OrderedEnumerator<TNumber> : IEnumerator<TNumber>
        where TNumber : IOrdered<TNumber>, INumber
    {
        private IOrdered<TNumber> _current;

        public OrderedEnumerator(TNumber current)
        {
            _current = current;
        }
        public TNumber Current => _current.Current;

        object IEnumerator.Current => _current;

        public bool MoveNext()
        {
            try
            {
                _current = _current.Next;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
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
