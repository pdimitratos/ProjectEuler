using ConceptualMath.Numbers.Prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConceptualMath.Numbers.Generation
{
    public static class Sequences
    {

        public static IEnumerable<BigInteger> ProductsBetween(BigInteger lowInclusive, BigInteger highExclusive)
        {
            if (lowInclusive > highExclusive) throw new ArgumentException($"low ({lowInclusive}) must be less than high ({highExclusive})");

            for (BigInteger i = lowInclusive; i < highExclusive; i++)
            {
                for (BigInteger j = lowInclusive; j <= i; j++)
                {
                    yield return (i * j);
                }
            }
        }

        public static IEnumerable<BigInteger> NumbersBetween(BigInteger lowInclusive, BigInteger highExclusive)
            => NaturalNumbers()
                .Skip((int)lowInclusive)
                .Take((int)(highExclusive - lowInclusive));


        public static IEnumerable<BigInteger> NaturalNumbers()
        {
            BigInteger currentNatural = 0;
            while (true)
            {
                yield return currentNatural++;
            }
        }

        public static IEnumerable<BigInteger> TriangleNumbers()
        {
            BigInteger runningTotal = 0;
            foreach (var number in NaturalNumbers())
            {
                runningTotal += number;
                yield return runningTotal;
            }
        }

        public static IEnumerable<BigInteger> FibonacciNumbers()
        {
            BigInteger previous = 1;
            yield return previous;
            BigInteger current = 2;
            yield return current;
            BigInteger temp;
            while (true)
            {
                temp = previous;
                previous = current;
                current = temp + previous;
                yield return current;
            }
        }

        private static IEnumerable<TOut> Iterate<TOut>(Func<TOut, TOut> iterativeFunction, TOut seedValue)
        {
            var workingValue = seedValue;
            while (true)
            {
                yield return workingValue;
                workingValue = iterativeFunction(workingValue);
            }
        }

        public static Func<TOut, IEnumerable<TOut>> GenerateIteratively<TOut>(
                Func<TOut, TOut> iterativeFunction
            ) => (TOut seedValue) => Iterate(iterativeFunction, seedValue);



        public static IEnumerable<BigInteger> Primes()
        {
            var primeService = new PrimeService();
            yield return primeService.LargestIdentifiedPrime;
            while (true)
            {
                var prime = primeService.FindNextPrime();
                yield return prime;
            }
        }

        public static IEnumerable<T> Repeat<T>(T input)
        {
            while (true)
            {
                yield return input;
            }
        }
    }
}

