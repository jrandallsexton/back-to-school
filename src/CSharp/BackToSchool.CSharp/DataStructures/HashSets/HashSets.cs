using System.Collections.Generic;

namespace BackToSchool.CSharp.DataStructures.HashSets
{
    public class HashSets
    {
        public HashSet<int> OddEvensMerge(int n)
        {
            var evens = new HashSet<int>();
            var odds = new HashSet<int>();

            for (var i =0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evens.Add(i);
                }
                else
                {
                    odds.Add(i);
                }
            }

            evens.UnionWith(odds);

            return evens;
        }
    }
}
