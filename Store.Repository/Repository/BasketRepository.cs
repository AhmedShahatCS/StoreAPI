using StackExchange.Redis;
using Store.Core.Entity;
using Store.Core.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase() ;
        }
      
        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _redis.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var Basket = await _redis.StringGetAsync(id);
            return Basket.IsNull ? null : JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var jsonbasket = JsonSerializer.Serialize(basket);
            var createdorupdated = await _redis.StringSetAsync(basket.Id, jsonbasket, TimeSpan.FromDays(1));
            if (!createdorupdated) return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
