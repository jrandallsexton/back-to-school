
using BackToSchool.CSharp.HigherOrderFunctions;

using FluentAssertions;

using System.Collections.Generic;

using Xunit;

namespace BackToSchool.CSharp.Tests.HigherOrderFunctions
{
    public class HofPlaygroundTests
    {
        [Fact]
        public void TransformTest()
        {
            // arrange
            var oldList = new List<int> { 100, 200, 300, 400, 500 };

            static int DivideBy2(int num) => num / 2;

            // act
            //var result = new HofPlayground().Transform(oldList, i => i / 2);
            var result = new HofPlayground().Transform(oldList, DivideBy2);

            // assert
            result[0].Should().Be(oldList[0] / 2);
        }
    }
}
