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
        where TOut : IEquatable<TOut>, new()
    {
        public bool IsFull => Count == Size;
        public int Size { get; private set; }
        private readonly TOut[] _backingArray;
        private readonly bool[] _trackingArray;
        private int _currentIndex;
        public CircularBuffer(int size)
        {
            Size = size;
            _backingArray = new TOut[size];
            _trackingArray = new bool[size];
            _currentIndex = 0;
        }
        public int Count
            => _trackingArray
            .Where(isUsed => isUsed)
            .Count();

        public bool IsReadOnly => false;

        public void Add(TOut item) 
        {
            var indexToInsertAt = _trackingArray
                .TakeWhile(isUsed => isUsed)
                .Count();

            if (indexToInsertAt == Size)
            {
                InsertAt(_currentIndex, item);
                _currentIndex += 1;
            }
            else
            {
                InsertAt(indexToInsertAt, item);
            }
            
            _currentIndex = _currentIndex % Size;
        }

        private void InsertAt(int index, TOut item)
        {
            _backingArray[index] = item;
            _trackingArray[index] = true;
        }

        public void Clear()
        {
            for (int i = 0; i < Size; i++)
            {
                _trackingArray[i] = false;
            }
            _currentIndex = 0;
        }

        public bool Contains(TOut item)
        {
            return _backingArray.Any(i => i.Equals(item));
        }

        public void CopyTo(TOut[] array, int arrayIndex)
        {
            for (int i = 0; i < Size; i++)
            {
                array[i + arrayIndex] = _backingArray[i];
            }
        }

        public IEnumerable<TOut> CurrentElements()
        {
            var backingArraySnapshot = _backingArray.ToList();
            var trackingArraySnapshot = _trackingArray.ToList();
            for (int i = 0; i < Size; i++)
            {
                if (trackingArraySnapshot[i]) yield return backingArraySnapshot[i];
            }
        }

        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var element in CurrentElements())
            {
                yield return element;
            }
        }

        public bool Remove(TOut item)
        {
            var indexOfItem = FindIndexOf(item);

            if (indexOfItem < 0 || !_trackingArray[indexOfItem]) return false;

            _trackingArray[indexOfItem] = false;
            return true;
        }

        protected int FindIndexOf(TOut item)
        {
            for (int i = _currentIndex; i < Size + _currentIndex; i++)
            {
                if (_backingArray[i % Size].Equals(item)
                    && _trackingArray[i % Size])
                {
                    return i % Size;
                }
            }
            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
