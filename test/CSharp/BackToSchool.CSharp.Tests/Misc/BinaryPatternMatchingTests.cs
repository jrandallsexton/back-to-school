using BackToSchool.CSharp.Misc;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class BinaryPatternMatchingTests
    {
        private Logger _logger;

        public BinaryPatternMatchingTests(ITestOutputHelper output)
        {
            _logger = new Logger(output);
        }

        [Fact]
        public void MatchSubmittedTest()
        {
            // arrange
            var sut = new BinaryPatternMatching(_logger);

            // act
            var result = BinaryPatternMatching.MatchSubmitted("010", "amazing");

            // assert
            result.Should().Be(2);
        }

        [Fact]
        public void MatchReviewTest()
        {
            // arrange
            var sut = new BinaryPatternMatching(_logger);

            // act
            var result = BinaryPatternMatching.MatchReview("010", "amazing");

            // assert
            result.Should().Be(2);
        }

        [Fact]
        public void MatchReviewAltTest()
        {
            // arrange
            var sut = new BinaryPatternMatching(_logger);

            // act
            var result = BinaryPatternMatching.MatchReviewAlt("010", "amazing");

            // assert
            result.Should().Be(2);
        }

        [Fact]
        public void MatchOptimizedTest()
        {
            // arrange
            var sut = new BinaryPatternMatching(_logger);

            // act
            var result = BinaryPatternMatching.MatchOptimized("010", "amazing");

            // assert
            result.Should().Be(2);
        }
    }

    public class Logger : IOutputHelper
    {
        private readonly ITestOutputHelper _outputHelper;

        public Logger(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public void WriteLine(string message)
        {
            _outputHelper.WriteLine(message);
        }

        public void WriteLine(string format, params object[] args)
        {
            _outputHelper.WriteLine(format, args);
        }
    }
}
