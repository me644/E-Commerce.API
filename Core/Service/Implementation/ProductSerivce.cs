    using AutoMapper;
using Domain.Contracts;
using Domain.Entites.Product;
using Domain.Exceptions;
using Service.Abstraction.Contracts;
using Service.Specifications;
using Shared;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ProductSerivce (IUnitOfWork _unitOfWork,IMapper _mapper): IProductService
    {
        public  async Task<IEnumerable<BrandDto>> GellAllBrandsAsync()
        {
          var brands =   await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
           return _mapper.Map<IEnumerable<   BrandDto>>(brands);
        }


        public async  Task<PaginatedResult<ProductDto>> GellAllProductsAsync(SepecificationParameters spec_params)
        {
            var spec = new ProductSpecification(spec_params);

            var spec_count = new CountSpecification(spec_params); 
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(spec);
            int _count=products
                .Count();




            int _Total =      await  _unitOfWork.GetRepository<Product, int>().CountAsync(spec);
            var paginated=new PaginatedResult<ProductDto>()
            { Data = _mapper.Map<IEnumerable<ProductDto>>(products),Page_Index=spec_params.PagaIndex ,Count=_count,Total=_Total};
            return paginated;


            // return _mapper.Map<PaginatedResult<ProductDto>>(products);
        }

      
        public async Task<IEnumerable<TypeDto>> GellAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(Types);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var spec = new ProductSpecification(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetbyIdAsync(spec);

              return product is null  ?  throw  new  ProductNotFoundException(id) :  _mapper.Map<ProductDto>(product);




        }
    }
}
