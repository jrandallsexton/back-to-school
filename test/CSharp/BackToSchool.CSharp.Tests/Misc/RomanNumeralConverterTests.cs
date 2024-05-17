
using BackToSchool.CSharp.Misc;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class RomanNumeralConverterTests
    {
        RomanNumeralConverter _sut = new RomanNumeralConverter();

        [Theory]
        [InlineData("III", 3)]
        //[InlineData("", 0)]
        //[InlineData("MCMXCIV", 1994)]
        //[InlineData("AAABBB", 0)]
        public void ToRoman_TestCases(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = _sut.ToRoman(roman);

            // assert
            result.Should().Be(expectedInt);

        }
    }
}
