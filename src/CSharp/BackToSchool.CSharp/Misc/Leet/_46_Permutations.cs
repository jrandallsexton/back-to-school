using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Misc.Leet
{
    public class _46_Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var values = new List<IList<int>>();

            if (nums is null)
                return values;

            var numSpan = nums.AsSpan();

            var outerIndex = 0;

            while (outerIndex < numSpan.Length)
            {
                // will be creating nums.Length permutations
                var newArray = new int[nums.Length];
                newArray[0] = numSpan[outerIndex];
                
                var innerIndex = outerIndex + 1;
                var innerLeft = innerIndex;

                while (innerIndex < numSpan.Length)
                {
                    if (innerIndex != outerIndex)
                    {
                        var swapped = SwapTwo(numSpan[innerIndex], numSpan[innerLeft]);
                        var temp = swapped[0][0];
                        newArray[0] = numSpan[outerIndex];
                    }

                    innerIndex++;
                }

                values.Add(newArray);

                outerIndex++;
            }

            return values;
        }

        private static List<int[]> SwapTwo(int a, int b)
        {
            return
            [
                new[] { a, b },
                new[] { b, a }
            ];
        }
    }
}
