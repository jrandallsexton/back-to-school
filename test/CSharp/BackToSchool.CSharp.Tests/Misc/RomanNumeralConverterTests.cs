
using BackToSchool.CSharp.Misc;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class RomanNumeralConverterTests
    {
        //RomanNumeralConverter _sut = new RomanNumeralConverter();

        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("", 0)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("AAABBB", 0)]
        public void ToRoman_TestCases(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.ToRoman(roman);

            // assert
            result.Should().Be(expectedInt);

        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("", 0)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("AAABBB", 0)]
        public void ToRoman_NaiveBruteForce(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.ToRoman_NaiveBruteForce(roman);

            // assert
            result.Should().Be(expectedInt);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("", 0)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("AAABBB", 0)]
        public void ToRomanLinear(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.ToRomanLinear(roman);

            // assert
            result.Should().Be(expectedInt);
        }
    }
}
