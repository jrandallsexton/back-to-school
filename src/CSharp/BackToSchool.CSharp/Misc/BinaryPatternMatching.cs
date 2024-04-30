using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackToSchool.CSharp.Misc
{
    public sealed class BinaryPatternMatching
    {
        private readonly IOutputHelper _outputHelper;

        public BinaryPatternMatching(IOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public static int MatchSubmitted(string pattern, string source)
        {
            // Given
            // pattern [0,1]
            // source [a, b, c, ... z]

            // Agreed-Upon
            // vowels [a,e,i,o,u,y]
            var vowels = new List<string>() {
                "a",
                "e",
                "i",
                "o",
                "u",
                "y"
            };

            // Still trying to decipher what constitues a "match"
            // max number of matches?

            var matchCount = 0;

            // oh man, there's probably a super elegant way of doing this via RegEx ... but that would require some Googling
            // suppose I'll have to just do it iteratively

            var patternLength = pattern.Length;
            var sourceLength = source.Length;

            if (sourceLength < patternLength)
                return 0;

            // convert the source into 0/1
            var sb = new StringBuilder();
            var sourceChars = source.ToCharArray();
            var patternChars = pattern.ToCharArray();

            foreach (var sourceChar in sourceChars)
            {
                var zeroOneValue = vowels.Contains(sourceChar.ToString()) ? 0 : 1;
                sb.Append(zeroOneValue.ToString());
            }
            var convertedString = sb.ToString();
            //Console.WriteLine($"Coverted string from: {source} to {convertedString}");

            // hmm? perhaps iterate through 'source' and create substrings of patternLenght?
            // not sure how the BigO is going to look.  let's see

            var idx = 0;
            while (idx <= (sourceLength - patternLength))
            {
                // ugh.  have to determine how many characters in the string match
                // NOT just if the strings are equal
                //if (convertedString.Substring(idx, patternLength) ==
                // doing this iteratively just isn't good

                var substring = convertedString.Substring(idx, patternLength);
                //Console.WriteLine($"Iteration {idx} substring: {substring}");

                // already looking a n^2 here if i loop through the pattern string
                var tempMatchCount = 0;
                for (var x = 0; x < patternLength; x++)
                {
                    var patternChar = patternChars[x];
                    var sourceChar = substring[x];
                    //Console.WriteLine($"\tCompare: {patternChar} : {sourceChar}");
                    if (patternChar == sourceChar)
                        tempMatchCount++;
                }

                //Console.WriteLine($"\tMatchcount: {tempMatchCount}");

                if (tempMatchCount == patternLength)
                    matchCount++;

                idx++;
            }

            return matchCount;
        }

        public static int MatchReview(string pattern, string source)
        {
            var vowels = new List<char>() {
                'a',
                'e',
                'i',
                'o',
                'u',
                'y'
            };

            var matchCount = 0;

            var patternLength = pattern.Length;
            var sourceLength = source.Length;

            if (sourceLength < patternLength)
                return 0;

            // convert the source into 0/1
            var sb = new StringBuilder();
            var sourceChars = source.ToCharArray();

            for (var x = 0; x < sourceChars.Length; x++)
            {
                var binaryValue = vowels.Contains(sourceChars[x]) ? 0 : 1;
                sb.Append(binaryValue);
            }

            var convertedString = sb.ToString();
            //_outputHelper.WriteLine($"Converted string from: {source} to {convertedString}");

            var idx = 0;
            while (idx <= (sourceLength - patternLength))
            {
                var substring = convertedString.Substring(idx, patternLength);
                //_outputHelper.WriteLine($"Iteration {idx} substring: {substring}");

                if (pattern == substring)
                {
                    //_outputHelper.WriteLine("\tMatch found");
                    matchCount++;
                }

                idx++;
            }

            return matchCount;
        }

        public static int MatchReviewAlt(string pattern, string source)
        {
            var vowels = new List<char>() {
                'a',
                'e',
                'i',
                'o',
                'u',
                'y'
            };

            var patternLength = pattern.Length;
            var sourceLength = source.Length;

            if (sourceLength < patternLength)
                return 0;

            // convert the source into binary
            var sb = new StringBuilder();

            foreach (var t in source.ToCharArray())
            {
                var binaryValue = vowels.Contains(t) ? 0 : 1;
                sb.Append(binaryValue);
            }
            
            var convertedString = sb.ToString();

            var matchCount = 0;
            var zMax = sourceLength - patternLength;

            for (var z = 0; z <= zMax; z++)
            {
                var tmp = convertedString.AsSpan(z, patternLength);
                if (tmp.Equals(pattern, StringComparison.Ordinal))
                {
                    matchCount++;
                }
            }

            return matchCount;
        }

        public static int MatchReviewAlt2(string pattern, string source)
        {
            var vowels = new List<char>() {
                'a',
                'e',
                'i',
                'o',
                'u',
                'y'
            };

            var patternLength = pattern.Length;
            var sourceLength = source.Length;

            if (sourceLength < patternLength)
                return 0;

            // convert the source into binary
            var sb = new StringBuilder();

            // there MUST be a better way
            // spans, conversion, comparison in a single swoop
            // but even if i do that, i take the BigO from 2n to just n
            // does it really matter?
            var sourceSpan = source.AsSpan();
            foreach (var t in source.ToCharArray())
            {
                var binaryValue = vowels.Contains(t) ? 0 : 1;
                sb.Append(binaryValue);
            }

            var convertedString = sb.ToString();

            var matchCount = 0;
            var zMax = sourceLength - patternLength;

            for (var z = 0; z <= zMax; z++)
            {
                var tmp = convertedString.AsSpan(z, patternLength);
                if (tmp.Equals(pattern, StringComparison.Ordinal))
                {
                    matchCount++;
                }
            }

            return matchCount;
        }

        public static int MatchOptimized(string pattern, string source)
        {
            var binaryValues = new Dictionary<char, int>()
            {
                { 'a', 0 }, 
                { 'b', 1 },
                { 'c', 1 },
                { 'd', 1 },
                { 'e', 0 },
                { 'f', 1 },
                { 'g', 1 },
                { 'h', 1 },
                { 'i', 0 },
                { 'j', 1 },
                { 'k', 1 },
                { 'l', 1 },
                { 'm', 1 },
                { 'n', 1 },
                { 'o', 0 },
                { 'p', 1 },
                { 'q', 1 },
                { 'r', 1 },
                { 's', 1 },
                { 't', 1 },
                { 'u', 0 },
                { 'v', 1 },
                { 'w', 1 },
                { 'x', 1 },
                { 'y', 0 },
                { 'z', 1 }
            };

            var patternLength = pattern.Length;
            var sourceLength = source.Length;

            if (sourceLength < patternLength)
                return 0;

            // convert the source into 0/1
            // *** We can also build our substrings during this!
            // could also use memoization for binary values?
            var sourceChars = source.ToCharArray();
            var substrings = new List<string>();

            for (var x = 0; x <= sourceLength - patternLength; x++)
            {
                var substringChars = sourceChars[x..(x + patternLength)];
                var substringBinary = new int[patternLength];

                for (var z = 0; z < substringChars.Length; z++)
                {
                    substringBinary[z] = binaryValues[substringChars[z]];
                }

                var substring = string.Join(string.Empty, substringBinary);
                //_outputHelper.WriteLine($"Substring: {substring}");
                substrings.Add(substring);

            }

            return substrings.Where(x => x == pattern).ToList().Count;
        }
    }
}
