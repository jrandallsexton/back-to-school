using System.Collections.Generic;
using System.Linq;

namespace BackToSchool.CSharp.Linq
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=net-8.0
    /// </summary>
    public class Aggregates
    {
        public string GetLongestEntry(IList<string> entries)
        {
            var longest = entries.Aggregate(string.Empty,
                (longest, next) =>
                    next.ToString().Length > longest.Length ? next : longest,
            fruit => fruit.ToUpper());

            return longest;
        }

        public int SumEvenNumbers(IList<int> numbers)
        {
            var numEven = numbers.Aggregate(0, (total, next) =>
                next % 2 == 0 ? total + 1 : total);

            return numEven;
        }
    }
}