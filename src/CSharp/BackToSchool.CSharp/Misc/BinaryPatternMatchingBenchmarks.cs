using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BackToSchool.CSharp.Misc
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BinaryPatternMatchingBenchmarks
    {
        private static readonly BinaryPatternMatching sut = new(null);
        private const int RepetitionCount = 10;
        private const string Pattern = "010";
        private const string Source = "amazinglysuperlongfreakingstringamazinglysuperlongfreakingstring";

        [Benchmark(Baseline = true)]
        public void Submitted()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                BinaryPatternMatching.MatchSubmitted(Pattern, Source);
            }
        }

        [Benchmark]
        public void Reviewed()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                BinaryPatternMatching.MatchReview(Pattern, Source);
            }
        }

        [Benchmark]
        public void ReviewedAlt()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                BinaryPatternMatching.MatchReviewAlt(Pattern, Source);
            }
        }

        [Benchmark]
        public void ReviewedAlt2()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                BinaryPatternMatching.MatchReviewAlt2(Pattern, Source);
            }
        }

        [Benchmark]
        public void Optimized()
        {
            for (var i = 0; i < RepetitionCount; i++)
            {
                BinaryPatternMatching.MatchOptimized(Pattern, Source);
            }
        }
    }
}
