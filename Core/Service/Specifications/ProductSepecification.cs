using Domain.Entites.Product;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public   class ProductSpecification : BaseSpecification<Product, int>
    {

        public ProductSpecification(SepecificationParameters spec_params)  :
            base(p => (!spec_params.Brand_id.HasValue || p.BrandId == spec_params.Brand_id) && (!spec_params.type_id.HasValue || p.TypeId == spec_params.type_id))
        {

                                                                                     

            switch (spec_params.sort) {

                case OrderEnum.NameAsc: AddOrderBy(p => p.Name);
                    break;


                case OrderEnum.NameDec:
                    AddOrderByDec(p => p.Name);
                    break;
                case OrderEnum.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case OrderEnum.PriceDec:
                    AddOrderByDec(p => p.Price);
                    break;


            }





            ApplyPagination(spec_params.PagaIndex, spec_params.PageSize);
          
        }

     





        public ProductSpecification(int id) : base(p=>p.Id==id)
        {


            AddIncludes(p=>p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }

      



    }
}
