
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
        [InlineData("MMMCMXCIX", 3999)]
        public void FromRoman(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.FromRoman(roman);

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
        [InlineData("MMMCMXCIX", 3999)]
        public void FromRoman_NaiveBruteForce(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.FromRoman_NaiveBruteForce(roman);

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
        [InlineData("MMMCMXCIX", 3999)]
        public void FromRomanLinear(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.FromRomanLinear(roman);

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
        [InlineData("MMMCMXCIX", 3999)]
        public void FromRomanLinearAllSpansSubtraction(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.FromRomanLinearAllSpansSubtraction(roman);

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
        [InlineData("MMMCMXCIX", 3999)]
        public void FromRomanLastShot(string roman, int expectedInt)
        {
            // arrange

            // act
            var result = RomanNumeralConverter.FromRomanLastShot(roman);

            // assert
            result.Should().Be(expectedInt);
        }
    }
}
