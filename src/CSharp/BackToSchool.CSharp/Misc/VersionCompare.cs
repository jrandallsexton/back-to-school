using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Misc
{
    public class VersionCompare
    {
        public int Compare(string version1, string version2)
        {
            var returnValue = 0;

            var v1Chars = version1.Split(".");
            var v2Chars = version2.Split(".");

            var v1Final = string.Empty;
            var v2Final = string.Empty;

            var maxLength = v1Chars.Length > v2Chars.Length ? v1Chars.Length : v2Chars.Length;

            for (var i = 0; i < maxLength; i++)
            {
                var v1 = i < v1Chars.Length ? v1Chars[i] : string.Empty;
                var v2 = i < v2Chars.Length ? v2Chars[i] : string.Empty;

                Console.WriteLine($"v1: {v1}");
                Console.WriteLine($"v2: {v2}");

                var v1Length = v1.Length;
                var v2Length = v2.Length;

                if (v1 == v2)
                {
                    if (i != 0)
                    {
                        v1 = v1.Insert(0, ".");
                        v2 = v2.Insert(0, ".");
                    }
                    v1Final += v1;
                    v2Final += v2;
                    continue;
                }
                else if (v1Length < v2Length)
                {
                    v1 = v1.PadLeft(v2Length, '0');
                    v1 = v1.Insert(0, ".");
                    v2 = v2.Insert(0, ".");
                    Console.WriteLine($"pad v1: {v1}");
                }
                else
                {
                    v2 = v2.PadLeft(v1Length, '0');
                    v2 = v2.Insert(0, ".");
                    v1 = v1.Insert(0, ".");
                    Console.WriteLine($"pad v2: {v2}");
                }

                v1Final += v1;
                v2Final += v2;
            }

            v1Final = v1Final.TrimEnd('.');
            v2Final = v2Final.TrimEnd('.');

            if (v1Final == v2Final)
            {
                return 0;
            }

            return string.Compare(v1Final, v2Final, StringComparison.Ordinal);
        }
    }
}
