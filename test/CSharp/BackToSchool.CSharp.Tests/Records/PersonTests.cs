
using BackToSchool.CSharp.Records;

using FluentAssertions;

using System;
using System.Linq;

using Xunit;

namespace BackToSchool.CSharp.Tests.Records
{
    public class PersonTests
    {
        [Fact]
        public void ShowsDistinct()
        {
            // arrange
            var people = new PersonRecord[]
            {
                new("Joe", new DateOnly(1997, 4, 28)),
                new("Jane", new DateOnly(1982, 5, 14)),
                new("Joe", new DateOnly(1986, 7, 19)),
                new("Joe", new DateOnly(1997, 4, 28)),
                new("Jane", new DateOnly(1982, 5, 14))
            };

            // act & assert
            people.Length.Should().Be(5);
            people.Distinct().Count().Should().Be(3);
        }
    }
}
