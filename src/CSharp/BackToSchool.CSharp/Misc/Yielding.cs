
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using System;
using System.Collections.Generic;

namespace BackToSchool.CSharp.Misc
{
    /// <summary>
    /// https://www.youtube.com/watch?v=uv74SZ5MX5Q
    /// </summary>
    public class Yielding
    {
        public static IEnumerable<int> GetEvenNumbersNoYield(int max)
        {
            var numbers = new List<int>();

            for (var i=0; i < max; i++)
            {
                if (i % 2 == 0)
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }

        public static IEnumerable<int> GetEvenNumbers(int max)
        {
            for (var i = 0; i < max; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class YieldingBenchmarks()
    {
        private const int Max = 100;

        [Benchmark(Baseline = true)]
#pragma warning disable CA1822 // Mark members as static
        public void NoYield()
#pragma warning restore CA1822 // Mark members as static
        {
            var numbers = Yielding.GetEvenNumbersNoYield(Max);

            var final = 0;
            foreach (var number in numbers)
            {
                final += number;
            }
        }

        [Benchmark]
#pragma warning disable CA1822 // Mark members as static
        public void Yield()
#pragma warning restore CA1822 // Mark members as static
        {
            var numbers = Yielding.GetEvenNumbers(Max);

            var final = 0;
            foreach (var number in numbers)
            {
                final += number;
            }
        }
    }
}