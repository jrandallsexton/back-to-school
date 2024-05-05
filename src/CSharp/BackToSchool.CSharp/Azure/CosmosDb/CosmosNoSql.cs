
using System.Collections.Generic;
using Microsoft.Azure.Cosmos;

using System.Net;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Azure.CosmosDb
{
    public class CosmosNoSql
    {
        private const string Endpoint = "https://btsnosql.documents.azure.com:443/";

        private const string AccessToken =
            "EwsYIr5WXIuiys2wMUv0Xb6WHPYwifZuzfl6zGYup6u3ifj74ExWionQbXmD6Y5hl2tcxca2tA7sACDbbIg7yA==";

        public async Task<AccountProperties> GetAccountPropertiesAsync()
        {
            // New instance of CosmosClient class using an endpoint and key string
            using CosmosClient client = new(
                accountEndpoint: Endpoint,
                authKeyOrResourceToken: AccessToken
            );
            var accountProps = await client.ReadAccountAsync();
            return accountProps;
        }

        public async Task<HttpStatusCode> CreateDatabaseAsync(string databaseName)
        {
            using CosmosClient client = new(
                accountEndpoint: Endpoint,
                authKeyOrResourceToken: AccessToken
            );
            var createDatabaseResponse = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            return createDatabaseResponse.StatusCode;
        }

        public async Task<HttpStatusCode> CreateContainerAsync(
            string dbName, string containerName, string partitionKey)
        {
            using CosmosClient client = new(
                accountEndpoint: Endpoint,
                authKeyOrResourceToken: AccessToken
            );
            var db = client.GetDatabase(dbName);
            var createContainerResponse = await db.CreateContainerAsync(containerName, $"/{partitionKey}");
            return createContainerResponse.StatusCode;
        }

        public async Task<HttpStatusCode> AddItemAsync<T>(T item,
            string dbName, string containerName, string partitionKey)
        {
            using CosmosClient client = new(
                accountEndpoint: Endpoint,
                authKeyOrResourceToken: AccessToken
            );
            var db = client.GetDatabase(dbName);
            var container = db.GetContainer(containerName);

            var createItemResponse = await container.CreateItemAsync<T>(item);

            return createItemResponse.StatusCode;
        }

        public async Task<HttpStatusCode> AddItemsAsync<T>(IEnumerable<T> items,
            string dbName, string containerName, string partitionKey)
        {
            using CosmosClient client = new(
                accountEndpoint: Endpoint,
                authKeyOrResourceToken: AccessToken
            );
            var db = client.GetDatabase(dbName);
            var container = db.GetContainer(containerName);

            var batch = container.CreateTransactionalBatch(new PartitionKey(partitionKey) {});

            foreach (var item in items)
            {
                batch.CreateItem(item);
            }

            var result = await batch.ExecuteAsync();
            return result.StatusCode;
        }
    }
}