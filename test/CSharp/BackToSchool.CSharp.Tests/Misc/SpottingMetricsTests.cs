using BackToSchool.CSharp.Misc;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class SpottingMetricsTests
    {
        [Fact]
        public void GetSpottingMetric_StripZeros()
        {
            // arrange && act
            var result = SpottingMetrics.GetSpottingMetric_StripZeros([1, 3, 0, 1, 5, 0, 0, 1, 0]);

            // assert
            result.Should().BeApproximately(1.666F, 0.1F);
        }

        [Fact]
        public void GetSpottingMetric_TwoPointers()
        {
            // arrange && act
            var result = SpottingMetrics.GetSpottingMetric_TwoPointers([1, 3, 0, 1, 5, 0, 0, 1, 0], 3);

            // assert
            result.Should().BeApproximately(1.666F, 0.1F);
        }

        [Fact]
        public void GetSpottingMetric_TwoPointers_Alt()
        {
            // arrange && act
            var result = SpottingMetrics.GetSpottingMetric_TwoPointers_Alt([1, 3, 0, 1, 5, 0, 0, 1, 0], 3);

            // assert
            result.Should().BeApproximately(1.666F, 0.1F);
        }
    }
}
