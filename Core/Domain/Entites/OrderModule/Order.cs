using Domain.Entites.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingAddress = Domain.Entites.OrderModule.Address; 

namespace Domain.Entites.OrderModule
{
    public class Order
    {
        public  string UserEmail {  get; set; }=string.Empty;


           public  ShippingAddress shippingAddress { get; set; }

        public ICollection<OrderItems> orderItems { get; set; } = [];

        public OrderPaymentMethode OrderPayment { get; set; }=OrderPaymentMethode.Pending;  
        public DeliveryMethod DeliveryMethod { get; set; }
        public int DeliveryMethodId { get; set; }
        public decimal SubTotal{  get; set; }

        public string PaymentIntenId { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;


    }

  
}
