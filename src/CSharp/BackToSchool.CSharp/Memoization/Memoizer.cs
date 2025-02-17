using System;
using System.Collections.Generic;

namespace BackToSchool.CSharp.Memoization
{
    public static class Memoizer
    {
        public static Func<Arg, Ret> Memoize<Arg, Ret>(this Func<Arg, Ret> functor)
        {
            var memo_table = new Dictionary<Arg, Ret>();

            return (arg0) =>
            {
                Ret func_return_value;

                if (!memo_table.TryGetValue(arg0, out func_return_value))
                {
                    func_return_value = functor(arg0);
                    memo_table.Add(arg0, func_return_value);
                }

                return func_return_value;
            };
        }
    }
}
