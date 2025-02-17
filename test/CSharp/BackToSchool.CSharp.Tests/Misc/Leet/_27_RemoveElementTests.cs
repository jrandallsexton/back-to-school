
using BackToSchool.CSharp.Misc.Leet;

using FluentAssertions;

using System.Collections;
using System.Collections.Generic;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc.Leet
{
    public class _27_RemoveElementTests
    {
        [Theory]
        [ClassData(typeof(RemoveElementsTestData))]
        public void RemoveElementTests(int[] nums, int val, int expected)
        {
            // arrange
            var sut = new _27_RemoveElement();

            // act
            var result = sut.RemoveElement(nums, val);

            // assert
            result.Should().Be(expected);
        }
    }

    public class RemoveElementsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [new[] { 3, 2, 2, 3 }, 3, 2];
            yield return [new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5];
            yield return [new int[] {}, 2, 0];
            yield return [new[] { 1 }, 1, 0];
            yield return [new[] { 2 }, 3, 1];
            yield return [new[] { 3, 3 }, 5, 2];
            yield return [new[] { 1, 1 }, 1, 0];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
