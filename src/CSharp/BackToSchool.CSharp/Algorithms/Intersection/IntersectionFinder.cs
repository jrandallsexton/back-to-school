using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Algorithms.Intersection
{
    public class IntersectionFinder
    {
        public static string FindIntersection(string[] strArr)
        {
            var first = strArr[0].Replace(" ", string.Empty);
            var second = strArr[1].Replace(" ", string.Empty);

            var tmp0 = first.Split(',');
            var tmp1 = second.Split(',');

            var foo = tmp0.Intersect(tmp1).ToList();

            if (foo.Count == 0)
                return "false";

            var result = new StringBuilder();
            foreach (var x in foo)
            {
                result.AppendFormat("{0},", x);
            }

            return result.ToString().TrimEnd(',');

        }
    }
}
