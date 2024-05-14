
using BackToSchool.CSharp.Records;

using FluentAssertions;

using System;
using System.Linq;
using BenchmarkDotNet.Jobs;
using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.Records
{
    public class PersonTests
    {
        private readonly ITestOutputHelper _output;

        public PersonTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

        [Fact]
        public void UsingWith()
        {
            var joe = new PersonRecord("Joe", new DateOnly(1997, 4, 28));

            var jim = joe with { Name = "Jim" };

            _output.WriteLine(joe.ToString());
            _output.WriteLine(jim.ToString());
            joe.ToString().Should().Contain("Joe");
            jim.ToString().Should().Contain("Jim");
            joe.Should().NotBe(jim);
        }
    }
}
