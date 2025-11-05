using Shared;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Contracts
{
    public interface IProductService
    {


        Task<PaginatedResult<ProductDto>> GellAllProductsAsync(SepecificationParameters spec_params);

        Task<IEnumerable<BrandDto>> GellAllBrandsAsync();


        Task<IEnumerable<TypeDto>> GellAllTypesAsync();


        Task<ProductDto> GetProductById(int id);

    }

}
