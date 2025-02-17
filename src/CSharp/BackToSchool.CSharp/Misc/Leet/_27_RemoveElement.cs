
namespace BackToSchool.CSharp.Misc.Leet
{
    /// <summary>
    /// https://leetcode.com/problems/remove-element/description/
    /// </summary>
    public class _27_RemoveElement
    {
        public int RemoveElement(int[] nums, int val)
        {
            switch (nums.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return nums[0] == val ? 0 : 1;
            }

            var nonMatchCount = 0;

            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var leftValue = nums[left];

                if (leftValue == val)
                {
                    // can we move it one place to the right?
                    var tmpRight = left + 1;
                    while (tmpRight < nums.Length)
                    {
                        var tmpRightVal = nums[tmpRight];
                        if (tmpRightVal == val)
                        {
                            tmpRight++;
                        }
                        else
                        {
                            // swap
                            nums[left] = tmpRightVal;
                            nums[tmpRight] = leftValue;
                            nonMatchCount++;
                            break;
                        }
                    }
                    left++;
                }
                else
                {
                    left++;
                    nonMatchCount++;
                }
            }

            return nonMatchCount;
        }
    }
}
