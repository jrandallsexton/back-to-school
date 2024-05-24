using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Characteristics;
using BenchmarkDotNet.Order;
using DotNext;

using LanguageExt.ClassInstances.Pred;

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
        private readonly Dictionary<char, char[]> _numberValues =
            new()
            {
                { '1', [] },
                { '2', ['a', 'b', 'c'] },
                { '3', ['d', 'e', 'f'] },
                { '4', ['g', 'h', 'i'] },
                { '5', ['j', 'k', 'l'] },
                { '6', ['m', 'n', 'o'] },
                { '7', ['p', 'q', 'r', 's'] },
                { '8', ['t', 'u', 'v'] },
                { '9', ['w', 'x', 'y', 'z'] }
            };

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> combinations = [];

            var digitLength = digits.Length;

            if (digitLength is <= 0 or > 4)
            {
                return combinations;
            }

            AddCombination("", digits, 0, combinations);

            return combinations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentOutputString">holds what the output will be (eventually)</param>
        /// <param name="digits"></param>
        /// <param name="index"></param>
        /// <param name="list">container for <see cref="currentOutputString"/> once completed</param>
        public void AddCombination(string currentOutputString, string digits, int index, IList<string> list)
        {
            if (index >= digits.Length)
            {
                list.Add(currentOutputString);
            }
            else
            {
                var digitChar = digits[index];

                if (!char.IsNumber(digitChar) || char.IsWhiteSpace(digitChar) || !char.IsBetween(digitChar, '2', '9'))
                    return;

                var digitMap = _numberValues[digitChar];

                for (var i = 0; i < digitMap.Length; i++)
                {
                    var newCurr = currentOutputString + digitMap[i]; ;

                    AddCombination(newCurr, digits, index + 1, list);
                }
            }
        }

        public IList<string> LetterCombinationsBacktrack(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>();
            }

            // Map of digit to corresponding letters
            var phoneMap = new Dictionary<char, string>() {
                { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" },
                { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
            };

            var results = new List<string>();
            Backtrack(0, [], digits, results, phoneMap);
            return results;
        }

        ///// <summary>
        ///// So recursion is nice and all, but given the following constraint: 0 <= digits.length <= 4 ...
        ///// We could simply make this thing iterative and likely more performant
        ///// </summary>
        ///// <param name="digits"></param>
        ///// <returns></returns>
        //public IList<string> LetterCombinationsBruteForce(string digits)
        //{
        //    // remove all whitespace chars
        //    var digitSpan = digits.ToArray();

        //    var values = new List<string>();

        //    var letterArrays = new Dictionary<char, char[]>();

        //    // get array of letters for each character
        //    foreach (var digit in digitSpan)
        //    {
        //        if (!char.IsNumber(digit) || char.IsWhiteSpace(digit) || !char.IsBetween(digit, '2', '9'))
        //            return new List<string>();

        //        if (!letterArrays.ContainsKey(digit))
        //            letterArrays.Add(digit, _numberValues[digit]);
        //    }

        //    if (letterArrays.Count == 0)
        //        return values;

        //    var keys = letterArrays.Keys.ToArray();

        //    if (letterArrays.Count > 1)
        //    {
        //        for (var i = 0; i < letterArrays.Count - 1; i++)
        //        {
        //            var left = letterArrays[keys[i]];
        //            var right = letterArrays[keys[i + 1]];

        //            foreach (var leftChar in left)
        //            {
        //                foreach (var rightChar in right)
        //                {
        //                    values.Add($"{leftChar}{rightChar}");
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        values.AddRange(letterArrays[keys[0]]);
        //    }

        //    // process the arrays to create combinations


        //    return values;
        //}

        private void Backtrack(int index, List<char> current, string digits, List<string> results, Dictionary<char, string> phoneMap)
        {
            if (index == digits.Length)
            {
                results.Add(new string(current.ToArray()));
                return;
            }

            string possibleLetters = phoneMap[digits[index]];
            foreach (var letter in possibleLetters)
            {
                current.Add(letter);
                Backtrack(index + 1, current, digits, results, phoneMap);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class PhoneNumberWordsBenchmarks()
    {
        private readonly PhoneNumberWords _sut = new PhoneNumberWords();
        private const int RepetitionCount = 10_000_000;
        private const string PhoneNumber = "239";

        [Benchmark(Baseline = true)]
        public void LetterCombinations()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                _sut.LetterCombinations(PhoneNumber);
            }
        }

        [Benchmark]
        public void LetterCombinationsBacktrack()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                _sut.LetterCombinationsBacktrack(PhoneNumber);
            }
        }
    }
}
