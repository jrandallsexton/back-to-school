using System.Collections.Generic;
using System.Linq;

namespace BackToSchool.CSharp.Algorithms.TwoPointers
{
    public class MinWindowSubstring
    {
        public static string Find(string[] strArr)
        {

            var first = strArr[0];
            var second = strArr[1];

            // look for exact match?
            if (first.Contains(second))
            {
                return second;
            }

            var bestLength = first.Length;
            var bestWindowIndexes = new KeyValuePair<int, int>();

            var left = 0;
            var right = 1;

            while (left < first.Length)
            {
                var window = first.Substring(left, right - left);
                if (WindowContainsAllChars(window, second))
                {
                    // is it shorter than our best length?
                    if (window.Length < bestLength)
                    {
                        bestWindowIndexes = new KeyValuePair<int, int>(left, right);
                        bestLength = right - left;
                    }

                    left++;
                }
                else
                {
                    // advance right if we can
                    if (right < first.Length)
                    {
                        right++;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return first.Substring(bestWindowIndexes.Key, bestLength);

        }

        private static bool WindowContainsAllChars(string window, string chars)
        {
            // need to track occurence counts also!
            var windowChars = window.ToCharArray().ToList();

            foreach (var ch in chars)
            {
                if (!windowChars.Contains(ch))
                {
                    return false;
                }
                else
                {
                    // remove it
                    windowChars.Remove(ch);
                }
            }

            return true;
        }
    }
}
