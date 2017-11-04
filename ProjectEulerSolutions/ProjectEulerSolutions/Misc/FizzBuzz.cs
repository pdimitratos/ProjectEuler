using ConceptualMath.Numbers.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerSolutions.Misc
{
    public static class FizzBuzz
    {
        public static IEnumerable<string> FirstNFizzBuzzResults(int n)
            => Sequences.NaturalNumbers()
                .Take(n)
                .Select(input =>
                {
                    var fizzBuzzResult = "";
                    if (input % 3 == 0) fizzBuzzResult += "Fizz";
                    if (input % 5 == 0) fizzBuzzResult += "Buzz";
                    return string.IsNullOrEmpty(fizzBuzzResult)
                        ? input.ToString()
                        : fizzBuzzResult;
                });
    }
}
