using BackToSchool.CSharp.Algorithms.Intersection;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Algorithms.Intersection
{
    public class IntersectionFinderTests
    {
        [Fact]
        public void Foo()
        {
            // arrange
            //var input = new string[] { "1, 3, 4, 7, 13", "1, 2, 4, 13, 15" };
            //var input = new string[] { "1, 5, 6, 7, 10, 11, 12", "5, 6, 8, 11, 17" };
            var input = new string[] { "1, 2, 3, 4, 5", "6, 7, 8, 9, 10" };

            // act
            var result = IntersectionFinder.FindIntersection(input);

            // assert
            //result.Should().Be("1,4,13");
            //result.Should().Be("5,6,11");
            result.Should().Be("false");
        }
    }
}
