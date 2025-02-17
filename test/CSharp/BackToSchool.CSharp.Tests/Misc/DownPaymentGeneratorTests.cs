using BackToSchool.CSharp.Misc;

using FluentAssertions;

using System.Collections;
using System.Collections.Generic;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class DownPaymentGeneratorTests
    {
        [Fact]
        public void Dynamic_Foo()
        {
            // arrange
            var command = new GenerateDownPaymentCommand()
            {
                Type = IncrementType.Dynamic,
                TierCount = 5,
                InitialDownpayment = 1_000.00m,
                PurchasePrice = 25_000.00m,
                Steps =
                [
                    1.1,
                    1.25,
                    1.5,
                    1.75,
                    2.0
                ]
            };

            var generator = new DownPaymentGenerator();

            // act
            var results = generator.GenerateDownPayments(command);

            // assert
            results.Count.Should().Be(command.TierCount);
            results.Should().Contain(1_100.00m);
            results.Should().Contain(1_250.00m);
            results.Should().Contain(1_500.00m);
            results.Should().Contain(1_750.00m);
            results.Should().Contain(2_000.00m);
        }
    }

    public class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new[] { "foo", "bar " } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
