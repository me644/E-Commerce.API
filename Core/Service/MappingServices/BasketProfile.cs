using AutoMapper;
using Domain.Entites.BasketModule;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingServices
{
    public class BasketProfile:Profile
    {

        public BasketProfile() {


            CreateMap<CustomerBasket, BasketDTO>().ReverseMap();

            CreateMap<BasketItems,BasketItemDto>().ReverseMap();
        
        }
    }
}
