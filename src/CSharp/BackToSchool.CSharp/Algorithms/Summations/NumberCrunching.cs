
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using System.Collections.Generic;
using System.Linq;

namespace BackToSchool.CSharp.Algorithms.Summations
{
    /// <summary>
    /// From Zoran's video:
    /// https://www.youtube.com/watch?v=mdqNyfCxrv4
    /// Takeaway?  For significantly large N, .sum() is faster
    /// as the framework applies some type of underlying logic
    /// That "n" seems to appear > 1K and especially > 10K
    /// Methods arranged in order of performance (low to high) fpr N=10,000
    /// </summary>
    public class NumberCrunching
    {
        public int ListSum(List<int> data)
        {
            return data.Sum();
        }

        public int ArraySum(int[] data)
        {
            return data.Sum();
        }

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
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class NumberCrunchingBenchmarks()
    {
        private static readonly NumberCrunching sut = new NumberCrunching();
        private const int RepetitionCount = 100;
        private const int DataLength = 10000;

        [Benchmark(Baseline = true)]
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
        public void ArrayForSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToArray();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ArrayForSum(numbers);
            }
        }

        [Benchmark]
        public void ArrayForeachSumBenchmark()
        {
            var numbers = Enumerable.Range(0, DataLength).ToArray();
            for (var i = 0; i < RepetitionCount; i++)
            {
                sut.ArrayForeachSum(numbers);
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
