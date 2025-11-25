using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared.OrderModel
{
    public  record OrderResult
    {


        public string UserEmail { get; init; } = string.Empty;


        public AddressDto shippingAddress { get; init; }

        public ICollection<OrderITemsDto> orderItems { get; init; } = [];

        public string OrderPayment { get; init; } = string.Empty;
        public string DeliveryMethod { get; init; }= string.Empty;
       // public int DeliveryMethodId { get; init; }
        public decimal Total { get; init; }

        public string PaymentIntenId { get; init; } = string.Empty;
        public DateTimeOffset OrderDate { get; init; } = DateTimeOffset.UtcNow;


    }
}
