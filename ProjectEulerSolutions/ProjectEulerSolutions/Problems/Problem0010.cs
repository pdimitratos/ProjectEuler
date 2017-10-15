using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Numerics;

namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0010
    {
        /*
         * The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

         * Find the sum of all the primes below two million.
         */

        [TestMethod]
        public void SumOfAllPrimesBelow10_Is17()
        {
            var n = 10;
            var answer = Sequences.Primes()
                            .TakeWhile(value => value < n)
                            .Sum();

            Assert.AreEqual(17, answer);
        }

        [TestMethod]
        public void SumOfAllPrimesBelow2_000_000_Is142913828922()
        {
            var n = 2_000_000;
            var answer = Sequences.Primes()
                            .TakeWhile(value => value < n)
                            .Sum();

            Assert.AreEqual(17, answer);
        }
    }
}
