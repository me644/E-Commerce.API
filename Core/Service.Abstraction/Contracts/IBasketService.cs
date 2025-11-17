using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Contracts
{
    public interface IBasketService
    {

        //Get 
      Task<BasketDTO> GetBasketAsync(string id);


        //Delete
        Task<bool>DeleteAsync(string id);

        //CreateOrUpdate
        Task<BasketDTO> CreateOrUpdate(BasketDTO basketDTO, TimeSpan TTL = default);
    }
}
