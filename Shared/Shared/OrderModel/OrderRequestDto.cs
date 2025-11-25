using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared.OrderModel
{
    public class OrderRequestDto
    {
        public string Basket_id {  get; set; }

        public AddressDto Address { get; set; }

        public int  DeliveryMethodId {  get; set; }


    }
}
