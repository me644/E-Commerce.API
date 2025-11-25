using Domain.Entites.OrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications 
{
    public class OrderWithIncludeSpecifications : BaseSpecification<Order, Guid>
    {
        public OrderWithIncludeSpecifications(Guid id) : base(o=>o.Id==id)
        {

            AddIncludes(o => o.DeliveryMethod);
            AddIncludes(o=>o.orderItems);

        }

        public OrderWithIncludeSpecifications(string email) : base(o => o.UserEmail == email)
        {

            AddIncludes(o => o.DeliveryMethod);
            AddIncludes(o => o.orderItems);
           AddIncludes(o=>o.OrderDate);
        }
    }
}
