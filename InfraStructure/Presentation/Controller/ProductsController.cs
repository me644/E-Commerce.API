using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.Contracts;
using Shared;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController(ISerivceMnager _serivceMnager):ControllerBase
    {
         
        [HttpGet("Products")]
        public async Task< ActionResult<PaginatedResult <ProductDto>>> GetAllProducts(SepecificationParameters spec_params)
        {

            var Products=  await _serivceMnager.ProductService.GellAllProductsAsync(spec_params);

            

            return Ok(Products);

        }

        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var types= await _serivceMnager.ProductService.GellAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("Brands")]

        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var types = await _serivceMnager.ProductService.GellAllBrandsAsync();
            return Ok(types);
        }



        [HttpGet("Product/{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int ? id)
        {
            var product = await _serivceMnager.ProductService.GetProductById(id.Value);
            return Ok(product);
        }




    }
}
