using BackToSchool.CSharp.Algorithms.Summations;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Algorithms.Summations
{
    public class MinSumTests
    {
        [Theory]
        [InlineData(new[] {2,4,7}, 4)]
        public void MinSumTestCases(int[] a, int expectedMin)
        {
            // arrange
            var sut = new MinSum();

            // act
            var result = sut.Solution(a);

            // assert
            result.Should().Be(expectedMin);
        }
    }
}
