using AutoMapper;
using Domain.Contracts;
using Domain.Entites.BasketModule;
using Domain.Exceptions;
using Service.Abstraction.Contracts;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class BasketService (IBasketRepository _basketRepository,IMapper _mapp): IBasketService
    {
        public async Task<BasketDTO> CreateOrUpdate(BasketDTO basketDTO, TimeSpan TTL = default)
        {

         var item= await _basketRepository.CreateOrUpdateBasketAsync(_mapp.Map<CustomerBasket>(basketDTO));


            if (item != null) { return _mapp.Map<BasketDTO>(item); }

            else throw new Exception("can not create");
               

        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _basketRepository.DeleteBasketAsync(id);

        }

        public async Task<BasketDTO> GetBasketAsync(string id)
        {


            var item =     _mapp.Map<BasketDTO>( 
              await  _basketRepository.GetByIdAsync(id));
            if (item is null) throw new BasketNotFoundException(id);

            else return item;
        }
    }
}
