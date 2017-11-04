using System;
using System.Collections.Generic;
using System.Text;

namespace System.Numerics
{
    public static class Equality
    {

    }

    public class BigIntegerEquater : IEqualityComparer<BigInteger>
    {
        private readonly Func<BigInteger, BigInteger, bool> _comparator;
        private readonly Func<BigInteger, int> _hashingFunction;
        public BigIntegerEquater()
        {
            _comparator = (BigInteger a, BigInteger b) => a.Equals(b);
            _hashingFunction = a => a.GetHashCode();
        }

        public BigIntegerEquater(Func<BigInteger, BigInteger, bool> comparatorToUse, Func<BigInteger, int> hashingFunctionToUse)
        {
            _comparator = comparatorToUse;
            _hashingFunction = hashingFunctionToUse;
        }
        public bool Equals(BigInteger x, BigInteger y) => _comparator(x, y);
        public int GetHashCode(BigInteger obj) => _hashingFunction(obj);
    }
}
