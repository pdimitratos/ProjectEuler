using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0014
    {
        /*The following iterative sequence is defined for the set of positive integers:

        n → n/2 (n is even)
        n → 3n + 1 (n is odd)

        Using the rule above and starting with 13, we generate the following sequence:

        13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
        It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. 
        Although it has not been proved yet (Collatz Problem), it is thought that all starting 
        numbers finish at 1.

        Which starting number, under one million, produces the longest chain?

        NOTE: Once the chain starts the terms are allowed to go above one million.
        */
        static Func<BigInteger, IEnumerable<BigInteger>> IterateFrom
            = Sequences
                .GenerateIteratively((input) => (input % 2 == 0)
                                    ? BigInteger.Divide(input, 2)
                                    : (BigInteger.Multiply(input, 3) + 1));

        static (BigInteger seed, int termCount) iterationTermCount(BigInteger number)
            => (number,
                    IterateFrom(number)
                    .TakeWhile(value => value != 1)
                    .Count());



        [TestMethod]
        public void ForGivenIterativeSequence_StartingPointOfSequenceWithMostTerms_Is837799()
        {
            var answer = Sequences.NumbersBetween(1, 1_000_001)
                            .Select(iterationTermCount)
                            .OrderByDescending(iteration => iteration.termCount)
                            .First().seed;

            Assert.AreEqual(837799, answer);
        }
    }
}
