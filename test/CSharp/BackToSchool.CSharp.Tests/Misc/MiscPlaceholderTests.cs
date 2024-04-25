using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToSchool.CSharp.Misc;
using FluentAssertions;
using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class MiscPlaceholderTests
    {
        [Theory]
        //[InlineData("2", "2.0", 0)]
        //[InlineData("2", "2.0.0", 0)]
        //[InlineData("2", "2.0.0.0.1", -1)]
        [InlineData("2.10.0.1", "2.1.0.10", 1)]

        public void MiscPlaceholderTest_DoesFoo(string v1, string v2, int expected)
        {
            // arrange

            var sut = new MiscPlaceholder();

            // act
            var result = sut.VersionCompare(v1, v2);

            // assert
            result.Should().Be(expected);
        }
    }
}
