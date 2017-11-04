using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0025
    {
        /*
         * The Fibonacci sequence is defined by the recurrence relation:

            Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
            Hence the first 12 terms will be:

            F1 = 1
            F2 = 1
            F3 = 2
            F4 = 3
            F5 = 5
            F6 = 8
            F7 = 13
            F8 = 21
            F9 = 34
            F10 = 55
            F11 = 89
            F12 = 144
            The 12th term, F12, is the first term to contain three digits.

            What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
        */

        [TestMethod]
        public void FirstTermOfFibonacciSequenceToContain3digts_IsThe12th()
        {
            var expected = 12;
            var result = Sequences.FibonacciNumbers()
                .TakeWhile(num => num < 100)
                .LongCount() + 2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FirstTermOfFibonacciSequenceToContain1000digts_IsThe4782nd()
        {
            var expected = 4782;
            var thousandDigitNumber = Sequences
                .Repeat(new BigInteger(0))
                .Take(999)
                .Append(new BigInteger(1))
                .FromDigits();
            var result = Sequences.FibonacciNumbers()
                .TakeWhile(num => num < thousandDigitNumber)
                .LongCount() + 2;

            Assert.AreEqual(expected, result);
        }
    }
}
