using BackToSchool.CSharp.Azure.CosmosDb;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using BackToSchool.CSharp.Shared;

namespace BackToSchool.CSharp.Tests.Azure.CosmosDb
{
    public class CosmosNoSqlTests
    {
        [Fact]
        public async Task GetAccountProperties()
        {
            // arrange
            var sut = new CosmosNoSql();

            // act
            var props = await sut.GetAccountPropertiesAsync();

            // assert
            props.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateDatabase()
        {
            // arrange
            var sut = new CosmosNoSql();

            // act
            var httpResponse = await sut.CreateDatabaseAsync("Test-Db");

            // assert
            httpResponse.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateContainerAsync()
        {
            // arrange
            var sut = new CosmosNoSql();

            // act
            var httpResponse = await sut.CreateContainerAsync("Test-Db", "venues", "providerId");

            // assert
            httpResponse.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task AddItemAsync()
        {
            // arrange
            var sut = new CosmosNoSql();

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
            var httpResponse = await sut.AddItemAsync(item, "Test-Db", "venues", "providerId");

            // assert
            httpResponse.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task AddItemsAsync()
        {
            // arrange
            var sut = new CosmosNoSql();

            var items = new List<TestPoco>()
            {
                new(
                    id: "EEEE2232-915C-4DE2-0186-08DC6B411EB7",
                    providerId: "espn",
                    externalId: "1400",
                    category: "venue",
                    name: "Tiger Stadium",
                    capacity: 92500,
                    isGrass: true
                ),
                new(
                    id: "6F6E2D80-DF50-41B3-018B-08DC6B411EB7",
                    providerId: "espn",
                    externalId: "1401",
                    category: "venue",
                    name: "Razorback Stadium",
                    capacity: 92750,
                    isGrass: true
                )
            };

            // act
            var httpResponse = await sut.AddItemsAsync(items, "Test-Db", "venues", "espn");

            // assert
            httpResponse.Should().Be(HttpStatusCode.OK);
        }
    }
}
