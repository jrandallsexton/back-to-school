
using BackToSchool.CSharp.Azure.ServiceBus;
using BackToSchool.CSharp.Shared;

using FluentAssertions;

using System.Threading.Tasks;

using Xunit;

namespace BackToSchool.CSharp.Tests.Azure.ServiceBus
{
    public class AzSvcBusPlaygroundTests
    {
        [Fact]
        public async Task SendMessageAsync()
        {
            // arrange
            var sut = new AzSvcBusPlayground();

            var item = new TestPoco(
                id: "EEEE2232-915C-4DE2-0186-08DC6B411EB7",
                providerId: "espn",
                externalId: "1400",
                category: "venue",
                name: "Tiger Stadium",
                capacity: 92500,
                isGrass: true
            );

            // act
            var result = await sut.SendMessageAsync(item);

            // assert
            result.Error.Should().BeNull();
        }

        [Fact]
        public async Task ReceiveMessageAsync()
        {
            // arrange
            var sut = new AzSvcBusPlayground();

            var item = new TestPoco(
                id: "EEEE2232-915C-4DE2-0186-08DC6B411EB7",
                providerId: "espn",
                externalId: "1400",
                category: "venue",
                name: "Tiger Stadium",
                capacity: 92500,
                isGrass: true
            );

            // act
            var result = await sut.ReceiveMessageAsync<TestPoco>("venuequeue");

            // assert
            result.Error.Should().BeNull();
            result.Value.id.Should().Be(item.id);
        }
    }
}
