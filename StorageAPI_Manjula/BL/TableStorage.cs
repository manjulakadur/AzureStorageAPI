using Azure.Data.Tables;
using Azure;
using StorageAPI_Manjula.Services;

namespace StorageAPI_Manjula.BL
{
    public class TableStorage :ITableStorage
    {
        private const string TableName = "Item";
        private readonly IConfiguration _configuration;
        public TableStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private async Task<TableClient> GetTableClient()
        {
            var serviceClient = new TableServiceClient(_configuration.GetValue<string>("MyConfig:StorageConnection"));

            var tableClient = serviceClient.GetTableClient(TableName);
            await tableClient.CreateIfNotExistsAsync();
            return tableClient;
        }
        public async Task<GroceryItemEntity> GetEntityAsync(string name, string id)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<GroceryItemEntity>(name, id);

        }
        public async Task<GroceryItemEntity> UpsertEntityAsync(GroceryItemEntity entity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }
        public async Task DeleteEntityAsync(string name, string id)
        {
            var tableClient = await GetTableClient();
            await tableClient.DeleteEntityAsync(name, id);
        }

    }
    public class GroceryItemEntity : ITableEntity
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public GroceryItemEntity()
        {
            Id = string.Empty;
            Name = string.Empty;
            Price = 0;
            PartitionKey = string.Empty;
            RowKey = string.Empty;
            Timestamp = new DateTimeOffset();
            ETag = new ETag();
        }
    }
}
