using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Nullables
{
    /// <summary>
    /// https://www.youtube.com/watch?v=tMKcLwlhoEs
    /// </summary>
    public class NullablePlayground
    {
        public void Foo()
        {

#nullable disable

            string x = null;
            int xx;

#nullable enable

            string z = null;
            int? zz = null;

#nullable disable

        }
    }
}
