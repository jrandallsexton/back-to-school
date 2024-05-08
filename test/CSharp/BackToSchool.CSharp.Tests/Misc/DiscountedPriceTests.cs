
using BackToSchool.CSharp.Misc;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    public class DiscountedPriceTests
    {
        [Fact]
        public void GetDiscountedPrice()
        {
            // arrange
            var sut = new DiscountedPrice();

            // act
            var result = sut.GetDiscountedPrice(12, 100, DiscountType.Weight);

            // assert
            result.Should().Be(82.0);
        }
    }
}
