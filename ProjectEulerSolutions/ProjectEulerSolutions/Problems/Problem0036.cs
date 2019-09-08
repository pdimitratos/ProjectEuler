using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Numerics;

namespace ProjectEulerSolutions.Problems
{
    [TestClass]
    public class Problem0036
    {
        /*The decimal number, 585 = 10010010012 (binary), 
         * is palindromic in both bases.

        Find the sum of all numbers, less than one million, 
        which are palindromic in base 10 and base 2.

        (Please note that the palindromic number, in either base, 
        may not include leading zeros.)
        */
        [TestMethod]
        public void Number585_IsPalindromicInBases2And10()
            => Assert.IsTrue(
                new BigInteger(585).IsPalindrome(10)
                && new BigInteger(585).IsPalindrome(2)
            );

        [TestMethod]
        public void SumOfNumbersPalindromicInBase10And2_LessThan1_000_000_Is872187()
        {
            var result = Sequences.NumbersBetween(1, 1_000_000)
                .Where(num => num.IsPalindrome(10))
                .Where(num => num.IsPalindrome(2))
                .Sum();

            Assert.AreEqual(new BigInteger(872187), result);
        }
    }
}
