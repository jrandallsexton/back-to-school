
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Validators;
using DotNext.Collections.Generic;
using LanguageExt;

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
    public static class RomanNumeralConverter
    {
        private static readonly char[] _validChars =
        [
            'I',
            'V',
            'X',
            'L',
            'C',
            'D',
            'M'
        ];

        /// <summary>
        /// need to capture the "gotchyas" (i.e. 4 == IV != IIII, etc)
        /// from above:
        /// IV => 4
        /// IX => 9
        /// XL => 40
        /// XC => 90
        /// CD => 400
        /// CM => 900
        /// </summary>
        private static readonly Dictionary<string, int> _gotchyas = new Dictionary<string, int>()
        {
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 },
        };

        private static readonly Dictionary<char, int> _romanValues = new Dictionary<char, int>()
        {
            { 'I', 1},
            { 'V', 5},
            { 'X', 10},
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000},
        };

        private static readonly Dictionary<char, char> _triggers = new Dictionary<char, char>()
        {
            { 'V', 'I' },
            { 'X', 'I' },
            { 'L', 'X' },
            { 'C', 'X' },
            { 'D', 'C' },
            { 'M', 'C' }
        };

        // using these two instead of a Dictionary
        private static readonly char[] _triggerChars =
        [
            'V',
            'X',
            'L',
            'C',
            'D',
            'M'
        ];

        private static readonly char[] _triggerVals =
        [
            'I',
            'I',
            'X',
            'X',
            'C',
            'C'
        ];

        public static int ToRoman_NaiveBruteForce(string roman)
        {
            // just do a string replacement
            foreach (var romanChar in roman)
            {
                if (!_romanValues.ContainsKey(romanChar))
                    return 0;
            }

            var values = new List<int>();

            foreach (var foo in _gotchyas)
            {
                while (roman.Contains(foo.Key))
                {
                    values.Add(_gotchyas[foo.Key]);
                    roman = roman.Replace(foo.Key, string.Empty);
                }
            }

            foreach (var letter in roman)
            {
                values.Add(_romanValues[letter]);
            }

            return values.Sum();
        }

        public static Option<int> ToRoman_NaiveBruteForce_LExt(string roman)
        {
            
            // just do a string replacement
            foreach (var romanChar in roman)
            {
                if (!_romanValues.ContainsKey(romanChar))
                    return 0;
            }

            var values = new List<int>();

            foreach (var foo in _gotchyas)
            {
                while (roman.Contains(foo.Key))
                {
                    values.Add(_gotchyas[foo.Key]);
                    roman = roman.Replace(foo.Key, string.Empty);
                }
            }

            foreach (var letter in roman)
            {
                values.Add(_romanValues[letter]);
            }

            return values.Sum();
        }

        public static int ToRoman_NaiveBruteForce_Alt(string roman)
        {
            // just do a string replacement
            var romanSpan = roman.AsSpan();

            foreach (var romanChar in romanSpan)
            {
                if (!_romanValues.ContainsKey(romanChar))
                    return 0;
            }

            var values = new List<int>();

            foreach (var foo in _gotchyas)
            {
                while (roman.Contains(foo.Key))
                {
                    values.Add(_gotchyas[foo.Key]);
                    roman = roman.Replace(foo.Key, string.Empty);
                }
            }

            foreach (var letter in roman)
            {
                values.Add(_romanValues[letter]);
            }

            return values.Sum();
        }

        public static int ToRomanExtensionLinear(this string roman)
        {
            var romanSpan = roman.AsSpan();
            var values = new List<int>();

            char? prev = null;
            char current;

            for (var i = 0; i < romanSpan.Length; i++)
            {
                current = romanSpan[i];

                if (!_validChars.Contains(current))
                    return 0;

                if (prev == null)
                {
                    values.Add(_romanValues[current]);
                    prev = current;
                    continue;
                }

                _triggers.TryGetValue(current, out char triggerValue);
                if (triggerValue == prev)
                {
                    // just update the lastmost entry in values
                    values[^1] = _romanValues[current] - values[^1];
                }
                else
                {
                    values.Add(_romanValues[current]);
                }

                prev = current;

            }

            return values.Sum();
        }

        public static int ToRomanLinear(string roman)
        {
            var romanSpan = roman.AsSpan();
            var values = new List<int>();

            char? prev = null;
            char current;

            for (var i = 0; i < romanSpan.Length; i++)
            {
                current = romanSpan[i];

                if (!_validChars.Contains(current))
                    return 0;

                if (prev == null)
                {
                    values.Add(_romanValues[current]);
                    prev = current;
                    continue;
                }

                _triggers.TryGetValue(current, out char triggerValue);
                if (triggerValue == prev)
                {
                    // just update the lastmost entry in values
                    values[^1] = _romanValues[current] - values[^1];
                }
                else
                {
                    values.Add(_romanValues[current]);
                }

                prev = current;

            }

            return values.Sum();
        }

        public static int ToRomanLinearAlt(string roman)
        {
            var romanSpan = roman.AsSpan();
            var validCharsSpan = _validChars.AsSpan();
            
            var values = new List<int>();
            
            char? prev = null;

            var max = romanSpan.Length;
            for (var i = 0; i < max; i++)
            {
                var current = romanSpan[i];

                if (!validCharsSpan.Contains(current))
                    return 0;

                if (i == 0)
                {
                    values.Add(_romanValues[current]);
                    prev = current;
                    continue;
                }

                _triggers.TryGetValue(current, out char triggerValue);
                if (triggerValue == prev)
                {
                    // just update the lastmost entry in values
                    values[^1] = _romanValues[current] - values[^1];
                }
                else
                {
                    values.Add(_romanValues[current]);
                }

                prev = current;

            }

            return values.Sum();
        }

        public static int ToRomanLinearAllSpansSubtraction(string roman)
        {
            var romanSpan = roman.AsSpan();
            var validCharsSpan = _validChars.AsSpan();
            var triggerCharsSpan = _triggerChars.AsSpan();
            var triggerValuesSpan = _triggerVals.AsSpan();

            var sum = 0;

            char? prev = null;
            var prevValue = 0;

            var max = romanSpan.Length;
            for (var i = 0; i < max; i++)
            {
                var current = romanSpan[i];

                if (!validCharsSpan.Contains(current))
                    return 0;

                if (i == 0)
                {
                    sum += _romanValues[current];
                    prev = current;
                    prevValue = sum;
                    continue;
                }

                // Does this character have a trigger?
                var triggerCharIndex = triggerCharsSpan.IndexOf(current);

                if (triggerCharIndex > -1)
                {
                    // yes, it does
                    // get the value for the trigger
                    var triggerValue = triggerValuesSpan[triggerCharIndex];

                    if (triggerValue == prev)
                    {
                        // perform subtraction to update the sum
                        sum += (_romanValues[current] - prevValue) - prevValue;
                        prevValue = _romanValues[current];
                        continue;
                    }
                }

                prevValue = _romanValues[current];
                sum += prevValue;
                prev = current;

            }

            return sum;
        }

        public static int ToRomanLastShot(string roman)
        {
            var romanSpan = roman.AsSpan();
            var validCharsSpan = _validChars.AsSpan();
            var triggerCharsSpan = _triggerChars.AsSpan();
            var triggerValuesSpan = _triggerVals.AsSpan();

            var sum = 0;

            char? prev = null;
            var prevValue = 0;

            var max = romanSpan.Length;
            for (var i = 0; i < max; i++)
            {
                var current = romanSpan[i];

                if (!validCharsSpan.Contains(current))
                    return 0;

                if (i == 0)
                {
                    sum += _romanValues[current];
                    prev = current;
                    prevValue = sum;
                    continue;
                }

                // Does this character have a trigger?
                var triggerCharIndex = triggerCharsSpan.IndexOf(current);

                if (triggerCharIndex > -1)
                {
                    // yes, it does
                    // get the value for the trigger
                    var triggerValue = triggerValuesSpan[triggerCharIndex];

                    if (triggerValue == prev)
                    {
                        // perform subtraction to update the sum
                        var currentValue = _romanValues[current];
                        sum += (currentValue - prevValue) - prevValue;
                        prev = current;
                        prevValue = currentValue;
                        continue;
                    }
                }

                prevValue = _romanValues[current];
                sum += prevValue;
                prev = current;

            }

            return sum;
        }

        public static int ToRoman(string roman)
        {
            var allChars = roman.ToArray();

            var left = 0;
            var right = 1;
            var sum = 0;
            var maxLeft = allChars.Length;

            while (left < maxLeft)
            {
                // look at the left
                var leftChar = allChars[left];

                if (!_validChars.Contains(leftChar))
                    return 0;

                var rightChar = (maxLeft - 1 == left) ? leftChar : allChars[right];

                // are we in a subtraction scenario?
                var pair = left == right ? string.Empty : $"{leftChar}{rightChar}";

                if (_gotchyas.TryGetValue(pair, out var gotchya))
                {
                    sum += gotchya;
                    left = right + 1;
                    right = left + 1;
                }
                else
                {
                    sum += _romanValues[leftChar];
                    left++;
                    right++;
                }
            }

            return sum;
        }

        public static int ToRomanAsSpan(string roman)
        {
            var allChars = roman.ToArray().AsSpan();

            var left = 0;
            var right = 1;
            var sum = 0;
            var maxLeft = allChars.Length;

            while (left < maxLeft)
            {
                // look at the left
                var leftChar = allChars[left];

                if (!_validChars.Contains(leftChar))
                    return 0;

                var rightChar = (maxLeft - 1 == left) ? leftChar : allChars[right];

                // are we in a subtraction scenario?
                var pair = left == right ? string.Empty : $"{leftChar}{rightChar}";

                if (_gotchyas.TryGetValue(pair, out var gotchya))
                {
                    sum += gotchya;
                    left = right + 1;
                    right = left + 1;
                }
                else
                {
                    sum += _romanValues[leftChar];
                    left++;
                    right++;
                }
            }

            return sum;
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class RomanNumeralConverterBenchmarks()
    {
        //private static readonly RomanNumeralConverter _sut = new();
        private const int RepetitionCount = 100_000;

        [Benchmark(Baseline = true)]
        public void ToRoman()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRoman("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanAsSpan()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRomanAsSpan("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanLinear()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRomanLinear("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanExtensionLinear()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                "MCMXCIV".ToRomanExtensionLinear();
            }
        }

        [Benchmark]
        public void ToRomanLinearAlt()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRomanLinearAlt("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanLinearAllSpansSubtraction()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRomanLinearAllSpansSubtraction("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanLastShot()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRomanLastShot("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanNaiveBruteForce()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRoman_NaiveBruteForce("MCMXCIV");
            }
        }

        [Benchmark]
        public void ToRomanNaiveBruteForceAlt()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                RomanNumeralConverter.ToRoman_NaiveBruteForce_Alt("MCMXCIV");
            }
        }
    }
}
