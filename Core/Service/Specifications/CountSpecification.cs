using Domain.Entites.Product;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class CountSpecification :BaseSpecification<Product,int>
    {


        public CountSpecification(SepecificationParameters spec_params) :
     base(p => (!spec_params.Brand_id.HasValue || p.BrandId == spec_params.Brand_id) && (!spec_params.type_id.HasValue || p.TypeId == spec_params.type_id))
        { }
    }
}
