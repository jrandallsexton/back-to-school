using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Params
{
    public class ParamsPlayground
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int AddByRef(ref int a, ref int b)
        {
            (a, b) = (b, a);
            return a + b;
        }

        public int Add(in ParamsPlaygroundCommand command)
        {
            return command.A + command.B;
        }

        public struct ParamsPlaygroundCommand
        {
            public int A { get; set; }

            public int B { get; set; }
        }
    }
}
