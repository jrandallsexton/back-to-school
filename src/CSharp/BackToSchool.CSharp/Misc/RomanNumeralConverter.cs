using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Misc
{
    /// <summary>
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// Symbol       Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// For example, 2 is written as II in Roman numeral, just two ones added together.
    /// 12 is written as XII, which is simply X + II.
    /// The number 27 is written as XXVII, which is XX + V + II.
    /// Roman numerals are usually written largest to smallest from left to right.
    /// However, the numeral for four is not IIII. Instead, the number four is written as IV.
    /// Because the one is before the five we subtract it making four.
    /// The same principle applies to the number nine, which is written as IX.
    /// There are six instances where subtraction is used:
    ///     I can be placed before V (5) and X (10) to make 4 and 9. 
    ///     X can be placed before L (50) and C (100) to make 40 and 90. 
    ///     C can be placed before D (500) and M (1000) to make 400 and 900.
    /// Given a roman numeral, convert it to an integer.
    /// Example 1:
    /// Input: s = "III"
    /// Output: 3
    /// Explanation: III = 3.
    /// 
    /// Example 2:
    /// Input: s = "LVIII"
    /// Output: 58
    /// Explanation: L = 50, V= 5, III = 3.
    /// 
    /// Example 3:
    /// Input: s = "MCMXCIV"
    /// Output: 1994
    /// Explanation: M = 1000, CM = 900, XC = 90 and IV = 4
    /// </summary>
    public class RomanNumeralConverter
    {
        public int ToRoman(string roman)
        {
            var romanValues = new Dictionary<char, int>()
            {
                { 'I', 1},
                { 'V', 5},
                { 'X', 10},
                { 'L', 50},
                { 'C', 100},
                { 'D', 500},
                { 'M', 1000},
            };

            // need to capture the "gotchyas" (i.e. 4 == IV != IIII, etc)
            // from above:
            // IV => 4
            // IX => 9
            // XL => 40
            // XC => 90
            // CD => 400
            // CM => 900
            var gotchyas = new Dictionary<string, int>()
            {
                { "IV", 4 },
                { "IX", 9 },
                { "XL", 40 },
                { "XC", 90 },
                { "CD", 400 },
                { "CM", 900 },
            };

            // Test1:  LVIII => 53
            // Test2:  XLIII => 43
            var allChars = roman.ToArray().AsSpan();

            var left = 0;
            var right = 1;
            var sum = 0;
            var maxLeft = allChars.Length;

            while (left < maxLeft)
            {
                // look at the left
                var leftChar = allChars[left];
                var rightChar = (maxLeft - 1 == left) ? left : allChars[right];

                // are we in a subtraction scenario?
                var pair = left == right ? string.Empty : $"{leftChar}{rightChar}";

                if (gotchyas.TryGetValue(pair, out var gotchya))
                {
                    sum += gotchya;
                    left = right++;
                    right = left++;
                }
                else
                {
                    sum += romanValues[leftChar];
                    left++;
                    right++;
                }

                // keep count?  match gotchyas?
                // look at the right and see if condition is coming?

                // as i progress, I am performing a summation
            }

            return sum;
        }
    }
}
