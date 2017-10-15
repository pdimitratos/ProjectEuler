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
    public class Problem0018
    {
        /*By starting at the top of the triangle below and moving 
         * to adjacent numbers on the row below, the maximum total
         * from top to bottom is 23.

        3
        7 4
        2 4 6
        8 5 9 3

        That is, 3 + 7 + 4 + 9 = 23.

        Find the maximum total from top to bottom of the triangle below:

        75
        95 64
        17 47 82
        18 35 87 10
        20 04 82 47 65
        19 01 23 75 03 34
        88 02 77 73 07 63 67
        99 65 04 28 06 16 70 92
        41 41 26 56 83 40 80 70 33
        41 48 72 33 47 32 37 16 94 29
        53 71 44 65 25 43 91 52 97 51 14
        70 11 33 28 77 73 17 78 39 68 17 57
        91 71 52 38 17 14 91 43 58 50 27 29 48
        63 66 04 68 89 53 67 30 73 16 69 87 40 31
        04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

        NOTE: As there are only 16384 routes, it is possible to 
        solve this problem by trying every route. However, Problem 67,
        is the same challenge with a triangle containing one-hundred rows; 
        it cannot be solved by brute force, and requires a clever method! ;o)
        */

        List<List<int>> TheTriangle = new List<List<int>>()
        {
            new List<int>(){75 },
            new List<int>(){95, 64},
            new List<int>(){17, 47, 82},
            new List<int>(){18, 35, 87, 10},
            new List<int>(){20, 04, 82, 47, 65},
            new List<int>(){19, 01, 23, 75, 03, 34},
            new List<int>(){88, 02, 77, 73, 07, 63, 67},
            new List<int>(){99, 65, 04, 28, 06, 16, 70, 92},
            new List<int>(){41, 41, 26, 56, 83, 40, 80, 70, 33},
            new List<int>(){41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
            new List<int>(){53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
            new List<int>(){70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
            new List<int>(){91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
            new List<int>(){63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
            new List<int>(){04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23}
        };

        public static List<int> CollapseTriangleLayers(List<int> lowerLayer, List<int> upperLayer)
            => lowerLayer
                .Skip(1)
                .Zip(lowerLayer
                    .SkipLast(1), (left, right) => left > right ? left : right)
                .Zip(upperLayer, (lower, upper) => lower + upper)
                .ToList();

        [TestMethod]
        public void MaximumPathCostOfGivenTriangle_Is1074()
        {
            var answer = TheTriangle
                        .AsEnumerable()
                        .Reverse()
                        .Aggregate(CollapseTriangleLayers)
                        .First();

            Assert.AreEqual(1074, answer);
        }
    }
}
