using System;

namespace BackToSchool.CSharp.Misc.Leet
{
    public class _28_IdxOfFirstOccurence
    {
        public int StrStr(string haystack, string needle)
        {
            var sourceSpan = haystack.AsSpan();
            var targetSpan = needle.AsSpan();

            if (targetSpan.Length > sourceSpan.Length)
                return -1;

            var left = 0;
            var right = 0;
            
            var needleLength = needle.Length;

            var maxLeft = sourceSpan.Length - needle.Length;

            while (left <= maxLeft)
            {
                var innerLeft = left;

                while (right <= needleLength)
                {
                    if (right == needleLength)
                    {
                        return left;
                    }

                    if (sourceSpan[innerLeft] == targetSpan[right])
                    {
                        if (needleLength == 1)
                        {
                            return left;
                        }
                        right++;
                    }
                    else
                    {
                        break;
                    }
                    innerLeft++;
                }

                left++;
                right = 0;
            }

            return -1;
        }
    }
}
