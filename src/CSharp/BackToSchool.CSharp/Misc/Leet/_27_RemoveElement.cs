
namespace BackToSchool.CSharp.Misc.Leet
{
    /// <summary>
    /// https://leetcode.com/problems/remove-element/description/
    /// </summary>
    public class _27_RemoveElement
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1 && nums[0] == val)
            {
                return 0;
            }

            var nonMatchCount = 0;

            var left = 0;
            var right = nums.Length - 1;
            var max = nums.Length - 2;

            while (left <= max && left < right)
            {
                var leftValue = nums[left];
                var rightValue = nums[right];

                if (leftValue == val)
                {
                    // swap left and right
                    nums[left] = rightValue;
                    nums[right] = leftValue;
                    right--;
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
