using AutoMapper;
using Domain.Entites.OrderModule;
using Shared.Shared.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingServices
{
    public class OrderProfile: Profile
    {

        public OrderProfile() {

           
         
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<DeleviryMethodResultDto, DeliveryMethod>().ReverseMap();

            CreateMap<OrderItems, OrderITemsDto>().ForMember(o => o.ProductId, op => op.MapFrom(src => src.productOrder.ProductId))
               .ForMember(o => o.ProductName, op => op.MapFrom(src => src.productOrder.ProductName))
               .ForMember(o => o.PictureUrl, op => op.MapFrom(src => src.productOrder.PictureUrl));

            CreateMap<Order, OrderResult>().ForMember(dest => dest.OrderPayment, op => op.MapFrom(Src => Src.OrderPayment.ToString())).
                ForMember(dest => dest.DeliveryMethod, op => op.MapFrom(Src => Src.DeliveryMethod.ShortName))
               .ForMember(dest => dest.Total, op => op.MapFrom(Src => Src.SubTotal + Src.DeliveryMethod.Price));

        }



    }
}
