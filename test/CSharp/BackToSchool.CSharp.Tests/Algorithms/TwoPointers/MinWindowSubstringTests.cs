using BackToSchool.CSharp.Algorithms.TwoPointers;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Algorithms.TwoPointers
{
    public class MinWindowSubstringTests
    {
        [Fact]
        public void MinWindowTest()
        {
            // arrange
            //var input = new string[] { "azjpskfzts", "sz" };
            var input = new string[] { "ahffaksfajeeubsne", "jefaa" };

            // act
            var result = MinWindowSubstring.Find(input);

            // assert
            //result.Should().Be("zts");
            result.Should().Be("aksfaje");
        }
    }
}
