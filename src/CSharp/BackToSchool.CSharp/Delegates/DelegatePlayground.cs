using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Delegates
{
    /// <summary>
    /// https://www.youtube.com/watch?v=ZGHBGFLuvmg
    /// </summary>
    public class DelegatePlayground
    {

        private delegate string TestDelegate(string name);

        private string TestMethod(string name)
        {
            return $"From delegate invocation: {name}";
        }

        public string TestMethodViaDelegate(string name)
        {
            TestDelegate d1 = TestMethod;
            return d1.Invoke(name);
        }
    }
}
