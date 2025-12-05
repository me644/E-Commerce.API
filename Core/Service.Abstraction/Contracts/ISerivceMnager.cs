using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Contracts
{
    public interface ISerivceMnager
    {
        public IProductService ProductService { get; }


        public IBasketService BasketService { get; }


       public  IOrderService OrderService { get; }

        public  IAuthenticationService AuthenticationService { get; }

    }
}
