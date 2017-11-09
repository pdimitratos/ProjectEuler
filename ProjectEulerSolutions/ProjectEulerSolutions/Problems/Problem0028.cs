using ConceptualMath.Numbers.Generation;
using ConceptualMath.Numbers.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0028
    {
        /*
         * Starting with the number 1 and moving to the right in a 
         * clockwise direction a 5 by 5 spiral is formed as follows:

            21 22 23 24 25
            20  7  8  9 10
            19  6  1  2 11
            18  5  4  3 12
            17 16 15 14 13

            It can be verified that the sum of the numbers on the diagonals is 101.

            What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral 
            formed in the same way?
        */
        public static IEnumerable<BigInteger> DiagonalsOfSquare()
        {
            BigInteger value = 1;
            yield return value;
            BigInteger layer = 1;
            BigInteger turns = 0;
            BigInteger steps = 0;

            while(true)
            {
                value++;
                steps++;
                if(steps == 2 * layer)
                {
                    yield return value;
                    if (turns == 3)
                    {
                        layer++;
                        turns = 0;
                        steps = 0;
                    }
                    else
                    {
                        turns++;
                        steps = 0;
                    }
                }
            }
        }
        public static int ValuesInDiagonalsOfNByNSquare(int n) => 2 * n - 1; 
        [TestMethod]
        public void SumOfDiagonalsOf5x5Square_Is101()
        {
            var n = 5;

            var result = DiagonalsOfSquare()
                .Take(ValuesInDiagonalsOfNByNSquare(n))
                .Sum();

            Assert.AreEqual(101, result);
        }

        [TestMethod]
        public void SumOfDiagonalsOf1001x1001Square_Is669171001()
        {
            var n = 1001;

            var result = DiagonalsOfSquare()
                .Take(ValuesInDiagonalsOfNByNSquare(n))
                .Sum();

            Assert.AreEqual(669171001, result);
        }
    }
}
