using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Sorting
{
    public class BubbleSort
    {
        public void Sort(int[] numbers)
        {
            if (numbers.Length is 0 or 1)
                return;

            var left = numbers[0];
            var right = numbers[1];
            var swapCount = numbers.Length;

            while (swapCount > 0)
            {
                swapCount = 0;

            }
        }
    }
}
