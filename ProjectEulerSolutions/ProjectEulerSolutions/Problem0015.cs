using ConceptualMath.Combinatorics;
using ConceptualMath.Numbers.Generation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ProjectEulerSolutions
{
    [TestClass]
    public class Problem0015
    {
        /*Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.


        How many such routes are there through a 20×20 grid?
        */
        IEnumerable<bool> PathChoices()
        {
            yield return true;
            yield return false;
        }

        [TestMethod]
        public void NumberOfPathsThrough2By2Grid_OnlyMovingRightAndDown_Is6()
        {
            var n = 2;

            var answer = Selection.BinomialCoefficient(n * 2, n);

            Assert.AreEqual(6, answer);

        }

        [TestMethod]
        public void NumberOfPathsThrough20By20Grid_OnlyMovingRightAndDown_Is137846528820()
        {
            var n = 20;

            var answer = Selection.BinomialCoefficient(n * 2, n);

            Assert.AreEqual(137846528820, answer);

        }
    }
}
