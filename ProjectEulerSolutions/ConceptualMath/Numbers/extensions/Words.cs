using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Numerics
{
    public static class Words
    {
        /// <summary>
        /// Writes the given number in words. Currently only valid between 1 and 1000 (inclusive)
        /// </summary>
        /// <param name="toConvert"></param>
        /// <returns></returns>
        public static string ToWords(this BigInteger toConvert)
        {
            var words = new StringBuilder();
            Action<string> add = (input) => words.Append(input);
            Action addHundred = () => add(" hundred ");
            Action addAnd = () => add(" and ");

            Action<BigInteger> basicDigitToWord = (BigInteger digit)
                =>
            {
                switch ((int)digit)
                {
                    case 0:
                        break;
                    case 1:
                        add(" one ");
                        break;
                    case 2:
                        add(" two ");
                        break;
                    case 3:
                        add(" three ");
                        break;
                    case 4:
                        add(" four ");
                        break;
                    case 5:
                        add(" five ");
                        break;
                    case 6:
                        add(" six ");
                        break;
                    case 7:
                        add(" seven ");
                        break;
                    case 8:
                        add(" eight ");
                        break;
                    case 9:
                        add(" nine ");
                        break;
                    default:
                        throw new IndexOutOfRangeException($"digits only, please; value provided was ${digit}");
                }
            };

            Action<BigInteger> teensDigitToWords = (BigInteger onesPlace) =>
            {
                switch ((int)onesPlace)
                {
                    case 0:
                        add(" ten ");
                        break;
                    case 1:
                        add(" eleven ");
                        break;
                    case 2:
                        add(" twelve ");
                        break;
                    case 3:
                        add(" thirteen ");
                        break;
                    case 4:
                        add(" fourteen ");
                        break;
                    case 5:
                        add(" fifteen ");
                        break;
                    case 6:
                        add(" sixteen ");
                        break;
                    case 7:
                        add(" seventeen ");
                        break;
                    case 8:
                        add(" eighteen ");
                        break;
                    case 9:
                        add(" nineteen ");
                        break;
                    default:
                        throw new IndexOutOfRangeException($"digits only, please; value provided was ${onesPlace}");
                }
            };

            Action<BigInteger, BigInteger> tensDigitToWord = (BigInteger digit, BigInteger onesDigit) =>
            {
                Action addOnesDigit = () => basicDigitToWord(onesDigit);
                switch ((int)digit)
                {
                    case 0:
                        addOnesDigit();
                        break;
                    case 1:
                        teensDigitToWords(onesDigit);
                        break;
                    case 2:
                        add(" twenty ");
                        addOnesDigit();
                        break;
                    case 3:
                        add(" thirty ");
                        addOnesDigit();
                        break;
                    case 4:
                        add(" forty ");
                        addOnesDigit();
                        break;
                    case 5:
                        add(" fifty ");
                        addOnesDigit();
                        break;
                    case 6:
                        add(" sixty ");
                        addOnesDigit();
                        break;
                    case 7:
                        add(" seventy ");
                        addOnesDigit();
                        break;
                    case 8:
                        add(" eighty ");
                        addOnesDigit();
                        break;
                    case 9:
                        add(" ninety ");
                        addOnesDigit();
                        break;
                    default:
                        throw new IndexOutOfRangeException($"digits only, please; value provided was ${digit}");
                }
            };


            Action<BigInteger, BigInteger, BigInteger> addDigitsToWords = (BigInteger hundreds, BigInteger tens, BigInteger ones)
                =>
            {
                if (hundreds > 0)
                {
                    basicDigitToWord(hundreds);
                    add(" hundred ");
                    if (!(tens == 0 && ones == 0)) add(" and ");
                }
                tensDigitToWord(tens, ones);
            };

            var digits = toConvert.ToDigits().ToList();

            if (digits.Count() > 3)
            {
                add("one thousand");
            }
            else
            {
                if (digits.Count == 3) addDigitsToWords(digits[2], digits[1], digits[0]);
                if (digits.Count == 2) tensDigitToWord(digits[1], digits[0]);
                if (digits.Count == 1) basicDigitToWord(digits[0]);
            }
            return words.ToString();
        }
    }
}
