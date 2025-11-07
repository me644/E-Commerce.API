using AutoMapper;
using Domain.Entites.Product;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Service.MappingServices
{
    public class ProductProfile:Profile
    {

        public ProductProfile() {



            CreateMap<ProductBrand, BrandDto>();

       CreateMap<ProductType, TypeDto>();


            CreateMap<Product, ProductDto>()
     .ForMember(dest => dest.BrandName,
                options => options.MapFrom(src => src.ProductBrand.Name))

      .ForMember(dest => dest.TypeName,
                options => options.MapFrom(src => src.ProductType.Name))
     .ForMember(dest => dest.PictureUrl, options => options.MapFrom<PictureUrlResolver>());















        }

    }
}
