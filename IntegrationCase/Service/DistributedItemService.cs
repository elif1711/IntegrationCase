using StackExchange.Redis;

namespace IntegrationCase.Service
{
    public class DistributedItemService
    {
        private readonly IDatabase _database;

        public DistributedItemService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            _database = redis.GetDatabase();
        }

        public async Task<string> AddItemAsync(string itemContent)
        {
            await Task.Delay(2000);

            if (await _database.StringGetAsync(itemContent) != RedisValue.Null)
            {
                return "Duplicate item.";
            }
            await _database.StringSetAsync(itemContent, true);
            return "Items added.";
        }
    }
}