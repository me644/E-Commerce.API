 using AutoMapper;
using Domain.Entites.Product;
using Microsoft.Extensions.Configuration;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingServices
{
    public class PictureUrlResolver(IConfiguration configurationProvider) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {


            return $"{configurationProvider.GetSection("URLS")["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
