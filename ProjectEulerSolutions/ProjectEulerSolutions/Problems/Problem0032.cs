using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEulerSolutions.Problems
{
    [TestClass]
    public class Problem0032
    {
        /*
         * We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

            The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

            Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

            HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
            */
        [TestMethod]
        public void Product7254Of39And186_IsPandigital()
        {
            (BigInteger, BigInteger) pair = (39, 186);
            var set = new List<BigInteger>() { pair.Item1, pair.Item2, pair.Item1 * pair.Item2 };

            var result = set.IsPandigitalSet();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SumOfAllProductsWhereIdentityIsPandigitalSet_Is45228()
        {
            BigInteger expected = 45228;

            var candidates = Sequences.NumbersBetween(1, 10000)
                .Where(num => !num.HasRepeatedDigits())
                .ToList();
            var result = candidates
                .FullJoinWhere(
                    candidates,
                    (multiplicand, multiplier)
                        => multiplicand > multiplier
                        && (multiplicand * multiplier).ToDigits().Count()
                            + multiplicand.ToDigits().Count()
                            + multiplier.ToDigits().Count() == 9,
                    (multiplicand, multiplier)
                        => new List<BigInteger>() { multiplicand, multiplier, multiplicand * multiplier }
                ).Where(identity => !identity.HasRepeatedDigits())
                .Where(identity => identity.IsPandigitalSet())
                .Select(identity => identity[2]) // Product
                .ToHashSet() // Unique
                .Sum();

            Assert.AreEqual(expected, result);
        }


    }
}
