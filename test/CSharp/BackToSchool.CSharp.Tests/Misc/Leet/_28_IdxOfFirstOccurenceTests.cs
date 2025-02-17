using BackToSchool.CSharp.Misc.Leet;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc.Leet
{
    public class _28_IdxOfFirstOccurenceTests
    {
        [Theory]
        [InlineData("sadbutsad", "sad", 0)]
        [InlineData("leetcode", "leeto", -1)]
        [InlineData("hello", "ll", 2)]
        [InlineData("a", "a", 0)]
        [InlineData("abc", "c", 2)]
        public void Foo(string haystack, string needle, int expectedIndex)
        {
            // arrange

            var sut = new _28_IdxOfFirstOccurence();

            // act
            var result = sut.StrStr(haystack, needle);

            // assert
            result.Should().Be(expectedIndex);
        }
    }
}
