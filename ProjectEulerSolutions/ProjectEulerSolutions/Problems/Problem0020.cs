using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0020
    {
        /*n! means n × (n − 1) × ... × 3 × 2 × 1

        For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
        and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

        Find the sum of the digits in the number 100!
        */
        [TestMethod]
        public void SumOfTheDigitsInTheNumber10Factorial_Is27()
        {
            BigInteger n = 10;
            var answer = n.Factorial().ToDigits().Sum();

            Assert.AreEqual(27, answer);
        }

        [TestMethod]
        public void SumOfTheDigitsInTheNumber100Factorial_Is648()
        {
            BigInteger n = 100;
            var answer = n.Factorial().ToDigits().Sum();

            Assert.AreEqual(648, answer);
        }
    }
}
