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
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.Property(e => e.Price).HasColumnType("decimal(10,2)");
            builder.OwnsOne(o => o.productOrder, p => p.WithOwner());

            ///

           
        }
    }
}
