using ConceptualMath.Conditionals;
using ConceptualMath.Numbers;
using ConceptualMath.Numbers.Generation;
using ConceptualMath.Sequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0005
    {
        /*
         * 2520 is the smallest number that can be divided by each
         * of the numbers from 1 to 10 without any remainder.

            What is the smallest positive number that is evenly 
            divisible by all of the numbers from 1 to 20?

         */

        [TestMethod]
        public void SmallestNumberThatCanBeDividedByNumbersUpTo10WithoutRemainder_Is2520()
        {
            
            var divisors = Sequences.NumbersBetween(1, 11)
                .WherePrime();
            var value = new NaturalNumbers()
                .Skip(1) //skip 0
                .Select(natural => natural.Value)
                .First(number => !divisors.Any(Conditional.HasRemainderWhenDividing(number)));

            Assert.AreEqual(2520, value);
        }

        [TestMethod]
        public void SmallestNumberThatCanBeDividedByNumbersUpTo20WithoutRemainder_IsSomething()
        {

            var divisors = Sequences.NumbersBetween(1, 21);
            var value = new NaturalNumbers()
                .Skip(1) //skip 0
                .Select(natural => natural.Value)
                .First(number => !divisors.Any(Conditional.HasRemainderWhenDividing(number)));

            Assert.AreEqual(2520, value);
        }
    }
}
