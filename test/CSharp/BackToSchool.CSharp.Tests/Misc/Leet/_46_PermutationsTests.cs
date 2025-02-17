
using BackToSchool.CSharp.Misc.Leet;

using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BackToSchool.CSharp.Tests.Misc.Leet
{
    public class _46_PermutationsTests
    {
        [Theory]
        [ClassData(typeof(PermutationsTestData))]
        public void Foo(int[] nums, int expectedLength)
        {
            // arrange
            var sut = new _46_Permutations();

            // act
            var result = sut.Permute(nums);

            // assert
            result.Count.Should().Be(expectedLength);
        }
    }

    public class PermutationsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [new[] { 1, 2, 3 }, 6];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
