using BackToSchool.CSharp.Misc;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Algorithms.Summations
{
    /// <summary>
    /// From Zoran's video:
    /// https://www.youtube.com/watch?v=mdqNyfCxrv4
    /// </summary>
    public class NumberCrunching
    {
        public int ArrayForSum(int[] data)
        {
            var sum = 0;
            for (var i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            return sum;
        }

        public int ArrayForeachSum(int[] data)
        {
            var sum = 0;
            foreach (var x in data)
            {
                sum += x;
            }
            return sum;
        }

        public int ArraySum(int[] data)
        {
            return data.Sum();
        }

        public int ListForSum(List<int> data)
        {
            var sum = 0;
            for (var i = 0; i < data.Count; i++)
            {
                sum += data[i];
            }
            return sum;
        }

        public int ListForeachSum(List<int> data)
        {
            var sum = 0;
            foreach (var x in data)
            {
                sum += x;
            }
            return sum;
        }

        public int ListSum(List<int> data)
        {
            return data.Sum();
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class NumberCrunchingBenchmarks()
    {
        private static readonly NumberCrunching sut = new NumberCrunching();
        private const int RepetitionCount = 10;
        private const int DataLength = 100;

        [Benchmark]
        public void ArrayForeachSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToArray();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ArrayForeachSum(numbers);
            }
        }

        [Benchmark(Baseline = true)]
        public void ArrayForSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToArray();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ArrayForSum(numbers);
            }
        }

        [Benchmark]
        public void ArraySumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToArray();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ArraySum(numbers);
            }
        }

        [Benchmark]
        public void ListSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToList();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ListSum(numbers);
            }
        }

        [Benchmark]
        public void ListForSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToList();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ListForSum(numbers);
            }
        }

        [Benchmark]
        public void ListForeachSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToList();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ListForeachSum(numbers);
            }
        }
    }
}
