using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Product
{
    public class ProductBrand:Base<int>
    {

        public string Name { get; set; } = null!;

    }
}
