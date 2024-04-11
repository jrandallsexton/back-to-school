using System.Collections.Generic;
using System.Linq;

namespace BackToSchool.CSharp.Linq
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct?view=net-8.0
    /// </summary>
    public class Distinct
    {
        public List<int> GetDistinctValues(IList<int> values)
        {
            return values.Distinct().ToList();
        }
    }
}
