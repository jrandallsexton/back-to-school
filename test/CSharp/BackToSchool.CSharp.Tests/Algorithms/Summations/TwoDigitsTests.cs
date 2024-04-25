using BackToSchool.CSharp.Algorithms.Summations;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Algorithms.Summations
{
    public class TwoDigitsTests
    {
        [Theory]
        [InlineData(29,11)]
        public void TwoDigitsTestCases(int n, int expectedSum)
        {
            // arrange
            var sut = new TwoDigits();

            // act
            var result = sut.Solution(n);

            // assert
            result.Should().Be(expectedSum);
        }
    }
}
