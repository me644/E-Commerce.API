using Domain.Entites.OrderModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Configuration
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.orderItems).WithOne();
            builder.OwnsOne(o => o.shippingAddress);


            builder.Property(e => e.OrderPayment).HasConversion(e => e.ToString(), e => (OrderPaymentMethode)Enum.Parse<OrderPaymentMethode>(e));
            builder.HasOne(o => o.DeliveryMethod).WithMany();//order  is  delivered by one  methode
                                                             //  Delveriy for  many orders 

        }
    }
}
