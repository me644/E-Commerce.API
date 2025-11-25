using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OrderNotFoundExceptions : NotFoundExceptions
    {
        public OrderNotFoundExceptions(string id) : base($"this id {id}  Not found")
        {
        }
    }
}
