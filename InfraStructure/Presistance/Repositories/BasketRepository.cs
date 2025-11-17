using Domain.Contracts;
using Domain.Entites;
using Domain.Entites.BasketModule;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistance.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private IDatabase _database;

        public BasketRepository(IConnectionMultiplexer connectionMultiplexer) { 
        
            _database = connectionMultiplexer.GetDatabase();
        }
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan TTL = default)
        {


            var jsonBasket=JsonSerializer.Serialize(basket);
          var isCreatedOrUpdate=   await _database.StringSetAsync(basket.id.ToString(), value: jsonBasket, TTL ==default  ? TimeSpan.FromDays(7) : TTL);
            if (isCreatedOrUpdate is true)
            {
                var Basket = await _database.StringGetAsync(basket.id.ToString());

                return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
            }
            else return null;

        }



        public async Task<bool> DeleteBasketAsync(string basketId)
        {


            bool Is_Deleated = await _database.KeyDeleteAsync(basketId);
            return Is_Deleated;

        }

        public  async Task<CustomerBasket?> GetByIdAsync(string basketId)
        {
            var Basket = await _database.StringGetAsync(basketId);


            if(Basket .IsNull ) { return null; }

            return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
        }
    }
}
