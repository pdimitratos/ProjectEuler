using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0019
    {
        /*
         * You are given the following information, but you may prefer to do some research for yourself.

            1 Jan 1900 was a Monday.
            Thirty days has September,
            April, June and November.
            All the rest have thirty-one,
            Saving February alone,
            Which has twenty-eight, rain or shine.
            And on leap years, twenty-nine.
            A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
            How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
        */

        [TestMethod]
        public void NumberOfSundaysThatFellOnTheFirstOfTheMonthDuringThe20thCentury_Is171()
        {
            var start = DateTime.Parse("1 Jan 1901");
            var end = DateTime.Parse("1 Jan 2001");

            var answer = Sequences.GenerateIteratively<DateTime>((date) => date.AddDays(1))
                            (start)
                            .Where(MatchesProblemConditions)
                            .TakeWhile(date => date < end)
                            .Count();

            Assert.AreEqual(171, answer);
        }

        private static bool MatchesProblemConditions(DateTime input)
            => input.DayOfWeek == DayOfWeek.Sunday
            && input.Day == 1;

        
    }
}
