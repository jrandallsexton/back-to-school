using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Misc
{
    /// <summary>
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    /// 
    /// Given a string containing digits from 2-9 inclusive,
    /// return all possible letter combinations that the number could represent.
    /// Return the answer in any order.

    ///A mapping of digits to letters(just like on the telephone buttons) is given below.
    /// Note that 1 does not map to any letters
    /// 
    /// Example 1:
    /// Input: digits = "23"
    /// Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
    /// 
    /// Example 2: 
    /// Input: digits = ""
    /// Output: []
    ///
    /// Example 3: 
    /// Input: digits = "2"
    /// Output: ["a","b","c"]
    ///
    /// Constraints:
    /// 0 <= digits.length <= 4
    /// digits[i] is a digit in the range ['2', '9'].
    /// </summary>
    public class PhoneNumberWords
    {
        private readonly Dictionary<string, List<string>> _numberValues =
            new()
            {
                { "1", [] },
                { "2", ["A", "B", "C"] },
                { "3", ["D", "E", "F"] },
                { "4", ["G", "H", "I"] },
                { "5", ["J", "K", "L"] },
                { "6", ["M", "N", "O"] },
                { "7", ["P", "Q", "R", "S"] },
                { "8", ["T", "U", "V"] },
                { "9", ["W", "X", "Y", "Z"] }
            };

        public IList<string> LetterCombinations(string digits)
        {
            // remove all whitespace chars
            var digitSpan = digits.ToArray();
            string newDigits = string.Empty;

            foreach (var digit in digitSpan)
            {
                if (!char.IsWhiteSpace(digit) && digit != '0' && digit != '1')
                    newDigits += digit;
            }

            if (string.IsNullOrEmpty(newDigits))
                return [];

            var values = new List<string>();

            for (var i = 0; i < newDigits.Length; i++) // e.g "23"
            {
                foreach (var letterValue in _numberValues[newDigits[i].ToString()])
                {
                    // 2 => A,B,C
                    // 3 => D,E,F
                    // capture them
                }

                // create all combinations
            }

            return values;
        }
    }
}
