
using System;
using System.Collections.Generic;

namespace BackToSchool.CSharp.HigherOrderFunctions
{
    public class HofPlayground
    {
        public List<TOutput> Transform<TInput, TOutput>(
            List<TInput> list,
            Func<TInput, TOutput> transformer)
        {
            var newList = new List<TOutput>();

            foreach (var input in list)
            {
                var newItem = transformer(input);
                newList.Add(newItem);
            }

            return newList;
        }
    }
}