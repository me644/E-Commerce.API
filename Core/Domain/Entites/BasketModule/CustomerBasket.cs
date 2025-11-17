using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.BasketModule
{
    public class CustomerBasket
    {

        public string id { get; set; } = string.Empty;

        public ICollection<BasketItems> BasketItems { get; set; } = [];
    }
}
