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
    public class IgnoreMe
    {
        public IEnumerable<char> Zeroes()
        {
            while(true)
            {
                yield return '0';
            }
        }
        [TestMethod]
        public void demo()
        {
            var reallyBigCharList = new List<char>() { '1' };
            reallyBigCharList.AddRange(Zeroes().Take(900));
            var reallyBigStringRepresentation = new String(reallyBigCharList.ToArray());
            BigInteger.TryParse(reallyBigStringRepresentation, out var reallyBigNumber);

            var bigOperationResult = reallyBigNumber / 137576;

            Console.WriteLine(bigOperationResult.ToString());
        }
    }
}
