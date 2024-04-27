

using BackToSchool.CSharp.Misc;

using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class AsciiArtTests
    {
        [Theory]
        [InlineData(1, "*")]
        public void AsciiArtTest(int n, string expected)
        {
            // arrange
            var sut = new AsciiArt();

            // act
            var result = sut.Draw(n);

            // assert
            result.Should().Be(expected);
        }
    }
}
