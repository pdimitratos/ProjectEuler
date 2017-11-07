using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0026
    {

        /*
         * A unit fraction contains 1 in the numerator. 
         * The decimal representation of the unit fractions with denominators 
         * 2 to 10 are given:

            1/2	= 	0.5
            1/3	= 	0.(3)
            1/4	= 	0.25
            1/5	= 	0.2
            1/6	= 	0.1(6)
            1/7	= 	0.(142857)
            1/8	= 	0.125
            1/9	= 	0.(1)
            1/10	= 	0.1
            Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. 
            It can be seen that 1/7 has a 6-digit recurring cycle.

            Find the value of d < 1000 for which 1/d contains the
            longest recurring cycle in its decimal fraction part.
        */

        [TestMethod]
        public void UnitFractionDenominatorLessThan11WhichHasLongestRecurringCycleInDecimalRepresentation_Is7()
        {
            var result = Sequences
                .NumbersBetween(2, 11)
                .Select(num => (denominator: num, cycleLength: Operations.DecimalRemainder(1, num).RecurringCycleLength()))
                .OrderByDescending(cycle => cycle.cycleLength)
                .First();

            Assert.AreEqual(7, result.denominator);
        }

        [TestMethod]
        public void UnitFractionDenominatorLessThan1000WhichHasLongestRecurringCycleInDecimalRepresentation_Is983()
        {
            var result = Sequences
                .NumbersBetween(2, 1000)
                .Select(num => (denominator: num, cycleLength: Operations.DecimalRemainder(1, num).RecurringCycleLength()))
                .OrderByDescending(cycle => cycle.cycleLength)
                .First();

            Assert.AreEqual(983, result.denominator);
        }
    }
}
