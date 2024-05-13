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
    public class PhoneNumberWordsTests
    {
        private readonly PhoneNumberWords _sut = new();


        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("       ", 0)]
        public void LetterCombinations_EmptyStrings(string digits, int expectedCount)
        {
            // arrange
            var sut = new PhoneNumberWords();

            // act
            var result = sut.LetterCombinations(digits);

            // assert
            result.Count.Should().Be(expectedCount);
        }
    }
}
