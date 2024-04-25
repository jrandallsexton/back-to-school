using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Algorithms.Summations
{
    /// <summary>
    /// You are given a two-digit integer n. Return the sum of its digits.
    /// Example:
    /// For n = 29, the output should be solution(n) = 11.
    /// </summary>
    public class TwoDigits
    {
        public int Solution(int n)
        {
            var numbers = n.ToString().ToCharArray();
            return int.Parse(numbers[0].ToString()) + int.Parse(numbers[1].ToString());
        }
    }
}
