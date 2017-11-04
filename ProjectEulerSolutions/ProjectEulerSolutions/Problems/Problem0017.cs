using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0017
    {
        /*If the numbers 1 to 5 are written out in words: one, two, three, four, 
         * five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

        If all the numbers from 1 to 1000 (one thousand) inclusive were written 
        out in words, how many letters would be used?


        NOTE: Do not count spaces or hyphens. 
        For example, 342 (three hundred and forty-two) contains 23 letters and 
        115 (one hundred and fifteen) contains 20 letters. The use of "and" 
        when writing out numbers is in compliance with British usage.
        */

        [TestMethod]
        public void LettersIn342WrittenInWords_Is23()
        {
            var n = 342;
            var answer = new BigInteger(n)
                .ToWords()
                .ToCharArray()
                .Count(character => !character.Equals(' '));

            Assert.AreEqual(23, answer);
        }

        [TestMethod]
        public void LettersIn115WrittenInWords_Is20()
        {
            var n = 115;
            var answer = new BigInteger(n)
                .ToWords()
                .ToCharArray()
                .Count(character => !character.Equals(' '));

            Assert.AreEqual(20, answer);
        }

        [TestMethod]
        public void LettersInAllNumbersFrom1To1000_Is21124()
        {
            var answer = Sequences.NumbersBetween(1, 1001)
                            .Select(number => number.ToWords()
                                                    .ToCharArray()
                                                    .Count(character => !character.Equals(' ')))
                            .Sum();

            Assert.AreEqual(21124, answer);
        }
    }
}
