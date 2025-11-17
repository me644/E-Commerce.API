using Domain.Entites.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {

        Task<CustomerBasket?> GetByIdAsync(string basketId);

        Task<CustomerBasket?>CreateOrUpdateBasketAsync(CustomerBasket basket,TimeSpan TTL=default);

        Task<bool> DeleteBasketAsync(string basketId);





    }
}
