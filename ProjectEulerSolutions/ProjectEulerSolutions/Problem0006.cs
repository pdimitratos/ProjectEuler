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
    public class Problem0006
    {
        /*
         *The sum of the squares of the first ten natural numbers is,

                1^2 + 2^2 + ... + 10^2 = 385

        The square of the sum of the first ten natural numbers is,

                (1 + 2 + ... + 10)2 = 55^2 = 3025

        Hence the difference between the sum of the squares of the 
        first ten natural numbers and the square of the sum is 
        
                3025 − 385 = 2640.

        Find the difference between the sum of the squares of 
        the first one hundred natural numbers and the square of the sum.

 
         */
        [TestMethod]
        public void DifferenceBetweenSquareOfTheSumAndSumOfTheSquaresOfTheFirst10NaturalNumbers_Is2640()
        {
            var n = 10;
            var value = SumOfSquaresMinusSquareOfSumsOfFirstNNaturalNumbers(n);

            Assert.AreEqual(2640, value);
        }

        [TestMethod]
        public void DifferenceBetweenSquareOfTheSumAndSumOfTheSquaresOfTheFirst100NaturalNumbers_Is25164150()
        {
            var n = 100;
            var value = SumOfSquaresMinusSquareOfSumsOfFirstNNaturalNumbers(n);

            Assert.AreEqual(25164150, value);
        }

        private static BigInteger SumOfSquaresMinusSquareOfSumsOfFirstNNaturalNumbers(int n)
        {
            var firstNNaturalNumbers = Sequences.NumbersBetween(1, n + 1).ToList();

            var sumOfSquares = firstNNaturalNumbers.Select((number) => number * number).Sum();
            var squareOfSum = BigInteger.Pow(firstNNaturalNumbers.Sum(), 2);

            var value = squareOfSum - sumOfSquares;
            return value;
        }
    }
}
