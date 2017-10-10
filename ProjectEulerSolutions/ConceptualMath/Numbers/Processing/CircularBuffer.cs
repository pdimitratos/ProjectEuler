using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Numbers.Processing
{
    public class CircularBuffer<TOut> 
        : ICollection<TOut>, 
        IEnumerable<TOut>
        where TOut : class
    {
        private int _size;
        private readonly TOut[] _backingArray;
        private int _currentIndex { get; set; }
        public CircularBuffer(int size)
        {
            _size = size;
            _backingArray = new TOut[size];
            _currentIndex = 0;
        }
        public int Count
            => _backingArray
            .Where(item => !(item is null))
            .Count();

        public bool IsReadOnly => false;

        public void Add(TOut item) 
        {
            _backingArray[_currentIndex] = item;
            _currentIndex += 1;
            _currentIndex = _currentIndex % _size;
        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _backingArray[i] = null;
            }
            _currentIndex = 0;
        }

        public bool Contains(TOut item)
        {
            return _backingArray.Any(i => i == item);
        }

        public void CopyTo(TOut[] array, int arrayIndex)
        {
            for (int i = 0; i < _size; i++)
            {
                array[i + arrayIndex] = _backingArray[i];
            }
        }

        public IEnumerable<TOut> CurrentElements => _backingArray.ToArray().Where(value => !(value is null));

        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var element in CurrentElements)
            {
                yield return element;
            }
        }

        public bool Remove(TOut item)
        {
            var indexOfItem = FindIndexOf(item);

            if (indexOfItem < 0) return false;

            _backingArray[indexOfItem] = null;
            return true;
        }

        protected int FindIndexOf(TOut item)
        {
            for (int i = _currentIndex; i < _size + _currentIndex; i++)
            {
                if (_backingArray[i % _size] == item)
                {
                    return i % _size;
                }
            }
            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
