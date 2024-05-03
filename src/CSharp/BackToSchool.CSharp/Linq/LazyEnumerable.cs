using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using System.Collections.Generic;
using System.Linq;

namespace BackToSchool.CSharp.Linq
{
    /// <summary>
    /// From Zoran's video:
    /// https://www.youtube.com/watch?v=P-0svGXEeNM&t=5s
    /// </summary>
    public class LazyEnumerable
    {
        public void ViaList()
        {
            var collection = new List<byte[]>();

            for (int i = 0; i < 8 * 1024 + 1; i++)
            {
                collection.Add(new byte[1024]);
            }

            foreach (var item in collection)
            {
                // do something
            }
        }

        public void ViaLazyEnumerable()
        {
            IEnumerable<byte[]> lazy = Enumerable
                .Range(0, 8 * 1024 + 1)
                .Select(_ => new byte[1024]);

            foreach (var item in lazy)
            {
                // do something
            }
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LazyEnumerableBenchmarks
    {
        private static readonly LazyEnumerable LazyEnumerable = new LazyEnumerable();

        [Benchmark(Baseline = true)]
        public void ViaList()
        {
            LazyEnumerable.ViaList();
        }

        [Benchmark]
        public void ViaLazyEnumerable()
        {
            LazyEnumerable.ViaLazyEnumerable();
        }
    }
}
