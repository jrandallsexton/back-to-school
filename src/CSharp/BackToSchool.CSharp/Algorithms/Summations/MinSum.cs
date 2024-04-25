using System;

namespace BackToSchool.CSharp.Algorithms.Summations
{
    public class MinSum
    {
        /// <summary>
        /// https://app.codesignal.com/practice-question/question/bugfix?context=otherTypes
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Solution(int[] a)
        {

            int indexOfMinimum = -1;
            int minimalSum = int.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    sum += Math.Abs(a[j] - a[i]);
                }
                if (sum < minimalSum)
                {
                    minimalSum = sum;
                    indexOfMinimum = i;
                }
            }

            return a[indexOfMinimum];
        }
    }
}
