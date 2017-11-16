using ConceptualMath.Numbers.Generation;
using ConceptualMath.Numbers.Prime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static ConceptualMath.Numbers.Generation.Sequences;

namespace ProjectEulerSolutions
{

    [TestClass]
    public class Problem0031
    {
        /*
         * In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

            1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
            It is possible to make £2 in the following way:

            1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
            How many different ways can £2 be made using any number of coins?
        */
        /* notes
         * Test case? making 5p
         * 5*1p, 3*1p + 2*2p, 1*1p + 2*2p, 1*5p => 4 combinations?
         * 
         */
        private static List<BigInteger> _coins() => new List<BigInteger>() { 1, 2, 5, 10, 20, 50, 100, 200 };

        [TestMethod]
        public void NumberOfWaysToMake5pChange_Is4()
        {
            var n = 5;
            var answer = Problem31(n);

            Assert.AreEqual(4, answer);
        }

        [TestMethod]
        public void NumberOfWaysToMake200pChange_IsSomething()
        {
            var n = 200;
            var answer = Problem31(n);

            Assert.AreEqual(73682, answer);
        }

        private static int Problem31(int n)
        {
            List<List<(BigInteger value, int count)>> results = new List<List<(BigInteger value, int count)>>();
            bool areEqual(List<(BigInteger value, int count)> a, List<(BigInteger value, int count)> b)
                => a.Zip(b, (x, y) => x.count == y.count)
                    .All(t => t);
            Action<List<(BigInteger value, int count)>> addUniquesToResults = coinList =>
            {
                if (!results.Any(result => areEqual(result, coinList)))
                {
                    results.Add(coinList);
                }
            };
            _coins()
                .Select(coin => ((currentValue: coin, mostRecent: coin, selectedCoins: new List<BigInteger>() { coin })))
                .ApplyWhile(
                    coinBags =>
                    {
                        coinBags
                            .Where(coinBag => coinBag.currentValue == n)
                            .Select(coinbag => coinbag.selectedCoins)
                            .Select(coinList => _coins()
                                .Select(coin => ((value: coin, count: coinList.Where(x => x == coin).Count())))
                                .OrderBy(t => t.value)
                                .ToList()
                            ).Map(addUniquesToResults);
                        return coinBags
                            .Where(coinBag => coinBag.currentValue < n)
                            .Select(coinBag => (coinBag: coinBag, coinsToAdd: _coins().Where(coin => coin >= coinBag.mostRecent && (coinBag.currentValue + coin) <= n)))
                            .SelectMany(bagCombo => bagCombo.coinsToAdd.Select(
                                coin => (currentValue: bagCombo.coinBag.currentValue + coin, mostRecent: coin, selectedCoins: bagCombo.coinBag.selectedCoins.Append(coin).ToList()))
                            );
                    },
                    coinbags => coinbags.Any(coinBag => coinBag.currentValue <= n));
 
            return results.Count;
        }
    }
}
