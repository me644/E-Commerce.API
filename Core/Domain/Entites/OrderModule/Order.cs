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
:Base<Guid>    {

        public Order() { }
        public Order(string userEmail, ShippingAddress shippingAddress, ICollection<OrderItems> orderItems, DeliveryMethod deliveryMethod, decimal subTotal)
        {
            UserEmail = userEmail;
            this.shippingAddress = shippingAddress;
            this.orderItems = orderItems;
            DeliveryMethod = deliveryMethod;
            SubTotal = subTotal;
        }

        public  string UserEmail {  get; set; }=string.Empty;


           public  ShippingAddress shippingAddress { get; set; }

        public ICollection<OrderItems> orderItems { get; set; } = [];

        public OrderPaymentMethode OrderPayment { get; set; }  
        public DeliveryMethod DeliveryMethod { get; set; }
        public int DeliveryMethodId { get; set; }
        public decimal SubTotal{  get; set; }

        public string PaymentIntenId { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;


    }

  
}
